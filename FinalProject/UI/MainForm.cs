using FinalProject.UI;
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
        enum XlsMinPlace { Chrom = 0, Position, GeneName, Ref, Var, NumOfShows };
        private XLSHandler _xls1Handler = null;
        private XLSHandler _xls2Handler = null;
        private CosmicWebService _cosmicWebService;
        private string _xls1Path = null;
        private string _xls2Path = null;
        private List<Mutation> _mutatioList = null;
        private MainBL _mainBL;
        private int _progressBarCounter = 1;
        List<string[]> _mutationsDetailsList = null;
        public MainForm()
        {
            _cosmicWebService = new CosmicWebService();
            _mainBL = new MainBL();
            InitializeComponent();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            SettingForm settingForm = new SettingForm(this);
            settingForm.Show();
        }
        private void Xls1Button_Click(object sender, EventArgs e)
        {
            xlsButtonPressed(1);
        }

        private void Xls2Button_Click(object sender, EventArgs e)
        {
            xlsButtonPressed(2);
        }

        private void xlsButtonPressed(int buttonId)
        {
            string tempPath = null, fileName; ;
            TextBox tempTextBox = null;
            string[] tempStringArray;
            if (buttonId == 1)
            {
                _xls1Path = getFilePath();
                tempPath = _xls1Path;
                tempTextBox = xls1TextBox;

            }
            else if (buttonId == 2)
            {
                _xls2Path = getFilePath();
                tempPath = _xls2Path;
                tempTextBox = xls2TextBox;
            }

            if (tempPath != null)
            {
                tempStringArray = tempPath.Split('\\');
                fileName = tempStringArray[tempStringArray.Length - 1];

                if (_xls2Path == _xls1Path)
                {
                    MessageBox.Show("Same File Selected", "Error");
                }
                else
                {
                    tempTextBox.Text = fileName;
                    if (buttonId == 1)
                        _xls1Handler = new XLSHandler(tempPath);
                    else if (buttonId == 2)
                        _xls2Handler = new XLSHandler(tempPath);
                }
            }
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            Boolean startAnalyze = false;
            if (_xls1Path == null && _xls2Path == null)
            {
                MessageBox.Show("No files selected", "Error");
            }
            else if (_xls1Path == null ^ _xls2Path == null)
            {
                if (MessageBox.Show("Only one file selected, Continue?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    startAnalyze = true;
                }
            }
            else
            {
                startAnalyze = true;
            }
            if (startAnalyze)
            {
                _mutationsDetailsList = intersectionLists(_xls1Handler, _xls2Handler);
                analyzeButton.Enabled = false;
                _analyzeBackgroundWorker.RunWorkerAsync();
            }


        }
        private void analyzeBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _mutatioList = new List<Mutation>();
            int i = 1;
            foreach (string[] s in _mutationsDetailsList)
            {
                try
                {
                    string chrom = s[(int)XlsMinPlace.Chrom];
                    int position = Convert.ToInt32(s[(int)XlsMinPlace.Position]);
                    string geneName = s[(int)XlsMinPlace.GeneName];
                    char refNuc = s[(int)XlsMinPlace.Ref][0];
                    char varNuc = s[(int)XlsMinPlace.Var][0];
                    Mutation tempMutation = _mainBL.getMutation(chrom, position, refNuc, varNuc);

                    if (tempMutation == null)
                    {
                        tempMutation = new Mutation(_mainBL, chrom, position, geneName, refNuc, varNuc);

                    }
                    tempMutation.NumOfShows = Convert.ToInt16(s[(int)XlsMinPlace.NumOfShows]);
                    _mutatioList.Add(tempMutation);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.ToString());
                }
                finally
                {
                    _analyzeBackgroundWorker.ReportProgress(((100 / (_mutationsDetailsList.Count)) * i));

                    i++;
                }
            }
            _analyzeBackgroundWorker.ReportProgress(100);

        }
        private void analyzeBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBarLabel.Text = "Status: Analyzing Mutation: " + (_progressBarCounter) + " of " + _mutationsDetailsList.Count;
            if (e.ProgressPercentage != 100)
                _progressBarCounter++;
            progressBar1.Value = e.ProgressPercentage;
        }

        private void analyzeBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarLabel.Text += ", Complete!";
            analyzeButton.Enabled = true;
            getArticlesButton.Enabled = true;
            saveButton.Enabled = true;
        }

        private List<string[]> intersectionLists(XLSHandler l1, XLSHandler l2)
        {
            List<string[]> toReturn = new List<string[]>(l1.XlsMin);
            if (l1 == null ^ l2 == null)
            {
                if (_xls2Path == null)
                    toReturn = new List<string[]>(l1.XlsMin);
                else
                    toReturn = new List<string[]>(l2.XlsMin);
            }
            else
            {
                foreach (string[] s in l2.XlsMin)
                {
                    bool found = false;
                    foreach (string[] d in toReturn)
                    {
                        if (d[0].Equals(s[0]) && d[1].Equals(s[1]) && d[2].Equals(s[2]) && d[3].Equals(s[3]) && d[4].Equals(s[4]))
                        {
                            found = true;
                            d[5] = "2";
                        }
                    }
                    if (!found)
                        toReturn.Add(s);
                }
            }
            return toReturn;
        }
        private void getArticlesButton_Click(object sender, EventArgs e)
        {
            bool logedIn = _cosmicWebService.loginToCosmic(Properties.Settings.Default.CosmicEmail, Properties.Settings.Default.CosmicPassword, 5);

            if (_cosmicWebService.isLogedIn())
            {
                toolStripStatusLabel2.Text = "Successful";
                toolStripStatusLabel2.ForeColor = Color.Green;

                foreach (Mutation m in _mutatioList)
                {
                    if (m.CosmicName != null)
                    {

                        string tsvStringFromCosmic = _cosmicWebService.getTsvFromCosmic(m.getCosmicNum());
                        TSVHandler tsvHandler = new TSVHandler(tsvStringFromCosmic);
                        string tabName = m.TumourSite + " x" + m.NumOfShows;
                        ArticleTabPage p = new ArticleTabPage(tabName, tsvHandler.AllArticles);

                        _articleTabControl.TabPages.Add(p);
                    }
                }
                if (_articleTabControl.TabCount != 0)
                    filterButton.Enabled = true;
            }
            else
            {
                toolStripStatusLabel2.Text = "Failed to log in. Check cosmic email and password in settings and/or check internet connection";
            }
        }
        private void _articlesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void _articlesBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        private string getFilePath()
        {

            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return _openFileDialog.FileName;
            }
            return null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _saveFileDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string name = _saveFileDialog.FileName;
            if (File.Exists(name))
                File.Delete(name);

            StreamWriter writer = new StreamWriter(name);
            writer.WriteLine("Chrom\tPosition\tGene Name\tRef\tVar\tStrand\tRef Codon\tVar Codon\tRef AA\tVar AA\tCDS Mutation\tAA Mutation\tCosmic Name\tShows");
            foreach (Mutation m in _mutatioList)
            {
                writer.WriteLine(m.PrintXLSLine());
            }

            writer.Close();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            FilterArticlesForm filterArticleForm = new FilterArticlesForm(this,((ArticleTabPage)_articleTabControl.SelectedTab));
            filterArticleForm.Show();
        }





    }
}
