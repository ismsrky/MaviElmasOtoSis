namespace MaviElmasOtoSis.AracKabul
{
    partial class ucServis
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateKayitBas = new DevExpress.XtraEditors.DateEdit();
            this.dateKayitBit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.splitAna = new System.Windows.Forms.SplitContainer();
            this.cmbServisDurum = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlServisler = new DevExpress.XtraGrid.GridControl();
            this.GridViewServisler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colServisID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnvan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeslimTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAracID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKayitZaman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucServisDetay1 = new MaviElmasOtoSis.AracKabul.ucServisDetay();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitAna)).BeginInit();
            this.splitAna.Panel1.SuspendLayout();
            this.splitAna.Panel2.SuspendLayout();
            this.splitAna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServisDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlServisler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewServisler)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Location = new System.Drawing.Point(6, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(114, 16);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Servis Açılış Tarihi :";
            // 
            // dateKayitBas
            // 
            this.dateKayitBas.EditValue = null;
            this.dateKayitBas.Location = new System.Drawing.Point(3, 28);
            this.dateKayitBas.Name = "dateKayitBas";
            this.dateKayitBas.Properties.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateKayitBas.Properties.Appearance.Options.UseFont = true;
            this.dateKayitBas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKayitBas.Properties.Mask.EditMask = "g";
            this.dateKayitBas.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateKayitBas.Size = new System.Drawing.Size(79, 20);
            this.dateKayitBas.TabIndex = 81;
            // 
            // dateKayitBit
            // 
            this.dateKayitBit.EditValue = null;
            this.dateKayitBit.Location = new System.Drawing.Point(91, 28);
            this.dateKayitBit.Name = "dateKayitBit";
            this.dateKayitBit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateKayitBit.Properties.Appearance.Options.UseFont = true;
            this.dateKayitBit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKayitBit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.dateKayitBit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateKayitBit.Properties.EditFormat.FormatString = "dd.MM.yyyy";
            this.dateKayitBit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateKayitBit.Properties.Mask.EditMask = "dd.MM.yyyy";
            this.dateKayitBit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateKayitBit.Size = new System.Drawing.Size(79, 20);
            this.dateKayitBit.TabIndex = 83;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Location = new System.Drawing.Point(83, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(5, 16);
            this.labelControl2.TabIndex = 85;
            this.labelControl2.Text = "/";
            // 
            // splitAna
            // 
            this.splitAna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitAna.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitAna.Location = new System.Drawing.Point(0, 0);
            this.splitAna.Name = "splitAna";
            // 
            // splitAna.Panel1
            // 
            this.splitAna.Panel1.Controls.Add(this.cmbServisDurum);
            this.splitAna.Panel1.Controls.Add(this.btnYenile);
            this.splitAna.Panel1.Controls.Add(this.gridControlServisler);
            this.splitAna.Panel1.Controls.Add(this.labelControl2);
            this.splitAna.Panel1.Controls.Add(this.dateKayitBit);
            this.splitAna.Panel1.Controls.Add(this.dateKayitBas);
            this.splitAna.Panel1.Controls.Add(this.labelControl1);
            // 
            // splitAna.Panel2
            // 
            this.splitAna.Panel2.Controls.Add(this.ucServisDetay1);
            this.splitAna.Size = new System.Drawing.Size(919, 500);
            this.splitAna.SplitterDistance = 172;
            this.splitAna.TabIndex = 4;
            // 
            // cmbServisDurum
            // 
            this.cmbServisDurum.Location = new System.Drawing.Point(6, 54);
            this.cmbServisDurum.Name = "cmbServisDurum";
            this.cmbServisDurum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbServisDurum.Properties.Items.AddRange(new object[] {
            "Tüm Servisler",
            "Açık",
            "Kapalı"});
            this.cmbServisDurum.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbServisDurum.Size = new System.Drawing.Size(100, 20);
            this.cmbServisDurum.TabIndex = 278;
            this.cmbServisDurum.SelectedIndexChanged += new System.EventHandler(this.cmbServisDurum_SelectedIndexChanged);
            // 
            // btnYenile
            // 
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(112, 50);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 277;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // gridControlServisler
            // 
            this.gridControlServisler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlServisler.Location = new System.Drawing.Point(0, 80);
            this.gridControlServisler.MainView = this.GridViewServisler;
            this.gridControlServisler.Name = "gridControlServisler";
            this.gridControlServisler.Size = new System.Drawing.Size(170, 420);
            this.gridControlServisler.TabIndex = 231;
            this.gridControlServisler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewServisler});
            // 
            // GridViewServisler
            // 
            this.GridViewServisler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colServisID,
            this.colPlaka,
            this.colUnvan,
            this.colTeslimTarih,
            this.colAracID,
            this.colKayitZaman});
            this.GridViewServisler.GridControl = this.gridControlServisler;
            this.GridViewServisler.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.GridViewServisler.Name = "GridViewServisler";
            this.GridViewServisler.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewServisler.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewServisler.OptionsBehavior.Editable = false;
            this.GridViewServisler.OptionsBehavior.ReadOnly = true;
            this.GridViewServisler.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewServisler.OptionsView.ColumnAutoWidth = false;
            this.GridViewServisler.OptionsView.ShowAutoFilterRow = true;
            this.GridViewServisler.OptionsView.ShowGroupPanel = false;
            this.GridViewServisler.OptionsView.ShowIndicator = false;
            this.GridViewServisler.OptionsView.ShowViewCaption = true;
            this.GridViewServisler.ViewCaption = "Servis Listesi";
            this.GridViewServisler.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.GridViewServisler_RowStyle);
            this.GridViewServisler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewServisler_FocusedRowChanged);
            this.GridViewServisler.Click += new System.EventHandler(this.GridViewServisler_Click);
            // 
            // colServisID
            // 
            this.colServisID.Caption = "Servis No";
            this.colServisID.FieldName = "ServisID";
            this.colServisID.MaxWidth = 65;
            this.colServisID.MinWidth = 62;
            this.colServisID.Name = "colServisID";
            this.colServisID.Visible = true;
            this.colServisID.VisibleIndex = 0;
            this.colServisID.Width = 62;
            // 
            // colPlaka
            // 
            this.colPlaka.Caption = "Plaka";
            this.colPlaka.FieldName = "Plaka";
            this.colPlaka.MinWidth = 62;
            this.colPlaka.Name = "colPlaka";
            this.colPlaka.Visible = true;
            this.colPlaka.VisibleIndex = 1;
            this.colPlaka.Width = 62;
            // 
            // colUnvan
            // 
            this.colUnvan.Caption = "Cari Ünvanı";
            this.colUnvan.FieldName = "Unvan";
            this.colUnvan.MinWidth = 62;
            this.colUnvan.Name = "colUnvan";
            this.colUnvan.Visible = true;
            this.colUnvan.VisibleIndex = 2;
            this.colUnvan.Width = 62;
            // 
            // colTeslimTarih
            // 
            this.colTeslimTarih.Caption = "Teslim Tarihi";
            this.colTeslimTarih.FieldName = "TeslimTarih";
            this.colTeslimTarih.Name = "colTeslimTarih";
            this.colTeslimTarih.Visible = true;
            this.colTeslimTarih.VisibleIndex = 3;
            // 
            // colAracID
            // 
            this.colAracID.Caption = "Araç No";
            this.colAracID.MinWidth = 62;
            this.colAracID.Name = "colAracID";
            this.colAracID.Visible = true;
            this.colAracID.VisibleIndex = 4;
            this.colAracID.Width = 62;
            // 
            // colKayitZaman
            // 
            this.colKayitZaman.Caption = "Tarih";
            this.colKayitZaman.FieldName = "KayitZaman";
            this.colKayitZaman.MinWidth = 62;
            this.colKayitZaman.Name = "colKayitZaman";
            this.colKayitZaman.Visible = true;
            this.colKayitZaman.VisibleIndex = 5;
            this.colKayitZaman.Width = 62;
            // 
            // ucServisDetay1
            // 
            this.ucServisDetay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucServisDetay1.Location = new System.Drawing.Point(0, 0);
            this.ucServisDetay1.Name = "ucServisDetay1";
            this.ucServisDetay1.Size = new System.Drawing.Size(743, 500);
            this.ucServisDetay1.TabIndex = 0;
            // 
            // ucServis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitAna);
            this.Name = "ucServis";
            this.Size = new System.Drawing.Size(919, 500);
            this.Load += new System.EventHandler(this.ucIsemri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties)).EndInit();
            this.splitAna.Panel1.ResumeLayout(false);
            this.splitAna.Panel1.PerformLayout();
            this.splitAna.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitAna)).EndInit();
            this.splitAna.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbServisDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlServisler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewServisler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateKayitBas;
        private DevExpress.XtraEditors.DateEdit dateKayitBit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.SplitContainer splitAna;
        private ucServisDetay ucServisDetay1;
        private DevExpress.XtraGrid.GridControl gridControlServisler;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewServisler;
        private DevExpress.XtraGrid.Columns.GridColumn colServisID;
        private DevExpress.XtraGrid.Columns.GridColumn colUnvan;
        private DevExpress.XtraGrid.Columns.GridColumn colAracID;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaka;
        private DevExpress.XtraGrid.Columns.GridColumn colKayitZaman;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.ComboBoxEdit cmbServisDurum;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimTarih;

    }
}
