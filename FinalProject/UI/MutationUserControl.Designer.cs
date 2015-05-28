namespace FinalProject.UI
{
    partial class MutationUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mutationDataGridView = new System.Windows.Forms.DataGridView();
            this.chromosomeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.geneNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strandCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refCodonCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varCodonCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refAACol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varAACol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aaNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdsNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cosmicNamesCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numOfShowsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyCol = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mutationDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mutationDataGridView
            // 
            this.mutationDataGridView.AllowUserToAddRows = false;
            this.mutationDataGridView.AllowUserToDeleteRows = false;
            this.mutationDataGridView.AllowUserToResizeColumns = false;
            this.mutationDataGridView.AllowUserToResizeRows = false;
            this.mutationDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mutationDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.mutationDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mutationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mutationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chromosomeCol,
            this.positionCol,
            this.geneNameCol,
            this.refCol,
            this.varCol,
            this.strandCol,
            this.refCodonCol,
            this.varCodonCol,
            this.refAACol,
            this.varAACol,
            this.aaNameCol,
            this.cdsNameCol,
            this.cosmicNamesCol,
            this.numOfShowsCol,
            this.historyCol});
            this.mutationDataGridView.Location = new System.Drawing.Point(3, 0);
            this.mutationDataGridView.MultiSelect = false;
            this.mutationDataGridView.Name = "mutationDataGridView";
            this.mutationDataGridView.ReadOnly = true;
            this.mutationDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mutationDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mutationDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mutationDataGridView.Size = new System.Drawing.Size(1245, 188);
            this.mutationDataGridView.TabIndex = 0;
            // 
            // chromosomeCol
            // 
            this.chromosomeCol.HeaderText = "Chromosome";
            this.chromosomeCol.Name = "chromosomeCol";
            this.chromosomeCol.ReadOnly = true;
            // 
            // positionCol
            // 
            this.positionCol.HeaderText = "Position";
            this.positionCol.Name = "positionCol";
            this.positionCol.ReadOnly = true;
            // 
            // geneNameCol
            // 
            this.geneNameCol.HeaderText = "Gene Name";
            this.geneNameCol.Name = "geneNameCol";
            this.geneNameCol.ReadOnly = true;
            // 
            // refCol
            // 
            this.refCol.HeaderText = "Ref";
            this.refCol.Name = "refCol";
            this.refCol.ReadOnly = true;
            // 
            // varCol
            // 
            this.varCol.HeaderText = "Var";
            this.varCol.Name = "varCol";
            this.varCol.ReadOnly = true;
            // 
            // strandCol
            // 
            this.strandCol.HeaderText = "Strand";
            this.strandCol.Name = "strandCol";
            this.strandCol.ReadOnly = true;
            // 
            // refCodonCol
            // 
            this.refCodonCol.HeaderText = "Ref Codon";
            this.refCodonCol.Name = "refCodonCol";
            this.refCodonCol.ReadOnly = true;
            // 
            // varCodonCol
            // 
            this.varCodonCol.HeaderText = "Var Codon";
            this.varCodonCol.Name = "varCodonCol";
            this.varCodonCol.ReadOnly = true;
            // 
            // refAACol
            // 
            this.refAACol.HeaderText = "Ref AA";
            this.refAACol.Name = "refAACol";
            this.refAACol.ReadOnly = true;
            // 
            // varAACol
            // 
            this.varAACol.HeaderText = "Var AA";
            this.varAACol.Name = "varAACol";
            this.varAACol.ReadOnly = true;
            // 
            // aaNameCol
            // 
            this.aaNameCol.HeaderText = "AA Name";
            this.aaNameCol.Name = "aaNameCol";
            this.aaNameCol.ReadOnly = true;
            // 
            // cdsNameCol
            // 
            this.cdsNameCol.HeaderText = "CDS Name";
            this.cdsNameCol.Name = "cdsNameCol";
            this.cdsNameCol.ReadOnly = true;
            // 
            // cosmicNamesCol
            // 
            this.cosmicNamesCol.HeaderText = "Cosmic Names";
            this.cosmicNamesCol.Name = "cosmicNamesCol";
            this.cosmicNamesCol.ReadOnly = true;
            // 
            // numOfShowsCol
            // 
            this.numOfShowsCol.HeaderText = "Shows";
            this.numOfShowsCol.MinimumWidth = 20;
            this.numOfShowsCol.Name = "numOfShowsCol";
            this.numOfShowsCol.ReadOnly = true;
            // 
            // historyCol
            // 
            this.historyCol.HeaderText = "History";
            this.historyCol.Name = "historyCol";
            this.historyCol.ReadOnly = true;
            this.historyCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MutationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mutationDataGridView);
            this.Name = "MutationUserControl";
            this.Size = new System.Drawing.Size(1251, 192);
            ((System.ComponentModel.ISupportInitialize)(this.mutationDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView mutationDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn chromosomeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn geneNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn refCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn varCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn strandCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn refCodonCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn varCodonCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn refAACol;
        private System.Windows.Forms.DataGridViewTextBoxColumn varAACol;
        private System.Windows.Forms.DataGridViewTextBoxColumn aaNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdsNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cosmicNamesCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn numOfShowsCol;
        private System.Windows.Forms.DataGridViewLinkColumn historyCol;
    }
}
