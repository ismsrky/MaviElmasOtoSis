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
    public partial class frmPopup : Sistem.frmBase
    {
        #region < Özellikler >
        XtraUserControl _UserKontrol;
        public XtraUserControl UserKontrol
        {
            get
            {
                return _UserKontrol;
            }
            set
            {
                _UserKontrol = value;
                if (!this.Controls.Contains(_UserKontrol))
                {
                    this.Controls.Add(_UserKontrol);
                }
                _UserKontrol.Dock = DockStyle.Fill;
            }
        }

        Size _Boyut;
        public Size Boyut
        {
            get
            {
                return _Boyut;
            }
            set
            {
                _Boyut = value;
                this.Size = value;
            }
        }
        #endregion

        public void DetayOlayi(Enumlar.DetayOlaylari Olay,DetayArgumanlari Arg)
        {
            if (Olay == Enumlar.DetayOlaylari.Kaydedildi)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        public frmPopup()
        {
            InitializeComponent();
        }

        private void frmPopup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}