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
    public class Kasa
    {
        #region < Kasa >
        public static kasa Ver_Kasa(ref otosisdbEntities dbModel, int KasaID)
        {
            kasa ks = null;

            ks = (from abc in dbModel.kasas
                  where abc.KasaID == KasaID
                  select abc).FirstOrDefault();

            if (ks != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, ks);
            }

            return ks;
        }

        public static DataTable Ver_Kasalar(bool? Durum = null)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    K.KasaID,K.KasaAd,IF(K.Durum,'Aktif','Pasif')Durum,
                                    (SELECT SUM(Miktar) FROM kasa_hareket WHERE Tahsilat=1 AND KasaID=K.KasaId)Tahsilat,
                                    (SELECT SUM(Miktar) FROM kasa_hareket WHERE Tahsilat=0 AND KasaID=K.KasaId)Odeme
                                    FROM kasa K
                                    WHERE K.SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);

                if (Durum != null)
                {
                    veri.SqlCumlesi += " And K.Durum=@Durum";
                    veri.Ekle_Param("@Durum", Durum.Value, MySqlDbType.Bit);
                }

                dt = veri.Ver_DataTable();

                if (dt != null)
                {
                    dt.Columns.Add("Bakiye", typeof(decimal));

                    decimal tahsilat = 0;
                    decimal odeme = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Odeme"] == DBNull.Value)
                            odeme = 0;
                        else
                            odeme = Convert.ToDecimal(dt.Rows[i]["Odeme"]);

                        if (dt.Rows[i]["Tahsilat"] == DBNull.Value)
                            tahsilat = 0;
                        else
                            tahsilat = Convert.ToDecimal(dt.Rows[i]["Tahsilat"]);

                        dt.Rows[i]["Bakiye"] = tahsilat - odeme;
                    }
                }
            }

            return dt;
        }

        public static bool Varmi_KasaAd(string KasaAd, string Haric = null)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From kasa Where KasaAd=@KasaAd And SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);
                veri.Ekle_Param("@KasaAd", KasaAd, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And KasaAd<>@Haric";
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

        #region < Kasa Haraket >
        public static kasa_hareket Ver_KasaHareket(ref otosisdbEntities dbModel, int ID)
        {
            kasa_hareket kh = null;

            kh = (from abc in dbModel.kasa_hareket
                  where abc.ID == ID
                  select abc).FirstOrDefault();

            if (kh != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, kh);
            }

            return kh;
        }

        public static DataTable Ver_KasaHareketleri(int KasaID, DateTime KayitZamanBas, DateTime KayitZamanBit)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    KH.ID,KH.EvrakTarih,KH.EvrakNo,KH.Miktar,KH.Tahsilat,
                                    KH.CariID,C.Unvan CariUnvan,GI.Aciklama KasaIslemTuru,
                                    KH.GelirGiderID,G.GelirGiderAd,KH.BankaID,B.BankaAd,
                                    IF(KH.Tahsilat,Miktar,null)TahsilatMiktar,
                                    IF(KH.Tahsilat,null,Miktar)OdemeMiktar
                                    FROM kasa_hareket KH
                                    INNER JOIN genelkodlar GI ON GI.Kod=KH.KasaIslemTuru
                                    LEFT JOIN cari_hesap C ON C.CariID=KH.CariID
                                    LEFT JOIN gelirgider G ON G.GelirGiderID=KH.GelirGiderID
                                    LEFT JOIN banka B ON B.BankaID=KH.BankaID
                                    WHERE GI.Grup='IslemTuru' And KH.KasaID=@KasaID
                                    And KH.EvrakTarih<=@KayitZamanBitis And KH.EvrakTarih>=@KayitZamanBas
                                    Order By KH.KayitZaman Asc";
                veri.Ekle_Param("@KasaID", KasaID, MySqlDbType.Int32);
                veri.Ekle_Param("@KayitZamanBas", KayitZamanBas, MySqlDbType.DateTime);
                veri.Ekle_Param("@KayitZamanBitis", KayitZamanBit, MySqlDbType.DateTime);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static int Ekle_KasaHareket(int KasaID, decimal Miktar, bool Tahsilat, Enumlar.IslemTurleri IslemTuru,
            int? CariID, int? GelirGiderID, int? BankaID, int? FaturaID, int? VirmanKasaID, string EvrakNo = null,
            string Aciklama = null,DateTime?EvrakTarih=null,int?KasaHareketID=null)
        {
            using (otosisdbEntities dbModel = new otosisdbEntities(Baglanti.BaglantiEntity))
            {
                int t_islemturu = (int)IslemTuru;
                kasa_hareket kh = new kasa_hareket();
                kh.KasaID = KasaID;
                kh.Miktar = Miktar;
                kh.KasaIslemTuru = t_islemturu.ToString();
                kh.EvrakNo = EvrakNo;
                kh.Aciklama = Aciklama;
                kh.FaturaID = FaturaID;
                kh.EvrakTarih = EvrakTarih;

                kh.KasaHareketID = KasaHareketID;

                kh.Tahsilat = Tahsilat;

                //if ((t_islemturu == 1 || t_islemturu == 2) || GelirGiderID != null)
                //{
                kh.GelirGiderID = GelirGiderID;
                //}
                //if (t_islemturu == 6 || t_islemturu == 7)
                //{
                kh.BankaID = BankaID;
                //}
                //if (t_islemturu == 8 || t_islemturu == 9)
                //{
                kh.CariID = CariID;
                //}

                //if (t_islemturu == 3)
                //{
                kh.VirmanKasaID = VirmanKasaID;
                //}

                kh.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                kh.KayitZaman = DateTime.Now;

                dbModel.AddTokasa_hareket(kh);
                dbModel.SaveChanges();

                return kh.ID;
            }
        }
        #endregion
    }
}