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
    public class MarkaModel
    {
        #region < Marka İşlemler >
        public static DataTable Ver_Markalar(string MarkaAdi, string ModelAdi)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = @"Select distinct MA.MarkaID,MA.MarkaAdi,MA.Web From araba_marka As MA";

                if (!string.IsNullOrEmpty(ModelAdi))
                {
                    veri.SqlCumlesi += @" Inner Join araba_model As MO On MA.MarkaID=MO.MarkaID
                                          Where MO.ModelAdi like @ModelAdi";
                    veri.Ekle_Param("@ModelAdi","%"+ ModelAdi+"%", MySqlDbType.VarChar);
                }
                else
                {
                    veri.SqlCumlesi += " Where 1=1";
                }

                if (!string.IsNullOrEmpty(MarkaAdi))
                {
                    veri.SqlCumlesi += " And MA.MarkaAdi like @MarkaAdi";
                    veri.Ekle_Param("@MarkaAdi", "%"+MarkaAdi+"%", MySqlDbType.VarChar);
                }


                veri.SqlCumlesi += " Order By MA.MarkaAdi";
                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static araba_marka Ver_ArabaMarka(ref otosisdbEntities dbModel, int MarkaID)
        {
            araba_marka marka = null;

            marka = (from abc in dbModel.araba_marka
                     where abc.MarkaID == MarkaID
                     select abc).FirstOrDefault();
            if (marka != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, marka);
            }

            return marka;
        }

        public static bool Varmi_Marka(string MarkaAdi,string Haric=null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From araba_marka Where MarkaAdi=@MarkaAdi";
                veri.Ekle_Param("@MarkaAdi", MarkaAdi, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And MarkaAdi<>@Haric";
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

        public static string Ver_MarkaAd(int MarkaID)
        {
            string Sonuc = "";

            for (int i = 0; i < Genel.dt_Markalar.Rows.Count; i++)
            {
                if (Convert.ToInt32(Genel.dt_Markalar.Rows[i]["MarkaID"]) == MarkaID)
                {
                    Sonuc = Genel.dt_Markalar.Rows[i]["MarkaAdi"].ToString();
                    break;
                }
            }

            return Sonuc;
        }
        #endregion

        #region < Model İşlemleri >
        public static DataTable Ver_Modeller(int MarkaID)
        {
            DataTable dt = null;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select ModelID,ModelAdi From araba_model Where MarkaID=@MarkaID Order By ModelAdi";
                veri.Ekle_Param("@MarkaID", MarkaID, MySqlDbType.Int32);

                dt = veri.Ver_DataTable();
            }

            return dt;
        }

        public static araba_model Ver_ArabaModel(ref otosisdbEntities dbModel, int ModelID)
        {
            araba_model model = null;

            model = (from abc in dbModel.araba_model
                     where abc.ModelID == ModelID
                     select abc).FirstOrDefault();
            if (model != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, model);
            }

            return model;
        }

        public static bool Varmi_Model(int MarkaID, string ModelAdi,string Haric=null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From araba_model Where MarkaID=@MarkaID And ModelAdi=@ModelAdi";
                veri.Ekle_Param("@MarkaID", MarkaID, MySqlDbType.Int32);
                veri.Ekle_Param("@ModelAdi", ModelAdi, MySqlDbType.VarChar);
                if (Haric != null)
                {
                    veri.SqlCumlesi += " And ModelAdi<>@Haric";
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

        public static string Ver_ModelAd(int ModelID)
        {
            string Sonuc = "";

            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = "Select ModelAdi From araba_model Where ModelID=@ModelID";
                veri.Ekle_Param("@ModelID", ModelID, MySqlDbType.Int32);

                Sonuc = veri.ExecuteScalar().ToString();
            }

            return Sonuc;
        }
        #endregion
    }
}