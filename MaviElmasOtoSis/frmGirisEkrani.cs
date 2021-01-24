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

namespace MaviElmasOtoSis
{
    public partial class frmGirisEkrani : Sistem.frmBase
    {
        #region < Değişkenler >

        #endregion

        #region < Load >
        public frmGirisEkrani()
        {
            InitializeComponent();

            this.Text = "Giriş Ekranı";
        }

        private void frmGirisEkrani_Load(object sender, EventArgs e)
        {
            try
            {
                 string sonuc = Baglanti.Baglanti_Dene(Baglanti.ServerAdres, Baglanti.VeritabaniAdi, Baglanti.KullaniciAdi, Baglanti.KullaniciSifre);
            if (sonuc != "Olumlu")
            {
                XtraMessageBox.Show("Veritaban Bağlantı Hatası.\nAyarlar Sayfasına Yönlendirileceksiniz.\n\nHata:\n" + sonuc, "Veritabanı Hatası",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Ac_Ayarlar();
                return;
            }

            Genel.Al_Verileri(true);

            lookUpSirketler.Properties.DisplayMember = "KisaAd";
            lookUpSirketler.Properties.ValueMember = "SirketID";
            lookUpSirketler.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Isler.Sirket.Ver_Sirketler(true), "KisaAd", "SirketID");

            Temizle();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show(hata.Message);
            }

            //txtKullaniciAdi.Text = "ismail";
            //txtKullaniciSifre.Text = "353419";
            //btnTamam.PerformClick();
        }
        #endregion

        #region < Olaylar >
        private void btnTamam_Click(object sender, EventArgs e)
        {
            #region < Kontroller >
            if (lookUpSirketler.EditValue.ToString() == "-1")
            {
                XtraMessageBox.Show("Lütfen Çalışmak İstediğiniz Şirketi Seçiniz.", "Şirket Seçilmedi.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpSirketler.Focus(); lookUpSirketler.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtKullaniciAdi.Text.Trim()))
            {
                XtraMessageBox.Show("Kullanıcı Adı Boş Bırakılamaz.", "Eksik Alan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Focus(); txtKullaniciAdi.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtKullaniciSifre.Text.Trim()))
            {
                XtraMessageBox.Show("Kullanıcı Şifresi Boş Bırakılamaz.", "Eksik Alan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciSifre.Focus(); txtKullaniciSifre.Select();
                return;
            }
            #endregion

            if (Isler.Kullanici.Varmi_Kullanici(txtKullaniciAdi.Text, txtKullaniciSifre.Text, Convert.ToInt32(lookUpSirketler.EditValue)))
            {

                this.Cursor = Cursors.WaitCursor;
                marqueeProgressBarControl1.Visible = true;
                //backgroundWorker1.
                backgroundWorker1.RunWorkerAsync();

                //Genel.Al_Verileri(false);

                //if (!Genel.Yetkilerim.Contains(1))
                //{
                //    Genel.Yetki_Uyari(1);
                //    return;
                //}               
            }
            else
            {
                XtraMessageBox.Show("Kullanıcı Adı/Şifre Yanlış veya Doğru Şirket Seçilmedi.", "Giriş Hatası",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lookUpSirketler_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpSirketler.EditValue != null)
            {
                Sistem.Ayarlar.VarsayilanSirketID = Convert.ToInt32(lookUpSirketler.EditValue);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Ac_Ayarlar();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool GirisOlumlu = false;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string dbVersiyon = Isler.Genelparam.Ver_ParamKarsilik(4).ToString();
                Araclar.Sistem.VersiyonKiyasla KiyasSonuc = Araclar.Sistem.Versiyon_Kiyasla(dbVersiyon, Araclar.Sistem.VersiyonBilgisi);
                if (KiyasSonuc == Araclar.Sistem.VersiyonKiyasla.SagBuyuk)
                {
                    XtraMessageBox.Show("Kullanmış Olduğunuz Veritabanı Versiyonu Eski.\n\nLütfen Veritabanınızı Güncelleyiniz."
                                        + "\n\nKullandığınız Versiyon: " + Araclar.Sistem.VersiyonBilgisi
                                        + "\nVeritabanı Versiyonu : " + dbVersiyon, "Versiyon Hatası",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GirisOlumlu = false;
                    return;
                }
                else if (KiyasSonuc == Araclar.Sistem.VersiyonKiyasla.SolBuyuk)
                {
                    if (XtraMessageBox.Show("Sistem Güncellemesi Algılandı.\n\nŞimdi Güncelleme Yapmak İster Misiniz?"
                                            + "\n\nKullandığınız Versiyon: " + Araclar.Sistem.VersiyonBilgisi
                                            + "\nGüncel Versiyon : " + dbVersiyon, "Versiyon Güncelle",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Application.StartupPath + @"\ClientVersiyonGuncelle.exe");
                        Application.Exit();
                    }
                    GirisOlumlu = false;
                    return;
                }

                if (Genel.AktifKullanici != null && Genel.AktifKullanici.EntityState != EntityState.Detached)
                {
                    Genel.dbModel.Detach(Genel.AktifKullanici);
                }
                Genel.AktifKullanici = null;
                Genel.AktifKullanici = Isler.Kullanici.Ver_Kullanici(ref Genel.dbModel, Araclar.Sifreleme.EncryptToString(txtKullaniciAdi.Text));

                //Sisteme Giriş Yetkisi Var Mı?:
                if (!Isler.Yetki.Varmi_Yetki(1))
                {
                    GirisOlumlu = false;
                    return;
                }

                if (Genel.AktifSirket != null && Genel.AktifSirket.EntityState != EntityState.Detached)
                {
                    Genel.dbModel.Detach(Genel.AktifSirket);
                }
                Genel.AktifSirket = null;
                Genel.AktifSirket = Isler.Sirket.Ver_Sirket(ref Genel.dbModel, Convert.ToInt32(lookUpSirketler.EditValue));

                Genel.AktifDepo = Isler.Stok.Ver_Depo(ref Genel.dbModel, 1);

                Genel.Al_Verileri(false);

                //frmAna ana = new frmAna();

                //Genel.AnaEkran = ana;
                //Genel.GirisEkran = this;
                //Genel.SistemeGirisSaat = DateTime.Now;

                GirisOlumlu = true;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Veriler Alınırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            marqueeProgressBarControl1.Visible = false;

            if (!GirisOlumlu)
                return;

            if (Genel.AnaEkran != null)
            {
                Genel.AnaEkran.Dispose();
                Genel.AnaEkran = null;
            }

            frmAna ana = new frmAna();

            Genel.AnaEkran = ana;
            Genel.GirisEkran = this;
            Genel.SistemeGirisSaat = DateTime.Now;
            this.Hide();
            Genel.AnaEkran.Show();

            Isler.Loglar.Ekle_Log(Enumlar.LogTurleri.SistemeGiris, Araclar.Net.SistemIP, Genel.AktifKullanici.KullaniciID, Genel.AktifKullanici.Ad, Genel.AktifKullanici.Soyad);
        }
        #endregion

        #region < Metod >
        void Ac_Ayarlar()
        {
            using (Sistem.frmAyarlar dbAyarlar = new Sistem.frmAyarlar())
            {
                dbAyarlar.GosterilecekSayfalar.Add(Sistem.frmAyarlar.SayfalarEnum.Db);
                dbAyarlar.SeciliSayfa = Sistem.frmAyarlar.SayfalarEnum.Db;
                dbAyarlar.ShowDialog();
            }
        }

        public void Temizle()
        {
            txtKullaniciAdi.Text = txtKullaniciSifre.Text = "";
            lookUpSirketler.EditValue = Sistem.Ayarlar.VarsayilanSirketID;

            txtKullaniciAdi.Focus(); txtKullaniciAdi.Select();
        }
        #endregion
    }
}