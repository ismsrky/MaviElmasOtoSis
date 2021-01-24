using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;

namespace MaviElmasOtoSis.Araclar
{
    public static class Net
    {
        #region < Değişkenler >
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        #endregion

        #region < Özellikler >
        /// <summary>
        /// Bilgisayarın ağ üzerindeki IP adresini dönderir. Eğere birden fazla enthernet kartı varsa bilgisayar hangisi ile internete giriyorsa onun IP adresini dönderir.
        /// </summary>
        public static string SistemIP
        {
            get
            {
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                string server_ip = "";
                foreach (IPAddress a in localIPs)
                {
                    if (a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        server_ip = a.ToString();
                    }
                    //server_ip = server_ip + a.ToString() + "/";
                }
                return server_ip;
            }
        }
        #endregion

        #region < Metod >
        /// <summary>
        /// Herhangi bir Url'lin canlı olup olmadığını verilen timeout ile kontrol eder.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="_TimeOut"></param>
        /// <returns></returns>
        public static bool Varmi_Baglanti(string url, int _TimeOut = 1000)
        {
            try
            {
                System.Uri Url = new System.Uri(url);

                System.Net.WebRequest WebReq;
                System.Net.WebResponse Resp;
                WebReq = System.Net.WebRequest.Create(Url);

                WebReq.Timeout = _TimeOut;

                Resp = WebReq.GetResponse();
                Resp.Close();
                WebReq = null;
                return true;
            }

            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Bilgisayarın internet bağlantısı olup olmadığını Windows API'si ile kontrol eder.
        /// </summary>
        /// <returns></returns>
        public static bool Varmi_InternetBaglantisi()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
        #endregion
    }
}