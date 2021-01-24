using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Stok
{
    public partial class ucStokHareket : Sistem.ucBase
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        stok_hareket hareket;

        bool Yukleme = false;

        DataTable dt_StokHareketleri;
        #endregion

        #region < Load >
        public ucStokHareket()
        {
            InitializeComponent();
        }

        private void ucStokHareket_Load(object sender, EventArgs e)
        {
            try
            {
                Yukleme = true;
                dbModel = new otosisdbEntities(VeriYonetimi.Baglanti.BaglantiEntity);

                #region databind
                dateKayitBas.EditValue = Araclar.TarihSaat.Ver_AyinBasi(DateTime.Now);
                dateKayitBit.EditValue = DateTime.Now;

                lookUpDepolar.Enabled = true;
                lookUpDepolar.Properties.DisplayMember = "DepoAd";
                lookUpDepolar.Properties.ValueMember = "DepoID";
                lookUpDepolar.Properties.DataSource = Isler.Stok.Ver_Depolar(false);
                if (Sistem.Ayarlar.VarsayilanDepoID == -1)
                {
                    lookUpDepolar.EditValue = Convert.ToInt32(Isler.Stok.Ver_Depolar(false).Rows[0]["DepoID"]);
                }
                else
                {
                    lookUpDepolar.EditValue = Sistem.Ayarlar.VarsayilanDepoID;
                }
                #endregion


                lookUpDepolar.EditValue = Genel.AktifDepo.DepoID;
                //Ara();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Hareketleri Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara();
        }

        private void GridViewStokHareketleri_Click(object sender, EventArgs e)
        {
            if (GridViewStokHareketleri.RowCount == 1)
                Focus_Hareket();
        }
        private void GridViewStokHareketleri_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Focus_Hareket();
        }
        #endregion

        #region < Metod >
        void Ara()
        {
            try
            {
                Yukleme = true;

                if (dateKayitBas.EditValue == null || dateKayitBit.EditValue == null)
                {
                    XtraMessageBox.Show("Arama Yapabilmek İçin Lütfen Tarih Kriterlerini Giriniz.", "Geçersiz İşlem",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dt_StokHareketleri != null)
                    dt_StokHareketleri.Dispose();
                dt_StokHareketleri = null;

                dt_StokHareketleri = Isler.Stok.Ver_StokHareketleri(
                    Araclar.TarihSaat.Ver_BaslangicTarih(Convert.ToDateTime(dateKayitBas.EditValue)),
                 Araclar.TarihSaat.Ver_BitisTarih(Convert.ToDateTime(dateKayitBit.EditValue))
                 , Convert.ToInt32(lookUpDepolar.EditValue));
                gridControlStokHareketleri.DataSource = dt_StokHareketleri;
                GridViewStokHareketleri.ViewCaption = "Stok Hareketleri (" + dt_StokHareketleri.Rows.Count.ToString() + ")";

                GridViewStokHareketleri.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
                GridViewStokHareketleri.OptionsView.ColumnAutoWidth = false;

                gridControlStokHareketleri.ForceInitialize();
                GridViewStokHareketleri.BestFitColumns();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Hareketleri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Yukleme = false;
            }
        }

        void Yukle_Hareket(int _ID)
        {
            if (Yukleme) return;

            try
            {
                if (hareket != null && hareket.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(hareket);
                }
                hareket = null;
                hareket = Isler.Stok.Ver_StokHareket(ref dbModel, _ID);
                if (hareket == null) return;

                ucKayitBilgi1.Yukle(hareket.KayitKullaniciID, hareket.KayitZaman, hareket.DuzenKullaniciID, hareket.DuzenZaman);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Hareket Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Focus_Hareket()
        {
            if (Yukleme || GridViewStokHareketleri.GetFocusedDataRow() == null) return;

            Yukle_Hareket(Convert.ToInt32(GridViewStokHareketleri.GetFocusedRowCellValue("ID")));
        }
        #endregion       
    }
}