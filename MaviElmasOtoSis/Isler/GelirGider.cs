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
    public class GelirGider
    {
        #region < Gelir Gider >
        public static DataTable Ver_GelirGiderler(bool? Durum = null, bool? Gelir = null)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT
                                   GG.GelirGiderID,GG.GelirGiderAd,GKB.Aciklama GelirGiderGrup,
                                   IF(GG.Durum,'Aktif','Pasif')Durum,IF(GG.Gelir,'Gelir','Gider')Gelir,
                                   (SELECT SUM(Miktar) FROM gelirgider_hareket WHERE Borc=1 And GelirGiderID=GG.GelirGiderID)Borc,
                                   (SELECT SUM(Miktar) FROM gelirgider_hareket WHERE Borc=0 And GelirGiderID=GG.GelirGiderID)Alacak                                 
                                   FROM gelirgider GG
                                   INNER JOIN genelkodlar GKB ON GKB.Kod=GG.GelirGiderGrup
                                   WHERE GKB.Grup='GelirGiderGrup'";

                if (Durum != null)
                {
                    veri.SqlCumlesi += " And GG.Durum=@Durum";
                    veri.Ekle_Param("@Durum", Durum.Value, MySqlDbType.Bit);
                }
                if (Gelir != null)
                {
                    veri.SqlCumlesi += " And GG.Gelir=@Gelir";
                    veri.Ekle_Param("@Gelir", Gelir.Value, MySqlDbType.Bit);
                }

                dt = veri.Ver_DataTable();

                if (dt != null)
                {
                    dt.Columns.Add("Bakiye", typeof(decimal));

                    decimal borc = 0;
                    decimal alacak = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Alacak"] == DBNull.Value)
                            alacak = 0;
                        else
                            alacak = Convert.ToDecimal(dt.Rows[i]["Alacak"]);

                        if (dt.Rows[i]["Borc"] == DBNull.Value)
                            borc = 0;
                        else
                            borc = Convert.ToDecimal(dt.Rows[i]["Borc"]);


                        dt.Rows[i]["Bakiye"] = alacak - borc;
                    }
                }
            }

            return dt;
        }

        public static gelirgider Ver_GelirGider(ref otosisdbEntities dbModel, int GelirGiderID)
        {
            gelirgider gg = null;

            gg = (from abc in dbModel.gelirgiders
                  where abc.GelirGiderID == GelirGiderID
                  select abc).FirstOrDefault();

            if (gg != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, gg);
            }

            return gg;
        }

        public static bool Varmi_GelirGiderAd(string GelirGiderAd, string Haric = null)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From gelirgider Where GelirGiderAd=@GelirGiderAd And SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);
                veri.Ekle_Param("@GelirGiderAd", GelirGiderAd, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And GelirGiderAd<>@Haric";
                    veri.Ekle_Param("@Haric", Haric, MySqlDbType.VarChar);
                }

                if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region < Gelir Gider Haraket >
        public static DataTable Ver_GelirGiderHareketler(int GelirGiderID, DateTime KayitZamanBas, DateTime KayitZamanBit)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    GGH.ID,GGH.EvrakTarih,GI.Aciklama IslemTuru,GGH.EvrakNo,
                                    IF(GGH.Borc,Miktar,NULL)BorcTutar,IF(GGH.Borc,NULL,Miktar)AlacakTutar,
                                    GGH.KasaID,K.KasaAd,GGH.BankaID,B.BankaAd
                                    FROM gelirgider_hareket GGH
                                    INNER JOIN genelkodlar GI ON GI.Kod=GGH.IslemTuru
                                    LEFT JOIN kasa K ON K.KasaID=GGH.KasaID
                                    LEFT JOIN banka B ON B.BankaID=GGH.BankaID
                                    WHERE GI.Grup='IslemTuru' AND GGH.GelirGiderID=@GelirGiderID
                                    And GGH.EvrakTarih<=@KayitZamanBitis And GGH.EvrakTarih>=@KayitZamanBas
                                    Order By GGH.KayitZaman Desc";

                veri.Ekle_Param("@GelirGiderID", GelirGiderID, MySqlDbType.Int32);
                veri.Ekle_Param("@KayitZamanBas", KayitZamanBas, MySqlDbType.DateTime);
                veri.Ekle_Param("@KayitZamanBitis", KayitZamanBit, MySqlDbType.DateTime);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static int Ekle_GelirGiderHareket(int GelirGiderID, decimal Miktar, bool Borc, Enumlar.IslemTurleri IslemTuru,
            int? BankaID, int? KasaID, string EvrakNo = null, string Aciklama = null, DateTime? EvrakTarih = null,
            int? BankaHareketID = null, int? KasaHareketID = null)
        {
            using (otosisdbEntities dbModel = new otosisdbEntities(Baglanti.BaglantiEntity))
            {
                gelirgider_hareket ggH = new gelirgider_hareket();
                ggH.GelirGiderID = GelirGiderID;
                ggH.Miktar = Miktar;
                ggH.Borc = Borc;
                ggH.IslemTuru = ((int)IslemTuru).ToString();
                ggH.BankaID = BankaID;
                ggH.KasaID = KasaID;
                ggH.EvrakNo = EvrakNo;
                ggH.Aciklama = Aciklama;
                ggH.EvrakTarih = EvrakTarih;

                ggH.BankaHareketID = BankaHareketID;
                ggH.KasaHareketID = KasaHareketID;

                ggH.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                ggH.KayitZaman = DateTime.Now;

                dbModel.AddTogelirgider_hareket(ggH);
                dbModel.SaveChanges();

                return ggH.ID;
            }
        }

        public static int Ver_AdetGelirGider(int GelirGiderID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select Count(*) From gelirgider_hareket Where GelirGiderID=@GelirGiderID";

                veri.Ekle_Param("@GelirGiderID", GelirGiderID, MySqlDbType.Int32);

                return Convert.ToInt32(veri.ExecuteScalar());
            }
        }
        #endregion
    }
}