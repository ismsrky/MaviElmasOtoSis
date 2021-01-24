namespace MaviElmasOtoSis.Personel
{
    partial class ucPersonel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPersonel));
            this.gridControlPersoneller = new DevExpress.XtraGrid.GridControl();
            this.GridViewPersoneller = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPersonelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTCKimlikNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnvan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCinsiyet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKanGrup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucPersonelDetay1 = new MaviElmasOtoSis.Personel.ucPersonelDetay();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPersoneller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPersoneller)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlPersoneller
            // 
            this.gridControlPersoneller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlPersoneller.Location = new System.Drawing.Point(0, 3);
            this.gridControlPersoneller.MainView = this.GridViewPersoneller;
            this.gridControlPersoneller.Name = "gridControlPersoneller";
            this.gridControlPersoneller.Size = new System.Drawing.Size(907, 218);
            this.gridControlPersoneller.TabIndex = 233;
            this.gridControlPersoneller.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewPersoneller});
            // 
            // GridViewPersoneller
            // 
            this.GridViewPersoneller.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPersonelID,
            this.colTCKimlikNo,
            this.colAd,
            this.colSoyad,
            this.colUnvan,
            this.colCinsiyet,
            this.colKanGrup});
            this.GridViewPersoneller.GridControl = this.gridControlPersoneller;
            this.GridViewPersoneller.Name = "GridViewPersoneller";
            this.GridViewPersoneller.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewPersoneller.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewPersoneller.OptionsBehavior.Editable = false;
            this.GridViewPersoneller.OptionsBehavior.ReadOnly = true;
            this.GridViewPersoneller.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewPersoneller.OptionsView.ShowAutoFilterRow = true;
            this.GridViewPersoneller.OptionsView.ShowViewCaption = true;
            this.GridViewPersoneller.ViewCaption = "Personeller Listesi";
            this.GridViewPersoneller.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewPersoneller_FocusedRowChanged);
            this.GridViewPersoneller.Click += new System.EventHandler(this.GridViewPersoneller_Click);
            // 
            // colPersonelID
            // 
            this.colPersonelID.AppearanceCell.Options.UseTextOptions = true;
            this.colPersonelID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPersonelID.Caption = "Per. No";
            this.colPersonelID.FieldName = "PersonelID";
            this.colPersonelID.MaxWidth = 55;
            this.colPersonelID.Name = "colPersonelID";
            this.colPersonelID.Visible = true;
            this.colPersonelID.VisibleIndex = 0;
            this.colPersonelID.Width = 55;
            // 
            // colTCKimlikNo
            // 
            this.colTCKimlikNo.Caption = "Tc Kimlik No";
            this.colTCKimlikNo.FieldName = "TcKimlikNo";
            this.colTCKimlikNo.Name = "colTCKimlikNo";
            this.colTCKimlikNo.Visible = true;
            this.colTCKimlikNo.VisibleIndex = 1;
            this.colTCKimlikNo.Width = 72;
            // 
            // colAd
            // 
            this.colAd.Caption = "Adı";
            this.colAd.FieldName = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.Visible = true;
            this.colAd.VisibleIndex = 2;
            this.colAd.Width = 224;
            // 
            // colSoyad
            // 
            this.colSoyad.Caption = "Soyad";
            this.colSoyad.FieldName = "Soyad";
            this.colSoyad.Name = "colSoyad";
            this.colSoyad.Visible = true;
            this.colSoyad.VisibleIndex = 3;
            this.colSoyad.Width = 337;
            // 
            // colUnvan
            // 
            this.colUnvan.Caption = "Ünvanı";
            this.colUnvan.FieldName = "Unvan";
            this.colUnvan.Name = "colUnvan";
            this.colUnvan.Visible = true;
            this.colUnvan.VisibleIndex = 4;
            this.colUnvan.Width = 71;
            // 
            // colCinsiyet
            // 
            this.colCinsiyet.Caption = "Cinsiyet";
            this.colCinsiyet.FieldName = "Cinsiyet";
            this.colCinsiyet.Name = "colCinsiyet";
            this.colCinsiyet.Visible = true;
            this.colCinsiyet.VisibleIndex = 5;
            this.colCinsiyet.Width = 61;
            // 
            // colKanGrup
            // 
            this.colKanGrup.Caption = "Kan Grubu";
            this.colKanGrup.FieldNameSortGroup = "KanGrup";
            this.colKanGrup.Name = "colKanGrup";
            this.colKanGrup.Visible = true;
            this.colKanGrup.VisibleIndex = 6;
            this.colKanGrup.Width = 69;
            // 
            // ucPersonelDetay1
            // 
            this.ucPersonelDetay1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPersonelDetay1.DetayMode = MaviElmasOtoSis.Enumlar.DetayModelari.Tum;
            this.ucPersonelDetay1.Location = new System.Drawing.Point(0, 227);
            this.ucPersonelDetay1.Name = "ucPersonelDetay1";
            this.ucPersonelDetay1.Size = new System.Drawing.Size(907, 409);
            this.ucPersonelDetay1.TabIndex = 234;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(852, 223);
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
            this.btnYazdir1.KaynakView = this.GridViewPersoneller;
            this.btnYazdir1.Location = new System.Drawing.Point(784, 224);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 275;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // ucPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnYazdir1);
            this.Controls.Add(this.ucPersonelDetay1);
            this.Controls.Add(this.gridControlPersoneller);
            this.Name = "ucPersonel";
            this.Size = new System.Drawing.Size(910, 639);
            this.Load += new System.EventHandler(this.ucPersonel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPersoneller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPersoneller)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPersoneller;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewPersoneller;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonelID;
        private DevExpress.XtraGrid.Columns.GridColumn colAd;
        private DevExpress.XtraGrid.Columns.GridColumn colSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn colUnvan;
        private DevExpress.XtraGrid.Columns.GridColumn colTCKimlikNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCinsiyet;
        private DevExpress.XtraGrid.Columns.GridColumn colKanGrup;
        private ucPersonelDetay ucPersonelDetay1;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.btnYazdir btnYazdir1;
    }
}
