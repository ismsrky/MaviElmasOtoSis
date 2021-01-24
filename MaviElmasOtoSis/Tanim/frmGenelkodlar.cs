using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Tanim
{
    public partial class frmGenelkodlar : Sistem.frmBase
    {
        #region < Değişkenler >
        genelkodlar genelkod;
        otosisdbEntities dbmodel;

        bool YeniKayit = true;

        int Secili_ID;
        string Secili_Kod;

        DataTable dt_Tanimlamalar;
        #endregion

        #region < Özellikler >
        public List<string> Gruplar { get; set; }
        public string Baslik { get; set; }
        #endregion

        #region < Load >
        public frmGenelkodlar()
        {
            Gruplar = new List<string>();

            InitializeComponent();
        }

        private void frmGenelkodlar_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;

                dbmodel = new otosisdbEntities(Baglanti.BaglantiEntity);

                this.Text = Baslik;

                cmbGruplar.Properties.Items.Add("Lütfen Seçiniz");
                foreach (string item in Gruplar)
                {
                    cmbGruplar.Properties.Items.Add(item);
                }
                cmbGruplar.SelectedIndex = 0;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Tanımlamalar Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }

        private void frmGenelkodlar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        #endregion

        #region < Olaylar >
        private void cmbGruplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ara();
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

        private void gridViewTanimlamalar_Click(object sender, EventArgs e)
        {
            Focus_Tanimlama();
        }
        private void gridViewTanimlamalar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Focus_Tanimlama();
        }
        #endregion

        #region < Metod >
        void Ara()
        {
            try
            {
                if (_Yukleme || cmbGruplar.SelectedIndex <= 0)
                {
                    pEnable(false);
                    return;
                }

                pEnable(true);

                string Secili_item = cmbGruplar.Text;


                dt_Tanimlamalar = null;
                dt_Tanimlamalar = Isler.Genelkodlar.Ver_Kod(Secili_item, null);

                gridControlTanimlamalar.DataSource = dt_Tanimlamalar;

                if (gridViewTanimlamalar.RowCount > 0)
                {
                    bool Bulundu = false;
                    for (int i = 0; i < gridViewTanimlamalar.RowCount; i++)
                    {
                        if (Convert.ToInt32(gridViewTanimlamalar.GetDataRow(i)["ID"]) == Secili_ID)
                        {
                            gridViewTanimlamalar.FocusedRowHandle = i;
                            Bulundu = true;
                            break;
                        }
                    }

                    if (!Bulundu)
                    {
                        Yukle(Convert.ToInt32(gridViewTanimlamalar.GetDataRow(0)["ID"]));
                    }

                    btnSil.Enabled = true;
                }
                else
                {
                    YeniKayit = true;
                    btnSil.Enabled = false;
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Gruba Ait Tanımlamalar Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Yukle(int _ID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle();
                YeniKayit = false;

                if (genelkod != null && genelkod.EntityState!=EntityState.Detached)
                {
                    dbmodel.Detach(genelkod);
                }
                genelkod = null;
                genelkod = Isler.Genelkodlar.Ver_GenelKod(_ID, ref dbmodel);
                if (genelkod == null) return;

                txtAciklama.Text = genelkod.Aciklama;
                txtKod.Text = genelkod.Kod;
                chkDurum.Checked = genelkod.Durum;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Tanım Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Kaydet()
        {
            try
            {
                #region < Kontroller >
                if (string.IsNullOrEmpty(txtAciklama.Text.Trim()))
                {
                    XtraMessageBox.Show("Açıklama Alanı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAciklama.Focus(); txtAciklama.Select();
                    return;
                }
                if (string.IsNullOrEmpty(txtKod.Text.Trim()))
                {
                    XtraMessageBox.Show("Kod Alanı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKod.Focus(); txtKod.Select();
                    return;
                }
                if (cmbGruplar.SelectedIndex <= 0)
                {
                    XtraMessageBox.Show("Lütfen Tanımlama Grubu Seçiniz.", "Değer Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbGruplar.Focus(); cmbGruplar.Select();
                    return;
                }
                if ((YeniKayit && Isler.Genelkodlar.Varmi_Kod(cmbGruplar.Text, txtKod.Text))
                    || (!YeniKayit && Isler.Genelkodlar.Varmi_Kod(cmbGruplar.Text, txtKod.Text, genelkod.ID)))
                {
                    XtraMessageBox.Show("Bu Kod Daha Önce Girilmiş..", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKod.Focus(); txtKod.Select();
                    return;
                }
                if ((YeniKayit && Isler.Genelkodlar.Varmi_Aciklama(cmbGruplar.Text, txtAciklama.Text))
                   || (!YeniKayit && Isler.Genelkodlar.Varmi_Aciklama(cmbGruplar.Text, txtAciklama.Text, genelkod.ID)))
                {
                    XtraMessageBox.Show("Bu Açıklama Daha Önce Girilmiş..", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKod.Focus(); txtKod.Select();
                    return;
                }

                #endregion

                if (YeniKayit)
                {
                    genelkod = new genelkodlar();
                    genelkod.Duzenlenebilir = true;
                }
                else if(!genelkod.Duzenlenebilir)
                {
                    XtraMessageBox.Show("Seçtiğiniz Kayıt Sistem Kaydıdır ve Kullanıcı Tarafından Düzenlenemez. ", "Geçersiz İşlem",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                #region Aktarma
                genelkod.Aciklama = txtAciklama.Text;
                genelkod.Durum = chkDurum.Checked;
                genelkod.Grup = cmbGruplar.Text;
                genelkod.Kod = txtKod.Text;
                #endregion

                #region Kayıt
                if (YeniKayit)
                {
                    dbmodel.AddTogenelkodlars(genelkod);
                }
                dbmodel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Tanımlama Başarılı Bir Şekilde Kaydedilmiştir.", null,
         ResOtoSis.mark_blue);
                #endregion

                Secili_ID = genelkod.ID;
                Ara();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Tanımlama Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Sil()
        {
            if (gridViewTanimlamalar.GetFocusedDataRow() == null) return;

            try
            {
                if (!genelkod.Duzenlenebilir)
                {
                    XtraMessageBox.Show("Seçtiğiniz Kayıt Sistem Kaydıdır ve Kullanıcı Tarafından Silinemez. ", "Geçersiz İşlem",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string temp_Aciklama = gridViewTanimlamalar.GetFocusedDataRow()["Aciklama"].ToString();
                string temp_Kod = gridViewTanimlamalar.GetFocusedDataRow()["Kod"].ToString();

                if (XtraMessageBox.Show("Seçili Tanımlamayı Silmek İstediğinize Emin Misiniz?\n\nKod No : " + temp_Kod
                    + "\nAçıklama : " + temp_Aciklama, "Tanımlama Sil Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbmodel.DeleteObject(genelkod);
                    dbmodel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Tanımlama Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    Ara();
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Tanımlama Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Yeni()
        {
            YeniKayit = true;
            Temizle();

            int Enbuyuk = EnBuyukKod();
            if (Enbuyuk > 0)
            {
                txtKod.Text = (Enbuyuk + 1).ToString();
            }

            txtAciklama.Focus(); txtAciklama.Select();
        }

        void Focus_Tanimlama()
        {
            if (_Yukleme || gridViewTanimlamalar.GetFocusedDataRow() == null) return;

            Secili_ID = Convert.ToInt32(gridViewTanimlamalar.GetFocusedRowCellValue("ID"));
            Secili_Kod = gridViewTanimlamalar.GetFocusedDataRow()["Kod"].ToString();
            YeniKayit = false;

            Yukle(Secili_ID);
        }

        void Temizle()
        {
            txtAciklama.Text = txtKod.Text = "";
            chkDurum.Checked = true;
        }

        void pEnable(bool deger)
        {
            txtKod.Enabled = txtAciklama.Enabled = chkDurum.Enabled = chkDurum.Enabled = btnKaydet.Enabled = btnSil.Enabled = btnYeniKayit.Enabled
            = gridControlTanimlamalar.Enabled = deger;
        }

        int EnBuyukKod()
        {
            int temp = 0;

            int enBuyukSayi = Int32.MinValue;
            int enBuyukIndex = Int32.MinValue;

            for (int i = 0; i < gridViewTanimlamalar.RowCount; i++)
            {
                if (Araclar.Dogrulama.IsNumeric(gridViewTanimlamalar.GetRowCellValue(i, "Kod").ToString()))
                {
                    temp = Convert.ToInt32(gridViewTanimlamalar.GetRowCellValue(i, "Kod"));

                    if (temp > enBuyukSayi)
                    {
                        enBuyukSayi = temp;
                        enBuyukIndex = i;
                    }
                }
            }

            if (enBuyukIndex != Int32.MinValue)
            {
                return enBuyukSayi;
            }

            return 0;
        }
        #endregion        
    }
}