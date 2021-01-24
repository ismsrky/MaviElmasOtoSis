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
    public class Personel
    {
        #region < Personel >
          public static DataTable Ver_Personeller(bool? IstenAyrildi=null)
        {
            DataTable dt = null;

            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT
P.PersonelID,P.TcKimlikNo,P.Ad,P.Soyad,GU.Aciklama Unvan,concat(P.Ad,' ',P.Soyad)AdSoyad,
GC.Aciklama Cinsiyet,GK.Aciklama KanGrup,IF(P.KanGrupRH IS NULL,NULL,IF(P.KanGrupRH=1,'+','-')) RH
FROM Personel P
INNER JOIN genelkodlar GU ON P.Unvan=GU.Kod
INNER JOIN genelkodlar GC ON P.Cinsiyet=GC.Kod
LEFT JOIN genelkodlar GK ON P.KanGrup=GK.Kod
WHERE P.SirketID And GU.Grup='Unvan' AND GC.Grup='Cinsiyet'
AND (GK.Grup IS NULL OR GK.Grup='KanGrup')";

                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);

                if (IstenAyrildi != null)
                {
                    veri.SqlCumlesi += " And P.IstenAyrildi=@IstenAyrildi";
                    veri.Ekle_Param("@IstenAyrildi", IstenAyrildi, MySqlDbType.Bit);
                }
                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static personel Ver_Personel(ref otosisdbEntities dbModel, int PersonelID)
        {
            personel per = null;

            per = (from abc in dbModel.personels
                   where abc.PersonelID == PersonelID
                   select abc).FirstOrDefault();

            if (per != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, per);
            }

            return per;

        }

        public static bool Varmi_TcKimlik(int SirketID, string TcKimlikNo, string Haric=null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From personel Where SirketID=@SirketID And TcKimlikNo=@TcKimlikNo";
                veri.Ekle_Param("@TcKimlikNo", TcKimlikNo, MySqlDbType.VarChar);
                veri.Ekle_Param("@SirketID", SirketID, MySqlDbType.Int32);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And TcKimlikNo<>@Haric";
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

        public static string Ver_AdSoyad(int PersonelID)
        {
            string Sonuc = "";
            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = "SELECT CONCAT(Ad,' ',Soyad)AdSoyad FROM personel WHERE PersonelID=@PersonelID";
                veri.Ekle_Param("@PersonelID", PersonelID, MySqlDbType.Int32);

                Sonuc = veri.ExecuteScalar().ToString();
            }

            return Sonuc;
        }
        #endregion

        #region < Personel Cari Hareket >
        public static int Ekle_PersonelHareket(int PersonelID, decimal Miktar, bool Borc, Enumlar.IslemTurleri IslemTuru,
            int? BankaID, int? KasaID, string Aciklama = null, string EvrakNo = null, DateTime? EvrakTarih=null,
             int? BankaHareketID = null, int? KasaHareketID = null)
        {
            using (otosisdbEntities dbModel = new otosisdbEntities(Baglanti.BaglantiEntity))
            {
                personel_cari_hareket pch = new personel_cari_hareket();
                pch.PersonelID = PersonelID;
                pch.Miktar = Miktar;
                pch.Borc = Borc;
                pch.IslemTuru = ((int)IslemTuru).ToString();
                pch.BankaID = BankaID;
                pch.KasaID = KasaID;
                pch.Aciklama = Aciklama;
                pch.EvrakNo = EvrakNo;
                pch.EvrakTarih = EvrakTarih;

                pch.BankaHareketID = BankaHareketID;
                pch.KasaHareketID = KasaHareketID;

                pch.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                pch.KayitZaman = DateTime.Now;
                dbModel.AddTopersonel_cari_hareket(pch);
                dbModel.SaveChanges();

                return pch.ID;
            }
        }

        public static int Ver_AdetPersonelHareket(int PersonelID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select
                                    (SELECT COUNT(*) FROM personel_cari_hareket Where PersonelID=@PersonelID)+
                                    (SELECT COUNT(*) FROM iscilik_hareket_personel Where PersonelID=@PersonelID)";

                veri.Ekle_Param("@PersonelID", PersonelID, MySqlDbType.Int32);

                return Convert.ToInt32(veri.ExecuteScalar());
            }
        }
        #endregion
    }
}