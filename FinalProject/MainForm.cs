using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{

    public partial class MainForm : Form
    {
        private XLSHandler _xlsHandler = null;
        private CosmicWebService _cosmicWebService;
        private string firstSelectedFile = null;
        private string secondSelectedFile = null;
        public MainForm()
        {
            _cosmicWebService = new CosmicWebService();
            //bool logedIn = _cosmicWebService.loginToCosmic(Properties.Settings.Default.CosmicEmail, Properties.Settings.Default.CosmicPassword);
            /*TODO
                 * 
                 * cosmic settings error messege
                 * 
                 */
            InitializeComponent();
        }

        private void loadXLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = getOpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                firstSelectedFile = fdlg.FileName;
                _xlsHandler = new XLSHandler(fdlg.FileName);
                try
                {
                    _xlsHandler.handle();
                }
                catch (Exception ex)
                {
                    if (ex is MySql.Data.MySqlClient.MySqlException)
                    {
                        MessageBox.Show("SQL Error");
                    }
                }
                if (_xlsHandler.CosmicMutation.Count != 0)
                {
                    foreach (Mutation m in _xlsHandler.CosmicMutation)
                    {
                    }
                    getArticlesButton.Enabled = true;
                }
            }
        }

        private void getArticlesButton_Click(object sender, EventArgs e)
        {
            bool logedIn = _cosmicWebService.loginToCosmic(Properties.Settings.Default.CosmicEmail, Properties.Settings.Default.CosmicPassword);
            /*TODO
             * 
             * cosmic settings error messege
             * 
             */
            if (_cosmicWebService.isLogedIn())
            {
                foreach (Mutation m in _xlsHandler.CosmicMutation)
                {
                    string tsvString = _cosmicWebService.getTsvFromCosmic(m.getCosmicNum());
                    string[] tsvLines = tsvString.Split('\n');
                    TSVHandler tsvHandler = new TSVHandler(tsvString);

                    articlesTabControl.TabPages.Add(new ArticleTabPage(new ArticlesForm(tsvHandler, m.CosmicName)));
                }
            }
            else
            {
                /*TODO
              * 
              * cosmic settings error messege
              * 
              */
            }

        }
        private OpenFileDialog getOpenFileDialog()
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "ION PGM Output (*.xls)|*.xls";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            return fdlg;
        }
        
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm f = new SettingForm();
            f.Show();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

       

    }
}
