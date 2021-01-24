namespace MaviElmasOtoSis.AracKabul
{
    partial class frmAracSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAracSec));
            this.gridControlAraclar = new DevExpress.XtraGrid.GridControl();
            this.GridViewAraclar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAracID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuhsatSahibi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikis = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnSec = new MaviElmasOtoSis.Bilesenler.MaviButon();
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
            this.gridControlAraclar.Size = new System.Drawing.Size(701, 250);
            this.gridControlAraclar.TabIndex = 233;
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
            this.GridViewAraclar.OptionsView.ShowGroupPanel = false;
            this.GridViewAraclar.OptionsView.ShowViewCaption = true;
            this.GridViewAraclar.ViewCaption = "Araçlar";
            this.GridViewAraclar.DoubleClick += new System.EventHandler(this.GridViewAraclar_DoubleClick);
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
            this.colPlaka.Width = 68;
            // 
            // colRuhsatSahibi
            // 
            this.colRuhsatSahibi.Caption = "Ruhsat Sahibi";
            this.colRuhsatSahibi.FieldName = "RuhsatSahibi";
            this.colRuhsatSahibi.Name = "colRuhsatSahibi";
            this.colRuhsatSahibi.Visible = true;
            this.colRuhsatSahibi.VisibleIndex = 2;
            this.colRuhsatSahibi.Width = 185;
            // 
            // colSaseNo
            // 
            this.colSaseNo.Caption = "Şase No";
            this.colSaseNo.FieldName = "SaseNo";
            this.colSaseNo.Name = "colSaseNo";
            this.colSaseNo.Visible = true;
            this.colSaseNo.VisibleIndex = 3;
            this.colSaseNo.Width = 156;
            // 
            // colMarka
            // 
            this.colMarka.Caption = "Marka";
            this.colMarka.FieldName = "MarkaAdi";
            this.colMarka.Name = "colMarka";
            this.colMarka.Visible = true;
            this.colMarka.VisibleIndex = 4;
            this.colMarka.Width = 93;
            // 
            // colModel
            // 
            this.colModel.Caption = "Model";
            this.colModel.FieldName = "ModelAdi";
            this.colModel.Name = "colModel";
            this.colModel.Visible = true;
            this.colModel.VisibleIndex = 5;
            this.colModel.Width = 131;
            // 
            // btnYenile
            // 
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(481, 259);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 263;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Cikis;
            this.btnCikis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCikis.Location = new System.Drawing.Point(542, 258);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(80, 25);
            this.btnCikis.TabIndex = 262;
            this.btnCikis.Text = "maviButon2";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnSec
            // 
            this.btnSec.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Sec;
            this.btnSec.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSec.Image = ((System.Drawing.Image)(resources.GetObject("btnSec.Image")));
            this.btnSec.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSec.Location = new System.Drawing.Point(628, 258);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(76, 25);
            this.btnSec.TabIndex = 261;
            this.btnSec.Text = "maviButon1";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // frmAracSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 286);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.gridControlAraclar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAracSec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ucAracSec";
            this.Load += new System.EventHandler(this.ucAracSec_Load);
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
        private Bilesenler.MaviButon btnCikis;
        private Bilesenler.MaviButon btnSec;
    }
}