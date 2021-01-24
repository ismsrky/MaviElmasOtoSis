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
    public partial class ucKasaDemo : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;

        kasa _ks;

        int _Secili_KasaID;
        #endregion

        #region < Özellikler >
        public kasa ks
        {
            get
            {
                return _ks;
            }
        }

        public int Secili_KasaID
        {
            get
            {
                return _Secili_KasaID;
            }
        }
        #endregion

        #region < Load >
        public ucKasaDemo()
        {
            InitializeComponent();

            try
            {
                if (this.IsInDesignMode) return;
                _Yukleme = true;
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kasa Bilgileri Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void btnStokKartSec_Click(object sender, EventArgs e)
        {
            using (Muhasebe.frmKasaSec kasaSec = new frmKasaSec()) 
            {
                if (kasaSec.ShowDialog() == DialogResult.OK)
                {
                    Yukle_Kasa(kasaSec.Secili_KasaID);
                }
            }
        }
        private void btnStokKartEkle_Click(object sender, EventArgs e)
        {
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(766, 310);
                pop.Text = "Kasa Detay";
                using (Muhasebe.ucKasaDetay kasaDetay = new ucKasaDetay())
                {
                    kasaDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    kasaDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    kasaDetay.Yeni();
                    pop.UserKontrol = kasaDetay;
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_Kasa(kasaDetay.Secili_KasaID);
                    }
                }
            }
        }
        private void btnStokKartDuzenle_Click(object sender, EventArgs e)
        {
            if (_ks == null) return;

            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(766, 310);
                pop.Text = "Kasa Detay";
                using (Muhasebe.ucKasaDetay kasaDetay = new ucKasaDetay())
                {
                    kasaDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    kasaDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    kasaDetay.Yukle_Kasa(_ks.KasaID);
                    pop.UserKontrol = kasaDetay;
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_Kasa(kasaDetay.Secili_KasaID);
                    }
                }
            }
        }
        #endregion

        #region < Metod >
        public void Yukle_Kasa(int _KasaID)
        {
            if (_Yukleme) return;

            try
            {
                if (_ks != null && _ks.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_ks);
                }
                _ks = null;
                _ks = Isler.Kasa.Ver_Kasa(ref dbModel, _KasaID);
                if (_ks == null) return;

                txtKasaAdi.Text = _ks.KasaAd;
                txtKasaID.Text = _ks.KasaID.ToString();

                _Secili_KasaID = _ks.KasaID;
            }
            catch (Exception hata)
            {
               XtraMessageBox.Show("Kasa Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Temizle_Kasa()
        {
            txtKasaAdi.Text = txtKasaID.Text = "";

            _Secili_KasaID = 0;
        }
        #endregion
    }
}