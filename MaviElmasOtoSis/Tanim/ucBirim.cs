using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Tanim
{
    public partial class ucBirim : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_Birimler;
        #endregion

        #region < Load >
        public ucBirim()
        {
            InitializeComponent();
        }

        private void ucBirim_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;

                Ara();

                ucBirimDetay1.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(DetayOlay);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Birim Tanımları Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void GridViewBirimler_Click(object sender, EventArgs e)
        {
            GridViewBirimler.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewBirimler.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Birim();
            }
            _Focusta = false;
        }
        private void GridViewBirimler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewBirimler.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Birim();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara();
        }

        void DetayOlay(Enumlar.DetayOlaylari Olay, Sistem.DetayArgumanlari Arg)
        {
            if (Olay == Enumlar.DetayOlaylari.AramaGerekli)
            {
                Ara();
            }
            else if (Olay == Enumlar.DetayOlaylari.YeniKayit)
            {
                GridViewBirimler.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
        }
        #endregion

        #region < Metod >
        void Ara()
        {
            try
            {
                _Yukleme = true;

                if (dt_Birimler != null)
                    dt_Birimler.Dispose();
                dt_Birimler = null;

                dt_Birimler = Isler.Birim.Ver_Birimler();

                gridControlBirimler.DataSource = dt_Birimler;
                GridViewBirimler.ViewCaption = "İşçilikler (" + dt_Birimler.Rows.Count.ToString() + ")";

                if (dt_Birimler.Rows.Count > 0)
                {
                    ucBirimDetay1.btnSil.Enabled = true;
                }
                else
                {
                    ucBirimDetay1.btnSil.Enabled = false;
                }

                GridViewBirimler.OptionsSelection.EnableAppearanceFocusedRow = false;
                ucBirimDetay1.Yeni();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Birimler Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Focus_Birim()
        {
            if (Yukleme || GridViewBirimler.GetFocusedDataRow() == null) return;

            ucBirimDetay1.Yukle_Birim(Convert.ToInt32(GridViewBirimler.GetFocusedRowCellValue("BirimID")));
        }
        #endregion
    }
}