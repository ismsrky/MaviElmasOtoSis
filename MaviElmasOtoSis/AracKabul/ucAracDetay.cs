using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;
using System.IO;

namespace MaviElmasOtoSis.AracKabul
{
    public partial class ucAracDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        arac arc;

        int _Secili_AracID;
        bool ResimSilindi = false;

        public DetayOlayHandler DetayOlay;
        #endregion

        #region < Özelikler >
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

        public int Secili_AracID
        {
            get
            {
                return _Secili_AracID;
            }
        }
        #endregion

        #region < Load >
        public ucAracDetay()
        {
            InitializeComponent();

            try
            {
                if (this.IsInDesignMode) return;

                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                spinModelYili.Properties.MaxValue = DateTime.Now.Year + 1;

                #region databind
                Isler.Genelkodlar.Ver_Kod("Karoser", ref lookUpKaroser, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("YakitTipi", ref lookUpYakitTipi, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("VitesTipi", ref lookUpVitesTipi, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("VitesTipi", ref lookUpVitesTipi, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("Cekis", ref lookUpCekis, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("Renk", ref lookUpRenk, "Lütfen Seçiniz");

                lookUpMarkalar.Properties.DisplayMember = "MarkaAdi";
                lookUpMarkalar.Properties.ValueMember = "MarkaID";
                lookUpMarkalar.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Genel.dt_Markalar.Copy(), "MarkaAdi", "MarkaID");
                #endregion

                Temizle_Arac();
            }
            catch (Exception hata)
            {

                throw;
            }
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

        private void spinModelYili_EditValueChanged(object sender, EventArgs e)
        {
            if (spinModelYili.EditValue != null && spinModelYili.Value == spinModelYili.Properties.MinValue)
            {
                spinModelYili.EditValue = null;
            }
        }
        private void spinSilindirHacmi_EditValueChanged(object sender, EventArgs e)
        {
            if (spinSilindirHacmi.EditValue != null && spinSilindirHacmi.Value == spinSilindirHacmi.Properties.MinValue)
            {
                spinSilindirHacmi.EditValue = null;
            }
        }
        private void spinMotoGucu_EditValueChanged(object sender, EventArgs e)
        {
            if (spinMotoGucu.EditValue != null && spinMotoGucu.Value == spinMotoGucu.Properties.MinValue)
            {
                spinMotoGucu.EditValue = null;
            }
        }

        private void lookUpMarkalar_EditValueChanged(object sender, EventArgs e)
        {
            if (Yukleme || lookUpMarkalar.EditValue == null) return;

            int temp_MarkaID = Convert.ToInt32(lookUpMarkalar.EditValue);

            lookUpModeller.Properties.DisplayMember = "ModelAdi";
            lookUpModeller.Properties.ValueMember = "ModelID";
            lookUpModeller.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Isler.MarkaModel.Ver_Modeller(temp_MarkaID), "ModelAdi", "ModelID");

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

        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    resimArac.Image = Image.FromFile(of.FileName);
                    resimArac.Tag = of.FileName;
                    ResimSilindi = false;
                }
            }
        }
        private void btnResimSil_Click(object sender, EventArgs e)
        {
            resimArac.Image = null;
            resimArac.Tag = null;
            ResimSilindi = true;

            resimArac.Image = ResOtoSis.car_icon;
        }
        #endregion

        #region < Metod >
        public void Yukle_Arac(int _AracID)
        {
            if (Yukleme) return;

            try
            {
                Temizle_Arac();
                _YeniKayit = false;

                if (arc != null && arc.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(arc);
                }
                arc = null;
                arc = Isler.Arac.Ver_Arac(ref dbModel, _AracID);
                if (arc == null) return;

                txtAracID.Text = arc.AracID.ToString();
                txtPlaka.Text = arc.Plaka;
                txtRuhsatSahibi.Text = arc.RuhsatSahibi;
                txtSase.Text = arc.SaseNo;
                if (!string.IsNullOrEmpty(arc.Karoser))
                {
                    lookUpKaroser.EditValue = arc.Karoser;
                }
                if (!string.IsNullOrEmpty(arc.YakitTipi))
                {
                    lookUpYakitTipi.EditValue = arc.YakitTipi;
                }
                if (!string.IsNullOrEmpty(arc.VitesTipi))
                {
                    lookUpVitesTipi.EditValue = arc.VitesTipi;
                }
                if (!string.IsNullOrEmpty(arc.Cekis))
                {
                    lookUpCekis.EditValue = arc.Cekis;
                }

                lookUpMarkalar.EditValue = arc.MarkaID;
                lookUpModeller.EditValue = arc.ModelID;
                dateUretimTarihi.EditValue = arc.UretimTarih;
                dateTeslimTarih.EditValue = arc.TeslimTarih;

                spinModelYili.EditValue = arc.ModelYil;
                spinMotoGucu.EditValue = arc.MotorGucu;
                spinSilindirHacmi.EditValue = arc.SilindirHacmi;

                if (!string.IsNullOrEmpty(arc.Renk))
                {
                    lookUpRenk.EditValue = arc.Renk;
                }
                memoAciklama.Text = arc.Aciklama;

                _Secili_AracID = arc.AracID;

                YukleResim();

                ucKayitBilgi1.Yukle(arc.KayitKullaniciID, arc.KayitZaman, arc.DuzenKullaniciID, arc.DuzenZaman);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Araç Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Kaydet()
        {
            if ((_YeniKayit && !Isler.Yetki.Varmi_Yetki(32)) || !_YeniKayit && !Isler.Yetki.Varmi_Yetki(33)) return;

            try
            {
                #region Kontroller
                if (string.IsNullOrEmpty(txtPlaka.Text.Trim()))
                {
                    XtraMessageBox.Show("Araç Plakası Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPlaka.Focus(); txtPlaka.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtSase.Text.Trim()))
                {
                    XtraMessageBox.Show("Araç Şase No Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSase.Focus(); txtSase.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtRuhsatSahibi.Text.Trim()))
                {
                    XtraMessageBox.Show("Araç Ruhsat Sahibi Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRuhsatSahibi.Focus(); txtRuhsatSahibi.Select();
                    return;
                }
                //if (lookUpKaroser.EditValue.ToString() == "-1")
                //{
                //    XtraMessageBox.Show("Lütfen Araç Karoser Tipini Seçiniz.", "Karoser Tipi Seçilmemiş",
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    lookUpKaroser.Focus(); lookUpKaroser.Select();
                //    return;
                //}
                //if (lookUpYakitTipi.EditValue.ToString() == "-1")
                //{
                //    XtraMessageBox.Show("Lütfen Araç Yakıt Tipini Seçiniz.", "Yakıt Tipi Seçilmemiş",
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    lookUpYakitTipi.Focus(); lookUpYakitTipi.Select();
                //    return;
                //}
                //if (lookUpVitesTipi.EditValue.ToString() == "-1")
                //{
                //    XtraMessageBox.Show("Lütfen Araç Vites Tipini Seçiniz.", "Vites Tipi Seçilmemiş",
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    lookUpVitesTipi.Focus(); lookUpVitesTipi.Select();
                //    return;
                //}
                if (lookUpMarkalar.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Araç Markasını Seçiniz.", "Araç Markası Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpMarkalar.Focus(); lookUpMarkalar.Select();
                    return;
                }
                if (lookUpModeller.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Araç Modelini Seçiniz.", "Araç Modeli Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpModeller.Focus(); lookUpModeller.Select();
                    return;
                }
                //if (lookUpCekis.EditValue.ToString() == "-1")
                //{
                //    XtraMessageBox.Show("Lütfen Araç Çekiş Tipini Seçiniz.", "Çekiş Tipi Seçilmemiş",
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    lookUpCekis.Focus(); lookUpCekis.Select();
                //    return;
                //}

                if (_YeniKayit && Isler.Arac.Varmi_Plaka(Genel.AktifSirket.SirketID, txtPlaka.Text.Replace(" ","")))
                {
                    XtraMessageBox.Show("Bu Araç Plakası Daha Önce Kullanılmış\nLütfen Farklı Bir Plaka Giriniz.", "Aynı Plaka",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPlaka.Focus(); txtPlaka.Select();
                    return;
                }
                else if (!_YeniKayit && txtPlaka.Text.Replace(" ", "") != arc.Plaka && Isler.Arac.Varmi_Plaka(Genel.AktifSirket.SirketID, txtPlaka.Text.Replace(" ", ""), arc.Plaka))
                {
                    XtraMessageBox.Show("Bu Araç Plakası Daha Önce Kullanılmış\nLütfen Farklı Bir Plaka Giriniz.", "Aynı Plaka",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPlaka.Focus(); txtPlaka.Select();
                    return;
                }

                if (_YeniKayit && Isler.Arac.Varmi_SaseNo(Genel.AktifSirket.SirketID, txtSase.Text))
                {
                    XtraMessageBox.Show("Bu Araç Şase Nosu Daha Önce Kullanılmış\nLütfen Farklı Bir Şase Nosu Giriniz.", "Aynı Şase No",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSase.Focus(); txtSase.Select();
                    return;
                }
                else if (!_YeniKayit && txtSase.Text != arc.SaseNo && Isler.Arac.Varmi_SaseNo(Genel.AktifSirket.SirketID, txtSase.Text, arc.SaseNo))
                {
                    XtraMessageBox.Show("Bu Araç Şase Nosu Daha Önce Kullanılmış\nLütfen Farklı Bir Şase Nosu Giriniz.", "Aynı Şase No",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSase.Focus(); txtSase.Select();
                    return;
                }
                #endregion

                if (_YeniKayit)
                {
                    if (arc != null && arc.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(arc);
                    }
                    arc = null;
                    arc = new arac();
                    arc.SirketID = Genel.AktifSirket.SirketID;
                }

                #region Araç Resmi
                if (ResimSilindi && !string.IsNullOrEmpty(arc.Resim))
                {
                    File.Delete(Sistem.Ayarlar.DosyaSunucusu + Genel.AracResim_Yol + arc.Resim);
                    arc.Resim = null;
                }
                else if (resimArac.Tag != null && !string.IsNullOrEmpty(arc.Resim) && resimArac.Tag.ToString() != arc.Resim)
                {
                    File.Delete(Sistem.Ayarlar.DosyaSunucusu + Genel.AracResim_Yol + arc.Resim);
                    arc.Resim = (DateTime.Now.Year + DateTime.Now.Millisecond + Araclar.Mat.Rasgele(10, 100000).ToString()) + ".zip";
                    string hedef = Sistem.Ayarlar.DosyaSunucusu + Genel.AracResim_Yol + arc.Resim;

                    Araclar.ZipDosya.Ziple(resimArac.Tag.ToString(), hedef, true);
                }
                else if (resimArac.Tag != null && string.IsNullOrEmpty(arc.Resim))
                {
                    arc.Resim = (DateTime.Now.Year + DateTime.Now.Millisecond +Araclar. Mat.Rasgele(10, 100000).ToString()) + ".zip";
                    string hedef = Sistem.Ayarlar.DosyaSunucusu + Genel.AracResim_Yol + arc.Resim;

                    Araclar.ZipDosya.Ziple(resimArac.Tag.ToString(), hedef, true);
                }
                #endregion

                #region Aktarma
                arc.Plaka = txtPlaka.Text.Replace(" ","");
                arc.SaseNo = txtSase.Text;
                arc.RuhsatSahibi = txtRuhsatSahibi.Text;
                arc.Karoser = lookUpKaroser.EditValue.ToString();
                arc.YakitTipi = lookUpYakitTipi.EditValue.ToString();
                arc.VitesTipi = lookUpVitesTipi.EditValue.ToString();
                arc.MarkaID = Convert.ToInt32(lookUpMarkalar.EditValue);
                arc.ModelID = Convert.ToInt32(lookUpModeller.EditValue);
                if (dateUretimTarihi.EditValue == null)
                {
                    arc.UretimTarih = null;
                }
                else
                {
                    arc.UretimTarih = Convert.ToDateTime(dateUretimTarihi.EditValue);
                }
                if (dateTeslimTarih.EditValue == null)
                {
                    arc.TeslimTarih = null;
                }
                else
                {
                    arc.TeslimTarih = Convert.ToDateTime(dateTeslimTarih.EditValue);
                }
                if (spinModelYili.EditValue == null)
                {
                    arc.ModelYil = null;
                }
                else
                {
                    arc.ModelYil = Convert.ToInt32(spinModelYili.EditValue);
                }
                if (spinMotoGucu.EditValue == null)
                {
                    arc.MotorGucu = null;
                }
                else
                {
                    arc.MotorGucu = Convert.ToInt32(spinMotoGucu.EditValue);
                }
                if (spinSilindirHacmi.EditValue == null)
                {
                    arc.SilindirHacmi = null;
                }
                else
                {
                    arc.SilindirHacmi = Convert.ToInt32(spinSilindirHacmi.EditValue);
                }
                arc.Cekis = lookUpCekis.EditValue.ToString();
                if (lookUpRenk.EditValue.ToString() == "-1")
                {
                    arc.Renk = null;
                }
                else
                {
                    arc.Renk = lookUpRenk.EditValue.ToString();
                }
                arc.Aciklama = memoAciklama.Text;
                #endregion

                #region Kayıt
                if (_YeniKayit)
                {
                    arc.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    arc.KayitZaman = DateTime.Now;
                    dbModel.AddToaracs(arc);
                }
                else
                {
                    arc.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    arc.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();
                _Secili_AracID = arc.AracID;
                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Araç Başarılı Bir Şekilde Kaydedilmiştir.", null,
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
                XtraMessageBox.Show("Araç Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Sil()
        {
            if (arc == null || !Isler.Yetki.Varmi_Yetki(34)) return;

            try
            {
                if (Isler.Arac.Ver_AdetAracHareket(arc.AracID) > 0)
                {
                    XtraMessageBox.Show("Seçili Araç Hareket Görmüş; Silinemez.", "Geçersiz İşlem",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Seçili Aracı Silmek İstediğinize Emin Misiniz?\n"
                   + "Araç No : " + arc.AracID.ToString()
                   + "\nAraç Plaka : " + arc.Plaka, "Araç Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (!string.IsNullOrEmpty(arc.Resim) && File.Exists(Sistem.Ayarlar.DosyaSunucusu + Genel.AracResim_Yol + arc.Resim))
                    {
                        File.Delete(Sistem.Ayarlar.DosyaSunucusu + Genel.AracResim_Yol + arc.Resim);
                    }

                    dbModel.DeleteObject(arc);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Araç Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    if (DetayOlay != null)
                    {
                        this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                    }
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Araç Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Yeni()
        {
            _YeniKayit = true;

            Temizle_Arac();
            txtPlaka.Focus(); txtPlaka.Select();

            if (DetayOlay != null && this.Handle.ToInt32() > 0)
            {
                this.Invoke(DetayOlay, Enumlar.DetayOlaylari.YeniKayit, null);
            }
        }

        void Temizle_Arac()
        {
            txtAracID.Text = txtPlaka.Text = txtRuhsatSahibi.Text = txtSase.Text = memoAciklama.Text = "";

            lookUpCekis.EditValue = lookUpKaroser.EditValue = lookUpRenk.EditValue = lookUpVitesTipi.EditValue
            = lookUpYakitTipi.EditValue = "-1";

            lookUpMarkalar.EditValue = -1;

            spinModelYili.EditValue = spinMotoGucu.EditValue = spinSilindirHacmi.EditValue = null;
        }

        void YukleResim()
        {
            try
            {
                if (string.IsNullOrEmpty(arc.Resim))
                {
                    resimArac.Image = ResOtoSis.car_icon;
                }
                else
                {
                    MemoryStream a = new MemoryStream();
                    Araclar.ZipDosya.Unzip_Stream(Sistem.Ayarlar.DosyaSunucusu + Genel.AracResim_Yol + arc.Resim, ref a, true);
                    resimArac.Image = Image.FromStream(a);
                    ResimSilindi = false;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Araç Resmini Yüklerken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}