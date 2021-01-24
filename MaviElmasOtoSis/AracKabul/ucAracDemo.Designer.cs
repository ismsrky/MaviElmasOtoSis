namespace MaviElmasOtoSis.AracKabul
{
    partial class ucAracDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAracDemo));
            this.grupAracBilgileri = new DevExpress.XtraEditors.GroupControl();
            this.lookUpCekis = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpVitesTipi = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpYakitTipi = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpKaroser = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAracDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnAracEkle = new DevExpress.XtraEditors.SimpleButton();
            this.btnAracSec = new DevExpress.XtraEditors.SimpleButton();
            this.memoAracDetay = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.txtAracID = new DevExpress.XtraEditors.TextEdit();
            this.txtAracSaseNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtAracPlaka = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.txtAracRuhsatSahibi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grupAracBilgileri)).BeginInit();
            this.grupAracBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCekis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpVitesTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpYakitTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpKaroser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAracDetay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAracID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAracSaseNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAracPlaka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAracRuhsatSahibi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grupAracBilgileri
            // 
            this.grupAracBilgileri.Controls.Add(this.lookUpCekis);
            this.grupAracBilgileri.Controls.Add(this.lookUpVitesTipi);
            this.grupAracBilgileri.Controls.Add(this.lookUpYakitTipi);
            this.grupAracBilgileri.Controls.Add(this.lookUpKaroser);
            this.grupAracBilgileri.Controls.Add(this.btnAracDuzenle);
            this.grupAracBilgileri.Controls.Add(this.btnAracEkle);
            this.grupAracBilgileri.Controls.Add(this.btnAracSec);
            this.grupAracBilgileri.Controls.Add(this.memoAracDetay);
            this.grupAracBilgileri.Controls.Add(this.labelControl21);
            this.grupAracBilgileri.Controls.Add(this.labelControl19);
            this.grupAracBilgileri.Controls.Add(this.labelControl2);
            this.grupAracBilgileri.Controls.Add(this.labelControl20);
            this.grupAracBilgileri.Controls.Add(this.txtAracID);
            this.grupAracBilgileri.Controls.Add(this.txtAracSaseNo);
            this.grupAracBilgileri.Controls.Add(this.labelControl3);
            this.grupAracBilgileri.Controls.Add(this.labelControl4);
            this.grupAracBilgileri.Controls.Add(this.txtAracPlaka);
            this.grupAracBilgileri.Controls.Add(this.labelControl17);
            this.grupAracBilgileri.Controls.Add(this.txtAracRuhsatSahibi);
            this.grupAracBilgileri.Controls.Add(this.labelControl18);
            this.grupAracBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grupAracBilgileri.Location = new System.Drawing.Point(0, 0);
            this.grupAracBilgileri.Name = "grupAracBilgileri";
            this.grupAracBilgileri.Size = new System.Drawing.Size(503, 179);
            this.grupAracBilgileri.TabIndex = 261;
            this.grupAracBilgileri.Text = "Araç Bilgileri";
            // 
            // lookUpCekis
            // 
            this.lookUpCekis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpCekis.Location = new System.Drawing.Point(339, 139);
            this.lookUpCekis.Name = "lookUpCekis";
            this.lookUpCekis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpCekis.Properties.Appearance.Options.UseFont = true;
            this.lookUpCekis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCekis.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Çekişi")});
            this.lookUpCekis.Properties.NullText = "";
            this.lookUpCekis.Properties.ReadOnly = true;
            this.lookUpCekis.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.lookUpCekis.Size = new System.Drawing.Size(158, 22);
            this.lookUpCekis.TabIndex = 321;
            // 
            // lookUpVitesTipi
            // 
            this.lookUpVitesTipi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpVitesTipi.Location = new System.Drawing.Point(339, 108);
            this.lookUpVitesTipi.Name = "lookUpVitesTipi";
            this.lookUpVitesTipi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpVitesTipi.Properties.Appearance.Options.UseFont = true;
            this.lookUpVitesTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpVitesTipi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Vites Tipi")});
            this.lookUpVitesTipi.Properties.NullText = "";
            this.lookUpVitesTipi.Properties.ReadOnly = true;
            this.lookUpVitesTipi.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.lookUpVitesTipi.Size = new System.Drawing.Size(158, 22);
            this.lookUpVitesTipi.TabIndex = 320;
            // 
            // lookUpYakitTipi
            // 
            this.lookUpYakitTipi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpYakitTipi.Location = new System.Drawing.Point(339, 80);
            this.lookUpYakitTipi.Name = "lookUpYakitTipi";
            this.lookUpYakitTipi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpYakitTipi.Properties.Appearance.Options.UseFont = true;
            this.lookUpYakitTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpYakitTipi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Yakıt Tipi")});
            this.lookUpYakitTipi.Properties.NullText = "";
            this.lookUpYakitTipi.Properties.ReadOnly = true;
            this.lookUpYakitTipi.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.lookUpYakitTipi.Size = new System.Drawing.Size(158, 22);
            this.lookUpYakitTipi.TabIndex = 319;
            // 
            // lookUpKaroser
            // 
            this.lookUpKaroser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpKaroser.Location = new System.Drawing.Point(339, 55);
            this.lookUpKaroser.Name = "lookUpKaroser";
            this.lookUpKaroser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.lookUpKaroser.Properties.Appearance.Options.UseFont = true;
            this.lookUpKaroser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpKaroser.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", "Kod", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", "Karoser Tipi")});
            this.lookUpKaroser.Properties.NullText = "";
            this.lookUpKaroser.Properties.ReadOnly = true;
            this.lookUpKaroser.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.lookUpKaroser.Size = new System.Drawing.Size(158, 22);
            this.lookUpKaroser.TabIndex = 309;
            // 
            // btnAracDuzenle
            // 
            this.btnAracDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAracDuzenle.Image = global::MaviElmasOtoSis.ResOtoSis.Edit_icon;
            this.btnAracDuzenle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAracDuzenle.Location = new System.Drawing.Point(480, 0);
            this.btnAracDuzenle.Name = "btnAracDuzenle";
            this.btnAracDuzenle.Size = new System.Drawing.Size(20, 20);
            this.btnAracDuzenle.TabIndex = 273;
            this.btnAracDuzenle.Click += new System.EventHandler(this.btnAracDuzenle_Click);
            // 
            // btnAracEkle
            // 
            this.btnAracEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAracEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnAracEkle.Image")));
            this.btnAracEkle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAracEkle.Location = new System.Drawing.Point(454, 0);
            this.btnAracEkle.Name = "btnAracEkle";
            this.btnAracEkle.Size = new System.Drawing.Size(20, 20);
            this.btnAracEkle.TabIndex = 272;
            this.btnAracEkle.Click += new System.EventHandler(this.btnAracEkle_Click);
            // 
            // btnAracSec
            // 
            this.btnAracSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAracSec.Image = global::MaviElmasOtoSis.ResOtoSis.gozat;
            this.btnAracSec.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAracSec.Location = new System.Drawing.Point(428, 0);
            this.btnAracSec.Name = "btnAracSec";
            this.btnAracSec.Size = new System.Drawing.Size(20, 20);
            this.btnAracSec.TabIndex = 271;
            this.btnAracSec.Click += new System.EventHandler(this.btnAracSec_Click);
            // 
            // memoAracDetay
            // 
            this.memoAracDetay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.memoAracDetay.EditValue = "Ford - Focus 2010 model ";
            this.memoAracDetay.Location = new System.Drawing.Point(5, 84);
            this.memoAracDetay.Name = "memoAracDetay";
            this.memoAracDetay.Properties.Appearance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.memoAracDetay.Properties.Appearance.Options.UseFont = true;
            this.memoAracDetay.Properties.MaxLength = 150;
            this.memoAracDetay.Size = new System.Drawing.Size(263, 90);
            this.memoAracDetay.TabIndex = 270;
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl21.Location = new System.Drawing.Point(295, 142);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(41, 16);
            this.labelControl21.TabIndex = 269;
            this.labelControl21.Text = "Çekiş :";
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl19.Location = new System.Drawing.Point(274, 85);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(62, 16);
            this.labelControl19.TabIndex = 265;
            this.labelControl19.Text = "Yakıt Tipi :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Location = new System.Drawing.Point(283, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 16);
            this.labelControl2.TabIndex = 263;
            this.labelControl2.Text = "Karoser :";
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl20.Location = new System.Drawing.Point(274, 112);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(62, 16);
            this.labelControl20.TabIndex = 267;
            this.labelControl20.Text = "Vites Tipi :";
            // 
            // txtAracID
            // 
            this.txtAracID.Location = new System.Drawing.Point(72, 27);
            this.txtAracID.Name = "txtAracID";
            this.txtAracID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAracID.Properties.Appearance.Options.UseFont = true;
            this.txtAracID.Properties.Mask.EditMask = "\\d+";
            this.txtAracID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtAracID.Size = new System.Drawing.Size(61, 22);
            this.txtAracID.TabIndex = 262;
            this.txtAracID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAracID_KeyDown);
            // 
            // txtAracSaseNo
            // 
            this.txtAracSaseNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAracSaseNo.Location = new System.Drawing.Point(339, 27);
            this.txtAracSaseNo.Name = "txtAracSaseNo";
            this.txtAracSaseNo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAracSaseNo.Properties.Appearance.Options.UseFont = true;
            this.txtAracSaseNo.Properties.ReadOnly = true;
            this.txtAracSaseNo.Size = new System.Drawing.Size(158, 22);
            this.txtAracSaseNo.TabIndex = 260;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Location = new System.Drawing.Point(282, 30);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 16);
            this.labelControl3.TabIndex = 59;
            this.labelControl3.Text = "Şasi No :";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Location = new System.Drawing.Point(11, 28);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(55, 16);
            this.labelControl4.TabIndex = 261;
            this.labelControl4.Text = "Araç No :";
            // 
            // txtAracPlaka
            // 
            this.txtAracPlaka.Location = new System.Drawing.Point(189, 27);
            this.txtAracPlaka.Name = "txtAracPlaka";
            this.txtAracPlaka.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAracPlaka.Properties.Appearance.Options.UseFont = true;
            this.txtAracPlaka.Size = new System.Drawing.Size(80, 22);
            this.txtAracPlaka.TabIndex = 46;
            this.txtAracPlaka.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAracPlaka_KeyDown);
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl17.Location = new System.Drawing.Point(139, 30);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(41, 16);
            this.labelControl17.TabIndex = 44;
            this.labelControl17.Text = "Plaka :";
            // 
            // txtAracRuhsatSahibi
            // 
            this.txtAracRuhsatSahibi.Location = new System.Drawing.Point(72, 55);
            this.txtAracRuhsatSahibi.Name = "txtAracRuhsatSahibi";
            this.txtAracRuhsatSahibi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAracRuhsatSahibi.Properties.Appearance.Options.UseFont = true;
            this.txtAracRuhsatSahibi.Properties.ReadOnly = true;
            this.txtAracRuhsatSahibi.Size = new System.Drawing.Size(197, 22);
            this.txtAracRuhsatSahibi.TabIndex = 31;
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl18.Location = new System.Drawing.Point(5, 56);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(61, 16);
            this.labelControl18.TabIndex = 30;
            this.labelControl18.Text = "R. Sahibi :";
            // 
            // ucAracDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grupAracBilgileri);
            this.Name = "ucAracDemo";
            this.Size = new System.Drawing.Size(503, 179);
            ((System.ComponentModel.ISupportInitialize)(this.grupAracBilgileri)).EndInit();
            this.grupAracBilgileri.ResumeLayout(false);
            this.grupAracBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCekis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpVitesTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpYakitTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpKaroser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAracDetay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAracID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAracSaseNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAracPlaka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAracRuhsatSahibi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grupAracBilgileri;
        private DevExpress.XtraEditors.LookUpEdit lookUpCekis;
        private DevExpress.XtraEditors.LookUpEdit lookUpVitesTipi;
        private DevExpress.XtraEditors.LookUpEdit lookUpYakitTipi;
        private DevExpress.XtraEditors.LookUpEdit lookUpKaroser;
        private DevExpress.XtraEditors.SimpleButton btnAracDuzenle;
        private DevExpress.XtraEditors.SimpleButton btnAracEkle;
        private DevExpress.XtraEditors.SimpleButton btnAracSec;
        private DevExpress.XtraEditors.MemoEdit memoAracDetay;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.TextEdit txtAracID;
        private DevExpress.XtraEditors.TextEdit txtAracSaseNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtAracPlaka;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.TextEdit txtAracRuhsatSahibi;
        private DevExpress.XtraEditors.LabelControl labelControl18;
    }
}
