using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Tanim
{
    public partial class ucSirket : Sistem.ucBase
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        sirket Sirket;

        bool YeniKayit = true;

        int Secili_SirketID;

        DataTable dt_Sirketler;
        DataTable dt_AdresIlce;
        #endregion

        #region < Load >
        public ucSirket()
        {
            InitializeComponent();
        }

        private void ucSirket_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                #region databind
                lookUpAdresIl.Properties.DisplayMember = "IlAdi";
                lookUpAdresIl.Properties.ValueMember = "Plaka";
                lookUpAdresIl.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Genel.dt_Iller.Copy(), "IlAdi", "Plaka");
                #endregion

                Ara();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Şirketler Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void chkDurum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDurum.Checked)
            {
                chkDurum.Text = "Aktif";
                chkDurum.ForeColor = Color.LightGreen;
            }
            else
            {
                chkDurum.Text = "Pasif";
                chkDurum.ForeColor = Color.Red;
            }
        }

        private void lookUpAdresIl_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpAdresIl.EditValue == null) return;

            int editvalue = Convert.ToInt32(lookUpAdresIl.EditValue);

            dt_AdresIlce = null;
            dt_AdresIlce = Isler.Adres.Ver_Ilce(editvalue);

            lookUpAdresIlce.Properties.DisplayMember = "IlceAdi";
            lookUpAdresIlce.Properties.ValueMember = "IlceID";
            lookUpAdresIlce.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(dt_AdresIlce, "IlceAdi", "IlceID");

            lookUpAdresIlce.EditValue = -1;
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

        private void GridViewSirketler_Click(object sender, EventArgs e)
        {
            if (GridViewSirketler.RowCount == 1)
                Focus_Sirket();
        }
        private void GridViewSirketler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Focus_Sirket();
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
                if (dt_Sirketler != null)
                    dt_Sirketler.Dispose();
                dt_Sirketler = null;

                dt_Sirketler = Isler.Sirket.Ver_Sirketler();
                gridControlSirketler.DataSource = dt_Sirketler;

                if (dt_Sirketler.Rows.Count > 0)
                {
                    bool Bulundu = false;
                    int temp_SirketID;
                    for (int i = 0; i < GridViewSirketler.RowCount; i++)
                    {
                        temp_SirketID = Convert.ToInt32(GridViewSirketler.GetDataRow(i)["SirketID"]);
                        if (temp_SirketID == Secili_SirketID)
                        {
                            GridViewSirketler.FocusedRowHandle = i;
                            Bulundu = true;
                            break;
                        }
                    }

                    _Yukleme = false;
                    if (!Bulundu)
                    {
                        Yukle_Sirket(Convert.ToInt32(GridViewSirketler.GetDataRow(0)["SirketID"]));
                    }
                    btnSil.Enabled = true;
                }
                else
                {
                    btnSil.Enabled = false;
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Sirketler Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Yukle_Sirket(int _SirketID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_Sirket();
                YeniKayit = false;

                if (Sirket != null && Sirket.EntityState!=EntityState.Detached)
                {
                    dbModel.Detach(Sirket);
                }
                Sirket = null;
                Sirket = Isler.Sirket.Ver_Sirket(ref dbModel, _SirketID);
                if (Sirket == null) return;

                txtSirketID.Text = Sirket.SirketID.ToString();
                txtEposta.Text = Sirket.Eposta;
                txtFax.Text = Sirket.Fax;
                txtKisaAd.Text = Sirket.KisaAd;
                txtTel1.Text = Sirket.Tel1;
                txtTel2.Text = Sirket.Tel2;
                txtUnvan.Text = Sirket.Unvan;
                txtVergiDairesi.Text = Sirket.VergiDairesi;
                txtWeb.Text = Sirket.Web;
                chkDurum.Checked = Sirket.Durum;
                memoAcikAdres.Text = Sirket.AdresAcik;
                memoAciklama.Text = Sirket.Aciklama;

                if (Sirket.AdresIl != null)
                {
                    lookUpAdresIl.EditValue = Sirket.AdresIl;
                }
                if (Sirket.AdresIlce != null)
                {
                    lookUpAdresIlce.EditValue = Sirket.AdresIlce;
                }

                ucKayitBilgi1.Yukle(Sirket.KayitKullaniciID, Sirket.KayitZaman, Sirket.DuzenKullaniciID, Sirket.DuzenZaman);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Şirket Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Sil()
        {
            if (GridViewSirketler.GetFocusedDataRow() == null) return;

            if (!Genel.Yetkilerim.Contains(19))
            {
                Genel.Yetki_Uyari(19);
                return;
            }

            try
            {
                //Burada şirket işlem bilgisi kontrol edilecek.
                //Eğer şirket üzerinden herhangi bir işlem yapılmış ise silme yapılmayacak.
                string temp_SirketID = GridViewSirketler.GetFocusedDataRow()["SirketID"].ToString();
                string temp_KisaAd = GridViewSirketler.GetFocusedDataRow()["KisaAd"].ToString();

                if (XtraMessageBox.Show("Seçili Şirketi Silmek İstediğinize Emin Misiniz?\n"
                  + "Şirket No : " + temp_SirketID
                  + "\nKısa Adı : " + temp_KisaAd, "Şirket Sil Onay",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(Sirket);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Şirket Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    Ara();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Şirket Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Kaydet()
        {
            if (YeniKayit && !Genel.Yetkilerim.Contains(17))
            {
                Genel.Yetki_Uyari(17);
                return;
            }
            else if (!YeniKayit && !Genel.Yetkilerim.Contains(18))
            {
                Genel.Yetki_Uyari(18);
                return;
            }
            try
            {
                #region Kontroller
                if (string.IsNullOrEmpty(txtKisaAd.Text))
                {
                    XtraMessageBox.Show("Şirket Kısa Adı Boş Bırakılamaz.", "Eksik Alan",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    xtraTabControl1.SelectedTabPageIndex = 0;
                    txtKisaAd.Focus(); txtKisaAd.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtUnvan.Text))
                {
                    XtraMessageBox.Show("Şirket Kısa Adı Boş Bırakılamaz.", "Eksik Alan",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    xtraTabControl1.SelectedTabPageIndex = 0;
                    txtUnvan.Focus(); txtUnvan.Select();
                    return;
                }
                if (YeniKayit && Isler.Sirket.Varmi_KisaAd(txtKisaAd.Text))
                {
                    XtraMessageBox.Show("Bu Şirket Kısa Adı Daha Önce Kullanılmış.\nLütfen Farklı Bir Kısa Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    xtraTabControl1.SelectedTabPageIndex = 0;
                    txtKisaAd.Focus(); txtKisaAd.Select();
                    return;
                }
                else if (!YeniKayit && txtKisaAd.Text != Sirket.KisaAd && Isler.Sirket.Varmi_KisaAd(txtKisaAd.Text, Sirket.KisaAd))
                {
                    XtraMessageBox.Show("Bu Şirket Kısa Adı Daha Önce Kullanılmış.\nLütfen Farklı Bir Kısa Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    xtraTabControl1.SelectedTabPageIndex = 0;
                    txtKisaAd.Focus(); txtKisaAd.Select();
                    return;
                }

                if (YeniKayit && Isler.Sirket.Varmi_Unvan(txtUnvan.Text))
                {
                    XtraMessageBox.Show("Bu Şirket Ünvanı Daha Önce Kullanılmış.\nLütfen Farklı Bir Ünvan Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    xtraTabControl1.SelectedTabPageIndex = 0;
                    txtUnvan.Focus(); txtUnvan.Select();
                    return;
                }
                else if (!YeniKayit && txtUnvan.Text != Sirket.Unvan && Isler.Sirket.Varmi_Unvan(txtUnvan.Text, Sirket.Unvan))
                {
                    XtraMessageBox.Show("Bu Şirket Ünvanı Daha Önce Kullanılmış.\nLütfen Farklı Bir Ünvanı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    xtraTabControl1.SelectedTabPageIndex = 0;
                    txtUnvan.Focus(); txtUnvan.Select();
                    return;
                }
                #endregion
                if (YeniKayit)
                {
                    if (Sirket != null && Sirket.EntityState!=EntityState.Detached)
                    {
                        dbModel.Detach(Sirket);
                    }
                    Sirket = null;
                    Sirket = new sirket();
                }

                #region Aktarma
                Sirket.Durum = chkDurum.Checked;
                Sirket.KisaAd = txtKisaAd.Text;
                Sirket.Unvan = txtUnvan.Text;
                Sirket.Aciklama = memoAciklama.Text;

                Sirket.Tel1 = txtTel1.Text;
                Sirket.Tel2 = txtTel2.Text;
                Sirket.Fax = txtFax.Text;
                Sirket.Web = txtWeb.Text;
                Sirket.Eposta = txtEposta.Text;
                if (lookUpAdresIl.EditValue.ToString() == "-1")
                {
                    Sirket.AdresIl = null;
                }
                else
                {
                    Sirket.AdresIl = Convert.ToInt32(lookUpAdresIl.EditValue);
                }

                if (lookUpAdresIlce.EditValue.ToString() == "-1")
                {
                    Sirket.AdresIlce = null;
                }
                else
                {
                    Sirket.AdresIlce = Convert.ToInt32(lookUpAdresIlce.EditValue);
                }
                Sirket.AdresAcik = memoAcikAdres.Text;

                Sirket.VergiDairesi = txtVergiDairesi.Text;
                #endregion

                #region Kayıt
                if (YeniKayit)
                {
                    Sirket.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    Sirket.KayitZaman = DateTime.Now;
                    dbModel.AddTosirkets(Sirket);
                }
                else
                {
                    Sirket.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    Sirket.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Şirket Başarılı Bir Şekilde Kaydedilmiştir.", null,
                    ResOtoSis.mark_blue);

                Secili_SirketID = Sirket.SirketID;
                Ara();
                #endregion
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Şirket Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Yeni()
        {
            YeniKayit = true;
            Temizle_Sirket();

            //pEnable(false);

            xtraTabControl1.SelectedTabPageIndex = 0;
            txtKisaAd.Focus(); txtKisaAd.Select();
        }

        void Focus_Sirket()
        {
            if (_Yukleme || GridViewSirketler.GetFocusedRow() == null) return;
            Secili_SirketID = Convert.ToInt32(GridViewSirketler.GetFocusedRowCellValue("SirketID"));
            YeniKayit = false;

            Yukle_Sirket(Secili_SirketID);
        }

        void Temizle_Sirket()
        {
            txtEposta.Text = txtFax.Text = txtKisaAd.Text = txtSirketID.Text = txtTel1.Text = txtTel2.Text = txtUnvan.Text
            = txtVergiDairesi.Text = txtWeb.Text = "";

            chkDurum.Checked = true;

            lookUpAdresIl.EditValue = lookUpAdresIlce.EditValue = -1;
        }
        #endregion              
    }
}