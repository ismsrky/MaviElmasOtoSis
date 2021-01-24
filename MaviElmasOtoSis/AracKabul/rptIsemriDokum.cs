using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MaviElmasOtoSis.AracKabul
{
    public partial class rptIsemriDokum : DevExpress.XtraReports.UI.XtraReport
    {
        public rptIsemriDokum()
        {
            InitializeComponent();

            lblTalep.DataBindings.Add(new XRBinding("Text", null, "Talep"));

            Temizle();
        }

        public void Temizle()
        {
            lblAdres.Text = lblCariID.Text = lblDanisman.Text = lblGetirenKisi.Text = lblIsemriKayitZaman.Text = lblKmYakit.Text = lblPlaka.Text
             = lblSasiNo.Text = lblServisIsemriNo.Text = lblTcKimlik.Text = lblTelefon.Text = lblUnvan.Text = lblVergiDairesi.Text = "";
        }
    }
}