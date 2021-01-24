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
    public class Banka
    {
        #region < Banka >
        public static DataTable Ver_Bankalar(bool? Durum = null)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT
                                    B.BankaID,B.BankaAd,GH.Aciklama HesapTuru,
                                    CONCAT(B.IlgiliKisiAd,' ',B.IlgiliKisiSoyad) IlgiliKisi,
                                    IF(B.Durum,'Aktif','Pasif')Durum,
                                    (SELECT SUM(Miktar) FROM banka_hareket WHERE Yatan=1 AND BankaID=B.BankaID)Yatirilan,
                                    (SELECT SUM(Miktar) FROM banka_hareket WHERE Yatan=0 AND BankaID=B.BankaID)Cekilen
                                    FROM banka B
                                    INNER JOIN genelkodlar GH ON GH.Kod=B.HesapTuru
                                    WHERE GH.Grup='BankaHesapTuru' AND B.SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);

                if (Durum != null)
                {
                    veri.SqlCumlesi += " And B.Durum=@Durum";
                    veri.Ekle_Param("@Durum", Durum.Value, MySqlDbType.Bit);
                }

                dt = veri.Ver_DataTable();

                if (dt != null)
                {
                    dt.Columns.Add("Bakiye", typeof(decimal));

                    decimal yatirilan = 0;
                    decimal cekilen = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Cekilen"] == DBNull.Value)
                            cekilen = 0;
                        else
                            cekilen = Convert.ToDecimal(dt.Rows[i]["Cekilen"]);

                        if (dt.Rows[i]["Yatirilan"] == DBNull.Value)
                            yatirilan = 0;
                        else
                            yatirilan = Convert.ToDecimal(dt.Rows[i]["Yatirilan"]);


                        dt.Rows[i]["Bakiye"] = yatirilan - cekilen;
                    }
                }
            }

            return dt;
        }

        public static banka Ver_Banka(ref otosisdbEntities dbModel, int BankaID)
        {
            banka bk = null;

            bk = (from abc in dbModel.bankas
                  where abc.BankaID == BankaID
                  select abc).FirstOrDefault();

            if (bk != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, bk);
            }

            return bk;
        }

        public static bool Varmi_BankaAd(string BankaAd, string Haric = null)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From banka Where BankaAd=@BankaAd And SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);
                veri.Ekle_Param("@BankaAd", BankaAd, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And BankaAd<>@Haric";
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

        #region < Banka Hareket >
        public static banka_hareket Ver_BankaHareket(ref otosisdbEntities dbModel, int ID)
        {
            banka_hareket bh = null;

            bh = (from abc in dbModel.banka_hareket
                  where abc.ID == ID
                  select abc).FirstOrDefault();

            if (bh != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, bh);
            }

            return bh;
        }

        public static DataTable Ver_BankaHareketler(int BankaID, DateTime KayitZamanBas, DateTime KayitZamanBit)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    BH.ID,BH.KayitZaman,GI.Aciklama IslemTuru,BH.EvrakNo,BH.EvrakTarih,
                                    IF(BH.Yatan,Miktar,NULL)YatanTutar,IF(BH.Yatan,NULL,Miktar)CekilenTutar,
                                    BH.KasaID,K.KasaAd,BH.FaturaID,BH.CariID,C.Unvan
                                    FROM banka_hareket BH
                                    INNER JOIN genelkodlar GI ON GI.Kod=BH.IslemTuru
                                    LEFT JOIN kasa K ON K.KasaID=BH.KasaID
                                    LEFT JOIN cari_hesap C On C.CariID=BH.CariID
                                    WHERE GI.Grup='IslemTuru' And BH.BankaID=@BankaID
                                    And BH.EvrakTarih<=@KayitZamanBitis And BH.EvrakTarih>=@KayitZamanBas
                                    Order By BH.KayitZaman Desc";

                veri.Ekle_Param("@BankaID", BankaID, MySqlDbType.Int32);
                veri.Ekle_Param("@KayitZamanBas", KayitZamanBas, MySqlDbType.DateTime);
                veri.Ekle_Param("@KayitZamanBitis", KayitZamanBit, MySqlDbType.DateTime);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static int Ekle_BankaHareket(int BankaID, decimal Miktar, bool Yatan,
            Enumlar.IslemTurleri IslemTuru, int? GelirGiderID, int? PersonelID, int? CariID, int? FaturaID, int? KasaID,
            string EvrakNo = null, string Aciklama = null, DateTime? EvrakTarih = null, int? KasaHareketID = null)
        {
            using (otosisdbEntities dbModel = new otosisdbEntities(Baglanti.BaglantiEntity))
            {
                banka_hareket bh = new banka_hareket();
                bh.BankaID = BankaID;
                bh.Miktar = Miktar;
                bh.Yatan = Yatan;
                bh.IslemTuru = ((int)IslemTuru).ToString();
                bh.GelirGiderID = GelirGiderID;
                bh.PersonelID = PersonelID;
                bh.CariID = CariID;
                bh.FaturaID = FaturaID;
                bh.KasaID = KasaID;
                bh.EvrakNo = EvrakNo;
                bh.Aciklama = Aciklama;
                bh.EvrakTarih = EvrakTarih;

                bh.KasaHareketID = KasaHareketID;

                bh.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                bh.KayitZaman = DateTime.Now;

                dbModel.AddTobanka_hareket(bh);
                dbModel.SaveChanges();

                return bh.ID;
            }
        }

        public static int Ver_AdetBankaHareket(int BankaID)
        {
            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = @"Select
                                    (Select Count(*) From banka_hareket Where BankaID=@BankaID)+
                                    (Select Count(*) From cari_hareket Where BankaID=@BankaID)+
                                    (SELECT COUNT(*) FROM kasa_hareket Where BankaID=@BankaID)+
                                    (SELECT COUNT(*) FROM personel_cari_hareket Where BankaID=@BankaID)+
                                    (SELECT COUNT(*) FROM fatura Where BankaID=@BankaID)";

                veri.Ekle_Param("@BankaID", BankaID, MySqlDbType.Int32);

                return Convert.ToInt32(veri.ExecuteScalar());
            }
        }
        #endregion
    }
}