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

namespace MaviElmasOtoSis.Tanim
{
    public partial class ucIscilikDemo : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;

        iscilik _isc;

        int _Secili_IscilikID;
        #endregion

        #region < Özellikler >
        public iscilik isc
        {
            get
            {
                return _isc;
            }
        }

        public int Secili_Iscilik
        {
            get
            {
                return _Secili_IscilikID;
            }
        }
        #endregion

        #region < Load >
        public ucIscilikDemo()
        {
            InitializeComponent();

            try
            {
                if (this.IsInDesignMode) return;
                _Yukleme = true;

                #region databind
                Isler.Genelkodlar.Ver_Kod("IscilikTip", ref lookUpIscilikTip, "Lütfen Seçiniz");
                #endregion

                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("İşçilik Bilgileri Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void btnIscilikSec_Click(object sender, EventArgs e)
        {
            using (frmIscilikSec iscSec = new frmIscilikSec())
            {
                if (iscSec.ShowDialog() == DialogResult.OK)
                {
                    Yukle_Iscilik(iscSec.IscilikID);
                }
            }
        }
        private void btnIscilikYeni_Click(object sender, EventArgs e)
        {
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(530, 240);
                pop.Text = "İşçilik Detayı";
                using (ucIscilikDetay iscDetay = new ucIscilikDetay())
                {
                    iscDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    iscDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    iscDetay.Yeni();
                    pop.UserKontrol = iscDetay;
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_Iscilik(iscDetay.Secili_Iscilik);
                    }
                }
            }
        }
        private void btnIscilikDuzenle_Click(object sender, EventArgs e)
        {
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(530, 240);
                pop.Text = "İşçilik Detayı";
                using (ucIscilikDetay iscDetay = new ucIscilikDetay())
                {
                    iscDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    iscDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    iscDetay.Yukle_Iscilik(_Secili_IscilikID);
                    pop.UserKontrol = iscDetay;
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_Iscilik(iscDetay.Secili_Iscilik);
                    }
                }
            }
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

                if (_isc != null && isc.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_isc);
                }
                _isc = null;
                _isc = Isler.Iscilik.Ver_Iscilik(ref dbModel, _IscilikID);
                if (isc == null) return;

                _Secili_IscilikID = isc.IscilikID;
                txtIscilikID.Text = isc.IscilikID.ToString();
                txtIscilikAdi.Text = isc.IscilikAd;
                spinKacSaat.Value = isc.KacSaat;
                lookUpIscilikTip.EditValue = isc.IscilikTip;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("İşçilik Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Temizle_Iscilik()
        {
            txtIscilikAdi.Text = txtIscilikID.Text = "";

            spinKacSaat.Value = 0;

            lookUpIscilikTip.EditValue = "-1";
        }
        #endregion
    }
}