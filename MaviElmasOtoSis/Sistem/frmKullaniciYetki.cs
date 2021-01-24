using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Sistem
{
    public partial class frmKullaniciYetki : DevExpress.XtraEditors.XtraForm
    {
        #region < Değişkenler >
        DataTable dt_Yetkiler;
        #endregion

        #region < Özellikler >
        public int KullaniciID { get; set; }
        #endregion

        #region < Load >
        public frmKullaniciYetki()
        {
            KullaniciID = 0;
            InitializeComponent();

            this.Text = "Kullanıcı Yetkileri";
        }

        private void frmKullaniciYetki_Load(object sender, EventArgs e)
        {
            try
            {
                #region Veri Bağlama
                lookUpKullanicilar.Properties.DisplayMember = "KullaniciAd";
                lookUpKullanicilar.Properties.ValueMember = "KullaniciID";
                lookUpKullanicilar.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Isler.Kullanici.Ver_Kullanicilar(), "KullaniciAd", "KullaniciID");
                lookUpKullanicilar.EditValue = -1;
                #endregion

                if (KullaniciID != 0)
                {
                    lookUpKullanicilar.EditValue = KullaniciID;
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kullanıcı Yetkileri Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region < Olaylar >
        private void lookUpKullanicilar_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpKullanicilar.EditValue == null || lookUpKullanicilar.EditValue.ToString() == "-1")
            {
                pEnable(false);
                return;
            }

            Ara_Yetkiler();

            pEnable(true);

            KullaniciID = Convert.ToInt32(lookUpKullanicilar.EditValue);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!Genel.Yetkilerim.Contains(30))
            {
                Genel.Yetki_Uyari(30);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                int temp_KullaniciID = Convert.ToInt32(lookUpKullanicilar.EditValue);

                Isler.Yetki.Sil_KullaniciYetki(temp_KullaniciID);
                Isler.Yetki.Ekle_KullaniciYetki(dt_Yetkiler, temp_KullaniciID);

                XtraMessageBox.Show("Yetkiler Başarılı Bir Şekilde Kullanıcıya Atanmıştır.", "İşlem Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Cursor = Cursors.Default;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Yetkiler Kullanıcıya Atanırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region < Metod >
        void Ara_Yetkiler()
        {
            try
            {
                if (lookUpKullanicilar.EditValue == null || lookUpKullanicilar.EditValue.ToString() == "-1") return;

                dt_Yetkiler = null;

                dt_Yetkiler = Isler.Yetki.Ver_Yetkiler_KullaniciyaGore(Convert.ToInt32(lookUpKullanicilar.EditValue), true);

                gridControlYetkiler.DataSource = dt_Yetkiler;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Kullanıcı Yetkileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void pEnable(bool deger)
        {
            gridControlYetkiler.Enabled = btnKaydet.Enabled = deger;
        }
        #endregion
    }
}