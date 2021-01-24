using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Sistem
{
    public partial class frmBase : DevExpress.XtraEditors.XtraForm
    {
        protected bool _Yukleme = false;
        public bool Yukleme
        {
            get
            {
                return _Yukleme;
            }
        }

        protected bool _Focusta = false;
        public bool Focusta
        {
            get
            {
                return _Focusta;
            }
        }

        public frmBase()
        {
            InitializeComponent();
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                Genel.Ekle_Sitil(item);
            }
        }
    }
}