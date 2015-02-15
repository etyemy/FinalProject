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
            ArticlesGridView.ColumnCount = 6;
            ArticlesGridView.Columns[0].HeaderText = "Title";
            ArticlesGridView.Columns[1].HeaderText = "Author";
            ArticlesGridView.Columns[2].HeaderText = "Year";
            ArticlesGridView.Columns[3].HeaderText = "Journal";
            ArticlesGridView.Columns[4].HeaderText = "Cosmic ID";
            ArticlesGridView.Columns[5].HeaderText = "PubMed ID";

            ArticlesGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ArticlesGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ArticlesGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ArticlesGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;



            foreach(Article a in _filterdArticles)
            {
                DataGridViewRow tempRow =(DataGridViewRow)ArticlesGridView.Rows[0].Clone();
                tempRow.Cells[0].Value = a.Title;
                tempRow.Cells[1].Value = a.Author;
                tempRow.Cells[2].Value = a.Year;
                tempRow.Cells[3].Value = a.Journal;
                tempRow.Cells[4].Value = a.CosmicID;
                tempRow.Cells[5].Value = a.PubMedID;
                ArticlesGridView.Rows.Add(tempRow);
            }

        }
    }
}
