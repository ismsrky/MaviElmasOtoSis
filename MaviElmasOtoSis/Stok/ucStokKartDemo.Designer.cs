namespace MaviElmasOtoSis.Stok
{
    partial class ucStokKartDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStokKartDemo));
            this.grupKartBilgileri = new DevExpress.XtraEditors.GroupControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtKartID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl75 = new DevExpress.XtraEditors.LabelControl();
            this.txtParcaNo = new DevExpress.XtraEditors.TextEdit();
            this.txtKalemAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtBarkodNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl51 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpStokBirim = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpStokGrup = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnKartDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnKartYeni = new DevExpress.XtraEditors.SimpleButton();
            this.btnKartSec = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grupKartBilgileri)).BeginInit();
            this.grupKartBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParcaNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKalemAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarkodNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpStokBirim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpStokGrup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grupKartBilgileri
            // 
            this.grupKartBilgileri.Controls.Add(this.labelControl10);
            this.grupKartBilgileri.Controls.Add(this.txtKartID);
            this.grupKartBilgileri.Controls.Add(this.labelControl4);
            this.grupKartBilgileri.Controls.Add(this.labelControl75);
            this.grupKartBilgileri.Controls.Add(this.txtParcaNo);
            this.grupKartBilgileri.Controls.Add(this.txtKalemAdi);
            this.grupKartBilgileri.Controls.Add(this.txtBarkodNo);
            this.grupKartBilgileri.Controls.Add(this.labelControl51);
            this.grupKartBilgileri.Controls.Add(this.labelControl8);
            this.grupKartBilgileri.Controls.Add(this.lookUpStokBirim);
            this.grupKartBilgileri.Controls.Add(this.lookUpStokGrup);
            this.grupKartBilgileri.Controls.Add(this.labelControl6);
            this.grupKartBilgileri.Controls.Add(this.btnKartDuzenle);
            this.grupKartBilgileri.Controls.Add(this.btnKartYeni);
            this.grupKartBilgileri.Controls.Add(this.btnKartSec);
            this.grupKartBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupKartBilgileri.Location = new System.Drawing.Point(0, 0);
            this.grupKartBilgileri.Name = "grupKartBilgileri";
            this.grupKartBilgileri.Size = new System.Drawing.Size(456, 112);
            this.grupKartBilgileri.TabIndex = 262;
            this.grupKartBilgileri.Text = "Stok Kartı Bilgileri";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl10.Location = new System.Drawing.Point(9, 31);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(52, 16);
            this.labelControl10.TabIndex = 287;
            this.labelControl10.Text = "Kart No :";
            // 
            // txtKartID
            // 
            this.txtKartID.Location = new System.Drawing.Point(67, 28);
            this.txtKartID.Name = "txtKartID";
            this.txtKartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKartID.Properties.Appearance.Options.UseFont = true;
            this.txtKartID.Size = new System.Drawing.Size(88, 22);
            this.txtKartID.TabIndex = 288;
            this.txtKartID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKartID_KeyDown);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Location = new System.Drawing.Point(164, 30);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 16);
            this.labelControl4.TabIndex = 279;
            this.labelControl4.Text = "Kalem Adı :";
            // 
            // labelControl75
            // 
            this.labelControl75.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl75.Location = new System.Drawing.Point(20, 59);
            this.labelControl75.Name = "labelControl75";
            this.labelControl75.Size = new System.Drawing.Size(41, 16);
            this.labelControl75.TabIndex = 277;
            this.labelControl75.Text = "P. No :";
            this.labelControl75.ToolTip = "Parça No";
            // 
            // txtParcaNo
            // 
            this.txtParcaNo.Location = new System.Drawing.Point(67, 56);
            this.txtParcaNo.Name = "txtParcaNo";
            this.txtParcaNo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtParcaNo.Properties.Appearance.Options.UseFont = true;
            this.txtParcaNo.Size = new System.Drawing.Size(88, 22);
            this.txtParcaNo.TabIndex = 278;
            this.txtParcaNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParcaNo_KeyDown);
            // 
            // txtKalemAdi
            // 
            this.txtKalemAdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKalemAdi.Location = new System.Drawing.Point(235, 28);
            this.txtKalemAdi.Name = "txtKalemAdi";
            this.txtKalemAdi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKalemAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKalemAdi.Properties.ReadOnly = true;
            this.txtKalemAdi.Size = new System.Drawing.Size(215, 22);
            this.txtKalemAdi.TabIndex = 280;
            // 
            // txtBarkodNo
            // 
            this.txtBarkodNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarkodNo.Location = new System.Drawing.Point(235, 84);
            this.txtBarkodNo.Name = "txtBarkodNo";
            this.txtBarkodNo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBarkodNo.Properties.Appearance.Options.UseFont = true;
            this.txtBarkodNo.Properties.ReadOnly = true;
            this.txtBarkodNo.Size = new System.Drawing.Size(215, 22);
            this.txtBarkodNo.TabIndex = 286;
            // 
            // labelControl51
            // 
            this.labelControl51.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl51.Location = new System.Drawing.Point(3, 87);
            this.labelControl51.Name = "labelControl51";
            this.labelControl51.Size = new System.Drawing.Size(58, 16);
            this.labelControl51.TabIndex = 281;
            this.labelControl51.Text = "S. Birimi :";
            this.labelControl51.ToolTip = "Stok Birimi";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Location = new System.Drawing.Point(163, 86);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(69, 16);
            this.labelControl8.TabIndex = 285;
            this.labelControl8.Text = "Barkod No :";
            // 
            // lookUpStokBirim
            // 
            this.lookUpStokBirim.Location = new System.Drawing.Point(67, 84);
            this.lookUpStokBirim.Name = "lookUpStokBirim";
            this.lookUpStokBirim.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpStokBirim.Properties.Appearance.Options.UseFont = true;
            this.lookUpStokBirim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpStokBirim.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Stok Birimi")});
            this.lookUpStokBirim.Properties.NullText = "";
            this.lookUpStokBirim.Properties.ReadOnly = true;
            this.lookUpStokBirim.Size = new System.Drawing.Size(88, 22);
            this.lookUpStokBirim.TabIndex = 282;
            // 
            // lookUpStokGrup
            // 
            this.lookUpStokGrup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpStokGrup.Location = new System.Drawing.Point(235, 56);
            this.lookUpStokGrup.Name = "lookUpStokGrup";
            this.lookUpStokGrup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpStokGrup.Properties.Appearance.Options.UseFont = true;
            this.lookUpStokGrup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpStokGrup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Stok Grubu")});
            this.lookUpStokGrup.Properties.NullText = "";
            this.lookUpStokGrup.Properties.ReadOnly = true;
            this.lookUpStokGrup.Size = new System.Drawing.Size(215, 22);
            this.lookUpStokGrup.TabIndex = 284;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Location = new System.Drawing.Point(158, 58);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(74, 16);
            this.labelControl6.TabIndex = 283;
            this.labelControl6.Text = "Stok Grubu :";
            // 
            // btnKartDuzenle
            // 
            this.btnKartDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKartDuzenle.Image = global::MaviElmasOtoSis.ResOtoSis.Edit_icon;
            this.btnKartDuzenle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnKartDuzenle.Location = new System.Drawing.Point(431, 0);
            this.btnKartDuzenle.Name = "btnKartDuzenle";
            this.btnKartDuzenle.Size = new System.Drawing.Size(20, 20);
            this.btnKartDuzenle.TabIndex = 276;
            this.btnKartDuzenle.Click += new System.EventHandler(this.btnKartDuzenle_Click);
            // 
            // btnKartYeni
            // 
            this.btnKartYeni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKartYeni.Image = ((System.Drawing.Image)(resources.GetObject("btnKartYeni.Image")));
            this.btnKartYeni.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnKartYeni.Location = new System.Drawing.Point(405, 0);
            this.btnKartYeni.Name = "btnKartYeni";
            this.btnKartYeni.Size = new System.Drawing.Size(20, 20);
            this.btnKartYeni.TabIndex = 275;
            this.btnKartYeni.Click += new System.EventHandler(this.btnKartYeni_Click);
            // 
            // btnKartSec
            // 
            this.btnKartSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKartSec.Image = global::MaviElmasOtoSis.ResOtoSis.gozat;
            this.btnKartSec.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnKartSec.Location = new System.Drawing.Point(379, 0);
            this.btnKartSec.Name = "btnKartSec";
            this.btnKartSec.Size = new System.Drawing.Size(20, 20);
            this.btnKartSec.TabIndex = 274;
            this.btnKartSec.Click += new System.EventHandler(this.btnKartSec_Click);
            // 
            // ucStokKartDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grupKartBilgileri);
            this.Name = "ucStokKartDemo";
            this.Size = new System.Drawing.Size(456, 112);
            ((System.ComponentModel.ISupportInitialize)(this.grupKartBilgileri)).EndInit();
            this.grupKartBilgileri.ResumeLayout(false);
            this.grupKartBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParcaNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKalemAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarkodNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpStokBirim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpStokGrup.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grupKartBilgileri;
        private DevExpress.XtraEditors.SimpleButton btnKartDuzenle;
        private DevExpress.XtraEditors.SimpleButton btnKartYeni;
        private DevExpress.XtraEditors.SimpleButton btnKartSec;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtKartID;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl75;
        private DevExpress.XtraEditors.TextEdit txtParcaNo;
        private DevExpress.XtraEditors.TextEdit txtKalemAdi;
        private DevExpress.XtraEditors.TextEdit txtBarkodNo;
        private DevExpress.XtraEditors.LabelControl labelControl51;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LookUpEdit lookUpStokBirim;
        private DevExpress.XtraEditors.LookUpEdit lookUpStokGrup;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
