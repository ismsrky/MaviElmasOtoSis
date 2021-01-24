using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;
using System.Data.Objects;

namespace MaviElmasOtoSis.Stok
{
    public partial class ucStokDepo : Sistem.ucBase
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        stok_depo depo;

        bool YeniKayit = true;

        int Secili_DepoID;

        DataTable dt_Depolar;
        #endregion

        #region < Load >
        public ucStokDepo()
        {
            InitializeComponent();
        }

        private void ucStokDepo_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                Ara();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Depolar Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void chkKilitli_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKilitli.Checked)
            {
                chkKilitli.Text = "Evet";
                chkKilitli.ForeColor = Color.Red;
            }
            else
            {
                chkKilitli.Text = "Hayır";
                chkKilitli.ForeColor = Color.LightGreen;
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

        private void GridViewStokDepo_Click(object sender, EventArgs e)
        {
            GridViewStokDepo.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewStokDepo.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Depo();
            }
            _Focusta = false;
        }
        private void GridViewStokDepo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewStokDepo.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Depo();
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

                if (dt_Depolar != null)
                    dt_Depolar.Dispose();
                dt_Depolar = null;

                dt_Depolar = Isler.Stok.Ver_Depolar();
                gridControlStokDepo.DataSource = dt_Depolar;
                _Yukleme = false;

                if (dt_Depolar.Rows.Count > 0)
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
                XtraMessageBox.Show("Depolar Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Yukle_Depo(int _DepoID)
        {
            if (_Yukleme) return;
            try
            {
                Temizle_Depo();
                YeniKayit = false;

                if (depo != null && depo.EntityState!=EntityState.Detached)
                {
                    dbModel.Detach(depo);
                }
                depo = null;
                depo = Isler.Stok.Ver_Depo(ref dbModel, _DepoID);
                if (depo == null) return;

                txtDepoID.Text = depo.DepoID.ToString();
                txtDepoAd.Text = depo.DepoAd;
                chkKilitli.Checked = depo.Kilitli;

                memoAciklama.Text = depo.Aciklama;
                memoLokasyon.Text = depo.Lokasyon;

                ucKayitBilgi1.Yukle(depo.KayitKullaniciID, depo.KayitZaman, depo.DuzenKullaniciID, depo.DuzenZaman);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Depo Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Sil()
        {
            if (GridViewStokDepo.GetFocusedDataRow() == null) return;

            if (!Genel.Yetkilerim.Contains(21))
            {
                Genel.Yetki_Uyari(21);
                return;
            }
            try
            {
                if (Isler.Stok.Ver_AdetDepoHareket(depo.DepoID) > 0)
                {
                    XtraMessageBox.Show("Bu Depo Üzerinden Stok Giriş/Çıkış İşlemleri Yapılmış.\nBu Yüzden Depo Silinemez.", "Geçersiz İşlem",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string temp_depoad = GridViewStokDepo.GetFocusedDataRow()["DepoAd"].ToString();
                string temp_depoid = GridViewStokDepo.GetFocusedDataRow()["DepoID"].ToString();

                if (XtraMessageBox.Show("Seçili Depoyu Silmek İstediğinize Emin Misiniz?\n"
                   + "Depo No : " + temp_depoid
                   +"\nDepo Adı : "+temp_depoad, "Depo Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(depo);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Depo Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    Ara();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Depo Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Kaydet()
        {
            if (YeniKayit && !Genel.Yetkilerim.Contains(22))
            {
                Genel.Yetki_Uyari(22);
                return;
            }
            else if (!YeniKayit && !Genel.Yetkilerim.Contains(23))
            {
                Genel.Yetki_Uyari(23);
                return;
            }
            try
            {
                #region Kontroller
                if (string.IsNullOrEmpty(txtDepoAd.Text.Trim()))
                {
                    XtraMessageBox.Show("Depo Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDepoAd.Focus(); txtDepoAd.Select();
                    return;
                }

                if (YeniKayit && Isler.Stok.Varmi_DepoAdi(txtDepoAd.Text))
                {
                    XtraMessageBox.Show("Bu Depo Adı Daha Önce Kullanılmış\nLütfen Farklı Bir Depo Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDepoAd.Focus(); txtDepoAd.Select();
                    return;
                }
                else if (!YeniKayit && txtDepoAd.Text != depo.DepoAd && Isler.Stok.Varmi_DepoAdi(txtDepoAd.Text,depo.DepoAd))
                {
                    XtraMessageBox.Show("Bu Depo Adı Daha Önce Kullanılmış\nLütfen Farklı Bir Depo Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDepoAd.Focus(); txtDepoAd.Select();
                    return;
                }
                #endregion

                if (YeniKayit)
                {
                    if (XtraMessageBox.Show("Depo Aşağıdaki Şirket Üzerine Açılak:\n\n"
                        + "Şirket No : " + Genel.AktifSirket.SirketID.ToString()
                        + "\nŞirket Adı : " + Genel.AktifSirket.KisaAd, "Depo Ekleme Onay",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    if (depo != null && depo.EntityState!=EntityState.Detached)
                    {
                        dbModel.Detach(depo);
                    }
                    depo = null;
                    depo = new stok_depo();
                    depo.SirketID = Genel.AktifSirket.SirketID;
                }

                #region Aktarma
                depo.Aciklama = memoAciklama.Text;
                depo.DepoAd = txtDepoAd.Text;
                depo.Kilitli = chkKilitli.Checked;
                depo.Lokasyon = memoLokasyon.Text;
                #endregion

                #region Kayıt
                if (YeniKayit)
                {
                    depo.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    depo.KayitZaman = DateTime.Now;

                    dbModel.AddTostok_depo(depo);
                }
                else
                {
                    depo.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    depo.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Depo Başarılı Bir Şekilde Kaydedilmiştir.", null,
                    ResOtoSis.mark_blue);

                Ara();
                #endregion
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Depo Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Yeni()
        {
            YeniKayit = true;
            Temizle_Depo();

            txtDepoAd.Focus(); txtDepoAd.Select();

            _Focusta = GridViewStokDepo.OptionsSelection.EnableAppearanceFocusedRow = false;
        }

        void Focus_Depo()
        {
            if (_Yukleme) return;
            Secili_DepoID = Convert.ToInt32(GridViewStokDepo.GetFocusedRowCellValue("DepoID"));
            YeniKayit = false;

            Yukle_Depo(Secili_DepoID);
        }

        void Temizle_Depo()
        {
            txtDepoAd.Text = txtDepoID.Text = memoAciklama.Text = memoLokasyon.Text = "";

            chkKilitli.Checked = false;
        }
        #endregion       
    }
}