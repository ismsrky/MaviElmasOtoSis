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
    public class Iscilik
    {
        #region < İşçilik >
        public static iscilik Ver_Iscilik(ref otosisdbEntities dbModel, int IscilikID)
        {
            iscilik isc = null;

            isc = (from abc in dbModel.isciliks
                   where abc.IscilikID == IscilikID
                   select abc).FirstOrDefault();

            if (isc != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, isc);
            }

            return isc;
        }

        public static DataTable Ver_Iscilikler(bool? Durum = null)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                  I.IscilikID,I.IscilikAd,I.IscilikTip,GI.Aciklama IscilikTipAciklama,I.KacSaat,
                                  IF(I.Durum,'Aktif','Pasif') Durum FROM iscilik AS I
                                  INNER JOIN genelkodlar GI ON GI.Kod=I.IscilikTip
                                  WHERE GI.Grup='IscilikTip' And I.SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);

                if (Durum != null)
                {
                    veri.SqlCumlesi += " And I.Durum=@Durum";
                    veri.Ekle_Param("@Durum", Durum, MySqlDbType.Bit);
                }

                dt = veri.Ver_DataTable();
            }

            return dt;
        }
        public static DataTable Ver_Iscilikler(int TalepID)
        {
            DataTable dt = null;

            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    IH.ID,IH.IscilikID,I.IscilikAd,IH.Miktar,IT.Aciklama IscilikTip,IH.BirimFiyat
                                    FROM iscilik_hareket IH
                                    INNER JOIN iscilik I ON I.IscilikID=IH.IscilikID
                                    INNER JOIN genelkodlar IT ON IT.Kod=IH.IscilikTip
                                    WHERE IT.Grup='IscilikTip' AND IH.TalepID=@TalepID";

                veri.Ekle_Param("@TalepID", TalepID, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static bool Varmi_Iscilik(int SirketID, string IscilikAdi, string Haric = null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From iscilik Where SirketID=@SirketID And IscilikAd=@IscilikAd";
                veri.Ekle_Param("@IscilikAd", IscilikAdi, MySqlDbType.VarChar);
                veri.Ekle_Param("@SirketID", SirketID, MySqlDbType.Int32);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And IscilikAd<>@Haric";
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

        public static string Ver_IscilikAd(int IscilikID)
        {
            string Sonuc = "";

            bool Bulundu = false;
            if (Genel.dt_IsciliklerSecim != null && Genel.dt_IsciliklerSecim.Rows.Count > 0)
            {
                for (int i = 0; i < Genel.dt_IsciliklerSecim.Rows.Count; i++)
                {
                    if (Convert.ToInt32(Genel.dt_IsciliklerSecim.Rows[i]["IscilikID"]) == IscilikID)
                    {
                        Sonuc = Genel.dt_IsciliklerSecim.Rows[i]["IscilikAd"].ToString();
                        Bulundu = true;
                        break;
                    }
                }
            }

            if (!Bulundu)
            {
                using (VeriErisim veri = new VeriErisim())
                {
                    veri.SqlCumlesi = "Select IscilikAd from iscilik Where IscilikID=@IscilikID";
                    veri.Ekle_Param("@IscilikID", IscilikID, MySqlDbType.Int32);

                    Sonuc = veri.ExecuteScalar().ToString();
                }
            }

            return Sonuc;
        }
        #endregion

        #region < İşçilik Hareket >
        public static iscilik_hareket Ver_IscilikHareket(ref otosisdbEntities dbModel, int ID)
        {
            iscilik_hareket isc_har = null;

            isc_har = (from abc in dbModel.iscilik_hareket
                       where abc.ID == ID
                       select abc).FirstOrDefault();

            if (isc_har != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, isc_har);
            }

            return isc_har;
        }

        public static int Ver_AdetIscilik(int TalepID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From iscilik_hareket Where TalepID=@TalepID";
                veri.Ekle_Param("@TalepID", TalepID, MySqlDbType.Int32);
                return Convert.ToInt32(veri.ExecuteScalar());
            }
        }
        #endregion

        #region < İşçilik Personel >
        public static DataTable Ver_IscilikPersoneller(int IH_ID)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    IHP.ID,IHP.PersonelID,IHP.Performans
                                    FROM iscilik_hareket_personel IHP
                                    INNER JOIN personel P ON P.PersonelID=IHP.PersonelID
                                    WHERE IHP.IH_ID=@IH_ID";

                veri.Ekle_Param("@IH_ID", IH_ID, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static void Sil_IscilikPersoneller(int IH_ID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Delete FRom iscilik_hareket_personel Where IH_ID=@IH_ID";
                veri.Ekle_Param("@IH_ID", IH_ID, MySqlDbType.Int32);
                veri.ExecuteNonQuery();
            }
        }
        #endregion
    }
}