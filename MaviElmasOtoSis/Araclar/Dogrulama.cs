using System;
using System.Text.RegularExpressions;

namespace MaviElmasOtoSis.Araclar
{
    public static class Dogrulama
    {
        #region < Metod >
        /// <summary>
        /// Girilen değerin uygun bir TC Kimlik numarası olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="tcKimlikNo">Kontrol edilecek TC Kimlik Numarası.</param>
        /// <returns></returns>
        public static bool TcDogrula(string tcKimlikNo)
        {
            bool returnvalue = false;
            if (string.IsNullOrEmpty(tcKimlikNo) == false && tcKimlikNo.Length == 11 && IsNumeric(tcKimlikNo))
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tcKimlikNo);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }
            return returnvalue;
        }

        /// <summary>
        /// Girilen değeri tam sayı(integer) olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="text">Kontrol edilecek değer.</param>
        /// <returns></returns>
        public static bool IsNumeric(string text)
        {
            return Regex.IsMatch(text, "^\\d+$");
        }
        /// <summary>
        /// Girilen değerin tam sayı(integer) veya virgüllü sayı olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="deger">Kontrol edilecek değer.</param>
        /// <returns></returns>
        public static bool IsNumericOrDecimal(string deger)
        {
            if (IsNumeric(deger))
            {
                return true;
            }

            decimal decValue;
            return decimal.TryParse(deger, out decValue);
        }

        /// <summary>
        /// Girilen değerin geçerli bir mail adresi olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="Email">Kontrol edilecek değer.</param>
        /// <returns></returns>
        public static bool EmailDogrula(string Email)
        {
            return Regex.IsMatch(Email,
                @"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+&lt;(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})&gt;$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$");
        }
        #endregion
    }
}