using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    class ArticleTabPage:TabPage
    {
        private List<Article> articleList;


        public ArticleTabPage(string tabName, List<Article> list)
        {
            this.Text = tabName;
            this.articleList = list;
            DataGridView dataGridView = new DataGridView();
            dataGridView.RowHeadersVisible = false;
            dataGridView.ReadOnly = true;
            dataGridView.DefaultCellStyle.SelectionBackColor = dataGridView.DefaultCellStyle.BackColor;
            dataGridView.DefaultCellStyle.SelectionForeColor = dataGridView.DefaultCellStyle.ForeColor;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            

            dataGridView.ColumnCount = 4;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;


            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Columns[0].HeaderText = "Title";
            dataGridView.Columns[1].HeaderText = "Journal";
            dataGridView.Columns[2].HeaderText = "Year";
            dataGridView.Columns[3].HeaderText = "Author";


            dataGridView.CellContentClick += dataGridView1_CellClick;
            foreach (Article a in list)
            {
                DataGridViewRow tempRow = (DataGridViewRow)dataGridView.Rows[0].Clone();
                tempRow.Cells[0] = new DataGridViewLinkCell();
                tempRow.Cells[0].Value = a.Title;
                tempRow.Cells[1].Value = a.Journal;
                tempRow.Cells[2].Value = a.Year;
                tempRow.Cells[3].Value = a.Author;
               
                dataGridView.Rows.Add(tempRow);
            }
            dataGridView.AllowUserToAddRows = false;

            this.Controls.Add(dataGridView);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                System.Diagnostics.Process.Start("http://www.ncbi.nlm.nih.gov/pubmed/" + articleList.ElementAt(e.RowIndex).PubMedID);
            }
                
        }
    }
}
