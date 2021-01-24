namespace MaviElmasOtoSis.Muhasebe
{
    partial class ucGelirGider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGelirGider));
            this.gridControlGelirGider = new DevExpress.XtraGrid.GridControl();
            this.GridViewGelirGider = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGelirGiderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGelirGiderGrup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGelir = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlacak = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBakiye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucGelirGiderDetay1 = new MaviElmasOtoSis.Muhasebe.ucGelirGiderDetay();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGelirGider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewGelirGider)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlGelirGider
            // 
            this.gridControlGelirGider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlGelirGider.Location = new System.Drawing.Point(3, 0);
            this.gridControlGelirGider.MainView = this.GridViewGelirGider;
            this.gridControlGelirGider.Name = "gridControlGelirGider";
            this.gridControlGelirGider.Size = new System.Drawing.Size(879, 255);
            this.gridControlGelirGider.TabIndex = 232;
            this.gridControlGelirGider.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewGelirGider});
            // 
            // GridViewGelirGider
            // 
            this.GridViewGelirGider.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGelirGiderID,
            this.colAd,
            this.colGelirGiderGrup,
            this.colGelir,
            this.colBorc,
            this.colAlacak,
            this.colBakiye,
            this.colDurum});
            this.GridViewGelirGider.GridControl = this.gridControlGelirGider;
            this.GridViewGelirGider.Name = "GridViewGelirGider";
            this.GridViewGelirGider.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewGelirGider.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewGelirGider.OptionsBehavior.Editable = false;
            this.GridViewGelirGider.OptionsBehavior.ReadOnly = true;
            this.GridViewGelirGider.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewGelirGider.OptionsView.ShowAutoFilterRow = true;
            this.GridViewGelirGider.OptionsView.ShowViewCaption = true;
            this.GridViewGelirGider.ViewCaption = "Gelir ve Gider Kalemleri Listesi";
            this.GridViewGelirGider.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewGelirGider_FocusedRowChanged);
            this.GridViewGelirGider.Click += new System.EventHandler(this.GridViewGelirGider_Click);
            // 
            // colGelirGiderID
            // 
            this.colGelirGiderID.AppearanceCell.Options.UseTextOptions = true;
            this.colGelirGiderID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colGelirGiderID.Caption = "Gelir/Gider No";
            this.colGelirGiderID.FieldName = "GelirGiderID";
            this.colGelirGiderID.MaxWidth = 80;
            this.colGelirGiderID.MinWidth = 75;
            this.colGelirGiderID.Name = "colGelirGiderID";
            this.colGelirGiderID.Visible = true;
            this.colGelirGiderID.VisibleIndex = 0;
            // 
            // colAd
            // 
            this.colAd.Caption = "Gelir / Gider Adı";
            this.colAd.FieldName = "GelirGiderAd";
            this.colAd.Name = "colAd";
            this.colAd.Visible = true;
            this.colAd.VisibleIndex = 1;
            this.colAd.Width = 204;
            // 
            // colGelirGiderGrup
            // 
            this.colGelirGiderGrup.Caption = "Gelir / Gider Grubu";
            this.colGelirGiderGrup.FieldName = "GelirGiderGrup";
            this.colGelirGiderGrup.Name = "colGelirGiderGrup";
            this.colGelirGiderGrup.Visible = true;
            this.colGelirGiderGrup.VisibleIndex = 2;
            this.colGelirGiderGrup.Width = 204;
            // 
            // colGelir
            // 
            this.colGelir.Caption = "Gelir / Gider";
            this.colGelir.FieldName = "Gelir";
            this.colGelir.MaxWidth = 70;
            this.colGelir.MinWidth = 70;
            this.colGelir.Name = "colGelir";
            this.colGelir.Visible = true;
            this.colGelir.VisibleIndex = 3;
            this.colGelir.Width = 70;
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
            this.colBakiye.MaxWidth = 80;
            this.colBakiye.MinWidth = 80;
            this.colBakiye.Name = "colBakiye";
            this.colBakiye.Visible = true;
            this.colBakiye.VisibleIndex = 6;
            this.colBakiye.Width = 80;
            // 
            // colDurum
            // 
            this.colDurum.Caption = "Durumu";
            this.colDurum.FieldName = "Durum";
            this.colDurum.MaxWidth = 60;
            this.colDurum.MinWidth = 60;
            this.colDurum.Name = "colDurum";
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 7;
            this.colDurum.Width = 60;
            // 
            // ucGelirGiderDetay1
            // 
            this.ucGelirGiderDetay1.DetayMode = MaviElmasOtoSis.Enumlar.DetayModelari.Tum;
            this.ucGelirGiderDetay1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucGelirGiderDetay1.Location = new System.Drawing.Point(0, 261);
            this.ucGelirGiderDetay1.Name = "ucGelirGiderDetay1";
            this.ucGelirGiderDetay1.Size = new System.Drawing.Size(885, 274);
            this.ucGelirGiderDetay1.TabIndex = 233;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(827, 261);
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
            this.btnYazdir1.KaynakView = this.GridViewGelirGider;
            this.btnYazdir1.Location = new System.Drawing.Point(759, 262);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 275;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // ucGelirGider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnYazdir1);
            this.Controls.Add(this.ucGelirGiderDetay1);
            this.Controls.Add(this.gridControlGelirGider);
            this.Name = "ucGelirGider";
            this.Size = new System.Drawing.Size(885, 535);
            this.Load += new System.EventHandler(this.ucGelirGider_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGelirGider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewGelirGider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlGelirGider;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewGelirGider;
        private DevExpress.XtraGrid.Columns.GridColumn colGelirGiderID;
        private DevExpress.XtraGrid.Columns.GridColumn colAd;
        private DevExpress.XtraGrid.Columns.GridColumn colGelirGiderGrup;
        private DevExpress.XtraGrid.Columns.GridColumn colGelir;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
        private ucGelirGiderDetay ucGelirGiderDetay1;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.btnYazdir btnYazdir1;
        private DevExpress.XtraGrid.Columns.GridColumn colBorc;
        private DevExpress.XtraGrid.Columns.GridColumn colAlacak;
        private DevExpress.XtraGrid.Columns.GridColumn colBakiye;
    }
}
