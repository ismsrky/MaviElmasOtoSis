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

namespace MaviElmasOtoSis.Stok
{
    public partial class ucStokKartDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        stok_kart kart;
        stok_kart_esdeger esdeger;

        int _Secili_KartID;
        int Secili_EsdegerID;

        DataTable dt_Markalar;
        DataTable dt_Esdegerler;

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

        public int Secili_KartID
        {
            get
            {
                return _Secili_KartID;
            }
        }
        #endregion

        #region < Load >
        public ucStokKartDetay()
        {
            InitializeComponent();
            if (this.IsInDesignMode) return;

            try
            {
                spinKritikStok.EditValue = null;
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                #region < databind >
                Isler.Genelkodlar.Ver_Kod("StokBirim", ref lookUpStokBirim, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("StokGrup", ref lookUpStokGrup, "Lütfen Seçiniz");

                lookUpMarkalar.Properties.DisplayMember = "MarkaAdi";
                lookUpMarkalar.Properties.ValueMember = "MarkaID";
                lookUpMarkalar.Properties.DataSource = Araclar.Veri.Ekle_Tumu(Genel.dt_Markalar.Copy(), "MarkaAdi", "MarkaID");
                #endregion

                Temizle_Detay();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Kartları Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ucStokKartDetay_Load(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region < Olaylar >
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

        private void tabStokKart_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            YukleTablar();
        }

        private void spinKritikStok_EditValueChanged(object sender, EventArgs e)
        {
            if (spinKritikStok.EditValue != null && spinKritikStok.EditValue.ToString() == "0")
            {
                spinKritikStok.EditValue = null;
            }
        }
        private void spinSatisFiyat_EditValueChanged(object sender, EventArgs e)
        {
            if (spinSatisFiyat.EditValue != null && spinSatisFiyat.EditValue.ToString() == "0")
            {
                spinSatisFiyat.EditValue = null;
            }
        }

        private void lookUpMarkalar_EditValueChanged(object sender, EventArgs e)
        {
            if (_Yukleme || lookUpMarkalar.EditValue == null) return;

            int temp_MarkaID = Convert.ToInt32(lookUpMarkalar.EditValue);

            lookUpModeller.Properties.DisplayMember = "ModelAdi";
            lookUpModeller.Properties.ValueMember = "ModelID";
            lookUpModeller.Properties.DataSource = Araclar.Veri.Ekle_Tumu(Isler.MarkaModel.Ver_Modeller(temp_MarkaID), "ModelAdi", "ModelID");

            lookUpModeller.EditValue = -1;

            if (temp_MarkaID == -1)
            {
                lookUpModeller.Enabled = false;
            }
            else
            {
                lookUpModeller.Enabled = true;
            }
        }

        private void btnMarkaEkle_Click(object sender, EventArgs e)
        {
            if (lookUpMarkalar.EditValue.ToString() == "-1") //Tüm markalar seçilmiş
            {
                Isler.Stok.Sil_KartMarkalari(kart.KartID);
                Ara_Markalar(kart.KartID);
                return;
            }

            int temp_MarkaID = Convert.ToInt32(lookUpMarkalar.EditValue);
            int temp_ModelID = Convert.ToInt32(lookUpModeller.EditValue);

            if (lookUpModeller.EditValue.ToString() == "-1") //tüm modeller seçilmiş
            {
                Isler.Stok.Sil_KartModeller(kart.KartID, temp_MarkaID);
                Ara_Markalar(kart.KartID);
                return;
            }

            if (Isler.Stok.Varmi_KartModel(kart.KartID, temp_MarkaID, temp_ModelID))
            {
                XtraMessageBox.Show("Bu Marka Model Daha Önce Eklenmiş.", "Aynı Kayıt",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Isler.Stok.Ekle_KartModel(kart.KartID, temp_MarkaID, temp_ModelID);

            Ara_Markalar(kart.KartID);
        }
        private void btnMarkaSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewModeller.GetFocusedRow() == null) return;

                Isler.Stok.Sil_KartMarka(Convert.ToInt32(gridViewModeller.GetFocusedRowCellValue("ID")));

                Ara_Markalar(kart.KartID);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Uyumlu Marka/Model Silinirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEsdegerEkle_Click(object sender, EventArgs e)
        {
            if (btnEsdegerStokKart.Tag == null)
            {
                XtraMessageBox.Show("Lütfen Eşdeğer Olacak Stok Kartını Seçiniz.", "Parça Seçilmemiş",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(btnEsdegerStokKart.Tag) == kart.KartID)
            {
                XtraMessageBox.Show("Parçanın Kendisi Eşdeğer Parça Olarak Eklenemez.", "Aynı Parça",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Isler.Stok.Varmi_Esdegeri(kart.KartID, Convert.ToInt32(btnEsdegerStokKart.Tag)))
            {
                XtraMessageBox.Show("Bu Parça Daha Önce Eşdeğer Olarak Eklenmiş.\nLütfen Başka Bir Parça Seçiniz.", "Aynı Parça",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (esdeger != null && esdeger.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(esdeger);
                }
                esdeger = null;
                esdeger = new stok_kart_esdeger();
                esdeger.StokKartID = kart.KartID;
                esdeger.EsdegerKartID = Convert.ToInt32(btnEsdegerStokKart.Tag);
                dbModel.AddTostok_kart_esdeger(esdeger);
                dbModel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Eşdeğer Parça Başarılı Bir Şekilde Eklenmiştir.", null,
                  ResOtoSis.mark_blue);

                Ara_Esdegerler(kart.KartID);

                btnEsdegerStokKart.Tag = null;
                btnEsdegerStokKart.Text = "";

                btnEsdegerEkle.Enabled = false;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Eşdeğer Parça Eklenirke Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEsdegerSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewEsdegerler.GetFocusedRow() == null) return;

                dbModel.DeleteObject(esdeger);
                dbModel.SaveChanges();

                Ara_Esdegerler(kart.KartID);

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Eşdeğer Parça Başarılı Bir Şekilde Silinmiştir.", null,
                    ResOtoSis.mark_blue);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Eşdeğer Parça Eklenirke Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEsdegerStokKart_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (Stok.frmStokKartSec sec = new frmStokKartSec())
            {
                if (sec.ShowDialog() == DialogResult.OK)
                {
                    btnEsdegerStokKart.Tag = sec.Secilen_KartID.ToString();
                    btnEsdegerStokKart.Text = sec.Secilen_KalemAdi;
                    btnEsdegerEkle.Enabled = true;
                }
                else
                {
                    btnEsdegerStokKart.Tag = null;
                    btnEsdegerStokKart.Text = "";
                    btnEsdegerEkle.Enabled = false;
                }
            }
        }

        private void gridViewEsdegerler_Click(object sender, EventArgs e)
        {
            if (gridViewEsdegerler.RowCount == 1)
                Focus_Esdeger();
        }
        private void gridViewEsdegerler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Focus_Esdeger();
        }

        private void chkDurum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDurum.Checked)
                chkDurum.Text = "Aktif";
            else
                chkDurum.Text = "Pasif";
        }
        #endregion

        #region < Metod >
        void Ara_Markalar(int _KartID)
        {
            dt_Markalar = null;
            dt_Markalar = Isler.Stok.Ver_KartMarkalar(_KartID);

            if (dt_Markalar.Rows.Count > 0)
            {
                btnMarkaSil.Enabled = true;
            }
            else
            {
                btnMarkaSil.Enabled = false;
            }

            gridControlModeller.DataSource = dt_Markalar;
            gridViewModeller.ViewCaption = "Uyumlu Marka ve Modeller (" + dt_Markalar.Rows.Count.ToString() + ")";
            lookUpMarkalar.EditValue = -1;
        }
        void Ara_Esdegerler(int _KartID)
        {
            dt_Esdegerler = null;
            dt_Esdegerler = Isler.Stok.Ver_Esdegerler(_KartID);

            gridControlEsdegerler.DataSource = dt_Esdegerler;
            gridViewEsdegerler.ViewCaption = "Eşdeğer Parçaları (" + dt_Esdegerler.Rows.Count.ToString() + ")";

            if (dt_Esdegerler.Rows.Count > 0)
            {
                int temp_ID;
                bool Bulundu = false;
                for (int i = 0; i < gridViewEsdegerler.RowCount; i++)
                {
                    temp_ID = Convert.ToInt32(gridViewEsdegerler.GetDataRow(i)["ID"]);
                    if (temp_ID == Secili_EsdegerID)
                    {
                        gridViewEsdegerler.FocusedRowHandle = i;
                        Bulundu = true;
                        break;
                    }
                }

                if (!Bulundu)
                {
                    Yukle_Esdeger(Convert.ToInt32(gridViewEsdegerler.GetDataRow(0)["ID"]));
                }

                btnEsdegerSil.Enabled = true;
            }
            else
            {
                btnEsdegerSil.Enabled = false;
            }
        }

        public void Yukle_Kart(int _KartID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_Detay();
                _YeniKayit = false;

                if (kart != null && kart.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(kart);
                }
                kart = null;
                kart = Isler.Stok.Ver_StokKart(ref dbModel, _KartID);
                if (kart == null) return;

                chkDurum.Checked = kart.Durum;
                txtKartID.Text = kart.KartID.ToString();
                txtBarkodNo.Text = kart.BarkodNo;
                txtKalemAdi.Text = kart.KalemAdi;
                txtParcaNo.Text = kart.ParcaNo;
                memoAciklama.Text = kart.Aciklama;

                spinKritikStok.EditValue = kart.KritikStok;
                spinSatisFiyat.EditValue = kart.SatisFiyat;

                lookUpStokGrup.EditValue = kart.StokGrup;
                lookUpStokBirim.EditValue = kart.StokBirim;

                if (kart.Raf != null)
                {
                    txtRaf.Text = kart.Raf.Value.ToString();
                }
                if (kart.Sira != null)
                {
                    txtSira.Text = kart.Sira.Value.ToString();
                }
                if (kart.Goz != null)
                {
                    txtGoz.Text = kart.Goz.Value.ToString();
                }

                if (kart.Kdv == null)
                {
                    spinKdv.Value = 0;
                }
                else
                {
                    spinKdv.Value = Convert.ToSByte(kart.Kdv);
                }

                pEnable(true);

                ucKayitBilgi1.Yukle(kart.KayitKullaniciID, kart.KayitZaman, kart.DuzenKullaniciID, kart.DuzenZaman);

                _Secili_KartID = kart.KartID;
                YukleTablar();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Kartı Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Yukle_Esdeger(int _ID)
        {
            if (_Yukleme) return;

            if (esdeger != null && esdeger.EntityState != EntityState.Detached)
            {
                dbModel.Detach(esdeger);
            }
            esdeger = null;
            esdeger = Isler.Stok.Ver_Esdeger(ref dbModel, _ID);
            if (esdeger == null) return;
        }

        void YukleTablar()
        {
            if (_Yukleme || kart == null) return;
            if (tabStokKart.SelectedTabPageIndex == 1)
            {
                Ara_Markalar(kart.KartID);
            }
            else if (tabStokKart.SelectedTabPageIndex == 2)
            {
                Ara_Esdegerler(kart.KartID);
            }
        }

        void Sil()
        {
            if (kart == null) return;

            if (!Genel.Yetkilerim.Contains(4))
            {
                Genel.Yetki_Uyari(4);
                return;
            }

            try
            {
                if (Isler.Stok.Ver_AdetStokHareket(kart.KartID) > 0)
                {
                    XtraMessageBox.Show("Bu Stok Kartı Hareket Görmüş, Silinemez.", "Geçersiz İşlem",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Seçili Stok Kartını Silmek İstediğinize Emin Misiniz?\n"
                   + "Kalem Adı : " + kart.KalemAdi
                   + "\nKalem No : " + kart.KartID, "Stok Kartı Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(kart);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Stok Kartı Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    if (DetayOlay != null)
                    {
                        this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                    }
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Kartı Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Kaydet()
        {
            if ((YeniKayit && !Isler.Yetki.Varmi_Yetki(2)) || !YeniKayit && !Isler.Yetki.Varmi_Yetki(3)) return;

            try
            {
                #region Kontroller
                if (string.IsNullOrEmpty(txtKalemAdi.Text))
                {
                    XtraMessageBox.Show("Kalem Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKalemAdi.Focus(); txtKalemAdi.Select();
                    return;
                }
                if (lookUpStokBirim.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Stok Birimini Seçiniz.", "Stok Birimi Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpStokBirim.Focus(); lookUpStokBirim.Select();
                    return;
                }
                if (lookUpStokGrup.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Stok Grubunu Seçiniz.", "Stok Grubu Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpStokGrup.Focus(); lookUpStokGrup.Select();
                    return;
                }
                //if (YeniKayit && Isler.Stok.Varmi_KalemAd(Genel.AktifSirket.SirketID, txtKalemAdi.Text))
                //{
                //    XtraMessageBox.Show("Bu Kalem Adı Daha Önce Kullanılmış\nLütfen Farklı Bir Kalem Adı Yazınız.", "Aynı Değer",
                //          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtKalemAdi.Focus(); txtKalemAdi.Select();
                //    return;
                //}
                //else if (!YeniKayit && txtKalemAdi.Text != kart.KalemAdi && Isler.Stok.Varmi_KalemAd(Genel.AktifSirket.SirketID, txtKalemAdi.Text, kart.KalemAdi))
                //{
                //    XtraMessageBox.Show("Bu Kalem Adı Daha Önce Kullanılmış\nLütfen Farklı Bir Kalem Adı Yazınız.", "Aynı Değer",
                //          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtKalemAdi.Focus(); txtKalemAdi.Select();
                //    return;
                //}

                if (YeniKayit && Isler.Stok.Varmi_ParcaNo(Genel.AktifSirket.SirketID, txtParcaNo.Text))
                {
                    XtraMessageBox.Show("Bu Parça Nosu Daha Önce Kullanılmış\nLütfen Farklı Bir Parça Nosu Yazınız.", "Aynı Parça No",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtParcaNo.Focus(); txtParcaNo.Select();
                    return;
                }
                else if (!YeniKayit && txtParcaNo.Text != kart.ParcaNo && Isler.Stok.Varmi_ParcaNo(Genel.AktifSirket.SirketID, txtParcaNo.Text, kart.ParcaNo))
                {
                    XtraMessageBox.Show("Bu Parça Nosu Daha Önce Kullanılmış\nLütfen Farklı Bir Parça Nosu Yazınız.", "Aynı Parça No",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtParcaNo.Focus(); txtParcaNo.Select();
                    return;
                }
                #endregion

                if (_YeniKayit)
                {
                    if (kart != null && kart.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(kart);
                    }
                    kart = null;
                    kart = new stok_kart();
                    kart.SirketID = Genel.AktifSirket.SirketID;
                }

                #region Aktarma
                kart.Aciklama = memoAciklama.Text;
                kart.BarkodNo = txtBarkodNo.Text;
                kart.KalemAdi = txtKalemAdi.Text;
                kart.ParcaNo = txtParcaNo.Text;
                kart.StokBirim = lookUpStokBirim.EditValue.ToString();
                kart.StokGrup = lookUpStokGrup.EditValue.ToString();
                if (string.IsNullOrEmpty(txtRaf.Text))
                {
                    kart.Raf = null;
                }
                else
                {
                    kart.Raf = Convert.ToInt32(txtRaf.Text);
                }
                if (string.IsNullOrEmpty(txtSira.Text))
                {
                    kart.Sira = null;
                }
                else
                {
                    kart.Sira = Convert.ToInt32(txtSira.Text);
                }
                if (string.IsNullOrEmpty(txtGoz.Text))
                {
                    kart.Goz = null;
                }
                else
                {
                    kart.Goz = Convert.ToInt32(txtGoz.Text);
                }
                if (spinKritikStok.EditValue == null)
                {
                    kart.KritikStok = null;
                }
                else
                {
                    kart.KritikStok = Convert.ToInt32(spinKritikStok.Value);
                }
                if (spinSatisFiyat.EditValue == null)
                {
                    kart.SatisFiyat = null;
                }
                else
                {
                    kart.SatisFiyat = Convert.ToDecimal(spinSatisFiyat.Value);
                }
                if (spinKdv.EditValue == null || spinKdv.Value <= 0)
                {
                    kart.Kdv = null;
                }
                else
                {
                    kart.Kdv = Convert.ToSByte(spinKdv.Value);
                }
                kart.Durum = chkDurum.Checked;
                #endregion

                #region Kayıt
                if (_YeniKayit)
                {
                    kart.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    kart.KayitZaman = DateTime.Now;
                    dbModel.AddTostok_kart(kart);
                }
                else
                {
                    kart.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    kart.DuzenZaman = DateTime.Now;
                }
                dbModel.SaveChanges();
                _Secili_KartID = kart.KartID;

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Stok Kartı Başarılı Bir Şekilde Kaydedilmiştir.", null,
                   ResOtoSis.mark_blue);

                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.Kaydedildi, null);
                }
                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                }

                pEnable(true);

                Yeni();
                #endregion
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Kartı Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Yeni()
        {
            _YeniKayit = true;

            Temizle_Detay();
            txtKalemAdi.Focus(); txtKalemAdi.Select();

            pEnable(false);

            if (DetayOlay != null && this.Handle.ToInt32() > 0)
            {
                this.Invoke(DetayOlay, Enumlar.DetayOlaylari.YeniKayit, null);
            }
        }

        void Focus_Esdeger()
        {
            if (_Yukleme || gridViewEsdegerler.GetFocusedDataRow() == null) return;

            Secili_EsdegerID = Convert.ToInt32(gridViewEsdegerler.GetFocusedRowCellValue("ID"));
            Yukle_Esdeger(Secili_EsdegerID);
        }

        void Temizle_Detay()
        {
            btnEsdegerStokKart.Text = txtKartID.Text = txtBarkodNo.Text = txtRaf.Text = txtSira.Text = txtGoz.Text = txtKalemAdi.Text
            = txtParcaNo.Text = txtRaf.Text = memoAciklama.Text = "";

            spinKritikStok.EditValue = spinSatisFiyat.EditValue = btnEsdegerStokKart.Tag = null;

            lookUpStokBirim.EditValue = lookUpStokGrup.EditValue = "-1";

            chkDurum.Checked = true;

            spinKdv.EditValue = 18;

            ucKayitBilgi1.Temizle();
        }

        void pEnable(bool deger)
        {
            //groupUyumluMarka.Enabled = deger;

            pageEsdeger.PageEnabled = pageUyumluMarka.PageEnabled = deger;

            if (!deger)
            {
                dt_Markalar = null;
                tabStokKart.SelectedTabPageIndex = 0;
            }
        }
        #endregion       
    }
}