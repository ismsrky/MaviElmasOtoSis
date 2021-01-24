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
    public partial class frmIscilikSec : Sistem.frmBase
    {
        #region < Değişkenler >
        int _IscilikID;
        string _IscilikAd;
        string _IscilikTip;
        string _IscilikTipAciklama;
        decimal _KacSaat;
        #endregion

        #region < Özellikler >
        public int IscilikID
        {
            get
            {
                return _IscilikID;
            }
        }
        public string IscilikAd
        {
            get
            {
                return _IscilikAd;
            }
        }
        public string IscilikTip
        {
            get
            {
                return _IscilikTip;
            }
        }
        public string IscilikTipAciklama
        {
            get
            {
                return _IscilikTipAciklama;
            }
        }
        public decimal KacSaat
        {
            get
            {
                return _KacSaat;
            }
        }
        #endregion

        #region < Load >
        public frmIscilikSec()
        {
            InitializeComponent();
        }

        private void ucIscilikSec_Load(object sender, EventArgs e)
        {
            try
            {
                Ara(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("İşçilik Seçme Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region < Olaylar >
        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara(true);
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            Sec();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void GridViewIscilikler_DoubleClick(object sender, EventArgs e)
        {
            Sec();
        }
        #endregion

        #region < Metod >
        void Sec()
        {
            if (GridViewIscilikler.RowCount == 0 || GridViewIscilikler.GetFocusedDataRow() == null)
            {
                _IscilikID = 0;
                _IscilikAd = null;
                _IscilikTip = null;
                _IscilikTipAciklama = null;
                _KacSaat = 0;
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                _IscilikID = Convert.ToInt32(GridViewIscilikler.GetFocusedDataRow()["IscilikID"]);
                _IscilikAd = GridViewIscilikler.GetFocusedDataRow()["IscilikAd"].ToString();
                _IscilikTip = GridViewIscilikler.GetFocusedDataRow()["IscilikTip"].ToString();
                _IscilikTipAciklama = GridViewIscilikler.GetFocusedDataRow()["IscilikTipAciklama"].ToString();
                _KacSaat = Convert.ToDecimal(GridViewIscilikler.GetFocusedDataRow()["KacSaat"]);
                this.DialogResult = DialogResult.OK;
            }
        }

        void Ara(bool Yeniden)
        {
            if (Yeniden || Genel.dt_IsciliklerSecim == null)
            {
                Genel.dt_IsciliklerSecim = null;
                Genel.dt_IsciliklerSecim = Isler.Iscilik.Ver_Iscilikler(true);
            }
            gridControlIscilikler.DataSource = Genel.dt_IsciliklerSecim;
            GridViewIscilikler.ViewCaption = "İşçilikler Listesi (" + Genel.dt_IsciliklerSecim.Rows.Count.ToString() + ")";
        }
        #endregion        
    }
}