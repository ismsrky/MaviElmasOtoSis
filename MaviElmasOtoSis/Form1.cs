using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis
{
    public partial class Form1 : Form
    {
        otosisdbEntities dbModel;

        public Form1()
        {
            InitializeComponent();

            dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = Araclar.Veri.exceldata(Application.StartupPath + @"\dilek.xls", "Sayfa1");

            string temp_Plaka;
            int temp_CariID;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                temp_Plaka = dt.Rows[i]["PLAKA"].ToString();
                temp_CariID = Convert.ToInt32(dt.Rows[i]["CARI_ID"]);

                arac arc = new arac();
                arc.Plaka = temp_Plaka;
                arc.RuhsatSahibi = Isler.Cari.Ver_CariUnvan(temp_CariID);
                arc.SaseNo = "1234";
                arc.MarkaID = 17;
                arc.ModelID = 71;

                arc.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                arc.KayitZaman = DateTime.Now;
                arc.SirketID = Genel.AktifSirket.SirketID;

                dbModel.AddToaracs(arc);
                dbModel.SaveChanges();
            }
        }
    }
}
