using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject.UI
{
    public partial class SearchResultForm : Form
    {
        private List<Patient> _patientList;
        private MainForm _mainForm;

        public SearchResultForm(List<Patient> patientList,MainForm mainForm)
        {
            InitializeComponent();
            _patientList = patientList;
            _mainForm = mainForm;
            foreach(Patient p in patientList)
            {
                listView1.Items.Add(p.ToString());
            }
        }

        private void loadPatienButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                _mainForm.PatientUC.loadPatientDetails(_patientList[listView1.SelectedIndices[0]]);
                _mainForm.MutationUC.clearAll();
                _mainForm.PatientUC.loadMutationDetails(_patientList[listView1.SelectedIndices[0]]);
                _mainForm.Enabled = true;
                this.Close();
            }
            else
                MessageBox.Show("No Selection Made");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _mainForm.Enabled = true;
            this.Close();
        }
    }
}
