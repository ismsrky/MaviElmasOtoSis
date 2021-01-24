using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Stok
{
    public partial class frmStokTahsisi : Sistem.frmBase
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;

        stok_hareket hareket;
        #endregion

        #region < Load >
        public frmStokTahsisi()
        {
            InitializeComponent();

            this.Text = "Stok Tahsisi";
        }

        private void frmStokHareketEkle_Load(object sender, EventArgs e)
        {
            try
            {
                dbModel = new otosisdbEntities(VeriYonetimi.Baglanti.BaglantiEntity);

                #region databind
                lookUpDepolar.Properties.DisplayMember = "DepoAd";
                lookUpDepolar.Properties.ValueMember = "DepoID";
                lookUpDepolar.Properties.DataSource = Genel.dt_DepolarSecim.Copy();
                #endregion

                ucStokKartDemo1.Temizle_Kart();
                Temizle_StokTahsis();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Tahsisi Ekleme Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region < Olaylar >
        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }
        #endregion

        #region < Metod >
        void Temizle_StokTahsis()
        {
            radioGroup1.SelectedIndex = 0;
            spinMiktar.EditValue = 0;
            memoAciklama.Text = "";

            lookUpDepolar.EditValue = Genel.AktifDepo.DepoID;
        }

        void Kaydet()
        {
            try
            {
                #region Kontroller
                if (spinMiktar.Value == 0)
                {
                    XtraMessageBox.Show("Lütfen Tahsis Miktarını 0'dan Büyük Bir Değer Giriniz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    spinMiktar.Focus(); spinMiktar.Select();
                    return;
                }
                if (ucStokKartDemo1.Secili_KartID<=0)
                {
                    XtraMessageBox.Show("Lütfen Stok Tahsis Yapılacak Stok Kalemini Seçiniz.", "Eksik Alan",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucStokKartDemo1.Focus(); ucStokKartDemo1.Select();
                    return;
                }
                int temp_DepoID = Convert.ToInt32(lookUpDepolar.EditValue);
                if (radioGroup1.SelectedIndex == 1 && !Genel.Varmi_Stokta(ucStokKartDemo1.Secili_KartID, temp_DepoID, spinMiktar.Value))
                {
                    return;
                }
                if (string.IsNullOrEmpty(memoAciklama.Text.Trim()))
                {
                    XtraMessageBox.Show("Stok Tahsisi Eklerken Açıklama Girilmesi Zorunludur.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    memoAciklama.Focus(); memoAciklama.Select();
                    return;
                }
                if (XtraMessageBox.Show("Stok Tahsis Eklemek İstediğinize Emin Misiniz?", "Kayıt Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                #endregion

                #region Aktarma - Kayıt
                if (hareket != null && hareket.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(hareket);
                }
                hareket = null;
                hareket = new stok_hareket();

                if (radioGroup1.SelectedIndex == 0)
                {
                    hareket.Giris = true;
                }
                else
                {
                    hareket.Giris = false;
                }

                hareket.Aciklama = memoAciklama.Text;
                hareket.StokKartID = ucStokKartDemo1 .Secili_KartID;
                hareket.StokHareketTipi = ((int)Enumlar.StokHareketTipleri.StokTahsisi).ToString();
                hareket.Miktar = spinMiktar.Value;
                hareket.DepoID = temp_DepoID;
                hareket.ParcaNo = ucStokKartDemo1.sk.ParcaNo;

                hareket.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                hareket.KayitZaman = DateTime.Now;

                dbModel.AddTostok_hareket(hareket);
                dbModel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Stok Tahsisi Başarılı Bir Şekilde Eklenmiştir.", null,
                    ResOtoSis.mark_blue);
                #endregion

                if (XtraMessageBox.Show("Başka Stok Tahsis İşlemi Yapmak İstiyor Musunuz?", "Başka İşlem Yapılacak Mı?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    ucStokKartDemo1.Temizle_Kart();
                    Temizle_StokTahsis();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Tahsisi Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}