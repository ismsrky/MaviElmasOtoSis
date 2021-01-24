using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;
using System.Data.Objects;

namespace MaviElmasOtoSis.Tanim
{
    public partial class ucSirketDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        
        #endregion

        #region < Özellikler >
        
        #endregion

        #region < Load >
        public ucSirketDetay()
        {
            InitializeComponent();
        }

        private void ucSirketDetay_Load(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnSil_Click(object sender, EventArgs e)
        {

        }

        private void chkDurum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDurum.Checked)
                chkDurum.Text = "Aktif";
            else
                chkDurum.Text = "Pasif";
        }

        #region < Olaylar >
        
        #endregion

        #region < Metod >
        
        #endregion
    }
}
