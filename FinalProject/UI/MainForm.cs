using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FinalProject.FileHendlers;
using System.Runtime.InteropServices;

namespace FinalProject.UI
{
    public partial class MainForm : Form
    {
        private MainBL _mainBL;

        private InfoAnalyzeUserControl infoAnalyzeUserControl;
        private ArticlesUserControl articlesUserControl;
        private PatientUserControl patientUserControl;
        private MutationUserControl mutationUserControl;

        private List<Mutation> _mutationList;
        private Patient _currPatient;
        public MainForm()
        {
            InitializeComponent();
            _mainBL = new MainBL();
            infoAnalyzeUserControl = new InfoAnalyzeUserControl(this);
            articlesUserControl = new ArticlesUserControl(this);
            patientUserControl = new PatientUserControl(this);
            mutationUserControl = new MutationUserControl(this);

            this.Controls.Add(infoAnalyzeUserControl);
            this.Controls.Add(articlesUserControl);
            this.Controls.Add(patientUserControl);
            this.Controls.Add(mutationUserControl);

            mutationUserControl.Left = 5;
            infoAnalyzeUserControl.Left = 5;
            articlesUserControl.Left = 5;
            patientUserControl.Left = 5;

            infoAnalyzeUserControl.Top = 20;
            articlesUserControl.Top = 280;
            patientUserControl.Top = 465;
            mutationUserControl.Top = 80;

        }
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            SettingForm settingForm = new SettingForm(this);
            settingForm.Show();
        }
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mutationList = null;
            _currPatient = null;
            articlesUserControl.clearAll();
            infoAnalyzeUserControl.clearAll();
            patientUserControl.clearAll();
            mutationUserControl.clearAll();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public MainBL MainBL
        {
            get
            {
                return _mainBL;
            }

        }
        public InfoAnalyzeUserControl InfoAnalyzeUC
        {
            get
            {
                return infoAnalyzeUserControl;
            }
        }
        public ArticlesUserControl ArticlesUC
        {
            get
            {
                return articlesUserControl;
            }
        }
        public PatientUserControl PatientUC
        {
            get
            {
                return patientUserControl;
            }
        }
        public MutationUserControl MutationUC
        {
            get
            {
                return mutationUserControl;
            }
        }
        public Patient CurrPatient
        {
            get
            {
                return _currPatient;
            }
            set
            {
                _currPatient = value;
            }
        }
        public List<Mutation> MutationList
        {
            get
            {
                return _mutationList;
            }
            set
            {
                _mutationList = value;
            }
        }

        private void ExportMenuItem_Click(object sender, EventArgs e)
        {
            string path = Properties.Settings.Default.DocSavePath;
            ToolStripMenuItem clicked = sender as ToolStripMenuItem;
            string clickedName = clicked.Name;
            if (path.Equals(""))
                MessageBox.Show("Error, Please select directory to save in settings");
            else
            {

                if (clickedName.Equals("docxWithDetailsMenuItem") || clicked.Name.Equals("docxWithoutDetailsMenuItem"))
                {
                    if (_currPatient == null || _mutationList == null)
                    {
                        MessageBox.Show("No Details To Export");
                    }
                    else
                    {
                        bool includeDetails = false;
                        if (clickedName.Equals("includeDetailsMenuItem"))
                        {
                            includeDetails = true;
                        }
                        try
                        {
                            DOCExportHandler.saveDOC(_currPatient, _mutationList, includeDetails, Properties.Settings.Default.DocSavePath);

                        }
                        catch (COMException)
                        {
                            MessageBox.Show("File Allready Open, Close And Try Again");
                        }

                    }
                }
                else if(clickedName.Equals("xlsxMutationMenuItem"))
                {
                    if (_mutationList == null)
                    {
                        MessageBox.Show("No Details To Export");
                    }
                    else
                    {
                        XLSExportHandler.saveXLS(patientUserControl.TestName,_mutationList);
                    }
                }




            }

        }
    }
}
