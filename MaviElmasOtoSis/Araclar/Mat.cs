using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaviElmasOtoSis.Araclar
{
    public static class Mat
    {
        public static int Rasgele(int BaslangicDeger, int BitisDeger)
        {
            Random ras = new Random();
            return ras.Next(BaslangicDeger, BitisDeger);
        }

        public static int Rasgele(int BaslangicDeger, int BitisDeger, List<int> HaricSayilar)
        {
            int Sonuc = -1;

            do
            {
                Sonuc = Rasgele(BaslangicDeger, BitisDeger);
                
            } while (HaricSayilar.Contains(Sonuc));
           
            return Sonuc;
        }
    }
}