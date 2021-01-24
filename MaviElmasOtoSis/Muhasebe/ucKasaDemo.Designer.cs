namespace MaviElmasOtoSis.Muhasebe
{
    partial class ucKasaDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKasaDemo));
            this.groupMarkaBilgileri = new DevExpress.XtraEditors.GroupControl();
            this.btnStokKartDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokKartEkle = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokKartSec = new DevExpress.XtraEditors.SimpleButton();
            this.txtKasaID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtKasaAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupMarkaBilgileri)).BeginInit();
            this.groupMarkaBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupMarkaBilgileri
            // 
            this.groupMarkaBilgileri.Controls.Add(this.btnStokKartDuzenle);
            this.groupMarkaBilgileri.Controls.Add(this.btnStokKartEkle);
            this.groupMarkaBilgileri.Controls.Add(this.btnStokKartSec);
            this.groupMarkaBilgileri.Controls.Add(this.txtKasaID);
            this.groupMarkaBilgileri.Controls.Add(this.labelControl1);
            this.groupMarkaBilgileri.Controls.Add(this.txtKasaAdi);
            this.groupMarkaBilgileri.Controls.Add(this.labelControl4);
            this.groupMarkaBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupMarkaBilgileri.Location = new System.Drawing.Point(0, 0);
            this.groupMarkaBilgileri.Name = "groupMarkaBilgileri";
            this.groupMarkaBilgileri.Size = new System.Drawing.Size(509, 64);
            this.groupMarkaBilgileri.TabIndex = 260;
            this.groupMarkaBilgileri.Text = "İşlem Yapılacak Kasa Bilgileri";
            // 
            // btnStokKartDuzenle
            // 
            this.btnStokKartDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStokKartDuzenle.Image = global::MaviElmasOtoSis.ResOtoSis.Edit_icon;
            this.btnStokKartDuzenle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnStokKartDuzenle.Location = new System.Drawing.Point(484, 0);
            this.btnStokKartDuzenle.Name = "btnStokKartDuzenle";
            this.btnStokKartDuzenle.Size = new System.Drawing.Size(20, 20);
            this.btnStokKartDuzenle.TabIndex = 276;
            this.btnStokKartDuzenle.Click += new System.EventHandler(this.btnStokKartDuzenle_Click);
            // 
            // btnStokKartEkle
            // 
            this.btnStokKartEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStokKartEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnStokKartEkle.Image")));
            this.btnStokKartEkle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnStokKartEkle.Location = new System.Drawing.Point(458, 0);
            this.btnStokKartEkle.Name = "btnStokKartEkle";
            this.btnStokKartEkle.Size = new System.Drawing.Size(20, 20);
            this.btnStokKartEkle.TabIndex = 275;
            this.btnStokKartEkle.Click += new System.EventHandler(this.btnStokKartEkle_Click);
            // 
            // btnStokKartSec
            // 
            this.btnStokKartSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStokKartSec.Image = global::MaviElmasOtoSis.ResOtoSis.gozat;
            this.btnStokKartSec.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnStokKartSec.Location = new System.Drawing.Point(432, 0);
            this.btnStokKartSec.Name = "btnStokKartSec";
            this.btnStokKartSec.Size = new System.Drawing.Size(20, 20);
            this.btnStokKartSec.TabIndex = 274;
            this.btnStokKartSec.Click += new System.EventHandler(this.btnStokKartSec_Click);
            // 
            // txtKasaID
            // 
            this.txtKasaID.Location = new System.Drawing.Point(71, 27);
            this.txtKasaID.Name = "txtKasaID";
            this.txtKasaID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKasaID.Properties.Appearance.Options.UseFont = true;
            this.txtKasaID.Properties.ReadOnly = true;
            this.txtKasaID.Size = new System.Drawing.Size(31, 22);
            this.txtKasaID.TabIndex = 262;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Location = new System.Drawing.Point(7, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 16);
            this.labelControl1.TabIndex = 261;
            this.labelControl1.Text = "Kasa No :";
            // 
            // txtKasaAdi
            // 
            this.txtKasaAdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKasaAdi.Location = new System.Drawing.Point(175, 27);
            this.txtKasaAdi.Name = "txtKasaAdi";
            this.txtKasaAdi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKasaAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKasaAdi.Properties.ReadOnly = true;
            this.txtKasaAdi.Size = new System.Drawing.Size(329, 22);
            this.txtKasaAdi.TabIndex = 46;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Location = new System.Drawing.Point(108, 28);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 16);
            this.labelControl4.TabIndex = 44;
            this.labelControl4.Text = "Kasa Adı :";
            // 
            // ucKasaDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupMarkaBilgileri);
            this.Name = "ucKasaDemo";
            this.Size = new System.Drawing.Size(509, 64);
            ((System.ComponentModel.ISupportInitialize)(this.groupMarkaBilgileri)).EndInit();
            this.groupMarkaBilgileri.ResumeLayout(false);
            this.groupMarkaBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaAdi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnStokKartDuzenle;
        private DevExpress.XtraEditors.SimpleButton btnStokKartEkle;
        private DevExpress.XtraEditors.SimpleButton btnStokKartSec;
        private DevExpress.XtraEditors.TextEdit txtKasaID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtKasaAdi;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.GroupControl groupMarkaBilgileri;
    }
}
