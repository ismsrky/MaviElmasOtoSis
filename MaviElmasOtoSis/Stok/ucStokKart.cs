using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Stok
{
    public partial class ucStokKart : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_StokKartlar;
        #endregion

        #region < Load >
        public ucStokKart()
        {
            InitializeComponent();
          
        }

        private void ucStokKart_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;

                Ara(false);

                ucStokKartDetay1.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(DetayOlay);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Kartları Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
           
        }
        #endregion

        #region < Olaylar >
        private void btnAra_Click(object sender, EventArgs e)
        {
            Ara(true);
        }

        private void GridViewStokKart_Click(object sender, EventArgs e)
        {
            GridViewStokKart.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewStokKart.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Kart();
            }
            _Focusta = false;
        }
        private void GridViewStokKart_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewStokKart.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Kart();
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
                _Focusta = GridViewStokKart.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
        }
        #endregion

        #region < Metod >
        void Ara(bool Yeniden)
        {
            try
            {
                _Yukleme = true;

                if (Yeniden || Genel.dt_StokKartlar == null)
                {
                    if (Genel.dt_StokKartlar != null)
                        Genel.dt_StokKartlar.Dispose();
                    Genel.dt_StokKartlar = null;
                    Genel.dt_StokKartlar = Isler.Stok.Ver_StokKartlari();
                }
                if (dt_StokKartlar != null)
                    dt_StokKartlar.Dispose();
                dt_StokKartlar = null;
                dt_StokKartlar = Genel.dt_StokKartlar.Copy();

                gridControlStokKart.DataSource = dt_StokKartlar;
                GridViewStokKart.ViewCaption = "Stok Kartları (" + dt_StokKartlar.Rows.Count + ")";

                if (dt_StokKartlar.Rows.Count > 0)
                {
                    ucStokKartDetay1.btnSil.Enabled = true;
                }
                else
                {
                    ucStokKartDetay1.btnSil.Enabled = false;
                }

                ucStokKartDetay1.Yeni();
                _Focusta = GridViewStokKart.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Kartları Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Focus_Kart()
        {
            if (_Yukleme || GridViewStokKart.GetFocusedDataRow() == null) return;

            ucStokKartDetay1.Yukle_Kart(Convert.ToInt32(GridViewStokKart.GetFocusedRowCellValue("KartID")));
        }
        #endregion
    }
}