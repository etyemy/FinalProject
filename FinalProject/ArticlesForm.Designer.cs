namespace FinalProject
{
    partial class ArticlesForm
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
            this.articlesMainPanael = new System.Windows.Forms.Panel();
            this.ArticlesGridView = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Journal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CosmicID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PubMedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articlesMainPanael.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArticlesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // articlesMainPanael
            // 
            this.articlesMainPanael.Controls.Add(this.ArticlesGridView);
            this.articlesMainPanael.Dock = System.Windows.Forms.DockStyle.Fill;
            this.articlesMainPanael.Location = new System.Drawing.Point(0, 0);
            this.articlesMainPanael.Name = "articlesMainPanael";
            this.articlesMainPanael.Size = new System.Drawing.Size(920, 309);
            this.articlesMainPanael.TabIndex = 0;
            // 
            // ArticlesGridView
            // 
            this.ArticlesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArticlesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Author,
            this.Year,
            this.Journal,
            this.CosmicID,
            this.PubMedID});
            this.ArticlesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArticlesGridView.Location = new System.Drawing.Point(0, 0);
            this.ArticlesGridView.Name = "ArticlesGridView";
            this.ArticlesGridView.RowHeadersVisible = false;
            this.ArticlesGridView.Size = new System.Drawing.Size(920, 309);
            this.ArticlesGridView.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Author
            // 
            this.Author.HeaderText = "Author";
            this.Author.Name = "Author";
            // 
            // Year
            // 
            this.Year.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.Width = 54;
            // 
            // Journal
            // 
            this.Journal.HeaderText = "Journal";
            this.Journal.Name = "Journal";
            this.Journal.ReadOnly = true;
            // 
            // CosmicID
            // 
            this.CosmicID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CosmicID.HeaderText = "Cosmic ID";
            this.CosmicID.Name = "CosmicID";
            this.CosmicID.ReadOnly = true;
            this.CosmicID.Width = 80;
            // 
            // PubMedID
            // 
            this.PubMedID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PubMedID.HeaderText = "PubMed ID";
            this.PubMedID.Name = "PubMedID";
            this.PubMedID.ReadOnly = true;
            this.PubMedID.Width = 86;
            // 
            // ArticlesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 309);
            this.Controls.Add(this.articlesMainPanael);
            this.Name = "ArticlesForm";
            this.Text = "ArticlesForm";
            this.articlesMainPanael.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArticlesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel articlesMainPanael;
        private System.Windows.Forms.DataGridView ArticlesGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Journal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CosmicID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PubMedID;
    }
}