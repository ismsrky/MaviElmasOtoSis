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
    public partial class ucIsemriDemo : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;

        isemri _ism;

        int _Secili_IsemirID;
        int _Secili_CariID;

        public DetayOlayHandler DetayOlay;
        #endregion

        #region < Özellikler >
        public isemri ism
        {
            get
            {
                return _ism;
            }
        }

        public int Secili_IsemirID
        {
            get
            {
                return _Secili_IsemirID;
            }
        }
        public int Secili_CariID
        {
            get
            {
                return _Secili_CariID;
            }
        }

        #endregion

        #region < Load >
        public ucIsemriDemo()
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
                XtraMessageBox.Show("İşemri Bilgileri Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void btnIsemriSec_Click(object sender, EventArgs e)
        {
            using (frmIsemriSec ismSec = new frmIsemriSec())
            {
                //ismSec.loo
                ismSec.lookUpIsemriKapatma.Properties.ReadOnly = true;
                ismSec.lookUpIsemriKapatma.EditValue = ((int)Enumlar.IsemriKapatmalari.Acik).ToString();
                if (ismSec.ShowDialog() == DialogResult.OK)
                {
                    Yukle_Isemri(ismSec.IsemirID);
                }
            }
        }
        #endregion

        #region < Metod >
        public void Yukle_Isemri(int _IsemirID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_Isemri();
                if (_ism != null && _ism.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_ism);
                }
                _ism = null;
                _ism = Isler.Servis.Ver_Isemri(ref dbModel, _IsemirID);
                if (_ism == null) return;

                _Secili_IsemirID = _ism.IsemirID;

                txtBirim.Text = Isler.Birim.Ver_BirimAd(_ism.BirimID);
                txtIsemriID.Text = _ism.IsemirID.ToString();
                txtServisID.Text = _ism.ServisID.ToString();

                var tempServis = (from abc in dbModel.servis
                                where abc.ServisID==_ism.ServisID
                                select new
                                {
                                   abc.CariID
                                }).SingleOrDefault();

                _Secili_CariID = tempServis.CariID;


                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli,null);
                }
            }
            catch (Exception hata)
            {
                
                throw;
            }
        }

        public void Temizle_Isemri()
        {
            txtBirim.Text = txtIsemriID.Text = txtServisID.Text = "";
        }
        #endregion
    }
}