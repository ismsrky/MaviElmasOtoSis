namespace MaviElmasOtoSis.Sistem
{
    partial class frmAyarlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAyarlar));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.pageDb = new DevExpress.XtraTab.XtraTabPage();
            this.btnGozat = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBaglantiDene = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtServerAdresi = new DevExpress.XtraEditors.TextEdit();
            this.txtDosyaSunucusu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtVeritabaniAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtServerKullaniciSifre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtServerKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.pageYazici = new DevExpress.XtraTab.XtraTabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmbYazicilarA4 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbYazicilarBarkod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.pageGenel = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lookUpDepolar = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpSirketler = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btnKaydet = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnIptal = new MaviElmasOtoSis.Bilesenler.MaviButon();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.pageDb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerAdresi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaSunucusu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVeritabaniAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerKullaniciSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerKullaniciAdi.Properties)).BeginInit();
            this.pageYazici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYazicilarA4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYazicilarBarkod.Properties)).BeginInit();
            this.pageGenel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepolar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpSirketler.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 12);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.pageDb;
            this.xtraTabControl1.Size = new System.Drawing.Size(608, 315);
            this.xtraTabControl1.TabIndex = 30;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageDb,
            this.pageYazici,
            this.pageGenel});
            // 
            // pageDb
            // 
            this.pageDb.Controls.Add(this.btnGozat);
            this.pageDb.Controls.Add(this.pictureBox1);
            this.pageDb.Controls.Add(this.btnBaglantiDene);
            this.pageDb.Controls.Add(this.labelControl1);
            this.pageDb.Controls.Add(this.txtServerAdresi);
            this.pageDb.Controls.Add(this.txtDosyaSunucusu);
            this.pageDb.Controls.Add(this.labelControl2);
            this.pageDb.Controls.Add(this.labelControl6);
            this.pageDb.Controls.Add(this.txtVeritabaniAdi);
            this.pageDb.Controls.Add(this.txtServerKullaniciSifre);
            this.pageDb.Controls.Add(this.labelControl5);
            this.pageDb.Controls.Add(this.labelControl4);
            this.pageDb.Controls.Add(this.txtServerKullaniciAdi);
            this.pageDb.Name = "pageDb";
            this.pageDb.PageVisible = false;
            this.pageDb.Size = new System.Drawing.Size(602, 287);
            this.pageDb.Text = "Veritabanı Ayarları";
            // 
            // btnGozat
            // 
            this.btnGozat.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnGozat.Appearance.Options.UseFont = true;
            this.btnGozat.Image = global::MaviElmasOtoSis.ResOtoSis.gozat;
            this.btnGozat.Location = new System.Drawing.Point(507, 239);
            this.btnGozat.Name = "btnGozat";
            this.btnGozat.Size = new System.Drawing.Size(72, 22);
            this.btnGozat.TabIndex = 29;
            this.btnGozat.Text = "Gözat";
            this.btnGozat.Click += new System.EventHandler(this.btnGozat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MaviElmasOtoSis.ResOtoSis.db_process;
            this.pictureBox1.Location = new System.Drawing.Point(19, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // btnBaglantiDene
            // 
            this.btnBaglantiDene.Appearance.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnBaglantiDene.Appearance.Options.UseFont = true;
            this.btnBaglantiDene.Location = new System.Drawing.Point(471, 144);
            this.btnBaglantiDene.Name = "btnBaglantiDene";
            this.btnBaglantiDene.Size = new System.Drawing.Size(108, 22);
            this.btnBaglantiDene.TabIndex = 28;
            this.btnBaglantiDene.Text = "Bağlantıyı Dene";
            this.btnBaglantiDene.Click += new System.EventHandler(this.btnBaglantiDene_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.labelControl1.Location = new System.Drawing.Point(211, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 16);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Server Adresi :";
            // 
            // txtServerAdresi
            // 
            this.txtServerAdresi.Location = new System.Drawing.Point(304, 28);
            this.txtServerAdresi.Name = "txtServerAdresi";
            this.txtServerAdresi.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtServerAdresi.Properties.Appearance.Options.UseFont = true;
            this.txtServerAdresi.Size = new System.Drawing.Size(275, 22);
            this.txtServerAdresi.TabIndex = 13;
            // 
            // txtDosyaSunucusu
            // 
            this.txtDosyaSunucusu.Location = new System.Drawing.Point(304, 210);
            this.txtDosyaSunucusu.Name = "txtDosyaSunucusu";
            this.txtDosyaSunucusu.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDosyaSunucusu.Properties.Appearance.Options.UseFont = true;
            this.txtDosyaSunucusu.Size = new System.Drawing.Size(275, 22);
            this.txtDosyaSunucusu.TabIndex = 25;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.labelControl2.Location = new System.Drawing.Point(207, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(89, 16);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Veritabanı Adı :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.labelControl6.Location = new System.Drawing.Point(189, 212);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(107, 16);
            this.labelControl6.TabIndex = 24;
            this.labelControl6.Text = "Dosya Sunucusu :";
            // 
            // txtVeritabaniAdi
            // 
            this.txtVeritabaniAdi.Location = new System.Drawing.Point(304, 57);
            this.txtVeritabaniAdi.Name = "txtVeritabaniAdi";
            this.txtVeritabaniAdi.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtVeritabaniAdi.Properties.Appearance.Options.UseFont = true;
            this.txtVeritabaniAdi.Size = new System.Drawing.Size(275, 22);
            this.txtVeritabaniAdi.TabIndex = 15;
            // 
            // txtServerKullaniciSifre
            // 
            this.txtServerKullaniciSifre.Location = new System.Drawing.Point(304, 115);
            this.txtServerKullaniciSifre.Name = "txtServerKullaniciSifre";
            this.txtServerKullaniciSifre.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtServerKullaniciSifre.Properties.Appearance.Options.UseFont = true;
            this.txtServerKullaniciSifre.Size = new System.Drawing.Size(275, 22);
            this.txtServerKullaniciSifre.TabIndex = 21;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.labelControl5.Location = new System.Drawing.Point(176, 88);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(120, 16);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "Server Kullanıcı Adı :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.labelControl4.Location = new System.Drawing.Point(169, 117);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(127, 16);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "Server Kullanıcı Şifre :";
            // 
            // txtServerKullaniciAdi
            // 
            this.txtServerKullaniciAdi.Location = new System.Drawing.Point(304, 86);
            this.txtServerKullaniciAdi.Name = "txtServerKullaniciAdi";
            this.txtServerKullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtServerKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtServerKullaniciAdi.Size = new System.Drawing.Size(275, 22);
            this.txtServerKullaniciAdi.TabIndex = 19;
            // 
            // pageYazici
            // 
            this.pageYazici.Controls.Add(this.pictureBox2);
            this.pageYazici.Controls.Add(this.cmbYazicilarA4);
            this.pageYazici.Controls.Add(this.cmbYazicilarBarkod);
            this.pageYazici.Controls.Add(this.labelControl7);
            this.pageYazici.Controls.Add(this.labelControl8);
            this.pageYazici.Name = "pageYazici";
            this.pageYazici.PageVisible = false;
            this.pageYazici.Size = new System.Drawing.Size(602, 287);
            this.pageYazici.Text = "Yazıcı Ayarları";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MaviElmasOtoSis.ResOtoSis.printerSettings;
            this.pictureBox2.Location = new System.Drawing.Point(19, 63);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // cmbYazicilarA4
            // 
            this.cmbYazicilarA4.Location = new System.Drawing.Point(167, 147);
            this.cmbYazicilarA4.Name = "cmbYazicilarA4";
            this.cmbYazicilarA4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbYazicilarA4.Properties.Appearance.Options.UseFont = true;
            this.cmbYazicilarA4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbYazicilarA4.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbYazicilarA4.Size = new System.Drawing.Size(409, 22);
            this.cmbYazicilarA4.TabIndex = 41;
            // 
            // cmbYazicilarBarkod
            // 
            this.cmbYazicilarBarkod.Location = new System.Drawing.Point(167, 97);
            this.cmbYazicilarBarkod.Name = "cmbYazicilarBarkod";
            this.cmbYazicilarBarkod.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbYazicilarBarkod.Properties.Appearance.Options.UseFont = true;
            this.cmbYazicilarBarkod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbYazicilarBarkod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbYazicilarBarkod.Size = new System.Drawing.Size(409, 22);
            this.cmbYazicilarBarkod.TabIndex = 40;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.labelControl7.Location = new System.Drawing.Point(167, 75);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(99, 16);
            this.labelControl7.TabIndex = 15;
            this.labelControl7.Text = "Barkod Yazıcısı :";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.labelControl8.Location = new System.Drawing.Point(167, 125);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(74, 16);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "A4 Yazıcısı :";
            // 
            // pageGenel
            // 
            this.pageGenel.Controls.Add(this.groupControl3);
            this.pageGenel.Name = "pageGenel";
            this.pageGenel.PageVisible = false;
            this.pageGenel.Size = new System.Drawing.Size(602, 287);
            this.pageGenel.Text = "Genel";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.lookUpDepolar);
            this.groupControl3.Controls.Add(this.lookUpSirketler);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.labelControl12);
            this.groupControl3.Location = new System.Drawing.Point(9, 8);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(294, 94);
            this.groupControl3.TabIndex = 64;
            this.groupControl3.Text = "Varsayılanlar";
            // 
            // lookUpDepolar
            // 
            this.lookUpDepolar.Location = new System.Drawing.Point(120, 58);
            this.lookUpDepolar.Name = "lookUpDepolar";
            this.lookUpDepolar.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpDepolar.Properties.Appearance.Options.UseFont = true;
            this.lookUpDepolar.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpDepolar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDepolar.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepoID", "Depo No", 30, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepoAd", 70, "Depo Adı"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kilitli", 30, "Kilitli")});
            this.lookUpDepolar.Properties.NullText = "";
            this.lookUpDepolar.Size = new System.Drawing.Size(166, 22);
            this.lookUpDepolar.TabIndex = 74;
            // 
            // lookUpSirketler
            // 
            this.lookUpSirketler.Location = new System.Drawing.Point(120, 29);
            this.lookUpSirketler.Name = "lookUpSirketler";
            this.lookUpSirketler.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpSirketler.Properties.Appearance.Options.UseFont = true;
            this.lookUpSirketler.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpSirketler.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpSirketler.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SirketID", "Şirket No", 30, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KisaAd", 70, "Kısa Adı"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Unvan", 140, "Ünvanı")});
            this.lookUpSirketler.Properties.NullText = "";
            this.lookUpSirketler.Size = new System.Drawing.Size(166, 22);
            this.lookUpSirketler.TabIndex = 73;
            this.lookUpSirketler.EditValueChanged += new System.EventHandler(this.lookUpSirketler_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.labelControl3.Location = new System.Drawing.Point(11, 61);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(103, 16);
            this.labelControl3.TabIndex = 59;
            this.labelControl3.Text = "Varsayılan Depo :";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.labelControl12.Location = new System.Drawing.Point(7, 31);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(107, 16);
            this.labelControl12.TabIndex = 14;
            this.labelControl12.Text = "Varsayılan Şirket :";
            // 
            // btnKaydet
            // 
            this.btnKaydet.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Kaydet;
            this.btnKaydet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnKaydet.Location = new System.Drawing.Point(518, 333);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(92, 25);
            this.btnKaydet.TabIndex = 31;
            this.btnKaydet.Text = "maviButon1";
            this.btnKaydet.ToolTip = "F2 - Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Iptal;
            this.btnIptal.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Image = ((System.Drawing.Image)(resources.GetObject("btnIptal.Image")));
            this.btnIptal.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnIptal.Location = new System.Drawing.Point(432, 333);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(80, 25);
            this.btnIptal.TabIndex = 32;
            this.btnIptal.Text = "maviButon2";
            this.btnIptal.ToolTip = "F2 - Kaydet";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // frmAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(622, 365);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.xtraTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAyarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAyarlar";
            this.Load += new System.EventHandler(this.frmAyarlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.pageDb.ResumeLayout(false);
            this.pageDb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerAdresi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDosyaSunucusu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVeritabaniAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerKullaniciSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerKullaniciAdi.Properties)).EndInit();
            this.pageYazici.ResumeLayout(false);
            this.pageYazici.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYazicilarA4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYazicilarBarkod.Properties)).EndInit();
            this.pageGenel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepolar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpSirketler.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage pageDb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton btnBaglantiDene;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtServerAdresi;
        private DevExpress.XtraEditors.TextEdit txtDosyaSunucusu;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtVeritabaniAdi;
        private DevExpress.XtraEditors.TextEdit txtServerKullaniciSifre;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtServerKullaniciAdi;
        private DevExpress.XtraTab.XtraTabPage pageYazici;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbYazicilarA4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbYazicilarBarkod;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraTab.XtraTabPage pageGenel;
        private Bilesenler.MaviButon btnKaydet;
        private Bilesenler.MaviButon btnIptal;
        private DevExpress.XtraEditors.SimpleButton btnGozat;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LookUpEdit lookUpDepolar;
        private DevExpress.XtraEditors.LookUpEdit lookUpSirketler;
    }
}