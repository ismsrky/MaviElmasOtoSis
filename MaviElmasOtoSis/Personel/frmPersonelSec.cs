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
    public partial class frmPersonelSec : Sistem.frmBase
    {
        #region < Değişkenler >
        int _PersonelID;
        string _TcKimlikNo;
        string _Ad;
        string _Soyad;
        string _Unvan;
        string _Cinsiyet;
        #endregion

        #region < Özellikler >
        public int PersonelID
        {
            get
            {
                return _PersonelID;
            }
        }
        public string TcKimlikNo
        {
            get
            {
                return _TcKimlikNo;
            }
        }
        public string Ad
        {
            get
            {
                return _Ad;
            }
        }
        public string Soyad
        {
            get
            {
                return _Soyad;
            }
        }
        public string Unvan
        {
            get
            {
                return _Unvan;
            }
        }
        public string Cinsiyet
        {
            get
            {
                return _Cinsiyet;
            }
        }
        #endregion

        #region < Load >
        public frmPersonelSec()
        {
            InitializeComponent();

            this.Text = "Personel Seçme Ekranı";
        }

        private void ucPersonelSec_Load(object sender, EventArgs e)
        {
            try
            {
                Ara(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Personel Seçme Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
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

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara(true);
        }

        private void GridViewPersoneller_DoubleClick(object sender, EventArgs e)
        {
            Sec();
        }
        #endregion

        #region < Metod >
        void Sec()
        {
            if (GridViewPersoneller.RowCount == 0 || GridViewPersoneller.GetFocusedDataRow() == null)
            {
                _PersonelID = 0;
                _TcKimlikNo = null;
                _Ad = null;
                _Soyad = null;
                _Unvan = null;
                _Cinsiyet = null;
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                _PersonelID = Convert.ToInt32(GridViewPersoneller.GetFocusedDataRow()["PersonelID"]);
                _Ad = GridViewPersoneller.GetFocusedDataRow()["Ad"].ToString();
                _Soyad = GridViewPersoneller.GetFocusedDataRow()["Soyad"].ToString();
                _Unvan = GridViewPersoneller.GetFocusedDataRow()["Unvan"].ToString();
                _Cinsiyet = GridViewPersoneller.GetFocusedDataRow()["Cinsiyet"].ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        void Ara(bool Yeniden)
        {
            if (Yeniden || Genel.dt_PersonellerSecim == null)
            {
                if (Genel.dt_PersonellerSecim != null)
                    Genel.dt_PersonellerSecim.Dispose();

                Genel.dt_PersonellerSecim = null;
                Genel.dt_PersonellerSecim = Isler.Personel.Ver_Personeller(false);
            }
            gridControlPersoneller.DataSource = Genel.dt_PersonellerSecim;
            GridViewPersoneller.ViewCaption = "Personel Listesi (" + Genel.dt_PersonellerSecim.Rows.Count.ToString() + ")";
        }
        #endregion       
    }
}