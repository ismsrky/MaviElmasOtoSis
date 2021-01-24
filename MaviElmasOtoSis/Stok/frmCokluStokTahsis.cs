using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Stok
{
    public partial class frmCokluStokTahsis : Sistem.frmBase
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        stok_hareket sh;

        DataTable dt_StokKartlar;
        DataTable dt_Araclar;
        DataTable dt_Depolar;

        DataTable dt_Parcalar;
        #endregion

        #region < Load >
        public frmCokluStokTahsis()
        {
            InitializeComponent();
        }

        private void frmCokluStokTahsis_Load(object sender, EventArgs e)
        {
            try
            {
                dbModel = new otosisdbEntities(VeriYonetimi.Baglanti.BaglantiEntity);
                #region databind
                dt_Parcalar = new DataTable();
                dt_Parcalar.Columns.Add("KartID", typeof(int));
                dt_Parcalar.Columns.Add("ParcaNo", typeof(string));
                dt_Parcalar.Columns.Add("KalemAdi", typeof(string));
                dt_Parcalar.Columns.Add("Miktar", typeof(decimal));
                dt_Parcalar.Columns.Add("DepoID", typeof(int));
                dt_Parcalar.Columns.Add("AracID", typeof(int));
                gridControlParcalar.DataSource = dt_Parcalar;
                dt_Parcalar.RowDeleted += new DataRowChangeEventHandler(dt_Parcalar_RowDeleted);

                dt_Depolar = Genel.dt_DepolarSecim.Copy();
                reLookUpDepo.DisplayMember = "DepoAd";
                reLookUpDepo.ValueMember = "DepoID";
                reLookUpDepo.DataSource = dt_Depolar;

                reGridLookAraclar.DisplayMember = "Plaka";
                reGridLookAraclar.ValueMember = "AracID";
                reGridLookAraclar.View.OptionsView.ShowAutoFilterRow = true;

                reGridLookStokKartlari.DisplayMember = reGridLookStokKartlari.ValueMember = "ParcaNo";


                Ara_Araclar(false);
                Ara_StokKartlari(false);
                #endregion

                GridViewParcalar.AddNewRow();
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        #endregion

        #region < Olaylar >
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void dt_Parcalar_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                dt_Parcalar.Rows.Remove(e.Row);
            }
            catch { }
        }

        private void GridViewParcalar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GridViewParcalar.AddNewRow();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                GridViewParcalar.DeleteSelectedRows();
            }
        }

        private void GridViewParcalar_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value == null) return;

            if (e.Column == colParcaNo)
            {
                string temp_ParcaNo = e.Value.ToString();

                var tempKart = (from abc in dbModel.stok_kart
                                where abc.ParcaNo == temp_ParcaNo && abc.SirketID == Genel.AktifSirket.SirketID
                                select new
                                {
                                    abc.KartID,
                                    abc.KalemAdi
                                }).SingleOrDefault();

                if (tempKart == null) return;

                GridViewParcalar.SetRowCellValue(e.RowHandle, colKartID, tempKart.KartID);
                GridViewParcalar.SetRowCellValue(e.RowHandle, colKalemAdi, tempKart.KalemAdi);
                GridViewParcalar.SetRowCellValue(e.RowHandle, colMiktar, 1);
                GridViewParcalar.SetRowCellValue(e.RowHandle, colDepoAd, Genel.AktifDepo.DepoID);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara_Araclar(true);
            Ara_StokKartlari(true);
        }
        #endregion

        #region < Metod >
        void Kaydet()
        {
            try
            {
                #region Kontroller
                int temp_KartID;
                int temp_DepoID;
                string temp_KalemAdi;
                for (int i = 0; i < dt_Parcalar.Rows.Count; i++)
                {
                    if (dt_Parcalar.Rows[i]["KartID"] != DBNull.Value)
                    {
                        temp_KartID = Convert.ToInt32(dt_Parcalar.Rows[i]["KartID"]);
                        temp_DepoID = Convert.ToInt32(dt_Parcalar.Rows[i]["DepoID"]);
                        temp_KalemAdi = dt_Parcalar.Rows[i]["KalemAdi"].ToString();

                        if (dt_Parcalar.Rows[i]["Miktar"] == DBNull.Value || Convert.ToDecimal(dt_Parcalar.Rows[i]["Miktar"]) <= 0)
                        {
                            XtraMessageBox.Show("Aşağıda Bilgileri Verilen Stok Kalemi Miktarı 0'dan Büyük Olmalıdır.\n\n"
                                                  + "Kart No : " + temp_KartID.ToString()
                                                  + "\nKalem Adı : " + temp_KalemAdi, "Miktar Girilmedi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (radioGiris.SelectedIndex==1&& Isler.Stok.StokAdet(temp_KartID, temp_DepoID) <= 0)
                        {
                            XtraMessageBox.Show("Aşağıda Bilgileri Verilen Stok Kalemi Seçilen Depoda Bulunmamaktadır.\n\n"
                                                + "Kart No : " + temp_KartID.ToString()
                                                + "\nKalem Adı : " + temp_KalemAdi, "Depo Seçilmedi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }                       
                    }
                }
                #endregion

                #region Kayıt
                int? temp_AracID = null;
                decimal temp_Miktar;
                string temp_ParcaNo;
                for (int i = 0; i < dt_Parcalar.Rows.Count; i++)
                {
                    if (dt_Parcalar.Rows[i]["KartID"] != DBNull.Value)
                    {
                        temp_KartID = Convert.ToInt32(dt_Parcalar.Rows[i]["KartID"]);
                        temp_ParcaNo = dt_Parcalar.Rows[i]["ParcaNo"].ToString();
                        temp_DepoID = Convert.ToInt32(dt_Parcalar.Rows[i]["DepoID"]);
                        temp_KalemAdi = dt_Parcalar.Rows[i]["KalemAdi"].ToString();
                        temp_Miktar = Convert.ToDecimal(dt_Parcalar.Rows[i]["Miktar"]);
                        
                        if (dt_Parcalar.Rows[i]["AracID"] == DBNull.Value)
                        {
                            temp_AracID = null;
                        }
                        else
                        {
                            temp_AracID = Convert.ToInt32(dt_Parcalar.Rows[i]["AracID"]);
                        }

                        sh = new stok_hareket();
                        sh.StokKartID = temp_KartID;
                        sh.StokHareketTipi = ((int)Enumlar.StokHareketTipleri.StokTahsisi).ToString();
                        sh.Miktar = temp_Miktar;
                        sh.DepoID = temp_DepoID;
                        sh.ParcaNo = temp_ParcaNo;
                        sh.AracID = temp_AracID;
                        sh.Giris = radioGiris.SelectedIndex == 0 ? true : false;
                        sh.Aciklama = memoAciklama.Text.Trim() == "" ? null : memoAciklama.Text;

                        sh.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                        sh.KayitZaman = DateTime.Now;

                        dbModel.AddTostok_hareket(sh);
                        dbModel.SaveChanges();
                        dbModel.Detach(sh);
                        sh = null;
                    }
                }

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Stok Tahsisi Başarılı Bir Şekilde Kaydedilmiştir.", null,
                 ResOtoSis.mark_blue);

                if (XtraMessageBox.Show("Başka Stok Tahsis İşlemi Yapmak İstiyor Musunuz?", "Başka İşlem Yapılacak Mı?",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    dt_Parcalar.Rows.Clear();
                    GridViewParcalar.AddNewRow();
                }
                #endregion
            }
            catch (Exception hata)
            {
                
                throw;
            }
        }

        void Ara_StokKartlari(bool Yeniden)
        {
            try
            {
                if (Yeniden || Genel.dt_StokKartlarSecim == null)
                {
                    if (Genel.dt_StokKartlarSecim != null)
                        Genel.dt_StokKartlarSecim.Dispose();
                    Genel.dt_StokKartlarSecim = null;
                    Genel.dt_StokKartlarSecim = Isler.Stok.Ver_StokKartlari(true);
                }

                if (dt_StokKartlar != null)
                    dt_StokKartlar.Dispose();
                dt_StokKartlar = null;
                dt_StokKartlar = Genel.dt_StokKartlarSecim.Copy();
                reGridLookStokKartlari.DataSource = dt_StokKartlar;
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Ara_Araclar(bool Yeniden)
        {
            if (Yeniden || Genel.dt_Araclar == null)
            {
                Genel.dt_Araclar = null;
                Genel.dt_Araclar = Isler.Arac.Ver_Araclar();
            }

            if (dt_Araclar != null)
                dt_Araclar.Dispose();
            dt_Araclar = null;
            dt_Araclar = Genel.dt_Araclar.Copy();

            reGridLookAraclar.DataSource = dt_Araclar;
        }
        #endregion              
    }
}