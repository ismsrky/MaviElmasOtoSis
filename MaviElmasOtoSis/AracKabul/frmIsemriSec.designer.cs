namespace MaviElmasOtoSis.AracKabul
{
    partial class frmIsemriSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIsemriSec));
            this.gridControlIsemirleri = new DevExpress.XtraGrid.GridControl();
            this.GridViewIsemirleri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsemirID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServisID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnvan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAracID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKayitZaman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikis = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnSec = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.lookUpIsemriKapatma = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIsemirleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewIsemirleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpIsemriKapatma.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlIsemirleri
            // 
            this.gridControlIsemirleri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlIsemirleri.Location = new System.Drawing.Point(0, 0);
            this.gridControlIsemirleri.MainView = this.GridViewIsemirleri;
            this.gridControlIsemirleri.Name = "gridControlIsemirleri";
            this.gridControlIsemirleri.Size = new System.Drawing.Size(592, 237);
            this.gridControlIsemirleri.TabIndex = 232;
            this.gridControlIsemirleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewIsemirleri});
            // 
            // GridViewIsemirleri
            // 
            this.GridViewIsemirleri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsemirID,
            this.colBirim,
            this.colServisID,
            this.colUnvan,
            this.colAracID,
            this.colPlaka,
            this.colKayitZaman});
            this.GridViewIsemirleri.GridControl = this.gridControlIsemirleri;
            this.GridViewIsemirleri.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.GridViewIsemirleri.Name = "GridViewIsemirleri";
            this.GridViewIsemirleri.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewIsemirleri.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewIsemirleri.OptionsBehavior.Editable = false;
            this.GridViewIsemirleri.OptionsBehavior.ReadOnly = true;
            this.GridViewIsemirleri.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewIsemirleri.OptionsView.ColumnAutoWidth = false;
            this.GridViewIsemirleri.OptionsView.ShowAutoFilterRow = true;
            this.GridViewIsemirleri.OptionsView.ShowGroupPanel = false;
            this.GridViewIsemirleri.OptionsView.ShowIndicator = false;
            this.GridViewIsemirleri.OptionsView.ShowViewCaption = true;
            this.GridViewIsemirleri.ViewCaption = "İşemirleri Listesi";
            this.GridViewIsemirleri.DoubleClick += new System.EventHandler(this.GridViewIsemirleri_DoubleClick);
            // 
            // colIsemirID
            // 
            this.colIsemirID.Caption = "İşemir No";
            this.colIsemirID.FieldName = "IsemirID";
            this.colIsemirID.MaxWidth = 62;
            this.colIsemirID.MinWidth = 62;
            this.colIsemirID.Name = "colIsemirID";
            this.colIsemirID.Visible = true;
            this.colIsemirID.VisibleIndex = 0;
            this.colIsemirID.Width = 62;
            // 
            // colBirim
            // 
            this.colBirim.Caption = "İşemri Birim";
            this.colBirim.FieldName = "BirimAd";
            this.colBirim.MaxWidth = 80;
            this.colBirim.MinWidth = 80;
            this.colBirim.Name = "colBirim";
            this.colBirim.Visible = true;
            this.colBirim.VisibleIndex = 1;
            this.colBirim.Width = 80;
            // 
            // colServisID
            // 
            this.colServisID.Caption = "Servis No";
            this.colServisID.FieldName = "ServisID";
            this.colServisID.MaxWidth = 62;
            this.colServisID.MinWidth = 62;
            this.colServisID.Name = "colServisID";
            this.colServisID.Visible = true;
            this.colServisID.VisibleIndex = 2;
            this.colServisID.Width = 62;
            // 
            // colUnvan
            // 
            this.colUnvan.Caption = "Cari Ünvanı";
            this.colUnvan.FieldName = "Unvan";
            this.colUnvan.MaxWidth = 180;
            this.colUnvan.MinWidth = 180;
            this.colUnvan.Name = "colUnvan";
            this.colUnvan.Visible = true;
            this.colUnvan.VisibleIndex = 3;
            this.colUnvan.Width = 180;
            // 
            // colAracID
            // 
            this.colAracID.Caption = "Araç No";
            this.colAracID.MinWidth = 62;
            this.colAracID.Name = "colAracID";
            this.colAracID.Visible = true;
            this.colAracID.VisibleIndex = 4;
            this.colAracID.Width = 62;
            // 
            // colPlaka
            // 
            this.colPlaka.Caption = "Plaka";
            this.colPlaka.FieldName = "Plaka";
            this.colPlaka.MaxWidth = 70;
            this.colPlaka.MinWidth = 70;
            this.colPlaka.Name = "colPlaka";
            this.colPlaka.Visible = true;
            this.colPlaka.VisibleIndex = 5;
            this.colPlaka.Width = 70;
            // 
            // colKayitZaman
            // 
            this.colKayitZaman.Caption = "Kayıt Tarih";
            this.colKayitZaman.FieldName = "KayitZaman";
            this.colKayitZaman.MaxWidth = 70;
            this.colKayitZaman.MinWidth = 70;
            this.colKayitZaman.Name = "colKayitZaman";
            this.colKayitZaman.Visible = true;
            this.colKayitZaman.VisibleIndex = 6;
            this.colKayitZaman.Width = 70;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(364, 244);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 266;
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
            this.btnCikis.Location = new System.Drawing.Point(425, 243);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(80, 25);
            this.btnCikis.TabIndex = 265;
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
            this.btnSec.Location = new System.Drawing.Point(511, 243);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(76, 25);
            this.btnSec.TabIndex = 264;
            this.btnSec.Text = "maviButon1";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // lookUpIsemriKapatma
            // 
            this.lookUpIsemriKapatma.Location = new System.Drawing.Point(67, 242);
            this.lookUpIsemriKapatma.Name = "lookUpIsemriKapatma";
            this.lookUpIsemriKapatma.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpIsemriKapatma.Properties.Appearance.Options.UseFont = true;
            this.lookUpIsemriKapatma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpIsemriKapatma.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Kapanma Durumu")});
            this.lookUpIsemriKapatma.Properties.NullText = "";
            this.lookUpIsemriKapatma.Size = new System.Drawing.Size(154, 22);
            this.lookUpIsemriKapatma.TabIndex = 313;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl16.Location = new System.Drawing.Point(8, 244);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(53, 16);
            this.labelControl16.TabIndex = 312;
            this.labelControl16.Text = "Durumu :";
            // 
            // frmIsemriSec
            // 
            this.AcceptButton = this.btnSec;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCikis;
            this.ClientSize = new System.Drawing.Size(592, 276);
            this.Controls.Add(this.lookUpIsemriKapatma);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.gridControlIsemirleri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIsemriSec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIsemriSec";
            this.Load += new System.EventHandler(this.frmIsemriSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlIsemirleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewIsemirleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpIsemriKapatma.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlIsemirleri;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewIsemirleri;
        private DevExpress.XtraGrid.Columns.GridColumn colServisID;
        private DevExpress.XtraGrid.Columns.GridColumn colUnvan;
        private DevExpress.XtraGrid.Columns.GridColumn colAracID;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaka;
        private DevExpress.XtraGrid.Columns.GridColumn colKayitZaman;
        private DevExpress.XtraGrid.Columns.GridColumn colIsemirID;
        private DevExpress.XtraGrid.Columns.GridColumn colBirim;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.MaviButon btnCikis;
        private Bilesenler.MaviButon btnSec;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        public DevExpress.XtraEditors.LookUpEdit lookUpIsemriKapatma;
    }
}