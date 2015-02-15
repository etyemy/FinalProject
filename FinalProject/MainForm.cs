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
        enum XlsMinPlace { Chrom = 0, Position, GeneName, Ref, Var };
        private XLSHandler _xls1Handler = null;
        private XLSHandler _xls2Handler = null;
        private CosmicWebService _cosmicWebService;
        private string _xls1Path = null;
        private string _xls2Path = null;
        private List<Mutation> _mutatioList = null;
        private UcscBL _ucscBL;
        public MainForm()
        {
            _cosmicWebService = new CosmicWebService();
            _ucscBL = new UcscBL();
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
            _xls1Path = getFilePath();
            if (_xls1Path != null)
            {
                _xls1Handler = new XLSHandler(_xls1Path);
            }
                
        }

        private void Xls2Button_Click(object sender, EventArgs e)
        {
            _xls2Path = getFilePath();
            if (_xls2Path != null)
            {
                _xls2Handler = new XLSHandler(_xls2Path);
            }
               
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            _mutatioList = new List<Mutation>();
            Boolean startAnalyze = false;
            if (_xls1Path == null && _xls2Path == null)
            {
                MessageBox.Show("No files selected", "Error");
            }
            else if (_xls1Path == null ^ _xls2Path == null)
            {
                DialogResult result1 = MessageBox.Show("Only one file selected, Continue?", "Notice", MessageBoxButtons.YesNo);

                if (result1 == DialogResult.Yes)
                {
                    XLSHandler temp;
                    if (_xls2Path == null)
                        temp = _xls1Handler;
                    else
                        temp = _xls2Handler;
                    addToMutationList(temp, 1);
                    startAnalyze = true;
                }
            }
            else
            {
                addToMutationList(_xls1Handler, 1);
                addToMutationList(_xls2Handler, 2);
                startAnalyze = true;
            }
            if (startAnalyze)
            {
                analyzeButton.Enabled = false;
                _analyzeBackgroundWorker.RunWorkerAsync();
            }
                
        }
        private void addToMutationList(XLSHandler xlsHandler, int p)
        {
            foreach (string[] s in xlsHandler.XlsMin)
            {
                Mutation m = new Mutation(s[(int)XlsMinPlace.Chrom], Convert.ToInt32(s[(int)XlsMinPlace.Position]), s[(int)XlsMinPlace.GeneName], s[(int)XlsMinPlace.Ref][0], s[(int)XlsMinPlace.Var][0]);
                Boolean found = false;
                foreach (Mutation n in _mutatioList)
                {
                    if (n.Equals(m))
                    {
                        if (p == 2)
                            n.NumOfShows = 2;
                        found = true;
                        break;
                    }
                }
                if (!found)
                    _mutatioList.Add(m);
            }
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
                        string tsvString = _cosmicWebService.getTsvFromCosmic(m.getCosmicNum());
                        string[] tsvLines = tsvString.Split('\n');
                        TSVHandler tsvHandler = new TSVHandler(tsvString);
                        articlesTabControl.TabPages.Add(new ArticleTabPage(new ArticlesForm(tsvHandler, m.CosmicName)));
                    }
                }
            }
            else
            {
                toolStripStatusLabel2.Text = "Failed to log in. Check cosmic email and password in settings and/or check internet connection";
            }
        }
        
        
        private void analyzeBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            for (int i = 0; i < _mutatioList.Count; i++)
            {
                try
                {
                    _mutatioList.ElementAt(i).extractExtraData(_ucscBL);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.ToString());
                }
                finally
                {
                    _analyzeBackgroundWorker.ReportProgress(((100 / (_mutatioList.Count - 1)) * i));
                }
            }
            _analyzeBackgroundWorker.ReportProgress(100);

        }
        private void analyzeBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void analyzeBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            analyzeButton.Enabled = true;
            getArticlesButton.Enabled = true;
            saveButton.Enabled = true;
        }

        private string getFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open XLS";
            openFileDialog.InitialDirectory = @"c:\";
            openFileDialog.Filter = "ION PGM Output (*.xls)|*.xls";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
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
            
            _saveFileDialog.Filter = "Output (*.xls)|*.xls";
            _saveFileDialog.ShowDialog();

        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string name = _saveFileDialog.FileName;
            if (File.Exists(name))
                File.Delete(name);

            StreamWriter writer = new StreamWriter(name);
            writer.WriteLine("Chrom\tPosition\tGene Name\tRef\tVar\tStrand\tRef Codon\tVar Codon\tRef AA\tVar AA\tCDS Mutation\tAA Mutation\tCosmic Name\tShows");
            foreach(Mutation m in _mutatioList)
            {
                writer.WriteLine(m.PrintXLSLine());
            }
            
            writer.Close();
        }

        

    }
}
