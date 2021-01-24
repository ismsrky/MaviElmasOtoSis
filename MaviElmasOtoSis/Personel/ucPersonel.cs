using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Personel
{
    public partial class ucPersonel : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_Personeller;
        #endregion

        #region < Load >
        public ucPersonel()
        {
            InitializeComponent();
        }

        private void ucPersonel_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;               
                
                Ara_Personeller(false);

                ucPersonelDetay1.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(DetayOlay);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Personel İşlemleri Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void GridViewPersoneller_Click(object sender, EventArgs e)
        {
            GridViewPersoneller.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewPersoneller.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Personel();
            }
            _Focusta = false;
        }
        private void GridViewPersoneller_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewPersoneller.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Personel();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara_Personeller(true);
        }

        void DetayOlay(Enumlar.DetayOlaylari Olay, Sistem.DetayArgumanlari Arg)
        {
            if (Olay == Enumlar.DetayOlaylari.AramaGerekli)
            {
                Ara_Personeller(true);
            }
            else if (Olay == Enumlar.DetayOlaylari.YeniKayit)
            {
                _Focusta = GridViewPersoneller.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
        }
        #endregion

        #region < Metod >
        void Ara_Personeller(bool Yeniden)
        {
            try
            {
                gridControlPersoneller.Cursor = Cursors.WaitCursor;
                _Yukleme = true;

                if (Yeniden || Genel.dt_Personeller == null)
                {
                    if (Genel.dt_Personeller != null)
                        Genel.dt_Personeller.Dispose();
                    Genel.dt_Personeller = null;
                    Genel.dt_Personeller = Isler.Personel.Ver_Personeller();
                }

                if (dt_Personeller != null)
                    dt_Personeller.Dispose();
                dt_Personeller = null;

                dt_Personeller = Genel.dt_Personeller.Copy();

                gridControlPersoneller.DataSource = dt_Personeller;
                GridViewPersoneller.ViewCaption = "Personeller Listesi (" + dt_Personeller.Rows.Count.ToString() + ")";

                if (dt_Personeller.Rows.Count > 0)
                {
                    ucPersonelDetay1.btnSil.Enabled = true;
                }
                else
                {
                    ucPersonelDetay1.btnSil.Enabled = false;
                   
                }
                ucPersonelDetay1.Yeni();
                _Focusta = GridViewPersoneller.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Personel Listesi Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
                gridControlPersoneller.Cursor = Cursors.Default;
            }
        }     

        void Focus_Personel()
        {
            if (_Yukleme || GridViewPersoneller.GetFocusedDataRow() == null) return;

            ucPersonelDetay1.Yukle_Personel(Convert.ToInt32(GridViewPersoneller.GetFocusedRowCellValue("PersonelID")));
        }
        #endregion
    }
}