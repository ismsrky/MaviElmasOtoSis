namespace MaviElmasOtoSis.Stok
{
    partial class ucStokDepo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStokDepo));
            this.gridControlStokDepo = new DevExpress.XtraGrid.GridControl();
            this.GridViewStokDepo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDepoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepoAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKilitli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupDepoBilgileri = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.memoAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.memoLokasyon = new DevExpress.XtraEditors.MemoEdit();
            this.chkKilitli = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDepoID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtDepoAd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl75 = new DevExpress.XtraEditors.LabelControl();
            this.ucKayitBilgi1 = new MaviElmasOtoSis.Sistem.ucKayitBilgi();
            this.btnSil = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnKaydet = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnYeniKayit = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStokDepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewStokDepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDepoBilgileri)).BeginInit();
            this.groupDepoBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoLokasyon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKilitli.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoAd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlStokDepo
            // 
            this.gridControlStokDepo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlStokDepo.Location = new System.Drawing.Point(3, 3);
            this.gridControlStokDepo.MainView = this.GridViewStokDepo;
            this.gridControlStokDepo.Name = "gridControlStokDepo";
            this.gridControlStokDepo.Size = new System.Drawing.Size(802, 250);
            this.gridControlStokDepo.TabIndex = 232;
            this.gridControlStokDepo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewStokDepo});
            // 
            // GridViewStokDepo
            // 
            this.GridViewStokDepo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDepoID,
            this.colDepoAd,
            this.colKilitli});
            this.GridViewStokDepo.GridControl = this.gridControlStokDepo;
            this.GridViewStokDepo.Name = "GridViewStokDepo";
            this.GridViewStokDepo.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewStokDepo.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewStokDepo.OptionsBehavior.Editable = false;
            this.GridViewStokDepo.OptionsBehavior.ReadOnly = true;
            this.GridViewStokDepo.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewStokDepo.OptionsView.ShowAutoFilterRow = true;
            this.GridViewStokDepo.OptionsView.ShowGroupPanel = false;
            this.GridViewStokDepo.OptionsView.ShowViewCaption = true;
            this.GridViewStokDepo.ViewCaption = "Depolar Listesi";
            this.GridViewStokDepo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewStokDepo_FocusedRowChanged);
            this.GridViewStokDepo.Click += new System.EventHandler(this.GridViewStokDepo_Click);
            // 
            // colDepoID
            // 
            this.colDepoID.AppearanceCell.Options.UseTextOptions = true;
            this.colDepoID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDepoID.Caption = "Depo No";
            this.colDepoID.FieldName = "DepoID";
            this.colDepoID.MaxWidth = 50;
            this.colDepoID.Name = "colDepoID";
            this.colDepoID.Visible = true;
            this.colDepoID.VisibleIndex = 0;
            this.colDepoID.Width = 50;
            // 
            // colDepoAd
            // 
            this.colDepoAd.Caption = "Depo Adı";
            this.colDepoAd.FieldName = "DepoAd";
            this.colDepoAd.Name = "colDepoAd";
            this.colDepoAd.Visible = true;
            this.colDepoAd.VisibleIndex = 1;
            this.colDepoAd.Width = 579;
            // 
            // colKilitli
            // 
            this.colKilitli.Caption = "Kilitli";
            this.colKilitli.FieldName = "Kilitli";
            this.colKilitli.Name = "colKilitli";
            this.colKilitli.Visible = true;
            this.colKilitli.VisibleIndex = 2;
            this.colKilitli.Width = 155;
            // 
            // groupDepoBilgileri
            // 
            this.groupDepoBilgileri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupDepoBilgileri.Controls.Add(this.labelControl1);
            this.groupDepoBilgileri.Controls.Add(this.memoAciklama);
            this.groupDepoBilgileri.Controls.Add(this.labelControl9);
            this.groupDepoBilgileri.Controls.Add(this.memoLokasyon);
            this.groupDepoBilgileri.Controls.Add(this.chkKilitli);
            this.groupDepoBilgileri.Controls.Add(this.labelControl6);
            this.groupDepoBilgileri.Controls.Add(this.txtDepoID);
            this.groupDepoBilgileri.Controls.Add(this.labelControl4);
            this.groupDepoBilgileri.Controls.Add(this.txtDepoAd);
            this.groupDepoBilgileri.Controls.Add(this.labelControl75);
            this.groupDepoBilgileri.Location = new System.Drawing.Point(3, 259);
            this.groupDepoBilgileri.Name = "groupDepoBilgileri";
            this.groupDepoBilgileri.Size = new System.Drawing.Size(667, 203);
            this.groupDepoBilgileri.TabIndex = 237;
            this.groupDepoBilgileri.Text = "Depo Bilgileri";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Location = new System.Drawing.Point(369, 91);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 246;
            this.labelControl1.Text = "Açıklama :";
            // 
            // memoAciklama
            // 
            this.memoAciklama.Location = new System.Drawing.Point(441, 89);
            this.memoAciklama.Name = "memoAciklama";
            this.memoAciklama.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.memoAciklama.Properties.Appearance.Options.UseFont = true;
            this.memoAciklama.Properties.MaxLength = 150;
            this.memoAciklama.Size = new System.Drawing.Size(215, 86);
            this.memoAciklama.TabIndex = 245;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Location = new System.Drawing.Point(40, 91);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(64, 16);
            this.labelControl9.TabIndex = 244;
            this.labelControl9.Text = "Lokasyon :";
            // 
            // memoLokasyon
            // 
            this.memoLokasyon.Location = new System.Drawing.Point(112, 90);
            this.memoLokasyon.Name = "memoLokasyon";
            this.memoLokasyon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.memoLokasyon.Properties.Appearance.Options.UseFont = true;
            this.memoLokasyon.Properties.MaxLength = 150;
            this.memoLokasyon.Size = new System.Drawing.Size(215, 86);
            this.memoLokasyon.TabIndex = 243;
            // 
            // chkKilitli
            // 
            this.chkKilitli.Location = new System.Drawing.Point(264, 35);
            this.chkKilitli.Name = "chkKilitli";
            this.chkKilitli.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.chkKilitli.Properties.Appearance.ForeColor = System.Drawing.Color.Green;
            this.chkKilitli.Properties.Appearance.Options.UseFont = true;
            this.chkKilitli.Properties.Appearance.Options.UseForeColor = true;
            this.chkKilitli.Properties.Caption = "Hayır";
            this.chkKilitli.Size = new System.Drawing.Size(63, 21);
            this.chkKilitli.TabIndex = 236;
            this.chkKilitli.CheckedChanged += new System.EventHandler(this.chkKilitli_CheckedChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Location = new System.Drawing.Point(222, 38);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 16);
            this.labelControl6.TabIndex = 67;
            this.labelControl6.Text = "Kilitli :";
            // 
            // txtDepoID
            // 
            this.txtDepoID.Location = new System.Drawing.Point(112, 34);
            this.txtDepoID.Name = "txtDepoID";
            this.txtDepoID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDepoID.Properties.Appearance.Options.UseFont = true;
            this.txtDepoID.Properties.ReadOnly = true;
            this.txtDepoID.Size = new System.Drawing.Size(61, 22);
            this.txtDepoID.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Location = new System.Drawing.Point(46, 37);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 16);
            this.labelControl4.TabIndex = 44;
            this.labelControl4.Text = "Depo No :";
            // 
            // txtDepoAd
            // 
            this.txtDepoAd.Location = new System.Drawing.Point(112, 62);
            this.txtDepoAd.Name = "txtDepoAd";
            this.txtDepoAd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDepoAd.Properties.Appearance.Options.UseFont = true;
            this.txtDepoAd.Size = new System.Drawing.Size(215, 22);
            this.txtDepoAd.TabIndex = 2;
            // 
            // labelControl75
            // 
            this.labelControl75.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl75.Location = new System.Drawing.Point(43, 65);
            this.labelControl75.Name = "labelControl75";
            this.labelControl75.Size = new System.Drawing.Size(61, 16);
            this.labelControl75.TabIndex = 30;
            this.labelControl75.Text = "Depo Adı :";
            // 
            // ucKayitBilgi1
            // 
            this.ucKayitBilgi1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.ucKayitBilgi1.Appearance.Options.UseBackColor = true;
            this.ucKayitBilgi1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucKayitBilgi1.GostermeSekli = MaviElmasOtoSis.Sistem.ucKayitBilgi.GostermeSekilleri.Hepsi;
            this.ucKayitBilgi1.GosterSimge = true;
            this.ucKayitBilgi1.Location = new System.Drawing.Point(0, 471);
            this.ucKayitBilgi1.Name = "ucKayitBilgi1";
            this.ucKayitBilgi1.Size = new System.Drawing.Size(808, 45);
            this.ucKayitBilgi1.TabIndex = 238;
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSil.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Sil;
            this.btnSil.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSil.Location = new System.Drawing.Point(521, 481);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(70, 25);
            this.btnSil.TabIndex = 241;
            this.btnSil.Text = "maviButon3";
            this.btnSil.ToolTip = "Del - Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKaydet.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Kaydet;
            this.btnKaydet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnKaydet.Location = new System.Drawing.Point(713, 481);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(92, 25);
            this.btnKaydet.TabIndex = 239;
            this.btnKaydet.Text = "maviButon2";
            this.btnKaydet.ToolTip = "F2 - Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnYeniKayit
            // 
            this.btnYeniKayit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYeniKayit.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Yeni;
            this.btnYeniKayit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnYeniKayit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYeniKayit.Image = ((System.Drawing.Image)(resources.GetObject("btnYeniKayit.Image")));
            this.btnYeniKayit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnYeniKayit.Location = new System.Drawing.Point(597, 481);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(110, 25);
            this.btnYeniKayit.TabIndex = 240;
            this.btnYeniKayit.Text = "maviButon1";
            this.btnYeniKayit.ToolTip = "F3 - Yeni Kayıt";
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(750, 259);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 276;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnYazdir1
            // 
            this.btnYazdir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYazdir1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYazdir1.Image = ((System.Drawing.Image)(resources.GetObject("btnYazdir1.Image")));
            this.btnYazdir1.KaynakView = this.GridViewStokDepo;
            this.btnYazdir1.Location = new System.Drawing.Point(682, 260);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 275;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // ucStokDepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnYazdir1);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnYeniKayit);
            this.Controls.Add(this.ucKayitBilgi1);
            this.Controls.Add(this.groupDepoBilgileri);
            this.Controls.Add(this.gridControlStokDepo);
            this.Name = "ucStokDepo";
            this.Size = new System.Drawing.Size(808, 516);
            this.Load += new System.EventHandler(this.ucStokDepo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStokDepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewStokDepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDepoBilgileri)).EndInit();
            this.groupDepoBilgileri.ResumeLayout(false);
            this.groupDepoBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoLokasyon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKilitli.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoAd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlStokDepo;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewStokDepo;
        private DevExpress.XtraGrid.Columns.GridColumn colDepoID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepoAd;
        private DevExpress.XtraGrid.Columns.GridColumn colKilitli;
        private DevExpress.XtraEditors.GroupControl groupDepoBilgileri;
        private DevExpress.XtraEditors.CheckEdit chkKilitli;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtDepoID;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtDepoAd;
        private DevExpress.XtraEditors.LabelControl labelControl75;
        private Sistem.ucKayitBilgi ucKayitBilgi1;
        private Bilesenler.MaviButon btnSil;
        private Bilesenler.MaviButon btnKaydet;
        private Bilesenler.MaviButon btnYeniKayit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memoAciklama;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit memoLokasyon;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.btnYazdir btnYazdir1;
    }
}
