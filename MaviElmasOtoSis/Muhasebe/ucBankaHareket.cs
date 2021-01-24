using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class ucBankaHareket : Sistem.ucBase
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        banka_hareket bh;

        DataTable dt_BankaHareketler;

        decimal Yatan = 0;
        decimal Cekilen = 0;
        decimal Bakiye = 0;
        #endregion

        #region < Özellikler >
        public int BankaID { get; set; }
        #endregion

        #region < Load >
        public ucBankaHareket()
        {
            InitializeComponent();

            if (this.IsInDesignMode) return;


            try
            {
                dateKayitBas.EditValue = Araclar.TarihSaat.Ver_AyinBasi(DateTime.Now);
                dateKayitBit.EditValue = DateTime.Now;

                dbModel = new otosisdbEntities(VeriYonetimi.Baglanti.BaglantiEntity);

                ucGelirGiderDemo1.Temizle_GelirGider();
                ucPersonelDemo1.Temizle_Personel();

                gridViewBankaHareket.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
                gridViewBankaHareket.OptionsView.ColumnAutoWidth = false;

                gridControlBankaHareket.ForceInitialize();
                gridViewBankaHareket.BestFitColumns();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kasa Hareketi Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region < Olaylar >
        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara_BankaHareket(BankaID);
        }

        private void drpIslemTuru_Click(object sender, EventArgs e)
        {
            drpIslemTuru.ContextMenuStrip.Show(drpIslemTuru, new Point(0, 23));
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil_BankaHareket();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet_BankaHareket();
        }
        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            Yeni_BankaHareket();
        }

        private void btnGelirFisi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem(Enumlar.IslemTurleri.BankaGelirFisi);
        }
        private void btnGiderFisi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem(Enumlar.IslemTurleri.BankaGiderFisi);
        }
        private void btnPersonelMaasOdemesi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem(Enumlar.IslemTurleri.PersonelMaasOdemesi);
        }
        private void btnPersonelAvansOdemesi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem(Enumlar.IslemTurleri.PersonelAvansOdemesi);
        }
        private void btnPersonelAgiOdemesi_Click(object sender, EventArgs e)
        {
            Ayarla_Islem(Enumlar.IslemTurleri.PersonelAgiOdemesi);
        }

        private void btnCariOdeme_Click(object sender, EventArgs e)
        {
            Ayarla_Islem(Enumlar.IslemTurleri.BankaCariyeOdenen);
        }
        private void btnCariTahsilat_Click(object sender, EventArgs e)
        {
            Ayarla_Islem(Enumlar.IslemTurleri.BankaCariTahsilat);
        }

        private void gridViewBankaHareket_Click(object sender, EventArgs e)
        {
            gridViewBankaHareket.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (gridViewBankaHareket.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_BankaHareket();
            }
            _Focusta = false;
        }
        private void gridViewBankaHareket_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewBankaHareket.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_BankaHareket();
        }
        #endregion

        #region < Metod >
        public void Ara_BankaHareket(int _BankaID)
        {
            try
            {
                BankaID = _BankaID;

                Yatan = Cekilen = Bakiye = 0;

                if (dt_BankaHareketler != null)
                    dt_BankaHareketler.Dispose();

                dt_BankaHareketler = Isler.Banka.Ver_BankaHareketler(_BankaID, Araclar.TarihSaat.Ver_BaslangicTarih(Convert.ToDateTime(dateKayitBas.EditValue))
                    , Araclar.TarihSaat.Ver_BitisTarih(Convert.ToDateTime(dateKayitBit.EditValue)));
                gridControlBankaHareket.DataSource = dt_BankaHareketler;

                for (int i = 0; i < dt_BankaHareketler.Rows.Count; i++)
                {
                    if (dt_BankaHareketler.Rows[i]["YatanTutar"] != DBNull.Value)
                        Yatan += Convert.ToDecimal(dt_BankaHareketler.Rows[i]["YatanTutar"]);

                    if (dt_BankaHareketler.Rows[i]["CekilenTutar"] != DBNull.Value)
                        Cekilen += Convert.ToDecimal(dt_BankaHareketler.Rows[i]["CekilenTutar"]);
                }

                Bakiye = Math.Round(Math.Round(Yatan, 2) - Math.Round(Cekilen, 2), 2);

                lblCekilen.Text = Cekilen.ToString();
                lblYatan.Text = Yatan.ToString();
                lblBakiye.Text = Bakiye.ToString();

                Yeni_BankaHareket();
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        void Yukle_BankaHareket(int _ID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_BankaHareket();

                if (bh != null && bh.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(bh);
                }
                bh = null;
                bh = Isler.Banka.Ver_BankaHareket(ref dbModel, _ID);
                if (bh == null) return;

                txtEvrakNo.Text = bh.EvrakNo;
                lblHareketNo.Text = bh.ID.ToString();
                Ayarla_Islem((Enumlar.IslemTurleri)Convert.ToInt32(bh.IslemTuru));
                memoAciklama.Text = bh.Aciklama;
                spinMiktar.Value = bh.Miktar;
                dateEvrakTarih.EditValue = bh.EvrakTarih;

                if (bh.GelirGiderID != null)
                {
                    ucGelirGiderDemo1.Yukle_GelirGider(bh.GelirGiderID.Value);
                }
                if (bh.PersonelID != null)
                {
                    ucPersonelDemo1.Yukle_Personel(bh.PersonelID.Value);
                }
                if (bh.CariID != null)
                {
                    ucCariHesapDemo1.Yukle_Cari(bh.CariID.Value);
                }

                ucKayitBilgi1.Yukle(bh.KayitKullaniciID, bh.KayitZaman);

                btnKaydet.Enabled = false;
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        void Sil_BankaHareket()
        {
            if (bh == null || !Isler.Yetki.Varmi_Yetki(78)) return;

            try
            {
                if (XtraMessageBox.Show("Seçili Banka Hereketini Silmek İstediğinize Emin Misiniz?\n", "Banka Hareketi Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(bh);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Banka Hereketi Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    Ara_BankaHareket(BankaID);
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kasa Hereketi Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Yeni_BankaHareket()
        {
            Temizle_BankaHareket();
            spinMiktar.Focus(); spinMiktar.Select();

            Ayarla_Islem(null);

            btnKaydet.Enabled = true;

            _Focusta = gridViewBankaHareket.OptionsSelection.EnableAppearanceFocusedRow = false;
        }
        void Kaydet_BankaHareket()
        {
            try
            {
                if (!Isler.Yetki.Varmi_Yetki(77)) return;

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

                Enumlar.IslemTurleri temp_islemturu = (Enumlar.IslemTurleri)drpIslemTuru.Tag;

                if (ucGelirGiderDemo1.Secili_GelirGiderID <= 0 && (temp_islemturu == Enumlar.IslemTurleri.BankaGiderFisi || temp_islemturu == Enumlar.IslemTurleri.BankaGelirFisi))
                {
                    XtraMessageBox.Show("Lütfen İşlem Yapılacak Geliri/Gideri Seçiniz.", "Gelir/Gider Seçilmedi",
                             MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucGelirGiderDemo1.Focus(); ucGelirGiderDemo1.Select();
                    return;
                }
                if (ucPersonelDemo1.Secili_PersonelID <= 0
                    && (temp_islemturu == Enumlar.IslemTurleri.PersonelAgiOdemesi || temp_islemturu == Enumlar.IslemTurleri.PersonelAvansOdemesi || temp_islemturu == Enumlar.IslemTurleri.PersonelMaasOdemesi))
                {
                    XtraMessageBox.Show("Lütfen İşlem Yapılacak Personeli Seçiniz.", "Personel Seçilmedi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucGelirGiderDemo1.Focus(); ucGelirGiderDemo1.Select();
                    return;
                }
                if ((temp_islemturu == Enumlar.IslemTurleri.BankaCariyeOdenen || temp_islemturu == Enumlar.IslemTurleri.BankaCariTahsilat) && ucCariHesapDemo1.Secili_CariID <= 0)
                {
                    XtraMessageBox.Show("Lütfen İşlem Yapılacak Cariyi Seçiniz.", "Cari Seçilmedi",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucCariHesapDemo1.Focus(); ucCariHesapDemo1.Select();
                    return;
                }
                #endregion

                #region Aktarma - Kayıt
                int? temp_GelirGiderID = null;
                int? temp_PersonelID = null;
                int? temp_CariID = null;
                DateTime? temp_EvrakTarih = null;

                int? temp_BankaHareketID = null;

                if (dateEvrakTarih.EditValue != null)
                {
                    temp_EvrakTarih = Convert.ToDateTime(dateEvrakTarih.EditValue);
                }

                if (temp_islemturu == Enumlar.IslemTurleri.BankaGelirFisi || temp_islemturu == Enumlar.IslemTurleri.BankaGiderFisi)
                {
                    temp_GelirGiderID = ucGelirGiderDemo1.Secili_GelirGiderID;
                }
                else if (temp_islemturu == Enumlar.IslemTurleri.PersonelMaasOdemesi || temp_islemturu == Enumlar.IslemTurleri.PersonelAvansOdemesi || temp_islemturu == Enumlar.IslemTurleri.PersonelAgiOdemesi)
                {
                    temp_PersonelID = ucPersonelDemo1.Secili_PersonelID;
                }
                else if (temp_islemturu == Enumlar.IslemTurleri.BankaCariTahsilat || temp_islemturu == Enumlar.IslemTurleri.BankaCariyeOdenen)
                {
                    temp_CariID = ucCariHesapDemo1.Secili_CariID;
                }


                temp_BankaHareketID = Isler.Banka.Ekle_BankaHareket(BankaID, spinMiktar.Value, temp_islemturu == Enumlar.IslemTurleri.BankaGelirFisi ? true : false,
                       temp_islemturu, temp_GelirGiderID, temp_PersonelID
                       , temp_CariID, null, null, txtEvrakNo.Text, memoAciklama.Text, temp_EvrakTarih);
                #endregion

                #region Diğer Kayıtlar
                if (temp_islemturu == Enumlar.IslemTurleri.PersonelAgiOdemesi || temp_islemturu == Enumlar.IslemTurleri.PersonelAvansOdemesi
                    || temp_islemturu == Enumlar.IslemTurleri.PersonelMaasOdemesi)
                {
                    Isler.Personel.Ekle_PersonelHareket(ucPersonelDemo1.Secili_PersonelID, spinMiktar.Value, true, temp_islemturu,
                        BankaID, null, memoAciklama.Text, txtEvrakNo.Text, temp_EvrakTarih, temp_BankaHareketID,null);
                }
                else if (temp_islemturu == Enumlar.IslemTurleri.BankaGelirFisi || temp_islemturu == Enumlar.IslemTurleri.BankaGiderFisi)
                {
                    Isler.GelirGider.Ekle_GelirGiderHareket(ucGelirGiderDemo1.Secili_GelirGiderID, spinMiktar.Value,
                        temp_islemturu == Enumlar.IslemTurleri.BankaGiderFisi ? true : false, temp_islemturu, BankaID, null,
                        txtEvrakNo.Text, memoAciklama.Text, temp_EvrakTarih, temp_BankaHareketID,null);
                }
                else if (temp_islemturu == Enumlar.IslemTurleri.BankaCariTahsilat || temp_islemturu == Enumlar.IslemTurleri.BankaCariyeOdenen)
                {
                    Isler.Cari.Ekle_CariHareket(ucCariHesapDemo1.Secili_CariID, spinMiktar.Value,
                        temp_islemturu == Enumlar.IslemTurleri.BankaCariyeOdenen ? true : false, temp_islemturu, null, BankaID, null,
                        txtEvrakNo.Text, memoAciklama.Text, temp_EvrakTarih, temp_BankaHareketID,null);
                }
                #endregion

                Ara_BankaHareket(BankaID);

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Banka İşlemi Başarılı Bir Şekilde Kaydedilmiştir.", null,
                 ResOtoSis.mark_blue);
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        void Temizle_BankaHareket()
        {
            txtEvrakNo.Text = memoAciklama.Text = lblHareketNo.Text = null;

            dateEvrakTarih.EditValue = null;

            spinMiktar.Value = 0;

            ucGelirGiderDemo1.Temizle_GelirGider();
            ucPersonelDemo1.Temizle_Personel();
            ucCariHesapDemo1.Temizle_Cari();

            ucKayitBilgi1.Temizle();

            ucCariHesapDemo1.Visible = ucPersonelDemo1.Visible = ucGelirGiderDemo1.Visible = false;
        }

        void Focus_BankaHareket()
        {
            if (_Yukleme || gridViewBankaHareket.GetFocusedDataRow() == null) return;

            Yukle_BankaHareket(Convert.ToInt32(gridViewBankaHareket.GetFocusedRowCellValue("ID")));
        }

        void Ayarla_Islem(Enumlar.IslemTurleri? IslemTuru)
        {
            if (IslemTuru == null)
            {
                drpIslemTuru.Tag = null;
                drpIslemTuru.Text = "Lütfen Seçiniz";

                ucGelirGiderDemo1.Visible = ucPersonelDemo1.Visible = ucCariHesapDemo1.Visible = false;
                return;
            }
            else
            {
                drpIslemTuru.Tag = IslemTuru.Value;
            }

            switch (IslemTuru.Value)
            {
                case Enumlar.IslemTurleri.BankaGelirFisi:
                    drpIslemTuru.Text = "Banka Gelir Fişi";
                    break;
                case Enumlar.IslemTurleri.BankaGiderFisi:
                    drpIslemTuru.Text = "Banka Gider Fişi";
                    break;
                case Enumlar.IslemTurleri.PersonelMaasOdemesi:
                    drpIslemTuru.Text = "Personel Maaş Ödemesi";
                    break;
                case Enumlar.IslemTurleri.PersonelAvansOdemesi:
                    drpIslemTuru.Text = "Personel Avans Ödemesi";
                    break;
                case Enumlar.IslemTurleri.PersonelAgiOdemesi:
                    drpIslemTuru.Text = "Personel AGİ Ödemesi";
                    break;
                case Enumlar.IslemTurleri.BankaCariyeOdenen:
                    drpIslemTuru.Text = "Cari Ödeme";
                    break;
                case Enumlar.IslemTurleri.BankaCariTahsilat:
                    drpIslemTuru.Text = "Cari Tahsilat";
                    break;
            }

            if (IslemTuru.Value == Enumlar.IslemTurleri.BankaGelirFisi || IslemTuru.Value == Enumlar.IslemTurleri.BankaGiderFisi)
            {
                ucPersonelDemo1.Visible = ucCariHesapDemo1.Visible = false;
                ucGelirGiderDemo1.Visible =  true;

                ucGelirGiderDemo1.Location = ucPersonelDemo1.Location;
            }
            else if (IslemTuru.Value == Enumlar.IslemTurleri.PersonelAgiOdemesi || IslemTuru.Value == Enumlar.IslemTurleri.PersonelAvansOdemesi || IslemTuru.Value == Enumlar.IslemTurleri.PersonelMaasOdemesi)
            {
                ucPersonelDemo1.Visible = true;
                ucGelirGiderDemo1.Visible = ucCariHesapDemo1.Visible = false;
            }
            else if (IslemTuru.Value == Enumlar.IslemTurleri.BankaCariTahsilat || IslemTuru.Value == Enumlar.IslemTurleri.BankaCariyeOdenen)
            {
                ucCariHesapDemo1.Visible = true;
                ucPersonelDemo1.Visible = ucGelirGiderDemo1.Visible = false;

                ucCariHesapDemo1.Location = ucPersonelDemo1.Location;
            }
        }
        #endregion
    }
}