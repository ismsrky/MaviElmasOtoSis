using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.Isler
{
    public class Loglar
    {
        public static void Ekle_Log(Enumlar.LogTurleri LogTuru, string IP, int? KullaniciID=null, string Ad = null, string Soyad = null, string Aciklama = null)
        {
            using (otosisdbEntities dbModel = new otosisdbEntities(Baglanti.BaglantiEntity))
            {
                loglar lg = new loglar();
                lg.LogTuru = ((int)LogTuru).ToString();
                lg.IP = IP;
                lg.KullaniciID = KullaniciID;
                lg.Ad = Ad;
                lg.Soyad = Soyad;
                lg.Aciklama = Aciklama;
                lg.Tarih = DateTime.Now;
                dbModel.AddTologlars(lg);
                dbModel.SaveChanges();
            }
        }
    }
}