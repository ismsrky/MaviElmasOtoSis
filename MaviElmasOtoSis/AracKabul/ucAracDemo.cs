using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.AracKabul
{
    public partial class ucAracDemo : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;

        arac _arc;

        int _Secili_AracID;

        public DetayOlayHandler DetayOlay;
        #endregion

        #region < Özellikler >
        public arac arc
        {
            get
            {
                return _arc;
            }
        }

        public int Secili_AracID
        {
            get
            {
                return _Secili_AracID;
            }
        }
        #endregion

        #region < Load >
        public ucAracDemo()
        {
            InitializeComponent();

            try
            {
                if (this.IsInDesignMode) return;
                _Yukleme = true;
                dbModel = new otosisdbEntities(VeriYonetimi.Baglanti.BaglantiEntity);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Araç Bilgileri Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void btnAracSec_Click(object sender, EventArgs e)
        {
            using (AracKabul.frmAracSec AracSec = new AracKabul.frmAracSec())
            {
                if (AracSec.ShowDialog() == DialogResult.OK)
                {
                    Yukle_Arac(AracSec.AracID);
                }
            }
        }
        private void btnAracEkle_Click(object sender, EventArgs e)
        {
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(795, 310);
                pop.Text = "Araç Bilgileri Detay";
                using (ucAracDetay ar = new ucAracDetay())
                {
                    ar.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    ar.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    pop.UserKontrol = ar;
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_Arac(ar.Secili_AracID);
                    }
                }
            }
        }
        private void btnAracDuzenle_Click(object sender, EventArgs e)
        {
            if (arc == null) return;
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(795, 310);
                pop.Text = "Araç Bilgileri Detay";
                using (ucAracDetay ar = new ucAracDetay())
                {
                    ar.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    ar.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    ar.Yukle_Arac(arc.AracID);
                    pop.UserKontrol = ar;
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_Arac(ar.Secili_AracID);
                    }
                }
            }
        }

        private void txtAracID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtAracID.Text.Trim()))
                {
                    Yukle_Arac(Convert.ToInt32(txtAracID.Text));
                }
            }
        }

        private void txtAracPlaka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtAracPlaka.Text.Trim()))
                {
                    Yukle_Arac(txtAracPlaka.Text);
                }
            }
        }
        #endregion

        #region < Metod >
        public void Yukle_Arac(int _AracID)
        {
            if (_Yukleme) return;

            Temizle_Arac();

            if (_arc != null && _arc.EntityState != EntityState.Detached)
            {
                dbModel.Detach(_arc);
            }
            _arc = null;
            _arc = Isler.Arac.Ver_Arac(ref dbModel, _AracID);
            Yukle_Arac();
        }
        public void Yukle_Arac(string _Plaka)
        {
            if (_Yukleme) return;

            Temizle_Arac();

            if (_arc != null && _arc.EntityState != EntityState.Detached)
            {
                dbModel.Detach(_arc);
            }
            _arc = null;
            _arc = Isler.Arac.Ver_Arac(ref dbModel, _Plaka);
            Yukle_Arac();
        }
        void Yukle_Arac()
        {
            if (_Yukleme) return;

            try
            {
                if (_arc == null) return;

                txtAracID.Text = _arc.AracID.ToString();
                txtAracPlaka.Text = _arc.Plaka;
                txtAracRuhsatSahibi.Text = _arc.RuhsatSahibi;
                txtAracSaseNo.Text = _arc.SaseNo;
                lookUpKaroser.EditValue = _arc.Karoser;
                lookUpYakitTipi.EditValue = _arc.YakitTipi;
                lookUpVitesTipi.EditValue = _arc.VitesTipi;
                if (_arc.ModelYil != null)
                {
                    memoAracDetay.Text += _arc.ModelYil.Value.ToString() + " Model ";
                }
                memoAracDetay.Text += Isler.MarkaModel.Ver_MarkaAd(_arc.MarkaID) + " / ";
                memoAracDetay.Text += Isler.MarkaModel.Ver_ModelAd(_arc.ModelID);

                if (_arc.MotorGucu != null)
                {
                    memoAracDetay.Text += Environment.NewLine + "Motor Gücü : " + _arc.MotorGucu.Value.ToString() + " beygir";
                }
                if (_arc.SilindirHacmi != null)
                {
                    memoAracDetay.Text += Environment.NewLine + "Silindir Hacmi : " + _arc.SilindirHacmi.Value.ToString() + " cc";
                }
                if (_arc.UretimTarih != null)
                {
                    memoAracDetay.Text += Environment.NewLine + "Üretim Tarih : " + _arc.UretimTarih.Value.ToString("dd.MM.yyyy");
                }
                if (_arc.TeslimTarih != null)
                {
                    memoAracDetay.Text += Environment.NewLine + "Teslim Tarih : " + _arc.TeslimTarih.Value.ToString("dd.MM.yyyy");
                }
                if (!string.IsNullOrEmpty(_arc.Renk))
                {
                    memoAracDetay.Text += Environment.NewLine + "Renk : " + Isler.Genelkodlar.Ver_Aciklama("Renk", _arc.Renk);
                }
                lookUpCekis.EditValue = _arc.Cekis;

                _Secili_AracID = _arc.AracID;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Araç Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Temizle_Arac()
        {
            txtAracID.Text = txtAracPlaka.Text = txtAracRuhsatSahibi.Text = txtAracSaseNo.Text
             = memoAracDetay.Text = "";

            lookUpCekis.EditValue = lookUpKaroser.EditValue = lookUpVitesTipi.EditValue
            = lookUpYakitTipi.EditValue = "-1";
        }
        #endregion
    }
}