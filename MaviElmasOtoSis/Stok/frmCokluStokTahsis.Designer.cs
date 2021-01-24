namespace MaviElmasOtoSis.Stok
{
    partial class frmCokluStokTahsis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCokluStokTahsis));
            this.gridControlParcalar = new DevExpress.XtraGrid.GridControl();
            this.GridViewParcalar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colParcaNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reGridLookStokKartlari = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.GridViewStokKart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKartID2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKalemAdi2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParcaNo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarkodNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokBirim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKalemAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reSpinMiktar = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colDepoAd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reLookUpDepo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colKartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAracID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.reGridLookAraclar = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.GridViewAraclar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAracID2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlaka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuhsatSahibi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnIptal = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.btnKaydet = new MaviElmasOtoSis.Bilesenler.MaviButon();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioGiris = new DevExpress.XtraEditors.RadioGroup();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.memoAciklama = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlParcalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewParcalar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reGridLookStokKartlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewStokKart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reSpinMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reLookUpDepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reGridLookAraclar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAraclar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGiris.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlParcalar
            // 
            this.gridControlParcalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlParcalar.Location = new System.Drawing.Point(3, 1);
            this.gridControlParcalar.MainView = this.GridViewParcalar;
            this.gridControlParcalar.Name = "gridControlParcalar";
            this.gridControlParcalar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reSpinMiktar,
            this.reLookUpDepo,
            this.reGridLookStokKartlari,
            this.reGridLookAraclar});
            this.gridControlParcalar.Size = new System.Drawing.Size(718, 258);
            this.gridControlParcalar.TabIndex = 305;
            this.gridControlParcalar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridViewParcalar});
            // 
            // GridViewParcalar
            // 
            this.GridViewParcalar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colParcaNo,
            this.colKalemAdi,
            this.colMiktar,
            this.colDepoAd,
            this.colKartID,
            this.colAracID});
            this.GridViewParcalar.GridControl = this.gridControlParcalar;
            this.GridViewParcalar.Name = "GridViewParcalar";
            this.GridViewParcalar.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.GridViewParcalar.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.GridViewParcalar.OptionsView.ShowGroupPanel = false;
            this.GridViewParcalar.OptionsView.ShowViewCaption = true;
            this.GridViewParcalar.ViewCaption = "Parça ve İşçilikler Listesi";
            this.GridViewParcalar.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GridViewParcalar_CellValueChanging);
            this.GridViewParcalar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GridViewParcalar_KeyUp);
            // 
            // colParcaNo
            // 
            this.colParcaNo.Caption = "Parça/Ref. No";
            this.colParcaNo.ColumnEdit = this.reGridLookStokKartlari;
            this.colParcaNo.FieldName = "ParcaNo";
            this.colParcaNo.MaxWidth = 100;
            this.colParcaNo.MinWidth = 90;
            this.colParcaNo.Name = "colParcaNo";
            this.colParcaNo.Visible = true;
            this.colParcaNo.VisibleIndex = 0;
            this.colParcaNo.Width = 100;
            // 
            // reGridLookStokKartlari
            // 
            this.reGridLookStokKartlari.AutoHeight = false;
            this.reGridLookStokKartlari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reGridLookStokKartlari.Name = "reGridLookStokKartlari";
            this.reGridLookStokKartlari.NullText = "";
            this.reGridLookStokKartlari.PopupFormMinSize = new System.Drawing.Size(893, 261);
            this.reGridLookStokKartlari.PopupFormSize = new System.Drawing.Size(893, 261);
            this.reGridLookStokKartlari.View = this.GridViewStokKart;
            this.reGridLookStokKartlari.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView;
            // 
            // GridViewStokKart
            // 
            this.GridViewStokKart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKartID2,
            this.colKalemAdi2,
            this.colParcaNo2,
            this.colStokMiktar,
            this.colBarkodNo,
            this.colStokBirim});
            this.GridViewStokKart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridViewStokKart.Name = "GridViewStokKart";
            this.GridViewStokKart.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewStokKart.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewStokKart.OptionsBehavior.Editable = false;
            this.GridViewStokKart.OptionsBehavior.ReadOnly = true;
            this.GridViewStokKart.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewStokKart.OptionsView.ShowAutoFilterRow = true;
            this.GridViewStokKart.OptionsView.ShowGroupPanel = false;
            this.GridViewStokKart.OptionsView.ShowViewCaption = true;
            this.GridViewStokKart.ViewCaption = "Stok Kartları";
            // 
            // colKartID2
            // 
            this.colKartID2.AppearanceCell.Options.UseTextOptions = true;
            this.colKartID2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKartID2.Caption = "Kart No";
            this.colKartID2.FieldName = "KartID";
            this.colKartID2.MaxWidth = 50;
            this.colKartID2.Name = "colKartID2";
            this.colKartID2.Visible = true;
            this.colKartID2.VisibleIndex = 0;
            this.colKartID2.Width = 50;
            // 
            // colKalemAdi2
            // 
            this.colKalemAdi2.Caption = "Kalem Adı";
            this.colKalemAdi2.FieldName = "KalemAdi";
            this.colKalemAdi2.Name = "colKalemAdi2";
            this.colKalemAdi2.Visible = true;
            this.colKalemAdi2.VisibleIndex = 1;
            this.colKalemAdi2.Width = 124;
            // 
            // colParcaNo2
            // 
            this.colParcaNo2.Caption = "Parça No";
            this.colParcaNo2.FieldName = "ParcaNo";
            this.colParcaNo2.Name = "colParcaNo2";
            this.colParcaNo2.Visible = true;
            this.colParcaNo2.VisibleIndex = 2;
            this.colParcaNo2.Width = 124;
            // 
            // colStokMiktar
            // 
            this.colStokMiktar.Caption = "Stok Miktarı";
            this.colStokMiktar.FieldName = "StokMiktar";
            this.colStokMiktar.MaxWidth = 75;
            this.colStokMiktar.MinWidth = 75;
            this.colStokMiktar.Name = "colStokMiktar";
            this.colStokMiktar.Visible = true;
            this.colStokMiktar.VisibleIndex = 3;
            // 
            // colBarkodNo
            // 
            this.colBarkodNo.Caption = "Barkod No";
            this.colBarkodNo.FieldName = "BarkodNo";
            this.colBarkodNo.Name = "colBarkodNo";
            // 
            // colStokBirim
            // 
            this.colStokBirim.Caption = "Stok Birimi";
            this.colStokBirim.FieldName = "StokBirim";
            this.colStokBirim.Name = "colStokBirim";
            this.colStokBirim.Visible = true;
            this.colStokBirim.VisibleIndex = 4;
            // 
            // colKalemAdi
            // 
            this.colKalemAdi.Caption = "Kalem Adı";
            this.colKalemAdi.FieldName = "KalemAdi";
            this.colKalemAdi.MinWidth = 110;
            this.colKalemAdi.Name = "colKalemAdi";
            this.colKalemAdi.OptionsColumn.AllowEdit = false;
            this.colKalemAdi.OptionsColumn.ReadOnly = true;
            this.colKalemAdi.Visible = true;
            this.colKalemAdi.VisibleIndex = 1;
            this.colKalemAdi.Width = 334;
            // 
            // colMiktar
            // 
            this.colMiktar.Caption = "Miktar";
            this.colMiktar.ColumnEdit = this.reSpinMiktar;
            this.colMiktar.FieldName = "Miktar";
            this.colMiktar.MaxWidth = 100;
            this.colMiktar.MinWidth = 90;
            this.colMiktar.Name = "colMiktar";
            this.colMiktar.Visible = true;
            this.colMiktar.VisibleIndex = 2;
            this.colMiktar.Width = 100;
            // 
            // reSpinMiktar
            // 
            this.reSpinMiktar.AutoHeight = false;
            this.reSpinMiktar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.reSpinMiktar.DisplayFormat.FormatString = "d";
            this.reSpinMiktar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.reSpinMiktar.EditFormat.FormatString = "d";
            this.reSpinMiktar.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.reSpinMiktar.Name = "reSpinMiktar";
            // 
            // colDepoAd
            // 
            this.colDepoAd.Caption = "Depo Adı";
            this.colDepoAd.ColumnEdit = this.reLookUpDepo;
            this.colDepoAd.FieldName = "DepoID";
            this.colDepoAd.MaxWidth = 110;
            this.colDepoAd.MinWidth = 100;
            this.colDepoAd.Name = "colDepoAd";
            this.colDepoAd.Visible = true;
            this.colDepoAd.VisibleIndex = 3;
            this.colDepoAd.Width = 110;
            // 
            // reLookUpDepo
            // 
            this.reLookUpDepo.AutoHeight = false;
            this.reLookUpDepo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reLookUpDepo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepoID", "Depo No"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepoAd", "Depo Adı")});
            this.reLookUpDepo.Name = "reLookUpDepo";
            // 
            // colKartID
            // 
            this.colKartID.Caption = "KartID";
            this.colKartID.FieldName = "KartID";
            this.colKartID.Name = "colKartID";
            // 
            // colAracID
            // 
            this.colAracID.Caption = "Araç";
            this.colAracID.ColumnEdit = this.reGridLookAraclar;
            this.colAracID.FieldName = "AracID";
            this.colAracID.MaxWidth = 100;
            this.colAracID.MinWidth = 95;
            this.colAracID.Name = "colAracID";
            this.colAracID.Visible = true;
            this.colAracID.VisibleIndex = 4;
            this.colAracID.Width = 95;
            // 
            // reGridLookAraclar
            // 
            this.reGridLookAraclar.AutoHeight = false;
            this.reGridLookAraclar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.reGridLookAraclar.Name = "reGridLookAraclar";
            this.reGridLookAraclar.View = this.GridViewAraclar;
            this.reGridLookAraclar.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView;
            // 
            // GridViewAraclar
            // 
            this.GridViewAraclar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAracID2,
            this.colPlaka,
            this.colRuhsatSahibi,
            this.colSaseNo,
            this.colMarka,
            this.colModel});
            this.GridViewAraclar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridViewAraclar.Name = "GridViewAraclar";
            this.GridViewAraclar.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewAraclar.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.GridViewAraclar.OptionsBehavior.Editable = false;
            this.GridViewAraclar.OptionsBehavior.ReadOnly = true;
            this.GridViewAraclar.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridViewAraclar.OptionsView.ShowAutoFilterRow = true;
            this.GridViewAraclar.OptionsView.ShowGroupPanel = false;
            this.GridViewAraclar.OptionsView.ShowViewCaption = true;
            this.GridViewAraclar.ViewCaption = "Araçlar";
            // 
            // colAracID2
            // 
            this.colAracID2.AppearanceCell.Options.UseTextOptions = true;
            this.colAracID2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAracID2.Caption = "Araç No";
            this.colAracID2.FieldName = "AracID";
            this.colAracID2.MaxWidth = 50;
            this.colAracID2.Name = "colAracID2";
            this.colAracID2.Visible = true;
            this.colAracID2.VisibleIndex = 0;
            this.colAracID2.Width = 50;
            // 
            // colPlaka
            // 
            this.colPlaka.Caption = "Plaka";
            this.colPlaka.FieldName = "Plaka";
            this.colPlaka.Name = "colPlaka";
            this.colPlaka.Visible = true;
            this.colPlaka.VisibleIndex = 1;
            this.colPlaka.Width = 68;
            // 
            // colRuhsatSahibi
            // 
            this.colRuhsatSahibi.Caption = "Ruhsat Sahibi";
            this.colRuhsatSahibi.FieldName = "RuhsatSahibi";
            this.colRuhsatSahibi.Name = "colRuhsatSahibi";
            this.colRuhsatSahibi.Visible = true;
            this.colRuhsatSahibi.VisibleIndex = 2;
            this.colRuhsatSahibi.Width = 185;
            // 
            // colSaseNo
            // 
            this.colSaseNo.Caption = "Şase No";
            this.colSaseNo.FieldName = "SaseNo";
            this.colSaseNo.Name = "colSaseNo";
            this.colSaseNo.Visible = true;
            this.colSaseNo.VisibleIndex = 3;
            this.colSaseNo.Width = 156;
            // 
            // colMarka
            // 
            this.colMarka.Caption = "Marka";
            this.colMarka.FieldName = "MarkaAdi";
            this.colMarka.Name = "colMarka";
            this.colMarka.Visible = true;
            this.colMarka.VisibleIndex = 4;
            this.colMarka.Width = 93;
            // 
            // colModel
            // 
            this.colModel.Caption = "Model";
            this.colModel.FieldName = "ModelAdi";
            this.colModel.Name = "colModel";
            this.colModel.Visible = true;
            this.colModel.VisibleIndex = 5;
            this.colModel.Width = 131;
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIptal.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Cikis;
            this.btnIptal.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Image = ((System.Drawing.Image)(resources.GetObject("btnIptal.Image")));
            this.btnIptal.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnIptal.Location = new System.Drawing.Point(540, 308);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(80, 25);
            this.btnIptal.TabIndex = 307;
            this.btnIptal.Text = "maviButon1";
            this.btnIptal.ToolTip = "Esc - İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKaydet.ButonCesidi = MaviElmasOtoSis.Bilesenler.MaviButon.ButonCesitleri.Kaydet;
            this.btnKaydet.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnKaydet.Location = new System.Drawing.Point(626, 308);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(92, 25);
            this.btnKaydet.TabIndex = 306;
            this.btnKaydet.Text = "maviButon1";
            this.btnKaydet.ToolTip = "F2 - Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Location = new System.Drawing.Point(478, 273);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 16);
            this.labelControl2.TabIndex = 309;
            this.labelControl2.Text = "*İşlem Yönü :";
            // 
            // radioGiris
            // 
            this.radioGiris.Location = new System.Drawing.Point(562, 267);
            this.radioGiris.Name = "radioGiris";
            this.radioGiris.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Giriş"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Çıkış")});
            this.radioGiris.Size = new System.Drawing.Size(159, 25);
            this.radioGiris.TabIndex = 308;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnYenile.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.btnYenile.Appearance.Options.UseFont = true;
            this.btnYenile.Image = global::MaviElmasOtoSis.ResOtoSis.refresh;
            this.btnYenile.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYenile.Location = new System.Drawing.Point(3, 319);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(60, 16);
            this.btnYenile.TabIndex = 347;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Location = new System.Drawing.Point(3, 267);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(62, 16);
            this.labelControl9.TabIndex = 349;
            this.labelControl9.Text = "Açıklama :";
            // 
            // memoAciklama
            // 
            this.memoAciklama.Location = new System.Drawing.Point(78, 265);
            this.memoAciklama.Name = "memoAciklama";
            this.memoAciklama.Properties.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.memoAciklama.Properties.Appearance.Options.UseFont = true;
            this.memoAciklama.Properties.MaxLength = 150;
            this.memoAciklama.Size = new System.Drawing.Size(215, 70);
            this.memoAciklama.TabIndex = 348;
            // 
            // frmCokluStokTahsis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 339);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.memoAciklama);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.radioGiris);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.gridControlParcalar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCokluStokTahsis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCokluStokTahsis";
            this.Load += new System.EventHandler(this.frmCokluStokTahsis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlParcalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewParcalar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reGridLookStokKartlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewStokKart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reSpinMiktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reLookUpDepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reGridLookAraclar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAraclar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGiris.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlParcalar;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewParcalar;
        private DevExpress.XtraGrid.Columns.GridColumn colParcaNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit reGridLookStokKartlari;
        private DevExpress.XtraGrid.Columns.GridColumn colKalemAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colMiktar;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit reSpinMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colDepoAd;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit reLookUpDepo;
        private DevExpress.XtraGrid.Columns.GridColumn colKartID;
        private DevExpress.XtraGrid.Columns.GridColumn colAracID;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit reGridLookAraclar;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewAraclar;
        private DevExpress.XtraGrid.Columns.GridColumn colAracID2;
        private DevExpress.XtraGrid.Columns.GridColumn colPlaka;
        private DevExpress.XtraGrid.Columns.GridColumn colRuhsatSahibi;
        private DevExpress.XtraGrid.Columns.GridColumn colSaseNo;
        private DevExpress.XtraGrid.Columns.GridColumn colMarka;
        private DevExpress.XtraGrid.Columns.GridColumn colModel;
        private Bilesenler.MaviButon btnIptal;
        private Bilesenler.MaviButon btnKaydet;
        private DevExpress.XtraGrid.Views.Grid.GridView GridViewStokKart;
        private DevExpress.XtraGrid.Columns.GridColumn colKartID2;
        private DevExpress.XtraGrid.Columns.GridColumn colKalemAdi2;
        private DevExpress.XtraGrid.Columns.GridColumn colParcaNo2;
        private DevExpress.XtraGrid.Columns.GridColumn colStokMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colBarkodNo;
        private DevExpress.XtraGrid.Columns.GridColumn colStokBirim;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup radioGiris;
        private DevExpress.XtraEditors.SimpleButton btnYenile;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit memoAciklama;
    }
}