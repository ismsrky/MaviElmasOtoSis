using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Muhasebe
{
    public partial class ucFaturaDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;
        fatura _ft;

        int _Secili_FaturaID;

        DataTable dt_FaturaElemanlari;
        DataTable dt_Depolar;
        DataTable dt_StokKartlar;
        DataTable dt_Iscilikler;
        DataTable dt_Araclar;

        public DetayOlayHandler DetayOlay;
        #endregion

        #region < Özellikler >
        public Enumlar.DetayModelari DetayMode
        {
            get
            {
                return _DetayMode;
            }
            set
            {
                _DetayMode = value;
            }
        }

        public int Secili_FaturaID
        {
            get
            {
                return _Secili_FaturaID;
            }
        }

        public Enumlar.FaturaTipleri FaturaTipi { get; set; }
        #endregion

        #region < Load >
        public ucFaturaDetay()
        {
            _Yukleme = true;
            InitializeComponent();
        }

        private void ucFaturaDetay_Load(object sender, EventArgs e)
        {
            if (this.IsInDesignMode) return;

            try
            {
                _Yukleme = true;
                dbModel = new otosisdbEntities(VeriYonetimi.Baglanti.BaglantiEntity);

                #region Initilize reGridLookStokKartlari
                DevExpress.XtraGrid.Columns.GridColumn colKartID = new DevExpress.XtraGrid.Columns.GridColumn();
                DevExpress.XtraGrid.Columns.GridColumn colKalemAdi = new DevExpress.XtraGrid.Columns.GridColumn();
                DevExpress.XtraGrid.Columns.GridColumn colParcaNo = new DevExpress.XtraGrid.Columns.GridColumn();
                DevExpress.XtraGrid.Columns.GridColumn colStokBirim = new DevExpress.XtraGrid.Columns.GridColumn();
                DevExpress.XtraGrid.Columns.GridColumn colStokGrup = new DevExpress.XtraGrid.Columns.GridColumn();
                DevExpress.XtraGrid.Columns.GridColumn colBarkodNo = new DevExpress.XtraGrid.Columns.GridColumn();
                DevExpress.XtraGrid.Columns.GridColumn colStokMiktar = new DevExpress.XtraGrid.Columns.GridColumn();

                // 
                // colKartID
                // 
                colKartID.AppearanceCell.Options.UseTextOptions = true;
                colKartID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                colKartID.Caption = "Kart No";
                colKartID.FieldName = "KartID";
                colKartID.MaxWidth = 50;
                colKartID.Name = "colKartID";
                colKartID.Visible = true;
                colKartID.VisibleIndex = 0;
                colKartID.Width = 50;
                // 
                // colKalemAdi
                // 
                colKalemAdi.Caption = "Kalem Adı";
                colKalemAdi.FieldName = "KalemAdi";
                colKalemAdi.Name = "colKalemAdi";
                colKalemAdi.Visible = true;
                colKalemAdi.VisibleIndex = 1;
                colKalemAdi.Width = 124;
                // 
                // colParcaNo
                // 
                colParcaNo.Caption = "Parça No";
                colParcaNo.FieldName = "ParcaNo";
                colParcaNo.Name = "colParcaNo";
                colParcaNo.Visible = true;
                colParcaNo.VisibleIndex = 2;
                colParcaNo.Width = 124;
                // 
                // colBarkodNo
                // 
                colBarkodNo.Caption = "Barkod No";
                colBarkodNo.FieldName = "BarkodNo";
                colBarkodNo.Name = "colBarkodNo";
                colBarkodNo.Visible = true;
                colBarkodNo.VisibleIndex = 4;
                // 
                // colStokBirim
                // 
                colStokBirim.Caption = "Stok Birimi";
                colStokBirim.FieldName = "StokBirim";
                colStokBirim.Name = "colStokBirim";
                colStokBirim.Visible = true;
                colStokBirim.VisibleIndex = 5;
                // 
                // colStokGrup
                // 
                colStokGrup.Caption = "Stok Grubu";
                colStokGrup.FieldName = "StokGrup";
                colStokGrup.Name = "colStokGrup";
                colStokGrup.Visible = true;
                colStokGrup.VisibleIndex = 6;

                reGridLookStokKartlari.View.Columns.Add(colKartID);
                reGridLookStokKartlari.View.Columns.Add(colKalemAdi);
                reGridLookStokKartlari.View.Columns.Add(colParcaNo);
                reGridLookStokKartlari.View.Columns.Add(colStokBirim);
                reGridLookStokKartlari.View.Columns.Add(colStokGrup);
                reGridLookStokKartlari.View.Columns.Add(colBarkodNo);
                reGridLookStokKartlari.View.Columns.Add(colStokMiktar);

                reGridLookStokKartlari.DisplayMember = "ParcaNo";
                reGridLookStokKartlari.ValueMember = "ParcaNo";
                reGridLookStokKartlari.View.OptionsView.ShowAutoFilterRow = true;
                #endregion

                if (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis)
                {
                    #region Initilize reGridLookUpIscilikler
                    DevExpress.XtraGrid.Columns.GridColumn colIscilikID = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn colIscilikAd = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn colIscilikTipAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn colKacSaat = new DevExpress.XtraGrid.Columns.GridColumn();
                    DevExpress.XtraGrid.Columns.GridColumn colIscilikTip = new DevExpress.XtraGrid.Columns.GridColumn();

                    // 
                    // colIscilikID
                    // 
                    colIscilikID.AppearanceCell.Options.UseTextOptions = true;
                    colIscilikID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    colIscilikID.Caption = "İşçilik No";
                    colIscilikID.FieldName = "IscilikID";
                    colIscilikID.MaxWidth = 60;
                    colIscilikID.MinWidth = 50;
                    colIscilikID.Name = "colIscilikID";
                    colIscilikID.Visible = true;
                    colIscilikID.VisibleIndex = 0;
                    colIscilikID.Width = 50;
                    // 
                    // colIscilikAd
                    // 
                    colIscilikAd.Caption = "İşçilik Adı";
                    colIscilikAd.FieldName = "IscilikAd";
                    colIscilikAd.Name = "colIscilikAd";
                    colIscilikAd.Visible = true;
                    colIscilikAd.VisibleIndex = 1;
                    colIscilikAd.Width = 292;
                    // 
                    // colIscilikTipAciklama
                    // 
                    colIscilikTipAciklama.Caption = "İşçilik Tipi";
                    colIscilikTipAciklama.FieldName = "IscilikTipAciklama";
                    colIscilikTipAciklama.MaxWidth = 70;
                    colIscilikTipAciklama.Name = "colIscilikTipAciklama";
                    colIscilikTipAciklama.Visible = true;
                    colIscilikTipAciklama.VisibleIndex = 2;
                    colIscilikTipAciklama.Width = 70;
                    // 
                    // colKacSaat
                    // 
                    colKacSaat.Caption = "Kaç Saat";
                    colKacSaat.FieldName = "KacSaat";
                    colKacSaat.MaxWidth = 60;
                    colKacSaat.MinWidth = 50;
                    colKacSaat.Name = "colKacSaat";
                    colKacSaat.Visible = true;
                    colKacSaat.VisibleIndex = 3;
                    colKacSaat.Width = 50;
                    // 
                    // colIscilikTip
                    // 
                    colIscilikTip.Caption = "IscilikTip";
                    colIscilikTip.FieldName = "IscilikTip";
                    colIscilikTip.Name = "colIscilikTip";

                    reGridLookUpIscilikler.View.Columns.Add(colIscilikID);
                    reGridLookUpIscilikler.View.Columns.Add(colIscilikAd);
                    reGridLookUpIscilikler.View.Columns.Add(colIscilikTipAciklama);
                    reGridLookUpIscilikler.View.Columns.Add(colKacSaat);
                    reGridLookUpIscilikler.View.Columns.Add(colIscilikTip);

                    reGridLookUpIscilikler.DisplayMember = "IscilikID";
                    reGridLookUpIscilikler.ValueMember = "IscilikID";
                    reGridLookUpIscilikler.View.OptionsView.ShowAutoFilterRow = true;
                    #endregion

                    Isler.Genelkodlar.Ver_Kod("IscilikTip", ref reLookUpIscilikTip);

                    colIndirim2.Visible = colIndirim3.Visible = false;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("ID", typeof(int));
                    dt.Columns.Add("Alan", typeof(string));
                    DataRow dr = dt.NewRow();
                    dr["ID"] = 0;
                    dr["Alan"] = "Stok Kartı";
                    dt.Rows.Add(dr);
                    dr = dt.NewRow();
                    dr["ID"] = 1;
                    dr["Alan"] = "İşçilik";
                    dt.Rows.Add(dr);
                    reLookUpKalemTip.DataSource = dt;
                    reLookUpKalemTip.ValueMember = "ID";
                    reLookUpKalemTip.DisplayMember = "Alan";
                }

                if (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis)
                {
                    ucIsemriDemo1.DetayOlay += new DetayOlayHandler(DetayOlayi);
                }

                if (FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis)
                {
                    colKalemIscilikAdi.Caption = "Kalem Adı";
                    colMiktar.Caption = "Miktar";
                    colFiyat.Caption = "Birim Fiyatı";
                    radioFaturaKaynak.Visible = ucIsemriDemo1.Visible = colIscilikTip.Visible = colIscilikID.Visible
                    = lblKaynakCaption.Visible = colTip.Visible = btnYazdir.Visible = false;

                    colAracID.Visible = true;

                    ucBankaDemo1.Size = new System.Drawing.Size(293, 78);
                    ucBankaDemo1.Location = new Point(457, 27);
                }

                if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis || FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis)
                {
                    lblKdvCaption.Visible = lblKdv18Caption.Visible = lblKdv18.Visible = chkKdvli.Visible = lblTevfikat.Visible = lblTevfikatCaption.Visible
                    = colKdv.Visible = false;
                }
                if (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi)
                {
                    lblKdvYuzdeCaption.Visible = spinKdvYuzde.Visible = lblTevfikat.Visible = lblTevfikatCaption.Visible = true;
                }

                dt_Depolar = Genel.dt_DepolarSecim.Copy();
                reLookUpDepo.DisplayMember = "DepoAd";
                reLookUpDepo.ValueMember = "DepoID";
                reLookUpDepo.DataSource = dt_Depolar;

                Isler.Genelkodlar.Ver_Kod("StokBirim", ref reLookUpBirim, "Saat");

                reGridLookAraclar.DisplayMember = "Plaka";
                reGridLookAraclar.ValueMember = "AracID";
                reGridLookAraclar.View.OptionsView.ShowAutoFilterRow = true;

                Ara_StokKartlari(false);
                Ara_Iscilikler(false);
                Ara_Araclar(false);
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Stok Kartları Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        private void radioFaturaKaynak_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Yukleme) return;
            Ara_FaturaElemanlari(-1, null);

            Temizle_GenelToplam();
            if (radioFaturaKaynak.SelectedIndex == 0 || radioFaturaKaynak.SelectedIndex==2) //Bağımsız
            {
                ucIsemriDemo1.Temizle_Isemri();

                lblPlakaCaption.Visible = txtAracPlaka.Visible = btnAracSec.Visible 
                = lblIsemriBitisTarih.Visible = dateIsemriBitisTarih.Visible = ucIsemriDemo1.Enabled = false;

                //ucCariHesapDemo1.Enabled = true;
                GridViewParcaIscilikler.AddNewRow();
            }
            else //İşemrinde
            {
                lblIsemriBitisTarih.Visible = dateIsemriBitisTarih.Visible = ucIsemriDemo1.Enabled = true;

                lblPlakaCaption.Visible = txtAracPlaka.Visible = btnAracSec.Visible = false;
                //ucCariHesapDemo1.Enabled = false;
                ucCariHesapDemo1.Temizle_Cari();
            }

            if (radioFaturaKaynak.SelectedIndex == 2)
            {
                lblPlakaCaption.Visible = txtAracPlaka.Visible = btnAracSec.Visible = true;
            }
        }
        private void radioFaturaTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioFaturaTip.SelectedIndex == 0) //Açık
            {
                ucKasaDemo1.Temizle_Kasa();
                ucBankaDemo1.Temizle_Banka();

                ucBankaDemo1.Enabled = ucKasaDemo1.Enabled = false;
            }
            else
            {
                ucBankaDemo1.Enabled = ucKasaDemo1.Enabled = true;
            }
        }

        private void GridViewParcaIscilikler_Click(object sender, EventArgs e)
        {
            if (GridViewParcaIscilikler.RowCount == 1)
                Focus();
        }
        private void GridViewParcaIscilikler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }
        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            Yeni();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }

        private void GridViewParcaIscilikler_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value == null) return;

            if (e.Column == colParcaNo)
            {
                string temp_ParcaNo = e.Value.ToString();
                var tempKart = (from abc in dbModel.stok_kart
                                where abc.ParcaNo == temp_ParcaNo && abc.SirketID == Genel.AktifSirket.SirketID
                                select new
                                {
                                    abc.KartID,
                                    abc.KalemAdi,
                                    abc.StokBirim,
                                    abc.SatisFiyat,
                                    abc.Kdv
                                }).SingleOrDefault();
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colKartID, tempKart.KartID);
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colKalemIscilikAdi, tempKart.KalemAdi);
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colBirim, tempKart.StokBirim);
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colFiyat, tempKart.SatisFiyat);
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colKdv, tempKart.Kdv);
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colDepoAd, Genel.AktifDepo.DepoID);

                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colIscilikTip, null);
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colMiktar, 1);
            }
            else if (e.Column == colIscilikID)
            {
                int tempIscilikID = Convert.ToInt32(e.Value);

                var tempIscilik = (from abc in dbModel.isciliks
                                   where abc.IscilikID == tempIscilikID
                                   select new
                                   {
                                       abc.IscilikAd,
                                       abc.IscilikTip,
                                       abc.KacSaat
                                   }).SingleOrDefault();

                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colKalemIscilikAdi, tempIscilik.IscilikAd);
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colBirim, -1);
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colKdv, 18);
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colMiktar, tempIscilik.KacSaat);
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colIscilikTip, tempIscilik.IscilikTip);

                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colFiyat, tempIscilik.IscilikTip == "1" ? Genel.IscilikAgir :
                    tempIscilik.IscilikTip == "2" ? Genel.IscilikOrta :
                    tempIscilik.IscilikTip == "3" ? Genel.IscilikHafif : 1);
            }
        }
        private void GridViewParcaIscilikler_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (_Yukleme == false && (e.Column == colNetTutar || e.Column == colIndirim))
                Hesapla_GenelToplam();

            if ((e.Column == colMiktar || e.Column == colFiyat) &&
              (GridViewParcaIscilikler.GetRowCellValue(e.RowHandle, colMiktar) != DBNull.Value) &&
              (GridViewParcaIscilikler.GetRowCellValue(e.RowHandle, colFiyat) != DBNull.Value))
            {
                GridViewParcaIscilikler.SetRowCellValue(e.RowHandle, colNetTutar,
                    Convert.ToDecimal(GridViewParcaIscilikler.GetRowCellValue(e.RowHandle, colMiktar)) *
                    Convert.ToDecimal(GridViewParcaIscilikler.GetRowCellValue(e.RowHandle, colFiyat)));
            }
        }

        private void GridViewParcaIscilikler_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (GridViewParcaIscilikler.FocusedColumn == colIscilikID && GridViewParcaIscilikler.GetFocusedRowCellValue(colTip) != DBNull.Value && Convert.ToInt32(GridViewParcaIscilikler.GetFocusedRowCellValue(colTip)) == 0)
                e.Cancel = true;

            if (GridViewParcaIscilikler.FocusedColumn == colParcaNo && GridViewParcaIscilikler.GetFocusedRowCellValue(colTip) != DBNull.Value && Convert.ToInt32(GridViewParcaIscilikler.GetFocusedRowCellValue(colTip)) == 1)
                e.Cancel = true;

            if (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi && radioFaturaKaynak.SelectedIndex == 1 &&
               (GridViewParcaIscilikler.FocusedColumn == colTip || GridViewParcaIscilikler.FocusedColumn == colParcaNo ||
              GridViewParcaIscilikler.FocusedColumn == colIscilikID || GridViewParcaIscilikler.FocusedColumn == colMiktar ||
              GridViewParcaIscilikler.FocusedColumn == colDepoAd)) e.Cancel = true;

            if (FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi && GridViewParcaIscilikler.FocusedColumn == colTip)
                e.Cancel = true;
        }

        private void chkKdvli_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKdvli.Checked)
                chkKdvli.Text = "Dahil";
            else
                chkKdvli.Text = "Hariç";
        }

        public void DetayOlayi(Enumlar.DetayOlaylari Olay, Sistem.DetayArgumanlari Arg)
        {
            if (Olay == Enumlar.DetayOlaylari.AramaGerekli)
            {
                Ara_FaturaElemanlari(null, ucIsemriDemo1.Secili_IsemirID);
                ucCariHesapDemo1.Yukle_Cari(ucIsemriDemo1.Secili_CariID);
                Hesapla_GenelToplam();
            }
        }

        void dt_FaturaElemanlari_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                dt_FaturaElemanlari.Rows.Remove(e.Row);
            }
            catch { }
        }

        private void chkTevfikatVar_CheckedChanged(object sender, EventArgs e)
        {
            spinCarpan1.Enabled = spinCarpan2.Enabled = chkTevfikatVar.Checked;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Hesapla_GenelToplam();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (_ft == null || GridViewParcaIscilikler.GetFocusedRow() == null) return;

            //decimal t_Tutar = 0;

            Hesapla_GenelToplam();
            for (int i = 0; i < dt_FaturaElemanlari.Rows.Count; i++)
            {
                dt_FaturaElemanlari.Rows[i]["NetTutar"] = Math.Round(Convert.ToDecimal(dt_FaturaElemanlari.Rows[i]["NetTutar"]), 2);
            }

            rptSatisFaturasi Cikti = new rptSatisFaturasi();
            if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis)
            {
                Cikti.lblKdvTutari.Visible = Cikti.lblKdvTutariCaption.Visible = false;
            }
            Cikti.lblKdvTutariCaption.Text = "Kdv Tutarı %" + spinKdvYuzde.Value.ToString() + " :";
            //Cikti.PageHeight = 2310;
           
            Cikti.PrinterName = Sistem.Ayarlar.YaziciA4;
            Cikti.Yukle(dt_FaturaElemanlari);
            Cikti.lblCariID.Text = ucCariHesapDemo1.Secili_CariID.ToString();
            Cikti.lblTcKimlik.Text = ucCariHesapDemo1.cari.TcKimlikNo;
            Cikti.lblUnvan.Text = ucCariHesapDemo1.cari.Unvan;
            Cikti.lblVergiDairesi.Text = ucCariHesapDemo1.cari.VergiDairesi;
            Cikti.lblAdres.Text = ucCariHesapDemo1.cari.AdresAcik + Environment.NewLine;
            if (ucCariHesapDemo1.cari.AdresIlce != null)
            {
                Cikti.lblAdres.Text += Isler.Adres.Ver_IlceAd(ucCariHesapDemo1.cari.AdresIlce.Value) + " / ";
            }
            if (ucCariHesapDemo1.cari.AdresIl != null)
            {
                Cikti.lblAdres.Text += Isler.Adres.Ver_IlAd(ucCariHesapDemo1.cari.AdresIl.Value);
            }

            Cikti.lblParcaToplam.Text = ParcaToplam.ToString();
            Cikti.lblParcaIndirim.Text = ParcaIndirimi.ToString();
            Cikti.lblParcaNetTutar.Text = ParcaNetTutar.ToString();
            Cikti.lblIscilikToplam.Text = IscilikToplam.ToString();
            Cikti.lblIscilikIndirim.Text = IscilikIndirimi.ToString();
            Cikti.lblIscilikNetTutar.Text = IscilikNetTutar.ToString();

            Cikti.lblToplamTutar.Text = ToplamTutar.ToString();
            Cikti.lblIndirimTutari.Text = IndirimTutari.ToString();
            Cikti.lblIndirimliTutar.Text = IndirimliTutar.ToString();
            Cikti.lblKdvTutari.Text = KdvTutari.ToString();

            Cikti.lblNetTutar.Text = NetTutar.ToString();
            Cikti.lblYazi.Text = Araclar.Para.YaziyaCevir(NetTutar);

            if (_ft.TevfikatVar)
            {
                Cikti.lblTevfikatOran.Text = _ft.TevCarpan1.Value.ToString() + "/" + _ft.TevCarpan2.Value.ToString();
                Cikti.lblTevfikatTutar.Text = Tevfikati.ToString();
                Cikti.lblTevfikatTutar.Visible = Cikti.lblTevfikatTutarCaption.Visible = Cikti.lblTevfikatOran.Visible
                = Cikti.lblTevfikatOranCaption.Visible = true;
            }

            if (_ft.VadeTarih != null)
            {
                Cikti.lblVadeTarih.Text = _ft.VadeTarih.Value.ToString("dd.MM.yyyy");
                Cikti.lblVadeTarih.Visible = Cikti.lblVadeTarihCaption.Visible = true;
            }

            if (_ft.FaturaKaynak == "2")
            {
                var srv = (from abc in dbModel.servis
                           where abc.ServisID == ucIsemriDemo1.ism.ServisID
                           join a in dbModel.aracs on abc.AracID equals a.AracID
                           select new
                           {
                               abc.ServisID,
                               abc.Km,
                               abc.AracID,
                               a.Plaka,
                               a.MarkaID,
                               a.ModelID,
                               a.SaseNo
                           }).FirstOrDefault();

                Cikti.lblPlaka.Text = srv.Plaka;
                Cikti.lblServisID.Text = srv.ServisID.ToString() + " / " + ucIsemriDemo1.Secili_IsemirID.ToString();
                if (srv.Km.HasValue)
                {
                    Cikti.lblAracKM.Text = srv.Km.Value.ToString();
                }
                Cikti.lblSasiNo.Text = srv.SaseNo;
                Cikti.lblMarkaModel.Text = Isler.MarkaModel.Ver_MarkaAd(srv.MarkaID) + " " + Isler.MarkaModel.Ver_ModelAd(srv.ModelID);
            }
            else if(_ft.FaturaKaynak=="1")
            {
                Cikti.lblPlaka.Visible = Cikti.lblPlakaCaption.Visible = Cikti.lblServisIDCaption.Visible = Cikti.lblServisID.Visible
                = Cikti.lblAracKM.Visible = Cikti.lblAracKMCaption.Visible = Cikti.lblMarkaModel.Visible = Cikti.lblMarkaModelCaption.Visible
                = false;
            }
            else if (_ft.FaturaKaynak == "3")
            {
                var srv = (from abc in dbModel.aracs
                           where abc.AracID==_ft.AracID.Value
                           select new
                           {
                               abc.AracID,
                               abc.Plaka,
                               abc.MarkaID,
                               abc.ModelID,
                               abc.SaseNo
                           }).FirstOrDefault();

                Cikti.lblPlaka.Text = srv.Plaka;
                Cikti.lblSasiNo.Text = srv.SaseNo;
                Cikti.lblMarkaModel.Text = Isler.MarkaModel.Ver_MarkaAd(srv.MarkaID) + " " + Isler.MarkaModel.Ver_ModelAd(srv.ModelID);
            }

            Cikti.lblFaturaNo.Text = _ft.FaturaID.ToString();
            Cikti.lblSevkTarih.Text = Cikti.lblFaturaTarih.Text = _ft.FaturaTarih.ToString("dd.MM.yyyy");
            //var arc=(from abc in dbModel.aracs
            //         where abc.AracID==
            //Cikti.lblPlaka.Text=

            Cikti.ShowPreview();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ara_Iscilikler(true);
            Ara_StokKartlari(true);
            Ara_Araclar(true);
        }

        private void GridViewParcaIscilikler_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && (radioFaturaKaynak.SelectedIndex == 0 || radioFaturaKaynak.SelectedIndex == 2) && FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi)
            {
                GridViewParcaIscilikler.AddNewRow();
            }
            if (e.KeyCode == Keys.Enter && (FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis))
            {
                DataRow dr = dt_FaturaElemanlari.NewRow();
                dr["IscilikMi"] = 0;
                dt_FaturaElemanlari.Rows.Add(dr);
            }
            if (e.KeyCode == Keys.Delete && (radioFaturaKaynak.SelectedIndex == 0 || radioFaturaKaynak.SelectedIndex == 2 || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi))
            {
                GridViewParcaIscilikler.DeleteSelectedRows();
            }
        }

        private void btnAracSec_Click(object sender, EventArgs e)
        {
            using (AracKabul.frmAracSec AracSec = new AracKabul.frmAracSec())
            {
                if (AracSec.ShowDialog() == DialogResult.OK)
                {
                    txtAracPlaka.Text = AracSec.Plaka;
                    txtAracPlaka.Tag = AracSec.AracID;
                }
            }
        }
        #endregion

        #region < Metod >
        public void Yukle_Fatura(int _FaturaID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_Fatura();
                _YeniKayit = false;

                if (_ft != null && _ft.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(_ft);
                }
                _ft = null;
                _ft = Isler.Fatura.Ver_Fatura(ref dbModel, _FaturaID);
                if (_ft == null) return;

                _Secili_FaturaID = _ft.FaturaID;
                lblFaturaID.Text = _Secili_FaturaID.ToString();
                chkKdvli.Checked = _ft.Kdvli;
                dateVadeTarih.EditValue = _ft.VadeTarih;
                memoAciklama.Text = _ft.Aciklama;
                spinSiraNo.Value = _ft.SiraNo;
                dateFaturaTarih.EditValue = _ft.FaturaTarih;

                if (_ft.AcikFatura)
                    radioFaturaTip.SelectedIndex = 0;
                else
                    radioFaturaTip.SelectedIndex = 1;

                if (_ft.FaturaKaynak == "1")
                {
                    radioFaturaKaynak.SelectedIndex = 0;
                }
                else if (_ft.FaturaKaynak == "2")
                {
                    radioFaturaKaynak.SelectedIndex = 1;
                }
                else if (_ft.FaturaKaynak == "3")
                {
                    radioFaturaKaynak.SelectedIndex = 2;
                }
                if (_ft.KasaID != null)
                {
                    ucKasaDemo1.Yukle_Kasa(_ft.KasaID.Value);
                }
                if (_ft.BankaID != null)
                {
                    ucBankaDemo1.Yukle_Banka(_ft.BankaID.Value);
                }
                if (_ft.IsemirID != null)
                {
                    ucIsemriDemo1.Yukle_Isemri(_ft.IsemirID.Value);
                    dateIsemriBitisTarih.EditValue = ucIsemriDemo1.ism.BitisTarih;
                }
                if (_ft.AracID != null)
                {
                    txtAracPlaka.Tag = _ft.AracID.Value;
                    txtAracPlaka.Text = Isler.Arac.Ver_Plaka(_ft.AracID.Value);
                }

                chkTevfikatVar.Checked = _ft.TevfikatVar;

                if (_ft.TevCarpan1 != null)
                {
                    spinCarpan1.Value = _ft.TevCarpan1.Value;
                }
                if (_ft.TevCarpan2 != null)
                {
                    spinCarpan2.Value = _ft.TevCarpan2.Value;
                }

                ucKayitBilgi1.Yukle(_ft.KayitKullaniciID, _ft.KayitZaman, _ft.DuzenKullaniciID, _ft.DuzenZaman);

                Ara_FaturaElemanlari(_ft.FaturaID, null);

                Hesapla_GenelToplam();

                ucIsemriDemo1.Enabled = radioFaturaKaynak.Enabled = false;
                btnYazdir.Enabled = true;

                ucCariHesapDemo1.Yukle_Cari(_ft.CariID);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Fatura Getirilken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Ara_FaturaElemanlari(int? _FaturaID, int? IsemirID)
        {
            try
            {
                _Yukleme = true;

                if (dt_FaturaElemanlari != null)
                    dt_FaturaElemanlari.Dispose();

                dt_FaturaElemanlari = null;
                dt_FaturaElemanlari = Isler.Fatura.Ver_FaturaElemanlari(_FaturaID, IsemirID);

                dt_FaturaElemanlari.RowDeleted += new DataRowChangeEventHandler(dt_FaturaElemanlari_RowDeleted);

                if (dt_FaturaElemanlari != null && dt_FaturaElemanlari.Rows.Count > 0)
                {
                    spinKdvYuzde.Value = Convert.ToDecimal(dt_FaturaElemanlari.Rows[0]["Kdv"]);
                }

                //if (L_ih != null && L_ih.Count > 0)
                //{
                //    foreach (iscilik_hareket item in L_ih)
                //    {
                //        if (item.EntityState != EntityState.Detached)
                //        {
                //            dbModel.Detach(item);
                //        }
                //    }
                //    L_ih.Clear();
                //}
                //if (L_sh != null && L_sh.Count > 0)
                //{
                //    foreach (stok_hareket item in L_sh)
                //    {
                //        if (item.EntityState != EntityState.Detached)
                //        {
                //            dbModel.Detach(item);
                //        }
                //    }
                //    L_sh.Clear();
                //}

                //int temp_ID;
                //bool temp_iscilikMi;
                //for (int i = 0; i < dt_FaturaElemanlari.Rows.Count; i++)
                //{
                //    temp_ID = Convert.ToInt32(dt_FaturaElemanlari.Rows[i]["ID"]);
                //    temp_iscilikMi = Convert.ToBoolean(dt_FaturaElemanlari.Rows[i]["IscilikMi"]);

                //    if (temp_iscilikMi)
                //    {
                //        L_ih.Add(Isler.Iscilik.Ver_IscilikHareket(ref dbModel, temp_ID));
                //    }
                //    else
                //    {
                //        L_sh.Add(Isler.Stok.Ver_StokHareket(ref dbModel, temp_ID));
                //    }
                //}

                gridControlParcaIscilikler.DataSource = dt_FaturaElemanlari;
                GridViewParcaIscilikler.ViewCaption = "Parça ve İşçilikler Listesi (" + dt_FaturaElemanlari.Rows.Count.ToString() + ")";
            }
            catch (Exception hata)
            {

                throw;
            }
            finally
            {
                _Yukleme = false;
            }
        }

        void Ara_StokKartlari(bool Yeniden)
        {
            try
            {
                if (Yeniden || Genel.dt_StokKartlarSecim == null)
                {
                    if (Genel.dt_StokKartlarSecim != null)
                        Genel.dt_StokKartlarSecim.Dispose();
                    Genel.dt_StokKartlarSecim = null;
                    Genel.dt_StokKartlarSecim = Isler.Stok.Ver_StokKartlari(true);
                }

                if (dt_StokKartlar != null)
                    dt_StokKartlar.Dispose();
                dt_StokKartlar = null;
                dt_StokKartlar = Genel.dt_StokKartlarSecim.Copy();
                reGridLookStokKartlari.DataSource = dt_StokKartlar;
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Ara_Iscilikler(bool Yeniden)
        {
            try
            {
                if (Yeniden || Genel.dt_IsciliklerSecim == null)
                {
                    if (Genel.dt_IsciliklerSecim != null)
                        Genel.dt_IsciliklerSecim.Dispose();
                    Genel.dt_IsciliklerSecim = null;
                    Genel.dt_IsciliklerSecim = Isler.Iscilik.Ver_Iscilikler(true);
                }

                if (dt_Iscilikler != null)
                    dt_Iscilikler.Dispose();
                dt_Iscilikler = null;
                dt_Iscilikler = Genel.dt_IsciliklerSecim.Copy();
                reGridLookUpIscilikler.DataSource = dt_Iscilikler;
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Ara_Araclar(bool Yeniden)
        {
            if (Yeniden || Genel.dt_Araclar == null)
            {
                Genel.dt_Araclar = null;
                Genel.dt_Araclar = Isler.Arac.Ver_Araclar();
            }

            if (dt_Araclar != null)
                dt_Araclar.Dispose();
            dt_Araclar = null;
            dt_Araclar = Genel.dt_Araclar.Copy();

            reGridLookAraclar.DataSource = dt_Araclar;
        }

        void Kaydet()
        {
            if (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi && (_YeniKayit && !Isler.Yetki.Varmi_Yetki(56)) || !_YeniKayit && !Isler.Yetki.Varmi_Yetki(57)) return;
            if (FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi && (_YeniKayit && !Isler.Yetki.Varmi_Yetki(60)) || !_YeniKayit && !Isler.Yetki.Varmi_Yetki(61)) return;
            if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis && (_YeniKayit && !Isler.Yetki.Varmi_Yetki(68)) || !_YeniKayit && !Isler.Yetki.Varmi_Yetki(68)) return;
            if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis && (_YeniKayit && !Isler.Yetki.Varmi_Yetki(64)) || !_YeniKayit && !Isler.Yetki.Varmi_Yetki(65)) return;

            try
            {
                #region < Kontroller >
                if (radioFaturaTip.SelectedIndex == 1 && ucKasaDemo1.Secili_KasaID <= 0 && ucBankaDemo1.Secili_BankaID <= 0)
                {
                    XtraMessageBox.Show("Lütfen Faturanın Aktarılacağı Kasayı veya Bankayı Seçiniz.", "Kasa Seçilmedi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucKasaDemo1.Focus(); ucKasaDemo1.Select();
                    return;
                }
                if (radioFaturaTip.SelectedIndex == 1 && ucKasaDemo1.Secili_KasaID > 0 && ucBankaDemo1.Secili_BankaID > 0)
                {
                    XtraMessageBox.Show("Hem Banka Hem de Kasa Seçilemez.", "Geçersiz İşlem",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if ((FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis) && radioFaturaKaynak.SelectedIndex == 1 && ucIsemriDemo1.Secili_IsemirID <= 0)
                {
                    XtraMessageBox.Show("Lütfen Faturanın İlişkilendirileceği İşemrini Seçiniz.", "İşemri Seçilmedi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucIsemriDemo1.Focus(); ucIsemriDemo1.Select();
                    return;
                }
                if (ucCariHesapDemo1.Secili_CariID <= 0)
                {
                    XtraMessageBox.Show("Lütfen Faturanın İlişkilendirileceği Cariyi Seçiniz.", "Cari Seçilmedi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucCariHesapDemo1.Focus(); ucCariHesapDemo1.Select();
                    return;
                }
                if (dateFaturaTarih.EditValue == null)
                {
                    XtraMessageBox.Show("Lütfen Faturanın Tarihini Giriniz.", "Eksik Alan",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateFaturaTarih.Focus(); dateFaturaTarih.Select();
                    return;
                }
                if (radioFaturaKaynak.SelectedIndex == 2 && txtAracPlaka.Tag == null && (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis))
                {
                    XtraMessageBox.Show("Lütfen Faturanın Kesileceği Aracı Seçiniz Giriniz.", "Eksik Alan",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAracPlaka.Focus(); txtAracPlaka.Select();
                    return;
                }
                if ((FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi) && (spinSiraNo.EditValue == null || spinSiraNo.Value <= 0))
                {
                    XtraMessageBox.Show("Sıra Nosu 0'dan Büyük Bir Sayı Olmalıdır.", "Geçersiz Değer",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    spinSiraNo.Focus(); spinSiraNo.Select();
                    return;
                }
                if (radioFaturaKaynak.SelectedIndex==1&& (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis) && dateIsemriBitisTarih.EditValue == null)
                {
                    XtraMessageBox.Show("Lütfen İşemri Bitiş Tarihini Giriniz.", "Geçersiz Değer",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateIsemriBitisTarih.Focus(); dateIsemriBitisTarih.Select();
                    return;
                }
                int t_kartno = 0;
                string t_kalemAdi = "";
                bool t_IscilikMi = false;

                for (int i = 0; i < dt_FaturaElemanlari.Rows.Count; i++)
                {
                    t_IscilikMi = Convert.ToBoolean(dt_FaturaElemanlari.Rows[i]["IscilikMi"]);
                    if (!t_IscilikMi)
                    {
                        t_kartno = Convert.ToInt32(dt_FaturaElemanlari.Rows[i]["KartID"]);
                        t_kalemAdi = dt_FaturaElemanlari.Rows[i]["KalemIscilikAdi"].ToString();
                        if (dt_FaturaElemanlari.Rows[i]["DepoID"] == DBNull.Value)
                        {
                            XtraMessageBox.Show("Aşağıda Bilgileri Verilen Stok Kaleminin Çıkacağı Depo Seçilmemiş.\n\n"
                                                + "Kart No : " + t_kartno.ToString()
                                                + "\nKalem Adı : " + t_kalemAdi, "Depo Seçilmedi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if ((FaturaTipi==Enumlar.FaturaTipleri.FaturasizSatis||FaturaTipi==Enumlar.FaturaTipleri.SatisFaturasi)&&  dt_FaturaElemanlari.Rows[i]["ID"] == DBNull.Value && Isler.Stok.StokAdet(t_kartno, (int)dt_FaturaElemanlari.Rows[i]["DepoID"]) <= 0)
                        {
                            XtraMessageBox.Show("Aşağıda Bilgileri Verilen Stok Kalemi Seçilen Depoda Bulunmamaktadır.\n\n"
                                                + "Kart No : " + t_kartno.ToString()
                                                + "\nKalem Adı : " + t_kalemAdi, "Depo Seçilmedi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi &&
                            dt_FaturaElemanlari.Rows[i]["IndirimYuzde"] == DBNull.Value && ((dt_FaturaElemanlari.Rows[i]["IndirimYuzde2"] != DBNull.Value || dt_FaturaElemanlari.Rows[i]["IndirimYuzde3"] != DBNull.Value))
                            && (dt_FaturaElemanlari.Rows[i]["IndirimYuzde2"] == DBNull.Value && dt_FaturaElemanlari.Rows[i]["IndirimYuzde3"] != DBNull.Value))
                        {
                            XtraMessageBox.Show("Aşağıda Bilgileri Verilen Stok Kaleminin İndirim Yüzdelerini Kontrol Ediniz.\n\n"
                                                 + "Kart No : " + t_kartno.ToString()
                                                 + "\nKalem Adı : " + t_kalemAdi, "Depo Seçilmedi",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                #endregion

                Hesapla_GenelToplam();

                if (_YeniKayit)
                {
                    if (_ft != null && _ft.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(_ft);
                    }
                    _ft = null;
                    _ft = new fatura();
                    _ft.SirketID = Genel.AktifSirket.SirketID;
                    _ft.FaturaTip = ((int)FaturaTipi).ToString();
                }

                #region Aktarma
                _ft.Aciklama = memoAciklama.Text;
                _ft.Kdvli = chkKdvli.Checked;
                _ft.CariID = ucCariHesapDemo1.Secili_CariID;
                if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis || FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis)
                {
                    _ft.SiraNo = 0;
                }
                else
                {
                    _ft.SiraNo = Convert.ToInt32(spinSiraNo.Value);
                }
                _ft.FaturaTarih = dateFaturaTarih.DateTime;
                if (dateVadeTarih.EditValue == null)
                {
                    _ft.VadeTarih = null;
                }
                else
                {
                    _ft.VadeTarih = Convert.ToDateTime(dateVadeTarih.EditValue);
                }
                if (FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis)
                {
                    _ft.FaturaKaynak = null;
                    _ft.IsemirID = null;
                }
                else if (radioFaturaKaynak.SelectedIndex == 0)
                {
                    _ft.FaturaKaynak = "1";
                    _ft.IsemirID = _ft.AracID = null;
                }
                else if (radioFaturaKaynak.SelectedIndex == 1)
                {
                    _ft.AracID = null;
                    _ft.FaturaKaynak = "2";
                    _ft.IsemirID = ucIsemriDemo1.Secili_IsemirID;
                }
                else if (radioFaturaKaynak.SelectedIndex == 2)
                {
                    _ft.IsemirID = null;
                    _ft.FaturaKaynak = "3";
                    _ft.AracID = Convert.ToInt32(txtAracPlaka.Tag);
                }

                if (radioFaturaTip.SelectedIndex == 0)
                {
                    _ft.AcikFatura = true;
                    _ft.KasaID = null;
                }
                else
                {
                    _ft.AcikFatura = false;

                    if (ucBankaDemo1.Secili_BankaID <= 0)
                    {
                        _ft.BankaID = null;
                    }
                    else
                    {
                        _ft.BankaID = ucBankaDemo1.Secili_BankaID;
                    }

                    if (ucKasaDemo1.Secili_KasaID <= 0)
                    {
                        _ft.KasaID = null;
                    }
                    else
                    {
                        _ft.KasaID = ucKasaDemo1.Secili_KasaID;
                    }
                }

                if (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi||FaturaTipi==Enumlar.FaturaTipleri.AlisFaturasi)
                {
                    _ft.TevfikatVar = chkTevfikatVar.Checked;
                }
                else
                {
                    _ft.TevfikatVar = false;
                }

                if (chkTevfikatVar.Checked && (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi||FaturaTipi==Enumlar.FaturaTipleri.AlisFaturasi))
                {
                    _ft.TevCarpan1 = Convert.ToSByte(spinCarpan1.Value);
                    _ft.TevCarpan2 = Convert.ToSByte(spinCarpan2.Value);
                }
                else
                {
                    _ft.TevCarpan1 = _ft.TevCarpan2 = null;
                }
                #endregion

                #region Kayıt
                if (_YeniKayit)
                {
                    _ft.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    _ft.KayitZaman = DateTime.Now;
                    dbModel.AddTofaturas(_ft);
                    dbModel.SaveChanges();
                }
                else
                {
                    _ft.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    _ft.DuzenZaman = DateTime.Now;
                    dbModel.SaveChanges();
                }

                Isler.Fatura.Sil_FaturaKasaHareket(_ft.FaturaID);
                Isler.Fatura.Sil_FaturaBankaHareket(_ft.FaturaID);
                Isler.Fatura.Sil_FaturaCariHareket(_ft.FaturaID);

                int? t_BankaHareketID = null;
                int? t_KasaHareketID = null;

                if (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi)
                {
                    Isler.Cari.Ekle_CariHareket(ucCariHesapDemo1.Secili_CariID, NetTutar, true,
                        Enumlar.IslemTurleri.SatisFaturasi, _ft.FaturaID, null, null,
                        FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi ? spinSiraNo.Value.ToString() : null,
                        memoAciklama.Text,_ft.FaturaTarih);
                }
                else if (FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi)
                {
                    Isler.Cari.Ekle_CariHareket(ucCariHesapDemo1.Secili_CariID, NetTutar, false,
                          Enumlar.IslemTurleri.AlisFaturasi, _ft.FaturaID, null, null,
                          FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi ? spinSiraNo.Value.ToString() : null,
                          memoAciklama.Text, _ft.FaturaTarih);
                }
                else if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis)
                {
                    Isler.Cari.Ekle_CariHareket(ucCariHesapDemo1.Secili_CariID, NetTutar, false, Enumlar.IslemTurleri.FaturasizAlis,
                        _ft.FaturaID, null, null,
                        FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi ? spinSiraNo.Value.ToString() : null, memoAciklama.Text, _ft.FaturaTarih);
                }
                else if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis)
                {
                    Isler.Cari.Ekle_CariHareket(ucCariHesapDemo1.Secili_CariID, NetTutar, true, Enumlar.IslemTurleri.FaturasizSatis,
                        _ft.FaturaID, null, null,
                        FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi ? spinSiraNo.Value.ToString():null,
                          memoAciklama.Text, _ft.FaturaTarih);
                }

                if (radioFaturaTip.SelectedIndex == 1 && ucKasaDemo1.Secili_KasaID > 0)
                {
                    t_KasaHareketID = Isler.Kasa.Ekle_KasaHareket(ucKasaDemo1.Secili_KasaID, NetTutar,
                           FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis ? true : false
                           , FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis ? Enumlar.IslemTurleri.KasaTahsilatFisi : Enumlar.IslemTurleri.KasaOdemeFisi,
                           ucCariHesapDemo1.Secili_CariID, null, null, _ft.FaturaID, null,
                           FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi ? spinSiraNo.Value.ToString() : null,
                           memoAciklama.Text, _ft.FaturaTarih);

                    Isler.Cari.Ekle_CariHareket(ucCariHesapDemo1.Secili_CariID, NetTutar,
                        FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis ? false : true,
                        FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis ? Enumlar.IslemTurleri.KasaTahsilatFisi : Enumlar.IslemTurleri.KasaOdemeFisi,
                        _ft.FaturaID, null, ucKasaDemo1.Secili_KasaID,
                         FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi ? spinSiraNo.Value.ToString() : null,
                         memoAciklama.Text, _ft.FaturaTarih, null, t_KasaHareketID);
                }
                else if (radioFaturaTip.SelectedIndex == 1 && ucBankaDemo1.Secili_BankaID > 0)
                {
                  t_BankaHareketID=  Isler.Banka.Ekle_BankaHareket(ucBankaDemo1.Secili_BankaID, NetTutar,
                        FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis ? true : false
                        , FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis ? Enumlar.IslemTurleri.GelenHavale : Enumlar.IslemTurleri.GidenHavale,
                        null, null,ucCariHesapDemo1.Secili_CariID, _ft.FaturaID, null,
                        FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi ? spinSiraNo.Value.ToString() : null,
                        memoAciklama.Text,_ft.FaturaTarih);

                    Isler.Cari.Ekle_CariHareket(ucCariHesapDemo1.Secili_CariID, NetTutar,
                        FaturaTipi==Enumlar.FaturaTipleri.SatisFaturasi||FaturaTipi==Enumlar.FaturaTipleri.FaturasizSatis? false :true,
                        FaturaTipi==Enumlar.FaturaTipleri.SatisFaturasi||FaturaTipi==Enumlar.FaturaTipleri.FaturasizSatis? Enumlar.IslemTurleri.GelenHavale:Enumlar.IslemTurleri.GidenHavale, _ft.FaturaID,
                        ucBankaDemo1.Secili_BankaID, null, spinSiraNo.Value.ToString(), memoAciklama.Text, _ft.FaturaTarih, t_BankaHareketID, null);
                }

                _Secili_FaturaID = _ft.FaturaID;
                lblFaturaID.Text = _Secili_FaturaID.ToString();
                _YeniKayit = false;

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Fatura Başarılı Bir Şekilde Kaydedilmiştir.", null,
                  ResOtoSis.mark_blue);
                #endregion

                #region İşemri Kaydı
                if ((radioFaturaKaynak.SelectedIndex == 1) && (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis))
                {
                    ////isemri temp_ism = Isler.Servis.Ver_Isemri(ref dbModel, ucIsemriDemo1.Secili_IsemirID);
                    //dbModel.Attach(ucIsemriDemo1.ism);
                    //ucIsemriDemo1.ism.FaturaID = _ft.FaturaID;
                    //ucIsemriDemo1.ism.IsemriKapatma = ((int)Enumlar.IsemriKapatmalari.Faturalandirildi).ToString();
                    //ucIsemriDemo1.ism.BitisTarih = dateIsemriBitisTarih.DateTime;
                    //dbModel.SaveChanges();
                    //dbModel.Detach(ucIsemriDemo1.ism);
                    ////temp_ism = null;
                    Isler.Servis.Guncelle_IsemriFatura(ucIsemriDemo1.Secili_IsemirID, _ft.FaturaID, Enumlar.IsemriKapatmalari.Faturalandirildi, dateIsemriBitisTarih.DateTime);
                }
                #endregion

                #region Hareketler
                int temp_ID;
                bool temp_IscilikMi;

                int temp_IscilikID = 0;
                int temp_KartID = 0;
                //sbyte temp_Kdv; //Gerek yok; ekrandaki kdv oranı alınmalı herzaman.

                decimal temp_BirimFiyat = 0;
                decimal temp_Miktar;
                string temp_ParcaNo="";

                decimal? temp_Indirim = null;
                decimal? temp_Indirim2 = null;
                decimal? temp_Indirim3 = null;
                int? temp_DepoID = null;
                int? temp_AracID = null;

                string temp_IscilikTip = null;

                iscilik_hareket temp_ih = null;
                stok_hareket temp_sh = null;

                bool temp_YeniKayit = false;

                List<int> temp_List_shID = new List<int>();
                List<int> temp_List_ihID = new List<int>();
                for (int i = 0; i < dt_FaturaElemanlari.Rows.Count; i++)
                {
                    temp_IscilikMi = Convert.ToBoolean(dt_FaturaElemanlari.Rows[i]["IscilikMi"]);
                    temp_BirimFiyat = Convert.ToDecimal(dt_FaturaElemanlari.Rows[i]["BirimFiyat"]);
                    temp_Miktar = Convert.ToDecimal(dt_FaturaElemanlari.Rows[i]["Miktar"]);
                    //temp_Kdv = Convert.ToSByte(dt_FaturaElemanlari.Rows[i]["Kdv"]);

                    if (dt_FaturaElemanlari.Rows[i]["IndirimYuzde"] == DBNull.Value)
                    {
                        temp_Indirim = null;
                    }
                    else
                    {
                        temp_Indirim = Convert.ToDecimal(dt_FaturaElemanlari.Rows[i]["IndirimYuzde"]);
                    }
                    if (dt_FaturaElemanlari.Rows[i]["IndirimYuzde2"] == DBNull.Value)
                    {
                        temp_Indirim2 = null;
                    }
                    else
                    {
                        temp_Indirim2 = Convert.ToDecimal(dt_FaturaElemanlari.Rows[i]["IndirimYuzde2"]);
                    }
                    if (dt_FaturaElemanlari.Rows[i]["IndirimYuzde3"] == DBNull.Value)
                    {
                        temp_Indirim3 = null;
                    }
                    else
                    {
                        temp_Indirim3 = Convert.ToDecimal(dt_FaturaElemanlari.Rows[i]["IndirimYuzde3"]);
                    }
                    if (dt_FaturaElemanlari.Rows[i]["AracID"] == DBNull.Value)
                    {
                        temp_AracID = null;
                    }
                    else
                    {
                        temp_AracID = Convert.ToInt32(dt_FaturaElemanlari.Rows[i]["AracID"]);
                    }

                    if (temp_IscilikMi)
                    {
                        temp_IscilikID = Convert.ToInt32(dt_FaturaElemanlari.Rows[i]["IscilikID"]);
                        temp_IscilikTip = dt_FaturaElemanlari.Rows[i]["IscilikTip"].ToString();

                        temp_ParcaNo = null;
                    }
                    else
                    {
                        temp_KartID = Convert.ToInt32(dt_FaturaElemanlari.Rows[i]["KartID"]);
                        temp_DepoID = Convert.ToInt32(dt_FaturaElemanlari.Rows[i]["DepoID"]);
                        temp_ParcaNo = dt_FaturaElemanlari.Rows[i]["ParcaNo"].ToString();
                    }

                    if (dt_FaturaElemanlari.Rows[i]["ID"] == DBNull.Value)//Yeni Kayıt ve kesinlikle iş emri değildir; bağımsız faturadır.
                    {
                        temp_YeniKayit = true;
                    }
                    else
                    {
                        temp_YeniKayit = false;
                    }


                    if (temp_YeniKayit)
                    {
                        if (temp_IscilikMi)
                        {
                            temp_ih = new iscilik_hareket();
                            temp_ih.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                            temp_ih.KayitZaman = DateTime.Now;
                        }
                        else
                        {
                            temp_sh = new stok_hareket();
                            temp_sh.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                            temp_sh.KayitZaman = DateTime.Now;
                        }
                    }
                    else
                    {
                        temp_ID = Convert.ToInt32(dt_FaturaElemanlari.Rows[i]["ID"]);
                        if (temp_IscilikMi)
                        {
                            temp_ih = Isler.Iscilik.Ver_IscilikHareket(ref dbModel, temp_ID);
                            temp_ih.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                            temp_ih.DuzenZaman = DateTime.Now;
                        }
                        else
                        {
                            temp_sh = Isler.Stok.Ver_StokHareket(ref dbModel, temp_ID);
                            temp_sh.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                            temp_sh.DuzenZaman = DateTime.Now;
                        }
                    }

                    if (temp_IscilikMi)
                    {
                        temp_ih.IscilikID = temp_IscilikID;
                        temp_ih.Miktar = temp_Miktar;
                        temp_ih.BirimFiyat = temp_BirimFiyat;
                        temp_ih.IscilikTip = temp_IscilikTip;
                        if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis)
                        {
                            temp_ih.Kdvli = false;
                            temp_ih.Kdv = 0;
                        }
                        else
                        {
                            temp_ih.Kdvli = chkKdvli.Checked;
                            temp_ih.Kdv = (sbyte)spinKdvYuzde.Value;
                        }

                        temp_ih.FaturaID = _ft.FaturaID;
                        temp_ih.IndirimYuzde = temp_Indirim;

                        if (temp_YeniKayit)
                        {
                            dbModel.AddToiscilik_hareket(temp_ih);
                        }

                        dbModel.SaveChanges();

                        temp_List_ihID.Add(temp_ih.ID);
                        dbModel.Detach(temp_ih);
                        temp_ih = null;
                    }
                    else
                    {
                        temp_sh.StokKartID = temp_KartID;

                        if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis)
                            temp_sh.StokHareketTipi = ((int)Enumlar.StokHareketTipleri.FaturasizAlis).ToString();
                        else if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis)
                            temp_sh.StokHareketTipi = ((int)Enumlar.StokHareketTipleri.FaturasizSatis).ToString();
                        else if (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi)
                            temp_sh.StokHareketTipi = ((int)Enumlar.StokHareketTipleri.SatisFatura).ToString();
                        else if (FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi)
                            temp_sh.StokHareketTipi = ((int)Enumlar.StokHareketTipleri.AlisFatura).ToString();

                        temp_sh.Giris = FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis ? false : true;
                        temp_sh.Miktar = temp_Miktar;
                        temp_sh.BirimFiyat = temp_BirimFiyat;
                        temp_sh.ParcaNo = temp_ParcaNo;
                        if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis)
                        {
                            temp_sh.Kdvli = null;
                            temp_sh.Kdv = null;
                        }
                        else
                        {
                            temp_sh.Kdvli = chkKdvli.Checked;
                            temp_sh.Kdv = (sbyte)spinKdvYuzde.Value;
                        }

                        temp_sh.IndirimYuzde = temp_Indirim;
                        temp_sh.IndirimYuzde2 = temp_Indirim2;
                        temp_sh.IndirimYuzde3 = temp_Indirim3;
                        temp_sh.FaturaID = _ft.FaturaID;
                        temp_sh.DepoID = temp_DepoID.Value;

                        if ((FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis) && radioFaturaKaynak.SelectedIndex == 2)//Bağımsız Araçlı
                        {
                            temp_sh.AracID = Convert.ToInt32(txtAracPlaka.Tag);
                        }

                        if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi)
                        {
                            temp_sh.AracID = temp_AracID;
                        }

                        if (temp_YeniKayit)
                        {
                            dbModel.AddTostok_hareket(temp_sh);
                        }

                        dbModel.SaveChanges();
                        temp_List_shID.Add(temp_sh.ID);
                        dbModel.Detach(temp_sh);
                        temp_sh = null;
                    }

                } //for'un bittiği yer.

                //if (_YeniKayit)
                //{
                if (radioFaturaKaynak.SelectedIndex == 0||radioFaturaKaynak.SelectedIndex==2 || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis)
                {
                    Isler.Fatura.Sil_FaturaElemanlari(_ft.FaturaID, temp_List_ihID, temp_List_shID);
                }
                //}
                #endregion

                ucIsemriDemo1.Enabled = radioFaturaKaynak.Enabled = false;

                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.Kaydedildi, new Sistem.DetayArgumanlari { ID = _ft.FaturaID });
                }
                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, new Sistem.DetayArgumanlari { ID = _ft.FaturaID });
                }

                btnYazdir.Enabled = true;
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Sil()
        {
            if (_ft == null
                || (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi && !Isler.Yetki.Varmi_Yetki(58))
                || (FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi && !Isler.Yetki.Varmi_Yetki(62))
                || (FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis && !Isler.Yetki.Varmi_Yetki(70))
                || (FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis && !Isler.Yetki.Varmi_Yetki(66))) return;

            try
            {
                //if (Isler.Fatura.Ver_AdetParca(_ft.FaturaID) > 0)
                //{
                //    XtraMessageBox.Show("Faturaya Bağlı Parçalar Var.\nFatura Silinemez.", "Geçersiz İşlem",
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //if (Isler.Fatura.Ver_AdetIscilik(_ft.FaturaID) > 0)
                //{
                //    XtraMessageBox.Show("Faturaya Bağlı İşçilikler Var.\nFatura Silinemez.", "Geçersiz İşlem",
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //Burada gelir hareketi kontrol edilecek
                //Eğer gelir hareket varsa silme işlemi yapılamayacak.
                if (XtraMessageBox.Show("Seçili Faturayı Silmek İstediğinize Emin Misiniz?\n"
                   + "Fatura No: " + _ft.FaturaID.ToString(), "Fatura Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (_ft.FaturaKaynak == "2" && (FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis || FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi))
                    {
                        Isler.Servis.Guncelle_IsemriKapatma(_ft.IsemirID.Value, Enumlar.IsemriKapatmalari.Acik);
                    }
                    if (_ft.FaturaKaynak == "1" || _ft.FaturaKaynak == "3" || FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis) //Bağımsız
                    {
                        Isler.Fatura.Sil_FaturaElemanlari(_ft.FaturaID);
                    }

                    dbModel.DeleteObject(_ft);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Fatura Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    if (DetayOlay != null)
                    {
                        this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                    }
                    Yeni();
                }
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        public void Yeni()
        {
            _YeniKayit = radioFaturaKaynak.Enabled = ucIsemriDemo1.Enabled = true;
            btnYazdir.Enabled = false;

            Temizle_Fatura();
            Temizle_GenelToplam();
            Ara_FaturaElemanlari(-1, null);

            dateFaturaTarih.EditValue = DateTime.Now;

            if (FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis)
            {
                DataRow dr = dt_FaturaElemanlari.NewRow();
                dr["IscilikMi"] = 0;
                dt_FaturaElemanlari.Rows.Add(dr);
            }
            if (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi)
            {
                spinSiraNo.Value = Isler.Fatura.Ver_SonSiraNo() + 1;
            }

            if (DetayOlay != null)
            {
                this.Invoke(DetayOlay, Enumlar.DetayOlaylari.YeniKayit, null);
            }
        }

        void Temizle_Fatura()
        {
            lblFaturaID.Text = memoAciklama.Text = "";
            dateVadeTarih.EditValue = dateIsemriBitisTarih.EditValue = null;

            radioFaturaTip.SelectedIndex = 0;
            chkKdvli.Checked = false;

            spinCarpan1.EditValue = spinCarpan2.EditValue = null;
            ucBankaDemo1.Temizle_Banka();
            ucCariHesapDemo1.Temizle_Cari();
            ucKasaDemo1.Temizle_Kasa();

            dateFaturaTarih.EditValue = null;
            spinSiraNo.EditValue = null;

            txtAracPlaka.Tag = null;
            txtAracPlaka.Text = "";

            spinKdvYuzde.Value = 18;

            if (GridViewParcaIscilikler.Columns == null || GridViewParcaIscilikler.Columns.Count <= 0)
                Ara_FaturaElemanlari(-1, null);

            if (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi || FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis)
            {
                radioFaturaKaynak.SelectedIndex = 1;
                chkTevfikatVar.Checked = false;
                ucIsemriDemo1.Temizle_Isemri();
            }
        }

        void Temizle_GenelToplam()
        {
            lblIndirimliTutar.Text = lblIndirimTutari.Text = lblIscilikIndirimi.Text = lblIscilikNetTutar.Text = lblIscilikToplam.Text
             = lblKdv18.Text = lblNetTutar.Text = lblParcaIndirimi.Text = lblParcaNetTutar.Text = lblParcaToplam.Text = lblToplamTutar.Text
             = lblTevfikat.Text = "";

            ParcaToplam =
            ParcaIndirimi =
            ParcaNetTutar =
            IscilikToplam =
            IscilikIndirimi =
            IscilikNetTutar =
            ToplamTutar =
            IndirimTutari =
            IndirimliTutar =
            KdvTutari =
            Tevfikati =
            NetTutar = 0;
        }

        #region Genel Toplam Değişkenleri
        decimal ParcaToplam = 0;
        decimal ParcaIndirimi = 0;
        decimal ParcaNetTutar = 0;
        decimal IscilikToplam = 0;
        decimal IscilikIndirimi = 0;
        decimal IscilikNetTutar = 0;
        decimal ToplamTutar = 0;
        decimal IndirimTutari = 0;
        decimal IndirimliTutar = 0;
        decimal KdvTutari = 0;
        decimal NetTutar = 0;
        decimal Tevfikati = 0;
        #endregion
        void Hesapla_GenelToplam()
        {
            Temizle_GenelToplam();

            decimal temp_Tutar = 0;
            bool temp_IscilikMi;

            decimal? temp_Indirim = null;
            decimal? temp_Indirim2 = null;
            decimal? temp_Indirim3 = null;
            decimal t_ParcaIndirimi = 0;
            for (int i = 0; i < dt_FaturaElemanlari.Rows.Count; i++)
            {
                t_ParcaIndirimi = 0;
                temp_Tutar = Convert.ToDecimal(dt_FaturaElemanlari.Rows[i]["NetTutar"]);
                temp_IscilikMi = Convert.ToBoolean(dt_FaturaElemanlari.Rows[i]["IscilikMi"]);

                if (dt_FaturaElemanlari.Rows[i]["IndirimYuzde"] == DBNull.Value)
                {
                    temp_Indirim = null;
                }
                else
                {
                    temp_Indirim = Convert.ToDecimal(dt_FaturaElemanlari.Rows[i]["IndirimYuzde"]);
                }
                if (dt_FaturaElemanlari.Rows[i]["IndirimYuzde2"] == DBNull.Value)
                {
                    temp_Indirim2 = null;
                }
                else
                {
                    temp_Indirim2 = Convert.ToDecimal(dt_FaturaElemanlari.Rows[i]["IndirimYuzde2"]);
                }
                if (dt_FaturaElemanlari.Rows[i]["IndirimYuzde3"] == DBNull.Value)
                {
                    temp_Indirim3 = null;
                }
                else
                {
                    temp_Indirim3 = Convert.ToDecimal(dt_FaturaElemanlari.Rows[i]["IndirimYuzde3"]);
                }

                if (temp_IscilikMi)
                {
                    IscilikToplam += temp_Tutar;

                    if (temp_Indirim != null)
                    {
                        IscilikIndirimi += temp_Tutar * temp_Indirim.Value / 100;
                    }
                }
                else
                {
                    ParcaToplam += temp_Tutar;

                    if (temp_Indirim != null)
                    {
                        t_ParcaIndirimi = temp_Tutar * temp_Indirim.Value / 100;
                    }
                    if (temp_Indirim2 != null)
                    {
                        ParcaIndirimi += (temp_Tutar - t_ParcaIndirimi) * temp_Indirim2.Value / 100;
                    }
                    if (temp_Indirim3 != null)
                    {
                        ParcaIndirimi += (temp_Tutar - t_ParcaIndirimi) * temp_Indirim3.Value / 100;
                    }

                    ParcaIndirimi += t_ParcaIndirimi;
                }
            }

            ParcaToplam = Math.Round(ParcaToplam, 2);
            IscilikToplam = Math.Round(IscilikToplam, 2);

            ParcaIndirimi = Math.Round(ParcaIndirimi, 2);
            IscilikIndirimi = Math.Round(IscilikIndirimi, 2);

            ParcaNetTutar = Math.Round(ParcaToplam - ParcaIndirimi, 2);
            IscilikNetTutar = Math.Round(IscilikToplam - IscilikIndirimi, 2);

            ToplamTutar = Math.Round(ParcaToplam + IscilikToplam, 2);
            IndirimTutari = Math.Round(ParcaIndirimi + IscilikIndirimi, 2);
            IndirimliTutar = Math.Round(ToplamTutar - IndirimTutari, 2);

            KdvTutari = Math.Round(IndirimliTutar * Convert.ToInt32(spinKdvYuzde.Value) / 100, 2);

            if (chkTevfikatVar.Checked && (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi||FaturaTipi==Enumlar.FaturaTipleri.AlisFaturasi))
            {
                Tevfikati = KdvTutari * spinCarpan1.Value / spinCarpan2.Value;
                NetTutar = Math.Round(Math.Round(IndirimliTutar + KdvTutari, 2) - Tevfikati, 2); ;
            }
            else if (FaturaTipi == Enumlar.FaturaTipleri.SatisFaturasi||FaturaTipi == Enumlar.FaturaTipleri.AlisFaturasi)
            {
                NetTutar = Math.Round(IndirimliTutar + KdvTutari, 2);
            }
            else if (FaturaTipi == Enumlar.FaturaTipleri.FaturasizSatis || FaturaTipi == Enumlar.FaturaTipleri.FaturasizAlis)
            {
                NetTutar = IndirimliTutar;
            }           

            lblParcaToplam.Text = ParcaToplam.ToString();
            lblParcaIndirimi.Text = ParcaIndirimi.ToString();
            lblParcaNetTutar.Text = ParcaNetTutar.ToString();

            lblIscilikToplam.Text = IscilikToplam.ToString();
            lblIscilikIndirimi.Text = IscilikIndirimi.ToString();
            lblIscilikNetTutar.Text = IscilikNetTutar.ToString();

            lblToplamTutar.Text = ToplamTutar.ToString();
            lblIndirimTutari.Text = IndirimTutari.ToString();
            lblIndirimliTutar.Text = IndirimliTutar.ToString();

            lblKdv18.Text = KdvTutari.ToString();
            lblTevfikat.Text = Tevfikati.ToString();
            lblNetTutar.Text = NetTutar.ToString();
        }
        #endregion

        private void spinKdvYuzde_EditValueChanged(object sender, EventArgs e)
        {
            if (spinKdvYuzde.EditValue != null)
            {
                lblKdv18Caption.Text = "Kdv % "+spinKdvYuzde.Value.ToString()+" :";
            }
        }
    }
}