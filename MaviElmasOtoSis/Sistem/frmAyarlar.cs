using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Sistem
{
    public partial class frmAyarlar : Sistem.frmBase
    {
        #region < Değişkenler >
        List<string> Yazicilar;

        bool YenidenBaslatmaGerekliMi = false;
        #endregion

        #region < Özellikler >
        public enum SayfalarEnum
        {
            Db,
            Yazici,
            Genel,
            Hepsi
        }

        public List<SayfalarEnum> GosterilecekSayfalar { get; set; }

        public SayfalarEnum SeciliSayfa { get; set; }
        #endregion

        #region < Load >
        public frmAyarlar()
        {
            GosterilecekSayfalar = new List<SayfalarEnum>();
            SeciliSayfa = new SayfalarEnum();

            InitializeComponent();

            this.Text = "Ayarlar";
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            if (GosterilecekSayfalar.Contains(SayfalarEnum.Db) || GosterilecekSayfalar.Contains(SayfalarEnum.Hepsi))
            {
                if (SeciliSayfa == SayfalarEnum.Db)
                {
                    txtServerAdresi.Focus(); txtServerAdresi.Select();
                    xtraTabControl1.SelectedTabPageIndex = 0;
                }

                pageDb.PageVisible = true;

                txtDosyaSunucusu.Text = Ayarlar.DosyaSunucusu;
                txtServerKullaniciAdi.Text = Ayarlar.ServerKullaniciAdi;
                txtServerKullaniciSifre.Text = Ayarlar.ServerKullaniciSifre;
                txtServerAdresi.Text = Ayarlar.ServerAdres;
                txtVeritabaniAdi.Text = Ayarlar.VeritabaniAdi;
            }
            if (GosterilecekSayfalar.Contains(SayfalarEnum.Yazici) || GosterilecekSayfalar.Contains(SayfalarEnum.Hepsi))
            {
                if (SeciliSayfa == SayfalarEnum.Yazici)
                {
                    xtraTabControl1.SelectedTabPageIndex = 1;
                }

                pageYazici.PageVisible = true;

                Yazicilar = Araclar.Sistem.Yazicilar();

                cmbYazicilarBarkod.Properties.Items.Add("Lütfen Yazıcı Seçin");
                cmbYazicilarA4.Properties.Items.Add("Lütfen Yazıcı Seçin");

                foreach (string item in Yazicilar)
                {
                    cmbYazicilarA4.Properties.Items.Add(item);
                    cmbYazicilarBarkod.Properties.Items.Add(item);
                }

                if (string.IsNullOrEmpty(Ayarlar.YaziciBarkod))
                {
                    cmbYazicilarBarkod.SelectedIndex = 0;
                }
                else
                {
                    cmbYazicilarBarkod.SelectedItem = Ayarlar.YaziciBarkod;
                }

                if (string.IsNullOrEmpty(Ayarlar.YaziciA4))
                {
                    cmbYazicilarA4.SelectedIndex = 0;
                }
                else
                {
                    cmbYazicilarA4.SelectedItem = Ayarlar.YaziciA4;
                }
            }

            if (GosterilecekSayfalar.Contains(SayfalarEnum.Genel) || GosterilecekSayfalar.Contains(SayfalarEnum.Hepsi))
            {
                if (SeciliSayfa == SayfalarEnum.Genel)
                {
                    xtraTabControl1.SelectedTabPageIndex = 2;
                }

                pageGenel.PageVisible = true;

                lookUpSirketler.Properties.DisplayMember = "KisaAd";
                lookUpSirketler.Properties.ValueMember = "SirketID";
                lookUpSirketler.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Isler.Sirket.Ver_Sirketler(true), "KisaAd", "SirketID");
                lookUpSirketler.EditValue = Ayarlar.VarsayilanSirketID;

                //Array degerler = System.Enum.GetValues(typeof(Bilesenler.HavaDurumu.Sehirler));
                //lookUpHavaSehir.Properties.DataSource = degerler;
                //Dictionary<int, Bilesenler.HavaDurumu.Sehirler> dic = new Dictionary<int, Bilesenler.HavaDurumu.Sehirler>();
                //foreach (Bilesenler.HavaDurumu.Sehirler item in degerler)
                //{
                //    dic.Add(Convert.ToInt32(item), item);
                //}
                //lookUpHavaSehir.EditValue = (Bilesenler.HavaDurumu.Sehirler)dic[Convert.ToInt32(Ayarlar.HavaDurumSehir)];

                //cmbHavaDurumYenilenmeZaman.SelectedIndex = Convert.ToInt32(Ayarlar.HavaDurumZaman);
                //cmbPiyasaYenilenmeZaman.SelectedIndex = Convert.ToInt32(Ayarlar.PiyasaZaman);
            }
        }
        #endregion        

        #region < Olaylar >
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                bool AyarlarKaydedilsinin = false;

                if (GosterilecekSayfalar.Contains(SayfalarEnum.Db) || GosterilecekSayfalar.Contains(SayfalarEnum.Hepsi))
                {
                    if (Kontrol() == false)
                    {
                        return;
                    }

                    Ayarlar.ServerKullaniciAdi = txtServerKullaniciAdi.Text;
                    Ayarlar.ServerKullaniciSifre = txtServerKullaniciSifre.Text;
                    Ayarlar.ServerAdres = txtServerAdresi.Text;
                    Ayarlar.VeritabaniAdi = txtVeritabaniAdi.Text;
                    Ayarlar.DosyaSunucusu = txtDosyaSunucusu.Text;
                    AyarlarKaydedilsinin = true;
                    YenidenBaslatmaGerekliMi = true;
                }
                if (GosterilecekSayfalar.Contains(SayfalarEnum.Yazici) || GosterilecekSayfalar.Contains(SayfalarEnum.Hepsi))
                {
                    Ayarlar.YaziciA4 = cmbYazicilarA4.Text;
                    Ayarlar.YaziciBarkod = cmbYazicilarBarkod.Text;
                    AyarlarKaydedilsinin = true;
                }
                if (GosterilecekSayfalar.Contains(SayfalarEnum.Genel) || GosterilecekSayfalar.Contains(SayfalarEnum.Hepsi))
                {
                    //Ayarlar.HavaDurumSehir = Convert.ToInt32(lookUpHavaSehir.EditValue).ToString();
                    //Ayarlar.HavaDurumZaman = cmbHavaDurumYenilenmeZaman.SelectedIndex.ToString();
                    //Ayarlar.PiyasaZaman = cmbPiyasaYenilenmeZaman.SelectedIndex.ToString();
                    Ayarlar.VarsayilanSirketID = Convert.ToInt32(lookUpSirketler.EditValue);
                    if (Ayarlar.VarsayilanSirketID == -1)
                    {
                        Ayarlar.VarsayilanDepoID = -1;
                    }
                    else
                    {
                        Ayarlar.VarsayilanDepoID = Convert.ToInt32(lookUpDepolar.EditValue);
                    }
                    AyarlarKaydedilsinin = true;
                }

                if (AyarlarKaydedilsinin)
                {
                    Ayarlar.Kaydet();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Ayarlar Kaydedilirken Bir Hata Oluştu.\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (YenidenBaslatmaGerekliMi)
            {
                XtraMessageBox.Show("Ayarlar Başarılı Bir Şekilde Kaydedildi.\n\nAyarların Etkili Olabilmesi İçin Program Yeniden Başlatılacak.", "İşlem Başarılı",
             MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Restart();
            }
            else
            {
                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Ayarlar Başarılı Bir Şekilde Kaydedildi.", null,
                    ResOtoSis.mark_blue);

                this.Close();
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBaglantiDene_Click(object sender, EventArgs e)
        {
            if (Kontrol() == false)
            {
                return;
            }

            string Sonuc = Baglanti.Baglanti_Dene(txtServerAdresi.Text, txtVeritabaniAdi.Text,
                txtServerKullaniciAdi.Text, txtServerKullaniciSifre.Text);

            if (Sonuc == "Olumlu")
            {
                XtraMessageBox.Show("Bağlantı Denemesi Başarılı.", "İşlem Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Sonuc == "Olumsuz")
            {
                XtraMessageBox.Show("Bağlantı Denemesi Olumsuz.", "İşlem Başarısız",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                XtraMessageBox.Show("Bağlantı Denemesi Olumsuz.\nHata Mesajı:\n" + Sonuc, "İşlem Başarısız",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region < Metod >
        bool Kontrol()
        {
            #region Kontroller
            if (string.IsNullOrEmpty(txtServerKullaniciAdi.Text.Trim()))
            {
                XtraMessageBox.Show("Sql Server Adresi Boş Bırakılamaz.", "Eksik Alan",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServerKullaniciAdi.Focus(); txtServerKullaniciAdi.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtVeritabaniAdi.Text.Trim()))
            {
                XtraMessageBox.Show("Veritabanı Adı Boş Bırakılamaz.", "Eksik Alan",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVeritabaniAdi.Focus(); txtVeritabaniAdi.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtServerKullaniciAdi.Text.Trim()))
            {
                XtraMessageBox.Show("'Sql Doğrulama' Seçiliyken, Sql Server Kullanıcı Adı Boş Bırakılamaz.", "Eksik Alan",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServerKullaniciAdi.Focus(); txtServerKullaniciAdi.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtServerKullaniciSifre.Text.Trim()))
            {
                XtraMessageBox.Show("'Sql Doğrulama' Seçiliyken, Sql Server Kullanıcı Şifresi Boş Bırakılamaz.", "Eksik Alan",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServerKullaniciSifre.Focus(); txtServerKullaniciSifre.Select();
                return false;
            }

            return true;
            #endregion
        }
        #endregion

        private void btnGozat_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtDosyaSunucusu.Text = fbd.SelectedPath;
                }
            }
        }

        private void lookUpSirketler_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpSirketler.EditValue == null || lookUpSirketler.EditValue.ToString() == "-1")
            {
                lookUpDepolar.Enabled = false;
                lookUpSirketler.EditValue = -1;
            }
            else
            {
                lookUpDepolar.Enabled = true;
                lookUpDepolar.Properties.DisplayMember = "DepoAd";
                lookUpDepolar.Properties.ValueMember = "DepoID";
                lookUpDepolar.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Isler.Stok.Ver_Depolar(false), "DepoAd", "DepoID");

                lookUpDepolar.EditValue = Ayarlar.VarsayilanDepoID;
            }
        }
    }
}