namespace MaviElmasOtoSis.Muhasebe
{
    partial class ucCariHesap
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCariHesap));
            this.gridControlCariler = new DevExpress.XtraGrid.GridControl();
            this.GridViewCariler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCariID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnvan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCariHesapGrup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTcKimlikNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlacak = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBakiye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYetkiliKisi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucDetay1 = new MaviElmasOtoSis.Muhasebe.ucCariHesapDetay();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            this.tabCari = new DevExpress.XtraTab.XtraTabControl();
            this.pageCariBilgiler = new DevExpress.XtraTab.XtraTabPage();
            this.pageCariHareketler = new DevExpress.XtraTab.XtraTabPage();
            this.ucCariHareketler1 = new MaviElmasOtoSis.Muhasebe.ucCariHareketler();
            this.colTel1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTel2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCariler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCariler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCari)).BeginInit();
            this.tabCari.SuspendLayout();
            this.pageCariBilgiler.SuspendLayout();
            this.pageCariHareketler.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlCariler
            // 
            this.gridControlCariler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlCariler.Location = new System.Drawing.Point(0, 0);
            this.gridControlCariler.MainView = this.GridViewCariler;
            this.gridControlCariler.Name = "gridControlCariler";
            this.gridControlCariler.Size = new System.Drawing.Size(926, 268);
            this.gridControlCariler.TabIndex = 231;
            this.gridControlCariler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewCariler});
            // 
            // GridViewCariler
            // 
            this.GridViewCariler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCariID,
            this.colUnvan,
            this.colCariHesapGrup,
            this.colTcKimlikNo,
            this.colBorc,
            this.colAlacak,
            this.colBakiye,
            this.colYetkiliKisi,
            this.colDurum,
            this.colTel1,
            this.colTel2});
            this.GridViewCariler.GridControl = this.gridControlCariler;
            this.GridViewCariler.Name = "GridViewCariler";
            this.GridViewCariler.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewCariler.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewCariler.OptionsBehavior.Editable = false;
            this.GridViewCariler.OptionsBehavior.ReadOnly = true;
            this.GridViewCariler.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewCariler.OptionsView.ShowAutoFilterRow = true;
            this.GridViewCariler.OptionsView.ShowViewCaption = true;
            this.GridViewCariler.ViewCaption = "Cari Hesaplar Listesi";
            this.GridViewCariler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewCariler_FocusedRowChanged);
            this.GridViewCariler.Click += new System.EventHandler(this.GridViewCariler_Click);
            // 
            // colCariID
            // 
            this.colCariID.AppearanceCell.Options.UseTextOptions = true;
            this.colCariID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCariID.Caption = "Cari No";
            this.colCariID.FieldName = "CariID";
            this.colCariID.MaxWidth = 50;
            this.colCariID.Name = "colCariID";
            this.colCariID.Visible = true;
            this.colCariID.VisibleIndex = 0;
            this.colCariID.Width = 50;
            // 
            // colUnvan
            // 
            this.colUnvan.Caption = "Ünvanı";
            this.colUnvan.FieldName = "Unvan";
            this.colUnvan.Name = "colUnvan";
            this.colUnvan.Visible = true;
            this.colUnvan.VisibleIndex = 1;
            this.colUnvan.Width = 124;
            // 
            // colCariHesapGrup
            // 
            this.colCariHesapGrup.Caption = "Cari Grubu";
            this.colCariHesapGrup.FieldName = "CariHesapGrup";
            this.colCariHesapGrup.Name = "colCariHesapGrup";
            this.colCariHesapGrup.Visible = true;
            this.colCariHesapGrup.VisibleIndex = 2;
            this.colCariHesapGrup.Width = 124;
            // 
            // colTcKimlikNo
            // 
            this.colTcKimlikNo.Caption = "TC Kimlik No / Vergi No";
            this.colTcKimlikNo.FieldName = "TcKimlikNo";
            this.colTcKimlikNo.Name = "colTcKimlikNo";
            this.colTcKimlikNo.Visible = true;
            this.colTcKimlikNo.VisibleIndex = 3;
            // 
            // colBorc
            // 
            this.colBorc.Caption = "Toplam Borç";
            this.colBorc.FieldName = "Borc";
            this.colBorc.MaxWidth = 80;
            this.colBorc.MinWidth = 80;
            this.colBorc.Name = "colBorc";
            this.colBorc.Visible = true;
            this.colBorc.VisibleIndex = 4;
            this.colBorc.Width = 80;
            // 
            // colAlacak
            // 
            this.colAlacak.Caption = "Toplam Alacak";
            this.colAlacak.FieldName = "Alacak";
            this.colAlacak.MaxWidth = 80;
            this.colAlacak.MinWidth = 80;
            this.colAlacak.Name = "colAlacak";
            this.colAlacak.Visible = true;
            this.colAlacak.VisibleIndex = 5;
            this.colAlacak.Width = 80;
            // 
            // colBakiye
            // 
            this.colBakiye.Caption = "Bakiye";
            this.colBakiye.FieldName = "Bakiye";
            this.colBakiye.MaxWidth = 60;
            this.colBakiye.MinWidth = 60;
            this.colBakiye.Name = "colBakiye";
            this.colBakiye.Visible = true;
            this.colBakiye.VisibleIndex = 6;
            this.colBakiye.Width = 60;
            // 
            // colYetkiliKisi
            // 
            this.colYetkiliKisi.Caption = "Yetkili Kişi";
            this.colYetkiliKisi.FieldName = "YetkiliKisi";
            this.colYetkiliKisi.Name = "colYetkiliKisi";
            this.colYetkiliKisi.Visible = true;
            this.colYetkiliKisi.VisibleIndex = 7;
            // 
            // colDurum
            // 
            this.colDurum.Caption = "Durumu";
            this.colDurum.FieldName = "Durum";
            this.colDurum.Name = "colDurum";
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 8;
            // 
            // ucDetay1
            // 
            this.ucDetay1.DetayMode = MaviElmasOtoSis.Enumlar.DetayModelari.Tum;
            this.ucDetay1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucDetay1.Location = new System.Drawing.Point(0, 272);
            this.ucDetay1.Name = "ucDetay1";
            this.ucDetay1.Size = new System.Drawing.Size(926, 239);
            this.ucDetay1.TabIndex = 232;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(871, 273);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 258;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnYazdir1
            // 
            this.btnYazdir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYazdir1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYazdir1.Image = ((System.Drawing.Image)(resources.GetObject("btnYazdir1.Image")));
            this.btnYazdir1.KaynakView = this.GridViewCariler;
            this.btnYazdir1.Location = new System.Drawing.Point(803, 274);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 274;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // tabCari
            // 
            this.tabCari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCari.Location = new System.Drawing.Point(0, 0);
            this.tabCari.Name = "tabCari";
            this.tabCari.SelectedTabPage = this.pageCariBilgiler;
            this.tabCari.Size = new System.Drawing.Size(932, 539);
            this.tabCari.TabIndex = 275;
            this.tabCari.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageCariBilgiler,
            this.pageCariHareketler});
            this.tabCari.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabCari_SelectedPageChanged);
            // 
            // pageCariBilgiler
            // 
            this.pageCariBilgiler.Controls.Add(this.btnYenile);
            this.pageCariBilgiler.Controls.Add(this.gridControlCariler);
            this.pageCariBilgiler.Controls.Add(this.btnYazdir1);
            this.pageCariBilgiler.Controls.Add(this.ucDetay1);
            this.pageCariBilgiler.Name = "pageCariBilgiler";
            this.pageCariBilgiler.Size = new System.Drawing.Size(926, 511);
            this.pageCariBilgiler.Text = "Cari Bilgiler";
            // 
            // pageCariHareketler
            // 
            this.pageCariHareketler.Controls.Add(this.ucCariHareketler1);
            this.pageCariHareketler.Name = "pageCariHareketler";
            this.pageCariHareketler.Size = new System.Drawing.Size(926, 511);
            this.pageCariHareketler.Text = "Cari Hareketler";
            // 
            // ucCariHareketler1
            // 
            this.ucCariHareketler1.CariID = 0;
            this.ucCariHareketler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCariHareketler1.Location = new System.Drawing.Point(0, 0);
            this.ucCariHareketler1.Name = "ucCariHareketler1";
            this.ucCariHareketler1.Size = new System.Drawing.Size(926, 511);
            this.ucCariHareketler1.TabIndex = 0;
            // 
            // colTel1
            // 
            this.colTel1.Caption = "Tel 1";
            this.colTel1.FieldName = "Tel1";
            this.colTel1.Name = "colTel1";
            this.colTel1.Visible = true;
            this.colTel1.VisibleIndex = 9;
            // 
            // colTel2
            // 
            this.colTel2.Caption = "Tel 2";
            this.colTel2.FieldName = "Tel2";
            this.colTel2.Name = "colTel2";
            this.colTel2.Visible = true;
            this.colTel2.VisibleIndex = 10;
            // 
            // ucCariHesap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCari);
            this.Name = "ucCariHesap";
            this.Size = new System.Drawing.Size(932, 539);
            this.Load += new System.EventHandler(this.ucCariHesap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCariler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCariler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCari)).EndInit();
            this.tabCari.ResumeLayout(false);
            this.pageCariBilgiler.ResumeLayout(false);
            this.pageCariHareketler.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCariler;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewCariler;
        private DevExpress.XtraGrid.Columns.GridColumn colCariID;
        private DevExpress.XtraGrid.Columns.GridColumn colUnvan;
        private DevExpress.XtraGrid.Columns.GridColumn colCariHesapGrup;
        private DevExpress.XtraGrid.Columns.GridColumn colTcKimlikNo;
        private DevExpress.XtraGrid.Columns.GridColumn colYetkiliKisi;
        private ucCariHesapDetay ucDetay1;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
        private Bilesenler.btnYazdir btnYazdir1;
        private DevExpress.XtraGrid.Columns.GridColumn colBorc;
        private DevExpress.XtraGrid.Columns.GridColumn colAlacak;
        private DevExpress.XtraGrid.Columns.GridColumn colBakiye;
        private DevExpress.XtraTab.XtraTabControl tabCari;
        private DevExpress.XtraTab.XtraTabPage pageCariBilgiler;
        private DevExpress.XtraTab.XtraTabPage pageCariHareketler;
        private ucCariHareketler ucCariHareketler1;
        private DevExpress.XtraGrid.Columns.GridColumn colTel1;
        private DevExpress.XtraGrid.Columns.GridColumn colTel2;
    }
}
