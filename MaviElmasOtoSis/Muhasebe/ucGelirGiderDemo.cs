using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class ucGelirGiderDemo : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;

        gelirgider _gg;

        bool _Gelir;

        int _Secili_GelirGiderID;
        #endregion

        #region < Özellikler >
        public gelirgider gg
        {
            get
            {
                return _gg;
            }
        }

        public int Secili_GelirGiderID
        {
            get
            {
                return _Secili_GelirGiderID;
            }
        }

        public bool Gelir
        {
            get
            {
                return _Gelir;
            }
            set
            {
                _Gelir = value;

                if (_Gelir)
                {
                    grupGelirGiderBilgileri.Text = "Gelir Bilgileri";
                    lblGelirAdi.Text = "Gelir Adı :";
                    lblGelirGrubu.Text = "Gelir Grubu :";
                    lblGelirNo.Text = "Gelir No :";
                }
                else
                {
                    grupGelirGiderBilgileri.Text = "Gider Bilgileri";
                    lblGelirAdi.Text = "Gider Adı :";
                    lblGelirGrubu.Text = "Gider Grubu :";
                    lblGelirNo.Text = "Gider No :";
                }
            }
        }
        #endregion

        #region < Load >
        public ucGelirGiderDemo()
        {
            InitializeComponent();

            try
            {
                if (this.IsInDesignMode) return;
                _Yukleme = true;

                #region databind
                Isler.Genelkodlar.Ver_Kod("GelirGiderGrup", ref lookUpGelirGiderGrup, "Lütfen Seçiniz");
                #endregion

                dbModel = new otosisdbEntities(VeriYonetimi.Baglanti.BaglantiEntity);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Gelir/Gider Bilgileri Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion
        
        #region < Olaylar >
        private void btnGelirGiderSec_Click(object sender, EventArgs e)
        {
            using (frmGelirGiderSec gelirgiderSec = new frmGelirGiderSec())
            {
                gelirgiderSec.Gelir = Gelir;
                if (gelirgiderSec.ShowDialog() == DialogResult.OK)
                {
                    Yukle_GelirGider(gelirgiderSec.Secilen_GelirGiderID);
                }
            }
        }
        private void btnGelirGiderYeni_Click(object sender, EventArgs e)
        {
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(766, 310);
                pop.Text = "Kasa Detay";
                using (ucGelirGiderDetay gelirgiderDetay = new ucGelirGiderDetay())
                {
                    gelirgiderDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    gelirgiderDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    gelirgiderDetay.Yeni();
                    gelirgiderDetay.radioGelirGiderID.Properties.ReadOnly = true;
                    if (Gelir)
                    {
                        gelirgiderDetay.radioGelirGiderID.SelectedIndex = 0;
                    }
                    else
                    {
                        gelirgiderDetay.radioGelirGiderID.SelectedIndex = 1;
                    }
                    pop.UserKontrol = gelirgiderDetay;
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_GelirGider(gelirgiderDetay.Secili_GelirGiderID);
                    }
                }
            }
        }
        private void btnGelirGiderDuzenle_Click(object sender, EventArgs e)
        {
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(766, 310);
                pop.Text = "Kasa Detay";
                using (ucGelirGiderDetay gelirgiderDetay = new ucGelirGiderDetay())
                {
                    gelirgiderDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    gelirgiderDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    gelirgiderDetay.Yukle_GelirGider(_Secili_GelirGiderID);
                    pop.UserKontrol = gelirgiderDetay;
                    gelirgiderDetay.radioGelirGiderID.Properties.ReadOnly = true;
                    if (Gelir)
                    {
                        gelirgiderDetay.radioGelirGiderID.SelectedIndex = 0;
                    }
                    else
                    {
                        gelirgiderDetay.radioGelirGiderID.SelectedIndex = 1;
                    }
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_GelirGider(gelirgiderDetay.Secili_GelirGiderID);
                    }
                }
            }
        }
        #endregion

        #region < Metod >
        public void Yukle_GelirGider(int _GelirGiderID)
        {
            if (_Yukleme) return;

            try
            {
                if (_gg != null && _gg.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_gg);
                }
                _gg = null;
                _gg = Isler.GelirGider.Ver_GelirGider(ref dbModel, _GelirGiderID);
                if (_gg == null) return;

                _Secili_GelirGiderID = _gg.GelirGiderID;
                txtAd.Text = _gg.GelirGiderAd;
                txtGelirGiderID.Text = _gg.GelirGiderID.ToString();
                lookUpGelirGiderGrup.EditValue = _gg.GelirGiderGrup;

                Gelir = _gg.Gelir;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Gelir/Gider Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Temizle_GelirGider()
        {
            txtGelirGiderID.Text = txtAd.Text ="";
            lookUpGelirGiderGrup.EditValue = "-1";

            _Secili_GelirGiderID = 0;
        }
        #endregion
    }
}
