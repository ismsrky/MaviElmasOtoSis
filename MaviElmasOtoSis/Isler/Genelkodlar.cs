using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;
using MySql.Data.MySqlClient;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Isler
{
    public class Genelkodlar
    {
        public static genelkodlar Ver_GenelKod(int ID,ref otosisdbEntities dbModel)
        {
            genelkodlar genelkod = null;

            genelkod = (from abc in dbModel.genelkodlars
                        where abc.ID == ID
                        select abc).FirstOrDefault();

            if (genelkod != null)
            {
                dbModel.Refresh(RefreshMode.StoreWins, genelkod);
            }

            return genelkod;
        }

        public static DataTable Ver_Kod(string KodGrup, bool? Durum = true)
        {
            return Ver_Kod(KodGrup, "", Durum);
        }
        public static DataTable Ver_Kod(string KodGrup, string Mesaj, bool? Durum = true)
        {
            DataTable dt = new DataTable("Genel_Kodlar");

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select ID,Kod,Aciklama,case Durum when 1 then 'Aktif' else 'Pasif' end as Durum From genelkodlar Where Grup=@Grup";
                if (Durum != null)
                {
                    veri.SqlCumlesi += " And Durum=@Durum";
                    veri.Ekle_Param("@Durum", Durum.Value, MySqlDbType.Bit);
                }

                veri.Ekle_Param("@Grup", KodGrup, MySqlDbType.VarChar);

                dt = veri.Ver_DataTable();
            }

            if (string.IsNullOrEmpty(Mesaj) == false)
            {
                Araclar.Veri.Ekle_Mesaj(dt, "Aciklama", "Kod", Mesaj);
            }

            return dt;
        }

        public static void Ver_Kod(string KodGrup, ref LookUpEdit _lookUpEdit, bool? Durum = true)
        {
            _lookUpEdit.Properties.DisplayMember = "Aciklama";
            _lookUpEdit.Properties.ValueMember = "Kod";
            _lookUpEdit.Properties.DataSource = Ver_Kod(KodGrup, Durum);
        }
        public static void Ver_Kod(string KodGrup, ref LookUpEdit _lookUpEdit, string Mesaj, bool? Durum = true)
        {
            _lookUpEdit.Properties.DisplayMember = "Aciklama";
            _lookUpEdit.Properties.ValueMember = "Kod";
            _lookUpEdit.Properties.DataSource = Ver_Kod(KodGrup, Mesaj, Durum);

            _lookUpEdit.EditValue = "-1";
        }

        public static void Ver_Kod(string KodGrup, ref RepositoryItemLookUpEdit _lookUpEdit, bool? Durum = true)
        {
            _lookUpEdit.DisplayMember = "Aciklama";
            _lookUpEdit.ValueMember = "Kod";
            _lookUpEdit.DataSource = Ver_Kod(KodGrup, Durum);
        }
        public static void Ver_Kod(string KodGrup, ref RepositoryItemLookUpEdit _lookUpEdit,string Mesaj, bool? Durum = true)
        {
            _lookUpEdit.DisplayMember = "Aciklama";
            _lookUpEdit.ValueMember = "Kod";
            _lookUpEdit.DataSource = Ver_Kod(KodGrup, Mesaj, Durum);
        }

        public static bool Varmi_Kod(string Grup, string Kod, int? HaricID = null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From genelkodlar Where Grup=@Grup And Kod=@Kod";
                veri.Ekle_Param("@Grup", Grup, MySqlDbType.VarChar);
                veri.Ekle_Param("@Kod", Kod, MySqlDbType.VarChar);

                if (HaricID != null)
                {
                    veri.SqlCumlesi += " And ID!=@HaricID";
                    veri.Ekle_Param("@HaricID", HaricID.Value, MySqlDbType.Int32);
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

        public static bool Varmi_Aciklama(string Grup, string Aciklama, int? HaricID = null)
        {
            bool Sonuc = false;

            using (VeriErisim veri = new VeriErisim())
            {
                veri.SqlCumlesi = "Select Count(*) From genelkodlar Where Grup=@Grup And Aciklama=@Aciklama";
                veri.Ekle_Param("@Grup", Grup, MySqlDbType.VarChar);
                veri.Ekle_Param("@Aciklama", Aciklama, MySqlDbType.VarChar);

                if (HaricID != null)
                {
                    veri.SqlCumlesi += " And ID!=@HaricID";
                    veri.Ekle_Param("@HaricID", HaricID.Value, MySqlDbType.Int32);
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

        public static string Ver_Aciklama(string Grup, string Kod)
        {
            string Sonuc = "";

            using (VeriErisim veri=new VeriErisim())
            {
                veri.SqlCumlesi = "Select Aciklama From genelkodlar Where Grup=@Grup And Kod=@Kod";
                veri.Ekle_Param("@Grup", Grup, MySqlDbType.VarChar);
                veri.Ekle_Param("@Kod", Kod, MySqlDbType.VarChar);
                Sonuc = veri.ExecuteScalar().ToString();
            }

            return Sonuc;
        }
    }
}