using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class ucGelirGiderHareket : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_GelirGiderHareketler;

        decimal Alacak = 0;
        decimal Borc = 0;
        decimal Bakiye = 0;
        #endregion

        #region < Özellikler >
        public int GelirGiderID { get; set; }
        #endregion

        #region < Load  >
        public ucGelirGiderHareket()
        {
            InitializeComponent();

            if (this.IsInDesignMode) return;
            dateKayitBas.EditValue = Araclar.TarihSaat.Ver_AyinBasi(DateTime.Now);
            dateKayitBit.EditValue = DateTime.Now;
        }
        #endregion

        #region < Olaylar >
        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara_GelirGiderHareket(GelirGiderID);
        }
        #endregion

        #region < Metod >
        public void Ara_GelirGiderHareket(int _GelirGiderID)
        {
            try
            {
                Alacak = Borc = Bakiye = 0;

                GelirGiderID = _GelirGiderID;

                if (dt_GelirGiderHareketler != null)
                    dt_GelirGiderHareketler.Dispose();

                dt_GelirGiderHareketler = Isler.GelirGider.Ver_GelirGiderHareketler(_GelirGiderID, Araclar.TarihSaat.Ver_BaslangicTarih(Convert.ToDateTime(dateKayitBas.EditValue))
                    , Araclar.TarihSaat.Ver_BitisTarih(Convert.ToDateTime(dateKayitBit.EditValue)));
                gridControGelirGiderHareket.DataSource = dt_GelirGiderHareketler;

                for (int i = 0; i < dt_GelirGiderHareketler.Rows.Count; i++)
                {
                    if (dt_GelirGiderHareketler.Rows[i]["AlacakTutar"] != DBNull.Value)
                        Alacak += Convert.ToDecimal(dt_GelirGiderHareketler.Rows[i]["AlacakTutar"]);

                    if (dt_GelirGiderHareketler.Rows[i]["BorcTutar"] != DBNull.Value)
                        Borc += Convert.ToDecimal(dt_GelirGiderHareketler.Rows[i]["BorcTutar"]);
                }

                Bakiye = Math.Round(Math.Round(Alacak, 2) - Math.Round(Borc, 2), 2);

                lblAlacak.Text = Alacak.ToString();
                lblBorc.Text = Borc.ToString();
                lblBakiye.Text = Bakiye.ToString();
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        #endregion
    }
}