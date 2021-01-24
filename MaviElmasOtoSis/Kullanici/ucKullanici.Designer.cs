namespace MaviElmasOtoSis.Kullanici
{
    partial class ucKullanici
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKullanici));
            this.gridControlKullanici = new DevExpress.XtraGrid.GridControl();
            this.GridViewKullanici = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKullaniciID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKullaniciAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoyad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucKayitBilgi1 = new MaviElmasOtoSis.Sistem.ucKayitBilgi();
            this.btnSil = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnKaydet = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnYeniKayit = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.groupKullaniciBilgileri = new DevExpress.XtraEditors.GroupControl();
            this.btnYetkileri = new DevExpress.XtraEditors.SimpleButton();
            this.btnSifreSifirla = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.txtSoyadi = new DevExpress.XtraEditors.TextEdit();
            this.chkDurum = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl51 = new DevExpress.XtraEditors.LabelControl();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl75 = new DevExpress.XtraEditors.LabelControl();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKullanici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewKullanici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupKullaniciBilgileri)).BeginInit();
            this.groupKullaniciBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyadi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlKullanici
            // 
            this.gridControlKullanici.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlKullanici.Location = new System.Drawing.Point(0, 0);
            this.gridControlKullanici.MainView = this.GridViewKullanici;
            this.gridControlKullanici.Name = "gridControlKullanici";
            this.gridControlKullanici.Size = new System.Drawing.Size(840, 228);
            this.gridControlKullanici.TabIndex = 231;
            this.gridControlKullanici.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewKullanici});
            // 
            // GridViewKullanici
            // 
            this.GridViewKullanici.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKullaniciID,
            this.colKullaniciAd,
            this.colAd,
            this.colSoyad,
            this.colDurum});
            this.GridViewKullanici.GridControl = this.gridControlKullanici;
            this.GridViewKullanici.Name = "GridViewKullanici";
            this.GridViewKullanici.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewKullanici.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewKullanici.OptionsBehavior.Editable = false;
            this.GridViewKullanici.OptionsBehavior.ReadOnly = true;
            this.GridViewKullanici.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewKullanici.OptionsView.ShowAutoFilterRow = true;
            this.GridViewKullanici.OptionsView.ShowGroupPanel = false;
            this.GridViewKullanici.OptionsView.ShowViewCaption = true;
            this.GridViewKullanici.ViewCaption = "Sistem Kullanıcılar Listesi";
            this.GridViewKullanici.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewKullanici_FocusedRowChanged);
            this.GridViewKullanici.Click += new System.EventHandler(this.GridViewKullanici_Click);
            // 
            // colKullaniciID
            // 
            this.colKullaniciID.AppearanceCell.Options.UseTextOptions = true;
            this.colKullaniciID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKullaniciID.Caption = "Kullanıcı No";
            this.colKullaniciID.FieldName = "KullaniciID";
            this.colKullaniciID.MaxWidth = 50;
            this.colKullaniciID.Name = "colKullaniciID";
            this.colKullaniciID.Visible = true;
            this.colKullaniciID.VisibleIndex = 0;
            this.colKullaniciID.Width = 50;
            // 
            // colKullaniciAd
            // 
            this.colKullaniciAd.Caption = "Kullanıcı Adı";
            this.colKullaniciAd.FieldName = "KullaniciAd";
            this.colKullaniciAd.Name = "colKullaniciAd";
            this.colKullaniciAd.Visible = true;
            this.colKullaniciAd.VisibleIndex = 1;
            this.colKullaniciAd.Width = 124;
            // 
            // colAd
            // 
            this.colAd.Caption = "Adı";
            this.colAd.FieldName = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.Visible = true;
            this.colAd.VisibleIndex = 2;
            this.colAd.Width = 124;
            // 
            // colSoyad
            // 
            this.colSoyad.Caption = "Soyadı";
            this.colSoyad.FieldName = "Soyad";
            this.colSoyad.Name = "colSoyad";
            this.colSoyad.Visible = true;
            this.colSoyad.VisibleIndex = 3;
            // 
            // colDurum
            // 
            this.colDurum.Caption = "Durumu";
            this.colDurum.FieldName = "Durum";
            this.colDurum.Name = "colDurum";
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 4;
            // 
            // ucKayitBilgi1
            // 
            this.ucKayitBilgi1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.ucKayitBilgi1.Appearance.Options.UseBackColor = true;
            this.ucKayitBilgi1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucKayitBilgi1.GostermeSekli = MaviElmasOtoSis.Sistem.ucKayitBilgi.GostermeSekilleri.Hepsi;
            this.ucKayitBilgi1.GosterSimge = true;
            this.ucKayitBilgi1.Location = new System.Drawing.Point(0, 426);
            this.ucKayitBilgi1.Name = "ucKayitBilgi1";
            this.ucKayitBilgi1.Size = new System.Drawing.Size(839, 45);
            this.ucKayitBilgi1.TabIndex = 232;
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSil.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Sil;
            this.btnSil.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSil.Location = new System.Drawing.Point(552, 435);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(70, 25);
            this.btnSil.TabIndex = 235;
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
            this.btnKaydet.Location = new System.Drawing.Point(744, 435);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(92, 25);
            this.btnKaydet.TabIndex = 4;
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
            this.btnYeniKayit.Location = new System.Drawing.Point(628, 435);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(110, 25);
            this.btnYeniKayit.TabIndex = 5;
            this.btnYeniKayit.Text = "maviButon1";
            this.btnYeniKayit.ToolTip = "F3 - Yeni Kayıt";
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click);
            // 
            // groupKullaniciBilgileri
            // 
            this.groupKullaniciBilgileri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupKullaniciBilgileri.Controls.Add(this.btnYetkileri);
            this.groupKullaniciBilgileri.Controls.Add(this.btnSifreSifirla);
            this.groupKullaniciBilgileri.Controls.Add(this.txtSoyadi);
            this.groupKullaniciBilgileri.Controls.Add(this.chkDurum);
            this.groupKullaniciBilgileri.Controls.Add(this.labelControl6);
            this.groupKullaniciBilgileri.Controls.Add(this.labelControl51);
            this.groupKullaniciBilgileri.Controls.Add(this.txtKullaniciAdi);
            this.groupKullaniciBilgileri.Controls.Add(this.labelControl4);
            this.groupKullaniciBilgileri.Controls.Add(this.txtAdi);
            this.groupKullaniciBilgileri.Controls.Add(this.labelControl75);
            this.groupKullaniciBilgileri.Location = new System.Drawing.Point(3, 234);
            this.groupKullaniciBilgileri.Name = "groupKullaniciBilgileri";
            this.groupKullaniciBilgileri.Size = new System.Drawing.Size(490, 186);
            this.groupKullaniciBilgileri.TabIndex = 236;
            this.groupKullaniciBilgileri.Text = "Kullanıcı Bilgileri";
            // 
            // btnYetkileri
            // 
            this.btnYetkileri.Image = global::MaviElmasOtoSis.ResOtoSis.yeni;
            this.btnYetkileri.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYetkileri.Location = new System.Drawing.Point(355, 126);
            this.btnYetkileri.Name = "btnYetkileri";
            this.btnYetkileri.Size = new System.Drawing.Size(130, 24);
            this.btnYetkileri.TabIndex = 257;
            this.btnYetkileri.Text = "Yetkileri";
            this.btnYetkileri.Click += new System.EventHandler(this.btnYetkileri_Click);
            // 
            // btnSifreSifirla
            // 
            this.btnSifreSifirla.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.SifreSifirla;
            this.btnSifreSifirla.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSifreSifirla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSifreSifirla.Image = ((System.Drawing.Image)(resources.GetObject("btnSifreSifirla.Image")));
            this.btnSifreSifirla.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSifreSifirla.Location = new System.Drawing.Point(355, 156);
            this.btnSifreSifirla.Name = "btnSifreSifirla";
            this.btnSifreSifirla.Size = new System.Drawing.Size(130, 25);
            this.btnSifreSifirla.TabIndex = 238;
            this.btnSifreSifirla.Text = "maviButon1";
            this.btnSifreSifirla.ToolTip = "F2 - Kaydet";
            this.btnSifreSifirla.Click += new System.EventHandler(this.btnSifreSifirla_Click);
            // 
            // txtSoyadi
            // 
            this.txtSoyadi.Location = new System.Drawing.Point(110, 90);
            this.txtSoyadi.Name = "txtSoyadi";
            this.txtSoyadi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSoyadi.Properties.Appearance.Options.UseFont = true;
            this.txtSoyadi.Size = new System.Drawing.Size(215, 22);
            this.txtSoyadi.TabIndex = 3;
            // 
            // chkDurum
            // 
            this.chkDurum.Location = new System.Drawing.Point(110, 117);
            this.chkDurum.Name = "chkDurum";
            this.chkDurum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.chkDurum.Properties.Appearance.Options.UseFont = true;
            this.chkDurum.Properties.Caption = "Pasif";
            this.chkDurum.Size = new System.Drawing.Size(63, 21);
            this.chkDurum.TabIndex = 236;
            this.chkDurum.CheckedChanged += new System.EventHandler(this.chkDurum_CheckedChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Location = new System.Drawing.Point(51, 120);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(53, 16);
            this.labelControl6.TabIndex = 67;
            this.labelControl6.Text = "Durumu :";
            // 
            // labelControl51
            // 
            this.labelControl51.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl51.Location = new System.Drawing.Point(56, 92);
            this.labelControl51.Name = "labelControl51";
            this.labelControl51.Size = new System.Drawing.Size(48, 16);
            this.labelControl51.TabIndex = 59;
            this.labelControl51.Text = "Soyadı :";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(112, 34);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(215, 22);
            this.txtKullaniciAdi.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Location = new System.Drawing.Point(24, 36);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(80, 16);
            this.labelControl4.TabIndex = 44;
            this.labelControl4.Text = "Kullanıcı Adı :";
            // 
            // txtAdi
            // 
            this.txtAdi.Location = new System.Drawing.Point(112, 62);
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdi.Properties.Appearance.Options.UseFont = true;
            this.txtAdi.Size = new System.Drawing.Size(215, 22);
            this.txtAdi.TabIndex = 2;
            // 
            // labelControl75
            // 
            this.labelControl75.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl75.Location = new System.Drawing.Point(77, 64);
            this.labelControl75.Name = "labelControl75";
            this.labelControl75.Size = new System.Drawing.Size(27, 16);
            this.labelControl75.TabIndex = 30;
            this.labelControl75.Text = "Adı :";
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(781, 234);
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
            this.btnYazdir1.KaynakView = this.GridViewKullanici;
            this.btnYazdir1.Location = new System.Drawing.Point(713, 235);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 275;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // ucKullanici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnYazdir1);
            this.Controls.Add(this.groupKullaniciBilgileri);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnYeniKayit);
            this.Controls.Add(this.ucKayitBilgi1);
            this.Controls.Add(this.gridControlKullanici);
            this.Name = "ucKullanici";
            this.Size = new System.Drawing.Size(839, 471);
            this.Load += new System.EventHandler(this.ucKullanici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKullanici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewKullanici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupKullaniciBilgileri)).EndInit();
            this.groupKullaniciBilgileri.ResumeLayout(false);
            this.groupKullaniciBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyadi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlKullanici;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewKullanici;
        private DevExpress.XtraGrid.Columns.GridColumn colKullaniciID;
        private DevExpress.XtraGrid.Columns.GridColumn colKullaniciAd;
        private DevExpress.XtraGrid.Columns.GridColumn colAd;
        private DevExpress.XtraGrid.Columns.GridColumn colSoyad;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
        private Sistem.ucKayitBilgi ucKayitBilgi1;
        private Bilesenler.MaviButon btnSil;
        private Bilesenler.MaviButon btnKaydet;
        private Bilesenler.MaviButon btnYeniKayit;
        private DevExpress.XtraEditors.GroupControl groupKullaniciBilgileri;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl51;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtAdi;
        private DevExpress.XtraEditors.LabelControl labelControl75;
        private DevExpress.XtraEditors.CheckEdit chkDurum;
        private DevExpress.XtraEditors.TextEdit txtSoyadi;
        private Bilesenler.MaviButon btnSifreSifirla;
        private DevExpress.XtraEditors.SimpleButton btnYetkileri;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private Bilesenler.btnYazdir btnYazdir1;
    }
}
