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
    public class Birim
    {
        public static DataTable Ver_Birimler(Enumlar.BirimTipleri? BirimTip=null)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    B.BirimID,B.BirimAd,GB.Aciklama BirimTip,IF(B.Durum,'Aktif','Pasif')Durum FROM birim B
                                    INNER JOIN genelkodlar GB ON GB.Kod=B.BirimTip
                                    WHERE GB.Grup='BirimTip'";

                if (BirimTip != null)
                {
                    veri.SqlCumlesi += " And B.BirimTip=@BirimTip";
                    veri.Ekle_Param("@BirimTip", ((int)BirimTip.Value).ToString(), MySqlDbType.VarChar);
                }
                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static birim Ver_Birim(ref otosisdbEntities dbModel, int BirimID)
        {
            birim _br = null;

            _br = (from abc in dbModel.birims
                   where abc.BirimID == BirimID
                   select abc).FirstOrDefault();

            if (_br != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, _br);
            }

            return _br;
        }

        public static string Ver_BirimAd(int BirimID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select BirimAd From birim Where BirimID=@BirimID";
                veri.Ekle_Param("@BirimID", BirimID, MySqlDbType.Int32);

                return veri.ExecuteScalar().ToString();
            }
        }

        public static bool Varmi_BirimAd(int SirketID, string BirimAd, string Haric = null)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From birim Where BirimAd=@BirimAd And SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);
                veri.Ekle_Param("@BirimAd", BirimAd, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And BirimAd<>@Haric";
                    veri.Ekle_Param("@Haric", Haric, MySqlDbType.VarChar);
                }

                if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}