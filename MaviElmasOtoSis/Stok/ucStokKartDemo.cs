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

namespace MaviElmasOtoSis.Stok
{
    public partial class ucStokKartDemo : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;

        stok_kart _sk;

        int _Secili_KartID;
        #endregion

        #region < Özellikler >
        public stok_kart sk
        {
            get
            {
                return _sk;
            }
        }

        public int Secili_KartID
        {
            get
            {
                return _Secili_KartID;
            }
        }
        #endregion

        #region < Load >
        public ucStokKartDemo()
        {
            InitializeComponent();

            try
            {
                if (this.IsInDesignMode) return;
                _Yukleme = true;

                #region databind
                Isler.Genelkodlar.Ver_Kod("StokBirim", ref lookUpStokBirim, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("StokGrup", ref lookUpStokGrup, "Lütfen Seçiniz");
                #endregion

                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Kart Bilgileri Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void btnKartSec_Click(object sender, EventArgs e)
        {
            using (Stok.frmStokKartSec sec = new frmStokKartSec())
            {
                if (sec.ShowDialog() == DialogResult.OK)
                {
                    Yukle_Kart(sec.Secilen_KartID);
                }
            }
        }
        private void btnKartYeni_Click(object sender, EventArgs e)
        {
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(766, 310);
                pop.Text = "Stok Kart Detayı";
                using (ucStokKartDetay skDetay = new ucStokKartDetay())
                {
                    skDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    skDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    skDetay.Yeni();
                    pop.UserKontrol = skDetay;
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_Kart(skDetay.Secili_KartID);
                    }
                }
            }
        }
        private void btnKartDuzenle_Click(object sender, EventArgs e)
        {
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(766, 310);
                pop.Text = "Stok Kart Detayı";
                using (ucStokKartDetay skDetay = new ucStokKartDetay())
                {
                    skDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    skDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    skDetay.Yukle_Kart(_sk.KartID);
                    pop.UserKontrol = skDetay;
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_Kart(skDetay.Secili_KartID);
                    }
                }
            }

        }

        private void txtParcaNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtParcaNo.Text.Trim()))
            {
                Yukle_Kart(txtParcaNo.Text);
            }
        }
        private void txtKartID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Araclar.Dogrulama.IsNumeric(txtKartID.Text))
            {
                Yukle_Kart(Convert.ToInt32(txtKartID.Text));
            }
        }
        #endregion

        #region < Metod >
        public void Yukle_Kart(int _KartID)
        {
            if (_Yukleme) return;

            try
            {
                if (_sk != null && _sk.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_sk);
                }
                _sk = null;
                _sk = Isler.Stok.Ver_StokKart(ref dbModel, _KartID);
                if (_sk == null) return;

                Yukle_Kart();
            }
            catch (Exception hata)
            {
                
                throw;
            }
        }
        public void Yukle_Kart(string _ParcaNo)
        {
            if (_Yukleme) return;

            try
            {
                if (_sk != null && _sk.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_sk);
                }
                _sk = null;
                _sk = Isler.Stok.Ver_StokKart(ref dbModel, _ParcaNo);
                if (_sk == null) return;

                Yukle_Kart();
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Yukle_Kart()
        {
            Temizle_Kart();

            _Secili_KartID = _sk.KartID;
            txtKartID.Text = _sk.KartID.ToString();
            txtBarkodNo.Text = _sk.BarkodNo;
            txtKalemAdi.Text = _sk.KalemAdi;
            txtParcaNo.Text = _sk.ParcaNo;

            lookUpStokGrup.EditValue = _sk.StokGrup;
            lookUpStokBirim.EditValue = _sk.StokBirim;
        }

        public void Temizle_Kart()
        {
            txtBarkodNo.Text = txtKalemAdi.Text = txtKartID.Text = txtParcaNo.Text = "";

            lookUpStokBirim.EditValue = lookUpStokGrup.EditValue = "-1";
        }
        #endregion
      
    }
}