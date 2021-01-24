namespace MaviElmasOtoSis.Stok
{
    partial class ucStokKart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStokKart));
            this.gridControlStokKart = new DevExpress.XtraGrid.GridControl();
            this.GridViewStokKart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKalemAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParcaNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarkodNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokBirim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokGrup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.ucStokKartDetay1 = new MaviElmasOtoSis.Stok.ucStokKartDetay();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            this.colSatisFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStokKart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewStokKart)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlStokKart
            // 
            this.gridControlStokKart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlStokKart.Location = new System.Drawing.Point(0, 0);
            this.gridControlStokKart.MainView = this.GridViewStokKart;
            this.gridControlStokKart.Name = "gridControlStokKart";
            this.gridControlStokKart.Size = new System.Drawing.Size(1064, 217);
            this.gridControlStokKart.TabIndex = 230;
            this.gridControlStokKart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewStokKart});
            // 
            // GridViewStokKart
            // 
            this.GridViewStokKart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKartID,
            this.colKalemAdi,
            this.colParcaNo,
            this.colStokMiktar,
            this.colSatisFiyat,
            this.colBarkodNo,
            this.colStokBirim,
            this.colStokGrup});
            this.GridViewStokKart.GridControl = this.gridControlStokKart;
            this.GridViewStokKart.Name = "GridViewStokKart";
            this.GridViewStokKart.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewStokKart.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewStokKart.OptionsBehavior.Editable = false;
            this.GridViewStokKart.OptionsBehavior.ReadOnly = true;
            this.GridViewStokKart.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewStokKart.OptionsView.ShowAutoFilterRow = true;
            this.GridViewStokKart.OptionsView.ShowViewCaption = true;
            this.GridViewStokKart.ViewCaption = "Stok Kartları";
            this.GridViewStokKart.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewStokKart_FocusedRowChanged);
            this.GridViewStokKart.Click += new System.EventHandler(this.GridViewStokKart_Click);
            // 
            // colKartID
            // 
            this.colKartID.AppearanceCell.Options.UseTextOptions = true;
            this.colKartID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKartID.Caption = "Kart No";
            this.colKartID.FieldName = "KartID";
            this.colKartID.MaxWidth = 50;
            this.colKartID.Name = "colKartID";
            this.colKartID.Visible = true;
            this.colKartID.VisibleIndex = 0;
            this.colKartID.Width = 50;
            // 
            // colKalemAdi
            // 
            this.colKalemAdi.Caption = "Kalem Adı";
            this.colKalemAdi.FieldName = "KalemAdi";
            this.colKalemAdi.Name = "colKalemAdi";
            this.colKalemAdi.Visible = true;
            this.colKalemAdi.VisibleIndex = 1;
            this.colKalemAdi.Width = 124;
            // 
            // colParcaNo
            // 
            this.colParcaNo.Caption = "Parça No";
            this.colParcaNo.FieldName = "ParcaNo";
            this.colParcaNo.Name = "colParcaNo";
            this.colParcaNo.Visible = true;
            this.colParcaNo.VisibleIndex = 2;
            this.colParcaNo.Width = 124;
            // 
            // colStokMiktar
            // 
            this.colStokMiktar.Caption = "Stok Miktarı";
            this.colStokMiktar.FieldName = "StokMiktar";
            this.colStokMiktar.MaxWidth = 75;
            this.colStokMiktar.MinWidth = 75;
            this.colStokMiktar.Name = "colStokMiktar";
            this.colStokMiktar.Visible = true;
            this.colStokMiktar.VisibleIndex = 3;
            // 
            // colBarkodNo
            // 
            this.colBarkodNo.Caption = "Barkod No";
            this.colBarkodNo.FieldName = "BarkodNo";
            this.colBarkodNo.Name = "colBarkodNo";
            this.colBarkodNo.Visible = true;
            this.colBarkodNo.VisibleIndex = 5;
            // 
            // colStokBirim
            // 
            this.colStokBirim.Caption = "Stok Birimi";
            this.colStokBirim.FieldName = "StokBirim";
            this.colStokBirim.Name = "colStokBirim";
            this.colStokBirim.Visible = true;
            this.colStokBirim.VisibleIndex = 6;
            // 
            // colStokGrup
            // 
            this.colStokGrup.Caption = "Stok Grubu";
            this.colStokGrup.FieldName = "StokGrup";
            this.colStokGrup.Name = "colStokGrup";
            this.colStokGrup.Visible = true;
            this.colStokGrup.VisibleIndex = 7;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(1009, 223);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 270;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // ucStokKartDetay1
            // 
            this.ucStokKartDetay1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucStokKartDetay1.DetayMode = MaviElmasOtoSis.Enumlar.DetayModelari.Tum;
            this.ucStokKartDetay1.Location = new System.Drawing.Point(3, 223);
            this.ucStokKartDetay1.Name = "ucStokKartDetay1";
            this.ucStokKartDetay1.Size = new System.Drawing.Size(1070, 331);
            this.ucStokKartDetay1.TabIndex = 271;
            // 
            // btnYazdir1
            // 
            this.btnYazdir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYazdir1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYazdir1.Image = ((System.Drawing.Image)(resources.GetObject("btnYazdir1.Image")));
            this.btnYazdir1.KaynakView = this.GridViewStokKart;
            this.btnYazdir1.Location = new System.Drawing.Point(944, 223);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 272;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // colSatisFiyat
            // 
            this.colSatisFiyat.Caption = "Satış Fiyat";
            this.colSatisFiyat.FieldName = "SatisFiyat";
            this.colSatisFiyat.Name = "colSatisFiyat";
            this.colSatisFiyat.Visible = true;
            this.colSatisFiyat.VisibleIndex = 4;
            // 
            // ucStokKart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnYazdir1);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.ucStokKartDetay1);
            this.Controls.Add(this.gridControlStokKart);
            this.Name = "ucStokKart";
            this.Size = new System.Drawing.Size(1076, 554);
            this.Load += new System.EventHandler(this.ucStokKart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStokKart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewStokKart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlStokKart;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewStokKart;
        private DevExpress.XtraGrid.Columns.GridColumn colKartID;
        private DevExpress.XtraGrid.Columns.GridColumn colKalemAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colParcaNo;
        private DevExpress.XtraGrid.Columns.GridColumn colStokBirim;
        private DevExpress.XtraGrid.Columns.GridColumn colStokGrup;
        private DevExpress.XtraGrid.Columns.GridColumn colBarkodNo;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private ucStokKartDetay ucStokKartDetay1;
        private DevExpress.XtraGrid.Columns.GridColumn colStokMiktar;
        private Bilesenler.btnYazdir btnYazdir1;
        private DevExpress.XtraGrid.Columns.GridColumn colSatisFiyat;
    }
}
