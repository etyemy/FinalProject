using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject.UI
{
    public partial class MainForm : Form
    {
        private MainBL _mainBL;
        
        private InfoAnalyzeUserControl infoAnalyzeUserControl;
        private ArticlesUserControl articlesUserControl;
        private PatientUserControl patientUserControl;
        private MutationUserControl mutationUserControl;
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
            articlesUserControl.Top =280;
            patientUserControl.Top = 465;
            mutationUserControl.Top = 80;

        }
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            SettingForm settingForm = new SettingForm(this);
            settingForm.Show();
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

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            articlesUserControl.clearAll();
            infoAnalyzeUserControl.clearAll();
            patientUserControl.clearAll();
            mutationUserControl.clearAll();
        }
    }
}
