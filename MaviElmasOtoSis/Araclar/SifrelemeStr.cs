using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MaviElmasOtoSis.Araclar
{
    public static class SifrelemeStr
    {
        public static string Sifrele(string Sifrelenecek_Deger)
        {
            return Convert.ToBase64String(Encoding.Unicode.GetBytes(Sifrelenecek_Deger));
        }

        public static string Coz(string Cozulecek_Deger)
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(Cozulecek_Deger));
        }
    }
}