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

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class ucGelirGiderDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        gelirgider _gg;

        int _Secili_GelirGiderID;

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

        public int Secili_GelirGiderID
        {
            get
            {
                return _Secili_GelirGiderID;
            }
        }

        public gelirgider gg
        {
            get
            {
                return _gg;
            }
        }
        #endregion

        #region < Load >
        public ucGelirGiderDetay()
        {
            InitializeComponent();
            if (this.IsInDesignMode) return;

            try
            {
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                #region databind
                Isler.Genelkodlar.Ver_Kod("GelirGiderGrup", ref lookUpGelirGiderGrup, "Lütfen Seçiniz");
                #endregion

                Temizle_GelirGider();
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        private void ucGelirGiderDetay_Load(object sender, EventArgs e)
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

        private void tabGelirGider_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            YukleTablar();
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
        public void Yukle_GelirGider(int _GelirGiderID)
        {
            if (Yukleme) return;

            try
            {
                Temizle_GelirGider();
                _YeniKayit = false;

                if (_gg != null && _gg.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_gg);
                }
                _gg = null;
                _gg = Isler.GelirGider.Ver_GelirGider(ref dbModel, _GelirGiderID);
                if (_gg == null) return;

                txtGelirGiderID.Text = _gg.GelirGiderID.ToString();
                txtAd.Text = _gg.GelirGiderAd;
                lookUpGelirGiderGrup.EditValue = _gg.GelirGiderGrup;
                chkDurum.Checked = _gg.Durum;
                if (_gg.Gelir)
                {
                    radioGelirGiderID.SelectedIndex = 0;
                }
                else
                {
                    radioGelirGiderID.SelectedIndex = 1;
                }
                memoAciklama.Text = _gg.Aciklama;


                _Secili_GelirGiderID = _gg.GelirGiderID;

                ucKayitBilgi1.Yukle(_gg.KayitKullaniciID, _gg.KayitZaman, _gg.DuzenKullaniciID, _gg.DuzenZaman);

                YukleTablar();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Gelir/Gider Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Sil()
        {
            if (_gg == null || !Isler.Yetki.Varmi_Yetki(46)) return;

            try
            {
                if (Isler.GelirGider.Ver_AdetGelirGider(_gg.GelirGiderID)>0)
                {
                    XtraMessageBox.Show("Seçili Gelir/Gider Kalemi Görmüş; Silinemez.", "Geçersiz İşlem",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show("Seçili Geliri/Gideri Silmek İstediğinize Emin Misiniz?\n"
                   + "Gelir/Gider No: " + _gg.GelirGiderID.ToString()
                   + "\nGelir/Gider Adı : " + _gg.GelirGiderAd, "Gelir/Gider Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(_gg);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Gelir/Gider Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    if (DetayOlay != null)
                    {
                        this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                    }
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Gelir/Gider Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Kaydet()
        {
            if ((_YeniKayit && !Isler.Yetki.Varmi_Yetki(44)) || !_YeniKayit && !Isler.Yetki.Varmi_Yetki(45)) return;

            try
            {
                #region < Kontroller >
                if (string.IsNullOrEmpty(txtAd.Text.Trim()))
                {
                    XtraMessageBox.Show("Gelir/Gider Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabGelirGider.SelectedTabPageIndex = 0;
                    txtAd.Focus(); txtAd.Select();
                    return;
                }
                if (lookUpGelirGiderGrup.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen Gelir/Gider Grubunu Seçiniz.", "Grup Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabGelirGider.SelectedTabPageIndex = 0;
                    lookUpGelirGiderGrup.Focus(); lookUpGelirGiderGrup.Select();
                    return;
                }
                if (_YeniKayit && Isler.GelirGider.Varmi_GelirGiderAd(txtAd.Text))
                {
                    XtraMessageBox.Show("Bu Gelir/Gider Adı Daha Önce Tanımlanmış.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAd.Focus(); txtAd.Select();
                    return;
                }
                else if (!_YeniKayit && txtAd.Text != _gg.GelirGiderAd && Isler.GelirGider.Varmi_GelirGiderAd(txtAd.Text, _gg.GelirGiderAd))
                {
                    XtraMessageBox.Show("Bu Gelir/Gider Adı Daha Önce Tanımlanmış.", "Aynı Değer",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAd.Focus(); txtAd.Select();
                    return;
                }
                #endregion

                if (_YeniKayit)
                {
                    if (_gg != null && _gg.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(_gg);
                    }
                    _gg = null;
                    _gg = new gelirgider();
                    _gg.SirketID = Genel.AktifSirket.SirketID;
                }

                #region Aktarma
                _gg.GelirGiderAd = txtAd.Text;
                if (radioGelirGiderID.SelectedIndex == 0)
                {
                    _gg.Gelir = true;
                }
                else if (radioGelirGiderID.SelectedIndex == 1)
                {
                    _gg.Gelir = false;
                }
                _gg.GelirGiderGrup = lookUpGelirGiderGrup.EditValue.ToString();
                _gg.Aciklama = memoAciklama.Text;
                _gg.Durum = chkDurum.Checked;
                #endregion

                #region Kayıt
                if (_YeniKayit)
                {
                    _gg.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    _gg.KayitZaman = DateTime.Now;
                    dbModel.AddTogelirgiders(_gg);
                }
                else
                {
                    _gg.DuzenKullaniciID = Genel.AktifKullanici.DuzenKullaniciID;
                    _gg.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();
                _Secili_GelirGiderID = _gg.GelirGiderID;

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Gelir/Gider Başarılı Bir Şekilde Kaydedilmiştir.", null,
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
                XtraMessageBox.Show("Gelir/Gider Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Yeni()
        {
            _YeniKayit = true;

            Temizle_GelirGider();
            tabGelirGider.SelectedTabPageIndex = 0;
            txtAd.Focus(); txtAd.Select();

            if (DetayOlay != null && this.Handle.ToInt32()>0)
            {
                this.Invoke(DetayOlay, Enumlar.DetayOlaylari.YeniKayit, null);
            }
        }

        void Temizle_GelirGider()
        {
            txtAd.Text = txtGelirGiderID.Text = memoAciklama.Text = "";
            radioGelirGiderID.SelectedIndex = 0;
            lookUpGelirGiderGrup.EditValue = "-1";

            chkDurum.Checked = true;
        }

        void YukleTablar()
        {
            if (tabGelirGider.SelectedTabPage == pageGelirGiderHareket)
            {
                ucGelirGiderHareket1.Ara_GelirGiderHareket(Secili_GelirGiderID);
            }
        }
        #endregion
    }
}