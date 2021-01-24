using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.EntityClient;

namespace MaviElmasOtoSis.VeriYonetimi
{
    public static class Baglanti
    {
        public static bool MesgulMu
        {
            get;
            set;
        }

        public static bool Test_Baglanti()
        {
            try
            {
                using (MySqlConnection Conn = new MySqlConnection(BaglantiCumlesi))
                {
                    Conn.Open();

                    Conn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string BaglantiEntity
        {
            get
            {
                EntityConnectionStringBuilder ecb = new EntityConnectionStringBuilder();

                //ecb.Metadata = "res://*/" + VeritabaniAdi + ".csdl|res://*/" + VeritabaniAdi + ".ssdl|res://*/" + VeritabaniAdi + ".msl";
                //ecb.Provider = "MySql.Data.MySqlClient";
                //ecb.ProviderConnectionString = BaglantiCumlesi;










                ecb.Metadata = @".\" + VeritabaniAdi + @".csdl|.\" + VeritabaniAdi + @".ssdl|.\" + VeritabaniAdi + ".msl";
                ecb.Provider = "MySql.Data.MySqlClient";
                ecb.ProviderConnectionString = BaglantiCumlesi;

              //"metadata=.\otosisdb.csdl|.\otosisdb.ssdl|.\otosisdb.msl;provider=MySql.Data.MySqlClient;provider connection string=&quot;server=localhost;User Id=root;password=1535;database=otosisdb;Persist Security Info=True&quot;" providerName="System.Data.EntityClient" />


                return ecb.ConnectionString;
            }
        }

        public static MySqlConnection Ver_Baglanti()
        {
            MySqlConnection SqlConn = new MySqlConnection(BaglantiCumlesi);
            
            return SqlConn;
        }

        public static string BaglantiCumlesi
        {
            get
            {
                if (string.IsNullOrEmpty(ServerAdres))
                    throw new Exception("Server Adresi / IP Verilmemiş.");
                if (string.IsNullOrEmpty(VeritabaniAdi))
                    throw new Exception("Veritabanı Adı Belirtilmemiş.");
                if (string.IsNullOrEmpty(KullaniciAdi))
                    throw new Exception("Kullanıcı adı girilmemiş.");
                if (string.IsNullOrEmpty(KullaniciSifre))
                    throw new Exception("Kullanıcı şifresi girilmemiş.");

                string _SqlBaglantiCumlesi = "";

                _SqlBaglantiCumlesi =
                    "Server = " + ServerAdres + ";Database=" + VeritabaniAdi + ";Uid=" + KullaniciAdi + ";Pwd=" + KullaniciSifre + ";";

                return _SqlBaglantiCumlesi;
            }
        }

        public static string ServerAdres
        {
            get;
            set;
        }

        public static string VeritabaniAdi
        {
            get;
            set;
        }

        public static string KullaniciAdi
        {
            get;
            set;
        }

        public static string KullaniciSifre
        {
            get;
            set;
        }

        public static string Baglanti_Dene(string _ServerAdres, string _VeritabaniAdi, string _KullaniAdi, string _KullaniciSifre)
        {
            if (string.IsNullOrEmpty(ServerAdres))
                return "Server Adresi / IP Verilmemiş.";
            if (string.IsNullOrEmpty(VeritabaniAdi))
                return "Veritabanı Adı Belirtilmemiş.";
            if (string.IsNullOrEmpty(KullaniciAdi))
                return "Kullanıcı adı girilmemiş.";
            if (string.IsNullOrEmpty(KullaniciSifre))
                return "Kullanıcı şifresi girilmemiş.";

            string _SqlBaglantiCumlesi =
                "Server = " + _ServerAdres + ";Database=" + _VeritabaniAdi + ";Uid=" + _KullaniAdi + ";Pwd=" + _KullaniciSifre + ";";

            using (MySqlConnection SqlConn = new MySqlConnection(_SqlBaglantiCumlesi))
            {
                
                try
                {
                    if (SqlConn.State != ConnectionState.Closed) SqlConn.Close();

                    SqlConn.Open();

                    SqlConn.Close();
                }
                catch (Exception hata)
                {
                    return hata.Message;
                }
            }

            return "Olumlu";
        }
    }
}