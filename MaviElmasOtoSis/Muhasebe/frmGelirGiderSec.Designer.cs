namespace MaviElmasOtoSis.Muhasebe
{
    partial class frmGelirGiderSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGelirGiderSec));
            this.gridControlGelirGider = new DevExpress.XtraGrid.GridControl();
            this.GridViewGelirGider = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGelirGiderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGelirGiderGrup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGelir = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikis = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnSec = new MaviElmasOtoSis.Bilesenler.MaviButon();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGelirGider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewGelirGider)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlGelirGider
            // 
            this.gridControlGelirGider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlGelirGider.Location = new System.Drawing.Point(0, 0);
            this.gridControlGelirGider.MainView = this.GridViewGelirGider;
            this.gridControlGelirGider.Name = "gridControlGelirGider";
            this.gridControlGelirGider.Size = new System.Drawing.Size(684, 295);
            this.gridControlGelirGider.TabIndex = 233;
            this.gridControlGelirGider.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewGelirGider});
            // 
            // GridViewGelirGider
            // 
            this.GridViewGelirGider.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGelirGiderID,
            this.colAd,
            this.colGelirGiderGrup,
            this.colGelir});
            this.GridViewGelirGider.GridControl = this.gridControlGelirGider;
            this.GridViewGelirGider.Name = "GridViewGelirGider";
            this.GridViewGelirGider.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewGelirGider.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewGelirGider.OptionsBehavior.Editable = false;
            this.GridViewGelirGider.OptionsBehavior.ReadOnly = true;
            this.GridViewGelirGider.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewGelirGider.OptionsView.ShowAutoFilterRow = true;
            this.GridViewGelirGider.OptionsView.ShowGroupPanel = false;
            this.GridViewGelirGider.OptionsView.ShowViewCaption = true;
            this.GridViewGelirGider.ViewCaption = "Gelir ve Gider Kalemleri Listesi";
            this.GridViewGelirGider.DoubleClick += new System.EventHandler(this.GridViewGelirGider_DoubleClick);
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
            this.colGelirGiderGrup.MaxWidth = 120;
            this.colGelirGiderGrup.MinWidth = 100;
            this.colGelirGiderGrup.Name = "colGelirGiderGrup";
            this.colGelirGiderGrup.Visible = true;
            this.colGelirGiderGrup.VisibleIndex = 2;
            this.colGelirGiderGrup.Width = 120;
            // 
            // colGelir
            // 
            this.colGelir.Caption = "Gelir / Gider";
            this.colGelir.FieldName = "Gelir";
            this.colGelir.MaxWidth = 65;
            this.colGelir.MinWidth = 65;
            this.colGelir.Name = "colGelir";
            this.colGelir.Visible = true;
            this.colGelir.VisibleIndex = 3;
            this.colGelir.Width = 65;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(452, 302);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 267;
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
            this.btnCikis.TabIndex = 266;
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
            this.btnSec.TabIndex = 265;
            this.btnSec.Text = "maviButon1";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // frmGelirGiderSec
            // 
            this.AcceptButton = this.btnSec;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCikis;
            this.ClientSize = new System.Drawing.Size(681, 334);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.gridControlGelirGider);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGelirGiderSec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGelirGiderSec";
            this.Load += new System.EventHandler(this.frmGelirGiderSec_Load);
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
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.MaviButon btnCikis;
        private Bilesenler.MaviButon btnSec;
    }
}