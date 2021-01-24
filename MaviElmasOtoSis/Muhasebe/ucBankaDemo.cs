using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Objects;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class ucBankaDemo : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;

        banka _bk;

        int _Secili_BankaID;
        #endregion

        #region < Özellikler >
        public int Secili_BankaID
        {
            get
            {
                return _Secili_BankaID;
            }
        }

        public banka bk
        {
            get
            {
                return _bk;
            }
        }
        #endregion

        #region < Load >
        public ucBankaDemo()
        {
            InitializeComponent();

            try
            {
                if (this.IsInDesignMode) return;
                _Yukleme = true;
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                Isler.Genelkodlar.Ver_Kod("BankaHesapTuru", ref lookUpHesapTuru, "Lütfen Seçiniz");
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Banka Bilgileri Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void btnBankaSec_Click(object sender, EventArgs e)
        {
            using (Muhasebe.frmBankaSec bankSec = new frmBankaSec())
            {
                if (bankSec.ShowDialog() == DialogResult.OK)
                {
                    Yukle_Banka(bankSec.Secili_BankaID);
                }
            }
        }
        private void btnBankaYeni_Click(object sender, EventArgs e)
        {
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(766, 310);
                pop.Text = "Banka Detay";
                using (Muhasebe.ucBankaDetay bankaDetay = new ucBankaDetay())
                {
                    bankaDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    bankaDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    bankaDetay.Yeni();
                    pop.UserKontrol = bankaDetay;
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_Banka(bankaDetay.Secili_BankaID);
                    }
                }
            }
        }
        private void btnBankaDuzenle_Click(object sender, EventArgs e)
        {
            if (_bk == null) return;
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(766, 310);
                pop.Text = "Banka Detay";
                using (Muhasebe.ucBankaDetay bankaDetay = new ucBankaDetay())
                {
                    bankaDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    bankaDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    bankaDetay.Yukle_Banka(_bk.BankaID);
                    pop.UserKontrol = bankaDetay;
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_Banka(bankaDetay.Secili_BankaID);
                    }
                }
            }
        }
        #endregion

        #region < Metod >
        public void Yukle_Banka(int _BankaID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_Banka();

                if (_bk != null && _bk.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_bk);
                }
                _bk = null;
                _bk = Isler.Banka.Ver_Banka(ref dbModel, _BankaID);
                if (_bk == null) return;

                _Secili_BankaID = _bk.BankaID;
                txtBankaAdi.Text = _bk.BankaAd;
                txtBankaID.Text = _bk.BankaID.ToString();

                if (!string.IsNullOrEmpty(_bk.IlgiliKisiAd))
                {
                    txtBankaIlgiliKisi.Text = _bk.IlgiliKisiAd;
                }
                if (!string.IsNullOrEmpty(_bk.IlgiliKisiSoyad))
                {
                    txtBankaIlgiliKisi.Text += " " + _bk.IlgiliKisiSoyad;
                }
                lookUpHesapTuru.EditValue = _bk.HesapTuru;

                if (!string.IsNullOrEmpty(_bk.SubeAd))
                {
                    memoBankaDetay.Text ="Şube Adı / Kodu : "+ _bk.SubeAd;
                }
                if (!string.IsNullOrEmpty(_bk.SubeKod))
                {
                    memoBankaDetay.Text += " / " + _bk.SubeKod;
                }
                SatirKontrol();
                if (!string.IsNullOrEmpty(_bk.HesapAd))
                {
                    memoBankaDetay.Text +="Hesap Adı / No : "+ _bk.HesapAd;
                }
                if (!string.IsNullOrEmpty(_bk.HesapNo))
                {
                    memoBankaDetay.Text += " / " + _bk.HesapNo;
                }
                SatirKontrol();
                if (!string.IsNullOrEmpty(_bk.Iban))
                {
                    memoBankaDetay.Text +="Iban No : "+ _bk.Iban;
                }
                SatirKontrol();
                if (!string.IsNullOrEmpty(_bk.AdresAcik) && _bk.AdresIl != null && _bk.AdresIlce != null)
                {
                    memoBankaDetay.Text += "Banka Adres :";
                    memoBankaDetay.Text += Environment.NewLine;
                    memoBankaDetay.Text += _bk.AdresAcik;
                    memoBankaDetay.Text += Environment.NewLine;
                    memoBankaDetay.Text += Isler.Adres.Ver_IlAd(_bk.AdresIl.Value) + " / "
                        + Isler.Adres.Ver_IlceAd(_bk.AdresIlce.Value);
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Banka Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Temizle_Banka()
        {
            txtBankaAdi.Text = txtBankaID.Text = txtBankaIlgiliKisi.Text = memoBankaDetay.Text = "";

            lookUpHesapTuru.EditValue = "-1";

            _Secili_BankaID = 0;
        }

        void SatirKontrol()
        {
            if (string.IsNullOrEmpty(memoBankaDetay.Text) == false)
            {
                memoBankaDetay.Text += Environment.NewLine;
            }
        }
        #endregion
    }
}