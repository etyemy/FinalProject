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
        public PatientUserControl(MainForm mainForm)
        {
            _mainForm = mainForm;
            _mainBL = mainForm.MainBL;
            InitializeComponent();

        }
        private void _loadPatientButton_Click(object sender, EventArgs e)
        {
            string patientId = idToLoadTextBox.Text;
            if (_mainBL.patientExist(patientId))
            {
                _patient = _mainBL.getPatientById(patientId);
                //List<string> patient = _mainBL.getPatientById(patientId);
                
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

                _mutationList = _mainBL.getMutationListByTestName(_patient.TestName);
                initPatientUC(_mutationList,_patient.TestName);
                _mainForm.MutationUC.initTable(_mutationList);
                _mainForm.ArticlesUC.initArticleUC(_mutationList);
            }
            else
                MessageBox.Show("Wrong ID, No patient found");
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
            if (_mainBL.patientExist(id))
            {
                if (MessageBox.Show("Patient with this ID allready exist, Overwrite?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _mainBL.updatePatient(testName, id, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, background, prevTreatment, currTreatment, conclusion);
                }
            }
            else
            {
                _mainBL.addPatient(testName,id, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, prevTreatment, currTreatment, background, conclusion);
                foreach (Mutation m in _mutationList)
                {
                    _mainBL.addMatch(testName, m.MutId);
                }
            }
            MessageBox.Show("Patient saved successfully");
        }
        public void initPatientUC(List<Mutation> mutationList,string testName)
        {
            _mutationList = mutationList;
            _testNameTextBox.Text = testName;
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
        }
    }
}
