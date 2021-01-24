using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.AracKabul
{
    public partial class frmIsemriSec : Sistem.frmBase
    {
        #region < Değişkenler >
        int _IsemirID;

        DataTable dt_Isemirleri;
        #endregion

        #region < Özellikler >
        public int IsemirID
        {
            get
            {
                return _IsemirID;
            }
        }
        #endregion

        #region < Load >
        public frmIsemriSec()
        {
            InitializeComponent();

            this.Text = "İşemri Seçme Ekranı";
            Isler.Genelkodlar.Ver_Kod("IsemriKapatma", ref lookUpIsemriKapatma, "Hepsi");
        }

        private void frmIsemriSec_Load(object sender, EventArgs e)
        {
            try
            {
               
                Ara();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("İşemri Seçme Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
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

        private void GridViewIsemirleri_DoubleClick(object sender, EventArgs e)
        {
            Sec();
        }
        #endregion

        #region < Metod >
        void Sec()
        {
            if (GridViewIsemirleri.RowCount == 0 || GridViewIsemirleri.GetFocusedDataRow() == null)
            {
                _IsemirID = 0;
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                _IsemirID = Convert.ToInt32(GridViewIsemirleri.GetFocusedDataRow()["IsemirID"]);
                this.DialogResult = DialogResult.OK;
            }
        }

        void Ara()
        {
            try
            {
                if (dt_Isemirleri != null)
                    dt_Isemirleri.Dispose();
                dt_Isemirleri = null;

                //bool? faturali = null;
                //if (cmbFaturaDurum.SelectedIndex == 1)
                //    faturali = false;
                //else if (cmbFaturaDurum.SelectedIndex == 2)
                //    faturali = true;

                string dr = null;

                if (lookUpIsemriKapatma.EditValue.ToString() != "-1")
                {
                    dr = lookUpIsemriKapatma.EditValue.ToString();
                }

                dt_Isemirleri = Isler.Servis.Ver_IsemirleriSecme(dr);
                gridControlIsemirleri.DataSource = dt_Isemirleri;
                GridViewIsemirleri.ViewCaption = "İşemirleri Listesi (" + dt_Isemirleri.Rows.Count.ToString() + ")";
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        #endregion

        private void cmbFaturaDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ara();
        }
    }
}