using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Personel
{
    public partial class ucPersonelDemo : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;

        personel _per;

        int _Secili_PersonelID;
        #endregion

        #region < Özellikler >
        public personel per
        {
            get
            {
                return _per;
            }
        }

        public int Secili_PersonelID
        {
            get
            {
                return _Secili_PersonelID;
            }
        }
        #endregion

        #region < Load >
        public ucPersonelDemo()
        {
            InitializeComponent();

            try
            {
                if (this.IsInDesignMode) return;
                _Yukleme = true;
                dbModel = new otosisdbEntities(MaviElmasOtoSis.VeriYonetimi.Baglanti.BaglantiEntity);

                Isler.Genelkodlar.Ver_Kod("MedeniHal", ref lookUpMedeniHal, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("Cinsiyet", ref lookUpCinsiyet, "Lütfen Seçiniz");

                lookUpCalistigiBirim.Properties.DisplayMember = "BirimAd";
                lookUpCalistigiBirim.Properties.ValueMember = "BirimID";
                lookUpCalistigiBirim.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Isler.Birim.Ver_Birimler(), "BirimAd", "BirimID");
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Personel Bilgileri Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void btnPersonelSec_Click(object sender, EventArgs e)
        {
            using (frmPersonelSec perSec=new frmPersonelSec())
            {
                if (perSec.ShowDialog() == DialogResult.OK)
                {
                    Yukle_Personel(perSec.PersonelID);
                }
            }
        }
        private void btnPersonelYeni_Click(object sender, EventArgs e)
        {
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(800, 450);
                pop.Text = "Personel Detay";
                using (ucPersonelDetay perDetay=new ucPersonelDetay())
                {
                    perDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    perDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    pop.UserKontrol = perDetay;
                    perDetay.Yeni();
                    if (pop.ShowDialog() == DialogResult.OK)
                    {

                        Yukle_Personel(perDetay.Secili_PersonelID);
                    }
                }
            }
        }
        private void btnPersonelDuzenle_Click(object sender, EventArgs e)
        {
            if (_per == null) return;
            using (Sistem.frmPopup pop = new Sistem.frmPopup())
            {
                pop.Boyut = new System.Drawing.Size(800, 450);
                pop.Text = "Personel Detay";
                using (ucPersonelDetay perDetay = new ucPersonelDetay())
                {
                    perDetay.DetayMode = Enumlar.DetayModelari.SadeceKaydet;
                    perDetay.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(pop.DetayOlayi);
                    pop.UserKontrol = perDetay;
                    perDetay.Yukle_Personel(_per.PersonelID);
                    if (pop.ShowDialog() == DialogResult.OK)
                    {

                        Yukle_Personel(perDetay.Secili_PersonelID);
                    }
                }
            }
        }

        private void txtPersonelID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtPersonelID.Text))
                {
                    Yukle_Personel(Convert.ToInt32(txtPersonelID.Text));
                }
            }
        }
        #endregion

        #region < Metod >
        public void Yukle_Personel(int _PersonelID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_Personel();

                if (_per != null && _per.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_per);
                }
                _per = null;
                _per = Isler.Personel.Ver_Personel(ref dbModel, _PersonelID);
                if (_per == null) return;

                _Secili_PersonelID = _per.PersonelID;

                txtAdSoyad.Text = _per.Ad + " " + _per.Soyad + "  - " + Isler.Genelkodlar.Ver_Aciklama("Unvan", _per.Unvan);
                txtPersonelID.Text = _per.PersonelID.ToString();
                txtTcKimlikNo.Text = _per.TcKimlikNo;

                lookUpCalistigiBirim.EditValue = _per.CalistigiBirim;
                if (!string.IsNullOrEmpty(_per.Cinsiyet))
                {
                    lookUpCinsiyet.EditValue = _per.Cinsiyet;
                }
                if (!string.IsNullOrEmpty(_per.MedeniHal))
                {
                    lookUpMedeniHal.EditValue = _per.MedeniHal;
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Personel Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Temizle_Personel()
        {
            txtAdSoyad.Text = txtPersonelID.Text = txtTcKimlikNo.Text = "";

            lookUpCalistigiBirim.EditValue = -1;
            lookUpCinsiyet.EditValue = lookUpMedeniHal.EditValue = "-1";

            _Secili_PersonelID = 0;
        }
        #endregion
    }
}