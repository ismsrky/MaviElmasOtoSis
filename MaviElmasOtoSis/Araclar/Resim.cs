using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

namespace MaviElmasOtoSis.Araclar
{
    public static class Resim
    {
        #region < Metod >
        /// <summary>
        /// İstenilen resmi istenilen ebatlarda yeniden boyutlandırır.
        /// </summary>
        /// <param name="BoyutlanacakResim">Yeniden boyutlandırılmak istenen resim.</param>
        /// <param name="Ebatlar">Yeni resmin boyutları.</param>
        /// <returns></returns>
        public static Image YenidenBoyunlandir(Image BoyutlanacakResim, Size Ebatlar)
        {
            int sourceWidth = BoyutlanacakResim.Width;
            int sourceHeight = BoyutlanacakResim.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Ebatlar.Width / (float)sourceWidth);
            nPercentH = ((float)Ebatlar.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(BoyutlanacakResim, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        /// <summary>
        /// Verilen resmi byte dizine dönüştürür.
        /// </summary>
        /// <param name="img">Byte dizisine dönüştürülecek resim.</param>
        /// <returns></returns>
        public static byte[] ImageToByte2(Image img)
        {

            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        /// <summary>
        /// Girilen uzantıya göre bir resim önizlemi dönderir.
        /// </summary>
        /// <param name="Uzanti">Dosyanın uzantısı.</param>
        /// <returns></returns>
        public static Image Ver_ResimUzantiyaGore(string Uzanti)
        {
            Image Res = null;
            if (Uzanti == ".mdb" || Uzanti == ".accdb")
            {
                Res = Bilesenler.ResUzantilar.ACCESS;
            }
            else if (Uzanti == ".exe" || Uzanti == ".EXE" || Uzanti == ".dll" || Uzanti == ".DLL")
            {
                Res = Bilesenler.ResUzantilar.EXE;
            }
            else if (Uzanti == ".xls" || Uzanti == ".XLS" || Uzanti == ".XLSX" || Uzanti == ".xlsx" || Uzanti == ".xlsm" || Uzanti == ".xltx" || Uzanti == ".xltm" || Uzanti == ".xlsb" || Uzanti == ".xlam")
            {
                Res = Bilesenler.ResUzantilar.MSEXCEL;
            }
            else if (Uzanti == ".doc" || Uzanti == ".DOC" || Uzanti == ".DOCX" || Uzanti == ".docx" || Uzanti == ".docm" || Uzanti == ".dotx" || Uzanti == ".dotm")
            {
                Res = Bilesenler.ResUzantilar.MSWORD;
            }
            else if (Uzanti == ".pdf" || Uzanti == ".PDF")
            {
                Res = Bilesenler.ResUzantilar.PDF;
            }
            else if (Uzanti == ".ppt" || Uzanti == ".PPT" || Uzanti == ".pptx" || Uzanti == ".pptm" || Uzanti == ".potx" || Uzanti == ".potm" || Uzanti == ".ppam" || Uzanti == ".ppsx" || Uzanti == ".ppsm" || Uzanti == ".sldx" || Uzanti == ".sldm" || Uzanti == ".thmx")
            {
                Res = Bilesenler.ResUzantilar.POWERPOINT;
            }
            else if (Uzanti == ".rar" || Uzanti == ".RAR")
            {
                Res = Bilesenler.ResUzantilar.RAR;
            }
            else if (Uzanti == ".zip" || Uzanti == ".ZIP")
            {
                Res = Bilesenler.ResUzantilar.ZIP;
            }
            else if (Uzanti == ".mp3" || Uzanti == ".wav" || Uzanti == ".wma" || Uzanti == ".m3u" || Uzanti == ".aiff" || Uzanti == ".au" || Uzanti == ".cdda" || Uzanti == ".raw" || Uzanti == ".flac" || Uzanti == ".la" || Uzanti == ".pac" || Uzanti == ".m4a" || Uzanti == ".mp2" || Uzanti == ".aac" || Uzanti == ".ra" || Uzanti == ".rm" || Uzanti == ".mid" || Uzanti == ".cust" || Uzanti == ".mus" || Uzanti == ".sib" || Uzanti == ".mod" || Uzanti == ".rmj" || Uzanti == ".asf")
            {
                Res = Bilesenler.ResUzantilar.SES;
            }
            else if (Uzanti == ".txt" || Uzanti == ".TXT")
            {
                Res = Bilesenler.ResUzantilar.TEXT;
            }
            else if (Uzanti == ".tiff")
            {
                Res = Bilesenler.ResUzantilar.TIFF;
            }
            else if (Uzanti == ".mpg" || Uzanti == ".mp4" || Uzanti == ".aaf" || Uzanti == ".3gp" || Uzanti == ".swf" || Uzanti == ".mov" || Uzanti == ".mpeg" || Uzanti == ".ogm" || Uzanti == ".wmv" || Uzanti == ".divx" || Uzanti == ".xvid" || Uzanti == ".flv")
            {
                Res = Bilesenler.ResUzantilar.VIDEO;
            }
            else
            {
                Res = Bilesenler.ResUzantilar.BILINMEYEN;
            }

            return Res;
        }
        #endregion
    }
}