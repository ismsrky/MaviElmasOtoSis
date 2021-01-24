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
    public partial class frmCariHesapSec : Sistem.frmBase
    {
        #region < Değişkenler >
        int _Secilen_CariID;
        string _Secilen_Unvan;
        string _Secilen_CariGrup;
        string _Secilen_TcKimlik;
        string _Secilen_YetkiliKisi;
        #endregion

        #region < Özellikler >
        public int Secilen_CariID
        {
            get
            {
                return _Secilen_CariID;
            }
        }
        public string Secilen_CariGrup
        {
            get
            {
                return _Secilen_CariGrup;
            }
        }
        public string Secilen_Unvan
        {
            get
            {
                return _Secilen_Unvan;
            }
        }
        public string Secilen_TcKimlik
        {
            get
            {
                return _Secilen_TcKimlik;
            }
        }
        public string Secilen_YetkiliKisi
        {
            get
            {
                return _Secilen_YetkiliKisi;
            }
        }
        #endregion

        #region < Load >
        public frmCariHesapSec()
        {
            InitializeComponent();

            this.Text = "Cari Hesap Seçin";
        }

        private void frmCariHesapSec_Load(object sender, EventArgs e)
        {
            try
            {
                Ara(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Cari Hesap Seçme Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
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

        private void GridViewCariler_DoubleClick(object sender, EventArgs e)
        {
            Sec();
        }
        #endregion

        #region < Metod >
        void Sec()
        {
            if (GridViewCariler.RowCount == 0 || GridViewCariler.GetFocusedDataRow() == null)
            {
                _Secilen_CariID = 0;
                _Secilen_CariGrup = "";
                _Secilen_TcKimlik = "";
                _Secilen_Unvan = "";
                _Secilen_YetkiliKisi = "";
                this.DialogResult = DialogResult.Abort;
            }
            else
            {
                _Secilen_CariID = Convert.ToInt32(GridViewCariler.GetFocusedDataRow()["CariID"]);
                _Secilen_CariGrup = GridViewCariler.GetFocusedDataRow()["CariHesapGrup"].ToString();
                _Secilen_TcKimlik = GridViewCariler.GetFocusedDataRow()["TcKimlikNo"].ToString();
                _Secilen_Unvan = GridViewCariler.GetFocusedDataRow()["Unvan"].ToString();
                _Secilen_YetkiliKisi = GridViewCariler.GetFocusedDataRow()["YetkiliKisi"].ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        void Ara(bool Yeniden)
        {
            if (Yeniden || Genel.dt_CarilerSecim == null)
            {
                if (Genel.dt_CarilerSecim != null)
                    Genel.dt_CarilerSecim.Dispose();

                Genel.dt_CarilerSecim = null;
                Genel.dt_CarilerSecim = Isler.Cari.Ver_Cariler(true);
            }
            gridControlCariler.DataSource = Genel.dt_CarilerSecim;
            GridViewCariler.ViewCaption = "Cari Hesaplar Listesi (" + Genel.dt_CarilerSecim.Rows.Count.ToString() + ")";
        }
        #endregion        
    }
}