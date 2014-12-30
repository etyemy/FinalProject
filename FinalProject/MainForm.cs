using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    
    public partial class MainForm : Form
    {
        private XLSHandler _xlsHandler;
        private UcscDAL _refGeneDAL;
        public MainForm()
        {
           
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void loadXLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = getOpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                _refGeneDAL = new UcscDAL();
                Log.Items.Add("Connection to RefGene Established.");
                _xlsHandler =new XLSHandler(fdlg.FileName);
                Log.Items.Add(fdlg.FileName + " Loaded.\n");
                Log.Items.Add("Analyzing xls File");
                _xlsHandler.handle();
                string[] s = _xlsHandler.ToString().Split('\n');
                foreach(string t in s)
                    Log.Items.Add(t);

            }
            else
            {
                Log.Items.Add("Cancelled by user");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private OpenFileDialog getOpenFileDialog()
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "ION PGM Output (*.xls)|*.xls";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            return fdlg;
        }

       
    }
}
