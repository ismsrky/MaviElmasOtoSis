namespace MaviElmasOtoSis.Personel
{
    partial class ucPersonelDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPersonelDemo));
            this.grupGelirGiderBilgileri = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpCalistigiBirim = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpMedeniHal = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpCinsiyet = new DevExpress.XtraEditors.LookUpEdit();
            this.txtTcKimlikNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtAdSoyad = new DevExpress.XtraEditors.TextEdit();
            this.lblGelirAdi = new DevExpress.XtraEditors.LabelControl();
            this.txtPersonelID = new DevExpress.XtraEditors.TextEdit();
            this.lblGelirNo = new DevExpress.XtraEditors.LabelControl();
            this.btnPersonelDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnPersonelYeni = new DevExpress.XtraEditors.SimpleButton();
            this.btnPersonelSec = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grupGelirGiderBilgileri)).BeginInit();
            this.grupGelirGiderBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCalistigiBirim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpMedeniHal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCinsiyet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTcKimlikNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdSoyad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grupGelirGiderBilgileri
            // 
            this.grupGelirGiderBilgileri.Controls.Add(this.labelControl2);
            this.grupGelirGiderBilgileri.Controls.Add(this.lookUpCalistigiBirim);
            this.grupGelirGiderBilgileri.Controls.Add(this.labelControl1);
            this.grupGelirGiderBilgileri.Controls.Add(this.lookUpMedeniHal);
            this.grupGelirGiderBilgileri.Controls.Add(this.labelControl13);
            this.grupGelirGiderBilgileri.Controls.Add(this.lookUpCinsiyet);
            this.grupGelirGiderBilgileri.Controls.Add(this.txtTcKimlikNo);
            this.grupGelirGiderBilgileri.Controls.Add(this.labelControl5);
            this.grupGelirGiderBilgileri.Controls.Add(this.txtAdSoyad);
            this.grupGelirGiderBilgileri.Controls.Add(this.lblGelirAdi);
            this.grupGelirGiderBilgileri.Controls.Add(this.txtPersonelID);
            this.grupGelirGiderBilgileri.Controls.Add(this.lblGelirNo);
            this.grupGelirGiderBilgileri.Controls.Add(this.btnPersonelDuzenle);
            this.grupGelirGiderBilgileri.Controls.Add(this.btnPersonelYeni);
            this.grupGelirGiderBilgileri.Controls.Add(this.btnPersonelSec);
            this.grupGelirGiderBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupGelirGiderBilgileri.Location = new System.Drawing.Point(0, 0);
            this.grupGelirGiderBilgileri.Name = "grupGelirGiderBilgileri";
            this.grupGelirGiderBilgileri.Size = new System.Drawing.Size(482, 110);
            this.grupGelirGiderBilgileri.TabIndex = 262;
            this.grupGelirGiderBilgileri.Text = "Personel Bilgileri";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Location = new System.Drawing.Point(194, 86);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 16);
            this.labelControl2.TabIndex = 291;
            this.labelControl2.Text = "Cinsiyet :";
            // 
            // lookUpCalistigiBirim
            // 
            this.lookUpCalistigiBirim.Location = new System.Drawing.Point(255, 55);
            this.lookUpCalistigiBirim.Name = "lookUpCalistigiBirim";
            this.lookUpCalistigiBirim.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpCalistigiBirim.Properties.Appearance.Options.UseFont = true;
            this.lookUpCalistigiBirim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCalistigiBirim.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BirimID", "Birim No", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BirimAd", "Birim Adı")});
            this.lookUpCalistigiBirim.Properties.NullText = "";
            this.lookUpCalistigiBirim.Properties.ReadOnly = true;
            this.lookUpCalistigiBirim.Size = new System.Drawing.Size(122, 22);
            this.lookUpCalistigiBirim.TabIndex = 290;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Location = new System.Drawing.Point(194, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 16);
            this.labelControl1.TabIndex = 289;
            this.labelControl1.Text = "Ç. Birim :";
            // 
            // lookUpMedeniHal
            // 
            this.lookUpMedeniHal.Location = new System.Drawing.Point(94, 83);
            this.lookUpMedeniHal.Name = "lookUpMedeniHal";
            this.lookUpMedeniHal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpMedeniHal.Properties.Appearance.Options.UseFont = true;
            this.lookUpMedeniHal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpMedeniHal.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Medeni Hali")});
            this.lookUpMedeniHal.Properties.NullText = "";
            this.lookUpMedeniHal.Properties.ReadOnly = true;
            this.lookUpMedeniHal.Size = new System.Drawing.Size(94, 22);
            this.lookUpMedeniHal.TabIndex = 288;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl13.Location = new System.Drawing.Point(12, 86);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(76, 16);
            this.labelControl13.TabIndex = 287;
            this.labelControl13.Text = "Medeni Hali :";
            // 
            // lookUpCinsiyet
            // 
            this.lookUpCinsiyet.Location = new System.Drawing.Point(255, 83);
            this.lookUpCinsiyet.Name = "lookUpCinsiyet";
            this.lookUpCinsiyet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpCinsiyet.Properties.Appearance.Options.UseFont = true;
            this.lookUpCinsiyet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCinsiyet.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Cinsiyet")});
            this.lookUpCinsiyet.Properties.NullText = "";
            this.lookUpCinsiyet.Properties.ReadOnly = true;
            this.lookUpCinsiyet.Size = new System.Drawing.Size(122, 22);
            this.lookUpCinsiyet.TabIndex = 286;
            // 
            // txtTcKimlikNo
            // 
            this.txtTcKimlikNo.EditValue = "12546987512";
            this.txtTcKimlikNo.Location = new System.Drawing.Point(94, 55);
            this.txtTcKimlikNo.Name = "txtTcKimlikNo";
            this.txtTcKimlikNo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTcKimlikNo.Properties.Appearance.Options.UseFont = true;
            this.txtTcKimlikNo.Properties.Mask.EditMask = "\\d{0,11}";
            this.txtTcKimlikNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTcKimlikNo.Size = new System.Drawing.Size(94, 22);
            this.txtTcKimlikNo.TabIndex = 282;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Location = new System.Drawing.Point(27, 58);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(61, 16);
            this.labelControl5.TabIndex = 281;
            this.labelControl5.Text = "TC K. No :";
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdSoyad.Location = new System.Drawing.Point(194, 27);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdSoyad.Properties.Appearance.Options.UseFont = true;
            this.txtAdSoyad.Properties.ReadOnly = true;
            this.txtAdSoyad.Size = new System.Drawing.Size(283, 22);
            this.txtAdSoyad.TabIndex = 280;
            // 
            // lblGelirAdi
            // 
            this.lblGelirAdi.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGelirAdi.Location = new System.Drawing.Point(123, 30);
            this.lblGelirAdi.Name = "lblGelirAdi";
            this.lblGelirAdi.Size = new System.Drawing.Size(65, 16);
            this.lblGelirAdi.TabIndex = 279;
            this.lblGelirAdi.Text = "Ad Soyad :";
            // 
            // txtPersonelID
            // 
            this.txtPersonelID.Location = new System.Drawing.Point(59, 27);
            this.txtPersonelID.Name = "txtPersonelID";
            this.txtPersonelID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPersonelID.Properties.Appearance.Options.UseFont = true;
            this.txtPersonelID.Properties.Mask.EditMask = "\\d+";
            this.txtPersonelID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtPersonelID.Size = new System.Drawing.Size(58, 22);
            this.txtPersonelID.TabIndex = 278;
            this.txtPersonelID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPersonelID_KeyDown);
            // 
            // lblGelirNo
            // 
            this.lblGelirNo.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGelirNo.Location = new System.Drawing.Point(5, 30);
            this.lblGelirNo.Name = "lblGelirNo";
            this.lblGelirNo.Size = new System.Drawing.Size(48, 16);
            this.lblGelirNo.TabIndex = 277;
            this.lblGelirNo.Text = "Per.No :";
            // 
            // btnPersonelDuzenle
            // 
            this.btnPersonelDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPersonelDuzenle.Image = global::MaviElmasOtoSis.ResOtoSis.Edit_icon;
            this.btnPersonelDuzenle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPersonelDuzenle.Location = new System.Drawing.Point(457, 0);
            this.btnPersonelDuzenle.Name = "btnPersonelDuzenle";
            this.btnPersonelDuzenle.Size = new System.Drawing.Size(20, 20);
            this.btnPersonelDuzenle.TabIndex = 276;
            this.btnPersonelDuzenle.Click += new System.EventHandler(this.btnPersonelDuzenle_Click);
            // 
            // btnPersonelYeni
            // 
            this.btnPersonelYeni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPersonelYeni.Image = ((System.Drawing.Image)(resources.GetObject("btnPersonelYeni.Image")));
            this.btnPersonelYeni.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPersonelYeni.Location = new System.Drawing.Point(431, 0);
            this.btnPersonelYeni.Name = "btnPersonelYeni";
            this.btnPersonelYeni.Size = new System.Drawing.Size(20, 20);
            this.btnPersonelYeni.TabIndex = 275;
            this.btnPersonelYeni.Click += new System.EventHandler(this.btnPersonelYeni_Click);
            // 
            // btnPersonelSec
            // 
            this.btnPersonelSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPersonelSec.Image = global::MaviElmasOtoSis.ResOtoSis.gozat;
            this.btnPersonelSec.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPersonelSec.Location = new System.Drawing.Point(405, 0);
            this.btnPersonelSec.Name = "btnPersonelSec";
            this.btnPersonelSec.Size = new System.Drawing.Size(20, 20);
            this.btnPersonelSec.TabIndex = 274;
            this.btnPersonelSec.Click += new System.EventHandler(this.btnPersonelSec_Click);
            // 
            // ucPersonelDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grupGelirGiderBilgileri);
            this.Name = "ucPersonelDemo";
            this.Size = new System.Drawing.Size(482, 110);
            ((System.ComponentModel.ISupportInitialize)(this.grupGelirGiderBilgileri)).EndInit();
            this.grupGelirGiderBilgileri.ResumeLayout(false);
            this.grupGelirGiderBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCalistigiBirim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpMedeniHal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCinsiyet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTcKimlikNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdSoyad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grupGelirGiderBilgileri;
        private DevExpress.XtraEditors.TextEdit txtAdSoyad;
        private DevExpress.XtraEditors.LabelControl lblGelirAdi;
        private DevExpress.XtraEditors.TextEdit txtPersonelID;
        private DevExpress.XtraEditors.LabelControl lblGelirNo;
        private DevExpress.XtraEditors.SimpleButton btnPersonelDuzenle;
        private DevExpress.XtraEditors.SimpleButton btnPersonelYeni;
        private DevExpress.XtraEditors.SimpleButton btnPersonelSec;
        private DevExpress.XtraEditors.TextEdit txtTcKimlikNo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lookUpCalistigiBirim;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpMedeniHal;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LookUpEdit lookUpCinsiyet;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
