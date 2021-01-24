namespace MaviElmasOtoSis.Tanim
{
    partial class ucIscilikDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucIscilikDemo));
            this.grupIscilikBilgileri = new DevExpress.XtraEditors.GroupControl();
            this.btnIscilikDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnIscilikYeni = new DevExpress.XtraEditors.SimpleButton();
            this.btnIscilikSec = new DevExpress.XtraEditors.SimpleButton();
            this.spinKacSaat = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl42 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl51 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpIscilikTip = new DevExpress.XtraEditors.LookUpEdit();
            this.txtIscilikID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtIscilikAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl75 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grupIscilikBilgileri)).BeginInit();
            this.grupIscilikBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinKacSaat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpIscilikTip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIscilikID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIscilikAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grupIscilikBilgileri
            // 
            this.grupIscilikBilgileri.Controls.Add(this.spinKacSaat);
            this.grupIscilikBilgileri.Controls.Add(this.labelControl42);
            this.grupIscilikBilgileri.Controls.Add(this.labelControl51);
            this.grupIscilikBilgileri.Controls.Add(this.lookUpIscilikTip);
            this.grupIscilikBilgileri.Controls.Add(this.txtIscilikID);
            this.grupIscilikBilgileri.Controls.Add(this.labelControl4);
            this.grupIscilikBilgileri.Controls.Add(this.txtIscilikAdi);
            this.grupIscilikBilgileri.Controls.Add(this.labelControl75);
            this.grupIscilikBilgileri.Controls.Add(this.btnIscilikDuzenle);
            this.grupIscilikBilgileri.Controls.Add(this.btnIscilikYeni);
            this.grupIscilikBilgileri.Controls.Add(this.btnIscilikSec);
            this.grupIscilikBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupIscilikBilgileri.Location = new System.Drawing.Point(0, 0);
            this.grupIscilikBilgileri.Name = "grupIscilikBilgileri";
            this.grupIscilikBilgileri.Size = new System.Drawing.Size(465, 82);
            this.grupIscilikBilgileri.TabIndex = 263;
            this.grupIscilikBilgileri.Text = "İşçilik Bilgileri";
            // 
            // btnIscilikDuzenle
            // 
            this.btnIscilikDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIscilikDuzenle.Image = global::MaviElmasOtoSis.ResOtoSis.Edit_icon;
            this.btnIscilikDuzenle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnIscilikDuzenle.Location = new System.Drawing.Point(440, 0);
            this.btnIscilikDuzenle.Name = "btnIscilikDuzenle";
            this.btnIscilikDuzenle.Size = new System.Drawing.Size(20, 20);
            this.btnIscilikDuzenle.TabIndex = 276;
            this.btnIscilikDuzenle.Click += new System.EventHandler(this.btnIscilikDuzenle_Click);
            // 
            // btnIscilikYeni
            // 
            this.btnIscilikYeni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIscilikYeni.Image = ((System.Drawing.Image)(resources.GetObject("btnIscilikYeni.Image")));
            this.btnIscilikYeni.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnIscilikYeni.Location = new System.Drawing.Point(414, 0);
            this.btnIscilikYeni.Name = "btnIscilikYeni";
            this.btnIscilikYeni.Size = new System.Drawing.Size(20, 20);
            this.btnIscilikYeni.TabIndex = 275;
            this.btnIscilikYeni.Click += new System.EventHandler(this.btnIscilikYeni_Click);
            // 
            // btnIscilikSec
            // 
            this.btnIscilikSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIscilikSec.Image = global::MaviElmasOtoSis.ResOtoSis.gozat;
            this.btnIscilikSec.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnIscilikSec.Location = new System.Drawing.Point(388, 0);
            this.btnIscilikSec.Name = "btnIscilikSec";
            this.btnIscilikSec.Size = new System.Drawing.Size(20, 20);
            this.btnIscilikSec.TabIndex = 274;
            this.btnIscilikSec.Click += new System.EventHandler(this.btnIscilikSec_Click);
            // 
            // spinKacSaat
            // 
            this.spinKacSaat.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinKacSaat.Location = new System.Drawing.Point(77, 48);
            this.spinKacSaat.Name = "spinKacSaat";
            this.spinKacSaat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinKacSaat.Properties.DisplayFormat.FormatString = "n";
            this.spinKacSaat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinKacSaat.Properties.EditFormat.FormatString = "n";
            this.spinKacSaat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinKacSaat.Properties.NullValuePrompt = "Yok";
            this.spinKacSaat.Properties.ReadOnly = true;
            this.spinKacSaat.Size = new System.Drawing.Size(61, 20);
            this.spinKacSaat.TabIndex = 285;
            // 
            // labelControl42
            // 
            this.labelControl42.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl42.Location = new System.Drawing.Point(4, 50);
            this.labelControl42.Name = "labelControl42";
            this.labelControl42.Size = new System.Drawing.Size(62, 16);
            this.labelControl42.TabIndex = 286;
            this.labelControl42.Text = "Kaç Saat :";
            // 
            // labelControl51
            // 
            this.labelControl51.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl51.Location = new System.Drawing.Point(150, 51);
            this.labelControl51.Name = "labelControl51";
            this.labelControl51.Size = new System.Drawing.Size(65, 16);
            this.labelControl51.TabIndex = 283;
            this.labelControl51.Text = "İşçilik Tipi :";
            // 
            // lookUpIscilikTip
            // 
            this.lookUpIscilikTip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpIscilikTip.Location = new System.Drawing.Point(220, 49);
            this.lookUpIscilikTip.Name = "lookUpIscilikTip";
            this.lookUpIscilikTip.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpIscilikTip.Properties.Appearance.Options.UseFont = true;
            this.lookUpIscilikTip.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpIscilikTip.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "İşçilik Tipi")});
            this.lookUpIscilikTip.Properties.NullText = "";
            this.lookUpIscilikTip.Properties.ReadOnly = true;
            this.lookUpIscilikTip.Size = new System.Drawing.Size(240, 22);
            this.lookUpIscilikTip.TabIndex = 284;
            // 
            // txtIscilikID
            // 
            this.txtIscilikID.Location = new System.Drawing.Point(77, 22);
            this.txtIscilikID.Name = "txtIscilikID";
            this.txtIscilikID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtIscilikID.Properties.Appearance.Options.UseFont = true;
            this.txtIscilikID.Properties.ReadOnly = true;
            this.txtIscilikID.Size = new System.Drawing.Size(61, 22);
            this.txtIscilikID.TabIndex = 277;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Location = new System.Drawing.Point(5, 25);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 16);
            this.labelControl4.TabIndex = 280;
            this.labelControl4.Text = "İşçilik No :";
            // 
            // txtIscilikAdi
            // 
            this.txtIscilikAdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIscilikAdi.Location = new System.Drawing.Point(220, 21);
            this.txtIscilikAdi.Name = "txtIscilikAdi";
            this.txtIscilikAdi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtIscilikAdi.Properties.Appearance.Options.UseFont = true;
            this.txtIscilikAdi.Properties.ReadOnly = true;
            this.txtIscilikAdi.Size = new System.Drawing.Size(240, 22);
            this.txtIscilikAdi.TabIndex = 278;
            // 
            // labelControl75
            // 
            this.labelControl75.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl75.Location = new System.Drawing.Point(151, 24);
            this.labelControl75.Name = "labelControl75";
            this.labelControl75.Size = new System.Drawing.Size(64, 16);
            this.labelControl75.TabIndex = 279;
            this.labelControl75.Text = "İşçilik Adı :";
            // 
            // ucIscilikDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grupIscilikBilgileri);
            this.Name = "ucIscilikDemo";
            this.Size = new System.Drawing.Size(465, 82);
            ((System.ComponentModel.ISupportInitialize)(this.grupIscilikBilgileri)).EndInit();
            this.grupIscilikBilgileri.ResumeLayout(false);
            this.grupIscilikBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinKacSaat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpIscilikTip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIscilikID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIscilikAdi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grupIscilikBilgileri;
        private DevExpress.XtraEditors.SimpleButton btnIscilikDuzenle;
        private DevExpress.XtraEditors.SimpleButton btnIscilikYeni;
        private DevExpress.XtraEditors.SimpleButton btnIscilikSec;
        private DevExpress.XtraEditors.SpinEdit spinKacSaat;
        private DevExpress.XtraEditors.LabelControl labelControl42;
        private DevExpress.XtraEditors.LabelControl labelControl51;
        private DevExpress.XtraEditors.LookUpEdit lookUpIscilikTip;
        private DevExpress.XtraEditors.TextEdit txtIscilikID;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtIscilikAdi;
        private DevExpress.XtraEditors.LabelControl labelControl75;
    }
}
