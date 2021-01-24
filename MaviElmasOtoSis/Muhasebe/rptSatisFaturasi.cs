using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class rptSatisFaturasi : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSatisFaturasi()
        {
            InitializeComponent();

            lblKartID.DataBindings.Add(new XRBinding("Text", null, "ParcaNo"));
            lblIscilikID.DataBindings.Add(new XRBinding("Text", null, "IscilikID"));
            lblParcaAd.DataBindings.Add(new XRBinding("Text", null, "KalemIscilikAdi"));
            lblMiktar.DataBindings.Add(new XRBinding("Text", null, "Miktar"));
            lblBirimFiyat.DataBindings.Add(new XRBinding("Text", null, "BirimFiyat"));
            lblIndirim.DataBindings.Add(new XRBinding("Text", null, "IndirimYuzde"));
            lblTutar.DataBindings.Add(new XRBinding("Text", null, "NetTutar"));
            lblKdv.DataBindings.Add(new XRBinding("Text", null, "Kdv"));

            lblCariID.Text = lblUnvan.Text = lblAdres.Text = lblVergiDairesi.Text = lblTcKimlik.Text = "";
        }

        public void Yukle(DataTable dt)
        {
            this.DataSource = dt;
        }
    }
}