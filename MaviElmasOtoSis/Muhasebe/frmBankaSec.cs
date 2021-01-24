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
    public partial class frmBankaSec : Sistem.frmBase
    {
        #region < Değişkenler >
        int _Secilen_BankaID;
        #endregion

        #region < Özellikler >
        public int Secili_BankaID
        {
            get
            {
                return _Secilen_BankaID;
            }
        }
        #endregion

        #region < Load >
        public frmBankaSec()
        {
            InitializeComponent();

            this.Text = "Banka Seçin";
        }

        private void frmBankaSec_Load(object sender, EventArgs e)
        {
            try
            {
                Ara(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Banka Seçme Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
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

        private void GridViewBankalar_DoubleClick(object sender, EventArgs e)
        {
            Sec();
        }
        #endregion

        #region < Metod >
        void Sec()
        {
            if (GridViewBankalar.RowCount == 0 || GridViewBankalar.GetFocusedDataRow() == null)
            {
                _Secilen_BankaID = 0;
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                _Secilen_BankaID = Convert.ToInt32(GridViewBankalar.GetFocusedDataRow()["BankaID"]);
                this.DialogResult = DialogResult.OK;
            }
        }

        void Ara(bool Yeniden)
        {
            if (Yeniden || Genel.dt_BankalarSecim == null)
            {
                if (Genel.dt_BankalarSecim != null)
                    Genel.dt_BankalarSecim.Dispose();

                Genel.dt_BankalarSecim = null;
                Genel.dt_BankalarSecim = Isler.Banka.Ver_Bankalar(true);
            }
            gridControlBankalar.DataSource = Genel.dt_BankalarSecim;
            GridViewBankalar.ViewCaption = "Bankalar Listesi (" + Genel.dt_BankalarSecim.Rows.Count.ToString() + ")";
        }
        #endregion
    }
}