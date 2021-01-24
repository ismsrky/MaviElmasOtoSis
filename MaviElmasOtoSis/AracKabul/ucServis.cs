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
    public partial class ucServis : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_Servisler;
        #endregion

        #region < Load >
        public ucServis()
        {
            InitializeComponent();
        }

        private void ucIsemri_Load(object sender, EventArgs e)
        {
            dateKayitBas.EditValue = Araclar.TarihSaat.Ver_AyinBasi(DateTime.Now);
            dateKayitBit.EditValue = DateTime.Now;

            ucServisDetay1.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(DetayOlay);

            cmbServisDurum.SelectedIndex = 1;
            Ara_Servisler();

            ucServisDetay1.Yeni_Servis();
        }
        #endregion

        #region < Olaylar >
        void DetayOlay(Enumlar.DetayOlaylari Olay, Sistem.DetayArgumanlari Arg)
        {
            if (Olay == Enumlar.DetayOlaylari.AramaGerekli)
            {
                Ara_Servisler();
            }
            else if (Olay == Enumlar.DetayOlaylari.YeniKayit)
            {
           _Focusta=     GridViewServisler.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
        }

        private void GridViewServisler_Click(object sender, EventArgs e)
        {
            if (GridViewServisler.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Servis();
            }
            _Focusta = false;
        }
        private void GridViewServisler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _Focusta = true;
            Focus_Servis();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara_Servisler();
        }

        private void GridViewServisler_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (GridViewServisler.GetRowCellDisplayText(e.RowHandle, colTeslimTarih) == "Yok")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }

        private void cmbServisDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ara_Servisler();
        }
        #endregion

        #region < Metod >
        void Ara_Servisler()
        {
            try
            {
                _Yukleme = true;
                if (dt_Servisler != null)
                    dt_Servisler.Dispose();

                bool? AcikServis = null;
                if (cmbServisDurum.SelectedIndex == 1)
                    AcikServis = true;
                else if (cmbServisDurum.SelectedIndex == 2)
                    AcikServis = false;

                dt_Servisler = null;
                dt_Servisler = Isler.Servis.Ver_Servisler(Araclar.TarihSaat.Ver_BaslangicTarih(Convert.ToDateTime(dateKayitBas.EditValue))
                    , Araclar.TarihSaat.Ver_BitisTarih(Convert.ToDateTime(dateKayitBit.EditValue)), AcikServis);

                gridControlServisler.DataSource = dt_Servisler;
                GridViewServisler.ViewCaption = "Servis Listesi (" + dt_Servisler.Rows.Count.ToString() + ")";

                if (dt_Servisler.Rows.Count > 0)
                {
                    ucServisDetay1.btnSil.Enabled = true;
                }
                else
                {
                    ucServisDetay1.btnSil.Enabled = false;
                }

                ucServisDetay1.Yeni_Servis();
           _Focusta=     GridViewServisler.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
            catch (Exception hata)
            {

                throw;
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Focus_Servis()
        {
            if (Yukleme || GridViewServisler.GetFocusedDataRow() == null) return;

            GridViewServisler.OptionsSelection.EnableAppearanceFocusedRow = true;
            ucServisDetay1.Yukle_Servis(Convert.ToInt32(GridViewServisler.GetFocusedRowCellValue("ServisID")));
        }
        #endregion        
    }
}