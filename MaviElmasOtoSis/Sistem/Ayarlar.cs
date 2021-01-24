using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Sistem
{
    public static class Ayarlar
    {
        #region < Değişkenler >
        static DataTable dt_Ayarlar = new DataTable();
        
        static string _ServerAdres;
        static string _ServerKullaniciAdi;
        static string _ServerKullaniciSifre;
        static string _VeritabaniAdi;

        static string _DosyaSunucusu;

        static string _YaziciBarkod;
        static string _YaziciA4;

        static string _HavaDurumSehir;
        static string _TemaAdi;

        static int _VarsayilanSirketID;
        static int _VarsayilanDepoID;
        #endregion

        #region < Özellikler >
        public static string ServerAdres
        {
            get
            {
                return _ServerAdres;
            }
            set
            {
                _ServerAdres = value;
                Ayar_Degistir("ServerAdres", value);
            }
        }        
        public static string ServerKullaniciAdi
        {
            get
            {
                return _ServerKullaniciAdi;
            }
            set
            {
                _ServerKullaniciAdi = value;
                Ayar_Degistir("ServerKullaniciAdi", Araclar.Sifreleme.EncryptToString(value));
            }
        }        
        public static string ServerKullaniciSifre
        {
            get
            {
                return _ServerKullaniciSifre;
            }
            set
            {
                _ServerKullaniciSifre = value;
                Ayar_Degistir("ServerKullaniciSifre",Araclar.Sifreleme.EncryptToString( value));
            }
        }        
        public static string VeritabaniAdi
        {
            get
            {
                return _VeritabaniAdi;
            }
            set
            {
                _VeritabaniAdi = value;
                Ayar_Degistir("VeritabaniAdi", value);
            }
        }
        
        public static string DosyaSunucusu
        {
            get
            {
                return _DosyaSunucusu;
            }
            set
            {
                _DosyaSunucusu = value;
                Ayar_Degistir("DosyaSunucusu", value);
            }
        }
       
        public static string YaziciBarkod
        {
            get
            {
                return _YaziciBarkod;
            }
            set
            {
                _YaziciBarkod = value;
                Ayar_Degistir("YaziciBarkod", value);
            }
        }        
        public static string YaziciA4
        {
            get
            {
                return _YaziciA4;
            }
            set
            {
                _YaziciA4 = value;
                Ayar_Degistir("YaziciA4", value);
            }
        }

        
        public static string HavaDurumSehir
        {
            get
            {
                return _HavaDurumSehir;
            }
            set
            {
                _HavaDurumSehir = value;
                Ayar_Degistir("HavaDurumSehir", value);
            }
        }        
      
        public static string TemaAdi
        {
            get
            {
                return _TemaAdi;
            }
            set
            {
                _TemaAdi = value;
                Ayar_Degistir("TemaAdi", value);
            }
        }
        public static int VarsayilanSirketID
        {
            get
            {
                return _VarsayilanSirketID;
            }
            set
            {
                _VarsayilanSirketID = value;
                Ayar_Degistir("VarsayilanSirketID", value.ToString());
            }
        }
        public static int VarsayilanDepoID
        {
            get
            {
                return _VarsayilanDepoID;
            }
            set
            {
                _VarsayilanDepoID = value;
                Ayar_Degistir("VarsayilanDepoID", value.ToString());
            }
        }
        #endregion

        #region < Metod >
        public static void Oku()
        {
            using (DataSet ds_Ayarlar=new DataSet())
            {
                ds_Ayarlar.ReadXml(AppDomain.CurrentDomain.BaseDirectory + @"\ayarlar.xml");

                dt_Ayarlar.Clear();
                dt_Ayarlar = ds_Ayarlar.Tables[0];                
            }

            string temp_AyarAdi = "";
            string temp_AyarDeger = "";
            for (int i = 0; i < dt_Ayarlar.Rows.Count; i++)
            {
                temp_AyarAdi = dt_Ayarlar.Rows[i]["AyarAdi"].ToString();
                temp_AyarDeger = dt_Ayarlar.Rows[i]["AyarDeger"].ToString();

                switch (temp_AyarAdi)
                {
                    case "ServerAdres":
                        _ServerAdres = Araclar.Sifreleme.DecryptString(temp_AyarDeger);
                        break;
                    case "ServerKullaniciAdi":
                        _ServerKullaniciAdi = Araclar.Sifreleme.DecryptString(temp_AyarDeger);
                        break;
                    case "ServerKullaniciSifre":
                        _ServerKullaniciSifre = Araclar.Sifreleme.DecryptString(temp_AyarDeger);
                        break;
                    case "VeritabaniAdi":
                        _VeritabaniAdi = temp_AyarDeger;
                        break;
                    case "DosyaSunucusu":
                        _DosyaSunucusu = temp_AyarDeger;
                        break;
                    case "TemaAdi":
                        _TemaAdi = temp_AyarDeger;
                        break;
                    case "YaziciBarkod":
                        _YaziciBarkod = temp_AyarDeger;
                        break;
                    case "YaziciA4":
                        _YaziciA4 = temp_AyarDeger;
                        break;
                    case "HavaDurumSehir":
                        _HavaDurumSehir = temp_AyarDeger;
                        break;                   
                    case "VarsayilanSirketID":
                        _VarsayilanSirketID = Convert.ToInt32(temp_AyarDeger);
                        break;
                    case "VarsayilanDepoID":
                        _VarsayilanDepoID = Convert.ToInt32(temp_AyarDeger);
                        break;
                }
            }


            Baglanti.ServerAdres = _ServerAdres;
            Baglanti.KullaniciAdi = _ServerKullaniciAdi;
            Baglanti.KullaniciSifre = _ServerKullaniciSifre;
            Baglanti.VeritabaniAdi = _VeritabaniAdi;
        }

        public static void Kaydet()
        {
            dt_Ayarlar.WriteXml(AppDomain.CurrentDomain.BaseDirectory + @"\ayarlar.xml");
        }

        static void Ayar_Degistir(string AyarAdi, string AyarDeger)
        {
            bool AyarVarMi = false;

            for (int i = 0; i < dt_Ayarlar.Rows.Count; i++)
            {
                if (AyarAdi == dt_Ayarlar.Rows[i]["AyarAdi"].ToString())
                {
                    AyarVarMi = true;

                    if (AyarAdi == "SqlServerAdres" || AyarAdi == "SqlKullaniciSifre" || AyarAdi == "SqlKullaniciAdi" || AyarAdi == "ServerAdres")
                    {
                        dt_Ayarlar.Rows[i]["AyarDeger"] = Araclar.Sifreleme.EncryptToString(AyarDeger);
                    }
                    else
                    {
                        dt_Ayarlar.Rows[i]["AyarDeger"] = AyarDeger;
                    }
                }
            }

            if (!AyarVarMi)
            {
                DataRow dr = dt_Ayarlar.NewRow();
                dr["AyarAdi"] = AyarAdi;
                dr["AyarDeger"] = AyarDeger;
                dt_Ayarlar.Rows.Add(dr);
            }
        }
        #endregion
    }
}