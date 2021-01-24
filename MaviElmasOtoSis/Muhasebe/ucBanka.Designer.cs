namespace MaviElmasOtoSis.Muhasebe
{
    partial class ucBanka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBanka));
            this.gridControlBankalar = new DevExpress.XtraGrid.GridControl();
            this.GridViewBankalar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBankaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankaAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesapTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYatirilan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCekilen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBakiye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIlgiliKisi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            this.tabBanka = new DevExpress.XtraTab.XtraTabControl();
            this.pageBankaTanim = new DevExpress.XtraTab.XtraTabPage();
            this.pageBankaHareketleri = new DevExpress.XtraTab.XtraTabPage();
            this.ucBankaHareket1 = new MaviElmasOtoSis.Muhasebe.ucBankaHareket();
            this.ucBankaDetay1 = new MaviElmasOtoSis.Muhasebe.ucBankaDetay();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBankalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewBankalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabBanka)).BeginInit();
            this.tabBanka.SuspendLayout();
            this.pageBankaTanim.SuspendLayout();
            this.pageBankaHareketleri.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlBankalar
            // 
            this.gridControlBankalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlBankalar.Location = new System.Drawing.Point(0, 0);
            this.gridControlBankalar.MainView = this.GridViewBankalar;
            this.gridControlBankalar.Name = "gridControlBankalar";
            this.gridControlBankalar.Size = new System.Drawing.Size(934, 263);
            this.gridControlBankalar.TabIndex = 232;
            this.gridControlBankalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewBankalar});
            // 
            // GridViewBankalar
            // 
            this.GridViewBankalar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBankaID,
            this.colBankaAd,
            this.colHesapTuru,
            this.colYatirilan,
            this.colCekilen,
            this.colBakiye,
            this.colIlgiliKisi,
            this.colDurum});
            this.GridViewBankalar.GridControl = this.gridControlBankalar;
            this.GridViewBankalar.Name = "GridViewBankalar";
            this.GridViewBankalar.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewBankalar.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewBankalar.OptionsBehavior.Editable = false;
            this.GridViewBankalar.OptionsBehavior.ReadOnly = true;
            this.GridViewBankalar.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewBankalar.OptionsView.ShowAutoFilterRow = true;
            this.GridViewBankalar.OptionsView.ShowViewCaption = true;
            this.GridViewBankalar.ViewCaption = "Bankalar Listesi";
            this.GridViewBankalar.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewBankalar_FocusedRowChanged);
            this.GridViewBankalar.Click += new System.EventHandler(this.GridViewBankalar_Click);
            // 
            // colBankaID
            // 
            this.colBankaID.AppearanceCell.Options.UseTextOptions = true;
            this.colBankaID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colBankaID.Caption = "Banka No";
            this.colBankaID.FieldName = "BankaID";
            this.colBankaID.MaxWidth = 60;
            this.colBankaID.MinWidth = 55;
            this.colBankaID.Name = "colBankaID";
            this.colBankaID.Visible = true;
            this.colBankaID.VisibleIndex = 0;
            this.colBankaID.Width = 60;
            // 
            // colBankaAd
            // 
            this.colBankaAd.Caption = "Banka Adı";
            this.colBankaAd.FieldName = "BankaAd";
            this.colBankaAd.Name = "colBankaAd";
            this.colBankaAd.Visible = true;
            this.colBankaAd.VisibleIndex = 1;
            this.colBankaAd.Width = 253;
            // 
            // colHesapTuru
            // 
            this.colHesapTuru.Caption = "Hesap Türü";
            this.colHesapTuru.FieldName = "HesapTuru";
            this.colHesapTuru.MaxWidth = 80;
            this.colHesapTuru.MinWidth = 75;
            this.colHesapTuru.Name = "colHesapTuru";
            this.colHesapTuru.Visible = true;
            this.colHesapTuru.VisibleIndex = 2;
            // 
            // colYatirilan
            // 
            this.colYatirilan.Caption = "Toplam Yatırılan";
            this.colYatirilan.FieldName = "Yatirilan";
            this.colYatirilan.MaxWidth = 90;
            this.colYatirilan.MinWidth = 90;
            this.colYatirilan.Name = "colYatirilan";
            this.colYatirilan.Visible = true;
            this.colYatirilan.VisibleIndex = 3;
            this.colYatirilan.Width = 90;
            // 
            // colCekilen
            // 
            this.colCekilen.Caption = "Toplam Çekilen";
            this.colCekilen.FieldName = "Cekilen";
            this.colCekilen.MaxWidth = 90;
            this.colCekilen.MinWidth = 90;
            this.colCekilen.Name = "colCekilen";
            this.colCekilen.Visible = true;
            this.colCekilen.VisibleIndex = 4;
            this.colCekilen.Width = 90;
            // 
            // colBakiye
            // 
            this.colBakiye.Caption = "Bakiye";
            this.colBakiye.FieldName = "Bakiye";
            this.colBakiye.MaxWidth = 80;
            this.colBakiye.MinWidth = 80;
            this.colBakiye.Name = "colBakiye";
            this.colBakiye.Visible = true;
            this.colBakiye.VisibleIndex = 5;
            this.colBakiye.Width = 80;
            // 
            // colIlgiliKisi
            // 
            this.colIlgiliKisi.Caption = "İlgili Kişi";
            this.colIlgiliKisi.FieldName = "IlgiliKisi";
            this.colIlgiliKisi.MaxWidth = 180;
            this.colIlgiliKisi.MinWidth = 100;
            this.colIlgiliKisi.Name = "colIlgiliKisi";
            this.colIlgiliKisi.Visible = true;
            this.colIlgiliKisi.VisibleIndex = 6;
            this.colIlgiliKisi.Width = 120;
            // 
            // colDurum
            // 
            this.colDurum.Caption = "Durumu";
            this.colDurum.FieldName = "Durum";
            this.colDurum.MaxWidth = 60;
            this.colDurum.MinWidth = 50;
            this.colDurum.Name = "colDurum";
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 7;
            this.colDurum.Width = 60;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(882, 262);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 276;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnYazdir1
            // 
            this.btnYazdir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYazdir1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYazdir1.Image = ((System.Drawing.Image)(resources.GetObject("btnYazdir1.Image")));
            this.btnYazdir1.KaynakView = this.GridViewBankalar;
            this.btnYazdir1.Location = new System.Drawing.Point(814, 263);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 275;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // tabBanka
            // 
            this.tabBanka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBanka.Location = new System.Drawing.Point(0, 0);
            this.tabBanka.Name = "tabBanka";
            this.tabBanka.SelectedTabPage = this.pageBankaTanim;
            this.tabBanka.Size = new System.Drawing.Size(946, 583);
            this.tabBanka.TabIndex = 277;
            this.tabBanka.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageBankaTanim,
            this.pageBankaHareketleri});
            this.tabBanka.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabBanka_SelectedPageChanged);
            // 
            // pageBankaTanim
            // 
            this.pageBankaTanim.Controls.Add(this.btnYenile);
            this.pageBankaTanim.Controls.Add(this.btnYazdir1);
            this.pageBankaTanim.Controls.Add(this.ucBankaDetay1);
            this.pageBankaTanim.Controls.Add(this.gridControlBankalar);
            this.pageBankaTanim.Name = "pageBankaTanim";
            this.pageBankaTanim.Size = new System.Drawing.Size(940, 557);
            this.pageBankaTanim.Text = "Banka Bilgileri";
            // 
            // pageBankaHareketleri
            // 
            this.pageBankaHareketleri.Controls.Add(this.ucBankaHareket1);
            this.pageBankaHareketleri.Name = "pageBankaHareketleri";
            this.pageBankaHareketleri.PageEnabled = false;
            this.pageBankaHareketleri.Size = new System.Drawing.Size(940, 557);
            this.pageBankaHareketleri.Text = "Banka Hareketleri";
            // 
            // ucBankaHareket1
            // 
            this.ucBankaHareket1.BankaID = 0;
            this.ucBankaHareket1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBankaHareket1.Location = new System.Drawing.Point(0, 0);
            this.ucBankaHareket1.Name = "ucBankaHareket1";
            this.ucBankaHareket1.Size = new System.Drawing.Size(940, 557);
            this.ucBankaHareket1.TabIndex = 0;
            // 
            // ucBankaDetay1
            // 
            this.ucBankaDetay1.DetayMode = MaviElmasOtoSis.Enumlar.DetayModelari.Tum;
            this.ucBankaDetay1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucBankaDetay1.Location = new System.Drawing.Point(0, 269);
            this.ucBankaDetay1.Name = "ucBankaDetay1";
            this.ucBankaDetay1.Size = new System.Drawing.Size(940, 288);
            this.ucBankaDetay1.TabIndex = 277;
            // 
            // ucBanka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabBanka);
            this.Name = "ucBanka";
            this.Size = new System.Drawing.Size(946, 583);
            this.Load += new System.EventHandler(this.ucBanka_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBankalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewBankalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabBanka)).EndInit();
            this.tabBanka.ResumeLayout(false);
            this.pageBankaTanim.ResumeLayout(false);
            this.pageBankaHareketleri.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlBankalar;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewBankalar;
        private DevExpress.XtraGrid.Columns.GridColumn colBankaID;
        private DevExpress.XtraGrid.Columns.GridColumn colBankaAd;
        private DevExpress.XtraGrid.Columns.GridColumn colHesapTuru;
        private DevExpress.XtraGrid.Columns.GridColumn colIlgiliKisi;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.btnYazdir btnYazdir1;
        private DevExpress.XtraGrid.Columns.GridColumn colYatirilan;
        private DevExpress.XtraGrid.Columns.GridColumn colCekilen;
        private DevExpress.XtraGrid.Columns.GridColumn colBakiye;
        private DevExpress.XtraTab.XtraTabControl tabBanka;
        private DevExpress.XtraTab.XtraTabPage pageBankaTanim;
        private DevExpress.XtraTab.XtraTabPage pageBankaHareketleri;
        private ucBankaHareket ucBankaHareket1;
        private ucBankaDetay ucBankaDetay1;
    }
}
