using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaviElmasOtoSis.Araclar
{
    public static class TarihSaat
    {
        public static int YasHesapla(DateTime DogumTarihi)
        {
            int years = DateTime.Now.Year - DogumTarihi.Year;
            if (DateTime.Now.Month < DogumTarihi.Month || (DateTime.Now.Month == DogumTarihi.Month && DateTime.Now.Day < DogumTarihi.Day))
            {
                years--;
            }

            ExcelClass asdad = new ExcelClass();
            

            return years;
        }

        public static DateTime Ver_AyinBasi(DateTime _Tarih)
        {
            DateTime date = new DateTime(_Tarih.Year, _Tarih.Month, 1, 0, 0, 0,0);

            return date;
        }
        public static DateTime Ver_SeneninBasi()
        {
            DateTime date = new DateTime(DateTime.Now.Year,1,1,0,0,0,0);

            return date;
        }

        public static DateTime Ver_BaslangicTarih(DateTime Tarih)
        {
            return new DateTime(Tarih.Year, Tarih.Month, Tarih.Day, 0, 0, 0);
        }
        public static DateTime Ver_BitisTarih(DateTime Tarih)
        {
            return new DateTime(Tarih.Year, Tarih.Month, Tarih.Day, 23, 59, 59);
        }
    }
}