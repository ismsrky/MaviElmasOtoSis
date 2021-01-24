namespace MaviElmasOtoSis.Muhasebe
{
    partial class frmBankaSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankaSec));
            this.gridControlBankalar = new DevExpress.XtraGrid.GridControl();
            this.GridViewBankalar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBankaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankaAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHesapTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIlgiliKisi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikis = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnSec = new MaviElmasOtoSis.Bilesenler.MaviButon();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBankalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewBankalar)).BeginInit();
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
            this.gridControlBankalar.Size = new System.Drawing.Size(681, 296);
            this.gridControlBankalar.TabIndex = 233;
            this.gridControlBankalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewBankalar});
            // 
            // GridViewBankalar
            // 
            this.GridViewBankalar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBankaID,
            this.colBankaAd,
            this.colHesapTuru,
            this.colIlgiliKisi});
            this.GridViewBankalar.GridControl = this.gridControlBankalar;
            this.GridViewBankalar.Name = "GridViewBankalar";
            this.GridViewBankalar.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewBankalar.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewBankalar.OptionsBehavior.Editable = false;
            this.GridViewBankalar.OptionsBehavior.ReadOnly = true;
            this.GridViewBankalar.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewBankalar.OptionsView.ShowAutoFilterRow = true;
            this.GridViewBankalar.OptionsView.ShowGroupPanel = false;
            this.GridViewBankalar.OptionsView.ShowIndicator = false;
            this.GridViewBankalar.OptionsView.ShowViewCaption = true;
            this.GridViewBankalar.ViewCaption = "Bankalar Listesi";
            this.GridViewBankalar.DoubleClick += new System.EventHandler(this.GridViewBankalar_DoubleClick);
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
            this.colBankaAd.Width = 359;
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
            this.colHesapTuru.Width = 80;
            // 
            // colIlgiliKisi
            // 
            this.colIlgiliKisi.Caption = "İlgili Kişi";
            this.colIlgiliKisi.FieldName = "IlgiliKisi";
            this.colIlgiliKisi.MaxWidth = 180;
            this.colIlgiliKisi.MinWidth = 100;
            this.colIlgiliKisi.Name = "colIlgiliKisi";
            this.colIlgiliKisi.Visible = true;
            this.colIlgiliKisi.VisibleIndex = 3;
            this.colIlgiliKisi.Width = 180;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(452, 302);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 264;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Cikis;
            this.btnCikis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCikis.Location = new System.Drawing.Point(513, 301);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(80, 25);
            this.btnCikis.TabIndex = 263;
            this.btnCikis.Text = "maviButon2";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnSec
            // 
            this.btnSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSec.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Sec;
            this.btnSec.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSec.Image = ((System.Drawing.Image)(resources.GetObject("btnSec.Image")));
            this.btnSec.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSec.Location = new System.Drawing.Point(599, 301);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(76, 25);
            this.btnSec.TabIndex = 262;
            this.btnSec.Text = "maviButon1";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // frmBankaSec
            // 
            this.AcceptButton = this.btnSec;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCikis;
            this.ClientSize = new System.Drawing.Size(681, 334);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.gridControlBankalar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBankaSec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBankaSec";
            this.Load += new System.EventHandler(this.frmBankaSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBankalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewBankalar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlBankalar;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewBankalar;
        private DevExpress.XtraGrid.Columns.GridColumn colBankaID;
        private DevExpress.XtraGrid.Columns.GridColumn colBankaAd;
        private DevExpress.XtraGrid.Columns.GridColumn colHesapTuru;
        private DevExpress.XtraGrid.Columns.GridColumn colIlgiliKisi;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.MaviButon btnCikis;
        private Bilesenler.MaviButon btnSec;
    }
}