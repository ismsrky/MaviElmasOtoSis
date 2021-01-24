using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;

namespace MaviElmasOtoSis.Bilesenler
{
    public partial class HavaDurumu : Component
    {
        #region < Yapıcı >
        public HavaDurumu()
        {
            _ds_HavaDurum = new DataSet();
            //tm_OtomatikGuncelleme = new System.Timers.Timer();

            InitializeComponent();

            tm_OtomatikGuncelleme.Elapsed += new System.Timers.ElapsedEventHandler(tm_OtomatikGuncelleme_Elapsed);
        }

        public HavaDurumu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region < Değişkenler >
        decimal _Derece;
        decimal _Nem;
        //string _Ruzgar;
        string _Durum;
        int _DurumKod;
        Image _HavaResim;


        DateTime _GuncellemeTarih;

        bool _OtomatikGuncelle;
        int _GuncelemeZamani;

        public delegate void GuncellendiHandler(object sender, string Sonuc);

        public event GuncellendiHandler Guncellendi;

        Thread thread1;
        System.Timers.Timer tm_OtomatikGuncelleme = new System.Timers.Timer();

        DataSet _ds_HavaDurum;

        Sehirler _Sehir;
        #endregion

        #region < Enum >
        public enum Sehirler
        {
            Adana = 2343678,
            Adiyaman = 2343680,
            Afyon = 2343682,
            Ağri = 2343687,
            Amasya = 2343729,
            Ankara = 2343732,
            Antalya = 2343733,
            Artvin = 2343741,
            Aydin = 2343751,
            Balikesir = 55966404,
            Bilecik = 2343810,
            Bingöl = 2343811,
            Bitlis = 2343814,
            Bolu = 2343819,
            Burdur = 2343840,
            Bursa = 2343843,
            Çanakkale = 2343859,
            Çankırı = 2343862,
            Çorum = 2343904,
            Denizli = 2343920,
            Diyarbakır = 2343932,
            Edirne = 2343949,
            Elazığ = 2343954,
            Erzincan = 2343976,
            Erzurum = 2343977,
            Eskişehir = 2343980,
            Gaziantep = 2343999,
            Giresun = 2344018,
            Gümüşhane = 2344042,
            Hakkari = 2344061,
            Hatay = 2344073,
            Isparta = 2344114,
            Mersin = 2323778,
            Istanbul = 2344116,
            Izmir = 2344117,
            Kars = 2344165,
            Kastamonu = 2344169,
            Kayseri = 2344174,
            Kırklareli = 2344198,
            Kırşehir = 2324643,
            Kocaeli = 2329471,
            Konya = 55966544,
            Kütahya = 2344239,
            Malatya = 2344246,
            Manisa = 2344250,
            Kahramanmaraş = 2344125,
            Mardin = 2344252,
            Muğla = 2344271,
            Muş = 2344276,
            Nevşehir = 2344285,
            Niğde = 2344286,
            Ordu = 2344302,
            Rize = 2344336,
            Sakarya = 2344345,
            Samsun = 2344351,
            Siirt = 2344385,
            Sinop = 2344394,
            Sivas = 2344398,
            Tokat = 2344446,
            Trabzon = 2344452,
            Tunceli = 2344453,
            Şanlıurfa = 2344354,
            Uşak = 2344475,
            Van = 12517920,
            Yozgat = 2344529,
            Zonguldak = 2344539,
            Aksaray = 2343707,
            Bayburt = 2343787,
            Karaman = 2344152,
            Kırıkkale = 2344196,
            Batman = 2343786,
            Şırnak = 2344396,
            Barkın = 2343781,
            Ardahan = 2343738,
            Iğdır = 2344094,
            Yalova = 2344489,
            Karabük = 2344140,
            Kilis = 2344192,
            Osmaniye = 2344312,
            Düzce = 2343946
        }

        public enum Diller
        {
            Turkce = 0,
            English = 1
        }
        #endregion

        #region < Özellikler >
        public decimal Derece
        {
            get
            {
                return _Derece;
            }
        }

        public decimal Nem
        {
            get
            {
                return _Nem;
            }
        }

        public string Durum
        {
            get
            {
                return _Durum;
            }
        }

        public int DurumKod
        {
            get
            {
                return _DurumKod;
            }
        }

        public DateTime GuncellemeTarih
        {
            get
            {
                return _GuncellemeTarih;
            }
        }

        [Category("Ayarlar")]
        public bool OtomatikGuncelle
        {
            get
            {
                return _OtomatikGuncelle;
            }
            set
            {
                if (!Araclar. Dogrulama.IsNumeric(GuncelemeZamani.ToString()))
                    throw new Exception("Güncelleme Zamanı Sayısal Bir değer olmalıdır.");

                if (GuncelemeZamani <= 0)
                    throw new Exception("Güncelleme Zamanı 0'dan Büyük olmalıdır.");

                _OtomatikGuncelle = value;

                tm_OtomatikGuncelleme.Interval = GuncelemeZamani;
                tm_OtomatikGuncelleme.Enabled = value;
            }
        }
        [Category("Ayarlar")]
        public int GuncelemeZamani
        {
            get
            {
                return _GuncelemeZamani;
            }
            set
            {
                if (!Araclar. Dogrulama.IsNumeric(GuncelemeZamani.ToString()))
                    throw new Exception("Güncelleme Zamanı Sayısal Bir değer olmalıdır.");

                if (GuncelemeZamani < 0)
                    throw new Exception("Güncelleme Zamanı 0'dan küçük olamaz.");
                _GuncelemeZamani = value;
            }
        }

        public Image HavaResim
        {
            get
            {
                return _HavaResim;
            }
        }

        public Sehirler Sehir
        {
            get
            {
                return _Sehir;
            }
            set
            {
                _Sehir = value;
            }
        }

        public Diller Dil { get; set; }
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
                int link = (int)_Sehir;
                WebRequest webRequest = WebRequest.Create("http://weather.yahooapis.com/forecastrss?w=" + link.ToString());
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                {
                    Sonuc = "Yanıt Yok";
                }

                _ds_HavaDurum = null;
                _ds_HavaDurum = new DataSet();
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    string a = sr.ReadToEnd().Trim();
                    //a = a.Replace(".", ",");
                    //a = a.Replace("version=\"1,0\"", "version=\"1.0\"");
                    _ds_HavaDurum.ReadXml(new StringReader(a));
                    sr.Close();
                }

                _GuncellemeTarih = DateTime.Now;
                _Derece = (decimal)Math.Round(Araclar. Cevirici.FahrenheitToCelsius(_ds_HavaDurum.Tables["condition"].Rows[0]["temp"].ToString()), 1);
                _Nem = Convert.ToDecimal(_ds_HavaDurum.Tables["atmosphere"].Rows[0]["humidity"]);

                _DurumKod = Convert.ToInt32(_ds_HavaDurum.Tables["condition"].Rows[0]["code"]);
                _Durum = HavaDurum(_DurumKod);

                //_HavaDurumTarih = Convert.ToDateTime(_ds_HavaDurum.Tables["condition"].Rows[0]["date"]);
            }
            catch (Exception hata)
            {
                Sonuc = "Hava durumu bilgilerini internetten alırken hata oluştu.\nHata:\n" + hata.Message;
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

        public string HavaDurum(int Kod)
        {
            switch (Kod)
            {
                case 0:
                    _HavaResim = ResHavaDurum.Hortum;
                    if (Dil == Diller.English)
                        return "Tornado";
                    return "Hortum";
                case 1:
                    if (Dil == Diller.English)
                        return "Tropical storm";
                    return "Tropik Fırtına";
                case 2:
                    if (Dil == Diller.English)
                        return "Hurricane";
                    return "Kasırga";
                case 3:
                    _HavaResim = ResHavaDurum.kuvvetliSaganak;
                    if (Dil == Diller.English)
                        return "Severe thunderstorms";
                    return "Şiddetli sağanak yağış";
                case 4:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Thunderstorms";
                    return "Sağanak Yağış";
                case 5:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Mixed rain and snow";
                    return "Karla karşık yağmur";
                case 6:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Mixed rain and sleet";
                    return "Yağmurla karışık dolu";
                case 7:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Mixed snow and sleet";
                    return "Karla karşık yağmur";
                case 8:
                    _HavaResim = ResHavaDurum.Don;
                    if (Dil == Diller.English)
                        return "Freezing drizzle";
                    return "Donucu Çiğ";
                case 9:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Drizzle";
                    return "Çiğ";
                case 10:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Freezing rain";
                    return "Dondurucu yağmur";
                case 11:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Showers";
                    return "Hafif Yağışlı";
                case 12:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Showers";
                    return "Hafif Yağışlı";
                case 13:
                    _HavaResim = ResHavaDurum.karliDon;
                    if (Dil == Diller.English)
                        return "Snow flurries";
                    return "Kar Fırtınası";
                case 14:
                    _HavaResim = ResHavaDurum.Kar;
                    if (Dil == Diller.English)
                        return "Light snow showers";
                    return "Hafif Kar";
                case 15:
                    _HavaResim = ResHavaDurum.Kar;
                    if (Dil == Diller.English)
                        return "Blowing snow";
                    return "Esen Kar";
                case 16:
                    _HavaResim = ResHavaDurum.Kar;
                    if (Dil == Diller.English)
                        return "Snow";
                    return "Kar";
                case 17:
                    if (Dil == Diller.English)
                        return "Hail";
                    return "Dolu";
                case 18:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Sleet";
                    return "Sulusepken";
                case 19:
                    if (Dil == Diller.English)
                        return "Dust";
                    return "Kum";
                case 20:
                    _HavaResim = ResHavaDurum.Sisli;
                    if (Dil == Diller.English)
                        return "Foggy";
                    return "Sisli";
                case 21:
                    _HavaResim = ResHavaDurum.Sisli;
                    if (Dil == Diller.English)
                        return "Haze";
                    return "Hafif Sisli";
                case 22:
                    _HavaResim = ResHavaDurum.Sisli;
                    if (Dil == Diller.English)
                        return "Smoky";
                    return "Dumanlı";
                case 23:
                    _HavaResim = ResHavaDurum.Ruzgarli;
                    if (Dil == Diller.English)
                        return "Blustery";
                    return "Rüzgar Fırtınası";
                case 24:
                    _HavaResim = ResHavaDurum.Ruzgarli;
                    if (Dil == Diller.English)
                        return "Windy";
                    return "Rüzgarlı";
                case 25:
                    _HavaResim = ResHavaDurum.Don;
                    if (Dil == Diller.English)
                        return "Cold";
                    return "Soğuk";
                case 26:
                    _HavaResim = ResHavaDurum.ParcaliBulutlu;
                    if (Dil == Diller.English)
                        return "Cloudy";
                    return "Bulutlu";
                case 27:
                    _HavaResim = ResHavaDurum.GeceCokBulut;
                    if (Dil == Diller.English)
                        return "Mostly cloudy (night)";
                    return "Çok bulutlu (gece)";
                case 28:
                    _HavaResim = ResHavaDurum.CokBulutlu;
                    if (Dil == Diller.English)
                        return "mostly cloudy (day)";
                    return "Çok bulutlu (gündüz)";
                case 29:
                    _HavaResim = ResHavaDurum.GeceBulutlu;
                    if (Dil == Diller.English)
                        return "Partly cloudy (night)";
                    return "Parça bulutlu (gece)";
                case 30:
                    _HavaResim = ResHavaDurum.ParcaliBulutlu;
                    if (Dil == Diller.English)
                        return "Partly cloudy (day)";
                    return "Parça bulutlu (gündüz)";
                case 31:
                    _HavaResim = ResHavaDurum.AcikGece;
                    if (Dil == Diller.English)
                        return "Clear (night)";
                    return "Temiz (Gece)";
                case 32:
                    _HavaResim = ResHavaDurum.Gunesli;
                    if (Dil == Diller.English)
                        return "Clear (day)";
                    return "Güneşli";
                case 33:
                    _HavaResim = ResHavaDurum.AcikGece;
                    if (Dil == Diller.English)
                        return "Fair (night)";
                    return "Açık (gece)";
                case 34:
                    _HavaResim = ResHavaDurum.Gunesli;
                    if (Dil == Diller.English)
                        return "Fair (day)";
                    return "Açık (gündüz)";
                case 35:
                    _HavaResim = ResHavaDurum.GeceYagis;
                    if (Dil == Diller.English)
                        return "Mixed rain and hail";
                    return "Doluyla karışık yağmur";
                case 36:
                    _HavaResim = ResHavaDurum.Gunesli;
                    if (Dil == Diller.English)
                        return "Hot";
                    return "Sıcak";
                case 37:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Isolated thunderstorms";
                    return "Kapalı sağanak yağışlı";
                case 38:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Scattered thunderstorms";
                    return "Dağınık yağışlı";
                case 39:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Scattered thunderstorms";
                    return "Dağınık yağışlı";
                case 40:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Scattered showers";
                    return "Seyrek Yağış";
                case 41:
                    _HavaResim = ResHavaDurum.Kar;
                    if (Dil == Diller.English)
                        return "Heavy snow";
                    return "Yoğun kâr yağışlı";
                case 42:
                    _HavaResim = ResHavaDurum.Kar;
                    if (Dil == Diller.English)
                        return "Scattered snow showers";
                    return "Dağınık sağnak kâr";
                case 43:
                    _HavaResim = ResHavaDurum.Kar;
                    if (Dil == Diller.English)
                        return "Heavy snow";
                    return "Yoğun kâr yağışı";
                case 44:
                    _HavaResim = ResHavaDurum.ParcaliBulutlu;
                    if (Dil == Diller.English)
                        return "Partly cloudy";
                    return "Parçalı bulutlu";
                case 45:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "Thundershowers";
                    return "Gökgürültülü sağanak yağış";
                case 46:
                    _HavaResim = ResHavaDurum.Kar;
                    if (Dil == Diller.English)
                        return "Snow showers";
                    return "Kâr yağışı";
                case 47:
                    _HavaResim = ResHavaDurum.Yagisli;
                    if (Dil == Diller.English)
                        return "";
                    return "Kapalı gökgürültülü sağanak yağış";
            }

            return "";
        }
        #endregion
    }
}