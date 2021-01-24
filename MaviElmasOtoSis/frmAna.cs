using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;

namespace MaviElmasOtoSis
{
    public partial class frmAna : DevExpress.XtraEditors.XtraForm
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        #endregion

        #region < Load >
        public frmAna()
        {
            InitializeComponent();

            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);

            this.Text = "Oto Sanayi Kurumsal";

            MaviElmasWpf.UC_AnalogSaat saa = new MaviElmasWpf.UC_AnalogSaat();
            elementHost1.Child = saa;
        }

        private void frmAna_Load(object sender, EventArgs e)
        {
            ribbon.Minimized = true;


            #region Ayarlar
            Array degerler = System.Enum.GetValues(typeof(Bilesenler.HavaDurumu.Sehirler));
            lookUpHavaSehir.Properties.DataSource = degerler;
            Dictionary<int, Bilesenler.HavaDurumu.Sehirler> dic = new Dictionary<int, Bilesenler.HavaDurumu.Sehirler>();
            foreach (Bilesenler.HavaDurumu.Sehirler item in degerler)
            {
                dic.Add(Convert.ToInt32(item), item);
            }
            lookUpHavaSehir.EditValue = dic[Convert.ToInt32(Sistem.Ayarlar.HavaDurumSehir)];

            havaDurumu1.Yenile();
            piyasaBilgi1.Yenile();
            #endregion

            lblAdSoyad.Text = Genel.AktifKullanici.Ad + " " + Genel.AktifKullanici.Soyad;
            lblGirisSaat.Text = Genel.SistemeGirisSaat.ToString("dd.MM.yyyy HH:mm");
            lblSirket.Text = Genel.AktifSirket.KisaAd;
            lblKullanici.Text = Genel.AktifKullanici.KullaniciAd;

            //havaDurumu1.Yenile();

            //XtraMessageBox.Show(Baglanti.Test_Baglanti().ToString());

            //otosisdbEntities1 model = new otosisdbEntities1();
            //kullanici kul = new kullanici();
            //kul.Ad = "a";
            //kul.Soyad = "a";
            //kul.KullaniciAd = "b";
            //kul.KullaniciSifre = "a";
            //kul.Durum = true;
            //model.AddTokullanicis(kul);
            //model.SaveChanges();

            //            DataTable dt = new DataTable();
            //            using (VeriErisim veri = new VeriErisim())
            //            {
            //                veri.SqlCumlesi = @"SELECT * FROM Adres_Ilce
            //INNER JOIN Adres_Il ON Adres_Il.Plaka=Adres_Ilce.IlPlaka";
            //                //veri.Ekle_Param("@Durum", true, MySql.Data.MySqlClient.MySqlDbType.Bit);
            //                dt = veri.Ver_DataTable();
            //            }

            //dataGridView1.DataSource = dt;

            dbModel = new otosisdbEntities(VeriYonetimi.Baglanti.BaglantiEntity);
        }

        private void frmAna_FormClosed(object sender, FormClosedEventArgs e)
        {
            Isler.Loglar.Ekle_Log(Enumlar.LogTurleri.SistemdenCikis, Araclar.Net.SistemIP, Genel.AktifKullanici.KullaniciID, Genel.AktifKullanici.Ad, Genel.AktifKullanici.Soyad);
            if (!Genel.GirisEkran.Visible)
            {
                //BlueIs.Isler.Loglar.Ekle_Log(BlueIs.Enumlar.LogTurleri.SistemdenCikis, BlueAraclar.Net.SistemIP,
                //    BlueAraclar.Sifreleme.DecryptString(Genel.AktifKullanici.KullaniciAd), false, DateTime.Now);
                Application.Exit();
            }
        }
        #endregion

        #region < Olaylar >
        private void tabAna_CloseButtonClick(object sender, EventArgs e)
        {
            if ((e as ClosePageButtonEventArgs).Page == pageAnaSayfa) return;
            tabAna.TabPages.Remove((e as ClosePageButtonEventArgs).Page as XtraTabPage);

            foreach (Control item in ((XtraTabPage)(e as ClosePageButtonEventArgs).Page).Controls)
            {
                //( (Sistem.ucBase)item).dis
                item.Dispose();
                //item = null;
            }
            //((XtraTabPage)(e as ClosePageButtonEventArgs).Page).Controls = null;

            //if (tabAna.TabPages.Count == 0)
            //{
            //    panel1.BringToFront();
            //}
        }

        private void btnMarkaModel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Ac_Sayfa(new Tanim.ucMarkaModel(), "Marka ve Model Tanımlamaları");
        }

        private void btnGenelTanimlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Tanim.frmGenelkodlar gene = new Tanim.frmGenelkodlar())
            {
                gene.Gruplar.Add("StokBirim");
                gene.Gruplar.Add("StokGrup");
                gene.Gruplar.Add("StokHareketTipi");
                gene.Gruplar.Add("CariHesapGrup");
                gene.Gruplar.Add("GelirGiderGrup");
                gene.Gruplar.Add("Renk");
                gene.ShowDialog();
            }
        }

        private void btnStokKart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(5))
            {
                return;
            }
            Ac_Sayfa(new Stok.ucStokKart(), "Stok Kartları");
        }

        private void btnYaziciAyarlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Sistem.frmAyarlar YaziciAyarlar = new Sistem.frmAyarlar())
            {
                YaziciAyarlar.GosterilecekSayfalar.Add(Sistem.frmAyarlar.SayfalarEnum.Yazici);
                YaziciAyarlar.SeciliSayfa = Sistem.frmAyarlar.SayfalarEnum.Yazici;

                YaziciAyarlar.ShowDialog();
            }
            //GC.Collect();
        }
        private void btnDbAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Sistem.frmAyarlar YaziciAyarlar = new Sistem.frmAyarlar())
            {
                YaziciAyarlar.GosterilecekSayfalar.Add(Sistem.frmAyarlar.SayfalarEnum.Db);
                YaziciAyarlar.SeciliSayfa = Sistem.frmAyarlar.SayfalarEnum.Db;

                YaziciAyarlar.ShowDialog();
            }
            //GC.Collect();
        }

        private void btnGenelAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Sistem.frmAyarlar GenelAyarlar = new Sistem.frmAyarlar())
            {
                GenelAyarlar.GosterilecekSayfalar.Add(Sistem.frmAyarlar.SayfalarEnum.Genel);
                GenelAyarlar.SeciliSayfa = Sistem.frmAyarlar.SayfalarEnum.Genel;

                GenelAyarlar.ShowDialog();
                //HavaDurumZaman_Ayarla();
                //PiyasaZaman_Ayarla();
            }
            //GC.Collect();
        }

        private void btnKullaniciYetkileri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(29))
                return;
            using (Sistem.frmKullaniciYetki yetkii = new Sistem.frmKullaniciYetki())
            {
                yetkii.ShowDialog();
            }
            //GC.Collect();
        }

        private void btnKullanicilar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(9))
                return;
            Ac_Sayfa(new Kullanici.ucKullanici(), "Sistem Kullanıcıları");
        }

        private void btnCariHesaplar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Ac_Sayfa(new Muhasebe.ucCariHesap(), "Cari Hesaplar");
        }

        private void btnStokHareketleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(15))
                return;

            Ac_Sayfa(new Stok.ucStokHareket(), "Stok Hareketleri");
        }

        private void btnSirketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(16))
                return;

            Ac_Sayfa(new Tanim.ucSirket(), "Şirketler");
        }

        private void btnDepolar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(20))
                return;

            Ac_Sayfa(new Stok.ucStokDepo(), "Depolar");
        }

        private void btnStokTahsisi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(24)) return;

            using (Stok.frmStokTahsisi stokTahsisi = new Stok.frmStokTahsisi())
            {
                stokTahsisi.ShowDialog();
            }
        }
        private void btnCokluStokTahsisi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(24)) return;

            using (Stok.frmCokluStokTahsis CoklustokTahsisi = new Stok.frmCokluStokTahsis())
            {
                CoklustokTahsisi.ShowDialog();
            }

        }

        private void btnIscilikler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(25))
                return;

            Ac_Sayfa(new Tanim.ucIscilik(), "İşçilik Tanımları");
        }

        private void btnAraclar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(31))
                return;

            Ac_Sayfa(new AracKabul.ucArac(), "Araçlar");
        }
        #endregion

        #region < Metod >
        void Ac_Sayfa(XtraUserControl Veri, string Baslik)
        {
            XtraTabPage yeni_sayfa = new XtraTabPage();
            //yeni_sayfa.Disposed += new EventHandler(Veri_Disposed);

            yeni_sayfa.Text = Baslik;
            Veri.Dock = DockStyle.Fill;
            yeni_sayfa.Controls.Add(Veri);
            Veri.Disposed += new EventHandler(Veri_Disposed);

            tabAna.TabPages.Add(yeni_sayfa);
            tabAna.SelectedTabPage = yeni_sayfa;

            //panel1.SendToBack();
        }

        void Veri_Disposed(object sender, EventArgs e)
        {
            GC.Collect();
        }

        void AppendTextBox(string value, LabelControl t)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, LabelControl>(AppendTextBox), new object[] { value, t });
                return;
            }

            t.Text = value;
        }
        void AppendTextBox(string value, TextEdit t)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, TextEdit>(AppendTextBox), new object[] { value, t });
                return;
            }

            t.Text = value;
        }
        void AppendPictureBox(Image value, PictureBox t)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<Image, PictureBox>(AppendPictureBox), new object[] { value, t });
                return;
            }

            t.Image = value;
        }
        #endregion

        private void bntPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(35))
                return;
            Ac_Sayfa(new Personel.ucPersonel(), "Personeller");
        }

        private void btnAracKabul_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Ac_Sayfa(new AracKabul.ucServisDetay(), "İş Emri");
            if (!Isler.Yetki.Varmi_Yetki(42))
                return;
            Ac_Sayfa(new AracKabul.ucServis(), "Servisler/İşemirleri");
        }

        private void btnSatisFatura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(55)) return;

            Muhasebe.ucFatura SatisFatura = new Muhasebe.ucFatura();
            SatisFatura.FaturaTipi = Enumlar.FaturaTipleri.SatisFaturasi;
            Ac_Sayfa(SatisFatura, "Satış Faturası");
        }
        private void btnAlisFatura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(59)) return;

            Muhasebe.ucFatura AlisFatura = new Muhasebe.ucFatura();
            AlisFatura.FaturaTipi = Enumlar.FaturaTipleri.AlisFaturasi;
            Ac_Sayfa(AlisFatura, "Aliş Faturası");
        }
        private void btnFaturasizSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(63)) return;

            Muhasebe.ucFatura FaturasizSatis = new Muhasebe.ucFatura();
            FaturasizSatis.FaturaTipi = Enumlar.FaturaTipleri.FaturasizSatis;
            Ac_Sayfa(FaturasizSatis, "Faturasiz Satış");
        }
        private void btnFaturasizAlis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(67)) return;

            Muhasebe.ucFatura FaturasizAlis = new Muhasebe.ucFatura();
            FaturasizAlis.FaturaTipi = Enumlar.FaturaTipleri.FaturasizAlis;
            Ac_Sayfa(FaturasizAlis, "Faturasiz Alış");
        }

        private void tabAna_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabAna.SelectedTabPage != null && tabAna.SelectedTabPage != pageAnaSayfa && (e.KeyCode == Keys.Control | e.KeyCode == Keys.W))
            {
                tabAna.SelectedTabPage.Dispose();

                if (tabAna.TabPages.Count > 1)
                {
                    tabAna.SelectedTabPageIndex = tabAna.TabPages.Count - 1;
                }
            }
        }

        private void btnGelirGiderTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(43))
                return;
            Ac_Sayfa(new Muhasebe.ucGelirGider(), "Gelir ve Gider Kalemleri");
        }

        private void btnKasalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(47))
                return;
            Ac_Sayfa(new Muhasebe.ucKasaDetay(), "Kasa");
            //Ac_Sayfa(new Muhasebe.ucKasa(), "Kasalar");
            //Muhasebe.frmKasaHareket ha = new Muhasebe.frmKasaHareket();
            //ha.ShowDialog();
        }

        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(51))
            {
                return;
            }
            Ac_Sayfa(new Muhasebe.ucBanka(), "Bankalar");
        }

        private void havaDurumu1_Guncellendi(object sender, string Sonuc)
        {
            AppendTextBox(havaDurumu1.Derece.ToString() + "°", lblHavaDerece);
            AppendTextBox(havaDurumu1.Durum, lblHavaDurumu);
            AppendTextBox("% " + havaDurumu1.Nem.ToString(), lblHavaNem);
            AppendPictureBox(havaDurumu1.HavaResim, HavaResim);
        }

        private void lookUpHavaSehir_EditValueChanged(object sender, EventArgs e)
        {
            havaDurumu1.Sehir = (Bilesenler.HavaDurumu.Sehirler)lookUpHavaSehir.EditValue;

            Sistem.Ayarlar.HavaDurumSehir = ((int)havaDurumu1.Sehir).ToString();
            Sistem.Ayarlar.Kaydet();

            havaDurumu1.Yenile();
        }

        private void resimHavaDurumYenile_Click(object sender, EventArgs e)
        {
            havaDurumu1.Yenile();
        }
        private void resimPiyasaYenile_Click(object sender, EventArgs e)
        {
            piyasaBilgi1.Yenile();
        }

        private void piyasaBilgi1_Guncellendi(object sender, string Sonuc)
        {
            AppendTextBox(Math.Round(piyasaBilgi1.AltinSatis, 2).ToString(), lblAltin);
            AppendTextBox(piyasaBilgi1.DolarSatis.ToString(), lblDolar);
            AppendTextBox(piyasaBilgi1.EuroSatis.ToString(), lblEuro);
            AppendTextBox("Güncel : " + piyasaBilgi1.GuncellemeTarih.ToString("dd.MM.yyyy HH:mm"), lblGuncellemeZamani);
        }

        private void btnKullaniciDegistir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Kullanıcınızı Değiştirmek İstediğinize Emin Misiniz?\n\nÖnemli Uyarı:\nTüm açık penceler kapatılacaktır.\nTüm işlemlerinizi kaydettiğinize emin olun.", "Kullanıcı Değiştirme Onay",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            //BlueIs.Isler.Loglar.Ekle_Log(BlueIs.Enumlar.LogTurleri.SistemdenCikis, BlueAraclar.Net.SistemIP,
            //       BlueAraclar.Sifreleme.DecryptString(Genel.AktifKullanici.KullaniciAd), false, DateTime.Now);

            //Genel.GirisEkran.Temizle();
            Genel.GirisEkran.Show();
            Genel.GirisEkran.Temizle();
            this.Close();

            //frmAna yeniAna = new frmAna();
            //Genel.AnaEkran = yeniAna;
        }

        private void btnBilgilerimiDegistir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (Kullanici.frmKullaniciGiris kulGiris = new Kullanici.frmKullaniciGiris())
            {
                kulGiris.ShowDialog();
            }
        }

        private void btnKdvTevfikati_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //using (Muhasebe.frmKdvTevfikat tev = new Muhasebe.frmKdvTevfikat())
            //{
            //    tev.ShowDialog();
            //}

            using (Tanim.frmGenelkodlar gene = new Tanim.frmGenelkodlar())
            {
                gene.Gruplar.Add("CariHesapGrup");
                gene.ShowDialog();
            }
        }

        private void btnBirimler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(74)) return;

            Ac_Sayfa(new Tanim.ucBirim(), "Birimler");
        }

        private void btnHakkimizda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Form1 frm1 = new Form1();
            //frm1.ShowDialog();
        }

        private void btnStokSayim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Isler.Yetki.Varmi_Yetki(79)) return;

            Ac_Sayfa(new Stok.ucSayim(), "Stok Sayımları");
        }

        private void tm_deneme_Tick(object sender, EventArgs e)
        {
            try
            {
                tm_deneme.Enabled = false;
                kasa ks = Isler.Kasa.Ver_Kasa(ref dbModel, 2);
                if (ks != null)
                {
                    dbModel.Detach(ks);
                }

                using (DataTable dt_kasa = Isler.Kasa.Ver_Kasalar())
                {

                }
            }
            catch { }
            finally
            {
                tm_deneme.Enabled = true;
            }
        }
    }
}