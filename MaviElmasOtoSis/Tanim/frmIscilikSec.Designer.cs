namespace MaviElmasOtoSis.Tanim
{
    partial class frmIscilikSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIscilikSec));
            this.gridControlIscilikler = new DevExpress.XtraGrid.GridControl();
            this.GridViewIscilikler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIscilikID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIscilikAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIscilikTipAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKacSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIscilikTip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikis = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnSec = new MaviElmasOtoSis.Bilesenler.MaviButon();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIscilikler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewIscilikler)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlIscilikler
            // 
            this.gridControlIscilikler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlIscilikler.Location = new System.Drawing.Point(2, 2);
            this.gridControlIscilikler.MainView = this.GridViewIscilikler;
            this.gridControlIscilikler.Name = "gridControlIscilikler";
            this.gridControlIscilikler.Size = new System.Drawing.Size(508, 313);
            this.gridControlIscilikler.TabIndex = 232;
            this.gridControlIscilikler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewIscilikler});
            // 
            // GridViewIscilikler
            // 
            this.GridViewIscilikler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIscilikID,
            this.colIscilikAd,
            this.colIscilikTipAciklama,
            this.colKacSaat,
            this.colIscilikTip});
            this.GridViewIscilikler.GridControl = this.gridControlIscilikler;
            this.GridViewIscilikler.Name = "GridViewIscilikler";
            this.GridViewIscilikler.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewIscilikler.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewIscilikler.OptionsBehavior.Editable = false;
            this.GridViewIscilikler.OptionsBehavior.ReadOnly = true;
            this.GridViewIscilikler.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewIscilikler.OptionsView.ShowAutoFilterRow = true;
            this.GridViewIscilikler.OptionsView.ShowGroupPanel = false;
            this.GridViewIscilikler.OptionsView.ShowViewCaption = true;
            this.GridViewIscilikler.ViewCaption = "İşçilikler Listesi";
            this.GridViewIscilikler.DoubleClick += new System.EventHandler(this.GridViewIscilikler_DoubleClick);
            // 
            // colIscilikID
            // 
            this.colIscilikID.AppearanceCell.Options.UseTextOptions = true;
            this.colIscilikID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIscilikID.Caption = "İşçilik No";
            this.colIscilikID.FieldName = "IscilikID";
            this.colIscilikID.MaxWidth = 60;
            this.colIscilikID.MinWidth = 50;
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
            this.colIscilikAd.Width = 292;
            // 
            // colIscilikTipAciklama
            // 
            this.colIscilikTipAciklama.Caption = "İşçilik Tipi";
            this.colIscilikTipAciklama.FieldName = "IscilikTipAciklama";
            this.colIscilikTipAciklama.MaxWidth = 70;
            this.colIscilikTipAciklama.Name = "colIscilikTipAciklama";
            this.colIscilikTipAciklama.Visible = true;
            this.colIscilikTipAciklama.VisibleIndex = 2;
            this.colIscilikTipAciklama.Width = 70;
            // 
            // colKacSaat
            // 
            this.colKacSaat.Caption = "Kaç Saat";
            this.colKacSaat.FieldName = "KacSaat";
            this.colKacSaat.MaxWidth = 60;
            this.colKacSaat.MinWidth = 50;
            this.colKacSaat.Name = "colKacSaat";
            this.colKacSaat.Visible = true;
            this.colKacSaat.VisibleIndex = 3;
            this.colKacSaat.Width = 50;
            // 
            // colIscilikTip
            // 
            this.colIscilikTip.Caption = "IscilikTip";
            this.colIscilikTip.FieldName = "IscilikTip";
            this.colIscilikTip.Name = "colIscilikTip";
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(283, 321);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 263;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Cikis;
            this.btnCikis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCikis.Location = new System.Drawing.Point(344, 320);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(80, 25);
            this.btnCikis.TabIndex = 262;
            this.btnCikis.Text = "maviButon2";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnSec
            // 
            this.btnSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSec.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Sec;
            this.btnSec.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSec.Image = ((System.Drawing.Image)(resources.GetObject("btnSec.Image")));
            this.btnSec.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSec.Location = new System.Drawing.Point(430, 320);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(76, 25);
            this.btnSec.TabIndex = 261;
            this.btnSec.Text = "maviButon1";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // frmIscilikSec
            // 
            this.AcceptButton = this.btnSec;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCikis;
            this.ClientSize = new System.Drawing.Size(513, 351);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.gridControlIscilikler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIscilikSec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ucIscilikSec";
            this.Load += new System.EventHandler(this.ucIscilikSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIscilikler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewIscilikler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlIscilikler;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewIscilikler;
        private DevExpress.XtraGrid.Columns.GridColumn colIscilikID;
        private DevExpress.XtraGrid.Columns.GridColumn colIscilikAd;
        private DevExpress.XtraGrid.Columns.GridColumn colIscilikTipAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn colKacSaat;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.MaviButon btnCikis;
        private Bilesenler.MaviButon btnSec;
        private DevExpress.XtraGrid.Columns.GridColumn colIscilikTip;
    }
}