namespace MaviElmasOtoSis.Muhasebe
{
    partial class ucGelirGiderDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGelirGiderDemo));
            this.grupGelirGiderBilgileri = new DevExpress.XtraEditors.GroupControl();
            this.lookUpGelirGiderGrup = new DevExpress.XtraEditors.LookUpEdit();
            this.lblGelirGrubu = new DevExpress.XtraEditors.LabelControl();
            this.txtAd = new DevExpress.XtraEditors.TextEdit();
            this.lblGelirAdi = new DevExpress.XtraEditors.LabelControl();
            this.txtGelirGiderID = new DevExpress.XtraEditors.TextEdit();
            this.lblGelirNo = new DevExpress.XtraEditors.LabelControl();
            this.btnGelirGiderDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnGelirGiderYeni = new DevExpress.XtraEditors.SimpleButton();
            this.btnGelirGiderSec = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grupGelirGiderBilgileri)).BeginInit();
            this.grupGelirGiderBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGelirGiderGrup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGelirGiderID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grupGelirGiderBilgileri
            // 
            this.grupGelirGiderBilgileri.Controls.Add(this.lookUpGelirGiderGrup);
            this.grupGelirGiderBilgileri.Controls.Add(this.lblGelirGrubu);
            this.grupGelirGiderBilgileri.Controls.Add(this.txtAd);
            this.grupGelirGiderBilgileri.Controls.Add(this.lblGelirAdi);
            this.grupGelirGiderBilgileri.Controls.Add(this.txtGelirGiderID);
            this.grupGelirGiderBilgileri.Controls.Add(this.lblGelirNo);
            this.grupGelirGiderBilgileri.Controls.Add(this.btnGelirGiderDuzenle);
            this.grupGelirGiderBilgileri.Controls.Add(this.btnGelirGiderYeni);
            this.grupGelirGiderBilgileri.Controls.Add(this.btnGelirGiderSec);
            this.grupGelirGiderBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupGelirGiderBilgileri.Location = new System.Drawing.Point(0, 0);
            this.grupGelirGiderBilgileri.Name = "grupGelirGiderBilgileri";
            this.grupGelirGiderBilgileri.Size = new System.Drawing.Size(512, 91);
            this.grupGelirGiderBilgileri.TabIndex = 261;
            this.grupGelirGiderBilgileri.Text = "Gelir / Gider Bilgileri";
            // 
            // lookUpGelirGiderGrup
            // 
            this.lookUpGelirGiderGrup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpGelirGiderGrup.Location = new System.Drawing.Point(194, 55);
            this.lookUpGelirGiderGrup.Name = "lookUpGelirGiderGrup";
            this.lookUpGelirGiderGrup.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpGelirGiderGrup.Properties.Appearance.Options.UseFont = true;
            this.lookUpGelirGiderGrup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpGelirGiderGrup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Gelir / Gider Grubu")});
            this.lookUpGelirGiderGrup.Properties.NullText = "";
            this.lookUpGelirGiderGrup.Properties.ReadOnly = true;
            this.lookUpGelirGiderGrup.Size = new System.Drawing.Size(313, 22);
            this.lookUpGelirGiderGrup.TabIndex = 282;
            // 
            // lblGelirGrubu
            // 
            this.lblGelirGrubu.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGelirGrubu.Location = new System.Drawing.Point(114, 58);
            this.lblGelirGrubu.Name = "lblGelirGrubu";
            this.lblGelirGrubu.Size = new System.Drawing.Size(74, 16);
            this.lblGelirGrubu.TabIndex = 281;
            this.lblGelirGrubu.Text = "Gelir Grubu :";
            // 
            // txtAd
            // 
            this.txtAd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAd.Location = new System.Drawing.Point(194, 27);
            this.txtAd.Name = "txtAd";
            this.txtAd.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAd.Properties.Appearance.Options.UseFont = true;
            this.txtAd.Properties.ReadOnly = true;
            this.txtAd.Size = new System.Drawing.Size(313, 22);
            this.txtAd.TabIndex = 280;
            // 
            // lblGelirAdi
            // 
            this.lblGelirAdi.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGelirAdi.Location = new System.Drawing.Point(130, 30);
            this.lblGelirAdi.Name = "lblGelirAdi";
            this.lblGelirAdi.Size = new System.Drawing.Size(58, 16);
            this.lblGelirAdi.TabIndex = 279;
            this.lblGelirAdi.Text = "Gelir Adı :";
            // 
            // txtGelirGiderID
            // 
            this.txtGelirGiderID.Location = new System.Drawing.Point(66, 27);
            this.txtGelirGiderID.Name = "txtGelirGiderID";
            this.txtGelirGiderID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGelirGiderID.Properties.Appearance.Options.UseFont = true;
            this.txtGelirGiderID.Properties.ReadOnly = true;
            this.txtGelirGiderID.Size = new System.Drawing.Size(58, 22);
            this.txtGelirGiderID.TabIndex = 278;
            // 
            // lblGelirNo
            // 
            this.lblGelirNo.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGelirNo.Location = new System.Drawing.Point(5, 30);
            this.lblGelirNo.Name = "lblGelirNo";
            this.lblGelirNo.Size = new System.Drawing.Size(55, 16);
            this.lblGelirNo.TabIndex = 277;
            this.lblGelirNo.Text = "Gelir No :";
            // 
            // btnGelirGiderDuzenle
            // 
            this.btnGelirGiderDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGelirGiderDuzenle.Image = global::MaviElmasOtoSis.ResOtoSis.Edit_icon;
            this.btnGelirGiderDuzenle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnGelirGiderDuzenle.Location = new System.Drawing.Point(487, 0);
            this.btnGelirGiderDuzenle.Name = "btnGelirGiderDuzenle";
            this.btnGelirGiderDuzenle.Size = new System.Drawing.Size(20, 20);
            this.btnGelirGiderDuzenle.TabIndex = 276;
            this.btnGelirGiderDuzenle.Click += new System.EventHandler(this.btnGelirGiderDuzenle_Click);
            // 
            // btnGelirGiderYeni
            // 
            this.btnGelirGiderYeni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGelirGiderYeni.Image = ((System.Drawing.Image)(resources.GetObject("btnGelirGiderYeni.Image")));
            this.btnGelirGiderYeni.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnGelirGiderYeni.Location = new System.Drawing.Point(461, 0);
            this.btnGelirGiderYeni.Name = "btnGelirGiderYeni";
            this.btnGelirGiderYeni.Size = new System.Drawing.Size(20, 20);
            this.btnGelirGiderYeni.TabIndex = 275;
            this.btnGelirGiderYeni.Click += new System.EventHandler(this.btnGelirGiderYeni_Click);
            // 
            // btnGelirGiderSec
            // 
            this.btnGelirGiderSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGelirGiderSec.Image = global::MaviElmasOtoSis.ResOtoSis.gozat;
            this.btnGelirGiderSec.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnGelirGiderSec.Location = new System.Drawing.Point(435, 0);
            this.btnGelirGiderSec.Name = "btnGelirGiderSec";
            this.btnGelirGiderSec.Size = new System.Drawing.Size(20, 20);
            this.btnGelirGiderSec.TabIndex = 274;
            this.btnGelirGiderSec.Click += new System.EventHandler(this.btnGelirGiderSec_Click);
            // 
            // ucGelirGiderDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grupGelirGiderBilgileri);
            this.Name = "ucGelirGiderDemo";
            this.Size = new System.Drawing.Size(512, 91);
            ((System.ComponentModel.ISupportInitialize)(this.grupGelirGiderBilgileri)).EndInit();
            this.grupGelirGiderBilgileri.ResumeLayout(false);
            this.grupGelirGiderBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpGelirGiderGrup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGelirGiderID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grupGelirGiderBilgileri;
        private DevExpress.XtraEditors.SimpleButton btnGelirGiderDuzenle;
        private DevExpress.XtraEditors.SimpleButton btnGelirGiderYeni;
        private DevExpress.XtraEditors.SimpleButton btnGelirGiderSec;
        private DevExpress.XtraEditors.TextEdit txtGelirGiderID;
        private DevExpress.XtraEditors.LabelControl lblGelirNo;
        private DevExpress.XtraEditors.LookUpEdit lookUpGelirGiderGrup;
        private DevExpress.XtraEditors.LabelControl lblGelirGrubu;
        private DevExpress.XtraEditors.TextEdit txtAd;
        private DevExpress.XtraEditors.LabelControl lblGelirAdi;

    }
}
