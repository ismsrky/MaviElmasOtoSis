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
    public partial class frmKasaSec : Sistem.frmBase
    {
        #region < Değişkenler >
        int _Secili_KasaID;
        #endregion

        #region < Özellikler >
        public int Secili_KasaID
        {
            get
            {
                return _Secili_KasaID;
            }
        }
        #endregion

        #region < Load >
        public frmKasaSec()
        {
            InitializeComponent();

            this.Text = "Kasa Seçin";
        }

        private void frmKasaSec_Load(object sender, EventArgs e)
        {
            try
            {
                Ara(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kasa Seçme Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region < Olaylar >
        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara(true);
        }
        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
        private void btnSec_Click(object sender, EventArgs e)
        {
            Sec();
        }

        private void GridViewKasalar_DoubleClick(object sender, EventArgs e)
        {
            Sec();
        }
        #endregion

        #region < Metod >
        void Sec()
        {
            if (GridViewKasalar.RowCount == 0 || GridViewKasalar.GetFocusedDataRow() == null)
            {
                _Secili_KasaID = 0;
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                _Secili_KasaID = Convert.ToInt32(GridViewKasalar.GetFocusedDataRow()["KasaID"]);
                this.DialogResult = DialogResult.OK;
            }
        }

        void Ara(bool Yeniden)
        {
            if (Yeniden || Genel.dt_KasalarSecim == null)
            {
                if (Genel.dt_KasalarSecim != null)
                    Genel.dt_KasalarSecim.Dispose();

                Genel.dt_KasalarSecim = null;
                Genel.dt_KasalarSecim = Isler.Kasa.Ver_Kasalar(true);
            }
            gridControlKasalar.DataSource = Genel.dt_KasalarSecim;
            GridViewKasalar.ViewCaption = "Kasalar Listesi (" + Genel.dt_KasalarSecim.Rows.Count.ToString() + ")";
        }
        #endregion
    }
}