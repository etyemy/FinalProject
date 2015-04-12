namespace FinalProject
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getArticlesButton = new System.Windows.Forms.Button();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.xls2TextBox = new System.Windows.Forms.TextBox();
            this.xls1TextBox = new System.Windows.Forms.TextBox();
            this.Xls1Button = new System.Windows.Forms.Button();
            this.Xls2Button = new System.Windows.Forms.Button();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this._analyzeBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._articleTabControl = new System.Windows.Forms.TabControl();
            this.filterButton = new System.Windows.Forms.Button();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._articlesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBarLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this._patientMutationListBox = new System.Windows.Forms.ListBox();
            this._idTextBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this._firstNameLabel = new System.Windows.Forms.Label();
            this._firstNameTextBox = new System.Windows.Forms.TextBox();
            this._lastNameLabel = new System.Windows.Forms.Label();
            this._lastNameTextBox = new System.Windows.Forms.TextBox();
            this._pathologicalNoLabel = new System.Windows.Forms.Label();
            this._pathologicalNoTextBox = new System.Windows.Forms.TextBox();
            this._runNoLabel = new System.Windows.Forms.Label();
            this._runNoTextBox = new System.Windows.Forms.TextBox();
            this._tumourSiteLabel = new System.Windows.Forms.Label();
            this._tumourSiteTextBox = new System.Windows.Forms.TextBox();
            this._diseaseLevelTextBox = new System.Windows.Forms.RichTextBox();
            this._diseaseLevelLabel = new System.Windows.Forms.Label();
            this._backgroundLabel = new System.Windows.Forms.Label();
            this._backgroundTextBox = new System.Windows.Forms.RichTextBox();
            this._previousTreatmentLabel = new System.Windows.Forms.Label();
            this._previousTreatmentTextBox = new System.Windows.Forms.RichTextBox();
            this._currentTreatmentLabel = new System.Windows.Forms.Label();
            this._currentTreatmentTextBox = new System.Windows.Forms.RichTextBox();
            this._coclusionsLabel = new System.Windows.Forms.Label();
            this._conclusionsTextBox1 = new System.Windows.Forms.RichTextBox();
            this._loadPatientButton = new System.Windows.Forms.Button();
            this._savePatientButton = new System.Windows.Forms.Button();
            this._menuStrip.SuspendLayout();
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1284, 24);
            this._menuStrip.TabIndex = 16;
            this._menuStrip.Text = "menuStrip1";
            this._menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // getArticlesButton
            // 
            this.getArticlesButton.Enabled = false;
            this.getArticlesButton.Location = new System.Drawing.Point(12, 111);
            this.getArticlesButton.Name = "getArticlesButton";
            this.getArticlesButton.Size = new System.Drawing.Size(75, 23);
            this.getArticlesButton.TabIndex = 28;
            this.getArticlesButton.Text = "Get Articles";
            this.getArticlesButton.UseVisualStyleBackColor = true;
            this.getArticlesButton.Click += new System.EventHandler(this.getArticlesButton_Click);
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this._statusStrip.Location = new System.Drawing.Point(0, 563);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(1284, 22);
            this._statusStrip.SizingGrip = false;
            this._statusStrip.TabIndex = 29;
            this._statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(85, 17);
            this.toolStripStatusLabel1.Text = "Cosmic Status:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel2.Text = "Disconnected";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(281, 53);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(268, 23);
            this.progressBar1.TabIndex = 30;
            // 
            // xls2TextBox
            // 
            this.xls2TextBox.Enabled = false;
            this.xls2TextBox.Location = new System.Drawing.Point(66, 56);
            this.xls2TextBox.Name = "xls2TextBox";
            this.xls2TextBox.Size = new System.Drawing.Size(100, 20);
            this.xls2TextBox.TabIndex = 32;
            // 
            // xls1TextBox
            // 
            this.xls1TextBox.Enabled = false;
            this.xls1TextBox.Location = new System.Drawing.Point(66, 30);
            this.xls1TextBox.Name = "xls1TextBox";
            this.xls1TextBox.Size = new System.Drawing.Size(100, 20);
            this.xls1TextBox.TabIndex = 33;
            // 
            // Xls1Button
            // 
            this.Xls1Button.Location = new System.Drawing.Point(12, 27);
            this.Xls1Button.Name = "Xls1Button";
            this.Xls1Button.Size = new System.Drawing.Size(48, 23);
            this.Xls1Button.TabIndex = 34;
            this.Xls1Button.Text = "Xls 1";
            this.Xls1Button.UseVisualStyleBackColor = true;
            this.Xls1Button.Click += new System.EventHandler(this.XlsButton_Click);
            // 
            // Xls2Button
            // 
            this.Xls2Button.Location = new System.Drawing.Point(13, 56);
            this.Xls2Button.Name = "Xls2Button";
            this.Xls2Button.Size = new System.Drawing.Size(47, 23);
            this.Xls2Button.TabIndex = 35;
            this.Xls2Button.Text = "Xls 2";
            this.Xls2Button.UseVisualStyleBackColor = true;
            this.Xls2Button.Click += new System.EventHandler(this.XlsButton_Click);
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(172, 27);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(61, 23);
            this.analyzeButton.TabIndex = 36;
            this.analyzeButton.Text = "Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(172, 56);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(61, 23);
            this.saveButton.TabIndex = 37;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // _analyzeBackgroundWorker
            // 
            this._analyzeBackgroundWorker.WorkerReportsProgress = true;
            this._analyzeBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.analyzeBackgroundWorker_DoWork);
            this._analyzeBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.analyzeBackgroundWorker_ProgressChanged);
            this._analyzeBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.analyzeBackgroundWorker_RunWorkerCompleted);
            // 
            // _saveFileDialog
            // 
            this._saveFileDialog.Filter = "Output (*.xls)|*.xls";
            this._saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // _articleTabControl
            // 
            this._articleTabControl.Location = new System.Drawing.Point(12, 140);
            this._articleTabControl.Name = "_articleTabControl";
            this._articleTabControl.SelectedIndex = 0;
            this._articleTabControl.Size = new System.Drawing.Size(1260, 164);
            this._articleTabControl.TabIndex = 39;
            // 
            // filterButton
            // 
            this.filterButton.Enabled = false;
            this.filterButton.Location = new System.Drawing.Point(93, 111);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 40;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Filter = "ION PGM Output (*.csv, *.xls)|*.xls; *.csv";
            this._openFileDialog.FilterIndex = 2;
            this._openFileDialog.InitialDirectory = "c:\\";
            this._openFileDialog.RestoreDirectory = true;
            this._openFileDialog.Title = "Open XLS";
            // 
            // _articlesBackgroundWorker
            // 
            this._articlesBackgroundWorker.WorkerReportsProgress = true;
            this._articlesBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._articlesBackgroundWorker_DoWork);
            this._articlesBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._articlesBackgroundWorker_ProgressChanged);
            this._articlesBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._articlesBackgroundWorker_RunWorkerCompleted);
            // 
            // progressBarLabel
            // 
            this.progressBarLabel.AutoSize = true;
            this.progressBarLabel.Location = new System.Drawing.Point(278, 27);
            this.progressBarLabel.Name = "progressBarLabel";
            this.progressBarLabel.Size = new System.Drawing.Size(43, 13);
            this.progressBarLabel.TabIndex = 41;
            this.progressBarLabel.Text = "Status: ";
            // 
            // _patientMutationListBox
            // 
            this._patientMutationListBox.FormattingEnabled = true;
            this._patientMutationListBox.Location = new System.Drawing.Point(13, 347);
            this._patientMutationListBox.Name = "_patientMutationListBox";
            this._patientMutationListBox.Size = new System.Drawing.Size(308, 212);
            this._patientMutationListBox.TabIndex = 42;
            // 
            // _idTextBox
            // 
            this._idTextBox.Location = new System.Drawing.Point(345, 332);
            this._idTextBox.Name = "_idTextBox";
            this._idTextBox.Size = new System.Drawing.Size(100, 20);
            this._idTextBox.TabIndex = 43;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(342, 316);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 44;
            this.idLabel.Text = "ID";
            // 
            // _firstNameLabel
            // 
            this._firstNameLabel.AutoSize = true;
            this._firstNameLabel.Location = new System.Drawing.Point(342, 355);
            this._firstNameLabel.Name = "_firstNameLabel";
            this._firstNameLabel.Size = new System.Drawing.Size(57, 13);
            this._firstNameLabel.TabIndex = 46;
            this._firstNameLabel.Text = "First Name";
            // 
            // _firstNameTextBox
            // 
            this._firstNameTextBox.Location = new System.Drawing.Point(345, 371);
            this._firstNameTextBox.Name = "_firstNameTextBox";
            this._firstNameTextBox.Size = new System.Drawing.Size(100, 20);
            this._firstNameTextBox.TabIndex = 45;
            // 
            // _lastNameLabel
            // 
            this._lastNameLabel.AutoSize = true;
            this._lastNameLabel.Location = new System.Drawing.Point(342, 394);
            this._lastNameLabel.Name = "_lastNameLabel";
            this._lastNameLabel.Size = new System.Drawing.Size(58, 13);
            this._lastNameLabel.TabIndex = 48;
            this._lastNameLabel.Text = "Last Name";
            // 
            // _lastNameTextBox
            // 
            this._lastNameTextBox.Location = new System.Drawing.Point(345, 410);
            this._lastNameTextBox.Name = "_lastNameTextBox";
            this._lastNameTextBox.Size = new System.Drawing.Size(100, 20);
            this._lastNameTextBox.TabIndex = 47;
            // 
            // _pathologicalNoLabel
            // 
            this._pathologicalNoLabel.AutoSize = true;
            this._pathologicalNoLabel.Location = new System.Drawing.Point(342, 433);
            this._pathologicalNoLabel.Name = "_pathologicalNoLabel";
            this._pathologicalNoLabel.Size = new System.Drawing.Size(82, 13);
            this._pathologicalNoLabel.TabIndex = 50;
            this._pathologicalNoLabel.Text = "Pathological No";
            // 
            // _pathologicalNoTextBox
            // 
            this._pathologicalNoTextBox.Location = new System.Drawing.Point(345, 449);
            this._pathologicalNoTextBox.Name = "_pathologicalNoTextBox";
            this._pathologicalNoTextBox.Size = new System.Drawing.Size(100, 20);
            this._pathologicalNoTextBox.TabIndex = 49;
            // 
            // _runNoLabel
            // 
            this._runNoLabel.AutoSize = true;
            this._runNoLabel.Location = new System.Drawing.Point(342, 472);
            this._runNoLabel.Name = "_runNoLabel";
            this._runNoLabel.Size = new System.Drawing.Size(44, 13);
            this._runNoLabel.TabIndex = 52;
            this._runNoLabel.Text = "Run No";
            // 
            // _runNoTextBox
            // 
            this._runNoTextBox.Location = new System.Drawing.Point(345, 488);
            this._runNoTextBox.Name = "_runNoTextBox";
            this._runNoTextBox.Size = new System.Drawing.Size(100, 20);
            this._runNoTextBox.TabIndex = 51;
            // 
            // _tumourSiteLabel
            // 
            this._tumourSiteLabel.AutoSize = true;
            this._tumourSiteLabel.Location = new System.Drawing.Point(342, 511);
            this._tumourSiteLabel.Name = "_tumourSiteLabel";
            this._tumourSiteLabel.Size = new System.Drawing.Size(64, 13);
            this._tumourSiteLabel.TabIndex = 54;
            this._tumourSiteLabel.Text = "Tomour Site";
            // 
            // _tumourSiteTextBox
            // 
            this._tumourSiteTextBox.Location = new System.Drawing.Point(345, 527);
            this._tumourSiteTextBox.Name = "_tumourSiteTextBox";
            this._tumourSiteTextBox.Size = new System.Drawing.Size(100, 20);
            this._tumourSiteTextBox.TabIndex = 53;
            // 
            // _diseaseLevelTextBox
            // 
            this._diseaseLevelTextBox.Location = new System.Drawing.Point(451, 332);
            this._diseaseLevelTextBox.Name = "_diseaseLevelTextBox";
            this._diseaseLevelTextBox.Size = new System.Drawing.Size(161, 59);
            this._diseaseLevelTextBox.TabIndex = 55;
            this._diseaseLevelTextBox.Text = "";
            // 
            // _diseaseLevelLabel
            // 
            this._diseaseLevelLabel.AutoSize = true;
            this._diseaseLevelLabel.Location = new System.Drawing.Point(448, 316);
            this._diseaseLevelLabel.Name = "_diseaseLevelLabel";
            this._diseaseLevelLabel.Size = new System.Drawing.Size(74, 13);
            this._diseaseLevelLabel.TabIndex = 56;
            this._diseaseLevelLabel.Text = "Disease Level";
            // 
            // _backgroundLabel
            // 
            this._backgroundLabel.AutoSize = true;
            this._backgroundLabel.Location = new System.Drawing.Point(448, 394);
            this._backgroundLabel.Name = "_backgroundLabel";
            this._backgroundLabel.Size = new System.Drawing.Size(65, 13);
            this._backgroundLabel.TabIndex = 58;
            this._backgroundLabel.Text = "Background";
            // 
            // _backgroundTextBox
            // 
            this._backgroundTextBox.Location = new System.Drawing.Point(451, 410);
            this._backgroundTextBox.Name = "_backgroundTextBox";
            this._backgroundTextBox.Size = new System.Drawing.Size(161, 137);
            this._backgroundTextBox.TabIndex = 57;
            this._backgroundTextBox.Text = "";
            // 
            // _previousTreatmentLabel
            // 
            this._previousTreatmentLabel.AutoSize = true;
            this._previousTreatmentLabel.Location = new System.Drawing.Point(615, 316);
            this._previousTreatmentLabel.Name = "_previousTreatmentLabel";
            this._previousTreatmentLabel.Size = new System.Drawing.Size(99, 13);
            this._previousTreatmentLabel.TabIndex = 60;
            this._previousTreatmentLabel.Text = "Previous Treatment";
            // 
            // _previousTreatmentTextBox
            // 
            this._previousTreatmentTextBox.Location = new System.Drawing.Point(618, 332);
            this._previousTreatmentTextBox.Name = "_previousTreatmentTextBox";
            this._previousTreatmentTextBox.Size = new System.Drawing.Size(210, 215);
            this._previousTreatmentTextBox.TabIndex = 59;
            this._previousTreatmentTextBox.Text = "";
            // 
            // _currentTreatmentLabel
            // 
            this._currentTreatmentLabel.AutoSize = true;
            this._currentTreatmentLabel.Location = new System.Drawing.Point(831, 316);
            this._currentTreatmentLabel.Name = "_currentTreatmentLabel";
            this._currentTreatmentLabel.Size = new System.Drawing.Size(92, 13);
            this._currentTreatmentLabel.TabIndex = 62;
            this._currentTreatmentLabel.Text = "Current Treatment";
            // 
            // _currentTreatmentTextBox
            // 
            this._currentTreatmentTextBox.Location = new System.Drawing.Point(834, 332);
            this._currentTreatmentTextBox.Name = "_currentTreatmentTextBox";
            this._currentTreatmentTextBox.Size = new System.Drawing.Size(213, 215);
            this._currentTreatmentTextBox.TabIndex = 61;
            this._currentTreatmentTextBox.Text = "";
            // 
            // _coclusionsLabel
            // 
            this._coclusionsLabel.AutoSize = true;
            this._coclusionsLabel.Location = new System.Drawing.Point(1050, 316);
            this._coclusionsLabel.Name = "_coclusionsLabel";
            this._coclusionsLabel.Size = new System.Drawing.Size(64, 13);
            this._coclusionsLabel.TabIndex = 64;
            this._coclusionsLabel.Text = "Conclusions";
            // 
            // _conclusionsTextBox1
            // 
            this._conclusionsTextBox1.Location = new System.Drawing.Point(1053, 332);
            this._conclusionsTextBox1.Name = "_conclusionsTextBox1";
            this._conclusionsTextBox1.Size = new System.Drawing.Size(213, 215);
            this._conclusionsTextBox1.TabIndex = 63;
            this._conclusionsTextBox1.Text = "";
            // 
            // _loadPatientButton
            // 
            this._loadPatientButton.Location = new System.Drawing.Point(12, 316);
            this._loadPatientButton.Name = "_loadPatientButton";
            this._loadPatientButton.Size = new System.Drawing.Size(111, 23);
            this._loadPatientButton.TabIndex = 65;
            this._loadPatientButton.Text = "Load Patient";
            this._loadPatientButton.UseVisualStyleBackColor = true;
            // 
            // _savePatientButton
            // 
            this._savePatientButton.Location = new System.Drawing.Point(129, 316);
            this._savePatientButton.Name = "_savePatientButton";
            this._savePatientButton.Size = new System.Drawing.Size(111, 23);
            this._savePatientButton.TabIndex = 66;
            this._savePatientButton.Text = "Save Patient";
            this._savePatientButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 585);
            this.Controls.Add(this._savePatientButton);
            this.Controls.Add(this._loadPatientButton);
            this.Controls.Add(this._coclusionsLabel);
            this.Controls.Add(this._conclusionsTextBox1);
            this.Controls.Add(this._currentTreatmentLabel);
            this.Controls.Add(this._currentTreatmentTextBox);
            this.Controls.Add(this._previousTreatmentLabel);
            this.Controls.Add(this._previousTreatmentTextBox);
            this.Controls.Add(this._backgroundLabel);
            this.Controls.Add(this._backgroundTextBox);
            this.Controls.Add(this._diseaseLevelLabel);
            this.Controls.Add(this._diseaseLevelTextBox);
            this.Controls.Add(this._tumourSiteLabel);
            this.Controls.Add(this._tumourSiteTextBox);
            this.Controls.Add(this._runNoLabel);
            this.Controls.Add(this._runNoTextBox);
            this.Controls.Add(this._pathologicalNoLabel);
            this.Controls.Add(this._pathologicalNoTextBox);
            this.Controls.Add(this._lastNameLabel);
            this.Controls.Add(this._lastNameTextBox);
            this.Controls.Add(this._firstNameLabel);
            this.Controls.Add(this._firstNameTextBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this._idTextBox);
            this.Controls.Add(this._patientMutationListBox);
            this.Controls.Add(this.progressBarLabel);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this._articleTabControl);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.Xls2Button);
            this.Controls.Add(this.Xls1Button);
            this.Controls.Add(this.xls1TextBox);
            this.Controls.Add(this.xls2TextBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this.getArticlesButton);
            this.Controls.Add(this._menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automation";
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button getArticlesButton;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox xls2TextBox;
        private System.Windows.Forms.TextBox xls1TextBox;
        private System.Windows.Forms.Button Xls1Button;
        private System.Windows.Forms.Button Xls2Button;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Button saveButton;
        private System.ComponentModel.BackgroundWorker _analyzeBackgroundWorker;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.TabControl _articleTabControl;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.ComponentModel.BackgroundWorker _articlesBackgroundWorker;
        private System.Windows.Forms.Label progressBarLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox _patientMutationListBox;
        private System.Windows.Forms.TextBox _idTextBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label _firstNameLabel;
        private System.Windows.Forms.TextBox _firstNameTextBox;
        private System.Windows.Forms.Label _lastNameLabel;
        private System.Windows.Forms.TextBox _lastNameTextBox;
        private System.Windows.Forms.Label _pathologicalNoLabel;
        private System.Windows.Forms.TextBox _pathologicalNoTextBox;
        private System.Windows.Forms.Label _runNoLabel;
        private System.Windows.Forms.TextBox _runNoTextBox;
        private System.Windows.Forms.Label _tumourSiteLabel;
        private System.Windows.Forms.TextBox _tumourSiteTextBox;
        private System.Windows.Forms.RichTextBox _diseaseLevelTextBox;
        private System.Windows.Forms.Label _diseaseLevelLabel;
        private System.Windows.Forms.Label _backgroundLabel;
        private System.Windows.Forms.RichTextBox _backgroundTextBox;
        private System.Windows.Forms.Label _previousTreatmentLabel;
        private System.Windows.Forms.RichTextBox _previousTreatmentTextBox;
        private System.Windows.Forms.Label _currentTreatmentLabel;
        private System.Windows.Forms.RichTextBox _currentTreatmentTextBox;
        private System.Windows.Forms.Label _coclusionsLabel;
        private System.Windows.Forms.RichTextBox _conclusionsTextBox1;
        private System.Windows.Forms.Button _loadPatientButton;
        private System.Windows.Forms.Button _savePatientButton;
    }
}

