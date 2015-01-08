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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadXLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Log = new System.Windows.Forms.ListBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.logInButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.getArticlesButton = new System.Windows.Forms.Button();
            this.ArticleEroorLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1196, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadXLSToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadXLSToolStripMenuItem
            // 
            this.loadXLSToolStripMenuItem.Name = "loadXLSToolStripMenuItem";
            this.loadXLSToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.loadXLSToolStripMenuItem.Text = "Load XLS";
            this.loadXLSToolStripMenuItem.Click += new System.EventHandler(this.loadXLSToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // Log
            // 
            this.Log.FormattingEnabled = true;
            this.Log.HorizontalScrollbar = true;
            this.Log.Location = new System.Drawing.Point(27, 159);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(389, 225);
            this.Log.TabIndex = 1;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(117, 44);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(150, 20);
            this.emailTextBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Cosmic Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cosmic Password";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.statusLabel.ForeColor = System.Drawing.Color.Red;
            this.statusLabel.Location = new System.Drawing.Point(124, 133);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(15, 13);
            this.statusLabel.TabIndex = 21;
            this.statusLabel.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Connection Status:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(117, 70);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(150, 20);
            this.passwordTextBox.TabIndex = 18;
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(27, 96);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(55, 23);
            this.logInButton.TabIndex = 24;
            this.logInButton.Text = "Log In";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Enabled = false;
            this.logOutButton.Location = new System.Drawing.Point(97, 96);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(60, 23);
            this.logOutButton.TabIndex = 25;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(461, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(706, 314);
            this.tabControl1.TabIndex = 27;
            // 
            // getArticlesButton
            // 
            this.getArticlesButton.Enabled = false;
            this.getArticlesButton.Location = new System.Drawing.Point(461, 27);
            this.getArticlesButton.Name = "getArticlesButton";
            this.getArticlesButton.Size = new System.Drawing.Size(75, 23);
            this.getArticlesButton.TabIndex = 28;
            this.getArticlesButton.Text = "Get Articles";
            this.getArticlesButton.UseVisualStyleBackColor = true;
            this.getArticlesButton.Click += new System.EventHandler(this.getArticlesButton_Click);
            // 
            // ArticleEroorLabel
            // 
            this.ArticleEroorLabel.AutoSize = true;
            this.ArticleEroorLabel.Location = new System.Drawing.Point(552, 32);
            this.ArticleEroorLabel.Name = "ArticleEroorLabel";
            this.ArticleEroorLabel.Size = new System.Drawing.Size(0, 13);
            this.ArticleEroorLabel.TabIndex = 29;
            this.ArticleEroorLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 406);
            this.Controls.Add(this.ArticleEroorLabel);
            this.Controls.Add(this.getArticlesButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.logInButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadXLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ListBox Log;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button getArticlesButton;
        private System.Windows.Forms.Label ArticleEroorLabel;
    }
}

