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
    public partial class frmAracSec : Sistem.frmBase
    {
        #region < Değişkenler >
        int _AracID;
        string _Plaka;
        string _RuhsatSahibi;
        string _SaseNo;
        string _Marka;
        string _Model;
        #endregion

        #region < Özellikler >
        public int AracID
        {
            get
            {
                return _AracID;
            }
        }
        public string Plaka
        {
            get
            {
                return _Plaka;
            }
        }
        public string RuhsatSahibi
        {
            get
            {
                return _RuhsatSahibi;
            }
        }
        public string SaseNo
        {
            get
            {
                return _SaseNo;
            }
        }
        public string Marka
        {
            get
            {
                return _Marka;
            }
        }
        public string Model
        {
            get
            {
                return _Model;
            }
        }
        #endregion

        #region < Load >
        public frmAracSec()
        {
            InitializeComponent();

            this.Text = "Araç Seçme Ekranı";
        }

        private void ucAracSec_Load(object sender, EventArgs e)
        {
            try
            {
                Ara(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Araç Seçme Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
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

        private void GridViewAraclar_DoubleClick(object sender, EventArgs e)
        {
            Sec();
        }
        #endregion

        #region < Metod >
        void Sec()
        {
            if (GridViewAraclar.RowCount == 0 || GridViewAraclar.GetFocusedDataRow() == null)
            {
                _AracID = 0;
                _RuhsatSahibi = null;
                _SaseNo = null;
                _Marka = null;
                _Model = null;
                _Plaka = null;
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                _AracID = Convert.ToInt32(GridViewAraclar.GetFocusedDataRow()["AracID"]);
                _Plaka = GridViewAraclar.GetFocusedDataRow()["Plaka"].ToString();
                _RuhsatSahibi = GridViewAraclar.GetFocusedDataRow()["RuhsatSahibi"].ToString();
                _SaseNo = GridViewAraclar.GetFocusedDataRow()["SaseNo"].ToString();
                _Marka = GridViewAraclar.GetFocusedDataRow()["MarkaAdi"].ToString();
                _Model = GridViewAraclar.GetFocusedDataRow()["ModelAdi"].ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        void Ara(bool Yeniden)
        {
            if (Yeniden || Genel.dt_Araclar == null)
            {
                Genel.dt_Araclar = null;
                Genel.dt_Araclar = Isler.Arac.Ver_Araclar();
            }
            gridControlAraclar.DataSource = Genel.dt_Araclar;
            GridViewAraclar.ViewCaption = "Araçlar Listesi (" + Genel.dt_Araclar.Rows.Count.ToString() + ")";
        }
        #endregion
    }
}