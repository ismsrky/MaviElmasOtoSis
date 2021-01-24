namespace MaviElmasOtoSis.Stok
{
    partial class frmStokKartSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokKartSec));
            this.gridControlStokKart = new DevExpress.XtraGrid.GridControl();
            this.GridViewStokKart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKalemAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParcaNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarkodNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokBirim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokGrup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSec = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnCikis = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStokKart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewStokKart)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlStokKart
            // 
            this.gridControlStokKart.Location = new System.Drawing.Point(0, 0);
            this.gridControlStokKart.MainView = this.GridViewStokKart;
            this.gridControlStokKart.Name = "gridControlStokKart";
            this.gridControlStokKart.Size = new System.Drawing.Size(893, 261);
            this.gridControlStokKart.TabIndex = 231;
            this.gridControlStokKart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewStokKart});
            // 
            // GridViewStokKart
            // 
            this.GridViewStokKart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKartID,
            this.colKalemAdi,
            this.colParcaNo,
            this.colStokMiktar,
            this.colBarkodNo,
            this.colStokBirim,
            this.colStokGrup});
            this.GridViewStokKart.GridControl = this.gridControlStokKart;
            this.GridViewStokKart.Name = "GridViewStokKart";
            this.GridViewStokKart.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewStokKart.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewStokKart.OptionsBehavior.Editable = false;
            this.GridViewStokKart.OptionsBehavior.ReadOnly = true;
            this.GridViewStokKart.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewStokKart.OptionsView.ShowAutoFilterRow = true;
            this.GridViewStokKart.OptionsView.ShowGroupPanel = false;
            this.GridViewStokKart.OptionsView.ShowViewCaption = true;
            this.GridViewStokKart.ViewCaption = "Stok Kartları";
            this.GridViewStokKart.DoubleClick += new System.EventHandler(this.GridViewStokKart_DoubleClick);
            // 
            // colKartID
            // 
            this.colKartID.AppearanceCell.Options.UseTextOptions = true;
            this.colKartID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKartID.Caption = "Kart No";
            this.colKartID.FieldName = "KartID";
            this.colKartID.MaxWidth = 50;
            this.colKartID.Name = "colKartID";
            this.colKartID.Visible = true;
            this.colKartID.VisibleIndex = 0;
            this.colKartID.Width = 50;
            // 
            // colKalemAdi
            // 
            this.colKalemAdi.Caption = "Kalem Adı";
            this.colKalemAdi.FieldName = "KalemAdi";
            this.colKalemAdi.Name = "colKalemAdi";
            this.colKalemAdi.Visible = true;
            this.colKalemAdi.VisibleIndex = 1;
            this.colKalemAdi.Width = 124;
            // 
            // colParcaNo
            // 
            this.colParcaNo.Caption = "Parça No";
            this.colParcaNo.FieldName = "ParcaNo";
            this.colParcaNo.Name = "colParcaNo";
            this.colParcaNo.Visible = true;
            this.colParcaNo.VisibleIndex = 2;
            this.colParcaNo.Width = 124;
            // 
            // colStokMiktar
            // 
            this.colStokMiktar.Caption = "Stok Miktarı";
            this.colStokMiktar.FieldName = "StokMiktar";
            this.colStokMiktar.MaxWidth = 75;
            this.colStokMiktar.MinWidth = 75;
            this.colStokMiktar.Name = "colStokMiktar";
            this.colStokMiktar.Visible = true;
            this.colStokMiktar.VisibleIndex = 3;
            // 
            // colBarkodNo
            // 
            this.colBarkodNo.Caption = "Barkod No";
            this.colBarkodNo.FieldName = "BarkodNo";
            this.colBarkodNo.Name = "colBarkodNo";
            this.colBarkodNo.Visible = true;
            this.colBarkodNo.VisibleIndex = 4;
            // 
            // colStokBirim
            // 
            this.colStokBirim.Caption = "Stok Birimi";
            this.colStokBirim.FieldName = "StokBirim";
            this.colStokBirim.Name = "colStokBirim";
            this.colStokBirim.Visible = true;
            this.colStokBirim.VisibleIndex = 5;
            // 
            // colStokGrup
            // 
            this.colStokGrup.Caption = "Stok Grubu";
            this.colStokGrup.FieldName = "StokGrup";
            this.colStokGrup.Name = "colStokGrup";
            this.colStokGrup.Visible = true;
            this.colStokGrup.VisibleIndex = 6;
            // 
            // btnSec
            // 
            this.btnSec.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Sec;
            this.btnSec.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSec.Image = ((System.Drawing.Image)(resources.GetObject("btnSec.Image")));
            this.btnSec.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSec.Location = new System.Drawing.Point(807, 267);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(76, 25);
            this.btnSec.TabIndex = 232;
            this.btnSec.Text = "maviButon1";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Cikis;
            this.btnCikis.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCikis.Location = new System.Drawing.Point(721, 267);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(80, 25);
            this.btnCikis.TabIndex = 233;
            this.btnCikis.Text = "maviButon2";
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(660, 268);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 257;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // frmStokKartSec
            // 
            this.AcceptButton = this.btnSec;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCikis;
            this.ClientSize = new System.Drawing.Size(895, 304);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.gridControlStokKart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStokKartSec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStokKartSec";
            this.Load += new System.EventHandler(this.frmStokKartSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStokKart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewStokKart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlStokKart;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewStokKart;
        private DevExpress.XtraGrid.Columns.GridColumn colKartID;
        private DevExpress.XtraGrid.Columns.GridColumn colKalemAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colParcaNo;
        private DevExpress.XtraGrid.Columns.GridColumn colStokBirim;
        private DevExpress.XtraGrid.Columns.GridColumn colStokGrup;
        private Bilesenler.MaviButon btnSec;
        private Bilesenler.MaviButon btnCikis;
        private DevExpress.XtraGrid.Columns.GridColumn colBarkodNo;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraGrid.Columns.GridColumn colStokMiktar;
    }
}