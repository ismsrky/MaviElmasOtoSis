using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;
using System.Threading;

namespace MaviElmasOtoSis.Bilesenler
{
    public class PiyasaBilgi : Component
    {
        #region < Yapıcı >
        private void InitializeComponent()
        {

        }
        public PiyasaBilgi()
        {
            ds_PiyasaBilgileri = new DataSet();
            tm_OtomatikGuncelleme = new System.Timers.Timer();

            tm_OtomatikGuncelleme.Elapsed += new System.Timers.ElapsedEventHandler(tm_OtomatikGuncelleme_Elapsed);
        }
        #endregion

        #region < Değişkenler >
        decimal _ALtinAlis;
        decimal _ALtinSatis;

        decimal _DolarAlis;
        decimal _DolarSatis;

        decimal _EuroAlis;
        decimal _EuroSatis;

        bool _OtomatikGuncelle;
        int _GuncelemeZamani;

        DateTime _GuncellemeTarih;

        DataSet ds_PiyasaBilgileri;

        public delegate void GuncellendiHandler(object sender, string Sonuc);

        public event GuncellendiHandler Guncellendi;

        Thread thread1;
        System.Timers.Timer tm_OtomatikGuncelleme;
        #endregion

        #region < Özellikler >
        public decimal AltinAlis
        {
            get
            {
                return _ALtinAlis;
            }
        }
        public decimal AltinSatis
        {
            get
            {
                return _ALtinSatis;
            }
        }

        public decimal DolarAlis
        {
            get
            {
                return _DolarAlis;
            }
        }
        public decimal DolarSatis
        {
            get
            {
                return _DolarSatis;
            }
        }

        public decimal EuroAlis
        {
            get
            {
                return _EuroAlis;
            }
        }
        public decimal EuroSatis
        {
            get
            {
                return _EuroSatis;
            }
        }

        public DateTime GuncellemeTarih
        {
            get
            {
                return _GuncellemeTarih;
            }
        }

        public bool OtomatikGuncelle
        {
            get
            {
                return _OtomatikGuncelle;
            }
            set
            {
                _OtomatikGuncelle = value;

                tm_OtomatikGuncelleme.Interval = GuncelemeZamani;
                tm_OtomatikGuncelleme.Enabled = value;
            }
        }
        public int GuncelemeZamani
        {
            get
            {
                return _GuncelemeZamani;
            }
            set
            {
                _GuncelemeZamani = value;
            }
        }
        #endregion

        #region < Olaylar >
        void tm_OtomatikGuncelleme_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Yenile();
        }

        private void ThreadKurOku()
        {
            tm_OtomatikGuncelleme.Enabled = false;
            string Sonuc = "";
            try
            {
                WebRequest webRequest = WebRequest.Create("http://xml.altinkaynak.com.tr/altinkaynak.xml");
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                {
                    Sonuc = "Yanıt Yok";
                }

                ds_PiyasaBilgileri = null;
                ds_PiyasaBilgileri = new DataSet();
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    string a = sr.ReadToEnd().Trim();
                    a = a.Replace(".", ",");
                    a = a.Replace("version=\"1,0\"", "version=\"1.0\"");
                    ds_PiyasaBilgileri.ReadXml(new StringReader(a));
                    sr.Close();
                }

                for (int i = 0; i < ds_PiyasaBilgileri.Tables[0].Rows.Count; i++)
                {
                    if (ds_PiyasaBilgileri.Tables[0].Rows[i][0].ToString() == "Tarih")
                    {
                        _GuncellemeTarih = Convert.ToDateTime(ds_PiyasaBilgileri.Tables[0].Rows[i][1]);
                    }
                    if (ds_PiyasaBilgileri.Tables[0].Rows[i][0].ToString() == "USD")
                    {
                        _DolarAlis = Convert.ToDecimal(ds_PiyasaBilgileri.Tables[0].Rows[i][1]);
                        _DolarSatis = Convert.ToDecimal(ds_PiyasaBilgileri.Tables[0].Rows[i][2]);
                    }
                    if (ds_PiyasaBilgileri.Tables[0].Rows[i][0].ToString() == "EUR")
                    {
                        _EuroAlis = Convert.ToDecimal(ds_PiyasaBilgileri.Tables[0].Rows[i][1]);
                        _EuroSatis = Convert.ToDecimal(ds_PiyasaBilgileri.Tables[0].Rows[i][2].ToString());
                    }
                    if (ds_PiyasaBilgileri.Tables[0].Rows[i][0].ToString() == "HH")
                    {
                        _ALtinAlis = Convert.ToDecimal(ds_PiyasaBilgileri.Tables[0].Rows[i][1]);
                        _ALtinSatis = Convert.ToDecimal(ds_PiyasaBilgileri.Tables[0].Rows[i][2]);
                    }
                }
            }
            catch (Exception hata)
            {
                Sonuc = "Piyasa bilgilerini internetten alırken hata oluştu.\nHata:\n" + hata.Message;
            }

            Sonuc = "Basarili";

            thread1 = null;

            if (Guncellendi != null)
            {
                Guncellendi.Invoke(this, Sonuc);
            }

            tm_OtomatikGuncelleme.Enabled = _OtomatikGuncelle;
        }
        #endregion

        #region < Metod >
        public void Yenile()
        {
            if (!Araclar. Net.Varmi_InternetBaglantisi()) return;
            thread1 = new Thread(new ThreadStart(ThreadKurOku));
            thread1.Start();
        }
        #endregion       
    }
}