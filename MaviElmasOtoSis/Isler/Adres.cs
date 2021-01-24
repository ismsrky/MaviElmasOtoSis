using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Isler
{
    public static class Adres
    {
        public static DataTable Ver_Il()
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Plaka,IlAdi From Adres_Il Order By IlAdi Asc";

                dt = veri.Ver_DataTable(false);
            }

            return dt;
        }

        public static DataTable Ver_Ilce()
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select IlceID,IlPlaka,IlceAdi From Adres_Ilce Order By IlceAdi Asc";

                dt = veri.Ver_DataTable(false);
            }

            return dt;
        }

        public static DataTable Ver_Ilce(int _IlPlaka)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select IlceID,IlPlaka,IlceAdi From Adres_Ilce Where IlPlaka=@IlPlaka Order By IlceAdi Asc";
                veri.Ekle_Param("@IlPlaka", _IlPlaka, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static string Ver_IlAd(int Plaka)
        {
            if (Genel.dt_Iller != null && Genel.dt_Iller.Rows.Count > 0)
            {
                for (int i = 0; i < Genel.dt_Iller.Rows.Count; i++)
                {
                    if (Convert.ToInt32(Genel.dt_Iller.Rows[i]["Plaka"]) == Plaka)
                    {
                        return Genel.dt_Iller.Rows[i]["IlAdi"].ToString();
                    }
                }
            }

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "SELECT IlAdi FROM adres_il Where Plaka=@Plaka";
                veri.Ekle_Param("@Plaka", Plaka, MySqlDbType.Int32);
                return veri.ExecuteScalar().ToString();
            }
        }
        public static string Ver_IlceAd(int IlceID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "SELECT IlceAdi FROM adres_ilce Where IlceID=@IlceID";
                veri.Ekle_Param("@IlceID", IlceID, MySqlDbType.Int32);
                return veri.ExecuteScalar().ToString();
            }
        }
    }
}