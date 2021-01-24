namespace MaviElmasOtoSis.Tanim
{
    partial class ucIscilik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucIscilik));
            this.gridControlIscilikler = new DevExpress.XtraGrid.GridControl();
            this.GridViewIscilikler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIscilikID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIscilikAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIscilikTip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKacSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucIscilikDetay1 = new MaviElmasOtoSis.Tanim.ucIscilikDetay();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIscilikler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewIscilikler)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlIscilikler
            // 
            this.gridControlIscilikler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlIscilikler.Location = new System.Drawing.Point(3, 3);
            this.gridControlIscilikler.MainView = this.GridViewIscilikler;
            this.gridControlIscilikler.Name = "gridControlIscilikler";
            this.gridControlIscilikler.Size = new System.Drawing.Size(875, 281);
            this.gridControlIscilikler.TabIndex = 231;
            this.gridControlIscilikler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewIscilikler});
            // 
            // GridViewIscilikler
            // 
            this.GridViewIscilikler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIscilikID,
            this.colIscilikAd,
            this.colIscilikTip,
            this.colKacSaat,
            this.colDurum});
            this.GridViewIscilikler.GridControl = this.gridControlIscilikler;
            this.GridViewIscilikler.Name = "GridViewIscilikler";
            this.GridViewIscilikler.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewIscilikler.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewIscilikler.OptionsBehavior.Editable = false;
            this.GridViewIscilikler.OptionsBehavior.ReadOnly = true;
            this.GridViewIscilikler.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewIscilikler.OptionsView.ShowAutoFilterRow = true;
            this.GridViewIscilikler.OptionsView.ShowViewCaption = true;
            this.GridViewIscilikler.ViewCaption = "İşçilikler Listesi";
            this.GridViewIscilikler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewIscilikler_FocusedRowChanged);
            this.GridViewIscilikler.Click += new System.EventHandler(this.GridViewIscilikler_Click);
            // 
            // colIscilikID
            // 
            this.colIscilikID.AppearanceCell.Options.UseTextOptions = true;
            this.colIscilikID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIscilikID.Caption = "İşçilik No";
            this.colIscilikID.FieldName = "IscilikID";
            this.colIscilikID.MaxWidth = 60;
            this.colIscilikID.Name = "colIscilikID";
            this.colIscilikID.Visible = true;
            this.colIscilikID.VisibleIndex = 0;
            this.colIscilikID.Width = 50;
            // 
            // colIscilikAd
            // 
            this.colIscilikAd.Caption = "İşçilik Adı";
            this.colIscilikAd.FieldName = "IscilikAd";
            this.colIscilikAd.Name = "colIscilikAd";
            this.colIscilikAd.Visible = true;
            this.colIscilikAd.VisibleIndex = 1;
            this.colIscilikAd.Width = 124;
            // 
            // colIscilikTip
            // 
            this.colIscilikTip.Caption = "İşçilik Tipi";
            this.colIscilikTip.FieldName = "IscilikTipAciklama";
            this.colIscilikTip.MaxWidth = 75;
            this.colIscilikTip.MinWidth = 75;
            this.colIscilikTip.Name = "colIscilikTip";
            this.colIscilikTip.Visible = true;
            this.colIscilikTip.VisibleIndex = 2;
            // 
            // colKacSaat
            // 
            this.colKacSaat.Caption = "Kaç Saat";
            this.colKacSaat.FieldName = "KacSaat";
            this.colKacSaat.MaxWidth = 50;
            this.colKacSaat.MinWidth = 50;
            this.colKacSaat.Name = "colKacSaat";
            this.colKacSaat.Visible = true;
            this.colKacSaat.VisibleIndex = 3;
            this.colKacSaat.Width = 50;
            // 
            // colDurum
            // 
            this.colDurum.Caption = "Durumu";
            this.colDurum.FieldName = "Durum";
            this.colDurum.MaxWidth = 50;
            this.colDurum.MinWidth = 50;
            this.colDurum.Name = "colDurum";
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 4;
            this.colDurum.Width = 50;
            // 
            // ucIscilikDetay1
            // 
            this.ucIscilikDetay1.DetayMode = MaviElmasOtoSis.Enumlar.DetayModelari.Tum;
            this.ucIscilikDetay1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucIscilikDetay1.Location = new System.Drawing.Point(0, 289);
            this.ucIscilikDetay1.Name = "ucIscilikDetay1";
            this.ucIscilikDetay1.Size = new System.Drawing.Size(881, 216);
            this.ucIscilikDetay1.TabIndex = 232;
            // 
            // btnYazdir1
            // 
            this.btnYazdir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYazdir1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYazdir1.Image = ((System.Drawing.Image)(resources.GetObject("btnYazdir1.Image")));
            this.btnYazdir1.KaynakView = this.GridViewIscilikler;
            this.btnYazdir1.Location = new System.Drawing.Point(755, 290);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 273;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(823, 289);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 274;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // ucIscilik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnYazdir1);
            this.Controls.Add(this.ucIscilikDetay1);
            this.Controls.Add(this.gridControlIscilikler);
            this.Name = "ucIscilik";
            this.Size = new System.Drawing.Size(881, 505);
            this.Load += new System.EventHandler(this.ucIscilik_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIscilikler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewIscilikler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlIscilikler;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewIscilikler;
        private DevExpress.XtraGrid.Columns.GridColumn colIscilikID;
        private DevExpress.XtraGrid.Columns.GridColumn colIscilikAd;
        private DevExpress.XtraGrid.Columns.GridColumn colIscilikTip;
        private DevExpress.XtraGrid.Columns.GridColumn colKacSaat;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
        private ucIscilikDetay ucIscilikDetay1;
        private Bilesenler.btnYazdir btnYazdir1;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
    }
}
