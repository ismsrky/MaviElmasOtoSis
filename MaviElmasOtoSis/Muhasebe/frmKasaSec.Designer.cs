namespace MaviElmasOtoSis.Muhasebe
{
    partial class frmKasaSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasaSec));
            this.gridControlKasalar = new DevExpress.XtraGrid.GridControl();
            this.GridViewKasalar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKasaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKasAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikis = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnSec = new MaviElmasOtoSis.Bilesenler.MaviButon();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKasalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewKasalar)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlKasalar
            // 
            this.gridControlKasalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlKasalar.Location = new System.Drawing.Point(0, 0);
            this.gridControlKasalar.MainView = this.GridViewKasalar;
            this.gridControlKasalar.Name = "gridControlKasalar";
            this.gridControlKasalar.Size = new System.Drawing.Size(618, 269);
            this.gridControlKasalar.TabIndex = 234;
            this.gridControlKasalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewKasalar});
            // 
            // GridViewKasalar
            // 
            this.GridViewKasalar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKasaID,
            this.colKasAd});
            this.GridViewKasalar.GridControl = this.gridControlKasalar;
            this.GridViewKasalar.Name = "GridViewKasalar";
            this.GridViewKasalar.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewKasalar.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewKasalar.OptionsBehavior.Editable = false;
            this.GridViewKasalar.OptionsBehavior.ReadOnly = true;
            this.GridViewKasalar.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewKasalar.OptionsView.ShowAutoFilterRow = true;
            this.GridViewKasalar.OptionsView.ShowGroupPanel = false;
            this.GridViewKasalar.OptionsView.ShowViewCaption = true;
            this.GridViewKasalar.ViewCaption = "Kasalar Listesi";
            this.GridViewKasalar.DoubleClick += new System.EventHandler(this.GridViewKasalar_DoubleClick);
            // 
            // colKasaID
            // 
            this.colKasaID.AppearanceCell.Options.UseTextOptions = true;
            this.colKasaID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKasaID.Caption = "Kasa No";
            this.colKasaID.FieldName = "KasaID";
            this.colKasaID.MaxWidth = 50;
            this.colKasaID.MinWidth = 40;
            this.colKasaID.Name = "colKasaID";
            this.colKasaID.Visible = true;
            this.colKasaID.VisibleIndex = 0;
            this.colKasaID.Width = 50;
            // 
            // colKasAd
            // 
            this.colKasAd.Caption = "Kasa Adı";
            this.colKasAd.FieldName = "KasaAd";
            this.colKasAd.Name = "colKasAd";
            this.colKasAd.Visible = true;
            this.colKasAd.VisibleIndex = 1;
            this.colKasAd.Width = 204;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(390, 275);
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
            this.btnCikis.Location = new System.Drawing.Point(451, 274);
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
            this.btnSec.Location = new System.Drawing.Point(537, 274);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(76, 25);
            this.btnSec.TabIndex = 262;
            this.btnSec.Text = "maviButon1";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // frmKasaSec
            // 
            this.AcceptButton = this.btnSec;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCikis;
            this.ClientSize = new System.Drawing.Size(617, 305);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.gridControlKasalar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKasaSec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKasaSec";
            this.Load += new System.EventHandler(this.frmKasaSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKasalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewKasalar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlKasalar;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewKasalar;
        private DevExpress.XtraGrid.Columns.GridColumn colKasaID;
        private DevExpress.XtraGrid.Columns.GridColumn colKasAd;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.MaviButon btnCikis;
        private Bilesenler.MaviButon btnSec;
    }
}