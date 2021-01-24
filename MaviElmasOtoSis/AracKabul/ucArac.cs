using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.AracKabul
{
    public partial class ucArac : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_Araclar;
        #endregion,

        #region < Load >
        public ucArac()
        {
            InitializeComponent();
        }

        private void ucArac_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;

                ucAracDetay1.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(DetayOlay);

                Ara(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Araçlar Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion
        
        #region < Olaylar >
        private void GridViewAraclar_Click(object sender, EventArgs e)
        {
            GridViewAraclar.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewAraclar.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Arac();
            }
            _Focusta = false;
        }
        private void GridViewAraclar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewAraclar.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Arac();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara(true);
        }

        void DetayOlay(Enumlar.DetayOlaylari Olay,Sistem. DetayArgumanlari Arg)
        {
            if (Olay == Enumlar.DetayOlaylari.AramaGerekli)
            {
                Ara(true);
            }
            else if (Olay == Enumlar.DetayOlaylari.YeniKayit)
            {
                _Focusta = GridViewAraclar.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
        }
        #endregion

        #region < Metod >
        void Ara(bool Yeniden)
        {
            try
            {
                _Yukleme = true;

                if (Yeniden || Genel.dt_Araclar == null)
                {
                    if (Genel.dt_Araclar != null)
                        Genel.dt_Araclar.Dispose();

                    Genel.dt_Araclar = null;
                    Genel.dt_Araclar = Isler.Arac.Ver_Araclar();
                }

                if (dt_Araclar != null)
                    dt_Araclar.Dispose();
                dt_Araclar = null;
                dt_Araclar = Genel.dt_Araclar.Copy();

                gridControlAraclar.DataSource = dt_Araclar;
                GridViewAraclar.ViewCaption = "Araçlar (" + dt_Araclar.Rows.Count.ToString() + ")";

                if (dt_Araclar.Rows.Count > 0)
                {
                    ucAracDetay1.btnSil.Enabled = true;
                }
                else
                {
                    ucAracDetay1.btnSil.Enabled = false;
                }

                ucAracDetay1.Yeni();
                _Focusta = GridViewAraclar.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Araçlar Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Focus_Arac()
        {
            if (_Yukleme || GridViewAraclar.GetFocusedDataRow() == null) return;

            ucAracDetay1.Yukle_Arac(Convert.ToInt32(GridViewAraclar.GetFocusedRowCellValue("AracID")));
        }
        #endregion
    }
}