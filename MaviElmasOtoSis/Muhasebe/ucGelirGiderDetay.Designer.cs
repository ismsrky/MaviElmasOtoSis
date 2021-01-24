namespace MaviElmasOtoSis.Muhasebe
{
    partial class ucGelirGiderDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGelirGiderDetay));
            this.ucKayitBilgi1 = new MaviElmasOtoSis.Sistem.ucKayitBilgi();
            this.btnSil = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnKaydet = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnYeniKayit = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.tabGelirGider = new DevExpress.XtraTab.XtraTabControl();
            this.pageGelirGider = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioGelirGiderID = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.memoAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.chkDurum = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpGelirGiderGrup = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtGelirGiderID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtAd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl75 = new DevExpress.XtraEditors.LabelControl();
            this.pageGelirGiderHareket = new DevExpress.XtraTab.XtraTabPage();
            this.ucGelirGiderHareket1 = new MaviElmasOtoSis.Muhasebe.ucGelirGiderHareket();
            ((System.ComponentModel.ISupportInitialize)(this.tabGelirGider)).BeginInit();
            this.tabGelirGider.SuspendLayout();
            this.pageGelirGider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGelirGiderID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGelirGiderGrup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGelirGiderID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).BeginInit();
            this.pageGelirGiderHareket.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucKayitBilgi1
            // 
            this.ucKayitBilgi1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.ucKayitBilgi1.Appearance.Options.UseBackColor = true;
            this.ucKayitBilgi1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucKayitBilgi1.GostermeSekli = MaviElmasOtoSis.Sistem.ucKayitBilgi.GostermeSekilleri.Hepsi;
            this.ucKayitBilgi1.GosterSimge = true;
            this.ucKayitBilgi1.Location = new System.Drawing.Point(0, 270);
            this.ucKayitBilgi1.Name = "ucKayitBilgi1";
            this.ucKayitBilgi1.Size = new System.Drawing.Size(879, 37);
            this.ucKayitBilgi1.TabIndex = 0;
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSil.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Sil;
            this.btnSil.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSil.Location = new System.Drawing.Point(592, 274);
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
            this.btnKaydet.Location = new System.Drawing.Point(784, 274);
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
            this.btnYeniKayit.Location = new System.Drawing.Point(668, 274);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(110, 25);
            this.btnYeniKayit.TabIndex = 243;
            this.btnYeniKayit.Text = "maviButon1";
            this.btnYeniKayit.ToolTip = "F3 - Yeni Kayıt";
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click);
            // 
            // tabGelirGider
            // 
            this.tabGelirGider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabGelirGider.Location = new System.Drawing.Point(0, 0);
            this.tabGelirGider.Name = "tabGelirGider";
            this.tabGelirGider.SelectedTabPage = this.pageGelirGider;
            this.tabGelirGider.Size = new System.Drawing.Size(876, 260);
            this.tabGelirGider.TabIndex = 246;
            this.tabGelirGider.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageGelirGider,
            this.pageGelirGiderHareket});
            this.tabGelirGider.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabGelirGider_SelectedPageChanged);
            // 
            // pageGelirGider
            // 
            this.pageGelirGider.Controls.Add(this.labelControl1);
            this.pageGelirGider.Controls.Add(this.radioGelirGiderID);
            this.pageGelirGider.Controls.Add(this.labelControl9);
            this.pageGelirGider.Controls.Add(this.memoAciklama);
            this.pageGelirGider.Controls.Add(this.chkDurum);
            this.pageGelirGider.Controls.Add(this.labelControl2);
            this.pageGelirGider.Controls.Add(this.lookUpGelirGiderGrup);
            this.pageGelirGider.Controls.Add(this.labelControl6);
            this.pageGelirGider.Controls.Add(this.txtGelirGiderID);
            this.pageGelirGider.Controls.Add(this.labelControl4);
            this.pageGelirGider.Controls.Add(this.txtAd);
            this.pageGelirGider.Controls.Add(this.labelControl75);
            this.pageGelirGider.Name = "pageGelirGider";
            this.pageGelirGider.Size = new System.Drawing.Size(870, 234);
            this.pageGelirGider.Text = "Gelir/Gider Bilgileri";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Location = new System.Drawing.Point(20, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 16);
            this.labelControl1.TabIndex = 242;
            this.labelControl1.Text = "Gelir / Gider ? :";
            // 
            // radioGelirGiderID
            // 
            this.radioGelirGiderID.Location = new System.Drawing.Point(117, 55);
            this.radioGelirGiderID.Name = "radioGelirGiderID";
            this.radioGelirGiderID.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Gelir"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Gider")});
            this.radioGelirGiderID.Size = new System.Drawing.Size(58, 46);
            this.radioGelirGiderID.TabIndex = 241;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Location = new System.Drawing.Point(43, 109);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(62, 16);
            this.labelControl9.TabIndex = 240;
            this.labelControl9.Text = "Açıklama :";
            // 
            // memoAciklama
            // 
            this.memoAciklama.Location = new System.Drawing.Point(115, 107);
            this.memoAciklama.Name = "memoAciklama";
            this.memoAciklama.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.memoAciklama.Properties.Appearance.Options.UseFont = true;
            this.memoAciklama.Properties.MaxLength = 150;
            this.memoAciklama.Size = new System.Drawing.Size(385, 86);
            this.memoAciklama.TabIndex = 239;
            // 
            // chkDurum
            // 
            this.chkDurum.Location = new System.Drawing.Point(296, 80);
            this.chkDurum.Name = "chkDurum";
            this.chkDurum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.chkDurum.Properties.Appearance.Options.UseFont = true;
            this.chkDurum.Properties.Caption = "Pasif";
            this.chkDurum.Size = new System.Drawing.Size(58, 21);
            this.chkDurum.TabIndex = 238;
            this.chkDurum.CheckedChanged += new System.EventHandler(this.chkDurum_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Location = new System.Drawing.Point(235, 83);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 16);
            this.labelControl2.TabIndex = 237;
            this.labelControl2.Text = "Durumu :";
            // 
            // lookUpGelirGiderGrup
            // 
            this.lookUpGelirGiderGrup.Location = new System.Drawing.Point(298, 48);
            this.lookUpGelirGiderGrup.Name = "lookUpGelirGiderGrup";
            this.lookUpGelirGiderGrup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpGelirGiderGrup.Properties.Appearance.Options.UseFont = true;
            this.lookUpGelirGiderGrup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpGelirGiderGrup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Gelir / Gider Grubu")});
            this.lookUpGelirGiderGrup.Properties.NullText = "";
            this.lookUpGelirGiderGrup.Size = new System.Drawing.Size(202, 22);
            this.lookUpGelirGiderGrup.TabIndex = 70;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Location = new System.Drawing.Point(181, 50);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(109, 16);
            this.labelControl6.TabIndex = 69;
            this.labelControl6.Text = "Gelir/Gider Grubu :";
            // 
            // txtGelirGiderID
            // 
            this.txtGelirGiderID.Location = new System.Drawing.Point(117, 19);
            this.txtGelirGiderID.Name = "txtGelirGiderID";
            this.txtGelirGiderID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGelirGiderID.Properties.Appearance.Options.UseFont = true;
            this.txtGelirGiderID.Properties.ReadOnly = true;
            this.txtGelirGiderID.Size = new System.Drawing.Size(58, 22);
            this.txtGelirGiderID.TabIndex = 50;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Location = new System.Drawing.Point(19, 22);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(90, 16);
            this.labelControl4.TabIndex = 49;
            this.labelControl4.Text = "Gelir/Gider No :";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(298, 20);
            this.txtAd.Name = "txtAd";
            this.txtAd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAd.Properties.Appearance.Options.UseFont = true;
            this.txtAd.Size = new System.Drawing.Size(204, 22);
            this.txtAd.TabIndex = 48;
            // 
            // labelControl75
            // 
            this.labelControl75.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl75.Location = new System.Drawing.Point(197, 22);
            this.labelControl75.Name = "labelControl75";
            this.labelControl75.Size = new System.Drawing.Size(93, 16);
            this.labelControl75.TabIndex = 47;
            this.labelControl75.Text = "Gelir/Gider Adı :";
            // 
            // pageGelirGiderHareket
            // 
            this.pageGelirGiderHareket.Controls.Add(this.ucGelirGiderHareket1);
            this.pageGelirGiderHareket.Name = "pageGelirGiderHareket";
            this.pageGelirGiderHareket.Size = new System.Drawing.Size(870, 234);
            this.pageGelirGiderHareket.Text = "Gelir/Gider Hareketleri";
            // 
            // ucGelirGiderHareket1
            // 
            this.ucGelirGiderHareket1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGelirGiderHareket1.GelirGiderID = 0;
            this.ucGelirGiderHareket1.Location = new System.Drawing.Point(0, 0);
            this.ucGelirGiderHareket1.Name = "ucGelirGiderHareket1";
            this.ucGelirGiderHareket1.Size = new System.Drawing.Size(870, 234);
            this.ucGelirGiderHareket1.TabIndex = 0;
            // 
            // ucGelirGiderDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabGelirGider);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnYeniKayit);
            this.Controls.Add(this.ucKayitBilgi1);
            this.Name = "ucGelirGiderDetay";
            this.Size = new System.Drawing.Size(879, 307);
            this.Load += new System.EventHandler(this.ucGelirGiderDetay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabGelirGider)).EndInit();
            this.tabGelirGider.ResumeLayout(false);
            this.pageGelirGider.ResumeLayout(false);
            this.pageGelirGider.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGelirGiderID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGelirGiderGrup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGelirGiderID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).EndInit();
            this.pageGelirGiderHareket.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sistem.ucKayitBilgi ucKayitBilgi1;
        public Bilesenler.MaviButon btnSil;
        private Bilesenler.MaviButon btnKaydet;
        private Bilesenler.MaviButon btnYeniKayit;
        private DevExpress.XtraTab.XtraTabControl tabGelirGider;
        private DevExpress.XtraTab.XtraTabPage pageGelirGider;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit memoAciklama;
        private DevExpress.XtraEditors.CheckEdit chkDurum;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUpGelirGiderGrup;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtGelirGiderID;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtAd;
        private DevExpress.XtraEditors.LabelControl labelControl75;
        private DevExpress.XtraTab.XtraTabPage pageGelirGiderHareket;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.RadioGroup radioGelirGiderID;
        private ucGelirGiderHareket ucGelirGiderHareket1;
    }
}
