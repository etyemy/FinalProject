using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FinalProject.UI
{
    public partial class InfoAnalyzeUserControl : UserControl
    {
        enum XlsMinPlace { Chrom = 0, Position, GeneName, Ref, Var, NumOfShows };
        private XLSHandler _xls1Handler = null;
        private XLSHandler _xls2Handler = null;
        private string _xls1Path = null;
        private string _xls2Path = null;
        private List<Mutation> _mutationList = null;
        private MainBL _mainBL;
        List<string[]> _mutationsDetailsList = null;
        private MainForm _mainForm;
        public InfoAnalyzeUserControl(MainForm mainForm)
        {
            _mainForm = mainForm;
            _mainBL = mainForm.MainBL;
            InitializeComponent();
        }

        private void LoadXlsButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string tempPath = null, fileName; ;
            TextBox tempTextBox = null;
            string[] tempStringArray;
            if (clickedButton == null) // just to be on the safe side
                return;

            if (clickedButton == Xls1Button)
            {
                _xls1Path = getFilePath();
                tempPath = _xls1Path;
                tempTextBox = xls1TextBox;
            }
            else if (clickedButton == Xls2Button)
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
                    MessageBox.Show("Same File Selected.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                    
                }
                else
                {
                    tempTextBox.Text = fileName;
                    if (clickedButton == Xls1Button)
                        _xls1Handler = new XLSHandler(tempPath);
                    else if (clickedButton == Xls2Button)
                        _xls2Handler = new XLSHandler(tempPath);
                }
            }
        }

        private string getFilePath()
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return _openFileDialog.FileName;
            }
            return null;
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            Boolean startAnalyze = false;
            if (_xls1Path == null && _xls2Path == null)
            {
                MessageBox.Show("No files selected.",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation,
                                  MessageBoxDefaultButton.Button1);
                    
              
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
                _mainForm.ArticlesUC.clearAll();
                _analyzeBackgroundWorker.RunWorkerAsync();
            }
        }
        private void analyzeBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _mutationList = new List<Mutation>();
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
                    Mutation tempMutation = _mainBL.getMutationByDetails(chrom, position, refNuc, varNuc);
                    if (tempMutation == null)
                    {
                        tempMutation = new Mutation(_mainBL, chrom, position, geneName, refNuc, varNuc);
                    }
                    tempMutation.NumOfShows = Convert.ToInt16(s[(int)XlsMinPlace.NumOfShows]);
                    _mutationList.Add(tempMutation);
                    _analyzeBackgroundWorker.ReportProgress(i);
                    i++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.ToString());
                }
            }
        }
        private void analyzeBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBarLabel.Text = "Status: Analyzing Line: " + (e.ProgressPercentage) + " of " + _mutationsDetailsList.Count;
            progressBar1.Value = (100 / _mutationsDetailsList.Count) * e.ProgressPercentage;
        }

        private void analyzeBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _mainForm.MutationList = _mutationList;
            _mainForm.MutationUC.clearAll();
            _mainForm.MutationUC.initTable(_mutationList);
            _mainForm.ArticlesUC.initArticleUC(_mutationList);
            _mainForm.PatientUC.clearAll();
            _mainForm.PatientUC.initPatientUC(_mutationList,generateTestName());
            progressBar1.Value = 100;
            progressBarLabel.Text += ", Complete!";
            analyzeButton.Enabled = true;
            
        }

        private string generateTestName()
        {
            string testName = "";
            string[] tempStringArray;
            string fileName;
            if(_xls1Path!=null)
            {
                tempStringArray = _xls1Path.Split('\\');
                fileName = tempStringArray[tempStringArray.Length - 1].Split('.')[0];
                testName += fileName;
                if (_xls2Path != null)
                    testName += "_";
            }
            if (_xls2Path != null)
            {
                tempStringArray = _xls2Path.Split('\\');
                fileName = tempStringArray[tempStringArray.Length - 1].Split('.')[0];
                testName +=  fileName;
            }
            return testName;
        }

        private List<string[]> intersectionLists(XLSHandler l1, XLSHandler l2)
        {
            bool twoFiles = true;
            List<string[]> toReturn = new List<string[]>();
            if (l1 == null ^ l2 == null)
            {
                twoFiles = false;
            }
            if (l1 != null)
                foreach (string[] s in l1.XlsMin)
                {
                    bool found = false;
                    foreach (string[] d in toReturn)
                    {
                        if (d[0].Equals(s[0]) && d[1].Equals(s[1]) && d[2].Equals(s[2]) && d[3].Equals(s[3]) && d[4].Equals(s[4]))
                        {
                            found = true;
                        }
                    }
                    if (!found)
                        toReturn.Add(s);
                }
            if (l2 != null)
                foreach (string[] s in l2.XlsMin)
                {
                    bool found = false;
                    foreach (string[] d in toReturn)
                    {
                        if (d[0].Equals(s[0]) && d[1].Equals(s[1]) && d[2].Equals(s[2]) && d[3].Equals(s[3]) && d[4].Equals(s[4]))
                        {
                            found = true;
                            if (twoFiles)
                                d[5] = "2";
                        }
                    }
                    if (!found)
                        toReturn.Add(s);
                }
            return toReturn;
        }
       
        public void clearAll()
        {
            _xls1Handler = null;
            _xls2Handler = null;
            _xls1Path = null;
            _xls2Path = null;
            _mutationList = null;
            _mutationsDetailsList = null;
            xls1TextBox.Text = "";
            xls2TextBox.Text = "";
            progressBarLabel.Text = "Status:";
            progressBar1.Value = 0;
        }
    }
}
