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
    public partial class ucBanka : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_Bankalar;
        #endregion

        #region < Load >
        public ucBanka()
        {
            InitializeComponent();
        }

        private void ucBanka_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;

                ucBankaDetay1.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(DetayOlay);

                Ara();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bankalar Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void GridViewBankalar_Click(object sender, EventArgs e)
        {
            GridViewBankalar.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewBankalar.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Banka();
            }
            _Focusta = false;
        }
        private void GridViewBankalar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewBankalar.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Banka();
        }

        private void tabBanka_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            Yukle_Tablar();
        }

        void DetayOlay(Enumlar.DetayOlaylari Olay, Sistem.DetayArgumanlari Arg)
        {
            if (Olay == Enumlar.DetayOlaylari.AramaGerekli)
            {
                Ara();
            }
            else if (Olay == Enumlar.DetayOlaylari.YeniKayit)
            {
                _Focusta = GridViewBankalar.OptionsSelection.EnableAppearanceFocusedRow = false;
                pageBankaHareketleri.PageEnabled = false;
            }
            else if (Olay == Enumlar.DetayOlaylari.Yukleme)
            {
                pageBankaHareketleri.PageEnabled = true;
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

                if (dt_Bankalar != null)
                    dt_Bankalar.Dispose();
                dt_Bankalar = null;

                dt_Bankalar = Isler.Banka.Ver_Bankalar();
                gridControlBankalar.DataSource = dt_Bankalar;
                GridViewBankalar.ViewCaption = "Bankalar Listesi (" + dt_Bankalar.Rows.Count.ToString() + " )";

                if (dt_Bankalar.Rows.Count > 0)
                {
                    ucBankaDetay1.btnSil.Enabled = true;
                }
                else
                {
                    ucBankaDetay1.btnSil.Enabled = false;
                }
                ucBankaDetay1.Yeni();
                _Focusta = GridViewBankalar.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Bankalar Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Focus_Banka()
        {
            if (_Yukleme || GridViewBankalar.GetFocusedDataRow() == null) return;

            ucBankaDetay1.Yukle_Banka(Convert.ToInt32(GridViewBankalar.GetFocusedRowCellValue("BankaID")));
        }

        void Yukle_Tablar()
        {
            if (tabBanka.SelectedTabPage == pageBankaHareketleri)
            {
                ucBankaHareket1.Ara_BankaHareket(ucBankaDetay1.Secili_BankaID);
            }
        }
        #endregion
    }
}