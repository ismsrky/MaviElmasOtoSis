using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace MaviElmasOtoSis
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                #region < Devexpress Ayarları >
                //MessageBox.Show("1");
                Araclar.Sifreleme.Key = new byte[] { 221, 129, 5, 240, 31, 67, 179, 18, 54, 123, 38, 33, 78, 145, 99, 168, 137, 4, 252, 92, 74, 25, 89, 62, 57, 73, 194, 205, 216, 164, 23, 234 };
                Araclar.Sifreleme.Vector = new byte[] { 28, 91, 66, 111, 32, 35, 124, 119, 231, 29, 221, 112, 79, 32, 111, 210 };
                Araclar.ZipDosya.SifreStr = "i1k341578Q";
                //MessageBox.Show("2");

                try
                {
                    if (!File.Exists(Application.StartupPath + @"\ayarlar.xml"))
                    {
                        MessageBox.Show("Program Dizininde Olması Gereken 'ayarlar.xml' Dosyası Bulunamadı.", "Dosya Yok",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                    }
                    //MessageBox.Show("3");
                    Sistem.Ayarlar.Oku();
                   // MessageBox.Show("4");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Program Dizinindeki 'ayarlar.xml' Dosyası Okunurken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
               // MessageBox.Show("5");
                DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.SiyahYesil).Assembly);
                DevExpress.UserSkins.BonusSkins.Register(); //Bonus temalar açılıyor.
                //DevExpress.UserSkins.OfficeSkins.Register();
               // MessageBox.Show("7");
                DevExpress.Skins.SkinManager.EnableFormSkins(); //Formları da temalı gösterir.
               // MessageBox.Show("8");
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Sistem.Ayarlar.TemaAdi);
                DevExpress.LookAndFeel.UserLookAndFeel.Default.StyleChanged += new EventHandler(Default_StyleChanged);
                Genel.AyarCek();
                #endregion

                #region < Standart >
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmGirisEkrani());
                #endregion
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        static void Default_StyleChanged(object sender, EventArgs e)
        {
            //Sistem.Ayarlar.TemaAdi = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
            //Sistem.Ayarlar.Kaydet();
        }
    }
}
