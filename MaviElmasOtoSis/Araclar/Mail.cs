using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace MaviElmasOtoSis.Araclar
{
    public class Mail
    {
        #region < Değişkenler >
        MailMessage mail;
        #endregion

        #region < Özellikler >
        public string KimdenMailAdres { get; set; }
        public string GonderenIsim { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public bool HtmlIcerik { get; set; }

        public string Host { get; set; }
        public int HostPort { get; set; }
        public string HostKullaniciAdi { get; set; }
        public string HostSifre { get; set; }

        public List<string> Kime { get; set; }
        public List<string> CC { get; set; }
        public List<string> Bcc { get; set; }
        #endregion

        #region < Yapıcı >
        public Mail()
        {
            Temizle_MailBilgileri();
        }
        #endregion

        #region < Metod >
        public void Gonder()
        {
            #region Kontroller
            if (string.IsNullOrEmpty(Host))
                throw new Exception("Host Bilgisi Girilmemiş.");
            if (HostPort <= 0)
                throw new Exception("Host Port Bilgisi Girilmemiş.");
            if (string.IsNullOrEmpty(HostKullaniciAdi))
                throw new Exception("Host Kullanıcı Adı Girilmemiş.");
            if (string.IsNullOrEmpty(HostSifre))
                throw new Exception("Host Kullanıcı Şifresi Girilmemiş.");
            if (string.IsNullOrEmpty(KimdenMailAdres))
                throw new Exception("Kimden Bilgisi Girilmemiş.");
            if (!Dogrulama.EmailDogrula(KimdenMailAdres))
                throw new Exception("Kimden Bilgisi Geçerli Bir Mail Adresi Değil.");
            if (string.IsNullOrEmpty(GonderenIsim))
                throw new Exception("Gönderen İsmi Girilmemiş.");
            #endregion

            #region Mail Gönderme
            using (mail = new MailMessage())
            {
                mail.From = new MailAddress(KimdenMailAdres, GonderenIsim);
                mail.Subject = Konu;
                mail.Body = Icerik;
                mail.IsBodyHtml = HtmlIcerik;


                foreach (string item in Kime)
                {
                    mail.To.Add(new MailAddress(item));
                }
                foreach (string item in CC)
                {
                    mail.CC.Add(new MailAddress(item));
                }
                foreach (string item in Bcc)
                {
                    mail.Bcc.Add(new MailAddress(item));
                }

                using (SmtpClient SmtpServer = new SmtpClient(Host))
                {
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(HostKullaniciAdi, HostSifre);
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                }
            }
            #endregion
        }

        public void Ekle_Kime(string MailAdres)
        {
            if (!Dogrulama.EmailDogrula(MailAdres))
                throw new Exception("Geçersiz Mail Adresi");
            if (Kime.Contains(MailAdres))
                throw new Exception("Bu Mail Adresi Daha Önce Eklenmiş.");

            Kime.Add(MailAdres);
        }
        public void Ekle_CC(string MailAdres)
        {
            if (!Dogrulama.EmailDogrula(MailAdres))
                throw new Exception("Geçersiz Mail Adresi");
            if (CC.Contains(MailAdres))
                throw new Exception("Bu Mail Adresi Daha Önce Eklenmiş.");

            CC.Add(MailAdres);
        }
        public void Ekle_Bcc(string MailAdres)
        {
            if (!Dogrulama.EmailDogrula(MailAdres))
                throw new Exception("Geçersiz Mail Adresi");
            if (Bcc.Contains(MailAdres))
                throw new Exception("Bu Mail Adresi Daha Önce Eklenmiş.");

            Bcc.Add(MailAdres);
        }

        public void Sil_Kime(string MailAdres)
        {
            if (string.IsNullOrEmpty(MailAdres))
                throw new Exception("Mail Adresi Boş.");

            if (Kime.Contains(MailAdres))
            {
                Kime.Remove(MailAdres);
            }
        }
        public void Sil_CC(string MailAdres)
        {
            if (string.IsNullOrEmpty(MailAdres))
                throw new Exception("Mail Adresi Boş.");

            if (CC.Contains(MailAdres))
            {
                CC.Remove(MailAdres);
            }
        }
        public void Sil_Bcc(string MailAdres)
        {
            if (string.IsNullOrEmpty(MailAdres))
                throw new Exception("Mail Adresi Boş.");

            if (Bcc.Contains(MailAdres))
            {
                Bcc.Remove(MailAdres);
            }
        }

        public void Degistir_Kime(string DegistirilecekMailAdres, string YeniMailAdres)
        {
            if (string.IsNullOrEmpty(DegistirilecekMailAdres))
                throw new Exception("Değiştirilecek Mail Adresi Boş.");
            if (string.IsNullOrEmpty(YeniMailAdres))
                throw new Exception("Yeni Mail Adresi Boş.");
            if (Kime.Contains(YeniMailAdres))
                throw new Exception("Bu Mail Adresi Daha Önce Eklenmiş.");

            if (Kime.Contains(DegistirilecekMailAdres))
            {
                Sil_Kime(DegistirilecekMailAdres);
                Ekle_Kime(YeniMailAdres);
            }
            else
            {
                throw new Exception("Böyle Bir Mail Adresi Bulunamadı.");
            }
        }
        public void Degistir_CC(string DegistirilecekMailAdres, string YeniMailAdres)
        {
            if (string.IsNullOrEmpty(DegistirilecekMailAdres))
                throw new Exception("Değiştirilecek Mail Adresi Boş.");
            if (string.IsNullOrEmpty(YeniMailAdres))
                throw new Exception("Yeni Mail Adresi Boş.");
            if (CC.Contains(YeniMailAdres))
                throw new Exception("Bu Mail Adresi Daha Önce Eklenmiş.");

            if (CC.Contains(DegistirilecekMailAdres))
            {
                Sil_CC(DegistirilecekMailAdres);
                Ekle_CC(YeniMailAdres);
            }
            else
            {
                throw new Exception("Böyle Bir Mail Adresi Bulunamadı.");
            }
        }
        public void Degistir_Bcc(string DegistirilecekMailAdres, string YeniMailAdres)
        {
            if (string.IsNullOrEmpty(DegistirilecekMailAdres))
                throw new Exception("Değiştirilecek Mail Adresi Boş.");
            if (string.IsNullOrEmpty(YeniMailAdres))
                throw new Exception("Yeni Mail Adresi Boş.");
            if (Bcc.Contains(YeniMailAdres))
                throw new Exception("Bu Mail Adresi Daha Önce Eklenmiş.");

            if (Bcc.Contains(DegistirilecekMailAdres))
            {
                Sil_Bcc(DegistirilecekMailAdres);
                Ekle_Bcc(YeniMailAdres);
            }
            else
            {
                throw new Exception("Böyle Bir Mail Adresi Bulunamadı.");
            }
        }

        public void Temizle_Kime()
        {
            Kime.Clear();
        }
        public void Temizle_CC()
        {
            CC.Clear();
        }
        public void Temizle_Bcc()
        {
            Bcc.Clear();
        }
        public void Temizle_TumAlicilar()
        {
            Kime = new List<string>();
            CC = new List<string>();
            Bcc = new List<string>();
        }
        public void Temizle_MailBilgileri()
        {
            Konu = Icerik = KimdenMailAdres = Host = HostKullaniciAdi = HostSifre = "";

            HostPort = 0;
            HtmlIcerik = false;

            Temizle_TumAlicilar();
        }
        #endregion
    }
}