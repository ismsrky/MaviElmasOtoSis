using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace MaviElmasOtoSis.Araclar
{
    public static class Veri
    {
        public static DataTable Ekle_Mesaj(DataTable dt, string DisplayMember, string ValueMember, string Msj, object ValMember = null)
        {
            if (dt == null) return null;
            DataRow dr = dt.NewRow();
            if (ValMember == null)
            {
                dr[ValueMember] = -1;
            }
            else
            {
                dr[ValueMember] = ValMember;
            }
            dr[DisplayMember] = Msj;
            dt.Rows.InsertAt(dr, 0);

            return dt;
        }
        public static DataTable Ekle_Tumu(DataTable dt, string DisplayMember, string ValueMember, object ValMember = null)
        {
            return Ekle_Mesaj(dt, DisplayMember, ValueMember, "Tümü", ValMember);
        }
        public static DataTable Ekle_Lutfen(DataTable dt, string DisplayMember, string ValueMember, object ValMember = null)
        {
            return Ekle_Mesaj(dt, DisplayMember, ValueMember, "Lütfen Seçiniz", ValMember);
        }

        public static DataTable exceldata(string DosyaYolu, string SayfaAdi)
        {
            string connstr = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + DosyaYolu + ";Extended Properties=Excel 8.0";

            DataTable dt = null;
            using (OleDbConnection conn = new OleDbConnection(connstr))
            {
                string strSQL = "SELECT * FROM [" + SayfaAdi + "$]";

                OleDbDataAdapter adp = new OleDbDataAdapter(strSQL, conn);

                dt = new DataTable();
                adp.Fill(dt);

                conn.Close();
            }

            return dt;
        }
    }
}