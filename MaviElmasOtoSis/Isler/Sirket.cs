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
    public class Sirket
    {
        public static DataTable Ver_Sirketler(bool? Durum=null)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "SELECT S.SirketID,S.KisaAd,S.Unvan,IF(S.Durum,'Aktif','Pasif') Durum FROM sirket S";

                if (Durum != null)
                {
                    veri.SqlCumlesi += " Where S.Durum=@Durum";
                    veri.Ekle_Param("@Durum", Durum.Value, MySqlDbType.Bit);
                }

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static sirket Ver_Sirket(ref otosisdbEntities dbModel, int SirketID)
        {
            sirket sir = null;

            sir = (from abc in dbModel.sirkets
                   where abc.SirketID == SirketID
                   select abc).FirstOrDefault();

            if (sir != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, sir);
            }

            return sir;
        }

        public static bool Varmi_KisaAd(string KisaAdi, string Haric = null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From Sirket Where KisaAd=@KisaAd";
                veri.Ekle_Param("@KisaAd", KisaAdi, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And KisaAd<>@Haric";
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
        public static bool Varmi_Unvan(string Unvan, string Haric = null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From Sirket Where Unvan=@Unvan";
                veri.Ekle_Param("@Unvan", Unvan, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And Unvan<>@Haric";
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
    }
}