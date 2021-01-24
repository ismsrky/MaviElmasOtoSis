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
    public partial class ucSayim : Sistem.ucBase
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        stok_sayim sayim;

        bool YeniKayit = true;
        bool Yukleme = false;

        DataTable dt_Sayimlar;
        DataTable dt_Kalemler;
        #endregion

        #region < Load >
        public ucSayim()
        {
            InitializeComponent();
        }

        private void ucSayim_Load(object sender, EventArgs e)
        {
            try
            {
                Yukleme = true;
                dbModel = new otosisdbEntities(VeriYonetimi.Baglanti.BaglantiEntity);

                #region databind
                dateKayitBas.EditValue = Araclar.TarihSaat.Ver_SeneninBasi();
                dateKayitBit.EditValue = DateTime.Now;

                lookUpDepolar.Enabled = true;
                lookUpDepolar.Properties.DisplayMember = "DepoAd";
                lookUpDepolar.Properties.ValueMember = "DepoID";
                lookUpDepolar.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Isler.Stok.Ver_Depolar(false), "DepoAd", "DepoID"); ;
                #endregion

                Ara_Sayimlar();
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
            Ara_Sayimlar();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }
        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            Yeni();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }

        private void btnKalemleriGetir_Click(object sender, EventArgs e)
        {
            if (lookUpDepolar.EditValue.ToString() == "-1")
            {
                XtraMessageBox.Show("Lütfen Stok Sayımı Yapılacak Depoyu Seçiniz.", "Depo Seçilmedi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpDepolar.Focus(); lookUpDepolar.Select();
                return;
            }
            if (dt_Kalemler != null)
                dt_Kalemler.Dispose();
            dt_Kalemler = null;

            int? Raf1 = null;
            int? Sira1 = null;
            int? Goz1 = null;
            int? Raf2 = null;
            int? Sira2 = null;
            int? Goz2 = null;

            if (!string.IsNullOrEmpty(txtRaf1.Text))
            {
                Raf1 = Convert.ToInt32(txtRaf1.Text);
            }
            if (!string.IsNullOrEmpty(txtSira1.Text))
            {
                Sira1 = Convert.ToInt32(txtSira1.Text);
            }
            if (!string.IsNullOrEmpty(txtGoz1.Text))
            {
                Goz1 = Convert.ToInt32(txtGoz1.Text);
            }

            if (!string.IsNullOrEmpty(txtRaf2.Text))
            {
                Raf2 = Convert.ToInt32(txtRaf2.Text);
            }
            if (!string.IsNullOrEmpty(txtSira2.Text))
            {
                Sira2 = Convert.ToInt32(txtSira2.Text);
            }
            if (!string.IsNullOrEmpty(txtGoz2.Text))
            {
                Goz2 = Convert.ToInt32(txtGoz2.Text);
            }

            dt_Kalemler = Isler.Stok.Ver_SayimKalemlerDepodan(Convert.ToInt32(lookUpDepolar.EditValue),
                chkSadeceStoktakiler.Checked, Raf1, Sira1, Goz1, Raf2, Sira2, Goz2);

            gridControlKalemler.DataSource = dt_Kalemler;
            GridViewKalemler.ViewCaption = "Sayım Yapılan Kalemler (" + dt_Kalemler.Rows.Count.ToString() + ")";
        }

        private void chkSadeceStoktakiler_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSadeceStoktakiler.Checked)
                chkSadeceStoktakiler.Text = "Evet";
            else
                chkSadeceStoktakiler.Text = "Hayır";
        }

        private void GridViewKalemler_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }
        private void GridViewKalemler_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value == null) return;

            if (e.Column == colSayilanMiktar || e.Column == colMevcutMiktar)
            {
                GridViewKalemler.SetRowCellValue(e.RowHandle, colFark,
                    Convert.ToDecimal(GridViewKalemler.GetFocusedRowCellValue(colMevcutMiktar)) -
                    Convert.ToDecimal(GridViewKalemler.GetFocusedRowCellValue(colSayilanMiktar)));
            }
        }

        private void GridViewSayimlar_Click(object sender, EventArgs e)
        {
            GridViewSayimlar.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewSayimlar.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Sayim();
            }
            _Focusta = false;
        }
        private void GridViewSayimlar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewSayimlar.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Sayim();
        }
        #endregion

        #region < Metod >
        void Ara_Sayimlar()
        {
            try
            {
                if (dt_Sayimlar != null)
                    dt_Sayimlar.Dispose();
                dt_Sayimlar = null;

                dt_Sayimlar = Isler.Stok.Ver_Sayimlar(Araclar.TarihSaat.Ver_BaslangicTarih(Convert.ToDateTime(dateKayitBas.EditValue)),
                    Araclar.TarihSaat.Ver_BitisTarih(Convert.ToDateTime(dateKayitBit.EditValue)));

                gridControlSayimlar.DataSource = dt_Sayimlar;
                GridViewSayimlar.ViewCaption = "Sayımlar Listesi (" + dt_Sayimlar.Rows.Count.ToString() + ")";

                if (dt_Sayimlar.Rows.Count > 0)
                {
                    btnSil.Enabled = true;
                }
                else
                {
                    btnSil.Enabled = false;
                }

                Yeni();
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Ara_Kalemler(int _SayimID)
        {
            try
            {
                if (dt_Kalemler != null)
                    dt_Kalemler.Dispose();
                dt_Kalemler = null;

                dt_Kalemler = Isler.Stok.Ver_SayimKalemler(_SayimID);
                gridControlKalemler.DataSource = dt_Kalemler;
                GridViewKalemler.ViewCaption = "Sayım Yapılan Kalemler (" + dt_Kalemler.Rows.Count.ToString() + ")";
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        void Yukle_Sayim(int SayimID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle();
                YeniKayit = false;

                btnKaydet.Enabled = false;

                if (sayim != null && sayim.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(sayim);
                }
                sayim = null;
                sayim = Isler.Stok.Ver_Sayim(ref dbModel, SayimID);                
                if (sayim == null) return;

                lookUpDepolar.EditValue = sayim.DepoID;
                memoAciklama.Text = sayim.Aciklama;

                if (sayim.Raf1 != null)
                {
                    txtRaf1.Text = sayim.Raf1.Value.ToString();
                }
                if (sayim.Sira1 != null)
                {
                    txtSira1.Text = sayim.Sira1.Value.ToString();
                }
                if (sayim.Goz1 != null)
                {
                    txtGoz1.Text = sayim.Goz1.Value.ToString();
                }


                if (sayim.Raf2 != null)
                {
                    txtRaf2.Text = sayim.Raf2.Value.ToString();
                }
                if (sayim.Sira2 != null)
                {
                    txtSira2.Text = sayim.Sira2.Value.ToString();
                }
                if (sayim.Goz2 != null)
                {
                    txtGoz2.Text = sayim.Goz2.Value.ToString();
                }

                ucKayitBilgi1.Yukle(sayim.KayitKullaniciID, sayim.KayitZaman);

                Ara_Kalemler(sayim.SayimID);
            }
            catch (Exception hata)
            {
                
                throw;
            }
        }

        void Kaydet()
        {
            if (!Isler.Yetki.Varmi_Yetki(80)) return;

            try
            {
                #region Kontroller
                if (lookUpDepolar.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Stok Sayımı Yapılacak Depoyu Seçiniz.", "Depo Seçilmedi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpDepolar.Focus(); lookUpDepolar.Select();
                    return;
                }
                #endregion

                if (sayim != null && sayim.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(sayim);
                }
                sayim = null;
                sayim = new stok_sayim();
                sayim.SirketID = Genel.AktifSirket.SirketID;

                int temp_DepoID = Convert.ToInt32(lookUpDepolar.EditValue);
                #region Aktarma
                sayim.DepoID = temp_DepoID;
                sayim.SadeceStoktakiler = chkSadeceStoktakiler.Checked;
                sayim.Aciklama = memoAciklama.Text;

                if (!string.IsNullOrEmpty(txtRaf1.Text))
                {
                    sayim.Raf1 = Convert.ToInt32(txtRaf1.Text);
                }
                if (!string.IsNullOrEmpty(txtSira1.Text))
                {
                    sayim.Sira1 = Convert.ToInt32(txtSira1.Text);
                }
                if (!string.IsNullOrEmpty(txtGoz1.Text))
                {
                    sayim.Goz1 = Convert.ToInt32(txtGoz1.Text);
                }

                if (!string.IsNullOrEmpty(txtRaf2.Text))
                {
                    sayim.Raf2 = Convert.ToInt32(txtRaf2.Text);
                }
                if (!string.IsNullOrEmpty(txtSira2.Text))
                {
                    sayim.Sira2 = Convert.ToInt32(txtSira2.Text);
                }
                if (!string.IsNullOrEmpty(txtGoz2.Text))
                {
                    sayim.Goz2 = Convert.ToInt32(txtGoz2.Text);
                }
                #endregion

                #region Kayıt
                sayim.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                sayim.KayitZaman = DateTime.Now;
                dbModel.AddTostok_sayim(sayim);
                dbModel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Stok Sayımı Başarılı Bir Şekilde Kaydedilmiştir.", null,
                   ResOtoSis.mark_blue);

                Ara_Sayimlar();
                #endregion

                #region Sayım Kalemleri
                int? temp_Raf;
                int? temp_Sira;
                int? temp_Goz;
                string temp_ParcaNo = "";
                int temp_StokKartID;
                decimal temp_MevcutMiktar = 0;
                decimal temp_SayilanMiktar = 0;
                bool temp_SayimDisi;

                decimal temp_Fark = 0;

                for (int i = 0; i < dt_Kalemler.Rows.Count; i++)
                {
                    temp_SayimDisi = Convert.ToBoolean(dt_Kalemler.Rows[i]["SayimDisi"]);
                    temp_SayilanMiktar = Convert.ToDecimal(dt_Kalemler.Rows[i]["SayilanMiktar"]);
                    temp_MevcutMiktar = Convert.ToDecimal(dt_Kalemler.Rows[i]["MevcutMiktar"]);
                    temp_StokKartID = Convert.ToInt32(dt_Kalemler.Rows[i]["StokKartID"]);
                    temp_ParcaNo = dt_Kalemler.Rows[i]["ParcaNo"].ToString();

                    temp_Fark = Convert.ToDecimal(dt_Kalemler.Rows[i]["Fark"]);

                    if (dt_Kalemler.Rows[i]["Raf"] == DBNull.Value)
                    {
                        temp_Raf = null;
                    }
                    else
                    {
                        temp_Raf = Convert.ToInt32(dt_Kalemler.Rows[i]["Raf"]);
                    }
                    if (dt_Kalemler.Rows[i]["Sira"] == DBNull.Value)
                    {
                        temp_Sira = null;
                    }
                    else
                    {
                        temp_Sira = Convert.ToInt32(dt_Kalemler.Rows[i]["Sira"]);
                    }
                    if (dt_Kalemler.Rows[i]["Goz"] == DBNull.Value)
                    {
                        temp_Goz = null;
                    }
                    else
                    {
                        temp_Goz = Convert.ToInt32(dt_Kalemler.Rows[i]["Goz"]);
                    }
                    
                    stok_sayim_kalem sayKalem = new stok_sayim_kalem();
                    sayKalem.SayimID = sayim.SayimID;
                    sayKalem.ParcaNo = temp_ParcaNo;
                    sayKalem.StokKartID = temp_StokKartID;
                    sayKalem.MevcutMiktar = temp_MevcutMiktar;
                    sayKalem.SayilanMiktar = temp_SayilanMiktar;
                    sayKalem.SayimDisi = temp_SayimDisi;
                    sayKalem.Raf = temp_Raf;
                    sayKalem.Sira = temp_Sira;
                    sayKalem.Goz = temp_Goz;
                    dbModel.AddTostok_sayim_kalem(sayKalem);
                    dbModel.SaveChanges();
                    dbModel.Detach(sayKalem);
                    sayKalem = null;

                    //stok eşitleme işlemi yapılacak
                    //Eğer fark varsa stok_hareket tablosuna işlenecek

                    if (!temp_SayimDisi && temp_Fark != 0)
                    {
                        stok_hareket sh = new stok_hareket();
                        sh.StokSayimID = sayim.SayimID;
                        sh.StokKartID = temp_StokKartID;
                        sh.StokHareketTipi = ((int)Enumlar.StokHareketTipleri.StokSayimEsitleme).ToString();
                        sh.Giris = temp_Fark > 0 ? false : true;
                        sh.Miktar = Math.Abs(temp_Fark);
                        sh.ParcaNo = temp_ParcaNo;
                        sh.KayitZaman = DateTime.Now;
                        sh.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                        sh.DepoID = temp_DepoID;

                        dbModel.AddTostok_hareket(sh);
                        dbModel.SaveChanges();
                        dbModel.Detach(sh);
                        sh = null;
                    }
                }
                #endregion
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Sil()
        {
        }
        void Yeni()
        {
            Temizle();

           btnKaydet.Enabled= YeniKayit = true;
            _Focusta = GridViewSayimlar.OptionsSelection.EnableAppearanceFocusedRow = false;
        }

        void Temizle()
        {
            lookUpDepolar.EditValue = -1;

            txtGoz1.Text = txtGoz2.Text = txtRaf1.Text = txtRaf2.Text = txtSira1.Text = txtSira2.Text = memoAciklama.Text="";

            chkSadeceStoktakiler.Checked = true;

            if (dt_Kalemler != null)
                dt_Kalemler.Clear();
        }

        void Focus_Sayim()
        {
            if (Yukleme || GridViewSayimlar.GetFocusedDataRow() == null) return;

            Yukle_Sayim(Convert.ToInt32(GridViewSayimlar.GetFocusedRowCellValue("SayimID")));
        }
        #endregion
    }
}