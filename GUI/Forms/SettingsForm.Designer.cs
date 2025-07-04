namespace GUI.Forms
{
    partial class SettingsForm
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
            gamePaths = new System.Windows.Forms.ListBox();
            gamePathsAdd = new System.Windows.Forms.Button();
            gamePathsRemove = new System.Windows.Forms.Button();
            gamePathsAddFolder = new System.Windows.Forms.Button();
            maxTextureSizeLabel = new System.Windows.Forms.Label();
            maxTextureSizeInput = new System.Windows.Forms.NumericUpDown();
            fovInput = new System.Windows.Forms.NumericUpDown();
            fovLabel = new System.Windows.Forms.Label();
            antiAliasingLabel = new System.Windows.Forms.Label();
            antiAliasingComboBox = new System.Windows.Forms.ComboBox();
            registerAssociationButton = new System.Windows.Forms.Button();
            vsyncLabel = new System.Windows.Forms.Label();
            vsyncCheckBox = new System.Windows.Forms.CheckBox();
            displayFpsCheckBox = new System.Windows.Forms.CheckBox();
            displayFpsLabel = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            groupBox2 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            shadowResolutionLabel = new System.Windows.Forms.Label();
            shadowResolutionInput = new System.Windows.Forms.NumericUpDown();
            fovPanel = new System.Windows.Forms.Panel();
            setFovTo4by3Button = new System.Windows.Forms.Button();
            groupBox3 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            textViewerFontSizeLabel = new System.Windows.Forms.Label();
            openExplorerOnStartCheckbox = new System.Windows.Forms.CheckBox();
            openExplorerOnStartLabel = new System.Windows.Forms.Label();
            themeLabel = new System.Windows.Forms.Label();
            themeComboBox = new System.Windows.Forms.ComboBox();
            textViewerFontSize = new System.Windows.Forms.NumericUpDown();
            groupBox4 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            quickPreviewLabel = new System.Windows.Forms.Label();
            quickPreviewSoundsLabel = new System.Windows.Forms.Label();
            quickPreviewCheckbox = new System.Windows.Forms.CheckBox();
            quickPreviewSoundsCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)maxTextureSizeInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fovInput).BeginInit();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)shadowResolutionInput).BeginInit();
            fovPanel.SuspendLayout();
            groupBox3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textViewerFontSize).BeginInit();
            groupBox4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // gamePaths
            // 
            gamePaths.Dock = System.Windows.Forms.DockStyle.Top;
            gamePaths.FormattingEnabled = true;
            gamePaths.Location = new System.Drawing.Point(16, 36);
            gamePaths.Margin = new System.Windows.Forms.Padding(0);
            gamePaths.Name = "gamePaths";
            gamePaths.Size = new System.Drawing.Size(432, 123);
            gamePaths.TabIndex = 1;
            // 
            // gamePathsAdd
            // 
            gamePathsAdd.Dock = System.Windows.Forms.DockStyle.Left;
            gamePathsAdd.Location = new System.Drawing.Point(0, 9);
            gamePathsAdd.Margin = new System.Windows.Forms.Padding(0, 9, 8, 9);
            gamePathsAdd.Name = "gamePathsAdd";
            gamePathsAdd.Size = new System.Drawing.Size(212, 30);
            gamePathsAdd.TabIndex = 2;
            gamePathsAdd.Text = "Add .vpk or gameinfo.gi";
            gamePathsAdd.UseVisualStyleBackColor = true;
            gamePathsAdd.Click += GamePathAdd;
            // 
            // gamePathsRemove
            // 
            gamePathsRemove.Dock = System.Windows.Forms.DockStyle.Right;
            gamePathsRemove.Location = new System.Drawing.Point(344, 9);
            gamePathsRemove.Margin = new System.Windows.Forms.Padding(8, 9, 0, 9);
            gamePathsRemove.Name = "gamePathsRemove";
            gamePathsRemove.Size = new System.Drawing.Size(88, 30);
            gamePathsRemove.TabIndex = 4;
            gamePathsRemove.Text = "Remove";
            gamePathsRemove.UseVisualStyleBackColor = true;
            gamePathsRemove.Click += GamePathRemoveClick;
            // 
            // gamePathsAddFolder
            // 
            gamePathsAddFolder.Dock = System.Windows.Forms.DockStyle.Left;
            gamePathsAddFolder.Location = new System.Drawing.Point(228, 9);
            gamePathsAddFolder.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            gamePathsAddFolder.Name = "gamePathsAddFolder";
            gamePathsAddFolder.Size = new System.Drawing.Size(88, 30);
            gamePathsAddFolder.TabIndex = 3;
            gamePathsAddFolder.Text = "Add folder";
            gamePathsAddFolder.UseVisualStyleBackColor = true;
            gamePathsAddFolder.Click += GamePathAddFolder;
            // 
            // maxTextureSizeLabel
            // 
            maxTextureSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            maxTextureSizeLabel.AutoSize = true;
            maxTextureSizeLabel.Location = new System.Drawing.Point(3, 103);
            maxTextureSizeLabel.Name = "maxTextureSizeLabel";
            maxTextureSizeLabel.Size = new System.Drawing.Size(111, 19);
            maxTextureSizeLabel.TabIndex = 0;
            maxTextureSizeLabel.Text = "Max texture size:";
            // 
            // maxTextureSizeInput
            // 
            maxTextureSizeInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            maxTextureSizeInput.Increment = new decimal(new int[] { 64, 0, 0, 0 });
            maxTextureSizeInput.Location = new System.Drawing.Point(219, 100);
            maxTextureSizeInput.Maximum = new decimal(new int[] { 10240, 0, 0, 0 });
            maxTextureSizeInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            maxTextureSizeInput.Name = "maxTextureSizeInput";
            maxTextureSizeInput.Size = new System.Drawing.Size(100, 25);
            maxTextureSizeInput.TabIndex = 5;
            maxTextureSizeInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            maxTextureSizeInput.ValueChanged += OnMaxTextureSizeValueChanged;
            // 
            // fovInput
            // 
            fovInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            fovInput.DecimalPlaces = 6;
            fovInput.Location = new System.Drawing.Point(3, 11);
            fovInput.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            fovInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            fovInput.Name = "fovInput";
            fovInput.Size = new System.Drawing.Size(100, 25);
            fovInput.TabIndex = 6;
            fovInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            fovInput.ValueChanged += OnFovValueChanged;
            // 
            // fovLabel
            // 
            fovLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            fovLabel.AutoSize = true;
            fovLabel.Location = new System.Drawing.Point(3, 13);
            fovLabel.Name = "fovLabel";
            fovLabel.Size = new System.Drawing.Size(87, 19);
            fovLabel.TabIndex = 4;
            fovLabel.Text = "Vertical FOV:";
            // 
            // antiAliasingLabel
            // 
            antiAliasingLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            antiAliasingLabel.AutoSize = true;
            antiAliasingLabel.Location = new System.Drawing.Point(3, 58);
            antiAliasingLabel.Name = "antiAliasingLabel";
            antiAliasingLabel.Size = new System.Drawing.Size(88, 19);
            antiAliasingLabel.TabIndex = 6;
            antiAliasingLabel.Text = "Anti-aliasing:";
            // 
            // antiAliasingComboBox
            // 
            antiAliasingComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            antiAliasingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            antiAliasingComboBox.FormattingEnabled = true;
            antiAliasingComboBox.Location = new System.Drawing.Point(219, 55);
            antiAliasingComboBox.Name = "antiAliasingComboBox";
            antiAliasingComboBox.Size = new System.Drawing.Size(100, 25);
            antiAliasingComboBox.TabIndex = 7;
            antiAliasingComboBox.SelectedIndexChanged += OnAntiAliasingValueChanged;
            // 
            // registerAssociationButton
            // 
            registerAssociationButton.Location = new System.Drawing.Point(4, 138);
            registerAssociationButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            registerAssociationButton.Name = "registerAssociationButton";
            registerAssociationButton.Size = new System.Drawing.Size(208, 30);
            registerAssociationButton.TabIndex = 10;
            registerAssociationButton.Text = "Register .vpk file association";
            registerAssociationButton.UseVisualStyleBackColor = true;
            registerAssociationButton.Click += OnRegisterAssociationButtonClick;
            // 
            // vsyncLabel
            // 
            vsyncLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            vsyncLabel.AutoSize = true;
            vsyncLabel.Location = new System.Drawing.Point(3, 193);
            vsyncLabel.Name = "vsyncLabel";
            vsyncLabel.Size = new System.Drawing.Size(88, 19);
            vsyncLabel.TabIndex = 7;
            vsyncLabel.Text = "Vertical Sync:";
            // 
            // vsyncCheckBox
            // 
            vsyncCheckBox.AutoSize = true;
            vsyncCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            vsyncCheckBox.Location = new System.Drawing.Point(219, 183);
            vsyncCheckBox.Name = "vsyncCheckBox";
            vsyncCheckBox.Size = new System.Drawing.Size(210, 39);
            vsyncCheckBox.TabIndex = 8;
            vsyncCheckBox.UseVisualStyleBackColor = true;
            vsyncCheckBox.CheckedChanged += OnVsyncValueChanged;
            // 
            // displayFpsCheckBox
            // 
            displayFpsCheckBox.AutoSize = true;
            displayFpsCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            displayFpsCheckBox.Location = new System.Drawing.Point(219, 228);
            displayFpsCheckBox.Name = "displayFpsCheckBox";
            displayFpsCheckBox.Size = new System.Drawing.Size(210, 39);
            displayFpsCheckBox.TabIndex = 9;
            displayFpsCheckBox.UseVisualStyleBackColor = true;
            displayFpsCheckBox.CheckedChanged += OnDisplayFpsValueChanged;
            // 
            // displayFpsLabel
            // 
            displayFpsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            displayFpsLabel.AutoSize = true;
            displayFpsLabel.Location = new System.Drawing.Point(3, 238);
            displayFpsLabel.Name = "displayFpsLabel";
            displayFpsLabel.Size = new System.Drawing.Size(82, 19);
            displayFpsLabel.TabIndex = 3;
            displayFpsLabel.Text = "Display FPS:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Controls.Add(gamePaths);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(16, 18);
            groupBox1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(16, 18, 16, 18);
            groupBox1.Size = new System.Drawing.Size(464, 219);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Game content search paths";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.Controls.Add(gamePathsAdd, 0, 0);
            tableLayoutPanel1.Controls.Add(gamePathsAddFolder, 1, 0);
            tableLayoutPanel1.Controls.Add(gamePathsRemove, 2, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel1.Location = new System.Drawing.Point(16, 159);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(432, 48);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel2);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox2.Location = new System.Drawing.Point(16, 237);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 18, 3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(16, 18, 16, 18);
            groupBox2.Size = new System.Drawing.Size(464, 332);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Video settings";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(displayFpsLabel, 0, 5);
            tableLayoutPanel2.Controls.Add(vsyncLabel, 0, 4);
            tableLayoutPanel2.Controls.Add(displayFpsCheckBox, 1, 5);
            tableLayoutPanel2.Controls.Add(vsyncCheckBox, 1, 4);
            tableLayoutPanel2.Controls.Add(shadowResolutionLabel, 0, 3);
            tableLayoutPanel2.Controls.Add(shadowResolutionInput, 1, 3);
            tableLayoutPanel2.Controls.Add(fovLabel, 0, 0);
            tableLayoutPanel2.Controls.Add(maxTextureSizeLabel, 0, 2);
            tableLayoutPanel2.Controls.Add(antiAliasingLabel, 0, 1);
            tableLayoutPanel2.Controls.Add(fovPanel, 1, 0);
            tableLayoutPanel2.Controls.Add(maxTextureSizeInput, 1, 2);
            tableLayoutPanel2.Controls.Add(antiAliasingComboBox, 1, 1);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(16, 36);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.Size = new System.Drawing.Size(432, 278);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // shadowResolutionLabel
            // 
            shadowResolutionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            shadowResolutionLabel.AutoSize = true;
            shadowResolutionLabel.Location = new System.Drawing.Point(3, 148);
            shadowResolutionLabel.Name = "shadowResolutionLabel";
            shadowResolutionLabel.Size = new System.Drawing.Size(125, 19);
            shadowResolutionLabel.TabIndex = 11;
            shadowResolutionLabel.Text = "Shadow resolution:";
            // 
            // shadowResolutionInput
            // 
            shadowResolutionInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            shadowResolutionInput.Increment = new decimal(new int[] { 64, 0, 0, 0 });
            shadowResolutionInput.Location = new System.Drawing.Point(219, 145);
            shadowResolutionInput.Maximum = new decimal(new int[] { 4096, 0, 0, 0 });
            shadowResolutionInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            shadowResolutionInput.Name = "shadowResolutionInput";
            shadowResolutionInput.Size = new System.Drawing.Size(100, 25);
            shadowResolutionInput.TabIndex = 12;
            shadowResolutionInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // fovPanel
            // 
            fovPanel.Controls.Add(setFovTo4by3Button);
            fovPanel.Controls.Add(fovInput);
            fovPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            fovPanel.Location = new System.Drawing.Point(216, 0);
            fovPanel.Margin = new System.Windows.Forms.Padding(0);
            fovPanel.Name = "fovPanel";
            fovPanel.Size = new System.Drawing.Size(216, 45);
            fovPanel.TabIndex = 10;
            // 
            // setFovTo4by3Button
            // 
            setFovTo4by3Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            setFovTo4by3Button.Location = new System.Drawing.Point(109, 11);
            setFovTo4by3Button.Name = "setFovTo4by3Button";
            setFovTo4by3Button.Size = new System.Drawing.Size(39, 26);
            setFovTo4by3Button.TabIndex = 7;
            setFovTo4by3Button.Text = "4:3";
            setFovTo4by3Button.UseVisualStyleBackColor = true;
            setFovTo4by3Button.Click += OnSetFovTo4by3ButtonClick;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tableLayoutPanel4);
            groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox3.Location = new System.Drawing.Point(16, 725);
            groupBox3.Margin = new System.Windows.Forms.Padding(0);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(16, 18, 16, 18);
            groupBox3.Size = new System.Drawing.Size(464, 245);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Explorer";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(textViewerFontSizeLabel, 0, 2);
            tableLayoutPanel4.Controls.Add(openExplorerOnStartCheckbox, 1, 0);
            tableLayoutPanel4.Controls.Add(openExplorerOnStartLabel, 0, 0);
            tableLayoutPanel4.Controls.Add(themeLabel, 0, 1);
            tableLayoutPanel4.Controls.Add(themeComboBox, 1, 1);
            tableLayoutPanel4.Controls.Add(textViewerFontSize, 1, 2);
            tableLayoutPanel4.Controls.Add(registerAssociationButton, 0, 3);
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel4.Location = new System.Drawing.Point(16, 36);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 5;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel4.Size = new System.Drawing.Size(432, 191);
            tableLayoutPanel4.TabIndex = 11;
            // 
            // textViewerFontSizeLabel
            // 
            textViewerFontSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            textViewerFontSizeLabel.AutoSize = true;
            textViewerFontSizeLabel.Location = new System.Drawing.Point(3, 103);
            textViewerFontSizeLabel.Name = "textViewerFontSizeLabel";
            textViewerFontSizeLabel.Size = new System.Drawing.Size(134, 19);
            textViewerFontSizeLabel.TabIndex = 15;
            textViewerFontSizeLabel.Text = "Text viewer font size:";
            // 
            // openExplorerOnStartCheckbox
            // 
            openExplorerOnStartCheckbox.AutoSize = true;
            openExplorerOnStartCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            openExplorerOnStartCheckbox.Location = new System.Drawing.Point(219, 3);
            openExplorerOnStartCheckbox.Name = "openExplorerOnStartCheckbox";
            openExplorerOnStartCheckbox.Size = new System.Drawing.Size(210, 39);
            openExplorerOnStartCheckbox.TabIndex = 12;
            openExplorerOnStartCheckbox.UseVisualStyleBackColor = true;
            openExplorerOnStartCheckbox.CheckedChanged += OnOpenExplorerOnStartValueChanged;
            // 
            // openExplorerOnStartLabel
            // 
            openExplorerOnStartLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            openExplorerOnStartLabel.AutoSize = true;
            openExplorerOnStartLabel.Location = new System.Drawing.Point(3, 13);
            openExplorerOnStartLabel.Name = "openExplorerOnStartLabel";
            openExplorerOnStartLabel.Size = new System.Drawing.Size(151, 19);
            openExplorerOnStartLabel.TabIndex = 11;
            openExplorerOnStartLabel.Text = "Open explorer on start:";
            // 
            // themeLabel
            // 
            themeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            themeLabel.AutoSize = true;
            themeLabel.Location = new System.Drawing.Point(3, 58);
            themeLabel.Name = "themeLabel";
            themeLabel.Size = new System.Drawing.Size(158, 19);
            themeLabel.TabIndex = 13;
            themeLabel.Text = "Theme (requires restart):";
            // 
            // themeComboBox
            // 
            themeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            themeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            themeComboBox.FormattingEnabled = true;
            themeComboBox.Location = new System.Drawing.Point(219, 55);
            themeComboBox.Name = "themeComboBox";
            themeComboBox.Size = new System.Drawing.Size(100, 25);
            themeComboBox.TabIndex = 14;
            themeComboBox.SelectedIndexChanged += OnThemeSelectedIndexChanged;
            // 
            // textViewerFontSize
            // 
            textViewerFontSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            textViewerFontSize.Location = new System.Drawing.Point(219, 100);
            textViewerFontSize.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            textViewerFontSize.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            textViewerFontSize.Name = "textViewerFontSize";
            textViewerFontSize.Size = new System.Drawing.Size(100, 25);
            textViewerFontSize.TabIndex = 16;
            textViewerFontSize.Value = new decimal(new int[] { 8, 0, 0, 0 });
            textViewerFontSize.ValueChanged += OnTextViewerFontSizeValueChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tableLayoutPanel3);
            groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox4.Location = new System.Drawing.Point(16, 569);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(16, 18, 16, 18);
            groupBox4.Size = new System.Drawing.Size(464, 156);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Quick file preview";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(quickPreviewLabel, 0, 0);
            tableLayoutPanel3.Controls.Add(quickPreviewSoundsLabel, 0, 1);
            tableLayoutPanel3.Controls.Add(quickPreviewCheckbox, 1, 0);
            tableLayoutPanel3.Controls.Add(quickPreviewSoundsCheckbox, 1, 1);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(16, 36);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            tableLayoutPanel3.Size = new System.Drawing.Size(432, 102);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // quickPreviewLabel
            // 
            quickPreviewLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            quickPreviewLabel.AutoSize = true;
            quickPreviewLabel.Location = new System.Drawing.Point(3, 13);
            quickPreviewLabel.Name = "quickPreviewLabel";
            quickPreviewLabel.Size = new System.Drawing.Size(175, 19);
            quickPreviewLabel.TabIndex = 0;
            quickPreviewLabel.Text = "Preview files after selecting:";
            // 
            // quickPreviewSoundsLabel
            // 
            quickPreviewSoundsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            quickPreviewSoundsLabel.AutoSize = true;
            quickPreviewSoundsLabel.Location = new System.Drawing.Point(3, 58);
            quickPreviewSoundsLabel.Name = "quickPreviewSoundsLabel";
            quickPreviewSoundsLabel.Size = new System.Drawing.Size(119, 19);
            quickPreviewSoundsLabel.TabIndex = 1;
            quickPreviewSoundsLabel.Text = "Auto play sounds:";
            // 
            // quickPreviewCheckbox
            // 
            quickPreviewCheckbox.AutoSize = true;
            quickPreviewCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            quickPreviewCheckbox.Location = new System.Drawing.Point(219, 3);
            quickPreviewCheckbox.Name = "quickPreviewCheckbox";
            quickPreviewCheckbox.Size = new System.Drawing.Size(210, 39);
            quickPreviewCheckbox.TabIndex = 2;
            quickPreviewCheckbox.UseVisualStyleBackColor = true;
            quickPreviewCheckbox.CheckedChanged += OnQuickPreviewCheckboxChanged;
            // 
            // quickPreviewSoundsCheckbox
            // 
            quickPreviewSoundsCheckbox.AutoSize = true;
            quickPreviewSoundsCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            quickPreviewSoundsCheckbox.Location = new System.Drawing.Point(219, 48);
            quickPreviewSoundsCheckbox.Name = "quickPreviewSoundsCheckbox";
            quickPreviewSoundsCheckbox.Size = new System.Drawing.Size(210, 39);
            quickPreviewSoundsCheckbox.TabIndex = 3;
            quickPreviewSoundsCheckbox.UseVisualStyleBackColor = true;
            quickPreviewSoundsCheckbox.CheckedChanged += OnQuickPreviewSoundsCheckboxChanged;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(496, 986);
            Controls.Add(groupBox3);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new System.Drawing.Font("Segoe UI", 10F);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(300, 221);
            Name = "SettingsForm";
            Padding = new System.Windows.Forms.Padding(16, 18, 16, 18);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Settings";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)maxTextureSizeInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)fovInput).EndInit();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)shadowResolutionInput).EndInit();
            fovPanel.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textViewerFontSize).EndInit();
            groupBox4.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox gamePaths;
        private System.Windows.Forms.Button gamePathsAdd;
        private System.Windows.Forms.Button gamePathsRemove;
        private System.Windows.Forms.Button gamePathsAddFolder;
        private System.Windows.Forms.Label maxTextureSizeLabel;
        private System.Windows.Forms.NumericUpDown maxTextureSizeInput;
        private System.Windows.Forms.NumericUpDown fovInput;
        private System.Windows.Forms.Label fovLabel;
        private System.Windows.Forms.Label antiAliasingLabel;
        private System.Windows.Forms.ComboBox antiAliasingComboBox;
        private System.Windows.Forms.Label vsyncLabel;
        private System.Windows.Forms.CheckBox vsyncCheckBox;
        private System.Windows.Forms.Button registerAssociationButton;
        private System.Windows.Forms.CheckBox displayFpsCheckBox;
        private System.Windows.Forms.Label displayFpsLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label quickPreviewLabel;
        private System.Windows.Forms.Label quickPreviewSoundsLabel;
        private System.Windows.Forms.CheckBox quickPreviewCheckbox;
        private System.Windows.Forms.CheckBox quickPreviewSoundsCheckbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox openExplorerOnStartCheckbox;
        private System.Windows.Forms.Label openExplorerOnStartLabel;
        private System.Windows.Forms.Panel fovPanel;
        private System.Windows.Forms.Button setFovTo4by3Button;
        private System.Windows.Forms.Label shadowResolutionLabel;
        private System.Windows.Forms.NumericUpDown shadowResolutionInput;
        private System.Windows.Forms.Label themeLabel;
        private System.Windows.Forms.ComboBox themeComboBox;
        private System.Windows.Forms.Label textViewerFontSizeLabel;
        private System.Windows.Forms.NumericUpDown textViewerFontSize;
    }
}
