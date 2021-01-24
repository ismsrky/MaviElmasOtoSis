using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace MaviElmasOtoSis.Bilesenler
{
    public class btnYazdir : SimpleButton
    {
        #region < Değişkenler >
        ContextYazdir contextYaz;

        public DevExpress.XtraGrid.Views.Grid.GridView _KaynakView;
        #endregion

        #region < Özellikler >
        public DevExpress.XtraGrid.Views.Grid.GridView KaynakView
        {
            get
            {
                return _KaynakView;
            }
            set
            {
                _KaynakView = value;
                if (contextYaz != null)
                {
                    contextYaz.KaynakView = value;
                }
            }
        }
        #endregion

        #region < Load >
        public btnYazdir()
        {
            this.Text = "Yazdır";
            this.Size = new Size(62, 23);
            this.Image = ResOtoSis.yazdirp;

            contextYaz = new ContextYazdir();
            this.ContextMenuStrip = contextYaz;

            this.Click += new System.EventHandler(this.btnYazdir_Click);

            this.Cursor = Cursors.Hand;
        }
        #endregion

        #region < Olaylar >
        private void btnYazdir_Click(object sender, EventArgs e)
        {
            contextYaz.KaynakView = _KaynakView;
            this.ContextMenuStrip.Show(this, new Point(0, 25));
        }
        #endregion

        #region < Metod >
        
        #endregion
    }
}