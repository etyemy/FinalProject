using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{

    public partial class MainForm : Form
    {
        private XLSHandler _xlsHandler = null;
        private CosmicWebService _cosmicWebService;
        public MainForm()
        {
            _cosmicWebService = new CosmicWebService();
            InitializeComponent();
        }

        private void loadXLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = getOpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                Log.Items.Add("Connection to RefGene Established.");
                _xlsHandler = new XLSHandler(fdlg.FileName);
                Log.Items.Add(fdlg.FileName + " Loaded.\n");
                Log.Items.Add("Analyzing xls File...");
                _xlsHandler.handle();
                Log.Items.Add("Found " + _xlsHandler.CosmicMutation.Count + " Interesting Mutations:");
                foreach (Mutation m in _xlsHandler.CosmicMutation)
                {
                    Log.Items.Add(m);
                }

                getArticlesButton.Enabled = true;
            }
            else
            {
                Log.Items.Add("Cancelled by user");
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
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logInButton.Enabled = false;
            bool logedIn = _cosmicWebService.loginToCosmic(emailTextBox.Text, passwordTextBox.Text);
            if (logedIn)
                loginMode();
            else
            {
                logoutMode();
                statusLabel.Text = "X Wrong Email or Password...";
            }

        }

        private void loginMode()
        {
            statusLabel.Text = "√";
            statusLabel.ForeColor = Color.Green;
            logInButton.Enabled = false;
            logOutButton.Enabled = true;
        }
        private void logoutMode()
        {
            statusLabel.Text = "X";
            statusLabel.ForeColor = Color.Red;
            logInButton.Enabled = true;
            logOutButton.Enabled = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            _cosmicWebService.logoutFromCosmic();
            logoutMode();
        }

        private void getArticlesButton_Click(object sender, EventArgs e)
        {

            if (_cosmicWebService.isLogedIn())
            {
                foreach (Mutation m in _xlsHandler.CosmicMutation)
                {
                    
                    TabPage tempPage = new TabPage(m.CosmicName);
                    
                    string tsvString = _cosmicWebService.getTsvFromCosmic(m.getCosmicNum());
                    string[] tsvLines = tsvString.Split('\n');
                    foreach(string s in tsvLines)
                    {
                        Label l = new Label();
                        l.Text = s;
                       
                        tempPage.Controls.Add(l);
                    }
                    tabControl1.TabPages.Add(tempPage);
                }
                getArticlesButton.Enabled = false;
            }
            else
            {
                ArticleEroorLabel.Text = "Login To Cosmic First...";
                ArticleEroorLabel.Visible = true;
            }

        }

    }
}
