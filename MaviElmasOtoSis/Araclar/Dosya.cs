using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MaviElmasOtoSis.Araclar
{
    public static class Dosya
    {
        #region < Metod >
        /// <summary>
        /// İstenilen dosyanın uzantısı verir.'.exe','.pdf' gibi.
        /// </summary>
        /// <param name="DosyaYolu">Dosya Yolu</param>
        /// <returns></returns>
        public static string Ver_Uzanti(string DosyaYolu)
        {
            string uzanti = "";

            uzanti = Path.GetExtension(DosyaYolu);

            return uzanti;
        }

        /// <summary>
        /// İstenilen dosyanın dosya boyutunu '.. mb','.. kb' vs. şeklinde döndürür.
        /// </summary>
        /// <param name="DosyaYolu">Dosya Yolu</param>
        /// <returns></returns>
        public static string Ver_DosyaBoyutu(string DosyaYolu)
        {
            FileInfo f = new FileInfo(DosyaYolu);

            return String.Format(new FileSizeFormatProvider(), "{0:fs}", f.Length);
        }

        /// <summary>
        /// Text bir dosyanın tüm satırlarını okuyup string olarak dönderir.
        /// </summary>
        /// <param name="DosyaYolu">Dosya Yolu.</param>
        /// <returns></returns>
        public static string Oku_Dosyadan(string DosyaYolu)
        {
            string Sonuc = "";

            using (StreamReader oku = new StreamReader(DosyaYolu))
            {
                while (!oku.EndOfStream)
                {
                    Sonuc += oku.ReadLine();
                }
                oku.Close();
            }
            return Sonuc;
        }

        /// <summary>
        /// Herhangi bir string veriyi bir text dosyasına yazar.
        /// </summary>
        /// <param name="DosyaYolu">Yazılacak dosyanın yolu.</param>
        /// <param name="Deger">Yazılacak değer/text</param>
        /// <param name="Append">Varolan dosyanın peşine yazılsın mı? Eğer false seçilirse varolan dosyanın tüm bilgileri silinir ve üzerine yazılır.</param>
        public static void Yaz_Dosyaya(string DosyaYolu, string Deger, bool Append = false)
        {
            using (StreamWriter yaz = new StreamWriter(DosyaYolu, Append))
            {
                yaz.Write(Deger);
                yaz.Close();
            }
        }
        #endregion
    }
}