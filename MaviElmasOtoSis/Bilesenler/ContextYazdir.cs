using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MaviElmasOtoSis.Bilesenler
{
    public class ContextYazdir : ContextMenuStrip
    {
        #region < Yapıcı >
        public ContextYazdir()
        {
            ToolStripMenuItem menuYazdir = new ToolStripMenuItem("Yazdır", null, new EventHandler(Menu_Tiklandi));
            ToolStripSeparator ayirac = new ToolStripSeparator();
            ToolStripMenuItem menuXlsAktar = new ToolStripMenuItem("Xls Aktar", null, new EventHandler(Menu_Tiklandi));
            ToolStripMenuItem menuXlsXAktar = new ToolStripMenuItem("Xlsx Aktar", null, new EventHandler(Menu_Tiklandi));
            ToolStripMenuItem menuPdfAktar = new ToolStripMenuItem("Pdf Aktar", null, new EventHandler(Menu_Tiklandi));
            ToolStripMenuItem menuHtmtlAktar = new ToolStripMenuItem("Html Aktar", null, new EventHandler(Menu_Tiklandi));
            ToolStripMenuItem menuRtfAktar = new ToolStripMenuItem("Rtf Aktar", null, new EventHandler(Menu_Tiklandi));
            ToolStripMenuItem menuYaziAktar = new ToolStripMenuItem("Yazı Aktar", null, new EventHandler(Menu_Tiklandi));

            this.Items.Add(menuYazdir);
            this.Items.Add(ayirac);
            this.Items.Add(menuXlsAktar);
            this.Items.Add(menuXlsXAktar);
            this.Items.Add(menuPdfAktar);
            this.Items.Add(menuHtmtlAktar);
            this.Items.Add(menuRtfAktar);
            this.Items.Add(menuYaziAktar);
        }
        #endregion

        #region < Değişkenler >
        
        #endregion

        #region < Özellikler >
        public DevExpress.XtraGrid.Views.Grid.GridView KaynakView { get; set; }
        #endregion

        public void Menu_Tiklandi(object sender, EventArgs e)
        {
            string Yazi = ((ToolStripMenuItem)sender).Text;

            if (Yazi == "Yazdır")
            {
                KaynakView.GridControl.ShowPrintPreview();
            }
            else
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    if (Yazi == "Xls Aktar")
                    {
                        sfd.Filter = "Excel Dosyası (*.xls)|*.xls";
                    }
                    else if (Yazi == "Xlsx Aktar")
                    {
                        sfd.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                    }
                    else if (Yazi == "Pdf Aktar")
                    {
                        sfd.Filter = "Pdf Dosyası (*.pdf)|*.pdf";
                    }
                    else if (Yazi == "Html Aktar")
                    {
                        sfd.Filter = "Html Dosyası (*.html)|*.html";
                    }
                    else if (Yazi == "Rtf Aktar")
                    {
                        sfd.Filter = "Rtf Dosyası (*.rtf)|*.rtf";
                    }
                    else if (Yazi == "Yazı Aktar")
                    {
                        sfd.Filter = "Yazı Dosyası (*.txt)|*.txt";
                    }

                    string dosyaAdi = "";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        dosyaAdi = sfd.FileName;

                        if (Yazi == "Xls Aktar")
                        {
                            KaynakView.ExportToXls(dosyaAdi);
                        }
                        else if (Yazi == "Xlsx Aktar")
                        {
                            KaynakView.ExportToXlsx(dosyaAdi);
                        }
                        else if (Yazi == "Pdf Aktar")
                        {
                            KaynakView.ExportToPdf(dosyaAdi);
                        }
                        else if (Yazi == "Html Aktar")
                        {
                            KaynakView.ExportToHtml(dosyaAdi);
                        }
                        else if (Yazi == "Rtf Aktar")
                        {
                            KaynakView.ExportToRtf(dosyaAdi);
                        }
                        else if (Yazi == "Yazı Aktar")
                        {
                            KaynakView.ExportToText(dosyaAdi);
                        }

                        XtraMessageBox.Show("İçerik Başarılı Bir Şekilde Dışarı Aktarıldı.", "İşlem Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            //switch (Yazi)
            //{
            //    case "Yazdır":
            //        KaynakView.GridControl.ShowPrintPreview();
            //        break;
            //    case "Xls Aktar":
            //        KaynakView.ExportToXls("");
            //        break;
            //    case "Xlsx Aktar":
            //        break;
            //    case "Pdf Aktar":
            //        break;
            //    case "Html Aktar":
            //        break;
            //    case "Rtf Aktar":
            //        break;
            //    case "Yazı Aktar":
            //        break;
            //}
        }
    }
}