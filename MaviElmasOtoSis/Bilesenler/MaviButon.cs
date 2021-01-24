using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Drawing;

namespace MaviElmasOtoSis.Bilesenler
{
    public class MaviButon : SimpleButton
    {
        #region < Yapıcı >
        public MaviButon()
        {
            this.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this._ButonCesidi = ButonCesitleri.Kaydet;
            this.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.Cursor = System.Windows.Forms.Cursors.Hand;

            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BlueButon_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BlueButon_MouseUp);
            this.MouseLeave += new System.EventHandler(this.BlueButon_MouseLeave);
        }
        #endregion

        #region < Değişkenler >
        public enum ButonCesitleri
        {
            Kaydet,
            Yeni,
            Sil,
            Yazdir,
            Ara,
            SifreSifirla,
            TalebiGeriAl,
            Yonlendir,
            TalebiReddet,
            Temizle,
            Iptal,
            Cikis,
            Sec,
            Tamam,
            Sonuclandir,
            TalepKarsilanamadi,
            Raporlar,
            WebSifreSifirla
        }

        public enum ButonDurumlari
        {
            Press,
            Hover,
            Normal
        }
        #endregion

        #region < Özellikler >
        ButonCesitleri _ButonCesidi;
        public ButonCesitleri ButonCesidi
        {
            get
            {
                return _ButonCesidi;
            }
            set
            {
                _ButonCesidi = value;
                ResimDegistir(ButonDurumlari.Normal);
            }
        }
        #endregion

        #region < Olaylar >
        private void BlueButon_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ResimDegistir(ButonDurumlari.Press);
        }

        private void BlueButon_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ResimDegistir(ButonDurumlari.Normal);
        }
        #endregion

        #region < Metodlar >
        public void ResimDegistir(ButonDurumlari butondurumu)
        {
            switch (_ButonCesidi)
            {
                case ButonCesitleri.Kaydet:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.kaydet;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.kaydetHover;

                    this.Size = new Size(92, 25);
                    this.ToolTip = "F2 - Kaydet";
                    break;
                case ButonCesitleri.Yeni:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.YeniKayit;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.YeniKayitHover;

                    this.Size = new Size(110, 25);
                    this.ToolTip = "F3 - Yeni Kayıt";
                    break;
                case ButonCesitleri.Sil:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.sil;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.silHover;

                    this.Size = new Size(70, 25);
                    this.ToolTip = "Del - Sil";
                    break;
                case ButonCesitleri.Yazdir:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.yazdir;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.yazdirHover;

                    this.Size = new Size(90, 25);
                    break;
                case ButonCesitleri.Ara:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.ara;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.araHover;

                    this.Size = new Size(70, 25);
                    break;
                case ButonCesitleri.SifreSifirla:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.sifreyi_hatirla;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.sifreyi_hatirlaHover;

                    this.Size = new Size(130, 25);
                    break;
                case ButonCesitleri.TalebiGeriAl:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.talebiGeriAl;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.TalebiGeriAlHover;

                    this.Size = new Size(130, 25);
                    break;
                case ButonCesitleri.Yonlendir:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.yonlendir;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.yonlendirHover;

                    this.Size = new Size(106, 25);
                    break;
                case ButonCesitleri.TalebiReddet:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.TalebiRedEt;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.TalebiRedetHover;

                    this.Size = new Size(130, 25);
                    break;
                case ButonCesitleri.Temizle:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.Temizle;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.TemizleHover;

                    this.Size = new Size(97, 25);
                    break;
                case ButonCesitleri.Iptal:
                     if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.iptal;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.iptalHover;

                    this.Size = new Size(80, 25);
                    break;
                case ButonCesitleri.Cikis:
                     if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.cikis;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.cikisHover;

                    this.Size = new Size(80, 25);
                    break;
                case ButonCesitleri.Sec:
                      if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.sec;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.sec;

                    this.Size = new Size(76, 25);
                    break;
                case ButonCesitleri.Tamam:
                      if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.tamam;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.tamamHover;

                    this.Size = new Size(97, 25);
                    break;
                case ButonCesitleri.Sonuclandir:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.sonuclandir;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.sonuclandirhover;

                    this.Size = new Size(125, 25);
                    break;
                case ButonCesitleri.TalepKarsilanamadi:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.talepKarsilanamadi;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.talepKarsilanamadiHOVER;

                    this.Size = new Size(176, 25);
                    break;
                case ButonCesitleri.Raporlar:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.Raporlar;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.RaporlarHover;

                    this.Size = new Size(100, 25);
                    break;
                case ButonCesitleri.WebSifreSifirla:
                    if (butondurumu == ButonDurumlari.Normal)
                        this.Image = ResButon.websifreSifirla;
                    else if (butondurumu == ButonDurumlari.Press)
                        this.Image = ResButon.WEbSifreSifirlaHOVER;

                    this.Size = new Size(160, 25);
                    break;
            }
        }
        #endregion

        private void BlueButon_MouseLeave(object sender, EventArgs e)
        {
            ResimDegistir(ButonDurumlari.Normal);
        }
    }
}