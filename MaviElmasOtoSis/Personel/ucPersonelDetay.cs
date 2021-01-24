using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;
using System.IO;
using MaviElmasOtoSis.Araclar;

namespace MaviElmasOtoSis.Personel
{
    public partial class ucPersonelDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        personel per;

        int _Secili_PersonelID;
        bool ResimSilindi = false;

        DataTable dt_AdresIlce;
        DataTable dt_NufIlce;

        public DetayOlayHandler DetayOlay;
        #endregion

        #region < Özellikler >
        public Enumlar.DetayModelari DetayMode
        {
            get
            {
                return _DetayMode;
            }
            set
            {
                _DetayMode = value;
                if (value == Enumlar.DetayModelari.SadeceKaydet)
                {
                    btnKaydet.Visible = true;
                    btnSil.Visible = btnYeniKayit.Visible = false;
                }
                else if (value == Enumlar.DetayModelari.SadeceOku)
                {
                    btnKaydet.Visible = btnSil.Visible = btnYeniKayit.Visible = false;
                }
                else if (value == Enumlar.DetayModelari.Tum)
                {
                    btnKaydet.Visible = btnSil.Visible = btnYeniKayit.Visible = true;
                }
            }
        }
        public int Secili_PersonelID
        {
            get
            {
                return _Secili_PersonelID;
            }
        }
        #endregion

        #region < Load >
        public ucPersonelDetay()
        {
            InitializeComponent();
            if (this.IsInDesignMode) return;

            try
            {
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                #region databind
                Isler.Genelkodlar.Ver_Kod("CalismaSekli", ref lookUpCalismaSekli, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("Cinsiyet", ref lookUpCinsiyet, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("Egitim", ref lookUpEgitimDurum, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("KanGrup", ref lookUpKanGup, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("MedeniHal", ref lookUpMedeniHal, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("Unvan", ref lookUpPersonelUnvan, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("SakatlikTuru", ref lookUpSakatlikTuru, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("NufVerilisNeden", ref lookUpVerilisNeden, "Lütfen Seçiniz");
                //Isler.Genelkodlar.Ver_Kod("Cinsiyet", ref lookUpYakinCinsiyet, "Lütfen Seçiniz");
                //Isler.Genelkodlar.Ver_Kod("Egitim", ref lookUpYakinEgitimDurum, "Lütfen Seçiniz");
                //Isler.Genelkodlar.Ver_Kod("Yakinlik", ref lookUpYakinlik, "Lütfen Seçiniz");
                //Isler.Genelkodlar.Ver_Kod("MedeniHal", ref lookUpYakinMedeniHal, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("AskerlikDurum", ref lookUpAskerlikDurum, "Lütfen Seçiniz");

                lookUpAdresIl.Properties.DisplayMember = "IlAdi";
                lookUpAdresIl.Properties.ValueMember = "Plaka";
                lookUpAdresIl.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Genel.dt_Iller.Copy(), "IlAdi", "Plaka");

                lookUpNufusIl.Properties.DisplayMember = "IlAdi";
                lookUpNufusIl.Properties.ValueMember = "Plaka";
                lookUpNufusIl.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Genel.dt_Iller.Copy(), "IlAdi", "Plaka");

                lookUpCalistigiBirim.Properties.DisplayMember = "BirimAd";
                lookUpCalistigiBirim.Properties.ValueMember = "BirimID";
                lookUpCalistigiBirim.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Isler.Birim.Ver_Birimler(), "BirimAd", "BirimID");
                #endregion

                Temizle_Personel();
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        private void ucPersonelDetay_Load(object sender, EventArgs e)
        {
          
        }
        #endregion

        #region < Olaylar <
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

        private void chkKanGrupRH_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKanGrupRH.Checked)
            {
                chkKanGrupRH.Text = "Pozitif";
            }
            else
            {
                chkKanGrupRH.Text = "Negatif";
            }
        }

        private void lookUpNufusIl_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpNufusIl.EditValue == null) return;

            int editvalue = Convert.ToInt32(lookUpNufusIl.EditValue);

            dt_NufIlce = null;
            dt_NufIlce = Isler.Adres.Ver_Ilce(editvalue);

            lookUpNufusIlce.Properties.DisplayMember = "IlceAdi";
            lookUpNufusIlce.Properties.ValueMember = "IlceID";
            lookUpNufusIlce.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(dt_NufIlce, "IlceAdi", "IlceID");

            lookUpNufusIlce.EditValue = -1;
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

        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    resimPersonel.Image = Image.FromFile(of.FileName);
                    resimPersonel.Tag = of.FileName;
                    ResimSilindi = false;
                }
            }
        }
        private void btnResimSil_Click(object sender, EventArgs e)
        {
            resimPersonel.Image = null;
            resimPersonel.Tag = null;
            ResimSilindi = true;

            if (per.Cinsiyet == "2") //kadınsa
            {
                resimPersonel.Image = ResOtoSis.bayan_fw;
            }
            else //diğer
            {
                resimPersonel.Image = ResOtoSis.adam_fw;
            }
        }
        #endregion

        #region < Metod >
        public void Yukle_Personel(int _PersonelID)
        {
            if (Yukleme) return;
            try
            {
                tabControlPersonel.Cursor = Cursors.WaitCursor;
                Temizle_Personel();
                _YeniKayit = false;

                if (per != null && per.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(per);
                }
                per = null;
                per = Isler.Personel.Ver_Personel(ref dbModel, _PersonelID);
                if (per == null) return;

                txtPersonelAdi.Text = per.Ad;
                txtPersonelSoyadi.Text = per.Soyad;
                txtAnaAdi.Text = per.AnaAdi;
                txtBabaAdi.Text = per.BabaAdi;
                txtTcKimlikNo.Text = per.TcKimlikNo;

                lookUpPersonelUnvan.EditValue = per.Unvan;
                lookUpCinsiyet.EditValue = per.Cinsiyet;
                lookUpCalistigiBirim.EditValue = per.CalistigiBirim;

                txtNufCuzSeri.Text = per.NufCuzSeri;
                if (per.NufCuzNo != null)
                    txtNufCuzSeriNo.Text = per.NufCuzNo.Value.ToString();

                dateDogumTarih.EditValue = per.DogumTarih;
                txtDogumYeri.Text = per.DogumYer;

                if (per.NufCiltNo != null)
                    txtCiltNo.Text = per.NufCiltNo.Value.ToString();

                if (per.NufAileSiraNo != null)
                    txtAileSiraNo.Text = per.NufAileSiraNo.Value.ToString();

                if (per.NufSiraNo != null)
                    txtSiraNo.Text = per.NufSiraNo.Value.ToString();

                txtVerildiğiYer.Text = per.NufVerildigiYer;

                if (!string.IsNullOrEmpty(per.NufVerilisNeden))
                    lookUpVerilisNeden.EditValue = per.NufVerilisNeden;

                if (per.NufCuzKayitNo != null)
                    txtKayitNo.Text = per.NufCuzKayitNo.Value.ToString();

                if (!string.IsNullOrEmpty(per.MedeniHal))
                    lookUpMedeniHal.EditValue = per.MedeniHal;

                if (per.NufIl != null)
                    lookUpNufusIl.EditValue = per.NufIl.Value;

                if (per.NufIlce != null)
                    lookUpNufusIlce.EditValue = per.NufIlce.Value;

                txtMahalle.Text = per.NufMahalle;
                dateVerilisTarih.EditValue = per.NufCuzVerilisTarih;

                if (!string.IsNullOrEmpty(per.KanGrup))
                    lookUpKanGup.EditValue = per.KanGrup;

                if (per.KanGrupRH != null)
                    chkKanGrupRH.Checked = per.KanGrupRH.Value;


                if (per.IstenAyrildi == null)
                {
                    chkIstenAyrildi.Checked = false;
                }
                else
                {
                    chkIstenAyrildi.Checked = per.IstenAyrildi.Value;
                }
                dateIstenAyrilmaTarih.EditValue = per.IstenAyrilmaTarih;

                if (per.CalismaSekli != null)
                    lookUpCalismaSekli.EditValue = per.CalismaSekli;

                dateIseBaslamaTarih.EditValue = per.IlkIseBaslamaTarih;

                if (per.MaasAlir == null)
                {
                    chkMaasALir.Checked = false;
                }
                else
                {
                    chkMaasALir.Checked = per.MaasAlir.Value;
                }
                txtMaasIbanNo.Text = per.MaasIbanNo;

                if (!string.IsNullOrEmpty(per.AskerlikDurum))
                    lookUpAskerlikDurum.EditValue = per.AskerlikDurum;
                dateTerhisTarih.EditValue = per.TerhisTarih;
                dateTecilTarih.EditValue = per.TecilTarih;

                txtEvTel.Text = per.EvTel;
                txtCepTel.Text = per.CepTel;
                txtEposta.Text = per.Eposta;

                if (per.AdresIl != null)
                    lookUpAdresIl.EditValue = per.AdresIl.Value;

                if (per.AdresIlce != null)
                    lookUpAdresIlce.EditValue = per.AdresIlce.Value;

                memoAcikAdres.Text = per.AdresAcik;

                if (!string.IsNullOrEmpty(per.SakatlikTuru))
                    lookUpSakatlikTuru.EditValue = per.SakatlikTuru;
                if (per.SakatlikYuzde != null)
                    spinSakatlikDerecesi.EditValue = per.SakatlikYuzde.Value;

                if (!string.IsNullOrEmpty(per.Egitim))
                    lookUpEgitimDurum.EditValue = per.Egitim;

                _Secili_PersonelID = per.PersonelID;

                YukleResim();

                ucKayitBilgi1.Yukle(per.KayitKullaniciID, per.KayitZaman, per.DuzenKullaniciID, per.DuzenZaman);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Personel Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tabControlPersonel.Cursor = Cursors.Default;
            }
        }

        void Sil()
        {
            if (per == null || !Isler.Yetki.Varmi_Yetki(38)) return;

            try
            {
                if (Isler.Personel.Ver_AdetPersonelHareket(per.PersonelID) > 0)
                {
                    XtraMessageBox.Show("Seçili Personel Hareket Görmüş; Silinemez.", "Geçersiz İşlem",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Seçili Personeli Silmek İstediğinize Emin Misiniz?\n\nPersonel No : " + per.PersonelID.ToString()
                    + "\nPersonel Ad Soyad : " + per.Ad + " " + per.Soyad, "Personel Sil Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    if (!string.IsNullOrEmpty(per.Resim) && File.Exists(Sistem.Ayarlar.DosyaSunucusu + Genel.PersonelResim_Yol + per.Resim))
                    {
                        File.Delete(Sistem.Ayarlar.DosyaSunucusu + Genel.PersonelResim_Yol + per.Resim);
                    }

                    dbModel.DeleteObject(per);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Personel Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    if (DetayOlay != null)
                    {
                        this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                    }
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Personel Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Kaydet()
        {
            if ((_YeniKayit && !Isler.Yetki.Varmi_Yetki(36)) || !_YeniKayit && !Isler.Yetki.Varmi_Yetki(37)) return;

            try
            {
                #region Kontroller
                if (string.IsNullOrEmpty(txtPersonelAdi.Text.Trim()))
                {
                    XtraMessageBox.Show("Personel Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 0;
                    txtPersonelAdi.Focus(); txtPersonelAdi.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtPersonelSoyadi.Text.Trim()))
                {
                    XtraMessageBox.Show("Personel Soyadı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 0;
                    txtPersonelSoyadi.Focus(); txtPersonelSoyadi.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtAnaAdi.Text.Trim()))
                {
                    XtraMessageBox.Show("Ana Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 0;
                    txtAnaAdi.Focus(); txtAnaAdi.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtBabaAdi.Text.Trim()))
                {
                    XtraMessageBox.Show("Baba Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 0;
                    txtBabaAdi.Focus(); txtBabaAdi.Select();
                    return;
                }
                if (!Araclar.Dogrulama.TcDogrula(txtTcKimlikNo.Text.Trim()))
                {
                    XtraMessageBox.Show("Personel TC Kimlik Numarası Geçersiz.", "Geçersiz Değer",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 0;
                    txtTcKimlikNo.Focus(); txtTcKimlikNo.Select();
                    return;
                }
                if (lookUpPersonelUnvan.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Personel Ünvanını Seçiniz.", "Değer Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 0;
                    lookUpPersonelUnvan.Focus(); lookUpPersonelUnvan.Select();
                    return;
                }
                if (lookUpCinsiyet.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Personel Cinsiyetini Seçiniz.", "Değer Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 0;
                    lookUpCinsiyet.Focus(); lookUpCinsiyet.Select();
                    return;
                }
                if (lookUpCalistigiBirim.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Personelin Çalıştığı Birimi Seçiniz.", "Değer Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 0;
                    lookUpCalistigiBirim.Focus(); lookUpCalistigiBirim.Select();
                    return;
                }
                if (_YeniKayit && Isler.Personel.Varmi_TcKimlik(Genel.AktifSirket.SirketID, txtTcKimlikNo.Text))
                {
                    XtraMessageBox.Show("Bu Tc Kimlik Numarası Başka Bir Personel Ait.\nLütfen Farklı Bir TC Kimlik Numarası Giriniz.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 0;
                    txtTcKimlikNo.Focus(); txtTcKimlikNo.Select();
                    return;
                }
                else if (!_YeniKayit && txtTcKimlikNo.Text != per.TcKimlikNo && Isler.Personel.Varmi_TcKimlik(Genel.AktifSirket.SirketID, txtTcKimlikNo.Text, per.TcKimlikNo))
                {
                    XtraMessageBox.Show("Bu Tc Kimlik Numarası Başka Bir Personel Ait.\nLütfen Farklı Bir TC Kimlik Numarası Giriniz.", "Aynı Değer",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 0;
                    txtTcKimlikNo.Focus(); txtTcKimlikNo.Select();
                    return;
                }
                if (lookUpMedeniHal.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Personel Medeni Halini Seçiniz.", "Değer Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 0;
                    lookUpMedeniHal.Focus(); lookUpMedeniHal.Select();
                    return;
                }
                if (lookUpSakatlikTuru.EditValue.ToString() != "-1" && spinSakatlikDerecesi.Value == 0)
                {
                    XtraMessageBox.Show("Personel Sakatlık Türü Seçilmiş Ancak Derecesi Seçilmemiş.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControlPersonel.SelectedTabPageIndex = 4;
                    spinSakatlikDerecesi.Focus(); spinSakatlikDerecesi.Select();
                    return;
                }
                #endregion

                if (_YeniKayit)
                {
                    if (per != null && per.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(per);
                    }
                    per = null;
                    per = new personel();
                    per.SirketID = Genel.AktifSirket.SirketID;
                }

                #region Personel Resmi
                if (ResimSilindi && !string.IsNullOrEmpty(per.Resim))
                {
                    File.Delete(Sistem.Ayarlar.DosyaSunucusu + Genel.PersonelResim_Yol + per.Resim);
                    per.Resim = null;
                }
                else if (resimPersonel.Tag != null && !string.IsNullOrEmpty(per.Resim) && resimPersonel.Tag.ToString() != per.Resim)
                {
                    File.Delete(Sistem.Ayarlar.DosyaSunucusu + Genel.PersonelResim_Yol + per.Resim);
                    per.Resim = (DateTime.Now.Year + DateTime.Now.Millisecond + Mat.Rasgele(10, 100000).ToString()) + ".zip";
                    string hedef = Sistem.Ayarlar.DosyaSunucusu + Genel.PersonelResim_Yol + per.Resim;

                    Araclar.ZipDosya.Ziple(resimPersonel.Tag.ToString(), hedef, true);
                }
                else if (resimPersonel.Tag != null && string.IsNullOrEmpty(per.Resim))
                {
                    per.Resim = (DateTime.Now.Year + DateTime.Now.Millisecond + Mat.Rasgele(10, 100000).ToString()) + ".zip";
                    string hedef = Sistem.Ayarlar.DosyaSunucusu + Genel.PersonelResim_Yol + per.Resim;

                    Araclar.ZipDosya.Ziple(resimPersonel.Tag.ToString(), hedef, true);
                }
                #endregion

                #region Aktarma
                per.Ad = txtPersonelAdi.Text;
                per.Soyad = txtPersonelSoyadi.Text;
                per.AnaAdi = txtAnaAdi.Text;
                per.BabaAdi = txtBabaAdi.Text;
                per.TcKimlikNo = txtTcKimlikNo.Text;
                per.Unvan = lookUpPersonelUnvan.EditValue.ToString();
                per.Cinsiyet = lookUpCinsiyet.EditValue.ToString();
                per.CalistigiBirim = Convert.ToInt32(lookUpCalistigiBirim.EditValue);
                per.NufCuzSeri = txtNufCuzSeri.Text;

                if (string.IsNullOrEmpty(txtNufCuzSeriNo.Text))
                {
                    per.NufCuzNo = null;
                }
                else
                {
                    per.NufCuzNo = Convert.ToInt32(txtNufCuzSeriNo.Text);
                }
                if (dateDogumTarih.EditValue == null)
                {
                    per.DogumTarih = null;
                }
                else
                {
                    per.DogumTarih = Convert.ToDateTime(dateDogumTarih.EditValue);
                }
                per.DogumYer = txtDogumYeri.Text;
                if (string.IsNullOrEmpty(txtCiltNo.Text))
                {
                    per.NufCiltNo = null;
                }
                else
                {
                    per.NufCiltNo = Convert.ToInt32(txtCiltNo.Text);
                }
                if (string.IsNullOrEmpty(txtAileSiraNo.Text))
                {
                    per.NufAileSiraNo = null;
                }
                else
                {
                    per.NufAileSiraNo = Convert.ToInt32(txtAileSiraNo.Text);
                }
                if (string.IsNullOrEmpty(txtSiraNo.Text))
                {
                    per.NufSiraNo = null;
                }
                else
                {
                    per.NufSiraNo = Convert.ToInt32(txtSiraNo.Text);
                }
                per.NufVerildigiYer = txtVerildiğiYer.Text;
                if (lookUpVerilisNeden.EditValue.ToString() == "-1")
                {
                    per.NufVerilisNeden = null;
                }
                else
                {
                    per.NufVerilisNeden = lookUpVerilisNeden.EditValue.ToString();
                }

                if (string.IsNullOrEmpty(txtKayitNo.Text))
                {
                    per.NufCuzKayitNo = null;
                }
                else
                {
                    per.NufCuzKayitNo = Convert.ToInt32(txtKayitNo.Text);
                }
                per.MedeniHal = lookUpMedeniHal.EditValue.ToString();
                if (lookUpNufusIl.EditValue.ToString() == "-1")
                {
                    per.NufIl = null;
                }
                else
                {
                    per.NufIl = Convert.ToInt32(lookUpNufusIl.EditValue);
                }
                if (lookUpNufusIlce.EditValue.ToString() == "-1")
                {
                    per.NufIlce = null;
                }
                else
                {
                    per.NufIlce = Convert.ToInt32(lookUpNufusIlce.EditValue);
                }

                per.NufMahalle = txtMahalle.Text;
                if (dateVerilisTarih.EditValue == null)
                {
                    per.NufCuzVerilisTarih = null;
                }
                else
                {
                    per.NufCuzVerilisTarih = Convert.ToDateTime(dateVerilisTarih.EditValue);
                }
                if (lookUpKanGup.EditValue.ToString() == "-1")
                {
                    per.KanGrup = null;
                }
                else
                {
                    per.KanGrup = lookUpKanGup.EditValue.ToString();
                }

                per.KanGrupRH = chkKanGrupRH.Checked;

                per.IstenAyrildi = chkIstenAyrildi.Checked;
                if (dateIstenAyrilmaTarih.EditValue == null)
                {
                    per.IstenAyrilmaTarih = null;
                }
                else
                {
                    per.IstenAyrilmaTarih = Convert.ToDateTime(dateIstenAyrilmaTarih.EditValue);
                }
                if (lookUpCalismaSekli.EditValue.ToString() == "-1")
                {
                    per.CalismaSekli = null;
                }
                else
                {
                    per.CalismaSekli = lookUpCalismaSekli.EditValue.ToString();
                }
                if (dateIseBaslamaTarih.EditValue == null)
                {
                    per.IlkIseBaslamaTarih = null;
                }
                else
                {
                    per.IlkIseBaslamaTarih = Convert.ToDateTime(dateIseBaslamaTarih.EditValue);
                }
                per.MaasAlir = chkMaasALir.Checked;
                per.MaasIbanNo = txtMaasIbanNo.Text;
                if (lookUpAskerlikDurum.EditValue.ToString() == "-1")
                {
                    per.AskerlikDurum = null;
                }
                else
                {
                    per.AskerlikDurum = lookUpAskerlikDurum.EditValue.ToString();
                }

                if (dateTerhisTarih.EditValue == null)
                {
                    per.TerhisTarih = null;
                }
                else
                {
                    per.TerhisTarih = Convert.ToDateTime(dateTerhisTarih.EditValue);
                }
                if (dateTecilTarih.EditValue == null)
                {
                    per.TecilTarih = null;
                }
                else
                {
                    per.TecilTarih = Convert.ToDateTime(dateTecilTarih.EditValue);
                }

                per.EvTel = txtEvTel.Text;
                per.CepTel = txtCepTel.Text;
                per.Eposta = txtEposta.Text;

                if (lookUpAdresIl.EditValue.ToString() == "-1")
                {
                    per.AdresIl = null;
                }
                else
                {
                    per.AdresIl = Convert.ToInt32(lookUpAdresIl.EditValue);
                }

                if (lookUpAdresIlce.EditValue.ToString() == "-1")
                {
                    per.AdresIlce = null;
                }
                else
                {
                    per.AdresIlce = Convert.ToInt32(lookUpAdresIlce.EditValue);
                }
                per.AdresAcik = memoAcikAdres.Text;

                if (lookUpSakatlikTuru.EditValue.ToString() == "-1")
                {
                    per.SakatlikTuru = null;
                }
                else
                {
                    per.SakatlikTuru = lookUpSakatlikTuru.EditValue.ToString();
                }


                per.SakatlikYuzde = Convert.ToInt32(spinSakatlikDerecesi.Value);
                per.Egitim = lookUpEgitimDurum.EditValue.ToString();
                #endregion

                #region Kayıt
                if (_YeniKayit)
                {
                    per.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    per.KayitZaman = DateTime.Now;
                    dbModel.AddTopersonels(per);
                }
                else
                {
                    per.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    per.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();
                _Secili_PersonelID = per.PersonelID;

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Personel Başarılı Bir Şekilde Kaydedilmiştir.", null,
                    ResOtoSis.mark_blue);

                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.Kaydedildi, null);
                }
                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                }

                Yeni();
                #endregion
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Personel Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Yeni()
        {
            _YeniKayit = true;

            Temizle_Personel();
            tabControlPersonel.SelectedTabPageIndex = 0;

            lookUpCalismaSekli.EditValue = "1";
            txtPersonelAdi.Focus(); txtPersonelAdi.Select();


            if (DetayOlay != null&&this.Visible)
            {
                this.Invoke(DetayOlay, Enumlar.DetayOlaylari.YeniKayit, null);
            }
        }

        void Temizle_Personel()
        {
            txtAileSiraNo.Text = txtAnaAdi.Text = txtBabaAdi.Text = txtCepTel.Text = txtCiltNo.Text
            = txtDahiliTel.Text = txtDogumYeri.Text = txtEposta.Text = txtEvTel.Text = txtKayitNo.Text
            = txtMaasIbanNo.Text = txtMahalle.Text = txtNufCuzSeri.Text = txtNufCuzSeriNo.Text
            = txtPersonelAdi.Text = txtPersonelSoyadi.Text = txtSiraNo.Text = txtTcKimlikNo.Text
            = txtVerildiğiYer.Text = memoAcikAdres.Text = "";

            lookUpAskerlikDurum.EditValue = lookUpCalismaSekli.EditValue = lookUpCinsiyet.EditValue = lookUpEgitimDurum.EditValue
            = lookUpKanGup.EditValue = lookUpMedeniHal.EditValue = lookUpPersonelUnvan.EditValue = lookUpSakatlikTuru.EditValue
            = lookUpVerilisNeden.EditValue = "-1";

            lookUpCalistigiBirim.EditValue = -1;

            lookUpAdresIl.EditValue = lookUpAdresIlce.EditValue = lookUpNufusIl.EditValue = lookUpNufusIlce.EditValue = -1;

            dateDogumTarih.EditValue = dateIseBaslamaTarih.EditValue = dateIstenAyrilmaTarih.EditValue = dateTecilTarih.EditValue = dateTerhisTarih.EditValue
            = dateVerilisTarih.EditValue = null;

            chkIstenAyrildi.Checked = chkKanGrupRH.Checked = false;
            chkMaasALir.Checked = true;

            resimPersonel.Tag = null;
            resimPersonel.Image = null;
        }

        void YukleResim()
        {
            try
            {
                if (string.IsNullOrEmpty(per.Resim))
                {
                    if (per.Cinsiyet == "2") //kadınsa
                    {
                        resimPersonel.Image = ResOtoSis.bayan_fw;
                    }
                    else //diğer
                    {
                        resimPersonel.Image = ResOtoSis.adam_fw;
                    }
                }
                else
                {
                    MemoryStream a = new MemoryStream();
                    Araclar.ZipDosya.Unzip_Stream(Sistem.Ayarlar.DosyaSunucusu + Genel.PersonelResim_Yol + per.Resim, ref a, true);
                    resimPersonel.Image = Image.FromStream(a);
                    ResimSilindi = false;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Personel Resmini Yüklerken Bri Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion      
    }
}