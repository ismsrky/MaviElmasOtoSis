using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Kullanici
{
    public partial class frmKullaniciBilgileriDegistir :Sistem.frmBase
    {
        public frmKullaniciBilgileriDegistir()
        {
            InitializeComponent();

            this.Text = "Kullanıcı Bilgileri";
        }

        private void frmKullaniciBilgileriDegistir_Load(object sender, EventArgs e)
        {
            txtAd.Text = Genel.AktifKullanici.Ad;
            txtSoyad.Text = Genel.AktifKullanici.Soyad;
            txtKullaniciAd.Text = Genel.AktifKullanici.KullaniciAd;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            try
            {
                #region Kontroller
                if (string.IsNullOrEmpty(txtKullaniciAd.Text.Trim()))
                {
                    XtraMessageBox.Show("Kullanici Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKullaniciAd.Focus(); txtKullaniciAd.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtAd.Text.Trim()))
                {
                    XtraMessageBox.Show("Ad Alanı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAd.Focus(); txtAd.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtSoyad.Text.Trim()))
                {
                    XtraMessageBox.Show("Soyad Alanı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoyad.Focus(); txtSoyad.Select();
                    return;
                }

                if (!string.IsNullOrEmpty(txtSifre.Text.Trim()))
                {
                    if (Genel.AktifKullanici.KullaniciSifre != Araclar.Sifreleme.EncryptToString(txtSifre.Text))
                    {
                        XtraMessageBox.Show("Girdiğiniz Şifre Geçersiz.", "Yanlış Değer",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSifre.Focus(); txtSifre.Select();
                        return;
                    }
                    if (txtSifreYeni.Text != txtSifreTekrar.Text)
                    {
                        XtraMessageBox.Show("Şifreler Birbirini Tutmuyor.", "Yanlış Değer",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSifreYeni.Focus(); txtSifreYeni.Select();
                        return;
                    }
                }
                #endregion

                Genel.AktifKullanici.Ad = Araclar.Sifreleme.EncryptToString(txtAd.Text);
                Genel.AktifKullanici.Soyad = Araclar.Sifreleme.EncryptToString(txtSoyad.Text);
                Genel.AktifKullanici.KullaniciAd = Araclar.Sifreleme.EncryptToString(txtKullaniciAd.Text);


                if (!string.IsNullOrEmpty(txtSifre.Text.Trim()))
                {
                    Genel.AktifKullanici.KullaniciSifre = Araclar.Sifreleme.EncryptToString(txtSifreYeni.Text);
                }

                Genel.AktifKullanici.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                Genel.AktifKullanici.DuzenZaman = DateTime.Now;

                Genel.dbModel.SaveChanges();

                Genel.AktifKullanici.Ad = txtAd.Text;
                Genel.AktifKullanici.Soyad = txtSoyad.Text;
                Genel.AktifKullanici.KullaniciAd = txtKullaniciAd.Text;

                if (Genel.AnaEkran != null)
                {
                    Genel.AnaEkran.lblAdSoyad.Text = txtAd.Text + " " + txtSoyad.Text;
                }

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Kullanıcı Bilgileriniz Başarılı Bir Şekilde Güncellenmiştir.", null,
                  ResOtoSis.mark_blue);

                txtSifreYeni.Text = txtSifreTekrar.Text = txtSifre.Text = "";
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kullanci Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSifre_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSifre.Text.Trim().Length > 0)
            {
                txtSifreTekrar.Enabled = txtSifreYeni.Enabled = true;
            }
            else
            {
                txtSifreTekrar.Enabled = txtSifreYeni.Enabled = false;
            }
        }
    }
}