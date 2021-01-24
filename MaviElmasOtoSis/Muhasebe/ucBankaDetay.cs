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
    public partial class ucBankaDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        banka bk;

        int _Secili_BankaID;

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

        public int Secili_BankaID
        {
            get
            {
                return _Secili_BankaID;
            }
        }
        #endregion

        #region < Load >
        public ucBankaDetay()
        {
            InitializeComponent();
            if (this.IsInDesignMode) return;
            try
            {
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                #region databind
                Isler.Genelkodlar.Ver_Kod("BankaHesapTuru", ref lookUpHesapTuru, "Lütfen Seçiniz");

                lookUpAdresIl.Properties.DisplayMember = "IlAdi";
                lookUpAdresIl.Properties.ValueMember = "Plaka";
                lookUpAdresIl.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Genel.dt_Iller.Copy(), "IlAdi", "Plaka");
                #endregion

                Temizle_Banka();
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        private void ucBankaDetay_Load(object sender, EventArgs e)
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

        private void tabBanka_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            YukleTablar();
        }
        #endregion

        #region < Metod >
        public void Yukle_Banka(int _BankaID)
        {
            if (Yukleme) return;

            try
            {
                Temizle_Banka();
                _YeniKayit = false;

                if (bk != null && bk.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(bk);
                }
                bk = null;
                bk = Isler.Banka.Ver_Banka(ref dbModel, _BankaID);
                if (bk == null) return;

                txtBankaID.Text = bk.BankaID.ToString();
                lookUpHesapTuru.EditValue = bk.HesapTuru;
                txtBankaAd.Text = bk.BankaAd;
                chkDurum.Checked = bk.Durum;

                txtSubeAd.Text = bk.SubeAd;
                txtSubeKod.Text = bk.SubeKod;
                txtHesapAd.Text = bk.HesapAd;
                txtHesapKod.Text = bk.HesapNo;
                txtKartNo.Text = bk.KartNo;
                txtKartSahibi.Text = bk.KartSahibi;
                txtMusteriNo.Text = bk.MusteriNo;

                txtIbanNo.Text = bk.Iban;

                memoAciklama.Text = bk.Aciklama;

                txtIlgiliKisiAdi.Text = bk.IlgiliKisiAd;
                txtIlgiliKisiSoyad.Text = bk.IlgiliKisiSoyad;
                txtIlgiliKisiGorev.Text = bk.IlgiliKisiGorev;
                txtIlgiliKisiDahili.Text = bk.IlgiliKisiDahili;
                txtIlgiliKisiEposta.Text = bk.IlgiliKisiEposta;
                txtIlgiliKisiCepTel.Text = bk.IlgiliKisiCep;

                txtTel1.Text = bk.Tel1;
                txtTel2.Text = bk.Tel2;
                txtFax.Text = bk.Fax;
                txtWeb.Text = bk.Web;
                txtEposta.Text = bk.Eposta;
                if (bk.AdresIl != null)
                {
                    lookUpAdresIl.EditValue = bk.AdresIl.Value;
                }
                if (bk.AdresIlce != null)
                {
                    lookUpAdresIlce.EditValue = bk.AdresIlce.Value;
                }
                memoAcikAdres.Text = bk.AdresAcik;

                _Secili_BankaID = bk.BankaID;

                ucKayitBilgi1.Yukle(bk.KayitKullaniciID, bk.KayitZaman, bk.DuzenKullaniciID, bk.DuzenZaman);

                if (DetayOlay != null && this.Handle.ToInt32() > 0)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.Yukleme, null);
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Banka Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Sil()
        {
            if (bk == null) return;

            if (!Genel.Yetkilerim.Contains(54))
            {
                Genel.Yetki_Uyari(54);
                return;
            }
            try
            {
                if (Isler.Banka.Ver_AdetBankaHareket(bk.BankaID) > 0)
                {
                    XtraMessageBox.Show("Seçili Banka Hareket Görmüş; Silinemez.", "Geçersiz İşlem",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show("Seçili Banka Hesabı Silmek İstediğinize Emin Misiniz?\n"
                   + "Banka No: " + bk.BankaID.ToString()
                   + "\nBanka Adı : " + bk.BankaAd, "Banka Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(bk);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Banka Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    if (DetayOlay != null)
                    {
                        this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                    }
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Banka Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Kaydet()
        {
            if ((_YeniKayit && !Isler.Yetki.Varmi_Yetki(52) || !_YeniKayit && !Isler.Yetki.Varmi_Yetki(53))) return;

            try
            {
                #region < Kontroller >
                if (string.IsNullOrEmpty(txtBankaAd.Text.Trim()))
                {
                    XtraMessageBox.Show("Cari Ünvanı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabBanka.SelectedTabPageIndex = 0;
                    txtBankaAd.Focus(); txtBankaAd.Select();
                    return;
                }
                if (lookUpHesapTuru.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Banka Grubunu Seçiniz.", "Değer Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabBanka.SelectedTabPageIndex = 0;
                    lookUpHesapTuru.Focus(); lookUpHesapTuru.Select();
                    return;
                }
                if (_YeniKayit && Isler.Banka.Varmi_BankaAd(txtBankaAd.Text))
                {
                    XtraMessageBox.Show("Bu Banka Adı Daha Önce Girilmiş.\nLütfen Farklı Bir Banka Adı Yazınız.", "Aynı Değer",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBankaAd.Focus(); txtBankaAd.Select();
                    return;
                }
                else if (!_YeniKayit && txtBankaAd.Text != bk.BankaAd && Isler.Banka.Varmi_BankaAd(txtBankaAd.Text, bk.BankaAd))
                {
                    XtraMessageBox.Show("Bu Banka Adı Daha Önce Girilmiş.\nLütfen Farklı Bir Banka Adı Yazınız.", "Aynı Değer",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBankaAd.Focus(); txtBankaAd.Select();
                    return;
                }
                #endregion

                if (_YeniKayit)
                {
                    if (bk != null && bk.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(bk);
                    }
                    bk = null;
                    bk = new banka();
                    bk.SirketID = Genel.AktifSirket.SirketID;
                }

                #region Aktarma
                bk.HesapTuru = lookUpHesapTuru.EditValue.ToString();
                bk.BankaAd = txtBankaAd.Text;
                bk.Durum = chkDurum.Checked;
                bk.Aciklama = memoAciklama.Text;

                bk.SubeAd = txtSubeAd.Text;
                bk.SubeKod = txtSubeKod.Text;
                bk.HesapAd = txtHesapAd.Text;
                bk.HesapNo = txtHesapKod.Text;
                bk.Iban = txtIbanNo.Text;
                bk.KartNo = txtKartNo.Text;
                bk.KartSahibi = txtKartSahibi.Text;
                bk.MusteriNo = txtMusteriNo.Text;

                bk.IlgiliKisiAd = txtIlgiliKisiAdi.Text;
                bk.IlgiliKisiSoyad = txtIlgiliKisiSoyad.Text;
                bk.IlgiliKisiGorev = txtIlgiliKisiGorev.Text;
                bk.IlgiliKisiCep = txtIlgiliKisiCepTel.Text;
                bk.IlgiliKisiEposta = txtIlgiliKisiEposta.Text;
                bk.IlgiliKisiDahili = txtIlgiliKisiDahili.Text;

                bk.Tel1 = txtTel1.Text;
                bk.Tel2 = txtTel2.Text;
                bk.Fax = txtFax.Text;
                bk.Web = txtWeb.Text;
                bk.Eposta = txtEposta.Text;
                if (lookUpAdresIl.EditValue.ToString() == "-1")
                {
                    bk.AdresIl = null;
                }
                else
                {
                    bk.AdresIl = Convert.ToInt32(lookUpAdresIl.EditValue);
                }
                if (lookUpAdresIlce.EditValue.ToString() == "-1")
                {
                    bk.AdresIlce = null;
                }
                else
                {
                    bk.AdresIlce = Convert.ToInt32(lookUpAdresIlce.EditValue);
                }
                bk.AdresAcik = memoAcikAdres.Text;
                #endregion

                #region Kayıt
                if (_YeniKayit)
                {
                    bk.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    bk.KayitZaman = DateTime.Now;
                    dbModel.AddTobankas(bk);
                }
                else
                {
                    bk.DuzenKullaniciID = Genel.AktifKullanici.DuzenKullaniciID;
                    bk.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();
                _Secili_BankaID = bk.BankaID;

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Banka Başarılı Bir Şekilde Kaydedilmiştir.", null,
                   ResOtoSis.mark_blue);

                _YeniKayit = false;

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
                XtraMessageBox.Show("Banka Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Yeni()
        {
            _YeniKayit = true;

            Temizle_Banka();
            tabBanka.SelectedTabPageIndex = 0;
            txtBankaAd.Focus(); txtBankaAd.Select();

            if (DetayOlay != null && this.Handle.ToInt32() > 0)
            {
                this.Invoke(DetayOlay, Enumlar.DetayOlaylari.YeniKayit, null);
            }
        }

        void Temizle_Banka()
        {
            txtBankaID.Text = txtEposta.Text = txtFax.Text = txtTel1.Text = txtTel2.Text = txtHesapAd.Text = txtHesapKod.Text
            = txtIlgiliKisiSoyad.Text = txtBankaAd.Text = txtWeb.Text = txtIlgiliKisiAdi.Text = txtSubeAd.Text = txtSubeKod.Text
            = txtIlgiliKisiCepTel.Text = txtIlgiliKisiDahili.Text = txtIlgiliKisiEposta.Text = txtIlgiliKisiGorev.Text
            = memoAcikAdres.Text = memoAciklama.Text = txtIbanNo.Text = txtKartNo.Text = txtKartSahibi.Text = txtMusteriNo.Text = "";

            lookUpAdresIl.EditValue = lookUpAdresIlce.EditValue = -1;
            lookUpHesapTuru.EditValue = "-1";

            chkDurum.Checked = true;
        }

        void YukleTablar()
        {
            //if (tabBanka.SelectedTabPage == pageBankaHareketler)
            //{
            //    ucBankaHareket1.Ara_BankaHareket(Secili_BankaID);
            //}
        }
        #endregion
    }
}