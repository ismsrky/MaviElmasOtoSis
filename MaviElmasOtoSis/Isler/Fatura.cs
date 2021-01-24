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
    public class Fatura
    {
        public static fatura Ver_Fatura(ref otosisdbEntities dbModel, int FaturaID)
        {
            fatura ft = null;

            ft = (from abc in dbModel.faturas
                  where abc.FaturaID == FaturaID
                  select abc).FirstOrDefault();

            if (ft != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, ft);
            }

            return ft;
        }

        public static DataTable Ver_Faturalar(Enumlar.FaturaTipleri? FaturaTipi, DateTime FaturaTarihBas, DateTime FaturaTarihBit)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    F.FaturaID,C.Unvan,C.TcKimlikNo,F.AcikFatura FaturaTipi,
                                    F.FaturaKaynak,F.IsemirID,I.BirimID,I.ServisID,
                                    IFNULL( S.AracID,F.AracID)AracID,IFNULL(A.Plaka,A2.Plaka)Plaka
                                    ,F.FaturaTarih,F.KayitZaman
                                    FROM fatura F
                                    INNER JOIN cari_hesap C ON C.CariID=F.CariID
                                    LEFT JOIN isemri I ON I.IsemirID=F.IsemirID
                                    LEFT JOIN servis S ON S.ServisID=I.ServisID
                                    LEFT JOIN arac A ON A.AracID=S.AracID
                                    LEFT JOIN arac A2 ON A2.AracID=F.AracID
                                    WHERE F.SirketID=@SirketID AND F.FaturaTip=@FaturaTip AND 
                                    F.FaturaTarih<=@FaturaTarihBit And F.FaturaTarih>=@FaturaTarihBas";

                veri.Ekle_Param("@FaturaTarihBas", FaturaTarihBas, MySqlDbType.DateTime);
                veri.Ekle_Param("@FaturaTarihBit", FaturaTarihBit, MySqlDbType.DateTime);

                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);
                veri.Ekle_Param("@FaturaTip", ((int)FaturaTipi).ToString(), MySqlDbType.VarChar);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static DataTable Ver_FaturaElemanlari(int? FaturaID, int? IsemirID)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    SH.ID,S.KartID,NULL IscilikID,S.KalemAdi KalemIscilikAdi,SH.Miktar,
                                    IFNULL(SH.BirimFiyat,0)BirimFiyat,S.StokBirim Birim,
                                    IF(IFNULL(SH.Kdvli,0),'Evet','Hayır')Kdvli,IFNULL(SH.Kdv,0)Kdv,
                                    IFNULL(SH.IndirimYuzde,0)IndirimYuzde, IFNULL(SH.IndirimYuzde2,0)IndirimYuzde2,
                                    IFNULL(SH.IndirimYuzde3,0)IndirimYuzde3,SH.DepoID,NULL IscilikTip,0 IscilikMi,S.ParcaNo,SH.AracID
                                    FROM stok_hareket SH
                                    INNER JOIN stok_kart S ON SH.StokKartID=S.KartID
                                    Where 1=1 ";
                if (FaturaID != null)
                {
                    veri.SqlCumlesi += " And SH.FaturaID=@FaturaID ";
                }
                if (IsemirID != null)
                {
                    veri.SqlCumlesi += " And SH.IsemirID=@IsemirID ";
                }

                veri.SqlCumlesi += @"UNION ALL
                                    SELECT 
                                    IH.ID,NULL KartID,I.IscilikID,I.IscilikAd KalemIscilikAdi,IH.Miktar,
                                    IFNULL(IH.BirimFiyat,0)BirimFiyat,-1 Birim,IF(IFNULL(IH.Kdvli,0),'Evet','Hayır')Kdvli,
                                    IFNULL(IH.Kdv,0)Kdv,IFNULL(IH.IndirimYuzde,0)IndirimYuzde,NULL IndirimYuzde2,NULL IndirimYuzde3,
                                    NULL DepoID,I.IscilikTip,1 IscilikMi,null ParcaNo,null AracID
                                    FROM iscilik_hareket IH
                                    INNER JOIN iscilik I ON I.IscilikID=IH.IscilikID
                                    Where 1=1";

                if (FaturaID != null)
                {
                    veri.SqlCumlesi += " And IH.FaturaID=@FaturaID ";
                    veri.Ekle_Param("@FaturaID", FaturaID, MySqlDbType.Int32);
                }
                if (IsemirID != null)
                {
                    veri.SqlCumlesi += " And IH.IsemirID=@IsemirID ";
                    veri.Ekle_Param("@IsemirID", IsemirID, MySqlDbType.Int32);
                }

                dt = veri.Ver_DataTable();

                dt.Columns.Add("NetTutar", typeof(decimal));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["NetTutar"] = Convert.ToDecimal(dt.Rows[i]["Miktar"]) * Convert.ToDecimal(dt.Rows[i]["BirimFiyat"]);
                }
            }

            return dt;
        }

        public static void Sil_FaturaElemanlari(int FaturaID, List<int> Haric_Ih, List<int> Haric_Sh)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.Ekle_Param("@FaturaID", FaturaID, MySqlDbType.Int32);

                //İşçilik Hareketleri:
                veri.SqlCumlesi = "Delete From iscilik_hareket Where FaturaID=@FaturaID ";
                if (Haric_Ih.Count > 0)
                {
                    veri.SqlCumlesi += "And ID not in (";
                    foreach (int item in Haric_Ih)
                    {
                        veri.SqlCumlesi += item.ToString() + ",";
                    }
                    veri.SqlCumlesi += "0)";
                }

                veri.ExecuteNonQuery();


                //Stok Hareketleri:
                veri.SqlCumlesi = "Delete From stok_hareket Where FaturaID=@FaturaID ";
                if (Haric_Sh.Count > 0)
                {
                    veri.SqlCumlesi += "And ID not in (";
                    foreach (int item in Haric_Sh)
                    {
                        veri.SqlCumlesi += item.ToString() + ",";
                    }
                    veri.SqlCumlesi += "0)";
                }
                veri.ExecuteNonQuery();
            }
        }
        public static void Sil_FaturaElemanlari(int FaturaID)
        {
            Sil_FaturaElemanlari(FaturaID, new List<int>(), new List<int>());
        }

        public static void Sil_FaturaKasaHareket(int FaturaID)
        {
            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = "Delete From kasa_hareket Where FaturaID=@FaturaID";
                veri.Ekle_Param("@FaturaID", FaturaID, MySqlDbType.Int32);
                veri.ExecuteNonQuery();
            }
        }
        public static void Sil_FaturaBankaHareket(int FaturaID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Delete From banka_hareket Where FaturaID=@FaturaID";
                veri.Ekle_Param("@FaturaID", FaturaID, MySqlDbType.Int32);
                veri.ExecuteNonQuery();
            }
        }
        public static void Sil_FaturaCariHareket(int FaturaID)
        {
            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = "Delete From cari_hareket Where FaturaID=@FaturaID";
                veri.Ekle_Param("@FaturaID", FaturaID, MySqlDbType.Int32);
                veri.ExecuteNonQuery();
            }
        }

        public static int Ver_SonSiraNo()
        {
            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT IFNULL(MAX(SiraNo),0) FROM fatura WHERE FaturaTip='3'";
                return Convert.ToInt32(veri.ExecuteScalar());
            }
        }

        //public static int Ver_AdetIscilik(int FaturaID)
        //{
        //    using (VeriErisim veri = new VeriErisim())
        //    {
        //        veri.SqlCumlesi = "Select Count(*) From iscilik_hareket Where FaturaID=@FaturaID";
        //        veri.Ekle_Param("@FaturaID", FaturaID, MySqlDbType.Int32);
        //        return Convert.ToInt32(veri.ExecuteScalar());
        //    }
        //}
        //public static int Ver_AdetParca(int FaturaID)
        //{
        //    using (VeriErisim veri = new VeriErisim())
        //    {
        //        veri.SqlCumlesi = "Select Count(*) From stok_hareket Where FaturaID=@FaturaID";
        //        veri.Ekle_Param("@FaturaID", FaturaID, MySqlDbType.Int32);
        //        return Convert.ToInt32(veri.ExecuteScalar());
        //    }
        //}
    }
}