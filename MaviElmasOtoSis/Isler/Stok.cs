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
    public class Stok
    {
        #region < Stok Kart >
        public static DataTable Ver_StokKartlari(bool? Durum = null)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select SK.KartID,SK.KalemAdi,SK.ParcaNo,SK.BarkodNo,
                                    GB.Aciklama As StokBirim,GG.Aciklama As StokGrup,
                                   (SELECT 
                                    IFNULL(SUM(Miktar),0)-IFNULL((SELECT SUM(Miktar)  FROM stok_hareket WHERE StokKartID=SK.KartID AND Giris=0),0) Mevcut
                                    FROM stok_hareket
                                    WHERE StokKartID=SK.KartID AND Giris=1)StokMiktar
                                    From stok_kart As SK
                                    Inner Join genelkodlar As GB On SK.StokBirim=GB.Kod
                                    Inner Join genelkodlar As GG On SK.StokGrup=GG.Kod
                                    Where SirketID=@SirketID And GB.Grup='StokBirim' And GG.Grup='StokGrup'";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);

                if (Durum != null)
                {
                    veri.SqlCumlesi += " And SK.Durum=@Durum";
                    veri.Ekle_Param("@Durum", Durum, MySqlDbType.Bit);
                }
                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static stok_kart Ver_StokKart(ref otosisdbEntities DbModel, int _KartID)
        {
            stok_kart kart = null;

            kart = (from abc in DbModel.stok_kart
                    where abc.KartID == _KartID
                    select abc).FirstOrDefault();

            if (kart != null)
            {
                DbModel.Refresh(RefreshMode.StoreWins, kart);
            }

            return kart;
        }
        public static stok_kart Ver_StokKart(ref otosisdbEntities DbModel, string ParcaNo)
        {
            stok_kart kart = null;

            kart = (from abc in DbModel.stok_kart
                    where abc.ParcaNo==ParcaNo
                    select abc).FirstOrDefault();

            if (kart != null)
            {
                DbModel.Refresh(RefreshMode.StoreWins, kart);
            }

            return kart;
        }

        /// <summary>
        /// Bu stok kartına ait tüm uyumlu marka ve modelleri siler ve parça hepsiyle uyumlu olur.
        /// </summary>
        /// <param name="KartID"></param>
        public static void Sil_KartMarkalari(int KartID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Delete From stok_kart_marka where StokKartID=@StokKartID";
                veri.Ekle_Param("@StokKartID", KartID, MySqlDbType.Int32);
                veri.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Verilen stok kartının tüm modellerini siler ve hep o markanın tüm modelleriyle uyumlu olur.
        /// </summary>
        /// <param name="KartID"></param>
        /// <param name="MarkaID"></param>
        public static void Sil_KartModeller(int KartID, int MarkaID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Delete From stok_kart_marka where StokKartID=@StokKartID And MarkaID=@MarkaID;";
                veri.SqlCumlesi += "Insert into stok_kart_marka (StokKartID,MarkaID,ModelID)values(@StokKartID,@MarkaID,-1)";
                veri.Ekle_Param("@StokKartID", KartID, MySqlDbType.Int32);
                veri.Ekle_Param("@MarkaID", MarkaID, MySqlDbType.Int32);
                veri.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// İstenen uyumlu marka/modeli siler.
        /// </summary>
        /// <param name="ID"></param>
        public static void Sil_KartMarka(int ID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Delete From stok_kart_marka where ID=@ID";
                veri.Ekle_Param("@ID", ID, MySqlDbType.Int32);
                veri.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Verilen karta uyumlu marka ve modeli ekler
        /// </summary>
        /// <param name="KartID"></param>
        /// <param name="MarkaID"></param>
        /// <param name="ModelID"></param>
        public static void Ekle_KartModel(int KartID, int MarkaID, int ModelID)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Delete From stok_kart_marka where StokKartID=@StokKartID And MarkaID=@MarkaID And ModelID=-1;";
                veri.SqlCumlesi += "Insert into stok_kart_marka (StokKartID,MarkaID,ModelID)values(@StokKartID,@MarkaID,@ModelID)";
                veri.Ekle_Param("@StokKartID", KartID, MySqlDbType.Int32);
                veri.Ekle_Param("@MarkaID", MarkaID, MySqlDbType.Int32);
                veri.Ekle_Param("@ModelID", ModelID, MySqlDbType.Int32);
                veri.ExecuteNonQuery();
            }
        }

        public static bool Varmi_KartModel(int KartID, int MarkaID, int ModelID)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From stok_kart_marka Where StokKartID=@StokKartID And MarkaID=@MarkaID And ModelID=@ModelID";
                veri.Ekle_Param("@StokKartID", KartID, MySqlDbType.Int32);
                veri.Ekle_Param("@MarkaID", MarkaID, MySqlDbType.Int32);
                veri.Ekle_Param("@ModelID", ModelID, MySqlDbType.Int32);

                if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                {
                    Sonuc = true;
                }
            }

            return Sonuc;
        }

        public static bool Varmi_KalemAd(int SirketID, string KalemAdi, string Haric = null)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From stok_kart Where KalemAdi=@KalemAdi And SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);
                veri.Ekle_Param("@KalemAdi", KalemAdi, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And KalemAdi<>@Haric";
                    veri.Ekle_Param("@Haric", Haric, MySqlDbType.VarChar);
                }

                if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool Varmi_ParcaNo(int SirketID, string ParcaNo, string Haric = null)
        {
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From stok_kart Where ParcaNo=@ParcaNo And SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);
                veri.Ekle_Param("@ParcaNo", ParcaNo, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And ParcaNo<>@Haric";
                    veri.Ekle_Param("@Haric", Haric, MySqlDbType.VarChar);
                }

                if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static DataTable Ver_KartMarkalar(int KartID)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select KM.ID,MA.MarkaAdi,IFNULL(MO.ModelAdi,'Tümü')As ModelAdi From stok_kart_marka As KM
                                    Inner Join araba_marka As MA On MA.MarkaID=KM.MarkaID
                                    Left Join araba_model As MO On MO.ModelID=KM.ModelID
                                    Where KM.StokKartID=@KartID";

                veri.Ekle_Param("@KartID", KartID, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static string Ver_KalemAdi(int KartID)
        {
            string Sonuc = "";
            bool Bulundu = false;
            if (Genel.dt_StokKartlarSecim != null && Genel.dt_StokKartlarSecim.Rows.Count > 0)
            {
                for (int i = 0; i < Genel.dt_StokKartlarSecim.Rows.Count; i++)
                {
                    if (Convert.ToInt32(Genel.dt_StokKartlarSecim.Rows[i]["KartID"]) == KartID)
                    {
                        Sonuc = Genel.dt_StokKartlarSecim.Rows[i]["KalemAdi"].ToString();
                        Bulundu = true;
                        break;
                    }
                }
            }

            if (!Bulundu)
            {
                using (VeriErisim veri = new VeriErisim())
                {
                    veri.SqlCumlesi = "Select KalemAdi from stok_kart Where KartID=@KartID";
                    veri.Ekle_Param("@KartID", KartID, MySqlDbType.Int32);

                    Sonuc = veri.ExecuteScalar().ToString();
                }
            }

            return Sonuc;
        }

        public static int StokAdet(int KartID, int DepoID)
        {
            int Sonuc = 0;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    IFNULL(SUM(Miktar)-
                                    IFNULL((SELECT SUM(Miktar)  FROM stok_hareket WHERE DepoID=@DepoID AND StokKartID=@KartID AND Giris=0),0),0) Mevcut
                                    FROM stok_hareket
                                    WHERE DepoID=@DepoID AND StokKartID=@KartID AND Giris=1";

                veri.Ekle_Param("@KartID", KartID, MySqlDbType.Int32);
                veri.Ekle_Param("@DepoID", DepoID, MySqlDbType.Int32);

                Sonuc = Convert.ToInt32(veri.ExecuteScalar());
            }

            return Sonuc;
        }
        #endregion

        #region < Eşdeğer Parça >
        public static DataTable Ver_Esdegerler(int KartID)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT SKE.ID,SKE.EsdegerKartID,SK.KalemAdi FROM stok_kart_esdeger SKE
                                    INNER JOIN stok_kart SK ON SKE.EsdegerKartID=SK.KartID
                                    Where SKE.StokKartID=@KartID";
                veri.Ekle_Param("@KartID", KartID, MySqlDbType.Int32);
                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static stok_kart_esdeger Ver_Esdeger(ref otosisdbEntities dbModel, int _ID)
        {
            stok_kart_esdeger esdeger = null;

            esdeger = (from abc in dbModel.stok_kart_esdeger
                       where abc.ID == _ID
                       select abc).FirstOrDefault();

            if (esdeger != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, esdeger);
            }

            return esdeger;
        }

        public static bool Varmi_Esdegeri(int KartID, int EsdegerKartID)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "SELECT COUNT(*) FROM stok_kart_esdeger WHERE StokKartID=@KartID AND EsdegerKartID=@EsdegerKartID";
                veri.Ekle_Param("@KartID", KartID, MySqlDbType.Int32);
                veri.Ekle_Param("@EsdegerKartID", EsdegerKartID, MySqlDbType.Int32);

                if (Convert.ToInt32(veri.ExecuteScalar()) > 0)
                {
                    Sonuc = true;
                }
            }

            return Sonuc;
        }
        #endregion

        #region < Stok Hareketleri >
        public static DataTable Ver_StokHareketleri(DateTime? KayitZamanBas, DateTime? KayitZamanBit, int DepoID)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    SK.ID,S.KalemAdi,IF (SK.Giris,'Giriş','Çıkış') GirisCikis,SK.StokKartID,
                                    GH.Aciklama StokHareketTipi,SK.KayitZaman,S.ParcaNo,SK.Miktar,SK.BirimFiyat,
                                    A.Plaka,SK.FaturaID,SK.IsemirID,SE.ServisID
                                    FROM stok_hareket AS SK
                                    INNER JOIN stok_kart AS S ON S.KartID=SK.StokKartID
                                    INNER JOIN genelkodlar AS GH ON GH.Kod=SK.StokHareketTipi
                                    LEFT JOIN arac A On A.AracID=SK.AracID
                                    LEFT JOIN isemri I On I.IsemirID=SK.IsemirID
                                    LEFT JOIN servis SE On SE.ServisID=I.ServisID
                                    WHERE S.SirketID=@SirketID And GH.Grup='StokHareketTipi'
                                    And SK.DepoID=@DepoID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);
                veri.Ekle_Param("@DepoID", DepoID, MySqlDbType.Int32);
                if (KayitZamanBas != null)
                {
                    veri.SqlCumlesi += " And SK.KayitZaman>=@KayitZamanBas";
                    veri.Ekle_Param("@KayitZamanBas", KayitZamanBas.Value, MySqlDbType.DateTime);
                }
                if (KayitZamanBit != null)
                {
                    veri.SqlCumlesi += " And SK.KayitZaman<=@KayitZamanBit";
                    veri.Ekle_Param("@KayitZamanBit", KayitZamanBit.Value, MySqlDbType.DateTime);
                }

                veri.SqlCumlesi += " Order By SK.KayitZaman Desc";

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static DataTable Ver_StokHareketleri(int TalepID)
        {
            DataTable dt = null;

            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT 
                                    SK.ID,S.KalemAdi,SK.StokKartID,S.ParcaNo,
                                    S.BarkodNo,GB.Aciklama StokBirim,D.DepoAd,SK.Miktar,SK.BirimFiyat
                                    FROM stok_hareket AS SK
                                    INNER JOIN stok_kart AS S ON S.KartID=SK.StokKartID
                                    INNER JOIN genelkodlar AS GB ON S.StokBirim=GB.Kod
                                    Inner Join stok_depo D On SK.DepoID=D.DepoID
                                    WHERE GB.Grup='StokBirim' And SK.TalepID=@TalepID";
                veri.Ekle_Param("@TalepID", TalepID, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static stok_hareket Ver_StokHareket(ref otosisdbEntities DbModel, int ID)
        {
            stok_hareket har = null;

            har = (from abc in DbModel.stok_hareket
                   where abc.ID == ID
                   select abc).FirstOrDefault();
            if (har != null)
            {
                DbModel.Refresh(RefreshMode.StoreWins, har);
            }

            return har;
        }

        public static int Ver_AdetHareket(int TalepID)
        {
            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From stok_hareket Where TalepID=@TalepID";
                veri.Ekle_Param("@TalepID", TalepID, MySqlDbType.Int32);
                return Convert.ToInt32(veri.ExecuteScalar());
            }
        }

        public static int Ver_AdetStokHareket(int KartID)
        {
            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From stok_hareket Where StokKartID=@KartID";
                veri.Ekle_Param("@KartID", KartID, MySqlDbType.Int32);
                return Convert.ToInt32(veri.ExecuteScalar());
            }
        }
        #endregion

        #region < Depo >
        public static DataTable Ver_Depolar(bool?Kilitli=null)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "SELECT DepoID,DepoAd,IF(Kilitli,'Evet','Hayır') Kilitli FROM stok_depo Where SirketID=@SirketID";
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);
                if (Kilitli != null)
                {
                    veri.SqlCumlesi += " And Kilitli=@Kilitli";
                    veri.Ekle_Param("@Kilitli", Kilitli.Value, MySqlDbType.Bit);
                }
                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static stok_depo Ver_Depo(ref otosisdbEntities dbModel, int DepoID)
        {
            stok_depo depo = null;

            depo = (from abc in dbModel.stok_depo
                    where abc.DepoID == DepoID
                    select abc).FirstOrDefault();

            if (depo != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, depo);
            }

            return depo;
        }

        public static int Ver_AdetDepoHareket(int _DepoID)
        {
            int Sonuc = 0;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From stok_hareket Where DepoID=@DepoID";
                veri.Ekle_Param("@DepoID", _DepoID, MySqlDbType.Int32);
                Sonuc = Convert.ToInt32(veri.ExecuteScalar());
            }

            return Sonuc;
        }

        public static bool Varmi_DepoAdi(string DepoAdi, string Haric = null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From stok_depo Where DepoAd=@DepoAd";
                veri.Ekle_Param("@DepoAd", DepoAdi, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And DepoAd<>@Haric";
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

        public static string Ver_DepoAd(int DepoID)
        {
            if (Genel.dt_DepolarSecim != null && Genel.dt_DepolarSecim.Rows.Count > 0)
            {
                for (int i = 0; i < Genel.dt_DepolarSecim.Rows.Count; i++)
                {
                    if (Convert.ToInt32(Genel.dt_DepolarSecim.Rows[i]["DepoID"]) == DepoID)
                    {
                        return Genel.dt_DepolarSecim.Rows[i]["DepoAd"].ToString();
                    }
                }
            }

            string DepoAd = null;
            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select IFNULL(DepoAd,'') From stok_depo Where DepoID=@DepoID";
                veri.Ekle_Param("@DepoID", DepoID, MySqlDbType.Int32);

                DepoAd = veri.ExecuteScalar().ToString();
            }

            return DepoAd;
        }
        #endregion

        #region < Sayım >
        public static stok_sayim Ver_Sayim(ref otosisdbEntities dbModel, int SayimID)
        {
            stok_sayim sayim = null;

            sayim = (from abc in dbModel.stok_sayim
                     where abc.SayimID == SayimID
                     select abc).FirstOrDefault();

            if (sayim != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, sayim);
            }
            return sayim;
        }
        public static DataTable Ver_Sayimlar(DateTime KayitZamanBas, DateTime KayitZamanBit)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select SayimID,DepoID,KayitZaman
                                    From stok_sayim 
                                    Where SirketID=SirketID And
                                    KayitZaman<=@KayitZamanBitis And KayitZaman>=@KayitZamanBas";

                veri.Ekle_Param("@KayitZamanBas", KayitZamanBas, MySqlDbType.DateTime);
                veri.Ekle_Param("@KayitZamanBitis", KayitZamanBit, MySqlDbType.DateTime);
                veri.Ekle_Param("@SirketID", Genel.AktifSirket.SirketID, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static DataTable Ver_SayimKalemler(int SayimID)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT
                                    K.ID,K.ParcaNo,K.StokKartID,K.MevcutMiktar,K.SayilanMiktar,K.SayimDisi,SK.KalemAdi,
                                    K.Raf,K.Sira,K.Goz
                                    FROM stok_sayim_kalem K
                                    INNER JOIN stok_sayim S ON S.SayimID=K.SayimID
                                    INNER JOIN stok_kart SK ON SK.KartID=K.StokKartID
                                    Where K.SayimID=@SayimID";

                veri.Ekle_Param("@SayimID", SayimID, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();

                dt.Columns.Add("Fark", typeof(decimal));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Fark"] = Convert.ToDecimal(dt.Rows[i]["MevcutMiktar"]) - Convert.ToDecimal(dt.Rows[i]["SayilanMiktar"]);
                }
            }

            return dt;
        }

        public static DataTable Ver_SayimKalemlerDepodan(int DepoID,bool SadeceStoktakiler,int?Raf1,int?Sira1,int?Goz1,int?Raf2,int?Sira2,int?Goz2)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"SELECT
                                    SK.KartID StokKartID,SK.KalemAdi,SK.ParcaNo,SK.Raf,SK.Sira,SK.Goz,
                                  (SELECT 
                                    IFNULL(SUM(Miktar),0)-IFNULL((SELECT SUM(Miktar)  FROM stok_hareket WHERE StokKartID=SK.KartID AND Giris=0 AND DepoID=@DepoID),0) Mevcut
                                    FROM stok_hareket
                                    WHERE StokKartID=SK.KartID AND Giris=1 AND DepoID=@DepoID) MevcutMiktar,                                    
                                    0 SayilanMiktar,false SayimDisi
                                    FROM stok_kart AS SK
                                    WHERE 1=1";
                veri.Ekle_Param("@DepoID", DepoID, MySqlDbType.Int32);

                if (SadeceStoktakiler)
                {
                    veri.SqlCumlesi += @" And (SELECT 
                                    IFNULL(SUM(Miktar),0)-IFNULL((SELECT SUM(Miktar)  FROM stok_hareket WHERE StokKartID=SK.KartID AND Giris=0 AND DepoID=@DepoID),0) Mevcut
                                    FROM stok_hareket
                                    WHERE StokKartID=SK.KartID AND Giris=1 AND DepoID=@DepoID) >0";
                }

                if (Raf1 != null)
                {
                    veri.SqlCumlesi += " And SK.Raf>=@Raf1";
                    veri.Ekle_Param("@Raf1", Raf1.Value, MySqlDbType.Int32);
                }
                if (Sira1 != null)
                {
                    veri.SqlCumlesi += " And SK.Sira>=@Sira1";
                    veri.Ekle_Param("@Sira1", Sira1.Value, MySqlDbType.Int32);
                }
                if (Goz1 != null)
                {
                    veri.SqlCumlesi += " And SK.Goz>=@Goz1";
                    veri.Ekle_Param("@Goz1", Raf1.Value, MySqlDbType.Int32);
                }

                if (Raf2 != null)
                {
                    veri.SqlCumlesi += " And SK.Raf<=@Raf2";
                    veri.Ekle_Param("@Raf2", Raf2.Value, MySqlDbType.Int32);
                }
                if (Sira2 != null)
                {
                    veri.SqlCumlesi += " And SK.Sira<=@Sira2";
                    veri.Ekle_Param("@Sira2", Sira2.Value, MySqlDbType.Int32);
                }
                if (Goz2 != null)
                {
                    veri.SqlCumlesi += " And SK.Goz<=@Goz2";
                    veri.Ekle_Param("@Goz2", Goz2.Value, MySqlDbType.Int32);
                }
                
                dt = veri.Ver_DataTable();

                dt.Columns.Add("Fark", typeof(decimal));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Fark"] = dt.Rows[i]["MevcutMiktar"];
                }
            }

            return dt;
        }
        #endregion
    }
}