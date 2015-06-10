namespace FinalProject.UI
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
            this.clearAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeDetailsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontIncludeDetailsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1270, 24);
            this._menuStrip.TabIndex = 17;
            this._menuStrip.Text = "MainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllMenuItem,
            this.exportMenuItem,
            this.toolStripSeparator1,
            this.settingMenuItem,
            this.exitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clearAllMenuItem
            // 
            this.clearAllMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearAllMenuItem.Name = "clearAllMenuItem";
            this.clearAllMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearAllMenuItem.Text = "Clear All";
            this.clearAllMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exportMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeDetailsMenuItem,
            this.dontIncludeDetailsMenuItem});
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportMenuItem.Text = "Export";
            // 
            // includeDetailsMenuItem
            // 
            this.includeDetailsMenuItem.Name = "includeDetailsMenuItem";
            this.includeDetailsMenuItem.Size = new System.Drawing.Size(179, 22);
            this.includeDetailsMenuItem.Text = "Include details";
            this.includeDetailsMenuItem.Click += new System.EventHandler(this.ExportMenuItem_Click);
            // 
            // dontIncludeDetailsMenuItem
            // 
            this.dontIncludeDetailsMenuItem.Name = "dontIncludeDetailsMenuItem";
            this.dontIncludeDetailsMenuItem.Size = new System.Drawing.Size(179, 22);
            this.dontIncludeDetailsMenuItem.Text = "Dont include details";
            this.dontIncludeDetailsMenuItem.Click += new System.EventHandler(this.ExportMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // settingMenuItem
            // 
            this.settingMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingMenuItem.Name = "settingMenuItem";
            this.settingMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingMenuItem.Text = "Setting";
            this.settingMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 662);
            this.Controls.Add(this._menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoAnalyze";
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeDetailsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontIncludeDetailsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

    }
}