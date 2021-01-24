using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class ucGelirGider : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_GelirGiderler;
        #endregion

        #region < Load >
        public ucGelirGider()
        {
            InitializeComponent();
        }

        private void ucGelirGider_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;

                ucGelirGiderDetay1.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(DetayOlay);

                Ara();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Gelir/Gider Kalemleri Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void GridViewGelirGider_Click(object sender, EventArgs e)
        {
            GridViewGelirGider.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewGelirGider.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_GelirGider();
            }
            _Focusta = false;
        }
        private void GridViewGelirGider_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewGelirGider.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_GelirGider();
        }

        void DetayOlay(Enumlar.DetayOlaylari Olay,Sistem. DetayArgumanlari Arg)
        {
            if (Olay == Enumlar.DetayOlaylari.AramaGerekli)
            {
                Ara();
            }
            else if (Olay == Enumlar.DetayOlaylari.YeniKayit)
            {
                _Focusta = GridViewGelirGider.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara();
        }
        #endregion

        #region < Metod >
        void Ara()
        {
            try
            {
                _Yukleme = true;

                if (dt_GelirGiderler != null)
                    dt_GelirGiderler.Dispose();
                dt_GelirGiderler = null;

                dt_GelirGiderler = Isler.GelirGider.Ver_GelirGiderler();
                gridControlGelirGider.DataSource = dt_GelirGiderler;
                GridViewGelirGider.ViewCaption = "Gelir ve Gider Kalemleri Listesi (" + dt_GelirGiderler.Rows.Count.ToString() + " )";

                if (dt_GelirGiderler.Rows.Count > 0)
                {
                    ucGelirGiderDetay1.btnSil.Enabled = true;
                }
                else
                {
                    ucGelirGiderDetay1.btnSil.Enabled = false;
                }

                ucGelirGiderDetay1.Yeni();
                _Focusta = GridViewGelirGider.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Gelir ve Giderler Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Focus_GelirGider()
        {
            if (_Yukleme || GridViewGelirGider.GetFocusedDataRow() == null) return;

            ucGelirGiderDetay1.Yukle_GelirGider(Convert.ToInt32(GridViewGelirGider.GetFocusedRowCellValue("GelirGiderID")));
        }
        #endregion
    }
}