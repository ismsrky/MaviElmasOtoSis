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
    public partial class ucIscilik : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_Iscilikler;
        #endregion

        #region < Load >
        public ucIscilik()
        {
            InitializeComponent();
        }

        private void ucIscilik_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;

                Ara(false);

                ucIscilikDetay1.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(DetayOlay);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("İşçilik Tanımları Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void GridViewIscilikler_Click(object sender, EventArgs e)
        {
            GridViewIscilikler.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewIscilikler.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Iscilik();
            }
            _Focusta = false;
        }
        private void GridViewIscilikler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewIscilikler.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Iscilik();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara(true);
        }

        void DetayOlay(Enumlar.DetayOlaylari Olay, Sistem.DetayArgumanlari Arg)
        {
            if (Olay == Enumlar.DetayOlaylari.AramaGerekli)
            {
                Ara(true);
            }
            else if (Olay == Enumlar.DetayOlaylari.YeniKayit)
            {
                _Focusta = GridViewIscilikler.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
        }
        #endregion

        #region < Metod >
        void Ara(bool Yeniden)
        {
            try
            {
                _Yukleme = true;

                if (Yeniden || Genel.dt_Iscilikler == null || dt_Iscilikler == null)
                {
                    if (Genel.dt_Iscilikler != null)
                        Genel.dt_Iscilikler.Dispose();
                    Genel.dt_Iscilikler = null;
                    Genel.dt_Iscilikler = Isler.Iscilik.Ver_Iscilikler();                  
                }

                if (dt_Iscilikler != null)
                    dt_Iscilikler.Dispose();
                dt_Iscilikler = null;
                dt_Iscilikler = Genel.dt_Iscilikler.Copy();

                gridControlIscilikler.DataSource = dt_Iscilikler;
                GridViewIscilikler.ViewCaption = "İşçilikler (" + dt_Iscilikler.Rows.Count.ToString() + ")";

                if (dt_Iscilikler.Rows.Count > 0)
                {
                    ucIscilikDetay1.btnSil.Enabled = true;
                }
                else
                {
                    ucIscilikDetay1.btnSil.Enabled = false;
                }

                ucIscilikDetay1.Yeni();
                _Focusta = GridViewIscilikler.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("İşçilikler Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Focus_Iscilik()
        {
            if (Yukleme || GridViewIscilikler.GetFocusedDataRow() == null) return;

            ucIscilikDetay1.Yukle_Iscilik(Convert.ToInt32(GridViewIscilikler.GetFocusedRowCellValue("IscilikID")));
        }
        #endregion       
    }
}