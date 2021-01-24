using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Tanim
{
    public partial class ucMarkaModel : Sistem.ucBase
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        araba_marka marka;
        araba_model model;

        bool YeniKayit = true;
        bool YeniKayitModel = true;

        int Secili_MarkID;

        DataTable dt_Modeller;
        #endregion

        #region < Load >
        public ucMarkaModel()
        {
            InitializeComponent();
        }

        private void ucMarkaModel_Load(object sender, EventArgs e)
        {
            try
            {
                _Yukleme = true;
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                Temizle_Ara();
                Temizle_Detay();
                Ara(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Marka / Modeller Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle_Ara();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Ara(true);
        }

        private void btnModelSil_Click(object sender, EventArgs e)
        {
            Sil_Model();
        }
        private void btnModelYeniKayit_Click(object sender, EventArgs e)
        {
            Yeni_Model();
        }
        private void btnModelKaydet_Click(object sender, EventArgs e)
        {
            Kaydet_Model();
        }

        private void GridViewMarkalar_Click(object sender, EventArgs e)
        {
            GridViewMarkalar.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewMarkalar.GetFocusedDataRow() != null && !Focusta)
            {
                Focus_Marka();
            }
            _Focusta = false;
        }
        private void GridViewMarkalar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewMarkalar.OptionsSelection.EnableAppearanceFocusedRow = true;
            _Focusta = true;
            Focus_Marka();
        }

        private void gridViewModeller_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Focus_Model();
        }
        private void gridViewModeller_Click(object sender, EventArgs e)
        {
            Focus_Model();
        }
        private void txtModelAdi_KeyDown(object sender, KeyEventArgs e)
          {
            if (e.KeyCode == Keys.Enter)
            {
                Kaydet_Model();   
            }
        }

        private void txtMarkaAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Kaydet();
            }
        }
        #endregion

        #region < Metod >
        void Ara(bool Yeniden)
        {
            try
            {
                _Yukleme = true;

                if (Yeniden || Genel.dt_Markalar == null)
                {
                    Genel.dt_Markalar = null;
                    Genel.dt_Markalar = Isler.MarkaModel.Ver_Markalar(txtAraMarkaAdi.Text, txtAraModelAdi.Text);
                }


                gridControlMarkalar.DataSource = Genel.dt_Markalar;
                GridViewMarkalar.ViewCaption = "Araba Markaları (" + Genel.dt_Markalar.Rows.Count.ToString() + ")";

                _Yukleme = false;

                if (Genel.dt_Markalar.Rows.Count > 0)
                {
                    btnSil.Enabled = true;
                }
                else
                {
                    btnSil.Enabled = false;
                }

                Yeni();
                _Focusta = GridViewMarkalar.OptionsSelection.EnableAppearanceFocusedRow = false;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Araba Markaları Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        void Ara_Modeller(int _MarkaID)
        {
            if (_Yukleme) return;

            try
            {
                if (dt_Modeller != null)
                    dt_Modeller.Dispose();
                dt_Modeller = null;

                dt_Modeller = Isler.MarkaModel.Ver_Modeller(_MarkaID);
                gridControlModeller.DataSource = dt_Modeller;
                gridViewModeller.ViewCaption = "Markaya Ait Modeller (" + dt_Modeller.Rows.Count.ToString() + ")";

                if (gridViewModeller.RowCount > 0)
                {
                    btnModelSil.Enabled = true;

                    //Yukle_Model(Convert.ToInt32(gridViewModeller.GetDataRow(0)["ModelID"]));
                }
                else
                {
                    btnModelSil.Enabled = false;                   
                }

                Yeni_Model();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Markaya Ait Modeller Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Yukle_Marka(int _MarkaID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_Detay();
                YeniKayit = false;

                if (marka != null && marka.EntityState!=EntityState.Detached)
                {
                    dbModel.Detach(marka);
                }
                marka = null;
                marka = Isler.MarkaModel.Ver_ArabaMarka(ref dbModel, _MarkaID);
                if (marka == null) return;
                Secili_MarkID = marka.MarkaID;

                txtMarkaAdi.Text = marka.MarkaAdi;
                txtWeb.Text = marka.Web;
                txtEposta.Text = marka.Email;

                groupModelBilgileri.Enabled = true;
                Ara_Modeller(marka.MarkaID);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Marka Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Yukle_Model(int _ModelID)
        {
            if (_Yukleme) return;

            try
            {
                txtModelAdi.Text = "";
                YeniKayitModel = false;

                if (model != null && model.EntityState!=EntityState.Detached)
                {
                    dbModel.Detach(model);
                }
                model = null;
                model = Isler.MarkaModel.Ver_ArabaModel(ref dbModel, _ModelID);
                if (model == null) return;

                txtModelAdi.Text = model.ModelAdi;

                 gridViewModeller.OptionsSelection.EnableAppearanceFocusedRow = true;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Model Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Focus_Marka()
        {
            if (_Yukleme || GridViewMarkalar.GetFocusedDataRow() == null) return;

            Secili_MarkID = Convert.ToInt32(GridViewMarkalar.GetFocusedRowCellValue("MarkaID"));
            YeniKayit = false;

            Yukle_Marka(Secili_MarkID);
        }
        void Focus_Model()
        {
            if (_Yukleme || gridViewModeller.GetFocusedDataRow() == null) return;

            Yukle_Model(Convert.ToInt32(gridViewModeller.GetFocusedRowCellValue("ModelID")));
        }

        void Sil()
        {
            if (GridViewMarkalar.GetFocusedDataRow() == null) return;

            try
            {
                string temp_markaadi = GridViewMarkalar.GetFocusedDataRow()["MarkaAdi"].ToString();

                if (XtraMessageBox.Show("Seçili Araç Markasını Silmek İstediğinize Emin Misiniz?\n"
                   + "Marka Adı : " + temp_markaadi
                   + "\n\nNot: Markaya bağlı modeller sistemden silinecek.", "Marka ve Modellerini Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(marka);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Marka ve Modelleri Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    Ara(true);
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Marka Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Yeni()
        {
            YeniKayit = true;

            groupModelBilgileri.Enabled = false;
            Temizle_Detay();

            txtMarkaAdi.Focus(); txtMarkaAdi.Select();

            _Focusta = GridViewMarkalar.OptionsSelection.EnableAppearanceFocusedRow = false;
        }
        void Kaydet()
        {
            try
            {
                if (string.IsNullOrEmpty(txtMarkaAdi.Text))
                {
                    XtraMessageBox.Show("Marka Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMarkaAdi.Focus(); txtMarkaAdi.Select();
                    return;
                }
                if (YeniKayit && Isler.MarkaModel.Varmi_Marka(txtMarkaAdi.Text.Trim()))
                {
                    XtraMessageBox.Show("Bu Marka Adı Daha Önce Girilmiş.\nLütfen Farklı Bir Marka Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMarkaAdi.Focus(); txtMarkaAdi.Select();
                    return;
                }
                else if (!YeniKayit && txtMarkaAdi.Text != marka.MarkaAdi && Isler.MarkaModel.Varmi_Marka(txtMarkaAdi.Text,marka.MarkaAdi))
                {
                    XtraMessageBox.Show("Bu Marka Adı Daha Önce Girilmiş.\nLütfen Farklı Bir Marka Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMarkaAdi.Focus(); txtMarkaAdi.Select();
                    return;
                }

                if (YeniKayit)
                {
                    marka = new araba_marka();
                }

                marka.MarkaAdi = txtMarkaAdi.Text;
                marka.Web = txtWeb.Text;
                marka.Email = txtEposta.Text;

                if (YeniKayit)
                {
                    dbModel.AddToaraba_marka(marka);
                }
                dbModel.SaveChanges();

                Temizle_Ara();
                Ara(true);

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Marka Başarılı Bir Şekilde Kaydedilmiştir.", null,
                    ResOtoSis.mark_blue);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Marka Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Kaydet_Model()
        {
            try
            {
                #region Kontroller
                if (string.IsNullOrEmpty(txtModelAdi.Text.Trim()))
                {
                    XtraMessageBox.Show("Model Adı Boş Bırakılamaz.", "Eksik Alan",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtModelAdi.Focus(); txtModelAdi.Select();
                    return;
                }
                if (YeniKayitModel && Isler.MarkaModel.Varmi_Model(marka.MarkaID, txtModelAdi.Text.Trim()))
                {
                    XtraMessageBox.Show("Bu Model Adı Daha Önce Bu Markaya Eklenmiş\nLütfen Farklı Bir Model Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtModelAdi.Focus(); txtModelAdi.Select();
                    return;
                }
                else if (!YeniKayitModel && txtModelAdi.Text != model.ModelAdi && Isler.MarkaModel.Varmi_Model(marka.MarkaID, txtModelAdi.Text, model.ModelAdi))
                {
                    XtraMessageBox.Show("Bu Model Adı Daha Önce Bu Markaya Eklenmiş\nLütfen Farklı Bir Model Adı Yazınız.", "Aynı Değer",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtModelAdi.Focus(); txtModelAdi.Select();
                    return;
                }
                #endregion

                if (YeniKayitModel)
                {
                    model = new araba_model();
                    model.MarkaID = marka.MarkaID;
                }

                model.ModelAdi = txtModelAdi.Text;

                if (YeniKayitModel)
                {
                    dbModel.AddToaraba_model(model);
                }
                dbModel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Model Başarılı Bir Şekilde Kaydedilmiştir.", null,
                    ResOtoSis.mark_blue);

                txtModelAdi.Text = "";
                Ara_Modeller(marka.MarkaID);

                Yeni_Model();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Model Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Sil_Model()
        {
            if (gridViewModeller.GetFocusedDataRow() == null) return;

            try
            {
                string temp_modeladi = gridViewModeller.GetFocusedDataRow()["ModelAdi"].ToString();

                if (XtraMessageBox.Show("Seçili Modeli Silmek İstediğinize Emin Misiniz?\n\n"
                  + "Model Adı : " + temp_modeladi, "Model Sil Onay",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(model);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Model Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    Ara_Modeller(marka.MarkaID);
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Model Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Yeni_Model()
        {
            YeniKayitModel = true;

            txtModelAdi.Text = "";

            txtModelAdi.Focus(); txtModelAdi.Select();

            gridViewModeller.OptionsSelection.EnableAppearanceFocusedRow = false;
        }

        void Temizle_Ara()
        {
            txtAraMarkaAdi.Text = txtAraModelAdi.Text = "";
        }

        void Temizle_Detay()
        {
            txtMarkaAdi.Text = txtWeb.Text = txtEposta.Text = txtModelAdi.Text = "";
        }
        #endregion
    }
}