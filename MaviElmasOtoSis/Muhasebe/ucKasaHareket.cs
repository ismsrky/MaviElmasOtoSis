using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class ucKasaHareket : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        kasa_hareket kh;

        int Secili_KasaHareketID;

        Enumlar.IslemTurleri _IslemTuru;

        DataTable dt_KasaHareketler;
        #endregion

        #region < Özellikler >
        public int KasaID { get; set; }
        #endregion

        #region < Load >
        public ucKasaHareket()
        {
            InitializeComponent();
        }

        private void ucKasaHareket_Load(object sender, EventArgs e)
        {
            if (this.IsInDesignMode) return;
            try
            {
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                dateKayitBas.EditValue = Araclar.TarihSaat.Ver_AyinBasi(DateTime.Now);
                dateKayitBit.EditValue = DateTime.Now;

                ucCariHesapDemo1.Temizle_Cari();
                ucBankaDemo1.Temizle_Banka();
                ucGelirGiderDemo1.Temizle_GelirGider();

                ucKasaDemo1.groupMarkaBilgileri.Text = "Virman Yapılan Kasa";

                gridViewKasaHareket.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
                gridViewKasaHareket.OptionsView.ColumnAutoWidth = false;

                gridControlKasaHareket.ForceInitialize();
                gridViewKasaHareket.BestFitColumns();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kasa Hareketi Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region < Olaylar >
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }
        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            Yeni();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }

        private void drpIslemTuru_Click(object sender, EventArgs e)
        {
            drpIslemTuru.ContextMenuStrip.Show(drpIslemTuru, new Point(0, 23));
        }

        private void btnKasaTahsilatFisi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.KasaTahsilatFisi);
        }
        private void btnKasaOdemeFisi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.KasaOdemeFisi);
        }
        private void btnKasaAcilisFisiBorclu_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.KasaAcilisFisiBorclu);
        }
        private void btnKasaAcilisFisiAlacakli_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.KasaAcilisFisiAlacakli);
        }
        private void btnKasaVirman_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.KasaVirmani);
        }
        private void btnCariTahsilatFisi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.CariTahsilatFisi);
        }
        private void btnCariOdemeFisi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.CariOdemeFisi);
        }
        private void btnBankayaYatirilan_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.BankayaYatirilan);
        }
        private void btnBankadanCekilen_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.BankadanCekilen);
        }
        private void btnPersonelMaasOdemesi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.PersonelMaasOdemesi);
        }
        private void btnPersonelAvansOdemesi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.PersonelAvansOdemesi);
        }
        private void btnPersonelAgiOdemesi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem((int)Enumlar.IslemTurleri.PersonelAgiOdemesi);
        }

        private void gridViewKasaHareket_Click(object sender, EventArgs e)
        {
            if (gridViewKasaHareket.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_KasaHarket();
            }
            _Focusta = false;
        }
        private void gridViewKasaHareket_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            _Focusta = true;
            Focus_KasaHarket();
        }
        #endregion

        #region < Metod >
        void Yukle_KasaHareket(int _ID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_KasaHareket();

                if (kh != null && kh.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(kh);
                }
                kh = null;
                kh = Isler.Kasa.Ver_KasaHareket(ref dbModel, _ID);
                if (kh == null) return;

                Secili_KasaHareketID = kh.ID;
                txtEvrakNo.Text = kh.EvrakNo;
                lblHareketNo.Text = kh.ID.ToString();
                Ayarla_Islem(Convert.ToInt32(kh.KasaIslemTuru));
                memoAciklama.Text = kh.Aciklama;
                spinMiktar.Value = kh.Miktar;
                dateEvrakTarih.EditValue = kh.EvrakTarih;

                if (kh.GelirGiderID != null)
                {
                    ucGelirGiderDemo1.Yukle_GelirGider(kh.GelirGiderID.Value);
                }

                if (kh.BankaID != null)
                {
                    ucBankaDemo1.Yukle_Banka(kh.BankaID.Value);
                }

                if (kh.CariID != null)
                {
                    ucCariHesapDemo1.Yukle_Cari(kh.CariID.Value);
                }

                if (kh.VirmanKasaID != null)
                {
                    ucKasaDemo1.Yukle_Kasa(kh.VirmanKasaID.Value);
                }
                if (kh.PersonelID != null)
                {
                    ucPersonelDemo1.Yukle_Personel(kh.PersonelID.Value);
                }
                if (kh.AracID != null)
                {
                    ucAracDemo1.Yukle_Arac(kh.AracID.Value);
                }

                //if (kh.KasaIslemTuru == "6" || kh.KasaIslemTuru == "7")
                //{
                //    var hari = (from abc in dbModel.kasa_hareket
                //                where abc.IlgiliID == kh.ID
                //                select new
                //                {
                //                    abc.Miktar,
                //                    abc.GelirGiderID
                //                }).SingleOrDefault();

                //    if (hari != null)
                //    {
                //        spinGiderMiktar.Value = hari.Miktar;
                //        ucGelirGiderDemo1.Yukle_GelirGider(hari.GelirGiderID.Value);
                //    }
                //}

                ucKayitBilgi1.Yukle(kh.KayitKullaniciID, kh.KayitZaman);

                btnKaydet.Enabled = false;
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        public void Ara_KasaHareketleri(int _KasaID)
        {
            try
            {
                _Yukleme = true;

                if (dt_KasaHareketler != null)
                    dt_KasaHareketler.Dispose();
                dt_KasaHareketler = null;

                KasaID = _KasaID;
                dt_KasaHareketler = Isler.Kasa.Ver_KasaHareketleri(_KasaID,Convert.ToDateTime(dateKayitBas.EditValue),Convert.ToDateTime(dateKayitBit.EditValue));
                gridControlKasaHareket.DataSource = dt_KasaHareketler;

                gridViewKasaHareket.ViewCaption = "Kasa Hareket Listesi (" + dt_KasaHareketler.Rows.Count.ToString() + ")";

                bool Bulundu = false;
                if (dt_KasaHareketler.Rows.Count > 0)
                {
                    int temp_ID = 0;
                    for (int i = 0; i < gridViewKasaHareket.RowCount; i++)
                    {
                        temp_ID = Convert.ToInt32(gridViewKasaHareket.GetDataRow(i)["ID"]);
                        if (temp_ID == Secili_KasaHareketID)
                        {
                            gridViewKasaHareket.FocusedRowHandle = i;
                            Bulundu = true;
                            break;
                        }
                    }

                    _Yukleme = false;
                    if (!Bulundu)
                    {
                        object o = gridViewKasaHareket.GetDataRow(0)["ID"];
                        Yukle_KasaHareket(Convert.ToInt32(gridViewKasaHareket.GetDataRow(0)["ID"]));
                    }

                    btnSil.Enabled = true;
                }
                else
                {
                    btnSil.Enabled = false;
                    Yeni();
                }
            }
            catch (Exception hata)
            {

                throw;
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Ayarla_Islem(int IslemTuru)
        {
            if (IslemTuru == 0)
            {
                drpIslemTuru.Tag = null;
                drpIslemTuru.Text = "Lütfen Seçiniz";

                ucGelirGiderDemo1.Visible = ucBankaDemo1.Visible = ucCariHesapDemo1.Visible = ucKasaDemo1.Visible = ucAracDemo1.Visible = false;
                return;
            }
            else
            {
                drpIslemTuru.Tag = IslemTuru;
            }

            switch (IslemTuru)
            {
                case 1:
                    drpIslemTuru.Text = "Kasa Tahsilat Fişi";
                    ucGelirGiderDemo1.Gelir = true;
                    break;
                case 2:
                    drpIslemTuru.Text = "Kasa Ödeme Fişi";
                    ucGelirGiderDemo1.Gelir = false;
                    break;
                case 3:
                    drpIslemTuru.Text = "Kasa Virmanı";
                    break;
                case 4:
                    drpIslemTuru.Text = "Kasa Açılış Fişi Borçlu";
                    break;
                case 5:
                    drpIslemTuru.Text = "Kasa Açılış Fişi Alacaklı";
                    break;
                case 6:
                    drpIslemTuru.Text = "Bankaya Yatırılan";
                    break;
                case 7:
                    drpIslemTuru.Text = "Bankadan Çekilen";
                    break;
                case 8:
                    drpIslemTuru.Text = "Cari Tahsilat Fişi";
                    break;
                case 9:
                    drpIslemTuru.Text = "Cari Ödeme Fişi";
                    break;
                case 18:
                    drpIslemTuru.Text = "Personel Maaş Ödemesi";
                    break;
                case 19:
                    drpIslemTuru.Text = "Personel Avans Ödemesi";
                    break;
                case 20:
                    drpIslemTuru.Text = "Personel AGİ Ödemesi";
                    break;
            }

            if (IslemTuru == 1 || IslemTuru == 2)
            {
                ucGelirGiderDemo1.Visible =ucAracDemo1.Visible= true;
                ucPersonelDemo1.Visible = ucKasaDemo1.Visible = ucBankaDemo1.Visible = ucCariHesapDemo1.Visible = false;
            }
            else if (IslemTuru == 4 || IslemTuru == 5)
            {
                ucPersonelDemo1.Visible = ucKasaDemo1.Visible = ucGelirGiderDemo1.Visible = ucBankaDemo1.Visible = ucCariHesapDemo1.Visible
                = ucAracDemo1.Visible = false;
            }
            else if (IslemTuru == 3)
            {
                ucKasaDemo1.Visible = true;
                ucPersonelDemo1.Visible = ucGelirGiderDemo1.Visible = ucBankaDemo1.Visible = ucCariHesapDemo1.Visible = ucAracDemo1.Visible = false;

                ucKasaDemo1.Location = ucGelirGiderDemo1.Location;
            }
            else if (IslemTuru == 6 || IslemTuru == 7)
            {
                ucBankaDemo1.Visible = true;
                ucPersonelDemo1.Visible = ucKasaDemo1.Visible = ucCariHesapDemo1.Visible = ucGelirGiderDemo1.Visible = ucAracDemo1.Visible = false;
                ucBankaDemo1.Location = ucGelirGiderDemo1.Location;
            }
            else if (IslemTuru == 8 || IslemTuru == 9)
            {
                ucCariHesapDemo1.Visible = true;
                ucPersonelDemo1.Visible = ucKasaDemo1.Visible = ucBankaDemo1.Visible = ucGelirGiderDemo1.Visible = ucAracDemo1.Visible = false;

                ucCariHesapDemo1.Location = ucGelirGiderDemo1.Location;
            }
            else if (IslemTuru == 18 || IslemTuru == 19 || IslemTuru == 20)
            {
                ucPersonelDemo1.Visible = true;
                ucBankaDemo1.Visible = ucKasaDemo1.Visible = ucCariHesapDemo1.Visible = ucGelirGiderDemo1.Visible = ucAracDemo1.Visible = false;

                ucPersonelDemo1.Location = ucGelirGiderDemo1.Location;
            }
        }

        void Yeni()
        {
            Temizle_KasaHareket();
            spinMiktar.Focus(); spinMiktar.Select();

            Ayarla_Islem(0);

            btnKaydet.Enabled = true;
        }
        void Kaydet()
        {
            try
            {
                if (!Isler.Yetki.Varmi_Yetki(75)) return;

                #region Kontroller
                if (spinMiktar.Value <= 0)
                {
                    XtraMessageBox.Show("Miktar Boş 0'dan Büyük Bir Değer Olmalıdır.", "Geçersiz Miktar",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    spinMiktar.Focus(); spinMiktar.Select();
                    return;
                }
                if (drpIslemTuru.Tag == null)
                {
                    XtraMessageBox.Show("Lütfen İşlem Türünü Seçiniz.", "İşlem Türü Seçilmedi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    drpIslemTuru.Focus(); drpIslemTuru.Select();
                    return;
                }

                int t_islemturu = Convert.ToInt32(drpIslemTuru.Tag);

                if ((t_islemturu == 1 || t_islemturu == 2) && ucGelirGiderDemo1.Secili_GelirGiderID <= 0)
                {
                    XtraMessageBox.Show("Lütfen İşlem Yapılacak Geliri/Gideri Seçiniz.", "Gelir/Gider Seçilmedi",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucGelirGiderDemo1.Focus(); ucGelirGiderDemo1.Select();
                    return;
                }
                else if ((t_islemturu == 6 || t_islemturu == 7) && ucBankaDemo1.Secili_BankaID <= 0)
                {
                    XtraMessageBox.Show("Lütfen İşlem Yapılacak Bankayı Seçiniz.", "Banka Seçilmedi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucBankaDemo1.Focus(); ucBankaDemo1.Select();
                    return;
                }
                else if ((t_islemturu == 8 || t_islemturu == 9) && ucCariHesapDemo1.Secili_CariID <= 0)
                {
                    XtraMessageBox.Show("Lütfen İşlem Yapılacak Cariyi Seçiniz.", "Cari Seçilmedi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucCariHesapDemo1.Focus(); ucCariHesapDemo1.Select();
                    return;
                }
                else if (t_islemturu == 3 && ucKasaDemo1.Secili_KasaID <= 0)
                {
                    XtraMessageBox.Show("Lütfen Virman Yapılacak Kasayı Seçiniz.", "Kasa Seçilmedi",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucKasaDemo1.Focus(); ucKasaDemo1.Select();
                    return;
                }

                if (ucPersonelDemo1.Secili_PersonelID <= 0 && ((t_islemturu == 18 || t_islemturu == 19 || t_islemturu == 20)))
                {
                    XtraMessageBox.Show("Lütfen Ödeme Yapılacak Personeli Seçiniz.", "Personel Seçilmedi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucPersonelDemo1.Focus(); ucPersonelDemo1.Select();
                    return;
                }

                //if ((t_islemturu == 6 || t_islemturu == 7) && ucGelirGiderDemo1.Secili_GelirGiderID > 0 && spinGiderMiktar.Value <= 0)
                //{
                //    XtraMessageBox.Show("Lütfen Gider Miktarını Giriniz veya Gider Seçmeyiniz.", "Eksik Alan",
                //             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    spinGiderMiktar.Focus(); spinGiderMiktar.Select();
                //    return;
                //}
                //else if ((t_islemturu == 6 || t_islemturu == 7) && spinGiderMiktar.Value > 0 && ucGelirGiderDemo1.Secili_GelirGiderID <= 0)
                //{
                //    XtraMessageBox.Show("Lütfen Gider Kalemini Seçiniz veya Gider Miktarı Girmeyiniz.", "Gider Seçilmedi",
                //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    spinGiderMiktar.Focus(); spinGiderMiktar.Select();
                //    return;
                //}
                #endregion

                if (kh != null && kh.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(kh);
                }
                kh = null;
                kh = new kasa_hareket();
                kh.KasaID = KasaID;

                #region Aktarma
                DateTime? temp_EvrakTarih = null;
                if (dateEvrakTarih.EditValue != null)
                {
                    temp_EvrakTarih = Convert.ToDateTime(dateEvrakTarih.EditValue);
                }
                kh.Miktar = spinMiktar.Value;
                kh.KasaIslemTuru = drpIslemTuru.Tag.ToString();
                kh.EvrakNo = txtEvrakNo.Text;
                kh.EvrakTarih = temp_EvrakTarih;
                kh.Aciklama = memoAciklama.Text;

                if (t_islemturu == 1 || t_islemturu == 4 || t_islemturu == 7 || t_islemturu == 8)
                {
                    kh.Tahsilat = true;
                }
                else if (t_islemturu == 2 || t_islemturu == 5 || t_islemturu == 6 || t_islemturu == 9 || t_islemturu == 3 || t_islemturu == 18 || t_islemturu == 19 || t_islemturu == 20)
                {
                    kh.Tahsilat = false;
                }

                if (t_islemturu == 1 || t_islemturu == 2)
                {
                    kh.GelirGiderID = ucGelirGiderDemo1.Secili_GelirGiderID;
                    if (ucAracDemo1.Secili_AracID > 0)
                    {
                        kh.AracID = ucAracDemo1.Secili_AracID;
                    }
                }
                if (t_islemturu == 6 || t_islemturu == 7)
                {
                    kh.BankaID = ucBankaDemo1.Secili_BankaID;
                }
                if (t_islemturu == 8 || t_islemturu == 9)
                {
                    kh.CariID = ucCariHesapDemo1.Secili_CariID;
                }

                if (t_islemturu == 3)
                {
                    kh.VirmanKasaID = ucKasaDemo1.Secili_KasaID;
                }
                if (t_islemturu == 18 || t_islemturu == 19 || t_islemturu == 20)
                {
                    kh.PersonelID = ucPersonelDemo1.Secili_PersonelID;
                }
                #endregion

                #region Kayıt
                int? t_KasaHareketID = null;
                int? t_BankaHareketID = null;

                kh.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                kh.KayitZaman = DateTime.Now;
                dbModel.AddTokasa_hareket(kh);

                dbModel.SaveChanges();
                Secili_KasaHareketID = kh.ID;
                lblHareketNo.Text = Secili_KasaHareketID.ToString();

                #region < Diğer Kayıt İşlemleri >
                if (t_islemturu == 3)
                {
                    t_KasaHareketID = Isler.Kasa.Ekle_KasaHareket(ucKasaDemo1.Secili_KasaID, spinMiktar.Value, true, Enumlar.IslemTurleri.KasaVirmani,
                               null, null, null,null, KasaID, txtEvrakNo.Text, memoAciklama.Text, temp_EvrakTarih, Secili_KasaHareketID);
                }
                #endregion

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Kasa İşlemi Başarılı Bir Şekilde Kaydedilmiştir.", null,
                  ResOtoSis.mark_blue);

                btnKaydet.Enabled = false;

                Ara_KasaHareketleri(KasaID);
                #endregion

                #region Diğer
                
                if (t_islemturu == 1) //kasa tahsil fişi
                {
                    Isler.GelirGider.Ekle_GelirGiderHareket(ucGelirGiderDemo1.Secili_GelirGiderID, spinMiktar.Value, false,
                        Enumlar.IslemTurleri.KasaTahsilatFisi, null, KasaID, txtEvrakNo.Text, memoAciklama.Text, temp_EvrakTarih,
                        null, Secili_KasaHareketID);
                }
                else if (t_islemturu == 2) //kasa ödeme fişi
                {
                    Isler.GelirGider.Ekle_GelirGiderHareket(ucGelirGiderDemo1.Secili_GelirGiderID, spinMiktar.Value, true,
                          Enumlar.IslemTurleri.KasaOdemeFisi, null, KasaID, txtEvrakNo.Text, memoAciklama.Text, temp_EvrakTarih,
                          null, Secili_KasaHareketID);
                }
                else if (t_islemturu == 8) //cari tahsilat fişi
                {
                    Isler.Cari.Ekle_CariHareket(ucCariHesapDemo1.Secili_CariID, spinMiktar.Value, false,
                        Enumlar.IslemTurleri.CariTahsilatFisi, null, null, KasaID, txtEvrakNo.Text, memoAciklama.Text, temp_EvrakTarih,
                        null, Secili_KasaHareketID);
                }
                else if (t_islemturu == 9)//cari ödeme fişi
                {
                    Isler.Cari.Ekle_CariHareket(ucCariHesapDemo1.Secili_CariID, spinMiktar.Value, true,
                          Enumlar.IslemTurleri.CariOdemeFisi, null, null, KasaID, txtEvrakNo.Text, memoAciklama.Text, temp_EvrakTarih,
                          null, Secili_KasaHareketID);
                }
                else if (t_islemturu == 6) //bankaya yatırılan
                {
                    t_BankaHareketID = Isler.Banka.Ekle_BankaHareket(ucBankaDemo1.Secili_BankaID, spinMiktar.Value, true,
                            Enumlar.IslemTurleri.BankayaYatirilan, null, null, null, null, KasaID, txtEvrakNo.Text, memoAciklama.Text, temp_EvrakTarih,
                            Secili_KasaHareketID);
                }
                else if (t_islemturu == 7) //bankadan çekilen
                {
                    t_BankaHareketID = Isler.Banka.Ekle_BankaHareket(ucBankaDemo1.Secili_BankaID, spinMiktar.Value, false,
                              Enumlar.IslemTurleri.BankadanCekilen, null, null, null, null, KasaID, txtEvrakNo.Text, memoAciklama.Text, temp_EvrakTarih,
                              Secili_KasaHareketID);
                }
                else if (t_islemturu == 18 || t_islemturu == 19 || t_islemturu == 20)
                {
                    Isler.Personel.Ekle_PersonelHareket(ucPersonelDemo1.Secili_PersonelID, spinMiktar.Value, true,
                     (Enumlar.IslemTurleri)t_islemturu, null, KasaID, memoAciklama.Text, txtEvrakNo.Text, temp_EvrakTarih,
                     null, Secili_KasaHareketID);
                }
                #endregion

                kh.KasaHareketID = t_KasaHareketID;
                kh.BankaHareketID = t_BankaHareketID;
                dbModel.SaveChanges();
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Sil()
        {
            if (kh == null || !Isler.Yetki.Varmi_Yetki(76)) return;

            try
            {
                if (XtraMessageBox.Show("Seçili Kasa Hereketini Silmek İstediğinize Emin Misiniz?\n", "Kasa Hareketi Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(kh);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Kasa Hereketi Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    Ara_KasaHareketleri(KasaID);
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kasa Hereketi Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Temizle_KasaHareket()
        {
            txtEvrakNo.Text = lblHareketNo.Text = memoAciklama.Text = null;
            spinMiktar.Value = 0;
            //lookUpIslemTuru.EditValue = "-1";


            ucGelirGiderDemo1.Temizle_GelirGider();
            ucBankaDemo1.Temizle_Banka();
            ucCariHesapDemo1.Temizle_Cari();
            ucAracDemo1.Temizle_Arac();

            ucKayitBilgi1.Temizle();
        }

        void Focus_KasaHarket()
        {
            if (_Yukleme || gridViewKasaHareket.GetFocusedDataRow() == null) return;

            Yukle_KasaHareket(Convert.ToInt32(gridViewKasaHareket.GetFocusedRowCellValue("ID")));
        }
        #endregion

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara_KasaHareketleri(KasaID);
        }
    }
}