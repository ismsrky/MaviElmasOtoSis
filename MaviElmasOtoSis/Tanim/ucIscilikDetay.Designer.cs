namespace MaviElmasOtoSis.Tanim
{
    partial class ucIscilikDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucIscilikDetay));
            this.groupIscilikBilgileri = new DevExpress.XtraEditors.GroupControl();
            this.spinKacSaat = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl42 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl51 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpIscilikTip = new DevExpress.XtraEditors.LookUpEdit();
            this.chkDurum = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtIscilikID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtIscilikAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl75 = new DevExpress.XtraEditors.LabelControl();
            this.ucKayitBilgi1 = new MaviElmasOtoSis.Sistem.ucKayitBilgi();
            this.btnSil = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnKaydet = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnYeniKayit = new MaviElmasOtoSis.Bilesenler.MaviButon();
            ((System.ComponentModel.ISupportInitialize)(this.groupIscilikBilgileri)).BeginInit();
            this.groupIscilikBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinKacSaat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpIscilikTip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIscilikID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIscilikAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupIscilikBilgileri
            // 
            this.groupIscilikBilgileri.Controls.Add(this.spinKacSaat);
            this.groupIscilikBilgileri.Controls.Add(this.labelControl42);
            this.groupIscilikBilgileri.Controls.Add(this.labelControl51);
            this.groupIscilikBilgileri.Controls.Add(this.lookUpIscilikTip);
            this.groupIscilikBilgileri.Controls.Add(this.chkDurum);
            this.groupIscilikBilgileri.Controls.Add(this.labelControl6);
            this.groupIscilikBilgileri.Controls.Add(this.txtIscilikID);
            this.groupIscilikBilgileri.Controls.Add(this.labelControl4);
            this.groupIscilikBilgileri.Controls.Add(this.txtIscilikAdi);
            this.groupIscilikBilgileri.Controls.Add(this.labelControl75);
            this.groupIscilikBilgileri.Location = new System.Drawing.Point(0, 0);
            this.groupIscilikBilgileri.Name = "groupIscilikBilgileri";
            this.groupIscilikBilgileri.Size = new System.Drawing.Size(425, 167);
            this.groupIscilikBilgileri.TabIndex = 239;
            this.groupIscilikBilgileri.Text = "İşçilik Bilgileri";
            // 
            // spinKacSaat
            // 
            this.spinKacSaat.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinKacSaat.Location = new System.Drawing.Point(112, 118);
            this.spinKacSaat.Name = "spinKacSaat";
            this.spinKacSaat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinKacSaat.Properties.DisplayFormat.FormatString = "n";
            this.spinKacSaat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinKacSaat.Properties.EditFormat.FormatString = "n";
            this.spinKacSaat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinKacSaat.Properties.NullValuePrompt = "Yok";
            this.spinKacSaat.Size = new System.Drawing.Size(67, 20);
            this.spinKacSaat.TabIndex = 239;
            // 
            // labelControl42
            // 
            this.labelControl42.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl42.Location = new System.Drawing.Point(39, 120);
            this.labelControl42.Name = "labelControl42";
            this.labelControl42.Size = new System.Drawing.Size(62, 16);
            this.labelControl42.TabIndex = 240;
            this.labelControl42.Text = "Kaç Saat :";
            // 
            // labelControl51
            // 
            this.labelControl51.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl51.Location = new System.Drawing.Point(36, 92);
            this.labelControl51.Name = "labelControl51";
            this.labelControl51.Size = new System.Drawing.Size(65, 16);
            this.labelControl51.TabIndex = 237;
            this.labelControl51.Text = "İşçilik Tipi :";
            // 
            // lookUpIscilikTip
            // 
            this.lookUpIscilikTip.Location = new System.Drawing.Point(112, 90);
            this.lookUpIscilikTip.Name = "lookUpIscilikTip";
            this.lookUpIscilikTip.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpIscilikTip.Properties.Appearance.Options.UseFont = true;
            this.lookUpIscilikTip.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpIscilikTip.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "İşçilik Tipi")});
            this.lookUpIscilikTip.Properties.NullText = "";
            this.lookUpIscilikTip.Size = new System.Drawing.Size(215, 22);
            this.lookUpIscilikTip.TabIndex = 238;
            // 
            // chkDurum
            // 
            this.chkDurum.Location = new System.Drawing.Point(264, 35);
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
            this.labelControl6.Location = new System.Drawing.Point(222, 38);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(46, 16);
            this.labelControl6.TabIndex = 67;
            this.labelControl6.Text = "Durum :";
            // 
            // txtIscilikID
            // 
            this.txtIscilikID.Location = new System.Drawing.Point(112, 34);
            this.txtIscilikID.Name = "txtIscilikID";
            this.txtIscilikID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtIscilikID.Properties.Appearance.Options.UseFont = true;
            this.txtIscilikID.Properties.ReadOnly = true;
            this.txtIscilikID.Size = new System.Drawing.Size(61, 22);
            this.txtIscilikID.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Location = new System.Drawing.Point(40, 37);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 16);
            this.labelControl4.TabIndex = 44;
            this.labelControl4.Text = "İşçilik No :";
            // 
            // txtIscilikAdi
            // 
            this.txtIscilikAdi.Location = new System.Drawing.Point(112, 62);
            this.txtIscilikAdi.Name = "txtIscilikAdi";
            this.txtIscilikAdi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtIscilikAdi.Properties.Appearance.Options.UseFont = true;
            this.txtIscilikAdi.Size = new System.Drawing.Size(215, 22);
            this.txtIscilikAdi.TabIndex = 2;
            // 
            // labelControl75
            // 
            this.labelControl75.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl75.Location = new System.Drawing.Point(37, 65);
            this.labelControl75.Name = "labelControl75";
            this.labelControl75.Size = new System.Drawing.Size(64, 16);
            this.labelControl75.TabIndex = 30;
            this.labelControl75.Text = "İşçilik Adı :";
            // 
            // ucKayitBilgi1
            // 
            this.ucKayitBilgi1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.ucKayitBilgi1.Appearance.Options.UseBackColor = true;
            this.ucKayitBilgi1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucKayitBilgi1.GostermeSekli = MaviElmasOtoSis.Sistem.ucKayitBilgi.GostermeSekilleri.Hepsi;
            this.ucKayitBilgi1.GosterSimge = true;
            this.ucKayitBilgi1.Location = new System.Drawing.Point(0, 171);
            this.ucKayitBilgi1.Name = "ucKayitBilgi1";
            this.ucKayitBilgi1.Size = new System.Drawing.Size(726, 45);
            this.ucKayitBilgi1.TabIndex = 240;
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSil.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Sil;
            this.btnSil.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSil.Location = new System.Drawing.Point(436, 184);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(70, 25);
            this.btnSil.TabIndex = 243;
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
            this.btnKaydet.Location = new System.Drawing.Point(628, 184);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(92, 25);
            this.btnKaydet.TabIndex = 242;
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
            this.btnYeniKayit.Location = new System.Drawing.Point(512, 184);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(110, 25);
            this.btnYeniKayit.TabIndex = 241;
            this.btnYeniKayit.Text = "maviButon1";
            this.btnYeniKayit.ToolTip = "F3 - Yeni Kayıt";
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click);
            // 
            // ucIscilikDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnYeniKayit);
            this.Controls.Add(this.ucKayitBilgi1);
            this.Controls.Add(this.groupIscilikBilgileri);
            this.Name = "ucIscilikDetay";
            this.Size = new System.Drawing.Size(726, 216);
            ((System.ComponentModel.ISupportInitialize)(this.groupIscilikBilgileri)).EndInit();
            this.groupIscilikBilgileri.ResumeLayout(false);
            this.groupIscilikBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinKacSaat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpIscilikTip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIscilikID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIscilikAdi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupIscilikBilgileri;
        private DevExpress.XtraEditors.SpinEdit spinKacSaat;
        private DevExpress.XtraEditors.LabelControl labelControl42;
        private DevExpress.XtraEditors.LabelControl labelControl51;
        private DevExpress.XtraEditors.LookUpEdit lookUpIscilikTip;
        private DevExpress.XtraEditors.CheckEdit chkDurum;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtIscilikID;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtIscilikAdi;
        private DevExpress.XtraEditors.LabelControl labelControl75;
        private Bilesenler.MaviButon btnKaydet;
        private Bilesenler.MaviButon btnYeniKayit;
        private Sistem.ucKayitBilgi ucKayitBilgi1;
        public Bilesenler.MaviButon btnSil;
    }
}
