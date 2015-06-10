using FinalProject.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class SettingForm : Form
    {
        private MainForm mainForm;
       
        public SettingForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            emailTextBox.Text = Properties.Settings.Default.CosmicEmail;
            passwordTextBox.Text = Properties.Settings.Default.CosmicPassword;
            docPathTextBox.Text = Properties.Settings.Default.DocSavePath;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.Enabled = true;
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CosmicEmail = emailTextBox.Text;
            Properties.Settings.Default.CosmicPassword = passwordTextBox.Text;
            Properties.Settings.Default.DocSavePath = docPathTextBox.Text;
            Properties.Settings.Default.Save();
            mainForm.Enabled = true;
            this.Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                docPathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
