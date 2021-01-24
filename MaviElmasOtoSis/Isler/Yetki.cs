using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Isler
{
    public static class Yetki
    {
        public static DataTable Ver_Yetkiler_KullaniciyaGore(int KullaniciID, bool YetkiDurum = true)
        {
            DataTable dt = Ver_Yetkiler(YetkiDurum);

            dt.Columns.Add("YetkiVarmi", typeof(bool));

            List<int> Yetkiler = new List<int>();
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select YetkiID From yetki_kullanici Where KullaniciID=@KullaniciID";
                veri.Ekle_Param("@KullaniciID", KullaniciID, MySqlDbType.Int32);

                DataTable dt_yetkiler = veri.Ver_DataTable();

                for (int i = 0; i < dt_yetkiler.Rows.Count; i++)
                {
                    Yetkiler.Add(Convert.ToInt32(dt_yetkiler.Rows[i]["YetkiID"]));
                }
            }

            int temp_YetkiID;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                temp_YetkiID = Convert.ToInt32(dt.Rows[i]["YetkiID"]);

                if (Yetkiler.Contains(temp_YetkiID))
                {
                    dt.Rows[i]["YetkiVarmi"] = true;
                }
                else
                {
                    dt.Rows[i]["YetkiVarmi"] = false;
                }
            }
            return dt;
        }

        public static List<int> Ver_Yetkilerim(int KullaniciID)
        {
            List<int> Yetkiler = new List<int>();
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select YetkiID From yetki_kullanici Where KullaniciID=@KullaniciID";
                veri.Ekle_Param("@KullaniciID", KullaniciID, MySqlDbType.Int32);

                DataTable dt_yetkiler = veri.Ver_DataTable();

                for (int i = 0; i < dt_yetkiler.Rows.Count; i++)
                {
                    Yetkiler.Add(Convert.ToInt32(dt_yetkiler.Rows[i]["YetkiID"]));
                }
            }

            return Yetkiler;
        }

        public static DataTable Ver_Yetkiler(bool Durum = true)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select Y.YetkiID,Y.Ad,Y.GrupID,Y.Durum,YG.Ad As YetkiGrupAdi From yetki As Y
Inner Join yetki_grup As YG On YG.GrupID=Y.GrupID Where Y.Durum=@Durum";
                veri.Ekle_Param("@Durum", Durum, MySqlDbType.Bit);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static List<yetki> Ver_YetkilerListe(bool Durum = true)
        {
            List<yetki> yetkiler = null;

            using (otosisdbEntities dbModel = new otosisdbEntities(Baglanti.BaglantiEntity))
            {
                yetkiler = (from abc in dbModel.yetkis
                            where abc.Durum == Durum
                            select abc).ToList();
            }

            return yetkiler;
        }

        public static void Sil_KullaniciYetki(int KullaniciID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Delete From yetki_kullanici Where KullaniciID=@KullaniciID";
                veri.Ekle_Param("@KullaniciID", KullaniciID, MySqlDbType.Int32);
                veri.ExecuteNonQuery();
            }
        }
        public static void Ekle_KullaniciYetki(int YetkiID, int KullaniciID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Insert Into yetki_kullanici(YetkiID,KullaniciID)Values(@YetkiID,@KullaniciID)";
                veri.Ekle_Param("@YetkiID", YetkiID, MySqlDbType.Int32);
                veri.Ekle_Param("@KullaniciID", KullaniciID, MySqlDbType.Int32);
                veri.ExecuteNonQuery();
            }
        }
        public static void Ekle_KullaniciYetki(DataTable dtYetkilerListesi, int KullaniciID)
        {
            int temp_YetkiID;
            bool temp_YetkiVarmi;
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Insert Into yetki_kullanici(YetkiID,KullaniciID)Values(@YetkiID,@KullaniciID)";
                veri.Ekle_Param("@YetkiID", 0, MySqlDbType.Int32);
                veri.Ekle_Param("@KullaniciID", KullaniciID, MySqlDbType.Int32);

                for (int i = 0; i < dtYetkilerListesi.Rows.Count; i++)
                {
                    temp_YetkiVarmi = Convert.ToBoolean(dtYetkilerListesi.Rows[i]["YetkiVarmi"]);
                    temp_YetkiID = Convert.ToInt32(dtYetkilerListesi.Rows[i]["YetkiID"]);

                    if (temp_YetkiVarmi)
                    {
                        veri.Degistir_Param("@YetkiID", temp_YetkiID);
                        veri.ExecuteNonQuery();
                    }
                }
                veri.ExecuteNonQuery();
            }

        }

        public static string Ver_YetkiAd(int YetkiID)
        {
            if (Genel.Yetkilerim != null)
            {
                foreach (yetki item in Genel.Yetkiler)
                {
                    if (item.YetkiID == YetkiID)
                    {
                        return item.Ad;
                    }
                }
            }

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Ad From yetki Where YetkiID=@YetkiID";
                veri.Ekle_Param("@YetkiID", YetkiID, MySqlDbType.Int32);

                return veri.ExecuteScalar().ToString();
            }
        }

        public static bool Varmi_Yetki(int YetkiID, bool Uyari = true)
        {
            bool Sonuc = false;

            if (Genel.Yetkilerim != null && Genel.Yetkilerim.Contains(YetkiID))
                Sonuc = true;

            if (!Sonuc)
            {
                using (VeriErisim veri = new VeriErisim())
                {
                    veri.SqlCumlesi = "Select Count(*) From yetki_kullanici Where YetkiID=@YetkiID And KullaniciID=@KullaniciID";
                    veri.Ekle_Param("@KullaniciID", Genel.AktifKullanici.KullaniciID, MySqlDbType.Int32);
                    veri.Ekle_Param("@YetkiID", YetkiID, MySqlDbType.Int32);

                    if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                    {
                        Sonuc = true;
                    }
                }
            }

            if (!Sonuc && Uyari)
            {
                Genel.Yetki_Uyari(YetkiID);
            }

            return Sonuc;
        }
    }
}