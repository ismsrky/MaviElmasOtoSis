using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.Objects;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Isler
{
    public class Kullanici
    {
        public static kullanici Ver_Kullanici(ref otosisdbEntities dbModel, int KullaniciID)
        {
            kullanici kul = null;

            kul = (from abc in dbModel.kullanicis
                   where abc.KullaniciID == KullaniciID
                   select abc).FirstOrDefault();

            if (kul != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, kul);

                kul.Ad = Araclar.Sifreleme.DecryptString(kul.Ad);
                kul.Soyad = Araclar.Sifreleme.DecryptString(kul.Soyad);
                kul.KullaniciAd = Araclar.Sifreleme.DecryptString(kul.KullaniciAd);
            }
            return kul;
        }
        public static kullanici Ver_Kullanici(ref otosisdbEntities dbModel, string KullaniciAdi)
        {
            kullanici kull = null;            

            kull = (from abc in dbModel.kullanicis
                   where abc.KullaniciAd==KullaniciAdi
                   select abc).FirstOrDefault();

            if (kull != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, kull);

                kull.Ad = Araclar.Sifreleme.DecryptString(kull.Ad);
                kull.Soyad = Araclar.Sifreleme.DecryptString(kull.Soyad);
                kull.KullaniciAd = Araclar.Sifreleme.DecryptString(kull.KullaniciAd);
            }

            return kull;
        }

        public static DataTable Ver_Kullanicilar(bool? Durum=null)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select KullaniciID,KullaniciAd,Ad,Soyad,IF(Durum,'Aktif','Pasif') Durum From Kullanici Where SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);
                if (Durum != null)
                {
                    veri.SqlCumlesi += " And Durum=@Durum";
                    veri.Ekle_Param("@Durum", Durum, MySqlDbType.Bit);
                }
                dt = veri.Ver_DataTable();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["KullaniciAd"] = Araclar.Sifreleme.DecryptString(dt.Rows[i]["KullaniciAd"].ToString());
                        dt.Rows[i]["Ad"] = Araclar.Sifreleme.DecryptString(dt.Rows[i]["Ad"].ToString());
                        dt.Rows[i]["Soyad"] = Araclar.Sifreleme.DecryptString(dt.Rows[i]["Soyad"].ToString());
                    }
                }
            }

            return dt;

        }

        public static bool Varmi_Kullanici(string KullaniciAdi, string KullaniciSifre,int SirketID)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "SELECT COUNT(*)  FROM kullanici WHERE Durum=1 And KullaniciAd=@KullaniciAd And KullaniciSifre=@KullaniciSifre And SirketID=@SirketID;";
                veri.Ekle_Param("@KullaniciAd", Araclar.Sifreleme.EncryptToString(KullaniciAdi), MySqlDbType.VarChar);
                veri.Ekle_Param("@KullaniciSifre", Araclar.Sifreleme.EncryptToString(KullaniciSifre), MySqlDbType.VarChar);
                veri.Ekle_Param("@SirketID", SirketID, MySqlDbType.Int32);

                if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                {
                    Sonuc = true;
                }
            }

            return Sonuc;
        }

        public static bool Varmi_KullaniciAdi(string KullaniciAdi, string Haric = null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From Kullanici Where KullaniciAd=@KullaniciAd";
                veri.Ekle_Param("@KullaniciAd", Araclar.Sifreleme.EncryptToString(KullaniciAdi), MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And KullaniciAd<>@Haric";
                    veri.Ekle_Param("@Haric", Haric, MySqlDbType.VarChar);
                }

                if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                {
                    Sonuc = true;
                }
                else
                {
                    Sonuc = false;
                }
            }

            return Sonuc;
        }

        public static string Ver_KullaniciAdSoyad(int KullaniciID)
        {
            if (Genel.dt_Kullanicilar != null && Genel.dt_Kullanicilar.Rows.Count > 0)
            {
                for (int i = 0; i < Genel.dt_Kullanicilar.Rows.Count; i++)
                {
                    if (Convert.ToInt32(Genel.dt_Kullanicilar.Rows[i]["KullaniciID"]) == KullaniciID)
                    {
                        return Genel.dt_Kullanicilar.Rows[i]["Ad"].ToString() + " "
                            + Genel.dt_Kullanicilar.Rows[i]["Soyad"].ToString();
                    }
                }
            }

            using (VeriErisim veri = new VeriErisim())
            {
                string AdSoyad = null;

                veri.SqlCumlesi = "Select Ad,Soyad From Kullanici Where KullaniciID=@KullaniciID";
                veri.Ekle_Param("@KullaniciID", KullaniciID, MySqlDbType.Int32);

                MySqlDataReader oku = veri.ExecuteReader();

                if (oku.Read())
                {
                    AdSoyad= Araclar.Sifreleme.DecryptString(oku.GetString(0)) + " " + Araclar.Sifreleme.DecryptString(oku.GetString(1));
                }
                veri.baglanti.Close();
                oku.Close(); oku.Dispose();

                return AdSoyad;
            }
        }
    }
}