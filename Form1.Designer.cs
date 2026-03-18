namespace PlexReportII.Sample.GUI;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        titleLabel = new Label();
        descLabel = new Label();
        marginGroup = new GroupBox();
        marginHLabel = new Label();
        _marginHorizontalInput = new NumericUpDown();
        marginHUnit = new Label();
        marginVLabel = new Label();
        _marginVerticalInput = new NumericUpDown();
        marginVUnit = new Label();
        resetButton = new Button();
        _allowCopyContentCheck = new CheckBox();
        headerFooterGroup = new GroupBox();
        showHeaderCheck = new CheckBox();
        showFooterCheck = new CheckBox();
        showPageNumberCheck = new CheckBox();
        headerTitleLabel = new Label();
        headerTitleInput = new TextBox();
        loadLogoButton = new Button();
        removeLogoButton = new Button();
        softwareNameLabel = new Label();
        softwareNameInput = new TextBox();
        versionLabel = new Label();
        versionInput = new TextBox();
        operatorLabel = new Label();
        operatorInput = new TextBox();
        ruoCheck = new CheckBox();
        flagNoteLabel = new Label();
        loadFlagNoteCsvButton = new Button();
        addSupplementalTextCheck = new CheckBox();
        addAboveFooterCheck = new CheckBox();
        flagNoteHeightLabel = new Label();
        flagNoteSpacingLabel = new Label();
        _flagNoteSpacingCombo = new ComboBox();
        supplementalTextLabel = new Label();
        supplementalTextInput = new TextBox();
        createPdfButton = new Button();
        exportPdfButton = new Button();
        openFolderButton = new Button();
        clearPdfButton = new Button();
        statusList = new ListBox();
        contentEditGroup = new GroupBox();
        _panelIndvResultTable = new Panel();
        drawIndvResultButton = new Button();
        loadIndvResultCsvButton = new Button();
        indvResultLabel = new Label();
        _panelSampleControlTable = new Panel();
        drawSampleControlButton = new Button();
        loadSampleControlCsvButton = new Button();
        sampleControlLabel = new Label();
        _panelWellInfo = new Panel();
        drawWellInfoButton = new Button();
        loadWellInfoCsvButton = new Button();
        wellInfoLabel = new Label();
        _panelSummaryTable = new Panel();
        drawSummaryTableButton = new Button();
        loadSummaryDataCsvButton = new Button();
        summaryTableLabel = new Label();
        _panelSignature = new Panel();
        drawSignatureButton = new Button();
        signatureLabel = new Label();
        _panelPcncDetailTable = new Panel();
        drawPcncDetailButton = new Button();
        loadPcncDetailCsvButton = new Button();
        pcncDetailTableLabel = new Label();
        _panelPcncTable = new Panel();
        drawPcncTableButton = new Button();
        loadPcncTableCsvButton = new Button();
        pcncTableLabel = new Label();
        _panelPcncNote = new Panel();
        drawPcncButton = new Button();
        loadPcncCsvButton = new Button();
        pcncLabel = new Label();
        _panelMultiColor = new Panel();
        drawMultiColorButton = new Button();
        linkTargetCheck = new CheckBox();
        outlineCheck = new CheckBox();
        _multiColorInput = new TextBox();
        multiColorLabel = new Label();
        _panelSpacing = new Panel();
        drawSpacingButton = new Button();
        _spacingHeightCombo = new ComboBox();
        spacingLabel2 = new Label();
        spacingLabel1 = new Label();
        _panelPageBreak = new Panel();
        pageBreakButton = new Button();
        pageBreakLabel = new Label();
        _panelLine = new Panel();
        drawLineButton = new Button();
        _lineSpacingAfterInput = new NumericUpDown();
        spaceLabel = new Label();
        _lineThicknessInput = new NumericUpDown();
        thickLabel = new Label();
        _lineLengthInput = new NumericUpDown();
        lenLabel = new Label();
        _lineStartXInput = new NumericUpDown();
        xLabel = new Label();
        _lineColorCombo = new ComboBox();
        lineLabel = new Label();
        _panelKitInfo = new Panel();
        drawKitInfoButton = new Button();
        _tableStyleCombo = new ComboBox();
        _renderMethodCombo = new ComboBox();
        loadCsvButton = new Button();
        kitInfoLabel = new Label();
        _editModeCombo = new ComboBox();
        editModeLabel = new Label();
        _pdfPreviewGroup = new GroupBox();
        _flexViewer = new C1.Win.FlexViewer.C1FlexViewer();
        _positionInfoLabel = new TextBox();
        marginGroup.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_marginHorizontalInput).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_marginVerticalInput).BeginInit();
        headerFooterGroup.SuspendLayout();
        contentEditGroup.SuspendLayout();
        _panelIndvResultTable.SuspendLayout();
        _panelSampleControlTable.SuspendLayout();
        _panelWellInfo.SuspendLayout();
        _panelSummaryTable.SuspendLayout();
        _panelSignature.SuspendLayout();
        _panelPcncDetailTable.SuspendLayout();
        _panelPcncTable.SuspendLayout();
        _panelPcncNote.SuspendLayout();
        _panelMultiColor.SuspendLayout();
        _panelSpacing.SuspendLayout();
        _panelPageBreak.SuspendLayout();
        _panelLine.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_lineSpacingAfterInput).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_lineThicknessInput).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_lineLengthInput).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_lineStartXInput).BeginInit();
        _panelKitInfo.SuspendLayout();
        _pdfPreviewGroup.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_flexViewer).BeginInit();
        SuspendLayout();
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Bold);
        titleLabel.Location = new Point(20, 20);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(265, 24);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "PlexReportII PDF 報表產生器";
        // 
        // descLabel
        // 
        descLabel.AutoSize = true;
        descLabel.Font = new Font("Microsoft JhengHei UI", 10F);
        descLabel.Location = new Point(20, 55);
        descLabel.Name = "descLabel";
        descLabel.Size = new Size(210, 18);
        descLabel.TabIndex = 1;
        descLabel.Text = "點擊下方按鈕產生範例 PDF 報表";
        // 
        // marginGroup
        // 
        marginGroup.Controls.Add(marginHLabel);
        marginGroup.Controls.Add(_marginHorizontalInput);
        marginGroup.Controls.Add(marginHUnit);
        marginGroup.Controls.Add(marginVLabel);
        marginGroup.Controls.Add(_marginVerticalInput);
        marginGroup.Controls.Add(marginVUnit);
        marginGroup.Controls.Add(resetButton);
        marginGroup.Controls.Add(_allowCopyContentCheck);
        marginGroup.Font = new Font("Microsoft JhengHei UI", 10F);
        marginGroup.Location = new Point(20, 85);
        marginGroup.Name = "marginGroup";
        marginGroup.Size = new Size(600, 95);
        marginGroup.TabIndex = 2;
        marginGroup.TabStop = false;
        marginGroup.Text = "頁面設定";
        // 
        // marginHLabel
        // 
        marginHLabel.AutoSize = true;
        marginHLabel.Location = new Point(15, 25);
        marginHLabel.Name = "marginHLabel";
        marginHLabel.Size = new Size(67, 18);
        marginHLabel.TabIndex = 0;
        marginHLabel.Text = "左右邊界:";
        // 
        // _marginHorizontalInput
        // 
        _marginHorizontalInput.DecimalPlaces = 1;
        _marginHorizontalInput.Location = new Point(90, 22);
        _marginHorizontalInput.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
        _marginHorizontalInput.Name = "_marginHorizontalInput";
        _marginHorizontalInput.Size = new Size(70, 24);
        _marginHorizontalInput.TabIndex = 1;
        _marginHorizontalInput.Value = new decimal(new int[] { 30, 0, 0, 0 });
        _marginHorizontalInput.ValueChanged += MarginInput_ValueChanged;
        // 
        // marginHUnit
        // 
        marginHUnit.AutoSize = true;
        marginHUnit.Location = new Point(162, 25);
        marginHUnit.Name = "marginHUnit";
        marginHUnit.Size = new Size(22, 18);
        marginHUnit.TabIndex = 2;
        marginHUnit.Text = "pt";
        // 
        // marginVLabel
        // 
        marginVLabel.AutoSize = true;
        marginVLabel.Location = new Point(210, 25);
        marginVLabel.Name = "marginVLabel";
        marginVLabel.Size = new Size(67, 18);
        marginVLabel.TabIndex = 3;
        marginVLabel.Text = "上下邊界:";
        // 
        // _marginVerticalInput
        // 
        _marginVerticalInput.DecimalPlaces = 1;
        _marginVerticalInput.Location = new Point(285, 22);
        _marginVerticalInput.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
        _marginVerticalInput.Name = "_marginVerticalInput";
        _marginVerticalInput.Size = new Size(70, 24);
        _marginVerticalInput.TabIndex = 4;
        _marginVerticalInput.Value = new decimal(new int[] { 60, 0, 0, 0 });
        _marginVerticalInput.ValueChanged += MarginInput_ValueChanged;
        // 
        // marginVUnit
        // 
        marginVUnit.AutoSize = true;
        marginVUnit.Location = new Point(357, 25);
        marginVUnit.Name = "marginVUnit";
        marginVUnit.Size = new Size(22, 18);
        marginVUnit.TabIndex = 5;
        marginVUnit.Text = "pt";
        // 
        // resetButton
        // 
        resetButton.Location = new Point(385, 21);
        resetButton.Name = "resetButton";
        resetButton.Size = new Size(45, 25);
        resetButton.TabIndex = 6;
        resetButton.Text = "重設";
        resetButton.UseVisualStyleBackColor = true;
        resetButton.Click += ResetMargins_Click;
        // 
        // _allowCopyContentCheck
        // 
        _allowCopyContentCheck.AutoSize = true;
        _allowCopyContentCheck.Location = new Point(15, 60);
        _allowCopyContentCheck.Name = "_allowCopyContentCheck";
        _allowCopyContentCheck.Size = new Size(137, 22);
        _allowCopyContentCheck.TabIndex = 7;
        _allowCopyContentCheck.Text = "允許複製PDF內容";
        _allowCopyContentCheck.UseVisualStyleBackColor = true;
        // 
        // headerFooterGroup
        // 
        headerFooterGroup.Controls.Add(showHeaderCheck);
        headerFooterGroup.Controls.Add(showFooterCheck);
        headerFooterGroup.Controls.Add(showPageNumberCheck);
        headerFooterGroup.Controls.Add(headerTitleLabel);
        headerFooterGroup.Controls.Add(headerTitleInput);
        headerFooterGroup.Controls.Add(loadLogoButton);
        headerFooterGroup.Controls.Add(removeLogoButton);
        headerFooterGroup.Controls.Add(softwareNameLabel);
        headerFooterGroup.Controls.Add(softwareNameInput);
        headerFooterGroup.Controls.Add(versionLabel);
        headerFooterGroup.Controls.Add(versionInput);
        headerFooterGroup.Controls.Add(operatorLabel);
        headerFooterGroup.Controls.Add(operatorInput);
        headerFooterGroup.Controls.Add(ruoCheck);
        headerFooterGroup.Controls.Add(flagNoteLabel);
        headerFooterGroup.Controls.Add(loadFlagNoteCsvButton);
        headerFooterGroup.Controls.Add(addSupplementalTextCheck);
        headerFooterGroup.Controls.Add(addAboveFooterCheck);
        headerFooterGroup.Controls.Add(flagNoteHeightLabel);
        headerFooterGroup.Controls.Add(flagNoteSpacingLabel);
        headerFooterGroup.Controls.Add(_flagNoteSpacingCombo);
        headerFooterGroup.Controls.Add(supplementalTextLabel);
        headerFooterGroup.Controls.Add(supplementalTextInput);
        headerFooterGroup.Font = new Font("Microsoft JhengHei UI", 10F);
        headerFooterGroup.Location = new Point(20, 190);
        headerFooterGroup.Name = "headerFooterGroup";
        headerFooterGroup.Size = new Size(770, 180);
        headerFooterGroup.TabIndex = 3;
        headerFooterGroup.TabStop = false;
        headerFooterGroup.Text = "Header / Footer 設定";
        // 
        // showHeaderCheck
        // 
        showHeaderCheck.AutoSize = true;
        showHeaderCheck.Checked = true;
        showHeaderCheck.CheckState = CheckState.Checked;
        showHeaderCheck.Location = new Point(15, 25);
        showHeaderCheck.Name = "showHeaderCheck";
        showHeaderCheck.Size = new Size(108, 22);
        showHeaderCheck.TabIndex = 0;
        showHeaderCheck.Text = "顯示 Header";
        showHeaderCheck.UseVisualStyleBackColor = true;
        showHeaderCheck.CheckedChanged += HeaderFooterSetting_Changed;
        // 
        // showFooterCheck
        // 
        showFooterCheck.AutoSize = true;
        showFooterCheck.Checked = true;
        showFooterCheck.CheckState = CheckState.Checked;
        showFooterCheck.Location = new Point(130, 25);
        showFooterCheck.Name = "showFooterCheck";
        showFooterCheck.Size = new Size(102, 22);
        showFooterCheck.TabIndex = 1;
        showFooterCheck.Text = "顯示 Footer";
        showFooterCheck.UseVisualStyleBackColor = true;
        showFooterCheck.CheckedChanged += HeaderFooterSetting_Changed;
        // 
        // showPageNumberCheck
        // 
        showPageNumberCheck.AutoSize = true;
        showPageNumberCheck.Checked = true;
        showPageNumberCheck.CheckState = CheckState.Checked;
        showPageNumberCheck.Location = new Point(250, 25);
        showPageNumberCheck.Name = "showPageNumberCheck";
        showPageNumberCheck.Size = new Size(83, 22);
        showPageNumberCheck.TabIndex = 2;
        showPageNumberCheck.Text = "顯示頁碼";
        showPageNumberCheck.UseVisualStyleBackColor = true;
        showPageNumberCheck.CheckedChanged += HeaderFooterSetting_Changed;
        // 
        // headerTitleLabel
        // 
        headerTitleLabel.AutoSize = true;
        headerTitleLabel.Font = new Font("Microsoft JhengHei UI", 9F);
        headerTitleLabel.Location = new Point(15, 55);
        headerTitleLabel.Name = "headerTitleLabel";
        headerTitleLabel.Size = new Size(79, 15);
        headerTitleLabel.TabIndex = 3;
        headerTitleLabel.Text = "Header 標題:";
        // 
        // headerTitleInput
        // 
        headerTitleInput.Font = new Font("Microsoft JhengHei UI", 9F);
        headerTitleInput.Location = new Point(100, 52);
        headerTitleInput.Name = "headerTitleInput";
        headerTitleInput.Size = new Size(200, 23);
        headerTitleInput.TabIndex = 4;
        headerTitleInput.Text = "IntelliPlex™ EGFR Mutation cfDNA Kit";
        headerTitleInput.Enter += HeaderFooterSetting_Enter;
        headerTitleInput.Leave += HeaderFooterSetting_Changed;
        // 
        // loadLogoButton
        // 
        loadLogoButton.Location = new Point(320, 50);
        loadLogoButton.Name = "loadLogoButton";
        loadLogoButton.Size = new Size(100, 27);
        loadLogoButton.TabIndex = 5;
        loadLogoButton.Text = "載入 Logo...";
        loadLogoButton.UseVisualStyleBackColor = true;
        loadLogoButton.Click += LoadLogoButton_Click;
        // 
        // removeLogoButton
        // 
        removeLogoButton.Location = new Point(425, 50);
        removeLogoButton.Name = "removeLogoButton";
        removeLogoButton.Size = new Size(100, 27);
        removeLogoButton.TabIndex = 6;
        removeLogoButton.Text = "移除 Logo";
        removeLogoButton.UseVisualStyleBackColor = true;
        removeLogoButton.Click += RemoveLogoButton_Click;
        // 
        // softwareNameLabel
        // 
        softwareNameLabel.AutoSize = true;
        softwareNameLabel.Font = new Font("Microsoft JhengHei UI", 9F);
        softwareNameLabel.Location = new Point(15, 85);
        softwareNameLabel.Name = "softwareNameLabel";
        softwareNameLabel.Size = new Size(58, 15);
        softwareNameLabel.TabIndex = 100;
        softwareNameLabel.Text = "軟體名稱:";
        // 
        // softwareNameInput
        // 
        softwareNameInput.Font = new Font("Microsoft JhengHei UI", 9F);
        softwareNameInput.Location = new Point(80, 82);
        softwareNameInput.Name = "softwareNameInput";
        softwareNameInput.Size = new Size(100, 23);
        softwareNameInput.TabIndex = 101;
        softwareNameInput.Text = "DeXipher™";
        softwareNameInput.Enter += HeaderFooterSetting_Enter;
        softwareNameInput.Leave += HeaderFooterSetting_Changed;
        // 
        // versionLabel
        // 
        versionLabel.AutoSize = true;
        versionLabel.Font = new Font("Microsoft JhengHei UI", 9F);
        versionLabel.Location = new Point(190, 85);
        versionLabel.Name = "versionLabel";
        versionLabel.Size = new Size(58, 15);
        versionLabel.TabIndex = 6;
        versionLabel.Text = "版本資訊:";
        // 
        // versionInput
        // 
        versionInput.Font = new Font("Microsoft JhengHei UI", 9F);
        versionInput.Location = new Point(255, 82);
        versionInput.Name = "versionInput";
        versionInput.Size = new Size(80, 23);
        versionInput.TabIndex = 7;
        versionInput.Text = "1.0.0.3643";
        versionInput.Enter += HeaderFooterSetting_Enter;
        versionInput.Leave += HeaderFooterSetting_Changed;
        // 
        // operatorLabel
        // 
        operatorLabel.AutoSize = true;
        operatorLabel.Font = new Font("Microsoft JhengHei UI", 9F);
        operatorLabel.Location = new Point(345, 85);
        operatorLabel.Name = "operatorLabel";
        operatorLabel.Size = new Size(46, 15);
        operatorLabel.TabIndex = 8;
        operatorLabel.Text = "操作者:";
        // 
        // operatorInput
        // 
        operatorInput.Font = new Font("Microsoft JhengHei UI", 9F);
        operatorInput.Location = new Point(395, 82);
        operatorInput.Name = "operatorInput";
        operatorInput.Size = new Size(80, 23);
        operatorInput.TabIndex = 9;
        operatorInput.Text = "William";
        operatorInput.Enter += HeaderFooterSetting_Enter;
        operatorInput.Leave += HeaderFooterSetting_Changed;
        // 
        // ruoCheck
        // 
        ruoCheck.AutoSize = true;
        ruoCheck.Font = new Font("Microsoft JhengHei UI", 9F);
        ruoCheck.Location = new Point(485, 84);
        ruoCheck.Name = "ruoCheck";
        ruoCheck.Size = new Size(130, 19);
        ruoCheck.TabIndex = 10;
        ruoCheck.Text = "Research Use Only";
        ruoCheck.UseVisualStyleBackColor = true;
        ruoCheck.CheckedChanged += HeaderFooterSetting_Changed;
        // 
        // flagNoteLabel
        // 
        flagNoteLabel.AutoSize = true;
        flagNoteLabel.Font = new Font("Microsoft JhengHei UI", 9F);
        flagNoteLabel.Location = new Point(15, 120);
        flagNoteLabel.Name = "flagNoteLabel";
        flagNoteLabel.Size = new Size(93, 15);
        flagNoteLabel.TabIndex = 11;
        flagNoteLabel.Text = "插入 Flag Note:";
        // 
        // loadFlagNoteCsvButton
        // 
        loadFlagNoteCsvButton.Font = new Font("Microsoft JhengHei UI", 9F);
        loadFlagNoteCsvButton.Location = new Point(110, 115);
        loadFlagNoteCsvButton.Name = "loadFlagNoteCsvButton";
        loadFlagNoteCsvButton.Size = new Size(80, 25);
        loadFlagNoteCsvButton.TabIndex = 12;
        loadFlagNoteCsvButton.Text = "載入 CSV";
        loadFlagNoteCsvButton.UseVisualStyleBackColor = true;
        loadFlagNoteCsvButton.Click += LoadFlagNoteCsvButton_Click;
        // 
        // addSupplementalTextCheck
        // 
        addSupplementalTextCheck.AutoSize = true;
        addSupplementalTextCheck.Font = new Font("Microsoft JhengHei UI", 9F);
        addSupplementalTextCheck.Location = new Point(200, 118);
        addSupplementalTextCheck.Name = "addSupplementalTextCheck";
        addSupplementalTextCheck.Size = new Size(187, 19);
        addSupplementalTextCheck.TabIndex = 13;
        addSupplementalTextCheck.Text = "是否增加Note上方的補充文字";
        addSupplementalTextCheck.UseVisualStyleBackColor = true;
        addSupplementalTextCheck.CheckedChanged += AddSupplementalTextCheck_CheckedChanged;
        // 
        // addAboveFooterCheck
        // 
        addAboveFooterCheck.AutoSize = true;
        addAboveFooterCheck.Font = new Font("Microsoft JhengHei UI", 9F);
        addAboveFooterCheck.Location = new Point(390, 118);
        addAboveFooterCheck.Name = "addAboveFooterCheck";
        addAboveFooterCheck.Size = new Size(183, 19);
        addAboveFooterCheck.TabIndex = 14;
        addAboveFooterCheck.Text = "是否添加到Footer的內容上方";
        addAboveFooterCheck.UseVisualStyleBackColor = true;
        addAboveFooterCheck.CheckedChanged += AddAboveFooterCheck_CheckedChanged;
        // 
        // flagNoteHeightLabel
        // 
        flagNoteHeightLabel.AutoSize = true;
        flagNoteHeightLabel.Font = new Font("Microsoft JhengHei UI", 9F);
        flagNoteHeightLabel.Location = new Point(620, 153);
        flagNoteHeightLabel.Name = "flagNoteHeightLabel";
        flagNoteHeightLabel.Size = new Size(125, 15);
        flagNoteHeightLabel.TabIndex = 16;
        flagNoteHeightLabel.Text = "Flag Note Height: ---";
        flagNoteHeightLabel.Visible = false;
        // 
        // flagNoteSpacingLabel
        // 
        flagNoteSpacingLabel.AutoSize = true;
        flagNoteSpacingLabel.Font = new Font("Microsoft JhengHei UI", 9F);
        flagNoteSpacingLabel.Location = new Point(590, 119);
        flagNoteSpacingLabel.Name = "flagNoteSpacingLabel";
        flagNoteSpacingLabel.Size = new Size(114, 15);
        flagNoteSpacingLabel.TabIndex = 17;
        flagNoteSpacingLabel.Text = "Flag Note頂部間距:";
        flagNoteSpacingLabel.Visible = false;
        // 
        // _flagNoteSpacingCombo
        // 
        _flagNoteSpacingCombo.Font = new Font("Microsoft JhengHei UI", 9F);
        _flagNoteSpacingCombo.FormattingEnabled = true;
        _flagNoteSpacingCombo.Items.AddRange(new object[] { "2", "5", "10", "15", "20", "25", "30", "40", "50" });
        _flagNoteSpacingCombo.Location = new Point(710, 116);
        _flagNoteSpacingCombo.Name = "_flagNoteSpacingCombo";
        _flagNoteSpacingCombo.Size = new Size(50, 23);
        _flagNoteSpacingCombo.TabIndex = 18;
        _flagNoteSpacingCombo.Text = "2";
        _flagNoteSpacingCombo.Visible = false;
        _flagNoteSpacingCombo.TextChanged += FlagNoteSpacingCombo_TextChanged;
        // 
        // supplementalTextLabel
        // 
        supplementalTextLabel.AutoSize = true;
        supplementalTextLabel.Font = new Font("Microsoft JhengHei UI", 9F);
        supplementalTextLabel.Location = new Point(15, 153);
        supplementalTextLabel.Name = "supplementalTextLabel";
        supplementalTextLabel.Size = new Size(58, 15);
        supplementalTextLabel.TabIndex = 17;
        supplementalTextLabel.Text = "補充說明:";
        supplementalTextLabel.Visible = false;
        // 
        // supplementalTextInput
        // 
        supplementalTextInput.Font = new Font("Microsoft JhengHei UI", 9F);
        supplementalTextInput.Location = new Point(90, 150);
        supplementalTextInput.Name = "supplementalTextInput";
        supplementalTextInput.Size = new Size(520, 23);
        supplementalTextInput.TabIndex = 18;
        supplementalTextInput.Text = "* : One or more controls may have failed. Please use caution when interpreting results.";
        supplementalTextInput.Visible = false;
        // 
        // createPdfButton
        // 
        createPdfButton.Font = new Font("Microsoft JhengHei UI", 10F);
        createPdfButton.Location = new Point(20, 385);
        createPdfButton.Name = "createPdfButton";
        createPdfButton.Size = new Size(100, 40);
        createPdfButton.TabIndex = 11;
        createPdfButton.Text = "建立 PDF";
        createPdfButton.UseVisualStyleBackColor = true;
        createPdfButton.Click += CreatePdfButton_Click;
        // 
        // exportPdfButton
        // 
        exportPdfButton.Font = new Font("Microsoft JhengHei UI", 10F);
        exportPdfButton.Location = new Point(240, 385);
        exportPdfButton.Name = "exportPdfButton";
        exportPdfButton.Size = new Size(100, 40);
        exportPdfButton.TabIndex = 12;
        exportPdfButton.Text = "輸出 PDF";
        exportPdfButton.UseVisualStyleBackColor = true;
        exportPdfButton.Click += ExportPdfButton_Click;
        // 
        // openFolderButton
        // 
        openFolderButton.Font = new Font("Microsoft JhengHei UI", 10F);
        openFolderButton.Location = new Point(350, 385);
        openFolderButton.Name = "openFolderButton";
        openFolderButton.Size = new Size(100, 40);
        openFolderButton.TabIndex = 13;
        openFolderButton.Text = "開啟資料夾";
        openFolderButton.UseVisualStyleBackColor = true;
        openFolderButton.Click += OpenFolderButton_Click;
        // 
        // clearPdfButton
        // 
        clearPdfButton.Font = new Font("Microsoft JhengHei UI", 10F);
        clearPdfButton.Location = new Point(130, 385);
        clearPdfButton.Name = "clearPdfButton";
        clearPdfButton.Size = new Size(100, 40);
        clearPdfButton.TabIndex = 14;
        clearPdfButton.Text = "清除 PDF";
        clearPdfButton.UseVisualStyleBackColor = true;
        clearPdfButton.Click += ClearPdfButton_Click;
        // 
        // statusList
        // 
        statusList.Font = new Font("Microsoft JhengHei UI", 10F);
        statusList.FormattingEnabled = true;
        statusList.ItemHeight = 17;
        statusList.Items.AddRange(new object[] { "就緒" });
        statusList.Location = new Point(20, 435);
        statusList.Name = "statusList";
        statusList.Size = new Size(740, 106);
        statusList.TabIndex = 15;
        // 
        // contentEditGroup
        // 
        contentEditGroup.Controls.Add(_panelIndvResultTable);
        contentEditGroup.Controls.Add(_panelSampleControlTable);
        contentEditGroup.Controls.Add(_panelWellInfo);
        contentEditGroup.Controls.Add(_panelSummaryTable);
        contentEditGroup.Controls.Add(_panelSignature);
        contentEditGroup.Controls.Add(_panelPcncDetailTable);
        contentEditGroup.Controls.Add(_panelPcncTable);
        contentEditGroup.Controls.Add(_panelPcncNote);
        contentEditGroup.Controls.Add(_panelMultiColor);
        contentEditGroup.Controls.Add(_panelSpacing);
        contentEditGroup.Controls.Add(_panelPageBreak);
        contentEditGroup.Controls.Add(_panelLine);
        contentEditGroup.Controls.Add(_panelKitInfo);
        contentEditGroup.Controls.Add(_editModeCombo);
        contentEditGroup.Controls.Add(editModeLabel);
        contentEditGroup.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        contentEditGroup.Location = new Point(20, 545);
        contentEditGroup.Name = "contentEditGroup";
        contentEditGroup.Size = new Size(770, 300);
        contentEditGroup.TabIndex = 16;
        contentEditGroup.TabStop = false;
        contentEditGroup.Text = "報表內容編輯 (操作相關Block功能完成文件內容)";
        // 
        // _panelIndvResultTable
        // 
        _panelIndvResultTable.Controls.Add(drawIndvResultButton);
        _panelIndvResultTable.Controls.Add(loadIndvResultCsvButton);
        _panelIndvResultTable.Controls.Add(indvResultLabel);
        _panelIndvResultTable.Location = new Point(20, 70);
        _panelIndvResultTable.Name = "_panelIndvResultTable";
        _panelIndvResultTable.Size = new Size(710, 210);
        _panelIndvResultTable.TabIndex = 14;
        _panelIndvResultTable.Visible = false;
        // 
        // drawIndvResultButton
        // 
        drawIndvResultButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawIndvResultButton.Location = new Point(470, 10);
        drawIndvResultButton.Name = "drawIndvResultButton";
        drawIndvResultButton.Size = new Size(80, 28);
        drawIndvResultButton.TabIndex = 2;
        drawIndvResultButton.Text = "繪製";
        drawIndvResultButton.UseVisualStyleBackColor = true;
        drawIndvResultButton.Click += DrawIndvResultButton_Click;
        // 
        // loadIndvResultCsvButton
        // 
        loadIndvResultCsvButton.Font = new Font("Microsoft JhengHei UI", 10F);
        loadIndvResultCsvButton.Location = new Point(360, 10);
        loadIndvResultCsvButton.Name = "loadIndvResultCsvButton";
        loadIndvResultCsvButton.Size = new Size(100, 28);
        loadIndvResultCsvButton.TabIndex = 1;
        loadIndvResultCsvButton.Text = "載入 CSV";
        loadIndvResultCsvButton.UseVisualStyleBackColor = true;
        loadIndvResultCsvButton.Click += LoadIndvResultCsvButton_Click;
        // 
        // indvResultLabel
        // 
        indvResultLabel.AutoSize = true;
        indvResultLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        indvResultLabel.Location = new Point(10, 10);
        indvResultLabel.Name = "indvResultLabel";
        indvResultLabel.Size = new Size(291, 18);
        indvResultLabel.TabIndex = 0;
        indvResultLabel.Text = "繪製Individual INDV_RESULT_TABLE_5COL";
        // 
        // _panelSampleControlTable
        // 
        _panelSampleControlTable.Controls.Add(drawSampleControlButton);
        _panelSampleControlTable.Controls.Add(loadSampleControlCsvButton);
        _panelSampleControlTable.Controls.Add(sampleControlLabel);
        _panelSampleControlTable.Location = new Point(20, 70);
        _panelSampleControlTable.Name = "_panelSampleControlTable";
        _panelSampleControlTable.Size = new Size(710, 210);
        _panelSampleControlTable.TabIndex = 13;
        _panelSampleControlTable.Visible = false;
        // 
        // drawSampleControlButton
        // 
        drawSampleControlButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawSampleControlButton.Location = new Point(400, 10);
        drawSampleControlButton.Name = "drawSampleControlButton";
        drawSampleControlButton.Size = new Size(80, 28);
        drawSampleControlButton.TabIndex = 2;
        drawSampleControlButton.Text = "繪製";
        drawSampleControlButton.UseVisualStyleBackColor = true;
        drawSampleControlButton.Click += DrawIndividualControlButton_Click;
        // 
        // loadSampleControlCsvButton
        // 
        loadSampleControlCsvButton.Font = new Font("Microsoft JhengHei UI", 10F);
        loadSampleControlCsvButton.Location = new Point(290, 10);
        loadSampleControlCsvButton.Name = "loadSampleControlCsvButton";
        loadSampleControlCsvButton.Size = new Size(100, 28);
        loadSampleControlCsvButton.TabIndex = 1;
        loadSampleControlCsvButton.Text = "載入 CSV";
        loadSampleControlCsvButton.UseVisualStyleBackColor = true;
        loadSampleControlCsvButton.Click += LoadIndividualControlCsvButton_Click;
        // 
        // sampleControlLabel
        // 
        sampleControlLabel.AutoSize = true;
        sampleControlLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        sampleControlLabel.Location = new Point(10, 10);
        sampleControlLabel.Name = "sampleControlLabel";
        sampleControlLabel.Size = new Size(198, 18);
        sampleControlLabel.TabIndex = 0;
        sampleControlLabel.Text = "繪製 INDV_CONTROL_TABLE";
        // 
        // _panelWellInfo
        // 
        _panelWellInfo.Controls.Add(drawWellInfoButton);
        _panelWellInfo.Controls.Add(loadWellInfoCsvButton);
        _panelWellInfo.Controls.Add(wellInfoLabel);
        _panelWellInfo.Location = new Point(20, 70);
        _panelWellInfo.Name = "_panelWellInfo";
        _panelWellInfo.Size = new Size(710, 210);
        _panelWellInfo.TabIndex = 12;
        _panelWellInfo.Visible = false;
        // 
        // drawWellInfoButton
        // 
        drawWellInfoButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawWellInfoButton.Location = new Point(360, 10);
        drawWellInfoButton.Name = "drawWellInfoButton";
        drawWellInfoButton.Size = new Size(80, 28);
        drawWellInfoButton.TabIndex = 2;
        drawWellInfoButton.Text = "繪製";
        drawWellInfoButton.UseVisualStyleBackColor = true;
        drawWellInfoButton.Click += DrawWellInfoButton_Click;
        // 
        // loadWellInfoCsvButton
        // 
        loadWellInfoCsvButton.Font = new Font("Microsoft JhengHei UI", 10F);
        loadWellInfoCsvButton.Location = new Point(250, 10);
        loadWellInfoCsvButton.Name = "loadWellInfoCsvButton";
        loadWellInfoCsvButton.Size = new Size(100, 28);
        loadWellInfoCsvButton.TabIndex = 1;
        loadWellInfoCsvButton.Text = "載入 CSV";
        loadWellInfoCsvButton.UseVisualStyleBackColor = true;
        loadWellInfoCsvButton.Click += LoadWellInfoCsvButton_Click;
        // 
        // wellInfoLabel
        // 
        wellInfoLabel.AutoSize = true;
        wellInfoLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        wellInfoLabel.Location = new Point(10, 10);
        wellInfoLabel.Name = "wellInfoLabel";
        wellInfoLabel.Size = new Size(166, 18);
        wellInfoLabel.TabIndex = 0;
        wellInfoLabel.Text = "繪製 WELL_INFO_TABLE";
        // 
        // _panelSummaryTable
        // 
        _panelSummaryTable.Controls.Add(drawSummaryTableButton);
        _panelSummaryTable.Controls.Add(loadSummaryDataCsvButton);
        _panelSummaryTable.Controls.Add(summaryTableLabel);
        _panelSummaryTable.Location = new Point(20, 70);
        _panelSummaryTable.Name = "_panelSummaryTable";
        _panelSummaryTable.Size = new Size(710, 210);
        _panelSummaryTable.TabIndex = 11;
        _panelSummaryTable.Visible = false;
        // 
        // drawSummaryTableButton
        // 
        drawSummaryTableButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawSummaryTableButton.Location = new Point(410, 10);
        drawSummaryTableButton.Name = "drawSummaryTableButton";
        drawSummaryTableButton.Size = new Size(80, 28);
        drawSummaryTableButton.TabIndex = 2;
        drawSummaryTableButton.Text = "繪製";
        drawSummaryTableButton.UseVisualStyleBackColor = true;
        drawSummaryTableButton.Click += DrawSummary6ColumnTableButton_Click;
        // 
        // loadSummaryDataCsvButton
        // 
        loadSummaryDataCsvButton.Font = new Font("Microsoft JhengHei UI", 10F);
        loadSummaryDataCsvButton.Location = new Point(300, 10);
        loadSummaryDataCsvButton.Name = "loadSummaryDataCsvButton";
        loadSummaryDataCsvButton.Size = new Size(100, 28);
        loadSummaryDataCsvButton.TabIndex = 1;
        loadSummaryDataCsvButton.Text = "載入 CSV";
        loadSummaryDataCsvButton.UseVisualStyleBackColor = true;
        loadSummaryDataCsvButton.Click += LoadSummary6ColumnDataCsvButton_Click;
        // 
        // summaryTableLabel
        // 
        summaryTableLabel.AutoSize = true;
        summaryTableLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        summaryTableLabel.Location = new Point(10, 10);
        summaryTableLabel.Name = "summaryTableLabel";
        summaryTableLabel.Size = new Size(261, 18);
        summaryTableLabel.TabIndex = 0;
        summaryTableLabel.Text = "繪製 SUMMARY_RESULT_TABLE_6COL";
        // 
        // _panelSignature
        // 
        _panelSignature.Controls.Add(drawSignatureButton);
        _panelSignature.Controls.Add(signatureLabel);
        _panelSignature.Location = new Point(20, 70);
        _panelSignature.Name = "_panelSignature";
        _panelSignature.Size = new Size(710, 210);
        _panelSignature.TabIndex = 10;
        _panelSignature.Visible = false;
        // 
        // drawSignatureButton
        // 
        drawSignatureButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawSignatureButton.Location = new Point(100, 10);
        drawSignatureButton.Name = "drawSignatureButton";
        drawSignatureButton.Size = new Size(80, 28);
        drawSignatureButton.TabIndex = 1;
        drawSignatureButton.Text = "繪製";
        drawSignatureButton.UseVisualStyleBackColor = true;
        drawSignatureButton.Click += DrawSignatureButton_Click;
        // 
        // signatureLabel
        // 
        signatureLabel.AutoSize = true;
        signatureLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        signatureLabel.Location = new Point(10, 10);
        signatureLabel.Name = "signatureLabel";
        signatureLabel.Size = new Size(78, 18);
        signatureLabel.TabIndex = 0;
        signatureLabel.Text = "繪製簽名區";
        // 
        // _panelPcncDetailTable
        // 
        _panelPcncDetailTable.Controls.Add(drawPcncDetailButton);
        _panelPcncDetailTable.Controls.Add(loadPcncDetailCsvButton);
        _panelPcncDetailTable.Controls.Add(pcncDetailTableLabel);
        _panelPcncDetailTable.Location = new Point(20, 70);
        _panelPcncDetailTable.Name = "_panelPcncDetailTable";
        _panelPcncDetailTable.Size = new Size(710, 210);
        _panelPcncDetailTable.TabIndex = 9;
        _panelPcncDetailTable.Visible = false;
        // 
        // drawPcncDetailButton
        // 
        drawPcncDetailButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawPcncDetailButton.Location = new Point(330, 10);
        drawPcncDetailButton.Name = "drawPcncDetailButton";
        drawPcncDetailButton.Size = new Size(80, 28);
        drawPcncDetailButton.TabIndex = 2;
        drawPcncDetailButton.Text = "繪製";
        drawPcncDetailButton.UseVisualStyleBackColor = true;
        drawPcncDetailButton.Click += DrawPcncDetailButton_Click;
        // 
        // loadPcncDetailCsvButton
        // 
        loadPcncDetailCsvButton.Font = new Font("Microsoft JhengHei UI", 10F);
        loadPcncDetailCsvButton.Location = new Point(220, 10);
        loadPcncDetailCsvButton.Name = "loadPcncDetailCsvButton";
        loadPcncDetailCsvButton.Size = new Size(100, 28);
        loadPcncDetailCsvButton.TabIndex = 1;
        loadPcncDetailCsvButton.Text = "載入 CSV";
        loadPcncDetailCsvButton.UseVisualStyleBackColor = true;
        loadPcncDetailCsvButton.Click += LoadPcncDetailCsvButton_Click;
        // 
        // pcncDetailTableLabel
        // 
        pcncDetailTableLabel.AutoSize = true;
        pcncDetailTableLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        pcncDetailTableLabel.Location = new Point(10, 10);
        pcncDetailTableLabel.Name = "pcncDetailTableLabel";
        pcncDetailTableLabel.Size = new Size(198, 18);
        pcncDetailTableLabel.TabIndex = 0;
        pcncDetailTableLabel.Text = "加入 PC/NC Fail Detail Table";
        // 
        // _panelPcncTable
        // 
        _panelPcncTable.Controls.Add(drawPcncTableButton);
        _panelPcncTable.Controls.Add(loadPcncTableCsvButton);
        _panelPcncTable.Controls.Add(pcncTableLabel);
        _panelPcncTable.Location = new Point(20, 70);
        _panelPcncTable.Name = "_panelPcncTable";
        _panelPcncTable.Size = new Size(710, 210);
        _panelPcncTable.TabIndex = 8;
        _panelPcncTable.Visible = false;
        // 
        // drawPcncTableButton
        // 
        drawPcncTableButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawPcncTableButton.Location = new Point(260, 10);
        drawPcncTableButton.Name = "drawPcncTableButton";
        drawPcncTableButton.Size = new Size(80, 28);
        drawPcncTableButton.TabIndex = 2;
        drawPcncTableButton.Text = "繪製";
        drawPcncTableButton.UseVisualStyleBackColor = true;
        drawPcncTableButton.Click += DrawPcncTableButton_Click;
        // 
        // loadPcncTableCsvButton
        // 
        loadPcncTableCsvButton.Font = new Font("Microsoft JhengHei UI", 10F);
        loadPcncTableCsvButton.Location = new Point(150, 10);
        loadPcncTableCsvButton.Name = "loadPcncTableCsvButton";
        loadPcncTableCsvButton.Size = new Size(100, 28);
        loadPcncTableCsvButton.TabIndex = 1;
        loadPcncTableCsvButton.Text = "載入 CSV";
        loadPcncTableCsvButton.UseVisualStyleBackColor = true;
        loadPcncTableCsvButton.Click += LoadPcncTableCsvButton_Click;
        // 
        // pcncTableLabel
        // 
        pcncTableLabel.AutoSize = true;
        pcncTableLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        pcncTableLabel.Location = new Point(10, 10);
        pcncTableLabel.Name = "pcncTableLabel";
        pcncTableLabel.Size = new Size(126, 18);
        pcncTableLabel.TabIndex = 0;
        pcncTableLabel.Text = "加入 PC/NC Table";
        // 
        // _panelPcncNote
        // 
        _panelPcncNote.Controls.Add(drawPcncButton);
        _panelPcncNote.Controls.Add(loadPcncCsvButton);
        _panelPcncNote.Controls.Add(pcncLabel);
        _panelPcncNote.Location = new Point(20, 70);
        _panelPcncNote.Name = "_panelPcncNote";
        _panelPcncNote.Size = new Size(710, 210);
        _panelPcncNote.TabIndex = 7;
        _panelPcncNote.Visible = false;
        // 
        // drawPcncButton
        // 
        drawPcncButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawPcncButton.Location = new Point(310, 10);
        drawPcncButton.Name = "drawPcncButton";
        drawPcncButton.Size = new Size(80, 28);
        drawPcncButton.TabIndex = 2;
        drawPcncButton.Text = "繪製";
        drawPcncButton.UseVisualStyleBackColor = true;
        drawPcncButton.Click += DrawPcncButton_Click;
        // 
        // loadPcncCsvButton
        // 
        loadPcncCsvButton.Font = new Font("Microsoft JhengHei UI", 10F);
        loadPcncCsvButton.Location = new Point(200, 10);
        loadPcncCsvButton.Name = "loadPcncCsvButton";
        loadPcncCsvButton.Size = new Size(100, 28);
        loadPcncCsvButton.TabIndex = 1;
        loadPcncCsvButton.Text = "載入 CSV";
        loadPcncCsvButton.UseVisualStyleBackColor = true;
        loadPcncCsvButton.Click += LoadPcncCsvButton_Click;
        // 
        // pcncLabel
        // 
        pcncLabel.AutoSize = true;
        pcncLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        pcncLabel.Location = new Point(10, 10);
        pcncLabel.Name = "pcncLabel";
        pcncLabel.Size = new Size(145, 18);
        pcncLabel.TabIndex = 0;
        pcncLabel.Text = "加入 PC/NC Flag List";
        // 
        // _panelMultiColor
        // 
        _panelMultiColor.Controls.Add(drawMultiColorButton);
        _panelMultiColor.Controls.Add(linkTargetCheck);
        _panelMultiColor.Controls.Add(outlineCheck);
        _panelMultiColor.Controls.Add(_multiColorInput);
        _panelMultiColor.Controls.Add(multiColorLabel);
        _panelMultiColor.Location = new Point(20, 70);
        _panelMultiColor.Name = "_panelMultiColor";
        _panelMultiColor.Size = new Size(710, 210);
        _panelMultiColor.TabIndex = 6;
        _panelMultiColor.Visible = false;
        // 
        // drawMultiColorButton
        // 
        drawMultiColorButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawMultiColorButton.Location = new Point(690, 10);
        drawMultiColorButton.Name = "drawMultiColorButton";
        drawMultiColorButton.Size = new Size(80, 28);
        drawMultiColorButton.TabIndex = 4;
        drawMultiColorButton.Text = "繪製";
        drawMultiColorButton.UseVisualStyleBackColor = true;
        drawMultiColorButton.Click += DrawMultiColorTextButton_Click;
        // 
        // linkTargetCheck
        // 
        linkTargetCheck.Font = new Font("Microsoft JhengHei UI", 9F);
        linkTargetCheck.Location = new Point(590, 10);
        linkTargetCheck.Name = "linkTargetCheck";
        linkTargetCheck.Size = new Size(90, 28);
        linkTargetCheck.TabIndex = 3;
        linkTargetCheck.Text = "LinkTarget";
        linkTargetCheck.UseVisualStyleBackColor = true;
        // 
        // outlineCheck
        // 
        outlineCheck.Font = new Font("Microsoft JhengHei UI", 9F);
        outlineCheck.Location = new Point(510, 10);
        outlineCheck.Name = "outlineCheck";
        outlineCheck.Size = new Size(70, 28);
        outlineCheck.TabIndex = 2;
        outlineCheck.Text = "Outline";
        outlineCheck.UseVisualStyleBackColor = true;
        // 
        // _multiColorInput
        // 
        _multiColorInput.Font = new Font("Microsoft JhengHei UI", 9F);
        _multiColorInput.Location = new Point(220, 10);
        _multiColorInput.Name = "_multiColorInput";
        _multiColorInput.Size = new Size(280, 23);
        _multiColorInput.TabIndex = 1;
        _multiColorInput.Text = "紅色文字|Red;藍色文字|Blue;一般文字";
        // 
        // multiColorLabel
        // 
        multiColorLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        multiColorLabel.Location = new Point(10, 10);
        multiColorLabel.Name = "multiColorLabel";
        multiColorLabel.Size = new Size(200, 28);
        multiColorLabel.TabIndex = 0;
        multiColorLabel.Text = "以多種顏色繪製文字段落";
        multiColorLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _panelSpacing
        // 
        _panelSpacing.Controls.Add(drawSpacingButton);
        _panelSpacing.Controls.Add(_spacingHeightCombo);
        _panelSpacing.Controls.Add(spacingLabel2);
        _panelSpacing.Controls.Add(spacingLabel1);
        _panelSpacing.Location = new Point(20, 70);
        _panelSpacing.Name = "_panelSpacing";
        _panelSpacing.Size = new Size(710, 210);
        _panelSpacing.TabIndex = 5;
        _panelSpacing.Visible = false;
        // 
        // drawSpacingButton
        // 
        drawSpacingButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawSpacingButton.Location = new Point(300, 10);
        drawSpacingButton.Name = "drawSpacingButton";
        drawSpacingButton.Size = new Size(80, 28);
        drawSpacingButton.TabIndex = 3;
        drawSpacingButton.Text = "繪製";
        drawSpacingButton.UseVisualStyleBackColor = true;
        drawSpacingButton.Click += DrawSpacingButton_Click;
        // 
        // _spacingHeightCombo
        // 
        _spacingHeightCombo.Font = new Font("Microsoft JhengHei UI", 10F);
        _spacingHeightCombo.FormattingEnabled = true;
        _spacingHeightCombo.Items.AddRange(new object[] { "10", "15", "20", "25", "30", "40", "50", "100" });
        _spacingHeightCombo.Location = new Point(210, 10);
        _spacingHeightCombo.Name = "_spacingHeightCombo";
        _spacingHeightCombo.Size = new Size(80, 25);
        _spacingHeightCombo.TabIndex = 2;
        _spacingHeightCombo.Text = "25";
        // 
        // spacingLabel2
        // 
        spacingLabel2.Font = new Font("Microsoft JhengHei UI", 10F);
        spacingLabel2.Location = new Point(130, 10);
        spacingLabel2.Name = "spacingLabel2";
        spacingLabel2.Size = new Size(70, 28);
        spacingLabel2.TabIndex = 1;
        spacingLabel2.Text = "高度(pt):";
        spacingLabel2.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // spacingLabel1
        // 
        spacingLabel1.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        spacingLabel1.Location = new Point(10, 10);
        spacingLabel1.Name = "spacingLabel1";
        spacingLabel1.Size = new Size(120, 28);
        spacingLabel1.TabIndex = 0;
        spacingLabel1.Text = "插入間隔區域";
        spacingLabel1.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _panelPageBreak
        // 
        _panelPageBreak.Controls.Add(pageBreakButton);
        _panelPageBreak.Controls.Add(pageBreakLabel);
        _panelPageBreak.Location = new Point(20, 70);
        _panelPageBreak.Name = "_panelPageBreak";
        _panelPageBreak.Size = new Size(710, 210);
        _panelPageBreak.TabIndex = 4;
        _panelPageBreak.Visible = false;
        // 
        // pageBreakButton
        // 
        pageBreakButton.Font = new Font("Microsoft JhengHei UI", 10F);
        pageBreakButton.Location = new Point(90, 10);
        pageBreakButton.Name = "pageBreakButton";
        pageBreakButton.Size = new Size(80, 28);
        pageBreakButton.TabIndex = 1;
        pageBreakButton.Text = "換頁";
        pageBreakButton.UseVisualStyleBackColor = true;
        pageBreakButton.Click += PageBreakButton_Click;
        // 
        // pageBreakLabel
        // 
        pageBreakLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        pageBreakLabel.Location = new Point(10, 10);
        pageBreakLabel.Name = "pageBreakLabel";
        pageBreakLabel.Size = new Size(80, 28);
        pageBreakLabel.TabIndex = 0;
        pageBreakLabel.Text = "手動換頁:";
        pageBreakLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _panelLine
        // 
        _panelLine.Controls.Add(drawLineButton);
        _panelLine.Controls.Add(_lineSpacingAfterInput);
        _panelLine.Controls.Add(spaceLabel);
        _panelLine.Controls.Add(_lineThicknessInput);
        _panelLine.Controls.Add(thickLabel);
        _panelLine.Controls.Add(_lineLengthInput);
        _panelLine.Controls.Add(lenLabel);
        _panelLine.Controls.Add(_lineStartXInput);
        _panelLine.Controls.Add(xLabel);
        _panelLine.Controls.Add(_lineColorCombo);
        _panelLine.Controls.Add(lineLabel);
        _panelLine.Location = new Point(20, 70);
        _panelLine.Name = "_panelLine";
        _panelLine.Size = new Size(710, 210);
        _panelLine.TabIndex = 3;
        _panelLine.Visible = false;
        // 
        // drawLineButton
        // 
        drawLineButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawLineButton.Location = new Point(610, 10);
        drawLineButton.Name = "drawLineButton";
        drawLineButton.Size = new Size(80, 28);
        drawLineButton.TabIndex = 10;
        drawLineButton.Text = "繪製線條";
        drawLineButton.UseVisualStyleBackColor = true;
        drawLineButton.Click += DrawLineButton_Click;
        // 
        // _lineSpacingAfterInput
        // 
        _lineSpacingAfterInput.Font = new Font("Microsoft JhengHei UI", 10F);
        _lineSpacingAfterInput.Location = new Point(550, 10);
        _lineSpacingAfterInput.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
        _lineSpacingAfterInput.Name = "_lineSpacingAfterInput";
        _lineSpacingAfterInput.Size = new Size(50, 24);
        _lineSpacingAfterInput.TabIndex = 9;
        _lineSpacingAfterInput.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // spaceLabel
        // 
        spaceLabel.Font = new Font("Microsoft JhengHei UI", 10F);
        spaceLabel.Location = new Point(460, 10);
        spaceLabel.Name = "spaceLabel";
        spaceLabel.Size = new Size(90, 28);
        spaceLabel.TabIndex = 8;
        spaceLabel.Text = "線段區域間距:";
        spaceLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _lineThicknessInput
        // 
        _lineThicknessInput.DecimalPlaces = 1;
        _lineThicknessInput.Font = new Font("Microsoft JhengHei UI", 10F);
        _lineThicknessInput.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        _lineThicknessInput.Location = new Point(400, 10);
        _lineThicknessInput.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
        _lineThicknessInput.Name = "_lineThicknessInput";
        _lineThicknessInput.Size = new Size(50, 24);
        _lineThicknessInput.TabIndex = 7;
        _lineThicknessInput.Value = new decimal(new int[] { 2, 0, 0, 65536 });
        // 
        // thickLabel
        // 
        thickLabel.Font = new Font("Microsoft JhengHei UI", 10F);
        thickLabel.Location = new Point(360, 10);
        thickLabel.Name = "thickLabel";
        thickLabel.Size = new Size(40, 28);
        thickLabel.TabIndex = 6;
        thickLabel.Text = "線粗:";
        thickLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _lineLengthInput
        // 
        _lineLengthInput.Font = new Font("Microsoft JhengHei UI", 10F);
        _lineLengthInput.Location = new Point(290, 10);
        _lineLengthInput.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
        _lineLengthInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        _lineLengthInput.Name = "_lineLengthInput";
        _lineLengthInput.Size = new Size(60, 24);
        _lineLengthInput.TabIndex = 5;
        _lineLengthInput.Value = new decimal(new int[] { 450, 0, 0, 0 });
        // 
        // lenLabel
        // 
        lenLabel.Font = new Font("Microsoft JhengHei UI", 10F);
        lenLabel.Location = new Point(250, 10);
        lenLabel.Name = "lenLabel";
        lenLabel.Size = new Size(40, 28);
        lenLabel.TabIndex = 4;
        lenLabel.Text = "線長:";
        lenLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _lineStartXInput
        // 
        _lineStartXInput.Font = new Font("Microsoft JhengHei UI", 10F);
        _lineStartXInput.Location = new Point(180, 10);
        _lineStartXInput.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
        _lineStartXInput.Name = "_lineStartXInput";
        _lineStartXInput.Size = new Size(60, 24);
        _lineStartXInput.TabIndex = 3;
        _lineStartXInput.Value = new decimal(new int[] { 72, 0, 0, 0 });
        // 
        // xLabel
        // 
        xLabel.Font = new Font("Microsoft JhengHei UI", 10F);
        xLabel.Location = new Point(155, 10);
        xLabel.Name = "xLabel";
        xLabel.Size = new Size(20, 28);
        xLabel.TabIndex = 2;
        xLabel.Text = "X:";
        xLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _lineColorCombo
        // 
        _lineColorCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _lineColorCombo.Font = new Font("Microsoft JhengHei UI", 10F);
        _lineColorCombo.FormattingEnabled = true;
        _lineColorCombo.Items.AddRange(new object[] { "Gray", "Black", "Red", "Blue", "Green", "Orange", "Purple" });
        _lineColorCombo.Location = new Point(70, 10);
        _lineColorCombo.Name = "_lineColorCombo";
        _lineColorCombo.Size = new Size(80, 25);
        _lineColorCombo.TabIndex = 1;
        // 
        // lineLabel
        // 
        lineLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        lineLabel.Location = new Point(10, 10);
        lineLabel.Name = "lineLabel";
        lineLabel.Size = new Size(60, 28);
        lineLabel.TabIndex = 0;
        lineLabel.Text = "水平線:";
        lineLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _panelKitInfo
        // 
        _panelKitInfo.Controls.Add(drawKitInfoButton);
        _panelKitInfo.Controls.Add(_tableStyleCombo);
        _panelKitInfo.Controls.Add(_renderMethodCombo);
        _panelKitInfo.Controls.Add(loadCsvButton);
        _panelKitInfo.Controls.Add(kitInfoLabel);
        _panelKitInfo.Location = new Point(20, 70);
        _panelKitInfo.Name = "_panelKitInfo";
        _panelKitInfo.Size = new Size(710, 210);
        _panelKitInfo.TabIndex = 2;
        _panelKitInfo.Visible = false;
        // 
        // drawKitInfoButton
        // 
        drawKitInfoButton.Font = new Font("Microsoft JhengHei UI", 10F);
        drawKitInfoButton.Location = new Point(590, 10);
        drawKitInfoButton.Name = "drawKitInfoButton";
        drawKitInfoButton.Size = new Size(80, 28);
        drawKitInfoButton.TabIndex = 4;
        drawKitInfoButton.Text = "繪製";
        drawKitInfoButton.UseVisualStyleBackColor = true;
        drawKitInfoButton.Click += DrawKitInfoButton_Click;
        // 
        // _tableStyleCombo
        // 
        _tableStyleCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _tableStyleCombo.Font = new Font("Microsoft JhengHei UI", 10F);
        _tableStyleCombo.FormattingEnabled = true;
        _tableStyleCombo.Items.AddRange(new object[] { "TbSetting1" });
        _tableStyleCombo.Location = new Point(450, 10);
        _tableStyleCombo.Name = "_tableStyleCombo";
        _tableStyleCombo.Size = new Size(120, 25);
        _tableStyleCombo.TabIndex = 3;
        // 
        // _renderMethodCombo
        // 
        _renderMethodCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _renderMethodCombo.Font = new Font("Microsoft JhengHei UI", 10F);
        _renderMethodCombo.FormattingEnabled = true;
        _renderMethodCombo.Items.AddRange(new object[] { "RenderTable_V1" });
        _renderMethodCombo.Location = new Point(290, 10);
        _renderMethodCombo.Name = "_renderMethodCombo";
        _renderMethodCombo.Size = new Size(140, 25);
        _renderMethodCombo.TabIndex = 2;
        // 
        // loadCsvButton
        // 
        loadCsvButton.Font = new Font("Microsoft JhengHei UI", 10F);
        loadCsvButton.Location = new Point(190, 10);
        loadCsvButton.Name = "loadCsvButton";
        loadCsvButton.Size = new Size(80, 28);
        loadCsvButton.TabIndex = 1;
        loadCsvButton.Text = "載入 csv";
        loadCsvButton.UseVisualStyleBackColor = true;
        loadCsvButton.Click += LoadKitInfoCsvButton_Click;
        // 
        // kitInfoLabel
        // 
        kitInfoLabel.AutoSize = true;
        kitInfoLabel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        kitInfoLabel.Location = new Point(10, 10);
        kitInfoLabel.Name = "kitInfoLabel";
        kitInfoLabel.Size = new Size(130, 18);
        kitInfoLabel.TabIndex = 0;
        kitInfoLabel.Text = "載入 Kit Info Table";
        // 
        // _editModeCombo
        // 
        _editModeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
        _editModeCombo.Font = new Font("Microsoft JhengHei UI", 10F);
        _editModeCombo.FormattingEnabled = true;
        _editModeCombo.Items.AddRange(new object[] { "表格資訊 (Kit Info Table)", "繪製線條 (Draw Line)", "頁面控制 (Page Control)", "插入間隔 (Insert Spacing)", "多色段落 (Multi-Color Text)", "加入 PC/NC 註解", "加入 PC/NC Table", "加入 PC/NC Fail Detail Table", "加入簽名區", "加入SUMMARY_RESULT_TABLE_6COL", "加入INDV_CONTROL_TABLE", "加入WELL_INFO_TABLE", "加入INDV_RESULT_TABLE" });
        _editModeCombo.Location = new Point(100, 30);
        _editModeCombo.Name = "_editModeCombo";
        _editModeCombo.Size = new Size(250, 25);
        _editModeCombo.TabIndex = 1;
        _editModeCombo.SelectedIndexChanged += EditModeCombo_SelectedIndexChanged;
        // 
        // editModeLabel
        // 
        editModeLabel.AutoSize = true;
        editModeLabel.Location = new Point(20, 30);
        editModeLabel.Name = "editModeLabel";
        editModeLabel.Size = new Size(68, 18);
        editModeLabel.TabIndex = 0;
        editModeLabel.Text = "編輯模式:";
        // 
        // _pdfPreviewGroup
        // 
        _pdfPreviewGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _pdfPreviewGroup.Controls.Add(_flexViewer);
        _pdfPreviewGroup.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold);
        _pdfPreviewGroup.Location = new Point(795, 20);
        _pdfPreviewGroup.Name = "_pdfPreviewGroup";
        _pdfPreviewGroup.Size = new Size(600, 935);
        _pdfPreviewGroup.TabIndex = 17;
        _pdfPreviewGroup.TabStop = false;
        _pdfPreviewGroup.Text = "PDF 即時預覽";
        // 
        // _flexViewer
        // 
        _flexViewer.AutoScrollMargin = new Size(0, 0);
        _flexViewer.AutoScrollMinSize = new Size(0, 0);
        _flexViewer.Dock = DockStyle.Fill;
        _flexViewer.Location = new Point(3, 20);
        _flexViewer.Name = "_flexViewer";
        _flexViewer.Size = new Size(594, 912);
        _flexViewer.TabIndex = 0;
        // 
        // _positionInfoLabel
        // 
        _positionInfoLabel.BackColor = SystemColors.Control;
        _positionInfoLabel.BorderStyle = BorderStyle.None;
        _positionInfoLabel.Font = new Font("Microsoft JhengHei UI", 10F);
        _positionInfoLabel.ForeColor = Color.DarkBlue;
        _positionInfoLabel.Location = new Point(20, 850);
        _positionInfoLabel.Multiline = true;
        _positionInfoLabel.Name = "_positionInfoLabel";
        _positionInfoLabel.ReadOnly = true;
        _positionInfoLabel.Size = new Size(740, 85);
        _positionInfoLabel.TabIndex = 17;
        _positionInfoLabel.Text = "CurrentX: -- | CurrentY: -- | TotalPages: -- | CurrentPage: -- | Header: -- | Footer: --";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        AutoScrollMinSize = new Size(1404, 961);
        ClientSize = new Size(1404, 961);
        Controls.Add(_pdfPreviewGroup);
        Controls.Add(_positionInfoLabel);
        Controls.Add(contentEditGroup);
        Controls.Add(statusList);
        Controls.Add(clearPdfButton);
        Controls.Add(openFolderButton);
        Controls.Add(exportPdfButton);
        Controls.Add(createPdfButton);
        Controls.Add(headerFooterGroup);
        Controls.Add(marginGroup);
        Controls.Add(descLabel);
        Controls.Add(titleLabel);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "PlexReportII GUI";
        marginGroup.ResumeLayout(false);
        marginGroup.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_marginHorizontalInput).EndInit();
        ((System.ComponentModel.ISupportInitialize)_marginVerticalInput).EndInit();
        headerFooterGroup.ResumeLayout(false);
        headerFooterGroup.PerformLayout();
        contentEditGroup.ResumeLayout(false);
        contentEditGroup.PerformLayout();
        _panelIndvResultTable.ResumeLayout(false);
        _panelIndvResultTable.PerformLayout();
        _panelSampleControlTable.ResumeLayout(false);
        _panelSampleControlTable.PerformLayout();
        _panelWellInfo.ResumeLayout(false);
        _panelWellInfo.PerformLayout();
        _panelSummaryTable.ResumeLayout(false);
        _panelSummaryTable.PerformLayout();
        _panelSignature.ResumeLayout(false);
        _panelSignature.PerformLayout();
        _panelPcncDetailTable.ResumeLayout(false);
        _panelPcncDetailTable.PerformLayout();
        _panelPcncTable.ResumeLayout(false);
        _panelPcncTable.PerformLayout();
        _panelPcncNote.ResumeLayout(false);
        _panelPcncNote.PerformLayout();
        _panelMultiColor.ResumeLayout(false);
        _panelMultiColor.PerformLayout();
        _panelSpacing.ResumeLayout(false);
        _panelPageBreak.ResumeLayout(false);
        _panelLine.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_lineSpacingAfterInput).EndInit();
        ((System.ComponentModel.ISupportInitialize)_lineThicknessInput).EndInit();
        ((System.ComponentModel.ISupportInitialize)_lineLengthInput).EndInit();
        ((System.ComponentModel.ISupportInitialize)_lineStartXInput).EndInit();
        _panelKitInfo.ResumeLayout(false);
        _panelKitInfo.PerformLayout();
        _pdfPreviewGroup.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_flexViewer).EndInit();
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label titleLabel;
    private System.Windows.Forms.Label descLabel;
    private System.Windows.Forms.GroupBox marginGroup;
    private System.Windows.Forms.Label marginHLabel;
    private System.Windows.Forms.NumericUpDown _marginHorizontalInput;
    private System.Windows.Forms.Label marginHUnit;
    private System.Windows.Forms.Label marginVLabel;
    private System.Windows.Forms.NumericUpDown _marginVerticalInput;
    private System.Windows.Forms.Label marginVUnit;
    private System.Windows.Forms.Button resetButton;
    private System.Windows.Forms.CheckBox _allowCopyContentCheck;
    private System.Windows.Forms.GroupBox headerFooterGroup;
    private System.Windows.Forms.CheckBox showHeaderCheck;
    private System.Windows.Forms.CheckBox showFooterCheck;
    private System.Windows.Forms.CheckBox showPageNumberCheck;
    private System.Windows.Forms.Label headerTitleLabel;
    private System.Windows.Forms.TextBox headerTitleInput;
    private System.Windows.Forms.Label softwareNameLabel;
    private System.Windows.Forms.TextBox softwareNameInput;
    private System.Windows.Forms.Button loadLogoButton;
    private System.Windows.Forms.Button removeLogoButton;
    private System.Windows.Forms.Label versionLabel;
    private System.Windows.Forms.TextBox versionInput;
    private System.Windows.Forms.Label operatorLabel;
    private System.Windows.Forms.TextBox operatorInput;
    private System.Windows.Forms.CheckBox ruoCheck;
    private System.Windows.Forms.Label flagNoteLabel;
    private System.Windows.Forms.Button loadFlagNoteCsvButton;
    private System.Windows.Forms.CheckBox addSupplementalTextCheck;
    private System.Windows.Forms.CheckBox addAboveFooterCheck;
    private System.Windows.Forms.Label flagNoteHeightLabel;
    private System.Windows.Forms.Label flagNoteSpacingLabel;
    private System.Windows.Forms.ComboBox _flagNoteSpacingCombo;
    private System.Windows.Forms.Label supplementalTextLabel;
    private System.Windows.Forms.TextBox supplementalTextInput;
    private System.Windows.Forms.Button createPdfButton;
    private System.Windows.Forms.GroupBox _pdfPreviewGroup;
    private C1.Win.FlexViewer.C1FlexViewer _flexViewer;
    private System.Windows.Forms.Button exportPdfButton;
    private System.Windows.Forms.Button openFolderButton;
    private System.Windows.Forms.Button clearPdfButton;
    private System.Windows.Forms.ListBox statusList;
    private System.Windows.Forms.GroupBox contentEditGroup;
    private System.Windows.Forms.Label editModeLabel;
    private System.Windows.Forms.ComboBox _editModeCombo;
    private System.Windows.Forms.Panel _panelKitInfo;
    private System.Windows.Forms.Label kitInfoLabel;
    private System.Windows.Forms.Button loadCsvButton;
    private System.Windows.Forms.ComboBox _renderMethodCombo;
    private System.Windows.Forms.ComboBox _tableStyleCombo;
    private System.Windows.Forms.Button drawKitInfoButton;
    private System.Windows.Forms.Panel _panelLine;
    private System.Windows.Forms.Label lineLabel;
    private System.Windows.Forms.ComboBox _lineColorCombo;
    private System.Windows.Forms.Label xLabel;
    private System.Windows.Forms.NumericUpDown _lineStartXInput;
    private System.Windows.Forms.Label lenLabel;
    private System.Windows.Forms.NumericUpDown _lineLengthInput;
    private System.Windows.Forms.Label thickLabel;
    private System.Windows.Forms.NumericUpDown _lineThicknessInput;
    private System.Windows.Forms.Label spaceLabel;
    private System.Windows.Forms.NumericUpDown _lineSpacingAfterInput;
    private System.Windows.Forms.Button drawLineButton;
    private System.Windows.Forms.Panel _panelPageBreak;
    private System.Windows.Forms.Label pageBreakLabel;
    private System.Windows.Forms.Button pageBreakButton;
    private System.Windows.Forms.Panel _panelSpacing;
    private System.Windows.Forms.Label spacingLabel1;
    private System.Windows.Forms.Label spacingLabel2;
    private System.Windows.Forms.ComboBox _spacingHeightCombo;
    private System.Windows.Forms.Button drawSpacingButton;
    private System.Windows.Forms.Panel _panelMultiColor;
    private System.Windows.Forms.Label multiColorLabel;
    private System.Windows.Forms.TextBox _multiColorInput;
    private System.Windows.Forms.CheckBox outlineCheck;
    private System.Windows.Forms.CheckBox linkTargetCheck;
    private System.Windows.Forms.Button drawMultiColorButton;
    private System.Windows.Forms.Panel _panelPcncNote;
    private System.Windows.Forms.Label pcncLabel;
    private System.Windows.Forms.Button loadPcncCsvButton;
    private System.Windows.Forms.Button drawPcncButton;
    private System.Windows.Forms.Panel _panelPcncTable;
    private System.Windows.Forms.Label pcncTableLabel;
    private System.Windows.Forms.Button loadPcncTableCsvButton;
    private System.Windows.Forms.Button drawPcncTableButton;
    private System.Windows.Forms.Panel _panelPcncDetailTable;
    private System.Windows.Forms.Label pcncDetailTableLabel;
    private System.Windows.Forms.Button loadPcncDetailCsvButton;
    private System.Windows.Forms.Button drawPcncDetailButton;
    private System.Windows.Forms.TextBox _positionInfoLabel;
    private System.Windows.Forms.Panel _panelSignature;
    private System.Windows.Forms.Label signatureLabel;
    private System.Windows.Forms.Button drawSignatureButton;
    private System.Windows.Forms.Panel _panelSummaryTable;
    private System.Windows.Forms.Label summaryTableLabel;
    private System.Windows.Forms.Button loadSummaryDataCsvButton;
    private System.Windows.Forms.Button drawSummaryTableButton;
    private System.Windows.Forms.Panel _panelWellInfo;
    private System.Windows.Forms.Label wellInfoLabel;
    private System.Windows.Forms.Button loadWellInfoCsvButton;
    private System.Windows.Forms.Button drawWellInfoButton;
    private System.Windows.Forms.Panel _panelSampleControlTable;
    private System.Windows.Forms.Label sampleControlLabel;
    private System.Windows.Forms.Button loadSampleControlCsvButton;
    private System.Windows.Forms.Button drawSampleControlButton;
    private System.Windows.Forms.Panel _panelIndvResultTable;
    private System.Windows.Forms.Label indvResultLabel;
    private System.Windows.Forms.Button loadIndvResultCsvButton;
    private System.Windows.Forms.Button drawIndvResultButton;
}
