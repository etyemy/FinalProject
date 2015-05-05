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
                List<string> patient = _mainBL.getPatientById(patientId);
                _idTextBox.Text = patient.ElementAt(0);
                _idTextBox.Enabled = false;
                _firstNameTextBox.Text = patient.ElementAt(1);
                _lastNameTextBox.Text = patient.ElementAt(2);
                _pathologicalNoTextBox.Text = patient.ElementAt(3);
                _runNoTextBox.Text = patient.ElementAt(4);
                _tumourSiteTextBox.Text = patient.ElementAt(5);
                _diseaseLevelTextBox.Text = patient.ElementAt(6);
                _previousTreatmentTextBox.Text = patient.ElementAt(7);
                _currentTreatmentTextBox.Text = patient.ElementAt(8);
                _backgroundTextBox.Text = patient.ElementAt(9);
                _conclusionsTextBox1.Text = patient.ElementAt(10);

                _mutationList = _mainBL.getMutationListPerPatient(_idTextBox.Text);
                initPatientUC(_mutationList);
                _mainForm.ArticlesUC.initArticleUC(_mutationList);
            }
            else
                MessageBox.Show("Wrong ID, No patient found");
        }

        private void _savePatientButton_Click(object sender, EventArgs e)
        {
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
                    _mainBL.updatePatient(id, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, prevTreatment, currTreatment, background, conclusion);
                }
            }
            else
            {
                _mainBL.addPatient(id, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, prevTreatment, currTreatment, background, conclusion);
                foreach (Mutation m in _mutationList)
                {
                    _mainBL.addMatch(id, m.MutId);
                }
            }
            MessageBox.Show("Patient saved successfully");
        }
        public void initPatientUC(List<Mutation> mutationList)
        {
            _mutationList = mutationList;
            _patientMutationListBox.Items.Clear();
            if (_mutationList != null)
                foreach (Mutation m in mutationList)
                    _patientMutationListBox.Items.Add(m.PrintToLog());
        }
        public void clearAll()
        {
            _patientMutationListBox.Items.Clear();
            _idTextBox.Text = "";
            _firstNameTextBox.Text = "";
            _lastNameTextBox.Text = "";
            _pathologicalNoTextBox.Text = "";
            _runNoTextBox.Text = "";
            _tumourSiteTextBox.Text = "";
            _diseaseLevelTextBox.Text = "";
            _previousTreatmentTextBox.Text = "";
            _currentTreatmentTextBox.Text = "";
            _conclusionsTextBox1.Text = "";
        }
    }
}
