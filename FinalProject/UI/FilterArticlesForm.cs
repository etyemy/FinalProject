using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject.UI
{
    public partial class FilterArticlesForm : Form
    {
        private MainForm mainForm;
        private ArticleTabPage articleTabPage;
       
        public FilterArticlesForm(MainForm mainForm, ArticleTabPage articleTabPage)
        {
            
            this.mainForm = mainForm;
            this.articleTabPage = articleTabPage;
            Dictionary<string, bool> dictionary = articleTabPage.getJournalToView();
            InitializeComponent();

            foreach (KeyValuePair<string, bool> entry in dictionary)
            {

                journalCheckedListBox.Items.Add(entry.Key,entry.Value);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Dictionary<string,bool> dic=articleTabPage.getJournalToView();
            for(int i=0;i<journalCheckedListBox.Items.Count;i++)
            {
                   string str = (string)journalCheckedListBox.Items[i];
                   dic[str]=journalCheckedListBox.GetItemChecked(i);
            }
            
            articleTabPage.filterTable();
            mainForm.Enabled = true;
            this.Close();
        }

        private void checkNoneButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < journalCheckedListBox.Items.Count; i++)
            {
                journalCheckedListBox.SetItemChecked(i, false);
            }
        }

        private void checkAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < journalCheckedListBox.Items.Count; i++)
            {
                journalCheckedListBox.SetItemChecked(i, true);
            }
        }

       
    }
}
