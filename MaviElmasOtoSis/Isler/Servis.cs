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
    public class Servis
    {
        #region < Servis >
        public static DataTable Ver_Servisler(DateTime KayitZamanBas, DateTime KayitZamanBit,bool?AcikServis)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT S.ServisID,C.Unvan,A.AracID,A.Plaka,S.KayitZaman,IFNULL(S.TeslimTarih,'Yok')TeslimTarih FROM servis S
                                    INNER JOIN cari_hesap C ON C.CariID=S.CariID
                                    INNER JOIN arac A ON A.AracID=S.AracID
                                    Where S.KayitZaman<=@KayitZamanBitis And S.KayitZaman>=@KayitZamanBas";

                veri.Ekle_Param("@KayitZamanBas", KayitZamanBas, MySqlDbType.DateTime);
                veri.Ekle_Param("@KayitZamanBitis", KayitZamanBit, MySqlDbType.DateTime);

                if (AcikServis != null&&AcikServis.Value)
                {
                    veri.SqlCumlesi += " And S.TeslimTarih is null";
                }
                else if (AcikServis != null && AcikServis.Value == false)
                {
                    veri.SqlCumlesi += " And S.TeslimTarih is not null";
                }

                veri.SqlCumlesi += " Order By S.KayitZaman Desc";

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static servi Ver_Servis(ref otosisdbEntities dbModel, int ServisID)
        {
            servi servis = null;

            servis = (from abc in dbModel.servis
                      where abc.ServisID == ServisID
                      select abc).FirstOrDefault();

            if (servis != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, servis);
            }

            return servis;
        }

        public static bool Varmi_AcikIsemri(int ServisID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "SELECT Count(*) FROM isemri WHERE IsemriKapatma='1' AND ServisID=@ServisID";
                veri.Ekle_Param("@ServisID", ServisID, MySqlDbType.Int32);

                if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                    return true;

                return false;
            }
        }
        #endregion

        #region < İşemri >
        public static DataTable Ver_Isemirleri(int ServisID)
        {
            DataTable dt = null;
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select IsemirID,B.BirimAd From isemri I
                                    Inner Join Birim B On I.BirimID=B.BirimID
                                    Where ServisID=@ServisID";
                veri.Ekle_Param("@ServisID", ServisID, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static DataTable Ver_IsemirleriSecme(string IsemriKapatma)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    I.IsemirID,B.BirimAd,I.ServisID,C.Unvan,
                                    A.Plaka,I.KayitZaman
                                    FROM isemri I
                                    INNER JOIN birim B ON B.BirimID=I.BirimID
                                    INNER JOIN servis S ON S.ServisID=I.ServisID
                                    INNER JOIN cari_hesap C ON C.CariID=S.CariID
                                    INNER JOIN arac A ON A.AracID=S.AracID
                                    Where 1=1 ";

                if (!string.IsNullOrEmpty(IsemriKapatma))
                {
                    veri.SqlCumlesi += " And I.IsemriKapatma=@IsemriKapatma";
                    veri.Ekle_Param("@IsemriKapatma", IsemriKapatma, MySqlDbType.VarChar);
                }

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static DataTable Ver_ParcaIscilikler(int IsemirID)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                //                veri.SqlCumlesi = @"SELECT 
                //SH.ID,S.KartID KartIscilikID,S.KalemAdi KalemIscilikAdi,SH.Miktar,IFNULL(SH.BirimFiyat,0)BirimFiyat
                //,GB.Aciklama Birim,
                //IF(IFNULL(SH.Kdvli,0),'Evet','Hayır')Kdvli,IFNULL(SH.Kdv,0)Kdv,IFNULL(SH.IndirimYuzde,0)IndirimYuzde,
                //D.DepoAd,NULL IscilikTip,'Parça'IscilikMiCaption,0 IscilikMi FROM stok_hareket SH
                //INNER JOIN stok_kart S ON SH.StokKartID=S.KartID
                //INNER JOIN genelkodlar GB ON GB.Kod=S.StokBirim
                //INNER JOIN stok_depo D ON SH.DepoID=D.DepoID
                //INNER JOIN isemri_talep IT ON IT.TalepID=SH.TalepID
                //WHERE GB.Grup='StokBirim' AND IT.IsemirID=@IsemirID
                //UNION ALL
                //SELECT 
                //IH.ID,I.IscilikID KartIscilikID,I.IscilikAd KalemIscilikAdi,IH.Miktar,IFNULL(IH.BirimFiyat,0)BirimFiyat,
                //'Saat' Birim,IF(IFNULL(IH.Kdvli,0),'Evet','Hayır')Kdvli,IFNULL(IH.Kdv,0)Kdv,IFNULL(IH.IndirimYuzde,0)IndirimYuzde,
                //NULL DepoAd,GI.Aciklama IscilikTip,'İşçilik'IscilikMiCaption,1 IscilikMi
                //FROM iscilik_hareket IH
                //INNER JOIN iscilik I ON I.IscilikID=IH.IscilikID
                //INNER JOIN genelkodlar GI ON GI.Kod=IH.IscilikTip
                //INNER JOIN isemri_talep IT ON IT.TalepID=IH.TalepID
                //WHERE GI.Grup='IscilikTip'AND IT.IsemirID=@IsemirID";

                veri.SqlCumlesi = @"SELECT 
SH.ID,S.KartID,NULL IscilikID,S.KalemAdi KalemIscilikAdi,SH.Miktar,IFNULL(SH.BirimFiyat,0)BirimFiyat
,S.StokBirim Birim,
IF(IFNULL(SH.Kdvli,0),'Evet','Hayır')Kdvli,IFNULL(SH.Kdv,0)Kdv,IFNULL(SH.IndirimYuzde,0)IndirimYuzde,
SH.DepoID,NULL IscilikTip,0 IscilikMi FROM stok_hareket SH
INNER JOIN stok_kart S ON SH.StokKartID=S.KartID
UNION ALL
SELECT 
IH.ID,NULL KartID,I.IscilikID,I.IscilikAd KalemIscilikAdi,IH.Miktar,IFNULL(IH.BirimFiyat,0)BirimFiyat,
-1 Birim,IF(IFNULL(IH.Kdvli,0),'Evet','Hayır')Kdvli,IFNULL(IH.Kdv,0)Kdv,IFNULL(IH.IndirimYuzde,0)IndirimYuzde,
NULL DepoID,I.IscilikTip,1 IscilikMi
FROM iscilik_hareket IH
INNER JOIN iscilik I ON I.IscilikID=IH.IscilikID";

                veri.Ekle_Param("@IsemirID", IsemirID, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static isemri Ver_Isemri(ref otosisdbEntities dbModel, int IsemirID)
        {
            isemri ism = null;

            ism = (from abc in dbModel.isemris
                   where abc.IsemirID == IsemirID
                   select abc).FirstOrDefault();

            //if (ism != null)
            //{
            //    dbModel.Refresh(RefreshMode.StoreWins, ism);
            //}

            return ism;
        }

        public static int Ver_AdetIsemirleri(int ServisID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From isemri Where ServisID=@ServisID";
                veri.Ekle_Param("@ServisID", ServisID, MySqlDbType.Int32);
                return Convert.ToInt32(veri.ExecuteScalar());
            }
        }

        public static void Guncelle_IsemriKapatma(int IsemirID, Enumlar.IsemriKapatmalari IsemriKapatma)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Update isemri Set IsemriKapatma=@IsemriKapatma Where IsemirID=@IsemirID";
                veri.Ekle_Param("@IsemirID", IsemirID, MySqlDbType.Int32);
                veri.Ekle_Param("@IsemriKapatma", ((int)IsemriKapatma).ToString(), MySqlDbType.VarChar);
                veri.ExecuteNonQuery();
            }
        }
        public static void Guncelle_IsemriFatura(int IsemriID, int FaturaID, Enumlar.IsemriKapatmalari IsemriKapatma, DateTime BitisTarih)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Update isemri Set FaturaID=@FaturaID,IsemriKapatma=@IsemriKapatma,BitisTarih=@BitisTarih
                                    Where IsemirID=@IsemirID";
                veri.Ekle_Param("@FaturaID", FaturaID, MySqlDbType.Int32);
                veri.Ekle_Param("@IsemriKapatma", ((int)IsemriKapatma).ToString(), MySqlDbType.VarChar);
                veri.Ekle_Param("@BitisTarih", BitisTarih, MySqlDbType.Date);
                veri.Ekle_Param("@IsemirID", IsemriID, MySqlDbType.Int32);
                veri.ExecuteNonQuery();
            }
        }

        public static bool Varmi_BirimID(int ServisID, int BirimID, int? Haric = null)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From isemri Where ServisID=@ServisID And BirimID=@BirimID";
                veri.Ekle_Param("@BirimID", BirimID, MySqlDbType.Int32);
                veri.Ekle_Param("@ServisID", ServisID, MySqlDbType.Int32);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And BirimID<>@Haric";
                    veri.Ekle_Param("@Haric", BirimID, MySqlDbType.Int32);
                }

                if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region < Talep >
        public static DataTable Ver_Talepler(int IsemirID)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select TalepID,Sira,Talep,IF(Yapildi,'Yapıldı','Yapılmadı') Yapildi
                                    From isemri_talep 
                                    Where IsemirID=@IsemirID
                                    Order By Sira Asc";
                veri.Ekle_Param("@IsemirID", IsemirID, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static isemri_talep Ver_Talep(ref otosisdbEntities dbModel, int TalepID)
        {
            isemri_talep talep = null;

            talep = (from abc in dbModel.isemri_talep
                     where abc.TalepID == TalepID
                     select abc).FirstOrDefault();

            if (talep != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, talep);
            }

            return talep;
        }
        #endregion
    }
}