namespace MaviElmasOtoSis.Muhasebe
{
    partial class ucKasaDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKasaDetay));
            this.btnSil = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnKaydet = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnYeniKayit = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.tabKasa = new DevExpress.XtraTab.XtraTabControl();
            this.pageKasaTanim = new DevExpress.XtraTab.XtraTabPage();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            this.GridViewKasa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKasaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKasAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTahsilat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOdeme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBakiye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlKasa = new DevExpress.XtraGrid.GridControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl75 = new DevExpress.XtraEditors.LabelControl();
            this.txtKasaAd = new DevExpress.XtraEditors.TextEdit();
            this.txtKasaID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkDurum = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.memoAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.ucKayitBilgi1 = new MaviElmasOtoSis.Sistem.ucKayitBilgi();
            this.pageKasaHareketleri = new DevExpress.XtraTab.XtraTabPage();
            this.ucKasaHareket1 = new MaviElmasOtoSis.Muhasebe.ucKasaHareket();
            ((System.ComponentModel.ISupportInitialize)(this.tabKasa)).BeginInit();
            this.tabKasa.SuspendLayout();
            this.pageKasaTanim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewKasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).BeginInit();
            this.pageKasaHareketleri.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSil.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Sil;
            this.btnSil.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSil.Location = new System.Drawing.Point(397, 449);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(70, 25);
            this.btnSil.TabIndex = 245;
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
            this.btnKaydet.Location = new System.Drawing.Point(589, 449);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(92, 25);
            this.btnKaydet.TabIndex = 244;
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
            this.btnYeniKayit.Location = new System.Drawing.Point(473, 449);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(110, 25);
            this.btnYeniKayit.TabIndex = 243;
            this.btnYeniKayit.Text = "maviButon1";
            this.btnYeniKayit.ToolTip = "F3 - Yeni Kayıt";
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click);
            // 
            // tabKasa
            // 
            this.tabKasa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabKasa.Location = new System.Drawing.Point(0, 0);
            this.tabKasa.Name = "tabKasa";
            this.tabKasa.SelectedTabPage = this.pageKasaTanim;
            this.tabKasa.Size = new System.Drawing.Size(690, 506);
            this.tabKasa.TabIndex = 246;
            this.tabKasa.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageKasaTanim,
            this.pageKasaHareketleri});
            this.tabKasa.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabKasa_SelectedPageChanged);
            // 
            // pageKasaTanim
            // 
            this.pageKasaTanim.Controls.Add(this.btnYenile);
            this.pageKasaTanim.Controls.Add(this.btnYazdir1);
            this.pageKasaTanim.Controls.Add(this.btnSil);
            this.pageKasaTanim.Controls.Add(this.btnKaydet);
            this.pageKasaTanim.Controls.Add(this.btnYeniKayit);
            this.pageKasaTanim.Controls.Add(this.groupControl1);
            this.pageKasaTanim.Controls.Add(this.gridControlKasa);
            this.pageKasaTanim.Controls.Add(this.ucKayitBilgi1);
            this.pageKasaTanim.Name = "pageKasaTanim";
            this.pageKasaTanim.Size = new System.Drawing.Size(684, 480);
            this.pageKasaTanim.Text = "Kasa Bilgileri";
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(626, 252);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 278;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnYazdir1
            // 
            this.btnYazdir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYazdir1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYazdir1.Image = ((System.Drawing.Image)(resources.GetObject("btnYazdir1.Image")));
            this.btnYazdir1.KaynakView = this.GridViewKasa;
            this.btnYazdir1.Location = new System.Drawing.Point(558, 253);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 277;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // GridViewKasa
            // 
            this.GridViewKasa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKasaID,
            this.colKasAd,
            this.colTahsilat,
            this.colOdeme,
            this.colBakiye,
            this.colDurum});
            this.GridViewKasa.GridControl = this.gridControlKasa;
            this.GridViewKasa.Name = "GridViewKasa";
            this.GridViewKasa.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewKasa.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewKasa.OptionsBehavior.Editable = false;
            this.GridViewKasa.OptionsBehavior.ReadOnly = true;
            this.GridViewKasa.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewKasa.OptionsView.ShowAutoFilterRow = true;
            this.GridViewKasa.OptionsView.ShowViewCaption = true;
            this.GridViewKasa.ViewCaption = "Kasalar Listesi";
            this.GridViewKasa.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewKasa_FocusedRowChanged);
            this.GridViewKasa.Click += new System.EventHandler(this.GridViewKasa_Click);
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
            // colTahsilat
            // 
            this.colTahsilat.Caption = "Toplam Borç";
            this.colTahsilat.FieldName = "Tahsilat";
            this.colTahsilat.MaxWidth = 85;
            this.colTahsilat.MinWidth = 85;
            this.colTahsilat.Name = "colTahsilat";
            this.colTahsilat.Visible = true;
            this.colTahsilat.VisibleIndex = 2;
            this.colTahsilat.Width = 85;
            // 
            // colOdeme
            // 
            this.colOdeme.Caption = "Toplam Alacak";
            this.colOdeme.FieldName = "Odeme";
            this.colOdeme.MaxWidth = 85;
            this.colOdeme.MinWidth = 85;
            this.colOdeme.Name = "colOdeme";
            this.colOdeme.Visible = true;
            this.colOdeme.VisibleIndex = 3;
            this.colOdeme.Width = 85;
            // 
            // colBakiye
            // 
            this.colBakiye.Caption = "Bakiye";
            this.colBakiye.FieldName = "Bakiye";
            this.colBakiye.MaxWidth = 80;
            this.colBakiye.MinWidth = 80;
            this.colBakiye.Name = "colBakiye";
            this.colBakiye.Visible = true;
            this.colBakiye.VisibleIndex = 4;
            this.colBakiye.Width = 80;
            // 
            // colDurum
            // 
            this.colDurum.Caption = "Durumu";
            this.colDurum.FieldName = "Durum";
            this.colDurum.MaxWidth = 50;
            this.colDurum.MinWidth = 40;
            this.colDurum.Name = "colDurum";
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 5;
            this.colDurum.Width = 40;
            // 
            // gridControlKasa
            // 
            this.gridControlKasa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlKasa.Location = new System.Drawing.Point(3, 3);
            this.gridControlKasa.MainView = this.GridViewKasa;
            this.gridControlKasa.Name = "gridControlKasa";
            this.gridControlKasa.Size = new System.Drawing.Size(678, 243);
            this.gridControlKasa.TabIndex = 247;
            this.gridControlKasa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewKasa});
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl75);
            this.groupControl1.Controls.Add(this.txtKasaAd);
            this.groupControl1.Controls.Add(this.txtKasaID);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.chkDurum);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.memoAciklama);
            this.groupControl1.Location = new System.Drawing.Point(3, 252);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(479, 185);
            this.groupControl1.TabIndex = 248;
            this.groupControl1.Text = "Kasa Detayları";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Location = new System.Drawing.Point(18, 36);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 16);
            this.labelControl4.TabIndex = 49;
            this.labelControl4.Text = "Kasa No :";
            // 
            // labelControl75
            // 
            this.labelControl75.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl75.Location = new System.Drawing.Point(15, 63);
            this.labelControl75.Name = "labelControl75";
            this.labelControl75.Size = new System.Drawing.Size(61, 16);
            this.labelControl75.TabIndex = 47;
            this.labelControl75.Text = "Kasa Adı :";
            // 
            // txtKasaAd
            // 
            this.txtKasaAd.Location = new System.Drawing.Point(86, 61);
            this.txtKasaAd.Name = "txtKasaAd";
            this.txtKasaAd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKasaAd.Properties.Appearance.Options.UseFont = true;
            this.txtKasaAd.Size = new System.Drawing.Size(385, 22);
            this.txtKasaAd.TabIndex = 48;
            // 
            // txtKasaID
            // 
            this.txtKasaID.Location = new System.Drawing.Point(86, 33);
            this.txtKasaID.Name = "txtKasaID";
            this.txtKasaID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKasaID.Properties.Appearance.Options.UseFont = true;
            this.txtKasaID.Properties.ReadOnly = true;
            this.txtKasaID.Size = new System.Drawing.Size(58, 22);
            this.txtKasaID.TabIndex = 50;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Location = new System.Drawing.Point(159, 36);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 16);
            this.labelControl2.TabIndex = 237;
            this.labelControl2.Text = "Durumu :";
            // 
            // chkDurum
            // 
            this.chkDurum.Location = new System.Drawing.Point(220, 33);
            this.chkDurum.Name = "chkDurum";
            this.chkDurum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.chkDurum.Properties.Appearance.Options.UseFont = true;
            this.chkDurum.Properties.Caption = "Pasif";
            this.chkDurum.Size = new System.Drawing.Size(58, 21);
            this.chkDurum.TabIndex = 238;
            this.chkDurum.CheckedChanged += new System.EventHandler(this.chkDurum_CheckedChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Location = new System.Drawing.Point(14, 91);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(62, 16);
            this.labelControl9.TabIndex = 240;
            this.labelControl9.Text = "Açıklama :";
            // 
            // memoAciklama
            // 
            this.memoAciklama.Location = new System.Drawing.Point(86, 89);
            this.memoAciklama.Name = "memoAciklama";
            this.memoAciklama.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.memoAciklama.Properties.Appearance.Options.UseFont = true;
            this.memoAciklama.Properties.MaxLength = 150;
            this.memoAciklama.Size = new System.Drawing.Size(385, 86);
            this.memoAciklama.TabIndex = 239;
            // 
            // ucKayitBilgi1
            // 
            this.ucKayitBilgi1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.ucKayitBilgi1.Appearance.Options.UseBackColor = true;
            this.ucKayitBilgi1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucKayitBilgi1.GostermeSekli = MaviElmasOtoSis.Sistem.ucKayitBilgi.GostermeSekilleri.Hepsi;
            this.ucKayitBilgi1.GosterSimge = true;
            this.ucKayitBilgi1.Location = new System.Drawing.Point(0, 443);
            this.ucKayitBilgi1.Name = "ucKayitBilgi1";
            this.ucKayitBilgi1.Size = new System.Drawing.Size(684, 37);
            this.ucKayitBilgi1.TabIndex = 246;
            // 
            // pageKasaHareketleri
            // 
            this.pageKasaHareketleri.Controls.Add(this.ucKasaHareket1);
            this.pageKasaHareketleri.Name = "pageKasaHareketleri";
            this.pageKasaHareketleri.PageEnabled = false;
            this.pageKasaHareketleri.Size = new System.Drawing.Size(684, 480);
            this.pageKasaHareketleri.Text = "Kasa Hareketleri";
            // 
            // ucKasaHareket1
            // 
            this.ucKasaHareket1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKasaHareket1.KasaID = 0;
            this.ucKasaHareket1.Location = new System.Drawing.Point(0, 0);
            this.ucKasaHareket1.Name = "ucKasaHareket1";
            this.ucKasaHareket1.Size = new System.Drawing.Size(684, 480);
            this.ucKasaHareket1.TabIndex = 0;
            // 
            // ucKasaDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabKasa);
            this.Name = "ucKasaDetay";
            this.Size = new System.Drawing.Size(690, 506);
            this.Load += new System.EventHandler(this.ucKasaDetay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabKasa)).EndInit();
            this.tabKasa.ResumeLayout(false);
            this.pageKasaTanim.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewKasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).EndInit();
            this.pageKasaHareketleri.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Bilesenler.MaviButon btnSil;
        private Bilesenler.MaviButon btnKaydet;
        private Bilesenler.MaviButon btnYeniKayit;
        private DevExpress.XtraTab.XtraTabControl tabKasa;
        private DevExpress.XtraTab.XtraTabPage pageKasaTanim;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit memoAciklama;
        private DevExpress.XtraEditors.CheckEdit chkDurum;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtKasaID;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtKasaAd;
        private DevExpress.XtraEditors.LabelControl labelControl75;
        private DevExpress.XtraTab.XtraTabPage pageKasaHareketleri;
        private Sistem.ucKayitBilgi ucKayitBilgi1;
        private ucKasaHareket ucKasaHareket1;
        private DevExpress.XtraGrid.GridControl gridControlKasa;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewKasa;
        private DevExpress.XtraGrid.Columns.GridColumn colKasaID;
        private DevExpress.XtraGrid.Columns.GridColumn colKasAd;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colTahsilat;
        private DevExpress.XtraGrid.Columns.GridColumn colOdeme;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.btnYazdir btnYazdir1;
        private DevExpress.XtraGrid.Columns.GridColumn colBakiye;
    }
}
