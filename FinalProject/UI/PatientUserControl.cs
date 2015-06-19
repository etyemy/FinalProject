using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject.UI
{
    public partial class PatientUserControl : UserControl
    {
        MainForm _mainForm;
        MainBL _mainBL;
        List<Mutation> _mutationList = null;
        Patient _patient;
        string testNmae;
        public PatientUserControl(MainForm mainForm)
        {
            _mainForm = mainForm;
            _mainBL = mainForm.MainBL;
            InitializeComponent();
        }
        public PatientUserControl(Patient p)
        {
            InitializeComponent();
            loadPatientDetails(p,false);
            PatientButtonPanel.Visible = false;
        }


        private void _searchPatientButton_Click(object sender, EventArgs e)
        {
            string patientId = idToLoadTextBox.Text;
            List<Patient> patientList = _mainBL.getPatientListById(patientId);
            if (patientList != null)
            {
                _mainForm.Enabled = false;
                SearchResultForm srf = new SearchResultForm(patientList, _mainForm);
                srf.Show();
                foreach (Patient p in patientList)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            else
                MessageBox.Show("Wrong ID, No patient found.",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation,
                                  MessageBoxDefaultButton.Button1);
        }

        private void _savePatientButton_Click(object sender, EventArgs e)
        {
            string testName = _testNameTextBox.Text;
            string id = _idTextBox.Text;
            string fName = _firstNameTextBox.Text;
            string lName = _lastNameTextBox.Text;
            string pathoNum = _pathologicalNoTextBox.Text;
            string runNum = _runNoTextBox.Text;
            string tumourSite = _tumourSiteTextBox.Text;
            string diseaseLevel = _diseaseLevelTextBox.Text;
            string prevTreatment = _previousTreatmentTextBox.Text;
            string currTreatment = _currentTreatmentTextBox.Text;
            string background = _backgroundTextBox.Text;
            string conclusion = _conclusionsTextBox1.Text;
            Patient p = new Patient(testName, id, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, background, prevTreatment, currTreatment, conclusion);
            if (_mainBL.testNameExist(testNmae))
            {
                if (MessageBox.Show("TEST NAME allready exist, Overwrite?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _mainBL.updatePatient(testName, id, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, background, prevTreatment, currTreatment, conclusion);
                    _mainForm.CurrPatient = p;
                    _mutationList = _mainBL.getMutationListByTestName(p.TestName);
                    _mainForm.MutationList = _mutationList;
                    MessageBox.Show("Patient saved successfully");
                }
            }
            else
            {
                _mainBL.addPatient(testName, id, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, prevTreatment, currTreatment, background, conclusion);
                _mainForm.CurrPatient = p;
                _mainForm.MutationList = _mutationList;
                foreach (Mutation m in _mutationList)
                {
                    _mainBL.addMatch(testName, m.MutId);
                }
                MessageBox.Show("Patient saved successfully");
            }
        }
        public void initPatientUC(List<Mutation> mutationList, string testName)
        {
            _mutationList = mutationList;
            this.testNmae = testName;
        }
        public void clearAll()
        {
            _idTextBox.Text = "";
            _idTextBox.ReadOnly = false;
            _firstNameTextBox.Text = "";
            _lastNameTextBox.Text = "";
            _pathologicalNoTextBox.Text = "";
            _runNoTextBox.Text = "";
            _tumourSiteTextBox.Text = "";
            _diseaseLevelTextBox.Text = "";
            _backgroundTextBox.Text = "";
            _previousTreatmentTextBox.Text = "";
            _currentTreatmentTextBox.Text = "";
            _testNameTextBox.Text = "";
            _conclusionsTextBox1.Text = "";
            patientDetailPanel.Visible = false;

        }

        private void newPatientButton_Click(object sender, EventArgs e)
        {
            if(_mainForm.MutationList!=null)
            {
                clearAll();
                _savePatientButton.Enabled = true;
                patientDetailPanel.Visible = true;
                if (testNmae != null)
                {
                    _testNameTextBox.Text = testNmae;
                }
                _mainForm.CurrPatient = null;
            }
            else
            {
                MessageBox.Show("Please Load Test files.");
            }
            
        }


        internal void loadPatientDetails(Patient patient, bool fullView)
        {
            
            _savePatientButton.Enabled = true;
            patientDetailPanel.Visible = true;

            _patient = patient;
            _testNameTextBox.Text = _patient.TestName;
            _idTextBox.Text = _patient.PatientID;
            _idTextBox.ReadOnly = true;
            _firstNameTextBox.Text = _patient.FName;
            _lastNameTextBox.Text = _patient.LName;
            _pathologicalNoTextBox.Text = _patient.PathoNum;
            _runNoTextBox.Text = _patient.RunNum;
            _tumourSiteTextBox.Text = _patient.TumourSite;
            _diseaseLevelTextBox.Text = _patient.DiseaseLevel;
            _backgroundTextBox.Text = _patient.Background;
            _previousTreatmentTextBox.Text = _patient.PrevTreatment;
            _currentTreatmentTextBox.Text = _patient.CurrTreatment;
            _conclusionsTextBox1.Text = _patient.Conclusion;
            patientDetailPanel.Visible = true;
            if (fullView)
                _mainForm.CurrPatient = _patient;
        }
        public void loadMutationDetails(Patient p)
        {
            _mutationList = _mainBL.getMutationListByTestName(_patient.TestName);
            _mainForm.MutationList = _mutationList;
            initPatientUC(_mutationList, _patient.TestName);
            _mainForm.MutationUC.initTable(_mutationList);
            _mainForm.ArticlesUC.initArticleUC(_mutationList);
        }
        public string TestName
        {
            get
            {
                return testNmae;
            }
        }
    }
}
