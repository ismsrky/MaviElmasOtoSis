namespace MaviElmasOtoSis.Muhasebe
{
    partial class frmCariHesapSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCariHesapSec));
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikis = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnSec = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.gridControlCariler = new DevExpress.XtraGrid.GridControl();
            this.GridViewCariler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCariID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnvan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCariHesapGrup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTcKimlikNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYetkiliKisi = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCariler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCariler)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(452, 302);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 261;
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
            this.btnCikis.TabIndex = 260;
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
            this.btnSec.TabIndex = 259;
            this.btnSec.Text = "maviButon1";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // gridControlCariler
            // 
            this.gridControlCariler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlCariler.Location = new System.Drawing.Point(2, 1);
            this.gridControlCariler.MainView = this.GridViewCariler;
            this.gridControlCariler.Name = "gridControlCariler";
            this.gridControlCariler.Size = new System.Drawing.Size(679, 294);
            this.gridControlCariler.TabIndex = 262;
            this.gridControlCariler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewCariler});
            // 
            // GridViewCariler
            // 
            this.GridViewCariler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCariID,
            this.colUnvan,
            this.colCariHesapGrup,
            this.colTcKimlikNo,
            this.colYetkiliKisi});
            this.GridViewCariler.GridControl = this.gridControlCariler;
            this.GridViewCariler.Name = "GridViewCariler";
            this.GridViewCariler.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewCariler.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewCariler.OptionsBehavior.Editable = false;
            this.GridViewCariler.OptionsBehavior.ReadOnly = true;
            this.GridViewCariler.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewCariler.OptionsView.ShowAutoFilterRow = true;
            this.GridViewCariler.OptionsView.ShowGroupPanel = false;
            this.GridViewCariler.OptionsView.ShowIndicator = false;
            this.GridViewCariler.OptionsView.ShowViewCaption = true;
            this.GridViewCariler.ViewCaption = "Cari Hesaplar Listesi";
            this.GridViewCariler.DoubleClick += new System.EventHandler(this.GridViewCariler_DoubleClick);
            // 
            // colCariID
            // 
            this.colCariID.AppearanceCell.Options.UseTextOptions = true;
            this.colCariID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCariID.Caption = "Cari No";
            this.colCariID.FieldName = "CariID";
            this.colCariID.MaxWidth = 45;
            this.colCariID.MinWidth = 45;
            this.colCariID.Name = "colCariID";
            this.colCariID.Visible = true;
            this.colCariID.VisibleIndex = 0;
            this.colCariID.Width = 45;
            // 
            // colUnvan
            // 
            this.colUnvan.Caption = "Ünvanı";
            this.colUnvan.FieldName = "Unvan";
            this.colUnvan.Name = "colUnvan";
            this.colUnvan.Visible = true;
            this.colUnvan.VisibleIndex = 1;
            this.colUnvan.Width = 281;
            // 
            // colCariHesapGrup
            // 
            this.colCariHesapGrup.Caption = "Cari Grubu";
            this.colCariHesapGrup.FieldName = "CariHesapGrup";
            this.colCariHesapGrup.MaxWidth = 120;
            this.colCariHesapGrup.MinWidth = 120;
            this.colCariHesapGrup.Name = "colCariHesapGrup";
            this.colCariHesapGrup.Visible = true;
            this.colCariHesapGrup.VisibleIndex = 2;
            this.colCariHesapGrup.Width = 120;
            // 
            // colTcKimlikNo
            // 
            this.colTcKimlikNo.Caption = "TC Kimlik No / V. No";
            this.colTcKimlikNo.FieldName = "TcKimlikNo";
            this.colTcKimlikNo.MaxWidth = 100;
            this.colTcKimlikNo.MinWidth = 85;
            this.colTcKimlikNo.Name = "colTcKimlikNo";
            this.colTcKimlikNo.Visible = true;
            this.colTcKimlikNo.VisibleIndex = 3;
            this.colTcKimlikNo.Width = 100;
            // 
            // colYetkiliKisi
            // 
            this.colYetkiliKisi.Caption = "Yetkili Kişi";
            this.colYetkiliKisi.FieldName = "YetkiliKisi";
            this.colYetkiliKisi.MaxWidth = 120;
            this.colYetkiliKisi.MinWidth = 120;
            this.colYetkiliKisi.Name = "colYetkiliKisi";
            this.colYetkiliKisi.Visible = true;
            this.colYetkiliKisi.VisibleIndex = 4;
            this.colYetkiliKisi.Width = 120;
            // 
            // frmCariHesapSec
            // 
            this.AcceptButton = this.btnSec;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCikis;
            this.ClientSize = new System.Drawing.Size(681, 334);
            this.Controls.Add(this.gridControlCariler);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCariHesapSec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCariHesapSec";
            this.Load += new System.EventHandler(this.frmCariHesapSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCariler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCariler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.MaviButon btnCikis;
        private Bilesenler.MaviButon btnSec;
        private DevExpress.XtraGrid.GridControl gridControlCariler;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewCariler;
        private DevExpress.XtraGrid.Columns.GridColumn colCariID;
        private DevExpress.XtraGrid.Columns.GridColumn colUnvan;
        private DevExpress.XtraGrid.Columns.GridColumn colCariHesapGrup;
        private DevExpress.XtraGrid.Columns.GridColumn colTcKimlikNo;
        private DevExpress.XtraGrid.Columns.GridColumn colYetkiliKisi;
    }
}