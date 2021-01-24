namespace MaviElmasOtoSis.Tanim
{
    partial class ucBirim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBirim));
            this.gridControlBirimler = new DevExpress.XtraGrid.GridControl();
            this.GridViewBirimler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBirimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirimAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirimTip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucBirimDetay1 = new MaviElmasOtoSis.Tanim.ucBirimDetay();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBirimler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewBirimler)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlBirimler
            // 
            this.gridControlBirimler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlBirimler.Location = new System.Drawing.Point(4, 3);
            this.gridControlBirimler.MainView = this.GridViewBirimler;
            this.gridControlBirimler.Name = "gridControlBirimler";
            this.gridControlBirimler.Size = new System.Drawing.Size(875, 274);
            this.gridControlBirimler.TabIndex = 232;
            this.gridControlBirimler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewBirimler});
            // 
            // GridViewBirimler
            // 
            this.GridViewBirimler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBirimID,
            this.colBirimAd,
            this.colBirimTip,
            this.colDurum});
            this.GridViewBirimler.GridControl = this.gridControlBirimler;
            this.GridViewBirimler.Name = "GridViewBirimler";
            this.GridViewBirimler.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewBirimler.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewBirimler.OptionsBehavior.Editable = false;
            this.GridViewBirimler.OptionsBehavior.ReadOnly = true;
            this.GridViewBirimler.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewBirimler.OptionsView.ShowAutoFilterRow = true;
            this.GridViewBirimler.OptionsView.ShowViewCaption = true;
            this.GridViewBirimler.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBirimAd, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.GridViewBirimler.ViewCaption = "Birimler Listesi";
            this.GridViewBirimler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewBirimler_FocusedRowChanged);
            this.GridViewBirimler.Click += new System.EventHandler(this.GridViewBirimler_Click);
            // 
            // colBirimID
            // 
            this.colBirimID.AppearanceCell.Options.UseTextOptions = true;
            this.colBirimID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colBirimID.Caption = "Birim No";
            this.colBirimID.FieldName = "BirimID";
            this.colBirimID.MaxWidth = 60;
            this.colBirimID.Name = "colBirimID";
            this.colBirimID.Visible = true;
            this.colBirimID.VisibleIndex = 0;
            this.colBirimID.Width = 50;
            // 
            // colBirimAd
            // 
            this.colBirimAd.Caption = "Birim Adı";
            this.colBirimAd.FieldName = "BirimAd";
            this.colBirimAd.Name = "colBirimAd";
            this.colBirimAd.Visible = true;
            this.colBirimAd.VisibleIndex = 1;
            this.colBirimAd.Width = 124;
            // 
            // colBirimTip
            // 
            this.colBirimTip.Caption = "Birim Tipi";
            this.colBirimTip.FieldName = "BirimTip";
            this.colBirimTip.MaxWidth = 110;
            this.colBirimTip.MinWidth = 90;
            this.colBirimTip.Name = "colBirimTip";
            this.colBirimTip.Visible = true;
            this.colBirimTip.VisibleIndex = 2;
            this.colBirimTip.Width = 90;
            // 
            // colDurum
            // 
            this.colDurum.Caption = "Durumu";
            this.colDurum.FieldName = "Durum";
            this.colDurum.MaxWidth = 50;
            this.colDurum.MinWidth = 50;
            this.colDurum.Name = "colDurum";
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 3;
            this.colDurum.Width = 50;
            // 
            // ucBirimDetay1
            // 
            this.ucBirimDetay1.DetayMode = MaviElmasOtoSis.Enumlar.DetayModelari.Tum;
            this.ucBirimDetay1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucBirimDetay1.Location = new System.Drawing.Point(0, 283);
            this.ucBirimDetay1.Name = "ucBirimDetay1";
            this.ucBirimDetay1.Size = new System.Drawing.Size(882, 195);
            this.ucBirimDetay1.TabIndex = 233;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(824, 283);
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
            this.btnYazdir1.KaynakView = this.GridViewBirimler;
            this.btnYazdir1.Location = new System.Drawing.Point(756, 284);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 275;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // ucBirim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnYazdir1);
            this.Controls.Add(this.ucBirimDetay1);
            this.Controls.Add(this.gridControlBirimler);
            this.Name = "ucBirim";
            this.Size = new System.Drawing.Size(882, 478);
            this.Load += new System.EventHandler(this.ucBirim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBirimler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewBirimler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlBirimler;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewBirimler;
        private DevExpress.XtraGrid.Columns.GridColumn colBirimID;
        private DevExpress.XtraGrid.Columns.GridColumn colBirimAd;
        private DevExpress.XtraGrid.Columns.GridColumn colBirimTip;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
        private ucBirimDetay ucBirimDetay1;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.btnYazdir btnYazdir1;
    }
}
