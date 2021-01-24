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
    public class Arac
    {
        public static DataTable Ver_Araclar()
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    A.AracID,A.Plaka,A.RuhsatSahibi,A.SaseNo,MA.MarkaAdi,MO.ModelAdi FROM arac A
                                    INNER JOIN araba_marka MA ON A.MarkaID=MA.MarkaID
                                    INNER JOIN araba_model MO ON A.ModelID=MO.ModelID
                                    Where A.SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static arac Ver_Arac(ref otosisdbEntities dbModel, int AracID)
        {
            arac arc = null;

            arc = (from abc in dbModel.aracs
                   where abc.AracID == AracID
                   select abc).FirstOrDefault();

            if (arc != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, arc);
            }

            return arc;
        }
        public static arac Ver_Arac(ref otosisdbEntities dbModel, string Plaka)
        {
            arac arc = null;

            arc = (from abc in dbModel.aracs
                   where abc.Plaka == Plaka && abc.SirketID == Genel.AktifSirket.SirketID
                   select abc).FirstOrDefault();

            if (arc != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, arc);
            }

            return arc;
        }

        public static string Ver_Plaka(int AracID)
        {
            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = "Select Plaka from arac Where AracID=@AracID";
                veri.Ekle_Param("@AracID", AracID, MySqlDbType.Int32);
                return veri.ExecuteScalar().ToString();
            }
        }

        public static bool Varmi_Plaka(int SirketID, string Plaka, string Haric = null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From arac Where SirketID=@SirketID And Plaka=@Plaka";
                veri.Ekle_Param("@Plaka", Plaka, MySqlDbType.VarChar);
                veri.Ekle_Param("@SirketID", SirketID, MySqlDbType.Int32);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And Plaka<>@Haric";
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
        public static bool Varmi_SaseNo(int SirketID, string SaseNo, string Haric = null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From arac Where SirketID=@SirketID And SaseNo=@SaseNo";
                veri.Ekle_Param("@SaseNo", SaseNo, MySqlDbType.VarChar);
                veri.Ekle_Param("@SirketID", SirketID, MySqlDbType.Int32);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And SaseNo<>@Haric";
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

        public static int Ver_AdetAracHareket(int AracID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select
                                    (SELECT COUNT(*) FROM servis Where AracID=@AracID)+
                                    (SELECT COUNT(*) FROM fatura Where AracID=@AracID)+
                                    (SELECT COUNT(*) FROM stok_hareket Where AracID=@AracID)";

                veri.Ekle_Param("@AracID", AracID, MySqlDbType.Int32);

                return Convert.ToInt32(veri.ExecuteScalar());
            }
        }
    }
}