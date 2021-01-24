namespace MaviElmasOtoSis.AracKabul
{
    partial class ucArac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucArac));
            this.gridControlAraclar = new DevExpress.XtraGrid.GridControl();
            this.GridViewAraclar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAracID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuhsatSahibi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.ucAracDetay1 = new MaviElmasOtoSis.AracKabul.ucAracDetay();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAraclar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAraclar)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlAraclar
            // 
            this.gridControlAraclar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlAraclar.Location = new System.Drawing.Point(3, 3);
            this.gridControlAraclar.MainView = this.GridViewAraclar;
            this.gridControlAraclar.Name = "gridControlAraclar";
            this.gridControlAraclar.Size = new System.Drawing.Size(975, 282);
            this.gridControlAraclar.TabIndex = 232;
            this.gridControlAraclar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewAraclar});
            // 
            // GridViewAraclar
            // 
            this.GridViewAraclar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAracID,
            this.colPlaka,
            this.colRuhsatSahibi,
            this.colSaseNo,
            this.colMarka,
            this.colModel});
            this.GridViewAraclar.GridControl = this.gridControlAraclar;
            this.GridViewAraclar.Name = "GridViewAraclar";
            this.GridViewAraclar.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewAraclar.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewAraclar.OptionsBehavior.Editable = false;
            this.GridViewAraclar.OptionsBehavior.ReadOnly = true;
            this.GridViewAraclar.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewAraclar.OptionsView.ShowAutoFilterRow = true;
            this.GridViewAraclar.OptionsView.ShowViewCaption = true;
            this.GridViewAraclar.ViewCaption = "Araçlar";
            this.GridViewAraclar.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewAraclar_FocusedRowChanged);
            this.GridViewAraclar.Click += new System.EventHandler(this.GridViewAraclar_Click);
            // 
            // colAracID
            // 
            this.colAracID.AppearanceCell.Options.UseTextOptions = true;
            this.colAracID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAracID.Caption = "Araç No";
            this.colAracID.FieldName = "AracID";
            this.colAracID.MaxWidth = 50;
            this.colAracID.Name = "colAracID";
            this.colAracID.Visible = true;
            this.colAracID.VisibleIndex = 0;
            this.colAracID.Width = 50;
            // 
            // colPlaka
            // 
            this.colPlaka.Caption = "Plaka";
            this.colPlaka.FieldName = "Plaka";
            this.colPlaka.Name = "colPlaka";
            this.colPlaka.Visible = true;
            this.colPlaka.VisibleIndex = 1;
            this.colPlaka.Width = 124;
            // 
            // colRuhsatSahibi
            // 
            this.colRuhsatSahibi.Caption = "Ruhsat Sahibi";
            this.colRuhsatSahibi.FieldName = "RuhsatSahibi";
            this.colRuhsatSahibi.Name = "colRuhsatSahibi";
            this.colRuhsatSahibi.Visible = true;
            this.colRuhsatSahibi.VisibleIndex = 2;
            this.colRuhsatSahibi.Width = 124;
            // 
            // colSaseNo
            // 
            this.colSaseNo.Caption = "Şase No";
            this.colSaseNo.FieldName = "SaseNo";
            this.colSaseNo.Name = "colSaseNo";
            this.colSaseNo.Visible = true;
            this.colSaseNo.VisibleIndex = 3;
            // 
            // colMarka
            // 
            this.colMarka.Caption = "Marka";
            this.colMarka.FieldName = "MarkaAdi";
            this.colMarka.Name = "colMarka";
            this.colMarka.Visible = true;
            this.colMarka.VisibleIndex = 4;
            // 
            // colModel
            // 
            this.colModel.Caption = "Model";
            this.colModel.FieldName = "ModelAdi";
            this.colModel.Name = "colModel";
            this.colModel.Visible = true;
            this.colModel.VisibleIndex = 5;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(923, 291);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 295;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // ucAracDetay1
            // 
            this.ucAracDetay1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucAracDetay1.DetayMode = MaviElmasOtoSis.Enumlar.DetayModelari.Tum;
            this.ucAracDetay1.Location = new System.Drawing.Point(3, 291);
            this.ucAracDetay1.Name = "ucAracDetay1";
            this.ucAracDetay1.Size = new System.Drawing.Size(975, 290);
            this.ucAracDetay1.TabIndex = 296;
            // 
            // btnYazdir1
            // 
            this.btnYazdir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYazdir1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYazdir1.Image = ((System.Drawing.Image)(resources.GetObject("btnYazdir1.Image")));
            this.btnYazdir1.KaynakView = this.GridViewAraclar;
            this.btnYazdir1.Location = new System.Drawing.Point(855, 291);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 297;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // ucArac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnYazdir1);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.ucAracDetay1);
            this.Controls.Add(this.gridControlAraclar);
            this.Name = "ucArac";
            this.Size = new System.Drawing.Size(981, 581);
            this.Load += new System.EventHandler(this.ucArac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAraclar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAraclar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlAraclar;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewAraclar;
        private DevExpress.XtraGrid.Columns.GridColumn colAracID;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaka;
        private DevExpress.XtraGrid.Columns.GridColumn colRuhsatSahibi;
        private DevExpress.XtraGrid.Columns.GridColumn colSaseNo;
        private DevExpress.XtraGrid.Columns.GridColumn colMarka;
        private DevExpress.XtraGrid.Columns.GridColumn colModel;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private ucAracDetay ucAracDetay1;
        private Bilesenler.btnYazdir btnYazdir1;
    }
}
