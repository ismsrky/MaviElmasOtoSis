using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class ucCariHesapDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        cari_hesap cari;

        int _Secili_CariID;

        DataTable dt_AdresIlce;

        public DetayOlayHandler DetayOlay;
        #endregion

        #region < Özellikler >
        public Enumlar.DetayModelari DetayMode
        {
            get
            {
                return _DetayMode;
            }
            set
            {
                _DetayMode = value;
                if (value == Enumlar.DetayModelari.SadeceKaydet)
                {
                    btnKaydet.Visible = true;
                    btnSil.Visible = btnYeniKayit.Visible = false;
                }
                else if (value == Enumlar.DetayModelari.SadeceOku)
                {
                    btnKaydet.Visible = btnSil.Visible = btnYeniKayit.Visible = false;
                }
                else if (value == Enumlar.DetayModelari.Tum)
                {
                    btnKaydet.Visible = btnSil.Visible = btnYeniKayit.Visible = true;
                }
            }
        }

        public int Secili_CariID
        {
            get
            {
                return _Secili_CariID;
            }
        }
        #endregion

        #region < Load >
        public ucCariHesapDetay()
        {
            InitializeComponent();

            if (this.IsInDesignMode) return;
            try
            {
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                #region databind
                Isler.Genelkodlar.Ver_Kod("CariHesapGrup", ref lookUpCariHesapGrup, "Lütfen Seçiniz");

                lookUpAdresIl.Properties.DisplayMember = "IlAdi";
                lookUpAdresIl.Properties.ValueMember = "Plaka";
                lookUpAdresIl.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Genel.dt_Iller.Copy(), "IlAdi", "Plaka");
                #endregion

                Temizle_Cari();
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        private void ucCariHesapDetay_Load(object sender, EventArgs e)
        {
                    
        }
        #endregion

        #region < Olaylar >
        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }
        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            Yeni();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }

        private void lookUpAdresIl_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpAdresIl.EditValue == null) return;

            int editvalue = Convert.ToInt32(lookUpAdresIl.EditValue);

            dt_AdresIlce = null;
            dt_AdresIlce = Isler.Adres.Ver_Ilce(editvalue);


            lookUpAdresIlce.Properties.DisplayMember = "IlceAdi";
            lookUpAdresIlce.Properties.ValueMember = "IlceID";
            lookUpAdresIlce.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(dt_AdresIlce, "IlceAdi", "IlceID");

            lookUpAdresIlce.EditValue = -1;
        }

        private void chkDurum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDurum.Checked)
                chkDurum.Text = "Aktif";
            else
                chkDurum.Text = "Pasif";
        }

      
        #endregion

        #region < Metod >
        public void Yukle_Cari(int _CariID)
        {
            if (Yukleme) return;

            try
            {
                Temizle_Cari();
                _YeniKayit = false;

                if (cari != null && cari.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(cari);
                }
                cari = null;
                cari = Isler.Cari.Ver_CariHesap(ref dbModel, _CariID);
                if (cari == null) return;

                txtCariID.Text = cari.CariID.ToString();
                lookUpCariHesapGrup.EditValue = cari.CariHesapGrup;
                txtUnvan.Text = cari.Unvan;
                chkDurum.Checked = cari.Durum;
                txtTcKimlik.Text = cari.TcKimlikNo;
                memoAciklama.Text = cari.Aciklama;

                txtYetkiliKisiAdi.Text = cari.YetkiliKisiAd;
                txttxtYetkiliKisiSoyad.Text = cari.YetkiliKisiSoyad;
                txtYetkiliKisiGorev.Text = cari.YetkiliKisiGorev;
                txtYetkiliKisiDahili.Text = cari.YetkiliKisiDahili;
                txtYetkiliKisiEposta.Text = cari.YetkiliKisiEposta;
                txtYetkiliKisiCepTel.Text = cari.YetkiliKisiCep;

                txtTel1.Text = cari.Tel1;
                txtTel2.Text = cari.Tel2;
                txtFax.Text = cari.Fax;
                txtWeb.Text = cari.Web;
                txtEposta.Text = cari.Eposta;
                if (cari.AdresIl != null)
                {
                    lookUpAdresIl.EditValue = cari.AdresIl.Value;
                }
                if (cari.AdresIlce != null)
                {
                    lookUpAdresIlce.EditValue = cari.AdresIlce.Value;
                }
                memoAcikAdres.Text = cari.AdresAcik;

                txtVergiDairesi.Text = cari.VergiDairesi;

                _Secili_CariID = cari.CariID;

                ucKayitBilgi1.Yukle(cari.KayitKullaniciID, cari.KayitZaman, cari.DuzenKullaniciID, cari.DuzenZaman);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Cari Hesap Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Sil()
        {
            if (cari == null) return;

            if (!Genel.Yetkilerim.Contains(12))
            {
                Genel.Yetki_Uyari(12);
                return;
            }
            try
            {
                if (Isler.Cari.Ver_AdetCariHareket(cari.CariID) > 0)
                {
                    XtraMessageBox.Show("Seçili Cari Hesap Hareket Görmüş; Silinemez.", "Geçersiz İşlem",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show("Seçili Cari Hesabı Silmek İstediğinize Emin Misiniz?\n"
                   + "Cari Hesap No: " + cari.CariID.ToString()
                   + "\nÜnvanı : " + cari.Unvan, "Cari Hesap Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(cari);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Cari Hesap Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    if (DetayOlay != null)
                    {
                        this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                    }
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Cari Hesap Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Kaydet()
        {
            if ((_YeniKayit && !Isler.Yetki.Varmi_Yetki(11)) || !_YeniKayit && !Isler.Yetki.Varmi_Yetki(13)) return;

            try
            {
                #region < Kontroller >
                if (string.IsNullOrEmpty(txtUnvan.Text.Trim()))
                {
                    XtraMessageBox.Show("Cari Ünvanı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    xtraTabControl1.SelectedTabPageIndex = 0;
                    txtUnvan.Focus(); txtUnvan.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtTcKimlik.Text.Trim()))
                {
                    XtraMessageBox.Show("Cari Tc Kimlik No / Vergi No Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    xtraTabControl1.SelectedTabPageIndex = 0;
                    txtTcKimlik.Focus(); txtTcKimlik.Select();
                    return;
                }
                if (lookUpCariHesapGrup.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Cari Hesap Grubunu Seçiniz.", "Değer Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    xtraTabControl1.SelectedTabPageIndex = 0;
                    lookUpCariHesapGrup.Focus(); lookUpCariHesapGrup.Select();
                    return;
                }
                if (_YeniKayit && Isler.Cari.Varmi_CariUnvan(txtUnvan.Text))
                {
                    XtraMessageBox.Show("Bu Cari Ünvanı Daha Önce Tanımlanmış.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnvan.Focus(); txtUnvan.Select();
                    return;
                }
                else if (!_YeniKayit && txtUnvan.Text != cari.Unvan && Isler.Cari.Varmi_CariUnvan(txtUnvan.Text, cari.Unvan))
                {
                    XtraMessageBox.Show("Bu Cari Ünvanı Daha Önce Tanımlanmış.", "Aynı Değer",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnvan.Focus(); txtUnvan.Select();
                    return;
                }
                #endregion

                if (_YeniKayit)
                {
                    if (cari != null && cari.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(cari);
                    }
                    cari = null;
                    cari = new cari_hesap();
                    cari.SirketID = Genel.AktifSirket.SirketID;
                }

                #region Aktarma
                cari.CariHesapGrup = lookUpCariHesapGrup.EditValue.ToString();
                cari.Unvan = txtUnvan.Text;
                cari.Durum = chkDurum.Checked;
                cari.TcKimlikNo = txtTcKimlik.Text;
                cari.Aciklama = memoAciklama.Text;

                cari.YetkiliKisiAd = txtYetkiliKisiAdi.Text;
                cari.YetkiliKisiSoyad = txttxtYetkiliKisiSoyad.Text;
                cari.YetkiliKisiGorev = txtYetkiliKisiGorev.Text;
                cari.YetkiliKisiCep = txtYetkiliKisiCepTel.Text;
                cari.YetkiliKisiEposta = txtYetkiliKisiEposta.Text;
                cari.YetkiliKisiDahili = txtYetkiliKisiDahili.Text;

                cari.Tel1 = txtTel1.Text;
                cari.Tel2 = txtTel2.Text;
                cari.Fax = txtFax.Text;
                cari.Web = txtWeb.Text;
                cari.Eposta = txtEposta.Text;
                if (lookUpAdresIl.EditValue.ToString() == "-1")
                {
                    cari.AdresIl = null;
                }
                else
                {
                    cari.AdresIl = Convert.ToInt32(lookUpAdresIl.EditValue);
                }
                if (lookUpAdresIlce.EditValue.ToString() == "-1")
                {
                    cari.AdresIlce = null;
                }
                else
                {
                    cari.AdresIlce = Convert.ToInt32(lookUpAdresIlce.EditValue);
                }
                cari.AdresAcik = memoAcikAdres.Text;

                cari.VergiDairesi = txtVergiDairesi.Text;
                #endregion

                #region Kayıt
                if (_YeniKayit)
                {
                    cari.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    cari.KayitZaman = DateTime.Now;
                    dbModel.AddTocari_hesap(cari);
                }
                else
                {
                    cari.DuzenKullaniciID = Genel.AktifKullanici.DuzenKullaniciID;
                    cari.DuzenZaman = DateTime.Now;
                }
                dbModel.SaveChanges();
                _Secili_CariID = cari.CariID;
                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Cari Hesap Başarılı Bir Şekilde Kaydedilmiştir.", null,
                   ResOtoSis.mark_blue);

                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.Kaydedildi, null);
                }
                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                }

                Yeni();
                #endregion
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Cari Hesap Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Yeni()
        {
            _YeniKayit = true;

            Temizle_Cari();
            xtraTabControl1.SelectedTabPageIndex = 0;
            txtUnvan.Focus(); txtUnvan.Select();

            if (DetayOlay != null && this.Handle.ToInt32() > 0)
            {
                this.Invoke(DetayOlay, Enumlar.DetayOlaylari.YeniKayit, null);
            }
        }

        void Temizle_Cari()
        {
            txtCariID.Text = txtEposta.Text = txtFax.Text = txtTcKimlik.Text = txtTel1.Text = txtTel2.Text
            = txttxtYetkiliKisiSoyad.Text = txtUnvan.Text = txtVergiDairesi.Text = txtWeb.Text = txtYetkiliKisiAdi.Text
            = txtYetkiliKisiCepTel.Text = txtYetkiliKisiDahili.Text = txtYetkiliKisiEposta.Text = txtYetkiliKisiGorev.Text
            = memoAcikAdres.Text = memoAciklama.Text = "";

            lookUpAdresIl.EditValue = lookUpAdresIlce.EditValue = -1;
            lookUpCariHesapGrup.EditValue = "-1";

            chkDurum.Checked = true;
        }

        //void Focus_Tab()
        //{
        //    if (xtraTabControl1.SelectedTabPage == pageCariHareketler)
        //    {
        //        ucCariHareketler1.Ara_CariHareket(Secili_CariID);
        //    }
        //}
        #endregion       
    }
}