using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Tanim
{
    public partial class ucIscilikDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        iscilik isc;

        int _Secili_Iscilik;

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

        public int Secili_Iscilik
        {
            get
            {
                return _Secili_Iscilik;
            }
        }
        #endregion

        #region < Load >
        public ucIscilikDetay()
        {
            InitializeComponent();

            if (this.IsInDesignMode) return;
            try
            {
                _Yukleme = true;
                dbModel = new otosisdbEntities(VeriYonetimi.Baglanti.BaglantiEntity);

                #region databind
                Isler.Genelkodlar.Ver_Kod("IscilikTip", ref lookUpIscilikTip, "Lütfen Seçiniz");
                #endregion
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("İşçilik Tanımları Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
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

        private void chkDurum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDurum.Checked)
                chkDurum.Text = "Aktif";
            else
                chkDurum.Text = "Pasif";
        }
        #endregion

        #region < Metod >
        public void Yukle_Iscilik(int _IscilikID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_Iscilik();
                _YeniKayit = false;

                if (isc != null && isc.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(isc);
                }
                isc = null;
                isc = Isler.Iscilik.Ver_Iscilik(ref dbModel, _IscilikID);
                if (isc == null) return;

                txtIscilikID.Text = isc.IscilikID.ToString();
                txtIscilikAdi.Text = isc.IscilikAd;
                spinKacSaat.Value = isc.KacSaat;
                lookUpIscilikTip.EditValue = isc.IscilikTip;
                chkDurum.Checked = isc.Durum;

                ucKayitBilgi1.Yukle(isc.KayitKullaniciID, isc.KayitZaman, isc.DuzenKullaniciID, isc.DuzenZaman);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("İşçilik Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Sil()
        {
            if (isc == null) return;

            if (!Genel.Yetkilerim.Contains(28))
            {
                Genel.Yetki_Uyari(28);
                return;
            }
            try
            {
                //Burada fatura kontrol edilecek
                //Eğer bu işçilik ile fatura kesilmiş ise silme işlemi yapılamayacak.
                if (XtraMessageBox.Show("Seçili İşçiliği Silmek İstediğinize Emin Misiniz?\n"
                   + "İşçilik Adı : " + isc.IscilikAd
                   + "\nİşçilik No : " + isc.IscilikID.ToString(), "İşçilik Kartı Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(isc);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "İşçilik Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    if (DetayOlay != null)
                    {
                        this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                    }
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("İşçilik Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Kaydet()
        {
            if (YeniKayit && !Genel.Yetkilerim.Contains(26))
            {
                Genel.Yetki_Uyari(26);
                return;
            }
            else if (!YeniKayit && !Genel.Yetkilerim.Contains(27))
            {
                Genel.Yetki_Uyari(27);
                return;
            }

            try
            {
                #region Kontroller
                if (string.IsNullOrEmpty(txtIscilikAdi.Text.Trim()))
                {
                    XtraMessageBox.Show("İşçilik Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIscilikAdi.Focus(); txtIscilikAdi.Select();
                    return;
                }
                if (lookUpIscilikTip.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen İşçilik Tipini Seçiniz.", "Değer Seçilmemiş",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpIscilikTip.Focus(); lookUpIscilikTip.Select();
                    return;
                }
                if (YeniKayit && Isler.Iscilik.Varmi_Iscilik(Genel.AktifSirket.SirketID, txtIscilikAdi.Text))
                {
                    XtraMessageBox.Show("Bu İşçilik Adı Daha Önce Kullanılmış\nLütfen Farklı Bir İşçilik Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIscilikAdi.Focus(); txtIscilikAdi.Select();
                    return;
                }
                else if (!YeniKayit && txtIscilikAdi.Text != isc.IscilikAd && Isler.Iscilik.Varmi_Iscilik(Genel.AktifSirket.SirketID, txtIscilikAdi.Text, isc.IscilikAd))
                {
                    XtraMessageBox.Show("Bu İşçilik Adı Daha Önce Kullanılmış\nLütfen Farklı Bir İşçilik Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIscilikAdi.Focus(); txtIscilikAdi.Select();
                    return;
                }
                if (spinKacSaat.Value == 0)
                {
                    XtraMessageBox.Show("Saat Değeri 0'dan Büyük Olmalıdır.", "Geçersiz Saat Değeri",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    spinKacSaat.Focus(); spinKacSaat.Select();
                    return;
                }
                #endregion

                if (YeniKayit)
                {
                    if (isc != null && isc.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(isc);
                        isc = null;
                    }
                    isc = new iscilik();
                    isc.SirketID = Genel.AktifSirket.SirketID;
                }

                #region Aktarma
                isc.IscilikAd = txtIscilikAdi.Text;
                isc.KacSaat = spinKacSaat.Value;
                isc.IscilikTip = lookUpIscilikTip.EditValue.ToString();
                isc.Durum = chkDurum.Checked;
                #endregion

                #region Kayıt
                if (YeniKayit)
                {
                    isc.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    isc.KayitZaman = DateTime.Now;
                    dbModel.AddToisciliks(isc);
                }
                else
                {
                    isc.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    isc.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "İşçilik Başarılı Bir Şekilde Kaydedilmiştir.", null,
                  ResOtoSis.mark_blue);

                _Secili_Iscilik = isc.IscilikID;

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
                XtraMessageBox.Show("İşçilik Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Yeni()
        {
            _YeniKayit = true;

            Temizle_Iscilik();
            txtIscilikAdi.Focus(); txtIscilikAdi.Select();

            if (DetayOlay != null&&!_Yukleme)
            {
                this.Invoke(DetayOlay, Enumlar.DetayOlaylari.YeniKayit, null);
            }
        }

        public void Temizle_Iscilik()
        {
            txtIscilikAdi.Text = txtIscilikID.Text = "";

            spinKacSaat.Value = 0;

            lookUpIscilikTip.EditValue = "-1";

            chkDurum.Checked = true;

            ucKayitBilgi1.Temizle();
        }
        #endregion        
    }
}