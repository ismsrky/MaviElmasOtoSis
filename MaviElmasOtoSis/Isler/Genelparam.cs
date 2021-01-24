using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;
using MySql.Data.MySqlClient;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Isler
{
    public class Genelparam
    {
        public static genelparam Ver_Param(ref otosisdbEntities dbModel, int ParamID)
        {
            genelparam param = null;

            param = (from abc in dbModel.genelparams
                     where abc.ParamID == ParamID
                     select abc).FirstOrDefault();

            if (param != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, param);
            }

            return param;
        }
        public static genelparam Ver_Param(ref otosisdbEntities DbModel, string Kod, string Grup)
        {
            genelparam param = null;

            param = (from abc in DbModel.genelparams
                     where abc.Kod == Kod && abc.Grup == Grup
                     select abc).FirstOrDefault();

            if (param != null)
            {
                DbModel.Refresh(RefreshMode.StoreWins, param);
            }

            return param;
        }

        public static object Ver_ParamKarsilik(string Kod, string Grup)
        {
            object Sonuc = null;

            otosisdbEntities dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);
            genelparam param = Ver_Param(ref dbModel, Kod, Grup);

            switch (param.Tip)
            {
                case "1":
                    Sonuc = Convert.ToInt32(param.Karsilik);
                    break;
                case "2":
                    Sonuc = Convert.ToDecimal(param.Karsilik);
                    break;
                case "3":
                    Sonuc = param.Karsilik;
                    break;
                case "4":
                    Sonuc = Convert.ToDateTime(param.Karsilik);
                    break;
                case "5":
                    Sonuc = Convert.ToBoolean(param.Karsilik);
                    break;
                case "6":
                    Sonuc = param.Karsilik;
                    break;
                case "7":
                    Sonuc = param.Karsilik;
                    break;
                default:
                    Sonuc = param.Karsilik;
                    break;
            }

            dbModel.Dispose();
            dbModel = null;
            return Sonuc;
        }
        public static object Ver_ParamKarsilik(int ParamID)
        {
            object Sonuc = null;

            otosisdbEntities dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);
            genelparam param = Ver_Param(ref dbModel, ParamID);

            switch (param.Tip)
            {
                case "1":
                    Sonuc = Convert.ToInt32(param.Karsilik);
                    break;
                case "2":
                    Sonuc = Convert.ToDecimal(param.Karsilik);
                    break;
                case "3":
                    Sonuc = param.Karsilik;
                    break;
                case "4":
                    Sonuc = Convert.ToDateTime(param.Karsilik);
                    break;
                case "5":
                    Sonuc = Convert.ToBoolean(param.Karsilik);
                    break;
                case "6":
                    Sonuc = param.Karsilik;
                    break;
                case "7":
                    Sonuc = param.Karsilik;
                    break;
                default:
                    Sonuc = param.Karsilik;
                    break;
            }

            dbModel.Dispose();
            dbModel = null;
            return Sonuc;
        }
    }
}