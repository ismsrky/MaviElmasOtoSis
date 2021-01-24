using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;
using System.Data.Objects;

namespace MaviElmasOtoSis.Kullanici
{
    public partial class ucKullanici : Sistem.ucBase
    {
        #region < Değişkenler >
        kullanici kull;
        otosisdbEntities dbModel;
        ObjectStateEntry stateEntry = null;

        bool YeniKayit = true;
        bool Yukleme = false;

        int Secili_KullaniciID;
        #endregion

        #region < Load >
        public ucKullanici()
        {
            InitializeComponent();
        }

        private void ucKullanici_Load(object sender, EventArgs e)
        {
            try
            {
                Yukleme = true;
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                Ara(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Sistem Kullanıcılar Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void chkDurum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDurum.Checked)
                chkDurum.Text = "Aktif";
            else
                chkDurum.Text = "Pasif";
        }

        private void btnSifreSifirla_Click(object sender, EventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(10)) return;

            try
            {
                if (XtraMessageBox.Show("Seçili Kullanıcının Şifresini Sıfırlamak İstediğinize Emin Misiniz?", "Kullanıcı Şifre Sıfırlama",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                kull.KullaniciAd = Araclar.Sifreleme.EncryptToString(kull.KullaniciAd);
                kull.Ad = Araclar.Sifreleme.EncryptToString(kull.Ad);
                kull.Soyad = Araclar.Sifreleme.EncryptToString(kull.Soyad);
              
                kull.KullaniciSifre = "134121112107126247087199030032204013221122235069";
                dbModel.SaveChanges();

                XtraMessageBox.Show("Kullanıcı Şifresi Başarılı Bir Şekilde Sıfırlanmış.\n\nKullanıcının Yeni Şifresi '1' dir.", "İşlem Başarılı",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kullanci Şifre Sıfırlama İşlemi Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnYetkileri_Click(object sender, EventArgs e)
        {
            using (Sistem.frmKullaniciYetki yetkileri = new Sistem.frmKullaniciYetki())
            {
                yetkileri.KullaniciID = kull.KullaniciID;
                yetkileri.ShowDialog();
            }
        }

        private void GridViewKullanici_Click(object sender, EventArgs e)
        {
            GridViewKullanici.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewKullanici.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Kullanici();
            }
            _Focusta = false;
        }
        private void GridViewKullanici_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewKullanici.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Kullanici();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara(true);
        }
        #endregion

        #region < Metod >
        void Ara(bool Yeniden)
        {
            try
            {
                Yukleme = true;

                if (Yeniden || Genel.dt_Kullanicilar == null)
                {
                    Genel.dt_Kullanicilar = null;
                    Genel.dt_Kullanicilar = Isler.Kullanici.Ver_Kullanicilar();
                }
                gridControlKullanici.DataSource = Genel.dt_Kullanicilar;
                GridViewKullanici.ViewCaption = "Sistem Kullanıcılar Listesi ("+Genel.dt_Kullanicilar.Rows.Count.ToString()+")";

                if (Genel.dt_Kullanicilar.Rows.Count > 0)
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
                XtraMessageBox.Show("Sistem Kullanıcıları Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Yukleme = false;
            }
        }

        void Yukle(int _KullaniciID)
        {
            if (Yukleme) return;

            try
            {
                Temizle_Detay();
                YeniKayit = false;

                if (kull != null && dbModel.ObjectStateManager.TryGetObjectStateEntry(kull, out stateEntry))
                {
                    dbModel.Detach(kull);
                }
                kull = null;
                kull = Isler.Kullanici.Ver_Kullanici(ref dbModel, _KullaniciID);
                if (kull == null) return;

                txtAdi.Text = kull.Ad;
                txtSoyadi.Text = kull.Soyad;
                txtKullaniciAdi.Text =kull.KullaniciAd;
                chkDurum.Checked = kull.Durum;

                pEnable(true);
                ucKayitBilgi1.Yukle(kull.KayitKullaniciID,kull.KayitZaman, kull.DuzenKullaniciID, kull.DuzenZaman);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kullanıcı Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Sil()
        {
            if (GridViewKullanici.GetFocusedDataRow() == null) return;

            if (!Genel.Yetkilerim.Contains(7))
            {
                Genel.Yetki_Uyari(7);
                return;
            }
            try
            {
                //Burada kullanıcı işlem bilgisi kontrol edilecek.
                //Eğer kullanıcı üzerinden herhangi bir işlem yapılmış ise silme yapılmayacak.
                string temp_kullanicidi = GridViewKullanici.GetFocusedDataRow()["KullaniciAd"].ToString();

                if (XtraMessageBox.Show("Seçili Kullanıcıyı Silmek İstediğinize Emin Misiniz?\n"
                   + "Kullanıcı Adı : " + temp_kullanicidi, "Kullanıcı Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(kull);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Kullanıcı Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    Ara(true);
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kullanıcı Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Kaydet()
        {
            if (YeniKayit && !Genel.Yetkilerim.Contains(6))
            {
                Genel.Yetki_Uyari(8);
                return;
            }
            else if (!YeniKayit && !Genel.Yetkilerim.Contains(8))
            {
                Genel.Yetki_Uyari(8);
                return;
            }
            try
            {
                #region Kontroller
                if (string.IsNullOrEmpty(txtKullaniciAdi.Text))
                {
                    XtraMessageBox.Show("Kullanici Adı Boş Bırakılamaz.", "Eksik Alan",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKullaniciAdi.Focus(); txtKullaniciAdi.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtAdi.Text.Trim()))
                {
                    XtraMessageBox.Show("Ad Alanı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdi.Focus(); txtAdi.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtSoyadi.Text.Trim()))
                {
                    XtraMessageBox.Show("Soyad Alanı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoyadi.Focus(); txtSoyadi.Select();
                    return;
                }
                if (YeniKayit && Isler.Kullanici.Varmi_KullaniciAdi(txtKullaniciAdi.Text))
                {
                    XtraMessageBox.Show("Bu Kullanıcı Adı Daha Önce Kullanılmış\nLütfen Farklı Bir Kulklanıcı Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKullaniciAdi.Focus(); txtKullaniciAdi.Select();
                    return;
                }
                else if (!YeniKayit && txtKullaniciAdi.Text!=kull.KullaniciAd &&Isler.Kullanici.Varmi_KullaniciAdi(txtKullaniciAdi.Text, kull.KullaniciAd))
                {
                    XtraMessageBox.Show("Bu Kullanıcı Adı Daha Önce Kullanılmış\nLütfen Farklı Bir Kulklanıcı Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKullaniciAdi.Focus(); txtKullaniciAdi.Select();
                    return;
                }
                #endregion

                if (YeniKayit)
                {
                    if (kull != null && dbModel.ObjectStateManager.TryGetObjectStateEntry(kull, out stateEntry))
                    {
                        dbModel.Detach(kull);
                    }
                    kull = null;
                    
                    kull = new kullanici();
                    kull.KullaniciSifre = "134121112107126247087199030032204013221122235069";
                    kull.SirketID = 1;
                }

                kull.KullaniciAd = Araclar.Sifreleme.EncryptToString(txtKullaniciAdi.Text);
                kull.Ad = Araclar.Sifreleme.EncryptToString(txtAdi.Text);
                kull.Soyad = Araclar.Sifreleme.EncryptToString(txtSoyadi.Text);
                kull.Durum = chkDurum.Checked;

                if (YeniKayit)
                {
                    kull.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    kull.KayitZaman = DateTime.Now;
                    dbModel.AddTokullanicis(kull);

                    XtraMessageBox.Show("Kullanıcı Başarılı Bir Şekilde Kaydedilmiştir.\n\nKullanıcın ilk şifresi '1' dir.", "İşlem Başarılı",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    kull.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    kull.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Kullanıcı Başarılı Bir Şekilde Kaydedilmiştir.", null,
                    ResOtoSis.mark_blue);

                Ara(true);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kullanci Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Yeni()
        {
            YeniKayit = true;
            Temizle_Detay();

            pEnable(false);

            txtKullaniciAdi.Focus(); txtKullaniciAdi.Select();

            _Focusta = GridViewKullanici.OptionsSelection.EnableAppearanceFocusedRow = false;
        }

        void Focus_Kullanici()
        {
            if (Yukleme||GridViewKullanici.GetFocusedRow()==null) return;
            Secili_KullaniciID = Convert.ToInt32(GridViewKullanici.GetFocusedRowCellValue("KullaniciID"));
            YeniKayit = false;

            Yukle(Secili_KullaniciID);
        }

        void Temizle_Detay()
        {
            txtAdi.Text = txtKullaniciAdi.Text = txtSoyadi.Text = "";


            ucKayitBilgi1.Temizle();
            chkDurum.Checked = true;
        }

        void pEnable(bool deger)
        {
            btnYetkileri.Enabled = btnSifreSifirla.Enabled = deger;
        }
        #endregion                      
      
    }
}
