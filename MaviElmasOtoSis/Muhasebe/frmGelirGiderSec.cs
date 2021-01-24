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
    public partial class frmGelirGiderSec : Sistem.frmBase
    {
        #region < Değişkenler >
        int _Secilen_GelirGiderID;

        DataTable dt_GelirGiderSecim;
        #endregion

        #region < Özellikler >
        public int Secilen_GelirGiderID
        {
            get
            {
                return _Secilen_GelirGiderID;
            }
        }

        public bool? Gelir { get; set; }
        #endregion

        #region < Load >
        public frmGelirGiderSec()
        {
            InitializeComponent();

            this.Text = "Gelir / Gider Seçin";
        }

        private void frmGelirGiderSec_Load(object sender, EventArgs e)
        {
            try
            {
                Ara();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Gelir/Gider Seçme Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region < Olaylar >
        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            Sec();
        }

        private void GridViewGelirGider_DoubleClick(object sender, EventArgs e)
        {
            Sec();
        }
        #endregion

        #region < Metod >
        void Sec()
        {
            if (GridViewGelirGider.RowCount == 0 || GridViewGelirGider.GetFocusedDataRow() == null)
            {
                _Secilen_GelirGiderID = 0;
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                _Secilen_GelirGiderID = Convert.ToInt32(GridViewGelirGider.GetFocusedDataRow()["GelirGiderID"]);
                this.DialogResult = DialogResult.OK;
            }
        }

        void Ara()
        {
            if (dt_GelirGiderSecim != null)
                dt_GelirGiderSecim.Dispose();

            dt_GelirGiderSecim = null;
            dt_GelirGiderSecim = Isler.GelirGider.Ver_GelirGiderler(true, Gelir);

            gridControlGelirGider.DataSource = dt_GelirGiderSecim;
            GridViewGelirGider.ViewCaption = "Bankalar Listesi (" + dt_GelirGiderSecim.Rows.Count.ToString() + ")";
        }
        #endregion
    }
}