using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class ArticlesForm : ArticleFormPage
    {
        private List<Article> _allArticles;
        private List<Article> _filterdArticles;
        public ArticlesForm(TSVHandler tsvHandler,string cosmicName)
        {
            
            InitializeComponent();
            this.pnl = panel1;
            this.Text = cosmicName;
            _allArticles = tsvHandler.AllArticles;
            _filterdArticles = new List<Article>(tsvHandler.AllArticles);
            dataGridView1.ColumnCount = 6;
            foreach(Article a in _filterdArticles)
            {
                DataGridViewRow tempRow =(DataGridViewRow)dataGridView1.Rows[0].Clone();
                tempRow.Cells[0].Value = a.Title;
                tempRow.Cells[1].Value = a.Author;
                tempRow.Cells[2].Value = a.Year;
                tempRow.Cells[3].Value = a.Journal;
                tempRow.Cells[4].Value = a.CosmicID;
                tempRow.Cells[5].Value = a.PubMedID;
                dataGridView1.Rows.Add(tempRow);
            }

        }
    }
}
