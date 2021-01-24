using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Sistem
{
    public partial class ucBase : DevExpress.XtraEditors.XtraUserControl
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

        public ucBase()
        {
            InitializeComponent();
        }

        private void ucBase_Load(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                Genel.Ekle_Sitil(item);
            }
        }

        protected bool IsInDesignMode
        {
            get
            {
                return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
            }
        }
    }
}