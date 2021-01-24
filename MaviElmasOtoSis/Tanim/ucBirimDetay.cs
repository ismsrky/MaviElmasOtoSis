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
    public partial class ucBirimDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        birim _br;

        int _Secili_BirimID;

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

        public birim br
        {
            get
            {
                return _br;
            }
        }

        public int Secili_BirimID
        {
            get
            {
                return _Secili_BirimID;
            }
        }
        #endregion

        #region < Load >
        public ucBirimDetay()
        {
            InitializeComponent();
            try
            {
              
                if (this.IsInDesignMode) return;
                _Yukleme = true;
                try
                {
                    dbModel = new otosisdbEntities(VeriYonetimi.Baglanti.BaglantiEntity);

                    Isler.Genelkodlar.Ver_Kod("BirimTip", ref lookUpBirimTip, "Lütfen Seçiniz");
                }
                catch (Exception hata)
                {

                    throw;
                }
            }
            catch (Exception hata)
            {

                throw;
            }
            finally
            {
                _Yukleme = false;
            }
        }

        private void ucBirimDetay_Load(object sender, EventArgs e)
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

        private void chkDurum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDurum.Checked)
                chkDurum.Text = "Aktif";
            else
                chkDurum.Text = "Pasif";
        }

        private void btnPersonelSec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (Personel.frmPersonelSec PersonelSec = new Personel.frmPersonelSec())
            {
                if (PersonelSec.ShowDialog() == DialogResult.OK)
                {
                    btnPersonelSec.Tag = PersonelSec.PersonelID;
                    btnPersonelSec.Text = PersonelSec.Ad + " " + PersonelSec.Soyad;
                }
            }
        }
        #endregion

        #region < Metod >
        public void Yukle_Birim(int _BirimID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_Birim();
                _YeniKayit = false;

                if (_br != null && _br.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_br);
                }
                _br = null;
                _br = Isler.Birim.Ver_Birim(ref dbModel, _BirimID);
                if (_br == null) return;

                _Secili_BirimID = _br.BirimID;

                txtBirimID.Text = _br.BirimID.ToString();
                txtBina.Text = _br.Bina;
                txtBirimAdi.Text = _br.BirimAd;
                txtDahili.Text = _br.DahiliTel;
                txtKat.Text = _br.Kat;
                txtOdaNo.Text = _br.Oda;
                lookUpBirimTip.EditValue = _br.BirimTip;

                btnPersonelSec.Tag = _br.YetkiliPersonel;
                if (_br.YetkiliPersonel != null)
                {
                    btnPersonelSec.Text = Isler.Personel.Ver_AdSoyad(_br.YetkiliPersonel.Value);
                }

                ucKayitBilgi1.Yukle(_br.KayitKullaniciID, _br.KayitZaman, _br.DuzenKullaniciID, _br.DuzenZaman);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("İşçilik Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Sil()
        {
            if (_br == null) return;

            if (!Isler.Yetki.Varmi_Yetki(73)) return;
            try
            {
                //Burada fatura kontrol edilecek
                //Eğer bu işçilik ile fatura kesilmiş ise silme işlemi yapılamayacak.
                if (XtraMessageBox.Show("Seçili Birimi Silmek İstediğinize Emin Misiniz?\n"
                   + "Birim Adı : " + _br.BirimAd
                   + "\nBirim No : " + _br.BirimID.ToString(), "Birim Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(_br);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Birim Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    if (DetayOlay != null)
                    {
                        this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                    }
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Birim Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Kaydet()
        {
            if ((YeniKayit && !Isler.Yetki.Varmi_Yetki(71) || (!YeniKayit && !Isler.Yetki.Varmi_Yetki(72)))) return;

            try
            {
                #region Kontroller
                if (string.IsNullOrEmpty(txtBirimAdi.Text.Trim()))
                {
                    XtraMessageBox.Show("Birim Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBirimAdi.Focus(); txtBirimAdi.Select();
                    return;
                }
                if (lookUpBirimTip.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Birim Tipini Seçiniz.", "Değer Seçilmemiş",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpBirimTip.Focus(); lookUpBirimTip.Select();
                    return;
                }
                if (YeniKayit && Isler.Birim.Varmi_BirimAd(Genel.AktifSirket.SirketID, txtBirimAdi.Text))
                {
                    XtraMessageBox.Show("Bu Birim Adı Daha Önce Kullanılmış\nLütfen Farklı Bir Birim Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBirimAdi.Focus(); txtBirimAdi.Select();
                    return;
                }
                else if (!YeniKayit && txtBirimAdi.Text != _br  .BirimAd && Isler.Birim.Varmi_BirimAd(Genel.AktifSirket.SirketID, txtBirimAdi.Text, _br.BirimAd))
                {
                    XtraMessageBox.Show("Bu Birim Adı Daha Önce Kullanılmış\nLütfen Farklı Bir Birim Adı Yazınız.", "Aynı Değer",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBirimAdi.Focus(); txtBirimAdi.Select();
                    return;
                }
                #endregion

                if (YeniKayit)
                {
                    if (_br != null && _br.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(_br);
                        _br = null;
                    }
                    _br = new birim();
                    _br.SirketID = Genel.AktifSirket.SirketID;
                }

                #region Aktarma
                _br.BirimAd = txtBirimAdi.Text;
                _br.Bina = txtBina.Text;
                _br.Kat = txtKat.Text;
                _br.Oda = txtOdaNo.Text;
                _br.BirimTip = lookUpBirimTip.EditValue.ToString();
                _br.DahiliTel = txtDahili.Text;
                _br.Durum = chkDurum.Checked;
                if (btnPersonelSec.Tag == null)
                {
                    _br.YetkiliPersonel = null;
                }
                else
                {
                    _br.YetkiliPersonel = Convert.ToInt32(btnPersonelSec.Tag);
                }
                #endregion

                #region Kayıt
                if (YeniKayit)
                {
                    _br.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    _br.KayitZaman = DateTime.Now;
                    dbModel.AddTobirims(_br);
                }
                else
                {
                    _br.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    _br.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();
                _Secili_BirimID = _br.BirimID;

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Birim Başarılı Bir Şekilde Kaydedilmiştir.", null,
                  ResOtoSis.mark_blue);

                Yeni();

                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.Kaydedildi, null);
                }
                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                }
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

            Temizle_Birim();
            txtBirimAdi.Focus(); txtBirimAdi.Select();

            if (DetayOlay != null&&!_Yukleme)
            {
                this.Invoke(DetayOlay, Enumlar.DetayOlaylari.YeniKayit, null);
            }
        }

        public void Temizle_Birim()
        {
            txtBirimAdi.Text = txtBina.Text = txtBirimID.Text = txtDahili.Text = txtKat.Text = txtOdaNo.Text = btnPersonelSec.Text = "";

            lookUpBirimTip.EditValue = "-1";

            chkDurum.Checked = true;

            btnPersonelSec.Tag = null;

            ucKayitBilgi1.Temizle();
        }
        #endregion

      
    }
}
