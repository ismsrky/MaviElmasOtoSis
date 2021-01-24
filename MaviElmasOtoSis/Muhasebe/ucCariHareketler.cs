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
    public partial class ucCariHareketler : Sistem.ucBase
    {
        #region < Değişkenler >
        DataTable dt_CariHareketler;

        decimal Alacak = 0;
        decimal Borc = 0;
        decimal Bakiye = 0;
        #endregion

        #region < Özellikler >
        public int CariID { get; set; }
        #endregion

        #region < Load  >
        public ucCariHareketler()
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
            Ara_CariHareket(CariID);
        }
        #endregion

        #region < Metod >
        public void Ara_CariHareket(int _CariID)
        {
            try
            {
                Alacak = Borc = Bakiye = 0;

                CariID = _CariID;

                if (dt_CariHareketler != null)
                    dt_CariHareketler.Dispose();

                dt_CariHareketler = Isler.Cari.Ver_CariHareketler(_CariID, Araclar.TarihSaat.Ver_BaslangicTarih(Convert.ToDateTime(dateKayitBas.EditValue))
                    , Araclar.TarihSaat.Ver_BitisTarih(Convert.ToDateTime(dateKayitBit.EditValue)));
                gridControlCariHareket.DataSource = dt_CariHareketler;

                for (int i = 0; i < dt_CariHareketler.Rows.Count; i++)
                {
                    if (dt_CariHareketler.Rows[i]["AlacakTutar"] != DBNull.Value)
                        Alacak += Convert.ToDecimal(dt_CariHareketler.Rows[i]["AlacakTutar"]);

                    if (dt_CariHareketler.Rows[i]["BorcTutar"] != DBNull.Value)
                        Borc += Convert.ToDecimal(dt_CariHareketler.Rows[i]["BorcTutar"]);
                }

                Bakiye = Math.Round(Math.Round(Borc, 2) - Math.Round(Alacak, 2), 2);

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