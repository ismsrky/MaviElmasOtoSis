using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class ucCariHesap : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_Cariler;
        #endregion

        #region < Load >
        public ucCariHesap()
        {
            InitializeComponent();
        }

        private void ucCariHesap_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;

                ucDetay1.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(DetayOlay);

                Ara(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Cari Hesaplar Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void GridViewCariler_Click(object sender, EventArgs e)
        {
             GridViewCariler.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewCariler.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Cari();
            }
            _Focusta = false;
        }
        private void GridViewCariler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewCariler.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Cari();
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
                pageCariHareketler.PageEnabled = _Focusta = GridViewCariler.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
        }
        #endregion

        #region < Metod >
        void Ara(bool Yeniden)
        {
            try
            {
                _Yukleme = true;

                if (Yeniden || Genel.dt_Cariler == null||dt_Cariler==null)
                {
                    if (dt_Cariler != null)
                        dt_Cariler.Dispose();
                    dt_Cariler = null;

                    if (Genel.dt_Cariler != null)
                        Genel.dt_Cariler.Dispose();
                  Genel.dt_Cariler = Isler.Cari.Ver_Cariler();

                  dt_Cariler = Genel.dt_Cariler.Copy();
                }
                
                gridControlCariler.DataSource = dt_Cariler;
                GridViewCariler.ViewCaption = "Cari Hesaplar Listesi (" + dt_Cariler.Rows.Count.ToString() + " )";

                if (dt_Cariler.Rows.Count > 0)
                {
                    ucDetay1.btnSil.Enabled = true;
                }
                else
                {
                    ucDetay1.btnSil.Enabled = false;
                }

                ucDetay1.Yeni();
                _Focusta = GridViewCariler.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Cari Hesaplar Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Focus_Cari()
        {
            if (_Yukleme || GridViewCariler.GetFocusedDataRow() == null) return;

            ucDetay1.Yukle_Cari(Convert.ToInt32(GridViewCariler.GetFocusedRowCellValue("CariID")));

            pageCariHareketler.PageEnabled = true;
        }

        void Yukle_Tablar()
        {
            if (tabCari.SelectedTabPage == pageCariHareketler)
            {
                ucCariHareketler1.Ara_CariHareket(ucDetay1.Secili_CariID);
            }
        }
        #endregion

        private void tabCari_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            Yukle_Tablar();
        }
    }
}