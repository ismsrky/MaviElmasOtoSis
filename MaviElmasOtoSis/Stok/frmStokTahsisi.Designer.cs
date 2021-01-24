namespace MaviElmasOtoSis.Stok
{
    partial class frmStokTahsisi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStokTahsisi));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lookUpDepolar = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl29 = new DevExpress.XtraEditors.LabelControl();
            this.btnIptal = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnKaydet = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.labelControl42 = new DevExpress.XtraEditors.LabelControl();
            this.spinMiktar = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.memoAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.ucStokKartDemo1 = new MaviElmasOtoSis.Stok.ucStokKartDemo();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepolar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lookUpDepolar);
            this.groupControl1.Controls.Add(this.labelControl29);
            this.groupControl1.Controls.Add(this.btnIptal);
            this.groupControl1.Controls.Add(this.btnKaydet);
            this.groupControl1.Controls.Add(this.labelControl42);
            this.groupControl1.Controls.Add(this.spinMiktar);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.memoAciklama);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.radioGroup1);
            this.groupControl1.Location = new System.Drawing.Point(5, 124);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(456, 196);
            this.groupControl1.TabIndex = 259;
            this.groupControl1.Text = "Stok Girişi";
            // 
            // lookUpDepolar
            // 
            this.lookUpDepolar.Location = new System.Drawing.Point(102, 62);
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
            this.lookUpDepolar.Size = new System.Drawing.Size(155, 22);
            this.lookUpDepolar.TabIndex = 305;
            // 
            // labelControl29
            // 
            this.labelControl29.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.labelControl29.Location = new System.Drawing.Point(55, 63);
            this.labelControl29.Name = "labelControl29";
            this.labelControl29.Size = new System.Drawing.Size(43, 16);
            this.labelControl29.TabIndex = 304;
            this.labelControl29.Text = "*Depo :";
            // 
            // btnIptal
            // 
            this.btnIptal.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Cikis;
            this.btnIptal.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Image = ((System.Drawing.Image)(resources.GetObject("btnIptal.Image")));
            this.btnIptal.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnIptal.Location = new System.Drawing.Point(267, 166);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(80, 25);
            this.btnIptal.TabIndex = 83;
            this.btnIptal.Text = "maviButon1";
            this.btnIptal.ToolTip = "Esc - İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Kaydet;
            this.btnKaydet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnKaydet.Location = new System.Drawing.Point(353, 166);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(92, 25);
            this.btnKaydet.TabIndex = 82;
            this.btnKaydet.Text = "maviButon1";
            this.btnKaydet.ToolTip = "F2 - Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // labelControl42
            // 
            this.labelControl42.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl42.Location = new System.Drawing.Point(267, 34);
            this.labelControl42.Name = "labelControl42";
            this.labelControl42.Size = new System.Drawing.Size(49, 16);
            this.labelControl42.TabIndex = 81;
            this.labelControl42.Text = "*Miktar :";
            // 
            // spinMiktar
            // 
            this.spinMiktar.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinMiktar.Location = new System.Drawing.Point(322, 32);
            this.spinMiktar.Name = "spinMiktar";
            this.spinMiktar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinMiktar.Properties.DisplayFormat.FormatString = "n2";
            this.spinMiktar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinMiktar.Properties.EditFormat.FormatString = "n2";
            this.spinMiktar.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinMiktar.Properties.Mask.EditMask = "n2";
            this.spinMiktar.Size = new System.Drawing.Size(67, 20);
            this.spinMiktar.TabIndex = 80;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Location = new System.Drawing.Point(29, 92);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(67, 16);
            this.labelControl9.TabIndex = 79;
            this.labelControl9.Text = "*Açıklama :";
            // 
            // memoAciklama
            // 
            this.memoAciklama.Location = new System.Drawing.Point(104, 90);
            this.memoAciklama.Name = "memoAciklama";
            this.memoAciklama.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.memoAciklama.Properties.Appearance.Options.UseFont = true;
            this.memoAciklama.Properties.MaxLength = 150;
            this.memoAciklama.Size = new System.Drawing.Size(341, 70);
            this.memoAciklama.TabIndex = 78;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Location = new System.Drawing.Point(18, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 16);
            this.labelControl2.TabIndex = 45;
            this.labelControl2.Text = "*İşlem Yönü :";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(102, 25);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Giriş"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Çıkış")});
            this.radioGroup1.Size = new System.Drawing.Size(159, 31);
            this.radioGroup1.TabIndex = 0;
            // 
            // ucStokKartDemo1
            // 
            this.ucStokKartDemo1.Location = new System.Drawing.Point(5, 7);
            this.ucStokKartDemo1.Name = "ucStokKartDemo1";
            this.ucStokKartDemo1.Size = new System.Drawing.Size(456, 112);
            this.ucStokKartDemo1.TabIndex = 260;
            // 
            // frmStokTahsisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(469, 324);
            this.Controls.Add(this.ucStokKartDemo1);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStokTahsisi";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStokTahsisi";
            this.Load += new System.EventHandler(this.frmStokHareketEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepolar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit memoAciklama;
        private DevExpress.XtraEditors.LabelControl labelControl42;
        private DevExpress.XtraEditors.SpinEdit spinMiktar;
        private Bilesenler.MaviButon btnKaydet;
        private Bilesenler.MaviButon btnIptal;
        private DevExpress.XtraEditors.LookUpEdit lookUpDepolar;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private ucStokKartDemo ucStokKartDemo1;
    }
}