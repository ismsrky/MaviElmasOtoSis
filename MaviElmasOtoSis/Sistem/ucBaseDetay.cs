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
    public partial class ucBaseDetay : Sistem.ucBase
    {
        public delegate void DetayOlayHandler(Enumlar.DetayOlaylari Olay, DetayArgumanlari Arg = null);

        protected bool _YeniKayit = true;

        public bool YeniKayit
        {
            get
            {
                return _YeniKayit;
            }
        }

        protected Enumlar.DetayModelari _DetayMode = Enumlar.DetayModelari.Tum;

        public ucBaseDetay()
        {
            InitializeComponent();
        }

        private void ucBaseDetay_Load(object sender, EventArgs e)
        {

        }
    }

    public class DetayArgumanlari
    {
        public int ID { get; set; }

        public int Adet { get; set; }
    }
}