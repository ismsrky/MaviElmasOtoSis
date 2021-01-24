using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Sistem
{
    public partial class ucKayitBilgi : Sistem.ucBase
    {
        #region < Değişkenler >
        GostermeSekilleri _GostermeSekli = GostermeSekilleri.Hepsi;

        bool _GosterSimge = true;

        public enum GostermeSekilleri
        {
            Hepsi,
            Kaydeden,
            Duzenyelen
        }
        #endregion

        #region < Özellikler >
        public bool GosterSimge
        {
            get
            {
                return _GosterSimge;
            }
            set
            {
                resimModul.Visible = _GosterSimge = value;

                AyarCek();
            }
        }
        public GostermeSekilleri GostermeSekli
        {
            get
            {
                return _GostermeSekli;
            }
            set
            {
                _GostermeSekli = value;

                AyarCek();
            }
        }
        #endregion

        #region < Load >
        public ucKayitBilgi()
        {
            InitializeComponent();

            AyarCek();
        }

        private void ucKayitBilgi_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region < Metodlar >
        public void Yukle(int? KaydedenKullaniciID, DateTime? KaydedilmeZamani, int? DuzenleyenKullanici, DateTime? DuzenlenmeZamani)
        {
            Temizle();

            if (KaydedenKullaniciID != null)
            {
                lblKaydedenKullanici.Text = Isler.Kullanici.Ver_KullaniciAdSoyad(KaydedenKullaniciID.Value);
                lblKaydedilmeZamani.Text = KaydedilmeZamani.Value.ToString("dd.MM.yyyy HH:mm");
            }
            if (DuzenleyenKullanici != null)
            {
                lblDuzenleyenKullanici.Text = Isler.Kullanici.Ver_KullaniciAdSoyad(DuzenleyenKullanici.Value);
                lblDuzenlenmeZamani.Text = DuzenlenmeZamani.Value.ToString("dd.MM.yyyy HH:mm");
            }
        }
        public void Yukle(int KaydedenKullaniciID, DateTime KaydedilmeZamani)
        {
            Yukle(KaydedenKullaniciID, KaydedilmeZamani, null, null);
        }

        public void Temizle()
        {
            lblDuzenlenmeZamani.Text = lblDuzenleyenKullanici.Text = "  -";
            lblKaydedenKullanici.Text = lblKaydedilmeZamani.Text = " -";
        }

        void AyarCek()
        {
            if (_GostermeSekli == GostermeSekilleri.Hepsi)
            {
                lblKaydedenKullaniciCaption.Visible = lblKaydedilmeZamaniCaption.Visible = lblKaydedilmeZamani.Visible = lblKaydedenKullanici.Visible = true;
                lblDuzenlemeZamaniCaption.Visible = lblDuzenlenmeZamani.Visible = lblDuzenleyenKullanici.Visible = lblDuzenleyenKullaniciCaption.Visible = true;

                if (_GosterSimge)
                {
                    lblDuzenleyenKullanici.Location = new Point(293, 1);
                    lblDuzenlenmeZamani.Location = new Point(293, 19);

                    lblDuzenlemeZamaniCaption.Location = new Point(217, 19);
                    lblDuzenleyenKullaniciCaption.Location = new Point(217, 1);
                }
                else
                {
                    lblDuzenleyenKullanici.Location = new Point(250, 1);
                    lblDuzenlenmeZamani.Location = new Point(250, 19);

                    lblDuzenlemeZamaniCaption.Location = new Point(174, 19);
                    lblDuzenleyenKullaniciCaption.Location = new Point(174, 1);

                    lblKaydedenKullaniciCaption.Location = new Point(1, 1);
                    lblKaydedenKullanici.Location = new Point(74, 1);
                    lblKaydedilmeZamaniCaption.Location = new Point(1, 19);
                    lblKaydedilmeZamani.Location = new Point(74, 19);
                }
            }
            else if (_GostermeSekli == GostermeSekilleri.Kaydeden)
            {
                lblKaydedenKullaniciCaption.Visible = lblKaydedilmeZamaniCaption.Visible = lblKaydedilmeZamani.Visible = lblKaydedenKullanici.Visible = true;
                lblDuzenlemeZamaniCaption.Visible = lblDuzenlenmeZamani.Visible = lblDuzenleyenKullanici.Visible = lblDuzenleyenKullaniciCaption.Visible = false;
            }
            else if (_GostermeSekli == GostermeSekilleri.Duzenyelen)
            {
                lblKaydedenKullaniciCaption.Visible = lblKaydedilmeZamaniCaption.Visible = lblKaydedilmeZamani.Visible = lblKaydedenKullanici.Visible = false;
                lblDuzenlemeZamaniCaption.Visible = lblDuzenlenmeZamani.Visible = lblDuzenleyenKullanici.Visible = lblDuzenleyenKullaniciCaption.Visible = true;

                if (_GosterSimge)
                {
                    lblDuzenleyenKullaniciCaption.Location = new Point(43, 1);
                    lblDuzenleyenKullanici.Location = new Point(190, 1);
                    lblDuzenlemeZamaniCaption.Location = new Point(43, 19);
                    lblDuzenlenmeZamani.Location = new Point(190, 19);
                }
                else
                {
                    lblDuzenleyenKullaniciCaption.Location = new Point(0, 1);
                    lblDuzenleyenKullanici.Location = new Point(74, 1);
                    lblDuzenlemeZamaniCaption.Location = new Point(1, 19);
                    lblDuzenlenmeZamani.Location = new Point(74, 19);
                }
            }
        }
        #endregion
    }
}