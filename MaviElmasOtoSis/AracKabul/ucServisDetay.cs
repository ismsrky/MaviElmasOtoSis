using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using DevExpress.XtraEditors;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.AracKabul
{
    public partial class ucServisDetay : Sistem.ucBaseDetay
    {
        #region < Değişkenler >
        otosisdbEntities dbModel;

        servi servis;
        isemri ism;
        isemri_talep talep;
        stok_hareket parca;
        iscilik_hareket isc_har;

        bool YuklemeIsemirleri;
        bool YuklemeTalepler;
        bool YuklemeParcalar;
        bool YuklemeIscilik;

        bool Focusta_Isemri = false;
        bool Focusta_Parca = false;
        bool Focusta_Iscilik = false;

        bool YeniKayitIsemri;
        bool YeniKayitTalep = true;
        bool YeniKayitParcalar = true;
        bool YeniKayitIscilik = true;

        int _Secili_ServisID;
        int Secili_Isemri;
        int Secili_TalepID;
        int Secili_ParcaID;
        int Secili_IscilikID;

        DataTable dt_Isemirleri;
        DataTable dt_Talepler;
        DataTable dt_IscilikPersonel;
        DataTable dt_Parcalar;
        DataTable dt_Iscilik;

        public DetayOlayHandler DetayOlay;

        bool IsemriDuzenle = false;
        #endregion

        #region < Özellikler >
        public int Secili_ServisID
        {
            get
            {
                return _Secili_ServisID;
            }
        }
        #endregion

        #region < Load >
        public ucServisDetay()
        {
            InitializeComponent();
            if (this.IsInDesignMode) return;
            try
            {
                _Yukleme = true;
                dbModel = new otosisdbEntities(Baglanti.BaglantiEntity);

                #region databind
                Isler.Genelkodlar.Ver_Kod("YakitMiktar", ref lookUpYakitMiktar, "Lütfen Seçiniz");
                Isler.Genelkodlar.Ver_Kod("Performans", ref reLookUpPerformans);
                Isler.Genelkodlar.Ver_Kod("IsemriKapatma", ref lookUpIsemriKapatma);

                lookUpIsemriBirim.Properties.DisplayMember = "BirimAd";
                lookUpIsemriBirim.Properties.ValueMember = "BirimID";
                lookUpIsemriBirim.Properties.DataSource = Araclar.Veri.Ekle_Lutfen(Isler.Birim.Ver_Birimler(Enumlar.BirimTipleri.Atolye), "BirimAd", "BirimID");

                lookUpDepolar.Properties.DisplayMember = "DepoAd";
                lookUpDepolar.Properties.ValueMember = "DepoID";
                lookUpDepolar.Properties.DataSource = Genel.dt_DepolarSecim.Copy();

                reLookUpPersonel.DisplayMember = "AdSoyad";
                reLookUpPersonel.ValueMember = "PersonelID";
                reLookUpPersonel.DataSource = Genel.dt_PersonellerSecim.Copy();
                #endregion

                lookUpDepolar.EditValue = 1;
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Araç Kabul Ekranı Açılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _Yukleme = false;
            }
        }
        #endregion

        #region < Olaylar >
        #region Servis
        private void tabServis_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            Yukle_ServisTablar();
        }

        private void spinIsemirKM_EditValueChanged(object sender, EventArgs e)
        {
            if (spinServisKM.EditValue != null && spinServisKM.Value == spinServisKM.Properties.MinValue)
            {
                spinServisKM.EditValue = null;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet_Servis();
        }
        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            Yeni_Servis();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil_Servis();
        }
        #endregion

        #region İşemri
        private void btnIsemriKaydet_Click(object sender, EventArgs e)
        {
            Kaydet_Isemri();
        }
        private void btnIsemriYeniKayit_Click(object sender, EventArgs e)
        {
            Yeni_Isemri();
        }
        private void btnIsemriSil_Click(object sender, EventArgs e)
        {
            Sil_Isemri();
        }

        private void gridViewIsemri_Click(object sender, EventArgs e)
        {
            gridViewIsemri.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (gridViewIsemri.GetFocusedDataRow() != null && !Focusta_Isemri)
            {
                Focus_Isemri();
            }
            Focusta_Isemri = false;
        }
        private void gridViewIsemri_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewIsemri.OptionsSelection.EnableAppearanceFocusedRow = true;
            Focusta_Isemri = true;
            Focus_Isemri();
        }

        private void lookUpIsemriBirim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Kaydet_Isemri();
            }
        }
        private void btnIsemriYazdir_Click(object sender, EventArgs e)
        {
            if (gridViewIsemri.GetFocusedRow() == null) return;
            rptIsemriDokum IsemriDok = new rptIsemriDokum();
            IsemriDok.DataSource = dt_Talepler;
            IsemriDok.PrinterName = Sistem.Ayarlar.YaziciA4;
            IsemriDok.lblCariID.Text = ucCariHesapDemo1.cari.CariID.ToString();
            IsemriDok.lblUnvan.Text = ucCariHesapDemo1.cari.Unvan;
            IsemriDok.lblVergiDairesi.Text = ucCariHesapDemo1.cari.VergiDairesi;
            if (!string.IsNullOrEmpty(ucCariHesapDemo1.cari.Tel1))
            {
                IsemriDok.lblTelefon.Text = ucCariHesapDemo1.cari.Tel1;
            }
            if (!string.IsNullOrEmpty(ucCariHesapDemo1.cari.Tel2))
            {
                IsemriDok.lblTelefon.Text += " / " + ucCariHesapDemo1.cari.Tel2;
            }

            IsemriDok.lblAdres.Text = ucCariHesapDemo1.cari.AdresAcik + Environment.NewLine;
            if (ucCariHesapDemo1.cari.AdresIlce != null)
            {
                IsemriDok.lblAdres.Text += Isler.Adres.Ver_IlceAd(ucCariHesapDemo1.cari.AdresIlce.Value) + " / ";
            }
            if (ucCariHesapDemo1.cari.AdresIl != null)
            {
                IsemriDok.lblAdres.Text += Isler.Adres.Ver_IlAd(ucCariHesapDemo1.cari.AdresIl.Value);
            }

            IsemriDok.lblServisIsemriNo.Text = servis.ServisID.ToString() + " / " + ism.IsemirID.ToString();
            IsemriDok.lblIsemriKayitZaman.Text = ism.KayitZaman.ToString("dd.MM.yyyy HH:mm");
            IsemriDok.lblPlaka.Text = ucAracDemo1.arc.Plaka;
            IsemriDok.lblMarka.Text = Isler.MarkaModel.Ver_MarkaAd(ucAracDemo1.arc.MarkaID) + " " + Isler.MarkaModel.Ver_ModelAd(ucAracDemo1.arc.ModelID);
            IsemriDok.lblSasiNo.Text = ucAracDemo1.arc.SaseNo;
            if (servis.Km != null)
            {
                IsemriDok.lblKmYakit.Text = servis.Km.Value.ToString();
            }
            if (!string.IsNullOrEmpty(servis.YakitMiktar))
            {
                IsemriDok.lblKmYakit.Text = Isler.Genelkodlar.Ver_Aciklama("YakitMiktar", servis.YakitMiktar);
            }

            IsemriDok.lblDanisman.Text = Isler.Kullanici.Ver_KullaniciAdSoyad(ism.KayitKullaniciID);
            IsemriDok.lblGetirenKisi.Text = servis.AraciGetirenKisi;
            IsemriDok.lblServisBilgileri.Text = Genel.AktifSirket.Unvan;
            IsemriDok.lblServisBilgileri.Text += Genel.AktifSirket.AdresAcik + Environment.NewLine;
            if (Genel.AktifSirket.AdresIlce != null)
            {
                IsemriDok.lblServisBilgileri.Text += Isler.Adres.Ver_IlceAd(Genel.AktifSirket.AdresIlce.Value) + " / ";
            }
            if (Genel.AktifSirket.AdresIl != null)
            {
                IsemriDok.lblServisBilgileri.Text += Isler.Adres.Ver_IlAd(Genel.AktifSirket.AdresIl.Value);
            }

            if (!string.IsNullOrEmpty(Genel.AktifSirket.Tel1))
            {
                IsemriDok.lblServisBilgileri.Text += Environment.NewLine + "TEL1: " + Genel.AktifSirket.Tel1;
            }
            if (!string.IsNullOrEmpty(Genel.AktifSirket.Tel2))
            {
                IsemriDok.lblServisBilgileri.Text += Environment.NewLine + "TEL2: " + Genel.AktifSirket.Tel2;
            }

            IsemriDok.ShowPreview();
        }
        #endregion

        #region Talepler
        private void btnTalepSil_Click(object sender, EventArgs e)
        {
            Sil_Talep();
        }
        private void btnTalepYeniKayit_Click(object sender, EventArgs e)
        {
            Yeni_Talep();
        }
        private void btnTalepKaydet_Click(object sender, EventArgs e)
        {
            Kaydet_Talep();
        }

        private void gridViewTalepler_Click(object sender, EventArgs e)
        {
            if (gridViewTalepler.GetFocusedDataRow() != null &&
               (int)gridViewTalepler.GetFocusedRowCellValue("TalepID") == Secili_TalepID)
                Focus_Talep();
        }
        private void gridViewTalepler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Focus_Talep();
        }

        private void chkTalepYapildi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTalepYapildi.Checked)
            {
                chkTalepYapildi.Text = "Yapıldı";
            }
            else
            {
                chkTalepYapildi.Text = "Yapılmadı";
            }
        }

        private void tabTalepDetaylar_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            Yukle_TalepTablari();
        }
        #endregion

        #region Parçalar
        private void btnParcalarSil_Click(object sender, EventArgs e)
        {
            Sil_Parca();
        }
        private void btnParcalarYeniKayit_Click(object sender, EventArgs e)
        {
            Yeni_Parca();
        }
        private void btnParcalarKaydet_Click(object sender, EventArgs e)
        {
            Kaydet_Parca();
        }

        private void GridViewParcalar_Click(object sender, EventArgs e)
        {
            GridViewParcalar.OptionsSelection.EnableAppearanceFocusedRow = true;
            if (GridViewParcalar.GetFocusedRow() != null && !Focusta_Parca)
            {
                Focus_Parcalar();
            }
            Focusta_Parca = false;
        }
        private void GridViewParcalar_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridViewParcalar.OptionsSelection.EnableAppearanceFocusedRow = true;
            Focusta_Parca = true;
            Focus_Parcalar();
        }

        private void btnParcalarStokKart_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (Stok.frmStokKartSec sec = new Stok.frmStokKartSec())
            {
                if (sec.ShowDialog() == DialogResult.OK)
                {
                    btnParcalarStokKart.Tag = sec.Secilen_KartID.ToString();
                    btnParcalarStokKart.Text = sec.Secilen_KalemAdi;

                    var parcaaaa = (from abc in dbModel.stok_kart
                                    where abc.KartID == sec.Secilen_KartID
                                    select new
                                    {
                                        abc.SatisFiyat
                                    }).FirstOrDefault();
                    spinBirimFiyat.Value = parcaaaa.SatisFiyat == null ? 0 : parcaaaa.SatisFiyat.Value;
                }
            }
        }
        #endregion

        #region İşçilikler
        private void btnIscilikSil_Click(object sender, EventArgs e)
        {
            Sil_Iscilik();
        }
        private void btnIscilikYeniKayit_Click(object sender, EventArgs e)
        {
            Yeni_Iscilik();
        }
        private void btnIscilikKaydet_Click(object sender, EventArgs e)
        {
            Kaydet_Iscilik();
        }

        private void gridViewIscilikler_Click(object sender, EventArgs e)
        {
            if (gridViewIscilikler.GetFocusedRow() != null && !Focusta_Iscilik)
            {
                Focus_Iscilik();
            }
            Focusta_Iscilik = false;
        }
        private void gridViewIscilikler_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Focusta_Iscilik = true;
            Focus_Iscilik();
        }

        private void btnIscilikSec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (Tanim.frmIscilikSec SecIsc = new Tanim.frmIscilikSec())
            {
                if (SecIsc.ShowDialog() == DialogResult.OK)
                {
                    btnIscilikSec.Text = SecIsc.IscilikAd;
                    btnIscilikSec.Tag = SecIsc.IscilikID;
                    spinIscilikMiktar.Value = SecIsc.KacSaat;

                    spinIscilikBirimFiyat.Value = SecIsc.IscilikTip == "1" ? Genel.IscilikAgir :
                       SecIsc.IscilikTip == "2" ? Genel.IscilikOrta :
                       SecIsc.IscilikTip == "3" ? Genel.IscilikHafif : 1;
                }
            }
        }

        void dt_IscilikPersonel_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            dt_IscilikPersonel.Rows.Remove(e.Row);

            if (dt_IscilikPersonel.Rows.Count == 0)
            {
                gridViewIscilikPersoneller.AddNewRow();
            }
        }

        private void gridViewIscilikPersoneller_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value == null) return;

            if (e.Column == colPersonelID)
            {
                //gridViewIscilikPersoneller.SetRowCellValue(e.RowHandle, colAdSoyad, Isler.Personel.Ver_AdSoyad(Convert.ToInt32(e.Value)));
                gridViewIscilikPersoneller.SetRowCellValue(e.RowHandle, colPerformans, "2");
            }
        }
        private void gridViewIscilikPersoneller_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridViewIscilikPersoneller.AddNewRow();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                gridViewIscilikPersoneller.DeleteSelectedRows();
            }
        }
        #endregion
        #endregion

        #region < Metod >
        void Ara_Isemirleri(int _ServisID)
        {
            try
            {
                YuklemeIsemirleri = true;

                dt_Isemirleri = null;
                dt_Isemirleri = Isler.Servis.Ver_Isemirleri(_ServisID);
                gridControlIsemri.DataSource = dt_Isemirleri;
                grupIsemri.Text = "İşemirleri (" + dt_Isemirleri.Rows.Count.ToString() + ")";

                if (dt_Isemirleri.Rows.Count > 0)
                {
                    btnIsemriSil.Enabled = true;
                }
                else
                {
                    btnIsemriSil.Enabled = false;
                }

                gridViewIsemri.OptionsSelection.EnableAppearanceFocusedRow = false;
                Yeni_Isemri();
            }
            catch (Exception hata)
            {

                throw;
            }
            finally
            {
                YuklemeIsemirleri = false;
            }
        }
        void Ara_Talepler(int _IsemirID)
        {
            try
            {
                YuklemeTalepler = true;

                dt_Talepler = null;
                dt_Talepler = Isler.Servis.Ver_Talepler(_IsemirID);
                gridControlTalepler.DataSource = dt_Talepler;
                gridViewTalepler.ViewCaption = "Talepler Listesi (" + dt_Talepler.Rows.Count.ToString() + ")";

                if (dt_Talepler.Rows.Count > 0)
                {
                    bool Bulundu = false;
                    int temp_TalepID = 0;
                    for (int i = 0; i < gridViewTalepler.RowCount; i++)
                    {
                        temp_TalepID = Convert.ToInt32(gridViewTalepler.GetDataRow(i)["TalepID"]);
                        if (temp_TalepID == Secili_TalepID)
                        {
                            gridViewTalepler.FocusedRowHandle = i;
                            Bulundu = true;
                            break;
                        }
                    }

                    YuklemeTalepler = false;
                    if (!Bulundu)
                    {
                        Yukle_Talep(Convert.ToInt32(gridViewTalepler.GetDataRow(0)["TalepID"]));
                    }
                    tabTalepDetaylar.Enabled = true;

                    btnTalepSil.Enabled = true & IsemriDuzenle;
                }
                else
                {
                    btnTalepSil.Enabled = false;
                    Yeni_Talep();
                }

                Yukle_TalepTablari();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Müşteri Talep Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                YuklemeTalepler = false;
            }
        }

        void Ara_IscilikPersonel(int _IHID)
        {
            try
            {
                if (dt_IscilikPersonel != null)
                    dt_IscilikPersonel.Dispose();
                dt_IscilikPersonel = null;

                dt_IscilikPersonel = Isler.Iscilik.Ver_IscilikPersoneller(_IHID);
                dt_IscilikPersonel.RowDeleted += new DataRowChangeEventHandler(dt_IscilikPersonel_RowDeleted);
                gridControlIscilikPersoneller.DataSource = dt_IscilikPersonel;
                gridViewIscilikPersoneller.ViewCaption = "İşi Yapan Personeller Listesi (" + dt_IscilikPersonel.Rows.Count.ToString() + ")";

                gridViewIscilikPersoneller.AddNewRow();
            }
            catch (Exception hata)
            {
                
            }
        }
        void Ara_Parcalar(int _TalepID)
        {
            try
            {
                YuklemeParcalar = true;

                dt_Parcalar = null;
                dt_Parcalar = Isler.Stok.Ver_StokHareketleri(_TalepID);
                gridControlParcalar.DataSource = dt_Parcalar;
                GridViewParcalar.ViewCaption = "Parçalar Listesi (" + dt_Parcalar.Rows.Count.ToString() + ")";

                if (dt_Parcalar.Rows.Count > 0)
                {
                    //bool Bulundu = false;
                    //int ID = 0;
                    //for (int i = 0; i < GridViewParcalar.RowCount; i++)
                    //{
                    //    ID = Convert.ToInt32(GridViewParcalar.GetDataRow(i)["ID"]);
                    //    if (ID == Secili_ParcaID)
                    //    {
                    //        GridViewParcalar.FocusedRowHandle = i;
                    //        Bulundu = true;
                    //        break;
                    //    }
                    //}

                    //YuklemeParcalar = false;
                    //if (!Bulundu)
                    //{
                    //    Yukle_Parca(Convert.ToInt32(GridViewParcalar.GetDataRow(0)["ID"]));
                    //}
                    btnParcalarSil.Enabled = true & IsemriDuzenle;
                }
                else
                {
                    btnParcalarSil.Enabled = false;
                }

                Yeni_Parca();
            }
            catch (Exception hata)
            {

                throw;
            }
            finally
            {
                YuklemeParcalar = false;
            }
        }
        void Ara_Iscilik(int _TalepID)
        {
            try
            {
                YuklemeIscilik = true;

                dt_Iscilik = null;
                dt_Iscilik = Isler.Iscilik.Ver_Iscilikler(_TalepID);
                gridControlIscilikler.DataSource = dt_Iscilik;
                gridViewIscilikler.ViewCaption = "İşçilikler Listesi (" + dt_Iscilik.Rows.Count.ToString() + ")";

                if (dt_Iscilik.Rows.Count > 0)
                {
                    bool Bulundu = false;
                    int _IscilikID = 0;
                    for (int i = 0; i < gridViewIscilikler.RowCount; i++)
                    {
                        _IscilikID = Convert.ToInt32(gridViewIscilikler.GetDataRow(i)["ID"]);
                        if (_IscilikID == Secili_IscilikID)
                        {
                            gridViewIscilikler.FocusedRowHandle = i;
                            Bulundu = true;
                            break;
                        }
                    }

                    YuklemeIscilik = false;
                    if (!Bulundu)
                    {
                        Yukle_Iscilik(Convert.ToInt32(gridViewIscilikler.GetDataRow(0)["ID"]));
                    }
                    btnIscilikSil.Enabled = true & IsemriDuzenle;
                }
                else
                {
                    Yeni_Iscilik();
                    btnIscilikSil.Enabled = false;
                }
            }
            catch (Exception hata)
            {

                throw;
            }
            finally
            {
                YuklemeIscilik = false;
            }
        }

        public void Yukle_Servis(int _ServisID)
        {
            if (_Yukleme) return;

            try
            {
                Temizle_Servis();
                _YeniKayit = false;

                if (servis != null && servis.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(servis);
                }
                servis = null;
                servis = Isler.Servis.Ver_Servis(ref dbModel, _ServisID);
                if (servis == null) return;

                txtServisID.Text = servis.ServisID.ToString();
                txtServisGetirenKisi.Text = servis.AraciGetirenKisi;
                txtServisGetirenKisiTel1.Text = servis.GetirenKisiCep1;
                txtServisGetirenKisiTel2.Text = servis.GetirenKisiCep2;
                memoServisAciklama.Text = servis.Aciklama;
                spinServisKM.EditValue = servis.Km;
                dateServisGelisTarih.EditValue = servis.GelisTarih;
                dateTeslimTarih.EditValue = servis.TeslimTarih;
                if (!string.IsNullOrEmpty(servis.YakitMiktar))
                {
                    lookUpYakitMiktar.EditValue = servis.YakitMiktar;
                }

                _Secili_ServisID = servis.ServisID;
                Secili_Isemri = 0;

                Yukle_ServisTablar();

                ucKayitBilgiServis.Yukle(servis.KayitKullaniciID, servis.KayitZaman, servis.DuzenKullaniciID, servis.DuzenZaman);
                pEnable(true);
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Yukle_Isemri(int _IsemirID)
        {
            if (YuklemeIsemirleri) return;

            try
            {
                Temizle_Isemri();
                YeniKayitIsemri = false;
                btnIsemriYazdir.Enabled = true;

                if (ism != null && ism.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(ism);
                }
                ism = null;
                ism = Isler.Servis.Ver_Isemri(ref dbModel, _IsemirID);
                if (ism == null) return;

                dateIsemirTahminiBitis.EditValue = ism.TahminiBitisTarih;
                lookUpIsemriBirim.EditValue = ism.BirimID;
                lookUpIsemriKapatma.EditValue = ism.IsemriKapatma;
                dateIsemriBitisTarih.EditValue = ism.BitisTarih;

                grupTalepler.Enabled = true;

                Secili_TalepID = 0;
                if (talep != null && talep.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(talep);
                }
                talep = null;

                ucKayitBilgiIsemri.Yukle(ism.KayitKullaniciID, ism.KayitZaman, ism.DuzenKullaniciID, ism.DuzenZaman);

                Ara_Talepler(_IsemirID);

                if (ism.FaturaID == null)
                {
                    pEnable_IsemriUyari(false);
                }
                else
                {
                    pEnable_IsemriUyari(true);
                }

                Secili_Isemri = ism.IsemirID;
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Yukle_Talep(int _TalepID)
        {
            if (YuklemeTalepler) return;

            try
            {
                Temizle_Talep();
                YeniKayitTalep = false;

                if (talep != null && talep.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(talep);
                }
                talep = null;
                talep = Isler.Servis.Ver_Talep(ref dbModel, _TalepID);
                if (talep == null) return;

                memoTalep.Text = talep.Talep;
                chkTalepYapildi.Checked = talep.Yapildi;
                spinTalepSira.EditValue = talep.Sira;
                dateTalepBaslama.EditValue = talep.BaslamaTarih;
                dateTalepBitis.EditValue = talep.BitisTarih;
                memoTalepAciklama.Text = talep.Aciklama;

                tabTalepDetaylar.Enabled = true;
                Secili_TalepID = talep.TalepID;

                tabTalepDetaylar.Enabled = true;

                ucKayitBilgiTalep.Yukle(talep.KayitKullaniciID, talep.KayitZaman, talep.DuzenKullaniciID, talep.DuzenZaman);

                Yukle_TalepTablari();
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Talep Bilgileri Getirilirken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Yukle_Parca(int ID)
        {
            if (YuklemeParcalar) return;

            try
            {
                Temizle_Parca();
                YeniKayitParcalar = false;

                if (parca != null && parca.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(parca);
                }
                parca = null;
                parca = Isler.Stok.Ver_StokHareket(ref dbModel, ID);
                if (parca == null) return;

                btnParcalarStokKart.Text = Isler.Stok.Ver_KalemAdi(parca.StokKartID);
                btnParcalarStokKart.Tag = parca.StokKartID;
                spinParcalarMiktar.EditValue = parca.Miktar;
                spinBirimFiyat.Value = parca.BirimFiyat.Value;
                memoParcalarAciklama.Text = parca.Aciklama;
                Secili_ParcaID = parca.ID;

                ucKayitBilgiParca.Yukle(parca.KayitKullaniciID, parca.KayitZaman, parca.DuzenKullaniciID, parca.DuzenZaman);
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Yukle_Iscilik(int _ID)
        {
            if (YuklemeIscilik) return;

            try
            {
                Temizle_Iscilik();

                YeniKayitIscilik = false;

                if (isc_har != null && isc_har.EntityState != EntityState.Detached)
                {
                    dbModel.Detach(isc_har);
                }
                isc_har = null;
                isc_har = Isler.Iscilik.Ver_IscilikHareket(ref dbModel, _ID);
                if (isc_har == null) return;

                //memoIscilikAciklama.Text = isc_har.Aciklama;
                spinIscilikMiktar.Value = isc_har.Miktar;

                btnIscilikSec.Tag = isc_har.IscilikID;
                btnIscilikSec.Text = Isler.Iscilik.Ver_IscilikAd(isc_har.IscilikID);

                Secili_IscilikID = isc_har.IscilikID;
                ucKayitBilgiIscilik.Yukle(isc_har.KayitKullaniciID, isc_har.KayitZaman, isc_har.DuzenKullaniciID, isc_har.DuzenZaman);

                Ara_IscilikPersonel(isc_har.ID);
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        void Yukle_ServisTablar()
        {
            if (_Yukleme || servis == null) return;

            if (tabServis.SelectedTabPage == pageServis)
            {
                ucAracDemo1.Yukle_Arac(servis.AracID);
                ucCariHesapDemo1.Yukle_Cari(servis.CariID);
            }
            else if (tabServis.SelectedTabPage == pageIsemirleri)
            {
                Ara_Isemirleri(servis.ServisID);
            }
        }
        void Yukle_TalepTablari()
        {
            if (tabTalepDetaylar.SelectedTabPage == pageParcalar)
            {
                Ara_Parcalar(Secili_TalepID);
            }
            else if (tabTalepDetaylar.SelectedTabPage == pageIscilikler)
            {
                Ara_Iscilik(Secili_TalepID);
            }
        }

        void Temizle_Servis()
        {
            ucAracDemo1.Temizle_Arac();
            ucCariHesapDemo1.Temizle_Cari();

            txtServisGetirenKisi.Text = txtServisID.Text = memoServisAciklama.Text = txtServisGetirenKisiTel1.Text = txtServisGetirenKisiTel2.Text = "";

            spinServisKM.EditValue = null;

            dateIsemirTahminiBitis.EditValue = null;

            lookUpYakitMiktar.EditValue = lookUpIsemriBirim.EditValue = "-1";
        }
        void Temizle_Isemri()
        {
            dateIsemirTahminiBitis.EditValue = dateIsemriBitisTarih.EditValue = null;
            lookUpIsemriBirim.EditValue = -1;
            ucKayitBilgiIsemri.Temizle();

            lookUpIsemriKapatma.EditValue = "1";

            Temizle_Talep();
        }
        void Temizle_Talep()
        {
            dateTalepBaslama.EditValue = dateTalepBitis.EditValue = null;

            memoTalepAciklama.Text = memoTalep.Text = "";
            spinTalepSira.EditValue = 1;
            chkTalepYapildi.Checked = false;

            ucKayitBilgiTalep.Temizle();
        }
        void Temizle_Parca()
        {
            memoParcalarAciklama.Text = btnParcalarStokKart.Text = "";
            spinParcalarMiktar.EditValue = 0;

            btnParcalarStokKart.Tag = null;

            ucKayitBilgiParca.Temizle();
        }
        void Temizle_Iscilik()
        {
            //memoIscilikAciklama.Text = btnIscilikSec.Text = "";

            btnIscilikSec.Tag = null;

            spinIscilikMiktar.Value = 0;

            ucKayitBilgiIscilik.Temizle();
        }

        //void Getir_TalepPersonel(int PersonelID)
        //{
        //    var per = (from abc in dbModel.personels
        //               where abc.PersonelID == PersonelID
        //               select new
        //               {
        //                   abc.Ad,
        //                   abc.Soyad,
        //                   abc.CalistigiBirim,
        //                   abc.Unvan
        //               }).SingleOrDefault();

        //    btnTalepPersonelAdSoyad.Text = per.Ad + " " + per.Soyad;
        //    lookUpTalepPersonelBirim.EditValue = per.CalistigiBirim;
        //    lookUpTalepPersonelUnvan.EditValue = per.Unvan;

        //    per = null;
        //}
        //void Getir_IscilikPersonel()
        //{
        //}

        void Focus_Isemri()
        {
            if (YuklemeIsemirleri || gridViewIsemri.GetFocusedRow() == null) return;
            Secili_Isemri = Convert.ToInt32(gridViewIsemri.GetFocusedRowCellValue("IsemirID"));

            Yukle_Isemri(Secili_Isemri);
        }
        void Focus_Talep()
        {
            if (YuklemeTalepler || gridViewTalepler.GetFocusedDataRow() == null) return;

            Secili_TalepID = Convert.ToInt32(gridViewTalepler.GetFocusedRowCellValue("TalepID"));

            Yukle_Talep(Secili_TalepID);
        }
        void Focus_Parcalar()
        {
            if (YuklemeParcalar || GridViewParcalar.GetFocusedRow() == null) return;

            Secili_ParcaID = Convert.ToInt32(GridViewParcalar.GetFocusedRowCellValue("ID"));

            Yukle_Parca(Secili_ParcaID);
        }
        void Focus_Iscilik()
        {
            if (YuklemeIscilik || gridViewIscilikler.GetFocusedRow() == null) return;

            Secili_IscilikID = Convert.ToInt32(gridViewIscilikler.GetFocusedRowCellValue("ID"));

            Yukle_Iscilik(Secili_IscilikID);
        }

        void Kaydet_Servis()
        {
            if ((_YeniKayit && !Isler.Yetki.Varmi_Yetki(39)) || !_YeniKayit && !Isler.Yetki.Varmi_Yetki(40)) return;

            try
            {
                #region Konroller
                if (string.IsNullOrEmpty(txtServisGetirenKisi.Text.Trim()))
                {
                    XtraMessageBox.Show("Aracı Getiren Kişi Adı Boş Bırakılamaz.", "Eksik Alan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServisGetirenKisi.Focus(); txtServisGetirenKisi.Select();
                    return;
                }
                if (ucCariHesapDemo1.Secili_CariID <= 0)
                {
                    XtraMessageBox.Show("Lütfen Servis Açılacak Cari Hesabı Seçiniz.", "Cari Hesap Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ucAracDemo1.Secili_AracID<=0)
                {
                    XtraMessageBox.Show("Lütfen Servis Açılacak Aracı Seçiniz.", "Araç Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucAracDemo1.Focus(); ucAracDemo1.Select();
                    return;
                }
                if (dateServisGelisTarih.EditValue == null)
                {
                    XtraMessageBox.Show("Lütfen Araç Geliş Tarihini Giriniz.", "Geliş Tarihi Girilmedi",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateServisGelisTarih.Focus(); dateServisGelisTarih.Select();
                    return;
                }
                if (dateTeslimTarih.EditValue != null && ((!YeniKayit && Isler.Servis.Ver_AdetIsemirleri(servis.ServisID) == 0) || YeniKayit))
                {
                    XtraMessageBox.Show("Servis Üzerinde Hiç İşemri Açılmamış.\nAraç Teslim Tarihi Girilemez.", "Geçersiz İşlem",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateTeslimTarih.Focus(); dateTeslimTarih.Select();
                    return;
                }
                if (!YeniKayit && dateTeslimTarih.EditValue != null && Isler.Servis.Varmi_AcikIsemri(servis.ServisID))
                {
                    XtraMessageBox.Show("Servis Üzerinde Açık İşemirleri Var.\nAraç Teslim Tarihi Girilemez.", "Geçersiz İşlem",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateTeslimTarih.Focus(); dateTeslimTarih.Select();
                    return;
                }
                #endregion

                if (_YeniKayit)
                {
                    if (servis != null && servis.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(servis);
                    }
                    servis = null;
                    servis = new servi();
                    servis.SirketID = Genel.AktifSirket.SirketID;
                }

                #region Aktarma
                servis.AracID = ucAracDemo1.Secili_AracID;
                servis.CariID = ucCariHesapDemo1.Secili_CariID;

                servis.AraciGetirenKisi = txtServisGetirenKisi.Text;
                servis.GetirenKisiCep1 = txtServisGetirenKisiTel1.Text;
                servis.GetirenKisiCep2 = txtServisGetirenKisiTel2.Text;
                servis.Aciklama = memoServisAciklama.Text;
                servis.GelisTarih = dateServisGelisTarih.DateTime;
                if (spinServisKM.EditValue == null)
                {
                    servis.Km = null;
                }
                else
                {
                    servis.Km = Convert.ToInt32(spinServisKM.EditValue);
                }
                if (lookUpYakitMiktar.EditValue.ToString() == "-1")
                {
                    servis.YakitMiktar = null;
                }
                else
                {
                    servis.YakitMiktar = lookUpYakitMiktar.EditValue.ToString();
                }
                if (dateTeslimTarih.EditValue == null)
                {
                    servis.TeslimTarih = null;
                }
                else
                {
                    servis.TeslimTarih = Convert.ToDateTime(dateTeslimTarih.EditValue);
                }
                #endregion

                #region Kayıt
                if (_YeniKayit)
                {
                    servis.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    servis.KayitZaman = DateTime.Now;
                    dbModel.AddToservis(servis);
                }
                else
                {
                    servis.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    servis.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();

                _Secili_ServisID = servis.ServisID;
                txtServisID.Text = servis.ServisID.ToString();

                _YeniKayit = false;

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Servis Başarılı Bir Şekilde Kaydedilmiştir.", null,
                  ResOtoSis.mark_blue);

                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.Kaydedildi, null);
                }
                if (DetayOlay != null)
                {
                    this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                }

                pEnable(true);

                if (YeniKayit)
                    tabServis.SelectedTabPageIndex = 1;
                #endregion
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("Servis Kayıdı Yapılırken Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int temp_BirimID;
        void Kaydet_Isemri()
        {
            try
            {
                #region Kontroller
                if (lookUpIsemriBirim.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Lütfen İşemrini Açılacağı Birimi Seçiniz.", "Birim Seçilmemiş",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabServis.SelectedTabPageIndex = 0;
                    lookUpIsemriBirim.Focus(); lookUpIsemriBirim.Select();
                    return;
                }
                temp_BirimID = Convert.ToInt32(lookUpIsemriBirim.EditValue);
                if (YeniKayitIsemri && Isler.Servis.Varmi_BirimID(_Secili_ServisID, temp_BirimID))
                {
                    XtraMessageBox.Show("Bu Birim Üzerinde Bir İşemri Daha Önce Açılmış\nLütfen Farklı Bir Birim Üzerinden İşemri Açmayı Deneyiniz.", "Aynı Birim",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpIsemriBirim.Focus(); lookUpIsemriBirim.Select();
                    return;
                }
                else if (!YeniKayitIsemri && temp_BirimID != ism.BirimID && Isler.Servis.Varmi_BirimID(_Secili_ServisID, temp_BirimID, ism.BirimID))
                {
                    XtraMessageBox.Show("Bu Birim Üzerinde Bir İşemri Daha Önce Açılmış\nLütfen Farklı Bir Birim Üzerinden İşemri Açmayı Deneyiniz.", "Aynı Birim",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpIsemriBirim.Focus(); lookUpIsemriBirim.Select();
                    return;
                }

                if (YeniKayitIsemri && servis.TeslimTarih != null)
                {
                    XtraMessageBox.Show("Kapatılmış Servis Üzerinde İşemri Açılamaz.", "Geçersiz İşlem",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if ((YeniKayitIsemri && lookUpIsemriKapatma.EditValue.ToString() == ((int)Enumlar.IsemriKapatmalari.Faturalandirildi).ToString())
                    || (!YeniKayitIsemri && ism.IsemriKapatma != ((int)Enumlar.IsemriKapatmalari.Faturalandirildi).ToString() && lookUpIsemriKapatma.EditValue.ToString() == ((int)Enumlar.IsemriKapatmalari.Faturalandirildi).ToString()))
                {
                    XtraMessageBox.Show("İşemrini Faturalandırıp Kapatmak İçin Lütfen Satış Faturası Kesiniz.", "Geçersiz İşlem",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpIsemriKapatma.Focus(); lookUpIsemriKapatma.Select();
                    return;
                }
                if (!YeniKayitIsemri && ism.IsemriKapatma == ((int)Enumlar.IsemriKapatmalari.Faturalandirildi).ToString())// && lookUpIsemriKapatma.EditValue.ToString() != ((int)Enumlar.IsemriKapatmalari.Faturalandirildi).ToString())
                {
                    XtraMessageBox.Show("Faturalandırılmış İşemrinin Durumu Değiştirilemez.", "Geçersiz İşlem",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpIsemriKapatma.Focus(); lookUpIsemriKapatma.Select();
                    return;
                }
                if (lookUpIsemriKapatma.EditValue.ToString() == ((int)Enumlar.IsemriKapatmalari.Acik).ToString() && dateIsemriBitisTarih.EditValue != null)
                {
                    XtraMessageBox.Show("Açık İşemrine Bitiş / Teslim Tarihi Girilemez.", "Geçersiz İşlem",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lookUpIsemriKapatma.Focus(); lookUpIsemriKapatma.Select();
                    return;
                }
                #endregion

                if (YeniKayitIsemri)
                {
                    if (ism != null && ism.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(ism);
                        ism = null;
                    }
                    ism = new isemri();
                }

                #region Aktarma - Kayıt
                ism.ServisID = servis.ServisID;
                ism.BirimID = temp_BirimID;
                if (dateIsemirTahminiBitis.EditValue == null)
                {
                    ism.TahminiBitisTarih = null;
                }
                else
                {
                    ism.TahminiBitisTarih = Convert.ToDateTime(dateIsemirTahminiBitis.EditValue);
                }

                ism.IsemriKapatma = lookUpIsemriKapatma.EditValue.ToString();
                if (lookUpIsemriKapatma.EditValue.ToString() == "-1")
                {
                    ism.IsemriKapatma = null;
                }
                else
                {
                    ism.IsemriKapatma = lookUpIsemriKapatma.EditValue.ToString();
                }

                if (YeniKayitIsemri)
                {
                    ism.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    ism.KayitZaman = DateTime.Now;
                    dbModel.AddToisemris(ism);
                }
                else
                {
                    ism.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    ism.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();

                Secili_Isemri = ism.IsemirID;


                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "İşemri Başarılı Bir Şekilde Kaydedilmiştir.", null,
                 ResOtoSis.mark_blue);

                Ara_Isemirleri(servis.ServisID);
                #endregion
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Kaydet_Talep()
        {
            try
            {
                #region Kontroller
                //if (dateTalepBaslama.EditValue == null)
                //{
                //    XtraMessageBox.Show("Talep Başlama Tarihi Boş Bırakılamaz.", "Eksik Alan",
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    dateTalepBaslama.Focus(); dateTalepBaslama.Select();
                //    return;
                //}
                //if (dateTalepBitis.EditValue == null)
                //{
                //    XtraMessageBox.Show("Talep Bitiş Tarihi Boş Bırakılamaz.", "Eksik Alan",
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    dateTalepBitis.Focus(); dateTalepBitis.Select();
                //    return;
                //}
                #endregion

                if (YeniKayitTalep)
                {
                    if (talep != null && talep.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(talep);
                        talep = null;
                    }
                    talep = new isemri_talep();
                    talep.IsemirID = ism.IsemirID;
                }

                #region Aktarma
                talep.Yapildi = chkTalepYapildi.Checked;
                talep.Talep = memoTalep.Text;
                if (dateTalepBaslama.EditValue == null)
                {
                    talep.BaslamaTarih = null;
                }
                else
                {
                    talep.BaslamaTarih = Convert.ToDateTime(dateTalepBaslama.EditValue);
                }
                if (dateTalepBitis.EditValue == null)
                {
                    talep.BitisTarih = null;
                }
                else
                {
                    talep.BitisTarih = Convert.ToDateTime(dateTalepBitis.EditValue);
                }
                talep.Sira = Convert.ToSByte(spinTalepSira.EditValue);
                talep.Aciklama = memoTalepAciklama.Text;
                #endregion

                #region Kayıt
                if (YeniKayitTalep)
                {
                    talep.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    talep.KayitZaman = DateTime.Now;
                    dbModel.AddToisemri_talep(talep);
                }
                else
                {
                    talep.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    talep.DuzenZaman = DateTime.Now;
                }
                dbModel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Talep Başarılı Bir Şekilde Kaydedilmiştir.", null,
                  ResOtoSis.mark_blue);

                Ara_Talepler(ism.IsemirID);
                #endregion
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Kaydet_Parca()
        {
            if (!btnParcalarKaydet.Enabled) return;
            try
            {
                int temp_KartID = 0;
                int temp_DepoID = Convert.ToInt32(lookUpDepolar.EditValue);

                #region Kontroller
                if (btnParcalarStokKart.Tag == null)
                {
                    XtraMessageBox.Show("Lütfen Talebe Eklenecek Parçayı Seçiniz.", "Parça Seçilmemiş",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnParcalarStokKart.Focus(); btnParcalarStokKart.Select();
                    return;
                }
                if (spinBirimFiyat.Value <= 0)
                {
                    XtraMessageBox.Show("Parça Birim Fiyatı 0'dan Büyük Olmalıdır.", "Geçersiz Birim Fiyat",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    spinBirimFiyat.Focus(); spinBirimFiyat.Select();
                    return;
                }
                temp_KartID = Convert.ToInt32(btnParcalarStokKart.Tag);
                if (spinParcalarMiktar.Value <= 0)
                {
                    XtraMessageBox.Show("Parça Miktarı 0'dan Büyük Olmalıdır.", "Geçersiz Miktar",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    spinParcalarMiktar.Focus(); spinParcalarMiktar.Select();
                    return;
                }
                if (!Genel.Varmi_Stokta(temp_KartID, temp_DepoID, spinParcalarMiktar.Value))
                {
                    return;
                }

                if (YeniKayitParcalar)
                {
                    for (int i = 0; i < dt_Parcalar.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt_Parcalar.Rows[i]["StokKartID"]) == temp_KartID)
                        {
                            XtraMessageBox.Show("Seçmiş Olduğunuz Kalem Daha Önce Listeye Eklenmiş.\nDeğişiklik yapmak için lütfen üzerine tıklayın ve değişiklik yapıp Kaydet butonuna basınız.", "Aynı Kayıt",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                #endregion

                if (YeniKayitParcalar)
                {
                    if (parca != null && parca.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(parca);
                    }
                    parca = null;
                    parca = new stok_hareket();

                    var per = (from abc in dbModel.stok_kart
                               where abc.KartID == temp_KartID
                               select new
                               {
                                   abc.SatisFiyat,
                                   abc.Kdv,
                                   abc.ParcaNo
                               }).SingleOrDefault();
                    parca.Kdvli = false;
                    parca.Kdv = per.Kdv;
                    parca.ParcaNo = per.ParcaNo;
                }

                #region Aktarma - Kayıt
                parca.BirimFiyat = spinBirimFiyat.Value;
                parca.AracID = ucAracDemo1.Secili_AracID;
                parca.TalepID = Secili_TalepID;
                parca.IsemirID = Secili_Isemri;
                parca.StokKartID = temp_KartID;
                parca.DepoID = temp_DepoID;
                parca.StokHareketTipi = "4"; //Satış Fatura
                parca.Giris = false;
                parca.Miktar = spinParcalarMiktar.Value;
                parca.Aciklama = memoParcalarAciklama.Text;

                if (YeniKayitParcalar)
                {
                    parca.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    parca.KayitZaman = DateTime.Now;
                    dbModel.AddTostok_hareket(parca);
                }
                else
                {
                    parca.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    parca.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Parça Başarılı Bir Şekilde Kaydedilmiştir.", null,
                  ResOtoSis.mark_blue);

                Ara_Parcalar(Secili_TalepID);
                #endregion
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Kaydet_Iscilik()
        {
            try
            {
                #region Kontroller
                if (btnIscilikSec.Tag == null)
                {
                    XtraMessageBox.Show("Lütfen Talebe Eklenecek İşçiliği Seçiniz.", "İşçilik Seçilmemiş",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnIscilikSec.Focus(); btnIscilikSec.Select();
                    return;
                }
                if (spinIscilikMiktar.Value <= 0)
                {
                    XtraMessageBox.Show("İşçilik Miktarı 0'dan Büyük Olmalıdır.", "Geçersiz Miktar",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    spinIscilikMiktar.Focus(); spinIscilikMiktar.Select();
                    return;
                }
                if (dt_IscilikPersonel == null || dt_IscilikPersonel.Rows.Count == 0)
                {
                    XtraMessageBox.Show("Lütfen İşçiliği Yapan Personelleri ve Performanslarını Seçiniz.", "Personel Eklenmedi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                int temp_IscilikID = Convert.ToInt32(btnIscilikSec.Tag);

                if (YeniKayitIscilik)
                {
                    if (isc_har != null && isc_har.EntityState != EntityState.Detached)
                    {
                        dbModel.Detach(isc_har);
                    }
                    isc_har = null;
                    isc_har = new iscilik_hareket();

                    var per = (from abc in dbModel.isciliks
                               where abc.IscilikID == temp_IscilikID
                               select new
                               {
                                   abc.IscilikTip
                               }).SingleOrDefault();
                    isc_har.IscilikTip = per.IscilikTip;
                    isc_har.Kdv = 18;
                    isc_har.Kdvli = false;
                }

                #region Aktarma - Kayıt
                isc_har.IscilikID = temp_IscilikID;
                isc_har.TalepID = Secili_TalepID;
                isc_har.IsemirID = Secili_Isemri;
                isc_har.Miktar = spinIscilikMiktar.Value;
                isc_har.BirimFiyat = spinIscilikBirimFiyat.Value;

                //isc_har.Aciklama = memoIscilikAciklama.Text;

                if (YeniKayitIscilik)
                {
                    isc_har.KayitKullaniciID = Genel.AktifKullanici.KullaniciID;
                    isc_har.KayitZaman = DateTime.Now;

                    dbModel.AddToiscilik_hareket(isc_har);
                }
                else
                {
                    isc_har.DuzenKullaniciID = Genel.AktifKullanici.KullaniciID;
                    isc_har.DuzenZaman = DateTime.Now;
                }

                dbModel.SaveChanges();

                Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "İşçilik Başarılı Bir Şekilde Kaydedilmiştir.", null,
                 ResOtoSis.mark_blue);

                ucKayitBilgiIscilik.Yukle(isc_har.KayitKullaniciID, isc_har.KayitZaman, isc_har.DuzenKullaniciID, isc_har.DuzenZaman);
                #endregion

                #region İşçilik Personel
                Isler.Iscilik.Sil_IscilikPersoneller(isc_har.ID);

                int temp_PersonelID = 0;
                string temp_Performans = "";
                for (int i = 0; i < dt_IscilikPersonel.Rows.Count; i++)
                {
                    if (dt_IscilikPersonel.Rows[i]["PersonelID"] != DBNull.Value)
                    {
                        temp_PersonelID = Convert.ToInt32(dt_IscilikPersonel.Rows[i]["PersonelID"]);
                        temp_Performans = dt_IscilikPersonel.Rows[i]["Performans"].ToString();

                        iscilik_hareket_personel IHP = new iscilik_hareket_personel();
                        IHP.IH_ID = isc_har.ID;
                        IHP.Performans = temp_Performans;
                        IHP.PersonelID = temp_PersonelID;
                        dbModel.AddToiscilik_hareket_personel(IHP);
                        dbModel.SaveChanges();
                        dbModel.Detach(IHP);
                        IHP = null;
                    }
                }
                #endregion

                Ara_Iscilik(Secili_TalepID);
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        void Sil_Servis()
        {
            if (servis == null) return;

            if (!Genel.Yetkilerim.Contains(41))
            {
                Genel.Yetki_Uyari(41);
                return;
            }

            try
            {
                if (Isler.Servis.Ver_AdetIsemirleri(_Secili_ServisID) > 0)
                {
                    XtraMessageBox.Show("Seçili Servise İşemri Girişi Yapılmış.\nServisi silmek için önce servisi eklenen işemirlerini siliniz.", "Servis Silme Yapılamıyor",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Burada fatura kontrol edilecek
                //Eğer iş emrine fatura kesilmiş ise silme işlemi yapılamayacak.
                if (XtraMessageBox.Show("Seçili Servisi Silmek İstediğinize Emin Misiniz?\n"
                   + "Servis No :" + servis.ServisID.ToString()
                   + "\nArac Plaka : " + ucAracDemo1.arc.Plaka
                   + "\nCari Ünvan : " + ucCariHesapDemo1.cari.Unvan, "İşemri Sil Onay",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(servis);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "İşemri Başarılı Bir Şekilde Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    if (DetayOlay != null)
                    {
                        this.Invoke(DetayOlay, Enumlar.DetayOlaylari.AramaGerekli, null);
                    }
                }
            }
            catch (Exception hata)
            {
                XtraMessageBox.Show("İşEmri Silme İşlemi Sırasında Bir Hata Oluştu.\n\nHata:\n" + hata.Message, "Hata",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Sil_Isemri()
        {
            if (ism == null) return;

            try
            {
                if (dt_Talepler != null && dt_Talepler.Rows.Count > 0)
                {
                    XtraMessageBox.Show("Seçili İşemrine Talep Girişi Yapılmış.\nİşemrini silmek için önce işemrine eklenen talepleri siliniz.", "İşemri Silme Yapılamıyor",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show("Seçili İşemrini Silmek İstediğinize Emin Misiniz?", "İşemri Sil Onay",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(ism);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "İşemri Başarılı Bir Şekilde Silinmiştir", null,
                          ResOtoSis.mark_blue);

                    Ara_Isemirleri(_Secili_ServisID);
                }
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Sil_Talep()
        {
            if (talep == null) return;

            try
            {
                if (Isler.Stok.Ver_AdetHareket(Secili_TalepID) > 0)
                {
                    XtraMessageBox.Show("Seçili Talebe Parça Girişi Yapılmış.\nTalebi silmek için önce talebe eklenen parçaları siliniz.", "Talep Silme Yapılamıyor",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Isler.Iscilik.Ver_AdetIscilik(Secili_TalepID) > 0)
                {
                    XtraMessageBox.Show("Seçili Talebe İşçilik Girişi Yapılmış.\nTalebi silmek için önce talebe eklenen işçilikleri siliniz.", "Talep Silme Yapılamıyor",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show("Seçili Talebi Silmek İstediğinize Emin Misiniz?", "Talep Sil Onay",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(talep);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Talep Başarılı Bir Şekilde Silinmiştir", null,
                          ResOtoSis.mark_blue);

                    Ara_Talepler(ism.IsemirID);
                }
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Sil_Parca()
        {
            if (parca == null || GridViewParcalar.GetFocusedRow() == null) return;

            try
            {
                if (XtraMessageBox.Show("Seçili Parçayı Listeden Silmek İstediğinize Emin Misiniz?\n"
                 + "Parça No : " + parca.StokKartID.ToString()
                 + "\nKalem Adı : " + GridViewParcalar.GetFocusedRowCellValue("KalemAdi").ToString(), "Parça Sil Onay",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dbModel.DeleteObject(parca);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "Parça Başarılı Bir Şekilde Listeden Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    Ara_Parcalar(Secili_TalepID);
                }
            }
            catch (Exception hata)
            {

                throw;
            }
        }
        void Sil_Iscilik()
        {
            if (isc_har == null || gridViewIscilikler.GetFocusedRow() == null) return;

            try
            {
                if (XtraMessageBox.Show("Seçili İşçiliği Listeden Silmek İstediğinize Emin Misiniz?\n"
                + "İşçilik No : " + isc_har.IscilikID.ToString()
                + "\nİşçilik Adı : " + gridViewIscilikler.GetFocusedRowCellValue("IscilikAd").ToString(), "İşçilik Sil Onay",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Isler.Iscilik.Sil_IscilikPersoneller(isc_har.ID);

                    dbModel.DeleteObject(isc_har);
                    dbModel.SaveChanges();

                    Genel.AlertMesaj.Show(Genel.AnaEkran, "İşlem Başarılı", "İşçilik Başarılı Bir Şekilde Listeden Silinmiştir", null,
                        ResOtoSis.mark_blue);

                    Ara_Iscilik(Secili_TalepID);
                }
            }
            catch (Exception hata)
            {

                throw;
            }
        }

        public void Yeni_Servis()
        {
            _YeniKayit = true;

            Temizle_Servis();
            spinServisKM.Focus(); spinServisKM.Select();

            pEnable(false);

            ucKayitBilgiServis.Temizle();

            tabServis.SelectedTabPageIndex = 0;

            dateServisGelisTarih.EditValue = DateTime.Now;

            if (DetayOlay != null)
            {
                this.Invoke(DetayOlay, Enumlar.DetayOlaylari.YeniKayit, null);
            }
        }
        void Yeni_Isemri()
        {
            YeniKayitIsemri = true;

            Temizle_Isemri();
            lookUpIsemriBirim.Focus(); lookUpIsemriBirim.Select();

            btnIsemriYazdir.Enabled = gridViewIsemri.OptionsSelection.EnableAppearanceFocusedRow = tabTalepDetaylar.Enabled
            = grupTalepler.Enabled = tabTalepDetaylar.Enabled = Focusta_Isemri = false;
        }
        void Yeni_Talep()
        {
            YeniKayitTalep = true;

            Temizle_Talep();
            memoTalep.Focus(); memoTalep.Select();

            tabTalepDetaylar.Enabled = false;
        }
        void Yeni_Parca()
        {
            YeniKayitParcalar = true;
            Focusta_Parca = GridViewParcalar.OptionsSelection.EnableAppearanceFocusedRow = false;

            Temizle_Parca();
            btnParcalarStokKart.Focus(); btnParcalarStokKart.Select();
        }
        void Yeni_Iscilik()
        {
            YeniKayitIscilik = true;

            Temizle_Iscilik();

            btnIscilikSec.Focus(); btnIscilikSec.Select();

            Ara_IscilikPersonel(-1);
        }

        void pEnable(bool deger)
        {
            //groupUyumluMarka.Enabled = deger;

            pageIsemirleri.PageEnabled = deger;

            if (!deger)
            {
                //dt_Markalar = null;
                tabServis.SelectedTabPageIndex = 0;
            }
        }
        void pEnable_IsemriUyari(bool deger)
        {
            btnTalepKaydet.Enabled = btnParcalarKaydet.Enabled = btnIscilikKaydet.Enabled
            = btnTalepSil.Enabled = btnParcalarSil.Enabled = btnIscilikSil.Enabled
            = btnTalepYeniKayit.Enabled = btnParcalarYeniKayit.Enabled = btnIscilikYeniKayit.Enabled
            = !deger;

            IsemriDuzenle = !deger;
        }
        #endregion

        private void btnParcalarStokKart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(btnParcalarStokKart.Text))
            {
                var parcaaaa = (from abc in dbModel.stok_kart
                                where abc.ParcaNo==btnParcalarStokKart.Text
                                select new
                                {
                                    abc.KartID,
                                    abc.KalemAdi,
                                    abc.SatisFiyat
                                }).FirstOrDefault();

                if (parcaaaa == null) return;

                btnParcalarStokKart.Tag = parcaaaa.KartID;
                btnParcalarStokKart.Text = parcaaaa.KalemAdi;

                spinBirimFiyat.Value = parcaaaa.SatisFiyat == null ? 0 : parcaaaa.SatisFiyat.Value;

                spinParcalarMiktar.Focus(); spinParcalarMiktar.Select();
            }
        }

        private void spinParcalarMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Kaydet_Parca();
            }
        }
    }
}