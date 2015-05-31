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
    public partial class HistoryForm : Form
    {
        MainForm _mainForm;
        int nextPosition = 15;
        public HistoryForm(List<Patient> patientList,MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            foreach(Patient p in patientList)
            {
                PatientUserControl puc = new PatientUserControl(p);
                this.Controls.Add(puc);
                puc.Top = nextPosition;
                puc.Left = -200;
                nextPosition += 215;
                puc.BackColor = Color.LightBlue;
                puc.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void HistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainForm.Enabled = true;
        }
    }
}
