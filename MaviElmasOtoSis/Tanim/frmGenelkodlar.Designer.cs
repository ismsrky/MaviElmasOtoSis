namespace MaviElmasOtoSis.Tanim
{
    partial class frmGenelkodlar
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControlTanimlamalar = new DevExpress.XtraGrid.GridControl();
            this.gridViewTanimlamalar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYeniKayit = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkDurum = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtKod = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAciklama = new DevExpress.XtraEditors.TextEdit();
            this.cmbGruplar = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTanimlamalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTanimlamalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGruplar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControlTanimlamalar);
            this.groupControl2.Controls.Add(this.btnYeniKayit);
            this.groupControl2.Controls.Add(this.btnSil);
            this.groupControl2.Controls.Add(this.btnKaydet);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.chkDurum);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.txtKod);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.txtAciklama);
            this.groupControl2.Location = new System.Drawing.Point(4, 36);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(731, 346);
            this.groupControl2.TabIndex = 256;
            this.groupControl2.Text = "Tanım Bilgileri";
            // 
            // gridControlTanimlamalar
            // 
            this.gridControlTanimlamalar.Location = new System.Drawing.Point(12, 76);
            this.gridControlTanimlamalar.MainView = this.gridViewTanimlamalar;
            this.gridControlTanimlamalar.Name = "gridControlTanimlamalar";
            this.gridControlTanimlamalar.Size = new System.Drawing.Size(710, 265);
            this.gridControlTanimlamalar.TabIndex = 257;
            this.gridControlTanimlamalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTanimlamalar});
            // 
            // gridViewTanimlamalar
            // 
            this.gridViewTanimlamalar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKod,
            this.colAciklama,
            this.colDurum,
            this.colID});
            this.gridViewTanimlamalar.GridControl = this.gridControlTanimlamalar;
            this.gridViewTanimlamalar.Name = "gridViewTanimlamalar";
            this.gridViewTanimlamalar.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewTanimlamalar.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewTanimlamalar.OptionsBehavior.Editable = false;
            this.gridViewTanimlamalar.OptionsBehavior.ReadOnly = true;
            this.gridViewTanimlamalar.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewTanimlamalar.OptionsView.ShowGroupPanel = false;
            this.gridViewTanimlamalar.OptionsView.ShowViewCaption = true;
            this.gridViewTanimlamalar.ViewCaption = "Gruba Ait Tanımlamalar";
            this.gridViewTanimlamalar.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewTanimlamalar_FocusedRowChanged);
            this.gridViewTanimlamalar.Click += new System.EventHandler(this.gridViewTanimlamalar_Click);
            // 
            // colKod
            // 
            this.colKod.AppearanceCell.Options.UseTextOptions = true;
            this.colKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKod.Caption = "Kod";
            this.colKod.FieldName = "Kod";
            this.colKod.MaxWidth = 50;
            this.colKod.Name = "colKod";
            this.colKod.Visible = true;
            this.colKod.VisibleIndex = 0;
            this.colKod.Width = 50;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 1;
            this.colAciklama.Width = 452;
            // 
            // colDurum
            // 
            this.colDurum.Caption = "Durum";
            this.colDurum.FieldName = "Durum";
            this.colDurum.Name = "colDurum";
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 2;
            this.colDurum.Width = 101;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // btnYeniKayit
            // 
            this.btnYeniKayit.Image = global::MaviElmasOtoSis.ResOtoSis.yeni;
            this.btnYeniKayit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYeniKayit.Location = new System.Drawing.Point(479, 46);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(82, 24);
            this.btnYeniKayit.TabIndex = 256;
            this.btnYeniKayit.Text = "Yeni Kayıt";
            this.btnYeniKayit.Click += new System.EventHandler(this.btnYeniKayit_Click);
            // 
            // btnSil
            // 
            this.btnSil.Image = global::MaviElmasOtoSis.ResOtoSis.Del;
            this.btnSil.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSil.Location = new System.Drawing.Point(421, 46);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(52, 24);
            this.btnSil.TabIndex = 255;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Image = global::MaviElmasOtoSis.ResOtoSis.kaydetdisket;
            this.btnKaydet.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(567, 46);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(82, 24);
            this.btnKaydet.TabIndex = 254;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Location = new System.Drawing.Point(303, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 16);
            this.labelControl3.TabIndex = 251;
            this.labelControl3.Text = "Durum :";
            // 
            // chkDurum
            // 
            this.chkDurum.Location = new System.Drawing.Point(359, 25);
            this.chkDurum.Name = "chkDurum";
            this.chkDurum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.chkDurum.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.chkDurum.Properties.Appearance.Options.UseFont = true;
            this.chkDurum.Properties.Appearance.Options.UseForeColor = true;
            this.chkDurum.Properties.Caption = "Aktif";
            this.chkDurum.Size = new System.Drawing.Size(63, 21);
            this.chkDurum.TabIndex = 250;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Location = new System.Drawing.Point(322, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 16);
            this.labelControl2.TabIndex = 249;
            this.labelControl2.Text = "Kod :";
            // 
            // txtKod
            // 
            this.txtKod.Location = new System.Drawing.Point(361, 48);
            this.txtKod.Name = "txtKod";
            this.txtKod.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKod.Properties.Appearance.Options.UseFont = true;
            this.txtKod.Properties.Mask.EditMask = "\\d+";
            this.txtKod.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtKod.Size = new System.Drawing.Size(48, 22);
            this.txtKod.TabIndex = 248;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Location = new System.Drawing.Point(12, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 16);
            this.labelControl1.TabIndex = 247;
            this.labelControl1.Text = "Açıklama :";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(85, 48);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAciklama.Properties.Appearance.Options.UseFont = true;
            this.txtAciklama.Size = new System.Drawing.Size(227, 22);
            this.txtAciklama.TabIndex = 246;
            // 
            // cmbGruplar
            // 
            this.cmbGruplar.Location = new System.Drawing.Point(89, 8);
            this.cmbGruplar.Name = "cmbGruplar";
            this.cmbGruplar.Properties.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbGruplar.Properties.Appearance.Options.UseFont = true;
            this.cmbGruplar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGruplar.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbGruplar.Size = new System.Drawing.Size(231, 22);
            this.cmbGruplar.TabIndex = 255;
            this.cmbGruplar.SelectedIndexChanged += new System.EventHandler(this.cmbGruplar_SelectedIndexChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl7.Location = new System.Drawing.Point(4, 10);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(79, 16);
            this.labelControl7.TabIndex = 254;
            this.labelControl7.Text = "Grup Seçin :";
            // 
            // frmGenelkodlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 390);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.cmbGruplar);
            this.Controls.Add(this.labelControl7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenelkodlar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGenelkodlar";
            this.Load += new System.EventHandler(this.frmGenelkodlar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGenelkodlar_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTanimlamalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTanimlamalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGruplar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnYeniKayit;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chkDurum;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtKod;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAciklama;
        private DevExpress.XtraEditors.ComboBoxEdit cmbGruplar;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.GridControl gridControlTanimlamalar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTanimlamalar;
        private DevExpress.XtraGrid.Columns.GridColumn colKod;
        private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
    }
}