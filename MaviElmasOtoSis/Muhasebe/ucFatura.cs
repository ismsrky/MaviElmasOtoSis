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
    public partial class ucFatura : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_Faturalar;
        Enumlar.FaturaTipleri _FaturaTipi = Enumlar.FaturaTipleri.SatisFaturasi;
        #endregion

        #region < Özellikler >
        public Enumlar.FaturaTipleri FaturaTipi
        {
            get
            {
                return _FaturaTipi;
            }
            set
            {
                ucFaturaDetay1.FaturaTipi = _FaturaTipi = value;
                if (_FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi)
                {
                }
                else if (_FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi)
                {
                }
            }
        }
        #endregion

        #region < Load >
        public ucFatura()
        {
            InitializeComponent();

            if (this.IsInDesignMode) return;

            dateKayitBas.EditValue = Araclar.TarihSaat.Ver_AyinBasi(DateTime.Now);
            dateKayitBit.EditValue = DateTime.Now;

            #region databind
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Alan", typeof(string));
            DataRow dr = dt.NewRow();
            dr["ID"] = 0;
            dr["Alan"] = "Kapalı";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["ID"] = 1;
            dr["Alan"] = "Açık";
            dt.Rows.Add(dr);
            reLookUpFaturaTip.DataSource = dt;
            reLookUpFaturaTip.ValueMember = "ID";
            reLookUpFaturaTip.DisplayMember = "Alan";

            dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Alan", typeof(string));
            dr = dt.NewRow();
            dr["ID"] = 1;
            dr["Alan"] = "Bağımsız";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["ID"] = 2;
            dr["Alan"] = "İşemrinden";
            dt.Rows.Add(dr);
            reLookUpFaturaKaynak.DataSource = dt;
            reLookUpFaturaKaynak.ValueMember = "ID";
            reLookUpFaturaKaynak.DisplayMember = "Alan";

            reLookUpBirim.DisplayMember = "BirimAd";
            reLookUpBirim.ValueMember = "BirimID";
            reLookUpBirim.DataSource = Isler.Birim.Ver_Birimler();
            #endregion

            ucFaturaDetay1.DetayOlay += new Sistem.ucBaseDetay.DetayOlayHandler(DetayOlay);
        }
        private void ucFatura_Load(object sender, EventArgs e)
        {
            if (this.IsInDesignMode) return;
            
            if (FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi)
            {
                colAracID.Visible = colFaturaKaynak.Visible = colIsemirID.Visible = false;
            }

            Ara_Faturalar();

            ucFaturaDetay1.Yeni();
            GridViewFaturalar.OptionsSelection.EnableAppearanceFocusedRow = false;
        }
        #endregion

        #region < Olaylar >
        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara_Faturalar();

            //for (int i = 0; i < dt_Faturalar.Rows.Count; i++)
            //{
            //    if (dt_Faturalar.Rows[i]["IsemirID"] != DBNull.Value)
            //    {
            //        Isler.Servis.Guncelle_IsemriFatura(
            //       Convert.ToInt32(dt_Faturalar.Rows[i]["IsemirID"]),
            //       Convert.ToInt32(dt_Faturalar.Rows[i]["FaturaID"]),
            //       Enumlar.IsemriKapatmalari.Faturalandirildi,
            //       Convert.ToDateTime(dt_Faturalar.Rows[i]["FaturaTarih"]));
            //    }
            //}
        }

        private void GridViewFaturalar_Click(object sender, EventArgs e)
        {
            GridViewFaturalar.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewFaturalar.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Fatura();
            }
            _Focusta = false;
        }
        private void GridViewFaturalar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
             GridViewFaturalar.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Fatura();
        }

        void DetayOlay(Enumlar.DetayOlaylari Olay, Sistem.DetayArgumanlari Arg)
        {
            if (Olay == Enumlar.DetayOlaylari.AramaGerekli)
            {
                Ara_Faturalar();
            }
            else if (Olay == Enumlar.DetayOlaylari.YeniKayit)
            {
                _Focusta = GridViewFaturalar.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
        }
        #endregion

        #region < Metod >
        public void Ara_Faturalar()
        {
            try
            {
                _Yukleme = true;

                if (dt_Faturalar != null)
                    dt_Faturalar.Dispose();
                dt_Faturalar = null;

                dt_Faturalar = Isler.Fatura.Ver_Faturalar(FaturaTipi, Araclar.TarihSaat.Ver_BaslangicTarih(Convert.ToDateTime(dateKayitBas.EditValue))
                    , Araclar.TarihSaat.Ver_BitisTarih(Convert.ToDateTime(dateKayitBit.EditValue)));
                gridControlFaturalar.DataSource = dt_Faturalar;

                GridViewFaturalar.ViewCaption = "Faturalar Listesi (" + dt_Faturalar.Rows.Count.ToString() + ")";

                if (dt_Faturalar.Rows.Count > 0)
                {
                    ucFaturaDetay1.btnSil.Enabled = true;
                }
                else
                {
                    ucFaturaDetay1.btnSil.Enabled = false;
                }

                //ucFaturaDetay1.Yeni();
                _Focusta = GridViewFaturalar.OptionsSelection.EnableAppearanceFocusedRow = false;
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

        void Focus_Fatura()
        {
            if (Yukleme || GridViewFaturalar.GetFocusedDataRow() == null) return;

            ucFaturaDetay1.Yukle_Fatura(Convert.ToInt32(GridViewFaturalar.GetFocusedRowCellValue("FaturaID")));
        }
        #endregion       
    }
}