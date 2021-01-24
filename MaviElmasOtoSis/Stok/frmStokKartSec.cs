using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Stok
{
    public partial class frmStokKartSec : Sistem.frmBase
    {
        #region < Değişkenler >
        int _Secilen_KartID = 0;
        string _Secilen_KalemAdi = null;
        string _Secilen_ParcaNo = null;
        string _Secilen_BarkodNo = null;
        string _Secilen_StokGrup = null;
        string _Secilen_StokBirim = null;
        #endregion

        #region < Özellikler >
        public int Secilen_KartID
        {
            get
            {
                return _Secilen_KartID;
            }
        }
        public string Secilen_KalemAdi
        {
            get
            {
                return _Secilen_KalemAdi;
            }
        }
        public string Secilen_ParcaNo
        {
            get
            {
                return _Secilen_ParcaNo;
            }
        }
        public string Secilen_BarkodNo
        {
            get
            {
                return _Secilen_BarkodNo;
            }
        }
        public string Secilen_StokGrup
        {
            get
            {
                return _Secilen_StokGrup;
            }
        }
        public string Secilen_StokBirim
        {
            get
            {
                return _Secilen_StokBirim;
            }
        }
        #endregion

        #region < Load >
        public frmStokKartSec()
        {
            InitializeComponent();

            this.Text = "Stok Kartı Seç";
        }

        private void frmStokKartSec_Load(object sender, EventArgs e)
        {
            try
            {
                Ara(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Kartı Seçme Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region < Olaylar >
        private void btnSec_Click(object sender, EventArgs e)
        {
            Sec();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void GridViewStokKart_DoubleClick(object sender, EventArgs e)
        {
            Sec();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara(true);
        }
        #endregion

        #region < Metod >
        void Sec()
        {
            if (GridViewStokKart.RowCount == 0 || GridViewStokKart.GetFocusedDataRow() == null)
            {
                _Secilen_KalemAdi = null;
                _Secilen_KartID = 0;
                _Secilen_ParcaNo = null;
                _Secilen_BarkodNo = null;
                _Secilen_StokGrup = null;
                _Secilen_StokBirim = null;
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                _Secilen_KalemAdi = GridViewStokKart.GetFocusedDataRow()["KalemAdi"].ToString();
                _Secilen_KartID = Convert.ToInt32(GridViewStokKart.GetFocusedDataRow()["KartID"]);
                _Secilen_ParcaNo = GridViewStokKart.GetFocusedDataRow()["ParcaNo"].ToString();
                _Secilen_BarkodNo = GridViewStokKart.GetFocusedDataRow()["BarkodNo"].ToString();
                _Secilen_StokGrup = GridViewStokKart.GetFocusedDataRow()["StokGrup"].ToString(); ;
                _Secilen_StokBirim = GridViewStokKart.GetFocusedDataRow()["StokBirim"].ToString(); ;
                this.DialogResult = DialogResult.OK;
            }
        }

        void Ara(bool Yeniden)
        {
            if (Yeniden || Genel.dt_StokKartlarSecim == null)
            {
                if (Genel.dt_StokKartlarSecim != null)
                    Genel.dt_StokKartlarSecim.Dispose();
                Genel.dt_StokKartlarSecim = null;
                Genel.dt_StokKartlarSecim = Isler.Stok.Ver_StokKartlari(true);
            }
            gridControlStokKart.DataSource = Genel.dt_StokKartlarSecim;
            GridViewStokKart.ViewCaption = "Stok Kartları (" + Genel.dt_StokKartlarSecim.Rows.Count.ToString() + ")";
        }
        #endregion
    }
}