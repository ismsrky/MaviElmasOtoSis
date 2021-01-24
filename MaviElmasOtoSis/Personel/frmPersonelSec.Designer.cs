namespace MaviElmasOtoSis.Personel
{
    partial class frmPersonelSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonelSec));
            this.gridControlPersoneller = new DevExpress.XtraGrid.GridControl();
            this.GridViewPersoneller = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPersonelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTCKimlikNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnvan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCinsiyet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikis = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnSec = new MaviElmasOtoSis.Bilesenler.MaviButon();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPersoneller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPersoneller)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlPersoneller
            // 
            this.gridControlPersoneller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlPersoneller.Location = new System.Drawing.Point(0, 5);
            this.gridControlPersoneller.MainView = this.GridViewPersoneller;
            this.gridControlPersoneller.Name = "gridControlPersoneller";
            this.gridControlPersoneller.Size = new System.Drawing.Size(841, 305);
            this.gridControlPersoneller.TabIndex = 234;
            this.gridControlPersoneller.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewPersoneller});
            // 
            // GridViewPersoneller
            // 
            this.GridViewPersoneller.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPersonelID,
            this.colTCKimlikNo,
            this.colAd,
            this.colSoyad,
            this.colUnvan,
            this.colCinsiyet});
            this.GridViewPersoneller.GridControl = this.gridControlPersoneller;
            this.GridViewPersoneller.Name = "GridViewPersoneller";
            this.GridViewPersoneller.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewPersoneller.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewPersoneller.OptionsBehavior.Editable = false;
            this.GridViewPersoneller.OptionsBehavior.ReadOnly = true;
            this.GridViewPersoneller.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewPersoneller.OptionsView.ShowAutoFilterRow = true;
            this.GridViewPersoneller.OptionsView.ShowGroupPanel = false;
            this.GridViewPersoneller.OptionsView.ShowViewCaption = true;
            this.GridViewPersoneller.ViewCaption = "Personeller Listesi";
            this.GridViewPersoneller.DoubleClick += new System.EventHandler(this.GridViewPersoneller_DoubleClick);
            // 
            // colPersonelID
            // 
            this.colPersonelID.AppearanceCell.Options.UseTextOptions = true;
            this.colPersonelID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPersonelID.Caption = "Per. No";
            this.colPersonelID.FieldName = "PersonelID";
            this.colPersonelID.MaxWidth = 55;
            this.colPersonelID.Name = "colPersonelID";
            this.colPersonelID.Visible = true;
            this.colPersonelID.VisibleIndex = 0;
            this.colPersonelID.Width = 54;
            // 
            // colTCKimlikNo
            // 
            this.colTCKimlikNo.Caption = "Tc Kimlik No";
            this.colTCKimlikNo.FieldName = "TcKimlikNo";
            this.colTCKimlikNo.MaxWidth = 115;
            this.colTCKimlikNo.MinWidth = 110;
            this.colTCKimlikNo.Name = "colTCKimlikNo";
            this.colTCKimlikNo.Visible = true;
            this.colTCKimlikNo.VisibleIndex = 1;
            this.colTCKimlikNo.Width = 112;
            // 
            // colAd
            // 
            this.colAd.Caption = "Adı";
            this.colAd.FieldName = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.Visible = true;
            this.colAd.VisibleIndex = 2;
            this.colAd.Width = 210;
            // 
            // colSoyad
            // 
            this.colSoyad.Caption = "Soyad";
            this.colSoyad.FieldName = "Soyad";
            this.colSoyad.Name = "colSoyad";
            this.colSoyad.Visible = true;
            this.colSoyad.VisibleIndex = 3;
            this.colSoyad.Width = 252;
            // 
            // colUnvan
            // 
            this.colUnvan.Caption = "Ünvanı";
            this.colUnvan.FieldName = "Unvan";
            this.colUnvan.Name = "colUnvan";
            this.colUnvan.Visible = true;
            this.colUnvan.VisibleIndex = 4;
            this.colUnvan.Width = 100;
            // 
            // colCinsiyet
            // 
            this.colCinsiyet.Caption = "Cinsiyet";
            this.colCinsiyet.FieldName = "Cinsiyet";
            this.colCinsiyet.Name = "colCinsiyet";
            this.colCinsiyet.Visible = true;
            this.colCinsiyet.VisibleIndex = 5;
            this.colCinsiyet.Width = 95;
            // 
            // btnYenile
            // 
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(618, 314);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 260;
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
            this.btnCikis.Location = new System.Drawing.Point(679, 313);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(80, 25);
            this.btnCikis.TabIndex = 259;
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
            this.btnSec.Location = new System.Drawing.Point(765, 313);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(76, 25);
            this.btnSec.TabIndex = 258;
            this.btnSec.Text = "maviButon1";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // frmPersonelSec
            // 
            this.AcceptButton = this.btnSec;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCikis;
            this.ClientSize = new System.Drawing.Size(844, 344);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.gridControlPersoneller);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonelSec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ucPersonelSec";
            this.Load += new System.EventHandler(this.ucPersonelSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPersoneller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPersoneller)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPersoneller;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewPersoneller;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonelID;
        private DevExpress.XtraGrid.Columns.GridColumn colTCKimlikNo;
        private DevExpress.XtraGrid.Columns.GridColumn colAd;
        private DevExpress.XtraGrid.Columns.GridColumn colSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn colUnvan;
        private DevExpress.XtraGrid.Columns.GridColumn colCinsiyet;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.MaviButon btnCikis;
        private Bilesenler.MaviButon btnSec;
    }
}