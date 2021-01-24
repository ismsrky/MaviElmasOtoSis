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
    public class Cari
    {
        #region < Cari >
        public static DataTable Ver_Cariler(bool? Durum = null)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select C.CariID,C.Unvan,GG.Aciklama As CariHesapGrup,C.TcKimlikNo,
                                    Concat(YetkiliKisiAd,' ',YetkiliKisiSoyad) As YetkiliKisi,C.Tel1,C.Tel2,
                                    IF(C.Durum,'Aktif','Pasif') Durum,
                                    (SELECT SUM(Miktar) FROM cari_hareket WHERE Borc=1 And CariID=C.CariID)Borc,
                                    (SELECT SUM(Miktar) FROM cari_hareket WHERE Borc=0 And CariID=C.CariID)Alacak
                                    From cari_hesap As C
                                    Inner Join genelkodlar As GG On C.CariHesapGrup=GG.Kod
                                    Where C.SirketID=@SirketID And GG.Grup='CariHesapGrup'";

                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);

                if (Durum != null)
                {
                    veri.SqlCumlesi += " And C.Durum=@Durum";
                    veri.Ekle_Param("@Durum", Durum, MySqlDbType.Bit);
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


                        dt.Rows[i]["Bakiye"] = borc - alacak;
                    }
                }
            }

            return dt;
        }

        public static cari_hesap Ver_CariHesap(ref otosisdbEntities dbModel, int CariID)
        {
            cari_hesap cari = null;

            cari = (from abc in dbModel.cari_hesap
                    where abc.CariID == CariID
                    select abc).FirstOrDefault();

            //if (cari != null)
            //{
            //    dbModel.Refresh(RefreshMode.StoreWins, cari);
            //}

            return cari;
        }

        public static bool Varmi_CariUnvan(string Unvan, string Haric = null)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From cari_hesap Where Unvan=@Unvan And SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);
                veri.Ekle_Param("@Unvan", Unvan, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And Unvan<>@Haric";
                    veri.Ekle_Param("@Haric", Haric, MySqlDbType.VarChar);
                }

                if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static string Ver_CariUnvan(int CariID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Unvan From cari_hesap Where CariID=@CariID";
                veri.Ekle_Param("@CariID", CariID, MySqlDbType.Int32);
                return veri.ExecuteScalar().ToString();
            }
        }
        #endregion

        #region < Cari Hareket >
        public static DataTable Ver_CariHareketler(int CariID, DateTime KayitZamanBas, DateTime KayitZamanBit)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    CH.ID,CH.KayitZaman,GI.Aciklama IslemTuru,CH.EvrakNo,
                                    IF(CH.Borc,Miktar,NULL)BorcTutar,IF(CH.Borc,NULL,Miktar)AlacakTutar,
                                    CH.KasaID,K.KasaAd,CH.FaturaID,CH.BankaID,B.BankaAd,CH.EvrakTarih
                                    FROM cari_hareket CH
                                    INNER JOIN genelkodlar GI ON GI.Kod=CH.IslemTuru
                                    LEFT JOIN kasa K ON K.KasaID=CH.KasaID
                                    LEFT JOIN banka B ON B.BankaID=CH.BankaID
                                    WHERE GI.Grup='IslemTuru' And CH.CariID=@CariID
                                    And CH.KayitZaman<=@KayitZamanBitis And CH.KayitZaman>=@KayitZamanBas
                                    Order By CH.KayitZaman Desc";

                veri.Ekle_Param("@CariID", CariID, MySqlDbType.Int32);
                veri.Ekle_Param("@KayitZamanBas", KayitZamanBas, MySqlDbType.DateTime);
                veri.Ekle_Param("@KayitZamanBitis", KayitZamanBit, MySqlDbType.DateTime);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static int Ekle_CariHareket(int CariID, decimal Miktar, bool Borc, Enumlar.IslemTurleri IslemTuru,
            int? FaturaID, int? BankaID, int? KasaID, string EvrakNo = null, string Aciklama = null, DateTime? EvrakTarih = null,
             int? BankaHareketID = null, int? KasaHareketID = null)
        {
            using (otosisdbEntities dbModel = new otosisdbEntities(Baglanti.BaglantiEntity))
            {
                cari_hareket ch = new cari_hareket();
                ch.CariID = CariID;
                ch.Miktar = Miktar;
                ch.Borc = Borc;
                ch.IslemTuru = ((int)IslemTuru).ToString();
                ch.FaturaID = FaturaID;
                ch.BankaID = BankaID;
                ch.KasaID = KasaID;
                ch.EvrakNo = EvrakNo;
                ch.Aciklama = Aciklama;
                ch.EvrakTarih = EvrakTarih;

                ch.BankaHareketID = BankaHareketID;
                ch.KasaHareketID = KasaHareketID;

                ch.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                ch.KayitZaman = DateTime.Now;

                dbModel.AddTocari_hareket(ch);
                dbModel.SaveChanges();

                return ch.ID;
            }
        }

        public static int Ver_AdetCariHareket(int CariID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select
                                    (Select Count(*) From banka_hareket Where CariID=@CariID)+
                                    (Select Count(*) From cari_hareket Where CariID=@CariID)+
                                    (SELECT COUNT(*) FROM kasa_hareket Where CariID=@CariID)+
                                    (SELECT COUNT(*) FROM servis Where CariID=@CariID)+
                                    (SELECT COUNT(*) FROM fatura Where CariID=@CariID)";

                veri.Ekle_Param("@CariID", CariID, MySqlDbType.Int32);

                return Convert.ToInt32(veri.ExecuteScalar());
            }
        }
        #endregion
    }
}