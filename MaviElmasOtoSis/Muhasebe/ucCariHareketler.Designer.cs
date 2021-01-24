namespace MaviElmasOtoSis.Muhasebe
{
    partial class ucCariHareketler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCariHareketler));
            this.gridControlCariHareket = new DevExpress.XtraGrid.GridControl();
            this.gridViewCariHareket = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEvrakTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIslemTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEvrakNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorcTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlacakTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBakiye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKasaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKasaAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankaAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSearchLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateKayitBit = new DevExpress.XtraEditors.DateEdit();
            this.dateKayitBas = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblBorc = new DevExpress.XtraEditors.LabelControl();
            this.lblAlacak = new DevExpress.XtraEditors.LabelControl();
            this.lblBakiye = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCariHareket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCariHareket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlCariHareket
            // 
            this.gridControlCariHareket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlCariHareket.Location = new System.Drawing.Point(3, -1);
            this.gridControlCariHareket.MainView = this.gridViewCariHareket;
            this.gridControlCariHareket.Name = "gridControlCariHareket";
            this.gridControlCariHareket.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSearchLookUpEdit1});
            this.gridControlCariHareket.Size = new System.Drawing.Size(950, 336);
            this.gridControlCariHareket.TabIndex = 277;
            this.gridControlCariHareket.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCariHareket});
            // 
            // gridViewCariHareket
            // 
            this.gridViewCariHareket.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colEvrakTarih,
            this.colIslemTuru,
            this.colEvrakNo,
            this.colBorcTutar,
            this.colAlacakTutar,
            this.colBakiye,
            this.colKasaID,
            this.colKasaAd,
            this.colFaturaID,
            this.colBankaID,
            this.colBankaAd});
            this.gridViewCariHareket.GridControl = this.gridControlCariHareket;
            this.gridViewCariHareket.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridViewCariHareket.Name = "gridViewCariHareket";
            this.gridViewCariHareket.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCariHareket.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCariHareket.OptionsBehavior.Editable = false;
            this.gridViewCariHareket.OptionsBehavior.ReadOnly = true;
            this.gridViewCariHareket.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewCariHareket.OptionsView.ShowAutoFilterRow = true;
            this.gridViewCariHareket.OptionsView.ShowGroupPanel = false;
            this.gridViewCariHareket.ViewCaption = "Cari Hareket Listesi";
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colID.Caption = "H. No";
            this.colID.FieldName = "ID";
            this.colID.MaxWidth = 60;
            this.colID.MinWidth = 40;
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 40;
            // 
            // colEvrakTarih
            // 
            this.colEvrakTarih.Caption = "Evrak Tarihi";
            this.colEvrakTarih.DisplayFormat.FormatString = "d";
            this.colEvrakTarih.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEvrakTarih.FieldName = "EvrakTarih";
            this.colEvrakTarih.MaxWidth = 110;
            this.colEvrakTarih.MinWidth = 95;
            this.colEvrakTarih.Name = "colEvrakTarih";
            this.colEvrakTarih.Visible = true;
            this.colEvrakTarih.VisibleIndex = 1;
            this.colEvrakTarih.Width = 95;
            // 
            // colIslemTuru
            // 
            this.colIslemTuru.Caption = "İşlem Türü";
            this.colIslemTuru.FieldName = "IslemTuru";
            this.colIslemTuru.MaxWidth = 150;
            this.colIslemTuru.MinWidth = 120;
            this.colIslemTuru.Name = "colIslemTuru";
            this.colIslemTuru.Visible = true;
            this.colIslemTuru.VisibleIndex = 2;
            this.colIslemTuru.Width = 120;
            // 
            // colEvrakNo
            // 
            this.colEvrakNo.Caption = "Evrak No";
            this.colEvrakNo.FieldName = "EvrakNo";
            this.colEvrakNo.MaxWidth = 100;
            this.colEvrakNo.MinWidth = 60;
            this.colEvrakNo.Name = "colEvrakNo";
            this.colEvrakNo.Visible = true;
            this.colEvrakNo.VisibleIndex = 3;
            this.colEvrakNo.Width = 60;
            // 
            // colBorcTutar
            // 
            this.colBorcTutar.Caption = "Borç";
            this.colBorcTutar.FieldName = "BorcTutar";
            this.colBorcTutar.MaxWidth = 80;
            this.colBorcTutar.MinWidth = 80;
            this.colBorcTutar.Name = "colBorcTutar";
            this.colBorcTutar.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBorcTutar.Visible = true;
            this.colBorcTutar.VisibleIndex = 4;
            this.colBorcTutar.Width = 80;
            // 
            // colAlacakTutar
            // 
            this.colAlacakTutar.Caption = "Alacak";
            this.colAlacakTutar.FieldName = "AlacakTutar";
            this.colAlacakTutar.MaxWidth = 80;
            this.colAlacakTutar.MinWidth = 80;
            this.colAlacakTutar.Name = "colAlacakTutar";
            this.colAlacakTutar.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colAlacakTutar.Visible = true;
            this.colAlacakTutar.VisibleIndex = 5;
            this.colAlacakTutar.Width = 80;
            // 
            // colBakiye
            // 
            this.colBakiye.Caption = "Bakiye";
            this.colBakiye.FieldName = "BakiyeMiktar";
            this.colBakiye.MaxWidth = 80;
            this.colBakiye.MinWidth = 80;
            this.colBakiye.Name = "colBakiye";
            // 
            // colKasaID
            // 
            this.colKasaID.Caption = "Kasa No";
            this.colKasaID.FieldName = "KasaID";
            this.colKasaID.MaxWidth = 50;
            this.colKasaID.MinWidth = 50;
            this.colKasaID.Name = "colKasaID";
            this.colKasaID.Visible = true;
            this.colKasaID.VisibleIndex = 6;
            this.colKasaID.Width = 50;
            // 
            // colKasaAd
            // 
            this.colKasaAd.Caption = "Kasa Adı";
            this.colKasaAd.FieldName = "KasaAd";
            this.colKasaAd.MaxWidth = 100;
            this.colKasaAd.MinWidth = 80;
            this.colKasaAd.Name = "colKasaAd";
            this.colKasaAd.Visible = true;
            this.colKasaAd.VisibleIndex = 7;
            this.colKasaAd.Width = 80;
            // 
            // colFaturaID
            // 
            this.colFaturaID.Caption = "Fatura No";
            this.colFaturaID.FieldName = "FaturaID";
            this.colFaturaID.MaxWidth = 65;
            this.colFaturaID.MinWidth = 50;
            this.colFaturaID.Name = "colFaturaID";
            this.colFaturaID.Visible = true;
            this.colFaturaID.VisibleIndex = 9;
            this.colFaturaID.Width = 60;
            // 
            // colBankaID
            // 
            this.colBankaID.Caption = "Banka No";
            this.colBankaID.FieldName = "BankaID";
            this.colBankaID.MaxWidth = 65;
            this.colBankaID.MinWidth = 60;
            this.colBankaID.Name = "colBankaID";
            this.colBankaID.Visible = true;
            this.colBankaID.VisibleIndex = 8;
            this.colBankaID.Width = 60;
            // 
            // colBankaAd
            // 
            this.colBankaAd.Caption = "Banka Adı";
            this.colBankaAd.FieldName = "BankaAd";
            this.colBankaAd.MinWidth = 100;
            this.colBankaAd.Name = "colBankaAd";
            this.colBankaAd.Visible = true;
            this.colBankaAd.VisibleIndex = 10;
            this.colBankaAd.Width = 100;
            // 
            // repositoryItemSearchLookUpEdit1
            // 
            this.repositoryItemSearchLookUpEdit1.AutoHeight = false;
            this.repositoryItemSearchLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEdit1.Name = "repositoryItemSearchLookUpEdit1";
            this.repositoryItemSearchLookUpEdit1.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // btnYazdir1
            // 
            this.btnYazdir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnYazdir1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYazdir1.Image = ((System.Drawing.Image)(resources.GetObject("btnYazdir1.Image")));
            this.btnYazdir1.KaynakView = this.gridViewCariHareket;
            this.btnYazdir1.Location = new System.Drawing.Point(351, 345);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 278;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(290, 345);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 279;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Location = new System.Drawing.Point(6, 347);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 16);
            this.labelControl2.TabIndex = 282;
            this.labelControl2.Text = "İşlem Tarihi :";
            // 
            // dateKayitBit
            // 
            this.dateKayitBit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateKayitBit.EditValue = null;
            this.dateKayitBit.Location = new System.Drawing.Point(196, 344);
            this.dateKayitBit.Name = "dateKayitBit";
            this.dateKayitBit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateKayitBit.Properties.Appearance.Options.UseFont = true;
            this.dateKayitBit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKayitBit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.dateKayitBit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateKayitBit.Properties.EditFormat.FormatString = "dd.MM.yyyy";
            this.dateKayitBit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateKayitBit.Properties.Mask.EditMask = "dd.MM.yyyy";
            this.dateKayitBit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateKayitBit.Size = new System.Drawing.Size(88, 22);
            this.dateKayitBit.TabIndex = 281;
            // 
            // dateKayitBas
            // 
            this.dateKayitBas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateKayitBas.EditValue = null;
            this.dateKayitBas.Location = new System.Drawing.Point(89, 345);
            this.dateKayitBas.Name = "dateKayitBas";
            this.dateKayitBas.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateKayitBas.Properties.Appearance.Options.UseFont = true;
            this.dateKayitBas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKayitBas.Properties.Mask.EditMask = "g";
            this.dateKayitBas.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateKayitBas.Size = new System.Drawing.Size(88, 22);
            this.dateKayitBas.TabIndex = 280;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Location = new System.Drawing.Point(183, 341);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(7, 23);
            this.labelControl1.TabIndex = 283;
            this.labelControl1.Text = "/";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Location = new System.Drawing.Point(507, 348);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(81, 16);
            this.labelControl3.TabIndex = 284;
            this.labelControl3.Text = "Toplam Borç :";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl4.Location = new System.Drawing.Point(654, 348);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(93, 16);
            this.labelControl4.TabIndex = 285;
            this.labelControl4.Text = "Toplam Alacak :";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl5.Location = new System.Drawing.Point(824, 348);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 16);
            this.labelControl5.TabIndex = 286;
            this.labelControl5.Text = "Bakiye :";
            // 
            // lblBorc
            // 
            this.lblBorc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBorc.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblBorc.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblBorc.Location = new System.Drawing.Point(594, 348);
            this.lblBorc.Name = "lblBorc";
            this.lblBorc.Size = new System.Drawing.Size(7, 16);
            this.lblBorc.TabIndex = 287;
            this.lblBorc.Text = "0";
            // 
            // lblAlacak
            // 
            this.lblAlacak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlacak.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblAlacak.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblAlacak.Location = new System.Drawing.Point(750, 348);
            this.lblAlacak.Name = "lblAlacak";
            this.lblAlacak.Size = new System.Drawing.Size(7, 16);
            this.lblAlacak.TabIndex = 288;
            this.lblAlacak.Text = "0";
            // 
            // lblBakiye
            // 
            this.lblBakiye.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBakiye.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblBakiye.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblBakiye.Location = new System.Drawing.Point(870, 348);
            this.lblBakiye.Name = "lblBakiye";
            this.lblBakiye.Size = new System.Drawing.Size(7, 16);
            this.lblBakiye.TabIndex = 289;
            this.lblBakiye.Text = "0";
            // 
            // ucCariHareketler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBakiye);
            this.Controls.Add(this.lblAlacak);
            this.Controls.Add(this.lblBorc);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.dateKayitBit);
            this.Controls.Add(this.dateKayitBas);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnYazdir1);
            this.Controls.Add(this.gridControlCariHareket);
            this.Name = "ucCariHareketler";
            this.Size = new System.Drawing.Size(950, 369);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCariHareket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCariHareket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCariHareket;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCariHareket;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colEvrakTarih;
        private DevExpress.XtraGrid.Columns.GridColumn colIslemTuru;
        private DevExpress.XtraGrid.Columns.GridColumn colEvrakNo;
        private DevExpress.XtraGrid.Columns.GridColumn colBorcTutar;
        private DevExpress.XtraGrid.Columns.GridColumn colAlacakTutar;
        private DevExpress.XtraGrid.Columns.GridColumn colBakiye;
        private DevExpress.XtraGrid.Columns.GridColumn colBankaID;
        private DevExpress.XtraGrid.Columns.GridColumn colBankaAd;
        private DevExpress.XtraGrid.Columns.GridColumn colKasaID;
        private DevExpress.XtraGrid.Columns.GridColumn colKasaAd;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private Bilesenler.btnYazdir btnYazdir1;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateKayitBit;
        private DevExpress.XtraEditors.DateEdit dateKayitBas;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblBorc;
        private DevExpress.XtraEditors.LabelControl lblAlacak;
        private DevExpress.XtraEditors.LabelControl lblBakiye;
    }
}
