using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;
using Ionic.Zlib;

namespace MaviElmasOtoSis.Araclar
{
    public static class ZipDosya
    {
        #region < Değişkenler >
        public enum Seviyeler
        {
            EnIyi,
            EnHizli,
            Seviye0,
            Seviye1,
            Seviye2,
            Seviye3,
            Seviye4,
            Seviye5,
            Seviye6,
            Seviye7,
            Seviye8,
            Seviye9,
            Yok
        }
        #endregion

        #region < Özellikler >
        public static string SifreStr { get; set; }
        #endregion

        #region < Metod >
        public static void Ziple(List<string> Dosyalar, string Hedef, bool Sifre = false, Seviyeler Seviye = Seviyeler.Yok)
        {
            using (ZipFile zip = new ZipFile())
            {
                foreach (string item in Dosyalar)
                {
                    ZipEntry e = zip.AddFile(item, "");

                    if (Sifre)
                    {
                        e.Password = SifreStr;
                    }
                    switch (Seviye)
                    {
                        case Seviyeler.EnIyi:
                            e.CompressionLevel = CompressionLevel.BestCompression;
                            break;
                        case Seviyeler.EnHizli:
                            e.CompressionLevel = CompressionLevel.BestSpeed;
                            break;
                        case Seviyeler.Seviye0:
                            e.CompressionLevel = CompressionLevel.Level0;
                            break;
                        case Seviyeler.Seviye1:
                            e.CompressionLevel = CompressionLevel.Level1;
                            break;
                        case Seviyeler.Seviye2:
                            e.CompressionLevel = CompressionLevel.Level2;
                            break;
                        case Seviyeler.Seviye3:
                            e.CompressionLevel = CompressionLevel.Level3;
                            break;
                        case Seviyeler.Seviye4:
                            e.CompressionLevel = CompressionLevel.Level4;
                            break;
                        case Seviyeler.Seviye5:
                            e.CompressionLevel = CompressionLevel.Level5;
                            break;
                        case Seviyeler.Seviye6:
                            e.CompressionLevel = CompressionLevel.Level6;
                            break;
                        case Seviyeler.Seviye7:
                            e.CompressionLevel = CompressionLevel.Level7;
                            break;
                        case Seviyeler.Seviye8:
                            e.CompressionLevel = CompressionLevel.Level8;
                            break;
                        case Seviyeler.Seviye9:
                            e.CompressionLevel = CompressionLevel.Level9;
                            break;
                        case Seviyeler.Yok:
                            e.CompressionLevel = CompressionLevel.None;
                            break;
                    }
                }

                zip.Save(Hedef);
            }
        }
        public static void Ziple(string Dosya, string Hedef, bool Sifre = false, Seviyeler Seviye = Seviyeler.Yok)
        {
            List<string> dosya = new List<string>();
            dosya.Add(Dosya);
            Ziple(dosya, Hedef, Sifre, Seviye);
        }

        public static string UnZip(string Kaynak, string Hedef, bool Sifre = false)
        {
            string Sonuc = "";
            using (ZipFile zip1 = ZipFile.Read(Kaynak))
            {
                if (Sifre)
                {
                    zip1.Password = "365218714";
                }
                foreach (ZipEntry e in zip1)
                {
                    if (Sifre)
                    {
                        e.ExtractWithPassword(Hedef, ExtractExistingFileAction.OverwriteSilently, SifreStr);
                    }
                    else
                    {
                        e.Extract(Hedef, ExtractExistingFileAction.OverwriteSilently);
                    }

                    Sonuc = e.FileName;
                }
            }

            return Sonuc;
        }
        public static void Unzip_Stream(string Kaynak, ref System.IO.MemoryStream stream, bool Sifre = false)
        {
            using (ZipFile zip1 = ZipFile.Read(Kaynak))
            {
                if (Sifre)
                {
                    zip1.Password = "365218714";
                }
                foreach (ZipEntry e in zip1)
                {
                    if (Sifre)
                    {
                        e.ExtractWithPassword(stream, SifreStr);
                    }
                    else
                    {
                        e.Extract(stream);
                    }
                }
            }
        }
        #endregion
    }
}