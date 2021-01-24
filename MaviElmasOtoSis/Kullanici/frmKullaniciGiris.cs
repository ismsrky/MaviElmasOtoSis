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
    public partial class frmKullaniciGiris : Sistem.frmBase
    {
        public frmKullaniciGiris()
        {
            InitializeComponent();

            this.Text = "Kullanıcı Doğrulama Ekranı";
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            #region < Kontroller >
            if (string.IsNullOrEmpty(txtKullaniciAd.Text))
            {
                 XtraMessageBox.Show("Lütfen Şuan Sistemde Oturum Açan Kullanıcı Adını Giriniz.", "Eksik Alan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAd.Focus(); txtKullaniciAd.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtSifre.Text))
            {
                 XtraMessageBox.Show("Lütfen Şuan Sistemde Oturum Açan Kullanıcının Şifresini Giriniz.", "Eksik Alan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSifre.Focus(); txtSifre.Select();
                return;
            }
            #endregion

            if (txtKullaniciAd.Text == Genel.AktifKullanici.KullaniciAd&&txtSifre.Text==Araclar.Sifreleme.DecryptString(Genel.AktifKullanici.KullaniciSifre))
            {
                this.Hide();

                frmKullaniciBilgileriDegistir bilgileriDegistir = new frmKullaniciBilgileriDegistir();
                bilgileriDegistir.ShowDialog();
                //this.Close();
            }
            else
            {
                 XtraMessageBox.Show("Yanlış Kullanıcı Adı veya Şifre.", "Yanlış Değer",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}