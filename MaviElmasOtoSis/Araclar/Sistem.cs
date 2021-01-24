using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Management;

namespace MaviElmasOtoSis.Araclar
{
    public static class Sistem
    {
        #region < Özellikler >
        /// <summary>
        /// Bilgisayarın kullanını CPU'nun seri numarasını verir.
        /// </summary>
        public static string CPU_Serial
        {
            get
            {
                ManagementObjectSearcher searcher =
                   new ManagementObjectSearcher("root\\CIMV2",
                   "SELECT * FROM Win32_Processor");

                string a = "";
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    //a = queryObj["Architecture"].ToString();
                    //a = queryObj["Caption"].ToString();
                    //a = queryObj["Family"].ToString();
                    a = queryObj["ProcessorId"].ToString();
                }
                return a;
            }
        }

        public static Version me_version
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
        }
        public static string VersiyonBilgisi
        {
            get
            {
                return me_version.Major.ToString() + "." + me_version.Minor.ToString() + "." + me_version.Build.ToString() + "." + me_version.Revision.ToString();
            }
        }
        #endregion

        #region < Metod >
        /// <summary>
        /// Bilgisayarda tanımlı yazıcıların isimlerini liste şeklinde verir.
        /// </summary>
        /// <returns></returns>
        public static List<string> Yazicilar()
        {
            List<string> Sonuc = new List<string>();

            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                Sonuc.Add(printer.ToString());
            }
            return Sonuc;
        }

        public static VersiyonKiyasla Versiyon_Kiyasla(string Ver_Sol, string Ver_Sag)
        {
            if (Ver_Sol == Ver_Sag) return VersiyonKiyasla.Esit;

            string[] yeni_sol = Ver_Sol.Split(new string[1] { "." }, StringSplitOptions.None);
            int Sol_Major = Convert.ToInt32(yeni_sol[0]);
            int Sol_Minor = Convert.ToInt32(yeni_sol[1]);
            int Sol_Build = Convert.ToInt32(yeni_sol[2]);
            int Sol_Revision = Convert.ToInt32(yeni_sol[3]);

            string[] yeni_sag = Ver_Sag.Split(new string[1] { "." }, StringSplitOptions.None);
            int Sag_Major = Convert.ToInt32(yeni_sag[0]);
            int Sag_Minor = Convert.ToInt32(yeni_sag[1]);
            int Sag_Build = Convert.ToInt32(yeni_sag[2]);
            int Sag_Revision = Convert.ToInt32(yeni_sag[3]);

            if (Sol_Major < Sag_Major)
                return VersiyonKiyasla.SagBuyuk;
            else if (Sol_Major == Sag_Major && Sol_Minor < Sag_Minor)
                return VersiyonKiyasla.SagBuyuk;
            else if (Sol_Major == Sag_Major && Sol_Minor == Sag_Minor && Sol_Build < Sag_Build)
                return VersiyonKiyasla.SagBuyuk;
            else if (Sol_Major == Sag_Major && Sol_Minor == Sag_Minor && Sol_Build == Sag_Build & Sol_Revision < Sag_Revision)
                return VersiyonKiyasla.SagBuyuk;

            return VersiyonKiyasla.SolBuyuk;
        }

        public enum VersiyonKiyasla
        {
            SolBuyuk,
            SagBuyuk,
            Esit
        }
        #endregion
    }
}