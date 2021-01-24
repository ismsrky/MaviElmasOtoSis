namespace MaviElmasOtoSis.Stok
{
    partial class ucStokHareket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStokHareket));
            this.splitAna = new System.Windows.Forms.SplitContainer();
            this.lookUpDepolar = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateKayitBit = new DevExpress.XtraEditors.DateEdit();
            this.dateKayitBas = new DevExpress.XtraEditors.DateEdit();
            this.resimModul = new System.Windows.Forms.PictureBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnYazdir1 = new MaviElmasOtoSis.Bilesenler.btnYazdir();
            this.GridViewStokHareketleri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParcaNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKalemAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokKartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGirisCikis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirimFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokHareketTipi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaturaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsemirID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServisID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKayitZaman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlStokHareketleri = new DevExpress.XtraGrid.GridControl();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ucKayitBilgi1 = new MaviElmasOtoSis.Sistem.ucKayitBilgi();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitAna)).BeginInit();
            this.splitAna.Panel1.SuspendLayout();
            this.splitAna.Panel2.SuspendLayout();
            this.splitAna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepolar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resimModul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewStokHareketleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStokHareketleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
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
            this.splitAna.Panel1.Controls.Add(this.lookUpDepolar);
            this.splitAna.Panel1.Controls.Add(this.labelControl4);
            this.splitAna.Panel1.Controls.Add(this.labelControl3);
            this.splitAna.Panel1.Controls.Add(this.labelControl2);
            this.splitAna.Panel1.Controls.Add(this.dateKayitBit);
            this.splitAna.Panel1.Controls.Add(this.dateKayitBas);
            this.splitAna.Panel1.Controls.Add(this.resimModul);
            this.splitAna.Panel1.Controls.Add(this.labelControl1);
            // 
            // splitAna.Panel2
            // 
            this.splitAna.Panel2.Controls.Add(this.btnYazdir1);
            this.splitAna.Panel2.Controls.Add(this.gridControlStokHareketleri);
            this.splitAna.Panel2.Controls.Add(this.ucKayitBilgi1);
            this.splitAna.Size = new System.Drawing.Size(937, 546);
            this.splitAna.SplitterDistance = 172;
            this.splitAna.TabIndex = 3;
            // 
            // lookUpDepolar
            // 
            this.lookUpDepolar.Location = new System.Drawing.Point(7, 136);
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
            this.lookUpDepolar.TabIndex = 88;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.labelControl4.Location = new System.Drawing.Point(6, 114);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(38, 16);
            this.labelControl4.TabIndex = 87;
            this.labelControl4.Text = "Depo :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Location = new System.Drawing.Point(36, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 16);
            this.labelControl3.TabIndex = 86;
            this.labelControl3.Text = "Bitiş :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Location = new System.Drawing.Point(6, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 16);
            this.labelControl2.TabIndex = 85;
            this.labelControl2.Text = "Başlagnıç :";
            // 
            // dateKayitBit
            // 
            this.dateKayitBit.EditValue = null;
            this.dateKayitBit.Location = new System.Drawing.Point(74, 68);
            this.dateKayitBit.Name = "dateKayitBit";
            this.dateKayitBit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateKayitBit.Properties.Appearance.Options.UseFont = true;
            this.dateKayitBit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKayitBit.Properties.Mask.EditMask = "g";
            this.dateKayitBit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateKayitBit.Size = new System.Drawing.Size(88, 22);
            this.dateKayitBit.TabIndex = 83;
            // 
            // dateKayitBas
            // 
            this.dateKayitBas.EditValue = null;
            this.dateKayitBas.Location = new System.Drawing.Point(74, 40);
            this.dateKayitBas.Name = "dateKayitBas";
            this.dateKayitBas.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateKayitBas.Properties.Appearance.Options.UseFont = true;
            this.dateKayitBas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateKayitBas.Properties.Mask.EditMask = "g";
            this.dateKayitBas.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateKayitBas.Size = new System.Drawing.Size(88, 22);
            this.dateKayitBas.TabIndex = 81;
            // 
            // resimModul
            // 
            this.resimModul.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.resimModul.Location = new System.Drawing.Point(32, 403);
            this.resimModul.Name = "resimModul";
            this.resimModul.Size = new System.Drawing.Size(128, 128);
            this.resimModul.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resimModul.TabIndex = 78;
            this.resimModul.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Location = new System.Drawing.Point(6, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(119, 16);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Stok Hareket Tarihi :";
            // 
            // btnYazdir1
            // 
            this.btnYazdir1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYazdir1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYazdir1.Image = ((System.Drawing.Image)(resources.GetObject("btnYazdir1.Image")));
            this.btnYazdir1.KaynakView = this.GridViewStokHareketleri;
            this.btnYazdir1.Location = new System.Drawing.Point(699, 506);
            this.btnYazdir1.Name = "btnYazdir1";
            this.btnYazdir1.Size = new System.Drawing.Size(62, 23);
            this.btnYazdir1.TabIndex = 273;
            this.btnYazdir1.Text = "Yazdır";
            // 
            // GridViewStokHareketleri
            // 
            this.GridViewStokHareketleri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colParcaNo,
            this.colKalemAdi,
            this.colStokKartID,
            this.colGirisCikis,
            this.colMiktar,
            this.colBirimFiyat,
            this.colStokHareketTipi,
            this.colPlaka,
            this.colFaturaID,
            this.colIsemirID,
            this.colServisID,
            this.colKayitZaman});
            this.GridViewStokHareketleri.GridControl = this.gridControlStokHareketleri;
            this.GridViewStokHareketleri.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.GridViewStokHareketleri.Name = "GridViewStokHareketleri";
            this.GridViewStokHareketleri.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewStokHareketleri.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewStokHareketleri.OptionsBehavior.Editable = false;
            this.GridViewStokHareketleri.OptionsBehavior.ReadOnly = true;
            this.GridViewStokHareketleri.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewStokHareketleri.OptionsView.ShowAutoFilterRow = true;
            this.GridViewStokHareketleri.OptionsView.ShowGroupPanel = false;
            this.GridViewStokHareketleri.OptionsView.ShowIndicator = false;
            this.GridViewStokHareketleri.OptionsView.ShowViewCaption = true;
            this.GridViewStokHareketleri.ViewCaption = "Stok Hareketleri";
            this.GridViewStokHareketleri.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewStokHareketleri_FocusedRowChanged);
            this.GridViewStokHareketleri.Click += new System.EventHandler(this.GridViewStokHareketleri_Click);
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colID.Caption = "H.No";
            this.colID.FieldName = "ID";
            this.colID.MaxWidth = 50;
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 46;
            // 
            // colParcaNo
            // 
            this.colParcaNo.Caption = "Parça No";
            this.colParcaNo.FieldName = "ParcaNo";
            this.colParcaNo.MaxWidth = 80;
            this.colParcaNo.MinWidth = 75;
            this.colParcaNo.Name = "colParcaNo";
            this.colParcaNo.Visible = true;
            this.colParcaNo.VisibleIndex = 1;
            // 
            // colKalemAdi
            // 
            this.colKalemAdi.Caption = "Kalem Adı";
            this.colKalemAdi.FieldName = "KalemAdi";
            this.colKalemAdi.Name = "colKalemAdi";
            this.colKalemAdi.SummaryItem.FieldName = "MarkaAdi";
            this.colKalemAdi.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            this.colKalemAdi.Visible = true;
            this.colKalemAdi.VisibleIndex = 2;
            this.colKalemAdi.Width = 114;
            // 
            // colStokKartID
            // 
            this.colStokKartID.Caption = "Kart No";
            this.colStokKartID.FieldName = "StokKartID";
            this.colStokKartID.MaxWidth = 55;
            this.colStokKartID.MinWidth = 50;
            this.colStokKartID.Name = "colStokKartID";
            this.colStokKartID.Visible = true;
            this.colStokKartID.VisibleIndex = 4;
            this.colStokKartID.Width = 55;
            // 
            // colGirisCikis
            // 
            this.colGirisCikis.Caption = "Giriş/Çıkış";
            this.colGirisCikis.FieldName = "GirisCikis";
            this.colGirisCikis.MaxWidth = 60;
            this.colGirisCikis.MinWidth = 50;
            this.colGirisCikis.Name = "colGirisCikis";
            this.colGirisCikis.Visible = true;
            this.colGirisCikis.VisibleIndex = 3;
            this.colGirisCikis.Width = 60;
            // 
            // colMiktar
            // 
            this.colMiktar.Caption = "Miktar";
            this.colMiktar.FieldName = "Miktar";
            this.colMiktar.MaxWidth = 55;
            this.colMiktar.MinWidth = 50;
            this.colMiktar.Name = "colMiktar";
            this.colMiktar.Visible = true;
            this.colMiktar.VisibleIndex = 5;
            this.colMiktar.Width = 55;
            // 
            // colBirimFiyat
            // 
            this.colBirimFiyat.Caption = "Birim Fiyat";
            this.colBirimFiyat.FieldName = "BirimFiyat";
            this.colBirimFiyat.MaxWidth = 65;
            this.colBirimFiyat.MinWidth = 60;
            this.colBirimFiyat.Name = "colBirimFiyat";
            this.colBirimFiyat.Visible = true;
            this.colBirimFiyat.VisibleIndex = 6;
            this.colBirimFiyat.Width = 60;
            // 
            // colStokHareketTipi
            // 
            this.colStokHareketTipi.Caption = "Hareket Tipi";
            this.colStokHareketTipi.FieldName = "StokHareketTipi";
            this.colStokHareketTipi.MaxWidth = 75;
            this.colStokHareketTipi.MinWidth = 65;
            this.colStokHareketTipi.Name = "colStokHareketTipi";
            this.colStokHareketTipi.Visible = true;
            this.colStokHareketTipi.VisibleIndex = 7;
            this.colStokHareketTipi.Width = 65;
            // 
            // colPlaka
            // 
            this.colPlaka.Caption = "Plaka";
            this.colPlaka.FieldName = "Plaka";
            this.colPlaka.MaxWidth = 65;
            this.colPlaka.MinWidth = 60;
            this.colPlaka.Name = "colPlaka";
            this.colPlaka.Visible = true;
            this.colPlaka.VisibleIndex = 8;
            this.colPlaka.Width = 65;
            // 
            // colFaturaID
            // 
            this.colFaturaID.Caption = "Fatura No";
            this.colFaturaID.FieldName = "FaturaID";
            this.colFaturaID.MaxWidth = 60;
            this.colFaturaID.MinWidth = 50;
            this.colFaturaID.Name = "colFaturaID";
            this.colFaturaID.Visible = true;
            this.colFaturaID.VisibleIndex = 9;
            this.colFaturaID.Width = 60;
            // 
            // colIsemirID
            // 
            this.colIsemirID.Caption = "Işemir No";
            this.colIsemirID.FieldName = "IsemirID";
            this.colIsemirID.MaxWidth = 65;
            this.colIsemirID.MinWidth = 50;
            this.colIsemirID.Name = "colIsemirID";
            this.colIsemirID.Visible = true;
            this.colIsemirID.VisibleIndex = 10;
            this.colIsemirID.Width = 65;
            // 
            // colServisID
            // 
            this.colServisID.Caption = "Servis No";
            this.colServisID.FieldName = "ServisID";
            this.colServisID.MaxWidth = 65;
            this.colServisID.MinWidth = 50;
            this.colServisID.Name = "colServisID";
            this.colServisID.Visible = true;
            this.colServisID.VisibleIndex = 11;
            this.colServisID.Width = 65;
            // 
            // colKayitZaman
            // 
            this.colKayitZaman.Caption = "Tarih";
            this.colKayitZaman.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
            this.colKayitZaman.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colKayitZaman.FieldName = "KayitZaman";
            this.colKayitZaman.MaxWidth = 100;
            this.colKayitZaman.MinWidth = 90;
            this.colKayitZaman.Name = "colKayitZaman";
            this.colKayitZaman.Visible = true;
            this.colKayitZaman.VisibleIndex = 12;
            this.colKayitZaman.Width = 90;
            // 
            // gridControlStokHareketleri
            // 
            this.gridControlStokHareketleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlStokHareketleri.Location = new System.Drawing.Point(0, 0);
            this.gridControlStokHareketleri.MainView = this.GridViewStokHareketleri;
            this.gridControlStokHareketleri.Name = "gridControlStokHareketleri";
            this.gridControlStokHareketleri.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridControlStokHareketleri.Size = new System.Drawing.Size(761, 504);
            this.gridControlStokHareketleri.TabIndex = 230;
            this.gridControlStokHareketleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewStokHareketleri});
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // ucKayitBilgi1
            // 
            this.ucKayitBilgi1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.ucKayitBilgi1.Appearance.Options.UseBackColor = true;
            this.ucKayitBilgi1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucKayitBilgi1.GostermeSekli = MaviElmasOtoSis.Sistem.ucKayitBilgi.GostermeSekilleri.Hepsi;
            this.ucKayitBilgi1.GosterSimge = true;
            this.ucKayitBilgi1.Location = new System.Drawing.Point(0, 504);
            this.ucKayitBilgi1.Name = "ucKayitBilgi1";
            this.ucKayitBilgi1.Size = new System.Drawing.Size(761, 42);
            this.ucKayitBilgi1.TabIndex = 53;
            // 
            // btnYenile
            // 
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(107, 164);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 278;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // ucStokHareket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitAna);
            this.Name = "ucStokHareket";
            this.Size = new System.Drawing.Size(937, 546);
            this.Load += new System.EventHandler(this.ucStokHareket_Load);
            this.splitAna.Panel1.ResumeLayout(false);
            this.splitAna.Panel1.PerformLayout();
            this.splitAna.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitAna)).EndInit();
            this.splitAna.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepolar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateKayitBas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resimModul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewStokHareketleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStokHareketleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitAna;
        private System.Windows.Forms.PictureBox resimModul;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Sistem.ucKayitBilgi ucKayitBilgi1;
        private DevExpress.XtraGrid.GridControl gridControlStokHareketleri;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewStokHareketleri;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colKalemAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colGirisCikis;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colStokKartID;
        private DevExpress.XtraGrid.Columns.GridColumn colStokHareketTipi;
        private DevExpress.XtraGrid.Columns.GridColumn colParcaNo;
        private DevExpress.XtraEditors.DateEdit dateKayitBit;
        private DevExpress.XtraEditors.DateEdit dateKayitBas;
        private DevExpress.XtraGrid.Columns.GridColumn colKayitZaman;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUpDepolar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn colMiktar;
        private Bilesenler.btnYazdir btnYazdir1;
        private DevExpress.XtraGrid.Columns.GridColumn colBirimFiyat;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaka;
        private DevExpress.XtraGrid.Columns.GridColumn colFaturaID;
        private DevExpress.XtraGrid.Columns.GridColumn colIsemirID;
        private DevExpress.XtraGrid.Columns.GridColumn colServisID;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
    }
}
