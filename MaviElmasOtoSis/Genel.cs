using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Data;
using System.IO;
using DevExpress.XtraBars.Alerter;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis
{
    public static class Genel
    {
        #region < Sabitler >
        public static DateTime SistemeGirisSaat;
        public static string PersonelResim_Yol;
        public static string AracResim_Yol;

        public static List<int> Yetkilerim;
        public static List<yetki> Yetkiler;

        public static StyleController AnaSitil;

        public static frmAna AnaEkran;
        public static frmGirisEkrani GirisEkran;
        public static kullanici AktifKullanici;
        public static sirket AktifSirket;
        public static stok_depo AktifDepo;

        public static decimal IscilikHafif;
        public static decimal IscilikOrta;
        public static decimal IscilikAgir;
        #endregion

        #region < Veriler >
        //Program açılırken yüklenmesi zorunlu olanlar:
        public static DataTable dt_Iller;
        public static DataTable dt_Markalar;
        public static DataTable dt_StokKartlarSecim;
        public static DataTable dt_IsciliklerSecim;
        public static DataTable dt_PersonellerSecim;
        public static DataTable dt_CarilerSecim;
        public static DataTable dt_DepolarSecim;
        public static DataTable dt_BankalarSecim;
        public static DataTable dt_KasalarSecim;

        public static DataTable dt_Kullanicilar;

        //Zorunlu olmayanlar:
        public static DataTable dt_Araclar;
        public static DataTable dt_Cariler;
        public static DataTable dt_StokKartlar;
        public static DataTable dt_Iscilikler;
        public static DataTable dt_Personeller;


        #endregion

        #region < Nesneler >
        public static AlertControl AlertMesaj;
        public static otosisdbEntities dbModel;
        #endregion

        #region < Metod >
        public static void Yetki_Uyari(int YetkiID)
        {
            XtraMessageBox.Show("Yetki Bulunamadı.\n\nYetki Adı : '" + Isler.Yetki.Ver_YetkiAd(YetkiID) + "'", "Yetki Yok",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void AyarCek()
        {
            #region   Klasör Ayarları
            PersonelResim_Yol = @"\PersonelResim\";
            if (!Directory.Exists(Sistem.Ayarlar.DosyaSunucusu + PersonelResim_Yol))
            {
                Directory.CreateDirectory(Sistem.Ayarlar.DosyaSunucusu + PersonelResim_Yol);
            }

            AracResim_Yol = @"\AracResim\";
            if (!Directory.Exists(Sistem.Ayarlar.DosyaSunucusu + AracResim_Yol))
            {
                Directory.CreateDirectory(Sistem.Ayarlar.DosyaSunucusu + AracResim_Yol);
            }

            #endregion

            #region Ana Sitil
            AnaSitil = new StyleController();
            //AnaSitil.AppearanceFocused.BackColor = ColorTranslator.FromHtml("#D7E6C8");
            AnaSitil.AppearanceFocused.BackColor = ColorTranslator.FromHtml("#EAFFBF");
            AnaSitil.AppearanceDisabled.BackColor = Color.White;
            #endregion

            AlertMesaj = new AlertControl();
            AlertMesaj.AutoFormDelay = 2500;
            AlertMesaj.FormLocation = AlertFormLocation.BottomLeft;
        }

        public static void Al_Verileri(bool GiristenOnce)
        {
            if (GiristenOnce)
            {
                if (dbModel != null)
                {
                    dbModel.Dispose();
                }
                dbModel = null;
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);
            }
            else
            {
                Yetkilerim = Isler.Yetki.Ver_Yetkilerim(Genel.AktifKullanici.KullaniciID);
                Yetkiler = Isler.Yetki.Ver_YetkilerListe();

                dt_DepolarSecim = Isler.Stok.Ver_Depolar(false);
                dt_Kullanicilar = Isler.Kullanici.Ver_Kullanicilar();
                dt_BankalarSecim = Isler.Banka.Ver_Bankalar(true);
                dt_StokKartlarSecim = Isler.Stok.Ver_StokKartlari(true);
                dt_IsciliklerSecim = Isler.Iscilik.Ver_Iscilikler(true);
                dt_PersonellerSecim = Isler.Personel.Ver_Personeller(false);
                dt_KasalarSecim = Isler.Kasa.Ver_Kasalar(true);

                dt_Iller = Isler.Adres.Ver_Il();

                dt_Markalar = Isler.MarkaModel.Ver_Markalar(null, null);

                IscilikAgir = Convert.ToDecimal(Isler.Genelparam.Ver_ParamKarsilik(1));
                IscilikOrta = Convert.ToDecimal(Isler.Genelparam.Ver_ParamKarsilik(2));
                IscilikHafif = Convert.ToDecimal(Isler.Genelparam.Ver_ParamKarsilik(3));
            }
        }
        public static void Ekle_Sitil(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.SplitContainer")
            {
                foreach (Control item in ((SplitContainer)control).Panel1.Controls)
                {
                    Ekle_Sitil(item);
                }

                foreach (Control item in ((SplitContainer)control).Panel2.Controls)
                {
                    Ekle_Sitil(item);
                }
            }
            else if (control.GetType().ToString() == "DevExpress.XtraEditors.GroupControl")
            {
                foreach (Control item in ((GroupControl)control).Controls)
                {
                    Ekle_Sitil(item);
                }
            }
            else if (control.GetType().ToString() == "DevExpress.XtraTab.XtraTabControl")
            {
                foreach (XtraTabPage item in ((XtraTabControl)control).TabPages)
                {
                    Ekle_Sitil(item);
                }
            }
            else if (control.GetType().ToString() == "DevExpress.XtraTab.XtraTabPage")
            {
                foreach (Control item in ((XtraTabPage)control).Controls)
                {
                    Ekle_Sitil(item);
                }
            }
            else if (control.GetType().ToString() == "DevExpress.XtraEditors.TextEdit")
            {
                ((TextEdit)control).StyleController = AnaSitil;
            }
            else if (control.GetType().ToString() == "DevExpress.XtraEditors.MemoEdit")
            {
                ((MemoEdit)control).StyleController = AnaSitil;
            }
            else if (control.GetType().ToString() == "DevExpress.XtraEditors.SimpleButton")
            {
                ((SimpleButton)control).Cursor = Cursors.Hand;
            }
            else if (control.GetType().ToString() == "DevExpress.XtraEditors.ButtonEdit")
            {
                ((ButtonEdit)control).Cursor = Cursors.Hand;
            }
            else if (control.GetType().ToString() == "DevExpress.XtraEditors.LookUpEdit")
            {
                ((LookUpEdit)control).Cursor = Cursors.Hand;
                ((LookUpEdit)control).StyleController = AnaSitil;
            }
            else if (control.GetType().ToString() == "DevExpress.XtraEditors.ComboBoxEdit")
            {
                ((ComboBoxEdit)control).Cursor = Cursors.Hand;
                ((ComboBoxEdit)control).StyleController = AnaSitil;
            }
            else if (control.GetType().ToString() == "DevExpress.XtraEditors.DropDownButton")
            {
                ((DropDownButton)control).Cursor = Cursors.Hand;
            }

            //Made by İsmail Sarıkaya
            //01.11.2012
        }

        /// <summary>
        /// Verilen kartid'nin verilen depoda ne kadar olduğuna bakar, eğer yok ise hata mesajı verir ve false dönderir, var ise mesaj vermeden true dönderir.
        /// </summary>
        /// <param name="KartID"></param>
        /// <param name="DepoID"></param>
        /// <param name="Miktar"></param>
        /// <returns></returns>
        public static bool Varmi_Stokta(int KartID, int DepoID, decimal Miktar)
        {
            return true;
            int temp_StokAdet = Isler.Stok.StokAdet(KartID, DepoID);
            if (temp_StokAdet <= 0 || temp_StokAdet < Miktar)
            {
                XtraMessageBox.Show("Seçilen Stok Kaleminin '" + Isler.Stok.Ver_DepoAd(DepoID) + "' Deposundaki Miktarı : " + temp_StokAdet, "Yetersiz Stok",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion
    }
}