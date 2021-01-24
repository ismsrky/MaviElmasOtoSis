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
    public partial class ucKasaDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        kasa ks;

        int _Secili_KasaID;

        public DetayOlayHandler DetayOlay;

        DataTable dt_Kasalar = null;
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

        public int Secili_KasaID
        {
            get
            {
                return _Secili_KasaID;
            }
        }
        #endregion

        #region < Load >
        public ucKasaDetay()
        {
            InitializeComponent();

            if (this.IsInDesignMode) return;

            try
            {
                _Yukleme = true;

                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                Temizle_Kasa();

                Ara();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kasalar Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        private void ucKasaDetay_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region < Olaylar >
        private void GridViewKasa_Click(object sender, EventArgs e)
        {
            if (GridViewKasa.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Kasa();
            }
            _Focusta = false;
        }
        private void GridViewKasa_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _Focusta = true;
            Focus_Kasa();
        }

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

        private void chkDurum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDurum.Checked)
                chkDurum.Text = "Aktif";
            else
                chkDurum.Text = "Pasif";
        }
        #endregion

        #region < Metod >
        public void Yukle_Kasa(int _KasaID)
        {
            if (Yukleme) return;

            try
            {
                Temizle_Kasa();
                _YeniKayit = false;

                if (ks != null && ks.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(ks);
                }
                ks = null;
                ks = Isler.Kasa.Ver_Kasa(ref dbModel, _KasaID);
                if (ks == null) return;

                txtKasaID.Text = ks.KasaID.ToString();
                txtKasaAd.Text = ks.KasaAd;
                chkDurum.Checked = ks.Durum;
                memoAciklama.Text = ks.Aciklama;

                _Secili_KasaID = ks.KasaID;
                pageKasaHareketleri.PageEnabled = true;

                ucKayitBilgi1.Yukle(ks.KayitKullaniciID, ks.KayitZaman, ks.DuzenKullaniciID, ks.DuzenZaman);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kasa Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Sil()
        {
            if (ks == null) return;

            if (!Genel.Yetkilerim.Contains(50))
            {
                Genel.Yetki_Uyari(50);
                return;
            }
            try
            {
                //Burada kasa hareketi kontrol edilecek
                //Eğer kasa hareket varsa silme işlemi yapılamayacak.
                if (XtraMessageBox.Show("Seçili Kasayı Silmek İstediğinize Emin Misiniz?\n"
                   + "Kasa No: " + ks.KasaID.ToString()
                   + "\nKasa Adı : " + ks.KasaAd, "Kasa Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(ks);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Kasa Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    if (DetayOlay != null)
                    {
                        this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                    }
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kasa Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Kaydet()
        {
            if (_YeniKayit && !Genel.Yetkilerim.Contains(48))
            {
                Genel.Yetki_Uyari(48);
                return;
            }
            else if (!_YeniKayit && !Genel.Yetkilerim.Contains(49))
            {
                Genel.Yetki_Uyari(49);
                return;
            }

            try
            {
                #region < Kontroller >
                if (string.IsNullOrEmpty(txtKasaAd.Text.Trim()))
                {
                    XtraMessageBox.Show("Kasa Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabKasa.SelectedTabPageIndex = 0;
                    txtKasaAd.Focus(); txtKasaAd.Select();
                    return;
                }
                if (_YeniKayit && Isler.Kasa.Varmi_KasaAd(txtKasaAd.Text))
                {
                    XtraMessageBox.Show("Bu Kasa Adı Daha Önce Tanımlanmış.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKasaAd.Focus(); txtKasaAd.Select();
                    return;
                }
                else if (!_YeniKayit && txtKasaAd.Text != ks.KasaAd && Isler.Kasa.Varmi_KasaAd(txtKasaAd.Text, ks.KasaAd))
                {
                    XtraMessageBox.Show("Bu Kasa Adı Daha Önce Tanımlanmış.", "Aynı Değer",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKasaAd.Focus(); txtKasaAd.Select();
                    return;
                }
                #endregion

                if (_YeniKayit)
                {
                    if (ks != null && ks.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(ks);
                    }
                    ks = null;
                    ks = new kasa();
                    ks.SirketID = Genel.AktifSirket.SirketID;
                }

                #region Aktarma
                ks.KasaAd = txtKasaAd.Text;
                ks.Durum = chkDurum.Checked;
                ks.Aciklama = memoAciklama.Text;
                #endregion

                #region Kayıt
                if (_YeniKayit)
                {
                    ks.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    ks.KayitZaman = DateTime.Now;
                    dbModel.AddTokasas(ks);
                }
                else
                {
                    ks.DuzenKullaniciID = Genel.AktifKullanici.DuzenKullaniciID;
                    ks.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();
                _Secili_KasaID = ks.KasaID;
                txtKasaID.Text = ks.KasaID.ToString();

                _YeniKayit = false;

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Kasa Başarılı Bir Şekilde Kaydedilmiştir.", null,
                   ResOtoSis.mark_blue);

                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.Kaydedildi, null);
                }
                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                }

                pageKasaHareketleri.PageEnabled = true;
                #endregion
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kasa Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Yeni()
        {
            _YeniKayit = true;

            Temizle_Kasa();
            tabKasa.SelectedTabPageIndex = 0;
            pageKasaHareketleri.PageEnabled = false;
            txtKasaAd.Focus(); txtKasaAd.Select();
        }

        void Temizle_Kasa()
        {
            txtKasaAd.Text = txtKasaID.Text = memoAciklama.Text = "";

            chkDurum.Checked = true;
        }

        void Ara()
        {
            try
            {
                _Yukleme = true;

                if (dt_Kasalar != null)
                    dt_Kasalar.Dispose();
                dt_Kasalar = null;

                dt_Kasalar = Isler.Kasa.Ver_Kasalar();
                gridControlKasa.DataSource = dt_Kasalar;
                GridViewKasa.ViewCaption = "Kasalar Listesi (" + dt_Kasalar.Rows.Count.ToString() + " )";

                bool Bulundu = false;
                if (dt_Kasalar.Rows.Count > 0)
                {
                    int temp_KasaID = 0;
                    for (int i = 0; i < GridViewKasa.RowCount; i++)
                    {
                        temp_KasaID = Convert.ToInt32(GridViewKasa.GetDataRow(i)["KasaID"]);
                        if (temp_KasaID == _Secili_KasaID)
                        {
                            GridViewKasa.FocusedRowHandle = i;
                            Bulundu = true;
                            break;
                        }
                    }

                    _Yukleme = false;
                    if (!Bulundu)
                    {
                        Yukle_Kasa(Convert.ToInt32(GridViewKasa.GetDataRow(0)["KasaID"]));
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
                XtraMessageBox.Show("Kasalar Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Focus_Kasa()
        {
            if (_Yukleme || GridViewKasa.GetFocusedDataRow() == null) return;

            Yukle_Kasa(Convert.ToInt32(GridViewKasa.GetFocusedRowCellValue("KasaID")));
        }
        #endregion

        private void tabKasa_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabKasa.SelectedTabPage == pageKasaHareketleri)
            {
                ucKasaHareket1.Ara_KasaHareketleri(ks.KasaID);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara();
        }
    }
}