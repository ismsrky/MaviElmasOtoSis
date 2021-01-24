using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class ucCariHesapDemo : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;

        cari_hesap _cari;

        int _Secili_CariID = 0;
        #endregion

        #region < Özellikler >
        public int Secili_CariID
        {
            get
            {
                return _Secili_CariID;
            }
        }

        public cari_hesap cari
        {
            get
            {
                return _cari;
            }
        }
        #endregion

        #region < Load >
        public ucCariHesapDemo()
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
                XtraMessageBox.Show("Cari Hesap Bilgileri Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void btnCariSec_Click(object sender, EventArgs e)
        {
            using (Muhasebe.frmCariHesapSec CariSec = new Muhasebe.frmCariHesapSec())
            {
                if (CariSec.ShowDialog() == DialogResult.OK)
                {
                    Yukle_Cari(CariSec.Secilen_CariID);
                }
            }
        }
        private void btnCariYeni_Click(object sender, EventArgs e)
        {
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(766, 310);
                pop.Text = "Cari Hesap Detay";
                using (Muhasebe.ucCariHesapDetay car = new Muhasebe.ucCariHesapDetay())
                {
                    car.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    car.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    pop.UserKontrol = car;
                    car.Yeni();
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        
                        Yukle_Cari(car.Secili_CariID);
                    }
                }
            }
        }
        private void btnCariDuzenle_Click(object sender, EventArgs e)
        {
            if (_cari == null) return;
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(766, 310);
                pop.Text = "Cari Hesap Detay";
                using (Muhasebe.ucCariHesapDetay car = new Muhasebe.ucCariHesapDetay())
                {
                    car.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    car.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    pop.UserKontrol = car;
                    car.Yukle_Cari(_cari.CariID);                  
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        Yukle_Cari(car.Secili_CariID);
                    }
                }
            }
        }

        private void txtCariID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtCariID.Text.Trim()))
                {
                    Yukle_Cari(Convert.ToInt32(txtCariID.Text));
                }
            }
        }
        #endregion

        #region < Metod >
        public void Yukle_Cari(int _CariID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_Cari();

                if (_cari != null && _cari.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_cari);
                }
                _cari = null;
                _cari = Isler.Cari.Ver_CariHesap(ref dbModel, _CariID);
                if (_cari == null) return;

                _Secili_CariID = _cari.CariID;

                txtCariID.Text = _cari.CariID.ToString();
                txtCariTcKimlik.Text = _cari.TcKimlikNo;
                txtCariUnvan.Text = _cari.Unvan;
                txtCariYetkiliKisi.Text = _cari.YetkiliKisiAd + " " + _cari.YetkiliKisiSoyad;

                if (!string.IsNullOrEmpty(_cari.Tel1))
                {
                    txtCariTel.Text = _cari.Tel1;
                }
                if (!string.IsNullOrEmpty(_cari.Tel2))
                {
                    txtCariTel.Text += " / " + _cari.Tel2;
                }

                txtCariYetkiliCep.Text = _cari.YetkiliKisiCep;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Cari Hesap Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Temizle_Cari()
        {
            txtCariID.Text = txtCariTcKimlik.Text = txtCariTel.Text = txtCariUnvan.Text = txtCariYetkiliCep.Text
            = txtCariYetkiliKisi.Text = "";

            _Secili_CariID = 0;
        }
        #endregion       
    }
}