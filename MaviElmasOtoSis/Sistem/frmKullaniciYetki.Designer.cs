namespace MaviElmasOtoSis.Sistem
{
    partial class frmKullaniciYetki
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKullaniciYetki));
            this.chkYetkiVar = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridControlYetkiler = new DevExpress.XtraGrid.GridControl();
            this.GridViewYetkiler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colYetkiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYetkiVarmi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYetkiGrupAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpKullanicilar = new DevExpress.XtraEditors.LookUpEdit();
            this.btnKaydet = new MaviElmasOtoSis.Bilesenler.MaviButon();
            ((System.ComponentModel.ISupportInitialize)(this.chkYetkiVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlYetkiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewYetkiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpKullanicilar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkYetkiVar
            // 
            this.chkYetkiVar.AutoHeight = false;
            this.chkYetkiVar.Name = "chkYetkiVar";
            // 
            // gridControlYetkiler
            // 
            this.gridControlYetkiler.Enabled = false;
            this.gridControlYetkiler.Location = new System.Drawing.Point(8, 36);
            this.gridControlYetkiler.MainView = this.GridViewYetkiler;
            this.gridControlYetkiler.Name = "gridControlYetkiler";
            this.gridControlYetkiler.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkYetkiVar});
            this.gridControlYetkiler.Size = new System.Drawing.Size(432, 361);
            this.gridControlYetkiler.TabIndex = 249;
            this.gridControlYetkiler.TabStop = false;
            this.gridControlYetkiler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewYetkiler});
            // 
            // GridViewYetkiler
            // 
            this.GridViewYetkiler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colYetkiID,
            this.colYetkiVarmi,
            this.colAd,
            this.colYetkiGrupAdi});
            this.GridViewYetkiler.GridControl = this.gridControlYetkiler;
            this.GridViewYetkiler.GroupCount = 1;
            this.GridViewYetkiler.GroupFormat = "[#image]{1} {2}";
            this.GridViewYetkiler.Name = "GridViewYetkiler";
            this.GridViewYetkiler.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewYetkiler.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewYetkiler.OptionsCustomization.AllowColumnMoving = false;
            this.GridViewYetkiler.OptionsCustomization.AllowColumnResizing = false;
            this.GridViewYetkiler.OptionsCustomization.AllowFilter = false;
            this.GridViewYetkiler.OptionsCustomization.AllowQuickHideColumns = false;
            this.GridViewYetkiler.OptionsCustomization.AllowSort = false;
            this.GridViewYetkiler.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewYetkiler.OptionsView.ShowColumnHeaders = false;
            this.GridViewYetkiler.OptionsView.ShowGroupPanel = false;
            this.GridViewYetkiler.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewYetkiler.OptionsView.ShowViewCaption = true;
            this.GridViewYetkiler.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYetkiGrupAdi, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.GridViewYetkiler.ViewCaption = "Yetki Listesi";
            // 
            // colYetkiID
            // 
            this.colYetkiID.AppearanceCell.Options.UseTextOptions = true;
            this.colYetkiID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colYetkiID.Caption = "Yetki No";
            this.colYetkiID.FieldName = "YetkiID";
            this.colYetkiID.MaxWidth = 50;
            this.colYetkiID.Name = "colYetkiID";
            this.colYetkiID.Width = 50;
            // 
            // colYetkiVarmi
            // 
            this.colYetkiVarmi.Caption = "gridColumn1";
            this.colYetkiVarmi.ColumnEdit = this.chkYetkiVar;
            this.colYetkiVarmi.FieldName = "YetkiVarmi";
            this.colYetkiVarmi.Name = "colYetkiVarmi";
            this.colYetkiVarmi.Visible = true;
            this.colYetkiVarmi.VisibleIndex = 0;
            this.colYetkiVarmi.Width = 41;
            // 
            // colAd
            // 
            this.colAd.Caption = "Yetki Adı";
            this.colAd.FieldName = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.OptionsColumn.AllowEdit = false;
            this.colAd.OptionsColumn.ReadOnly = true;
            this.colAd.Visible = true;
            this.colAd.VisibleIndex = 1;
            this.colAd.Width = 789;
            // 
            // colYetkiGrupAdi
            // 
            this.colYetkiGrupAdi.Caption = "Grup Adı ";
            this.colYetkiGrupAdi.FieldName = "YetkiGrupAdi";
            this.colYetkiGrupAdi.Name = "colYetkiGrupAdi";
            this.colYetkiGrupAdi.OptionsColumn.AllowEdit = false;
            this.colYetkiGrupAdi.OptionsColumn.ReadOnly = true;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Location = new System.Drawing.Point(8, 11);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(94, 16);
            this.labelControl8.TabIndex = 248;
            this.labelControl8.Text = "Kullanıcı Seçin :";
            // 
            // lookUpKullanicilar
            // 
            this.lookUpKullanicilar.Location = new System.Drawing.Point(108, 8);
            this.lookUpKullanicilar.Name = "lookUpKullanicilar";
            this.lookUpKullanicilar.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpKullanicilar.Properties.Appearance.Options.UseFont = true;
            this.lookUpKullanicilar.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpKullanicilar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpKullanicilar.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KullaniciID", "KullaniciID", 60, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KullaniciAd", 150, "Kullanıcı Adı"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AdSoyad", "Ad Soyad"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Durum", "Durum")});
            this.lookUpKullanicilar.Properties.NullText = "";
            this.lookUpKullanicilar.Size = new System.Drawing.Size(166, 22);
            this.lookUpKullanicilar.TabIndex = 247;
            this.lookUpKullanicilar.EditValueChanged += new System.EventHandler(this.lookUpKullanicilar_EditValueChanged);
            // 
            // btnKaydet
            // 
            this.btnKaydet.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Kaydet;
            this.btnKaydet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnKaydet.Location = new System.Drawing.Point(353, 7);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(92, 25);
            this.btnKaydet.TabIndex = 250;
            this.btnKaydet.Text = "maviButon1";
            this.btnKaydet.ToolTip = "F2 - Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmKullaniciYetki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 404);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.gridControlYetkiler);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.lookUpKullanicilar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKullaniciYetki";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKullaniciYetki";
            this.Load += new System.EventHandler(this.frmKullaniciYetki_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkYetkiVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlYetkiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewYetkiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpKullanicilar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlYetkiler;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewYetkiler;
        private DevExpress.XtraGrid.Columns.GridColumn colYetkiID;
        private DevExpress.XtraGrid.Columns.GridColumn colYetkiVarmi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkYetkiVar;
        private DevExpress.XtraGrid.Columns.GridColumn colAd;
        private DevExpress.XtraGrid.Columns.GridColumn colYetkiGrupAdi;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LookUpEdit lookUpKullanicilar;
        private Bilesenler.MaviButon btnKaydet;
    }
}