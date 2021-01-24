namespace MaviElmasOtoSis.Muhasebe
{
    partial class ucFatura
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
            this.splitAna = new System.Windows.Forms.SplitContainer();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlFaturalar = new DevExpress.XtraGrid.GridControl();
            this.GridViewFaturalar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFaturaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnvan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTcKimlikNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcikFatura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reLookUpFaturaTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colFaturaKaynak = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reLookUpFaturaKaynak = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colIsemirID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirimAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reLookUpBirim = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colServisID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAracID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKayitZaman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateKayitBit = new DevExpress.XtraEditors.DateEdit();
            this.dateKayitBas = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ucFaturaDetay1 = new MaviElmasOtoSis.Muhasebe.ucFaturaDetay();
            ((System.ComponentModel.ISupportInitialize)(this.splitAna)).BeginInit();
            this.splitAna.Panel1.SuspendLayout();
            this.splitAna.Panel2.SuspendLayout();
            this.splitAna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFaturalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewFaturalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reLookUpFaturaTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reLookUpFaturaKaynak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reLookUpBirim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.splitAna.Panel1.Controls.Add(this.btnYenile);
            this.splitAna.Panel1.Controls.Add(this.gridControlFaturalar);
            this.splitAna.Panel1.Controls.Add(this.labelControl3);
            this.splitAna.Panel1.Controls.Add(this.labelControl2);
            this.splitAna.Panel1.Controls.Add(this.dateKayitBit);
            this.splitAna.Panel1.Controls.Add(this.dateKayitBas);
            this.splitAna.Panel1.Controls.Add(this.labelControl1);
            // 
            // splitAna.Panel2
            // 
            this.splitAna.Panel2.Controls.Add(this.ucFaturaDetay1);
            this.splitAna.Size = new System.Drawing.Size(947, 465);
            this.splitAna.SplitterDistance = 172;
            this.splitAna.TabIndex = 5;
            // 
            // btnYenile
            // 
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(108, 77);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 291;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // gridControlFaturalar
            // 
            this.gridControlFaturalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlFaturalar.Location = new System.Drawing.Point(7, 108);
            this.gridControlFaturalar.MainView = this.GridViewFaturalar;
            this.gridControlFaturalar.Name = "gridControlFaturalar";
            this.gridControlFaturalar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reLookUpFaturaTip,
            this.reLookUpFaturaKaynak,
            this.reLookUpBirim});
            this.gridControlFaturalar.Size = new System.Drawing.Size(158, 358);
            this.gridControlFaturalar.TabIndex = 290;
            this.gridControlFaturalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewFaturalar});
            // 
            // GridViewFaturalar
            // 
            this.GridViewFaturalar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFaturaID,
            this.colPlaka,
            this.colUnvan,
            this.colTcKimlikNo,
            this.colFaturaTarih,
            this.colAcikFatura,
            this.colFaturaKaynak,
            this.colIsemirID,
            this.colBirimAd,
            this.colServisID,
            this.colAracID,
            this.colKayitZaman});
            this.GridViewFaturalar.GridControl = this.gridControlFaturalar;
            this.GridViewFaturalar.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.GridViewFaturalar.Name = "GridViewFaturalar";
            this.GridViewFaturalar.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewFaturalar.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewFaturalar.OptionsBehavior.Editable = false;
            this.GridViewFaturalar.OptionsBehavior.ReadOnly = true;
            this.GridViewFaturalar.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewFaturalar.OptionsView.ColumnAutoWidth = false;
            this.GridViewFaturalar.OptionsView.ShowAutoFilterRow = true;
            this.GridViewFaturalar.OptionsView.ShowGroupPanel = false;
            this.GridViewFaturalar.OptionsView.ShowIndicator = false;
            this.GridViewFaturalar.OptionsView.ShowViewCaption = true;
            this.GridViewFaturalar.ViewCaption = "Faturalar Listesi";
            this.GridViewFaturalar.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewFaturalar_FocusedRowChanged);
            this.GridViewFaturalar.Click += new System.EventHandler(this.GridViewFaturalar_Click);
            // 
            // colFaturaID
            // 
            this.colFaturaID.Caption = "Fatura No";
            this.colFaturaID.FieldName = "FaturaID";
            this.colFaturaID.MinWidth = 62;
            this.colFaturaID.Name = "colFaturaID";
            this.colFaturaID.Visible = true;
            this.colFaturaID.VisibleIndex = 0;
            this.colFaturaID.Width = 62;
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
            this.colUnvan.VisibleIndex = 8;
            this.colUnvan.Width = 62;
            // 
            // colTcKimlikNo
            // 
            this.colTcKimlikNo.Caption = "Cari Tc Kimlik No";
            this.colTcKimlikNo.FieldName = "TcKimlikNo";
            this.colTcKimlikNo.Name = "colTcKimlikNo";
            this.colTcKimlikNo.Visible = true;
            this.colTcKimlikNo.VisibleIndex = 3;
            // 
            // colFaturaTarih
            // 
            this.colFaturaTarih.Caption = "FaturaTarih";
            this.colFaturaTarih.FieldName = "FaturaTarih";
            this.colFaturaTarih.MaxWidth = 70;
            this.colFaturaTarih.MinWidth = 60;
            this.colFaturaTarih.Name = "colFaturaTarih";
            this.colFaturaTarih.Visible = true;
            this.colFaturaTarih.VisibleIndex = 4;
            this.colFaturaTarih.Width = 70;
            // 
            // colAcikFatura
            // 
            this.colAcikFatura.Caption = "Açık Fatura";
            this.colAcikFatura.ColumnEdit = this.reLookUpFaturaTip;
            this.colAcikFatura.FieldName = "FaturaTipi";
            this.colAcikFatura.Name = "colAcikFatura";
            this.colAcikFatura.Visible = true;
            this.colAcikFatura.VisibleIndex = 2;
            // 
            // reLookUpFaturaTip
            // 
            this.reLookUpFaturaTip.AutoHeight = false;
            this.reLookUpFaturaTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reLookUpFaturaTip.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Alan", "Fatura Tipi")});
            this.reLookUpFaturaTip.Name = "reLookUpFaturaTip";
            // 
            // colFaturaKaynak
            // 
            this.colFaturaKaynak.Caption = "Fatura Kaynağı";
            this.colFaturaKaynak.ColumnEdit = this.reLookUpFaturaKaynak;
            this.colFaturaKaynak.FieldName = "FaturaKaynak";
            this.colFaturaKaynak.Name = "colFaturaKaynak";
            this.colFaturaKaynak.Visible = true;
            this.colFaturaKaynak.VisibleIndex = 5;
            // 
            // reLookUpFaturaKaynak
            // 
            this.reLookUpFaturaKaynak.AutoHeight = false;
            this.reLookUpFaturaKaynak.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reLookUpFaturaKaynak.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Alan", "Fatura Kaynağı")});
            this.reLookUpFaturaKaynak.Name = "reLookUpFaturaKaynak";
            // 
            // colIsemirID
            // 
            this.colIsemirID.Caption = "Isemir No";
            this.colIsemirID.FieldName = "IsemirID";
            this.colIsemirID.Name = "colIsemirID";
            this.colIsemirID.Visible = true;
            this.colIsemirID.VisibleIndex = 6;
            // 
            // colBirimAd
            // 
            this.colBirimAd.Caption = "İşemri Birim Adı";
            this.colBirimAd.ColumnEdit = this.reLookUpBirim;
            this.colBirimAd.FieldName = "BirimID";
            this.colBirimAd.Name = "colBirimAd";
            this.colBirimAd.Visible = true;
            this.colBirimAd.VisibleIndex = 9;
            // 
            // reLookUpBirim
            // 
            this.reLookUpBirim.AutoHeight = false;
            this.reLookUpBirim.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reLookUpBirim.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BirimID", "Birim No"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BirimAd", "Birim Adı")});
            this.reLookUpBirim.Name = "reLookUpBirim";
            // 
            // colServisID
            // 
            this.colServisID.Caption = "Servis No";
            this.colServisID.FieldName = "ServisID";
            this.colServisID.Name = "colServisID";
            this.colServisID.Visible = true;
            this.colServisID.VisibleIndex = 7;
            // 
            // colAracID
            // 
            this.colAracID.Caption = "Araç No";
            this.colAracID.MinWidth = 62;
            this.colAracID.Name = "colAracID";
            this.colAracID.Visible = true;
            this.colAracID.VisibleIndex = 10;
            this.colAracID.Width = 62;
            // 
            // colKayitZaman
            // 
            this.colKayitZaman.Caption = "Kayıt Tarihi";
            this.colKayitZaman.FieldName = "KayitZaman";
            this.colKayitZaman.MinWidth = 62;
            this.colKayitZaman.Name = "colKayitZaman";
            this.colKayitZaman.Visible = true;
            this.colKayitZaman.VisibleIndex = 11;
            this.colKayitZaman.Width = 62;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Location = new System.Drawing.Point(37, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 16);
            this.labelControl3.TabIndex = 289;
            this.labelControl3.Text = "Bitiş :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Location = new System.Drawing.Point(7, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 16);
            this.labelControl2.TabIndex = 288;
            this.labelControl2.Text = "Başlangıç :";
            // 
            // dateKayitBit
            // 
            this.dateKayitBit.EditValue = null;
            this.dateKayitBit.Location = new System.Drawing.Point(75, 49);
            this.dateKayitBit.Name = "dateKayitBit";
            this.dateKayitBit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
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
            this.dateKayitBit.Size = new System.Drawing.Size(88, 22);
            this.dateKayitBit.TabIndex = 287;
            // 
            // dateKayitBas
            // 
            this.dateKayitBas.EditValue = null;
            this.dateKayitBas.Location = new System.Drawing.Point(75, 21);
            this.dateKayitBas.Name = "dateKayitBas";
            this.dateKayitBas.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateKayitBas.Properties.Appearance.Options.UseFont = true;
            this.dateKayitBas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKayitBas.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.dateKayitBas.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateKayitBas.Properties.EditFormat.FormatString = "dd.MM.yyyy";
            this.dateKayitBas.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateKayitBas.Properties.Mask.EditMask = "dd.MM.yyyy";
            this.dateKayitBas.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateKayitBas.Size = new System.Drawing.Size(88, 22);
            this.dateKayitBas.TabIndex = 286;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Location = new System.Drawing.Point(7, -1);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 16);
            this.labelControl1.TabIndex = 285;
            this.labelControl1.Text = "Fatura Tarihi :";
            // 
            // ucFaturaDetay1
            // 
            this.ucFaturaDetay1.DetayMode = MaviElmasOtoSis.Enumlar.DetayModelari.Tum;
            this.ucFaturaDetay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFaturaDetay1.FaturaTipi = MaviElmasOtoSis.Enumlar.FaturaTipleri.SatisFaturasi;
            this.ucFaturaDetay1.Location = new System.Drawing.Point(0, 0);
            this.ucFaturaDetay1.Name = "ucFaturaDetay1";
            this.ucFaturaDetay1.Size = new System.Drawing.Size(771, 465);
            this.ucFaturaDetay1.TabIndex = 0;
            // 
            // ucFatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitAna);
            this.Name = "ucFatura";
            this.Size = new System.Drawing.Size(947, 465);
            this.Load += new System.EventHandler(this.ucFatura_Load);
            this.splitAna.Panel1.ResumeLayout(false);
            this.splitAna.Panel1.PerformLayout();
            this.splitAna.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitAna)).EndInit();
            this.splitAna.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFaturalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewFaturalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reLookUpFaturaTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reLookUpFaturaKaynak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reLookUpBirim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitAna;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraGrid.GridControl gridControlFaturalar;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewFaturalar;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaID;
        private DevExpress.XtraGrid.Columns.GridColumn colUnvan;
        private DevExpress.XtraGrid.Columns.GridColumn colTcKimlikNo;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaTarih;
        private DevExpress.XtraGrid.Columns.GridColumn colAcikFatura;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit reLookUpFaturaTip;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaKaynak;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit reLookUpFaturaKaynak;
        private DevExpress.XtraGrid.Columns.GridColumn colIsemirID;
        private DevExpress.XtraGrid.Columns.GridColumn colBirimAd;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit reLookUpBirim;
        private DevExpress.XtraGrid.Columns.GridColumn colServisID;
        private DevExpress.XtraGrid.Columns.GridColumn colAracID;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaka;
        private DevExpress.XtraGrid.Columns.GridColumn colKayitZaman;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateKayitBit;
        private DevExpress.XtraEditors.DateEdit dateKayitBas;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private ucFaturaDetay ucFaturaDetay1;

    }
}
