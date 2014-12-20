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
        private static string fastaPath = @"Data\All_COSMIC_Genes.fasta";
       
        XLSHandler _xlsHandler;
        FastaHandler _fastaHandler;
        
        public MainForm()
        {
            _fastaHandler=new FastaHandler(fastaPath);
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void loadXLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "ION PGM Output (*.xls)|*.xls";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                _xlsHandler =new XLSHandler(fdlg.FileName);
                Log.Items.Add(fdlg.FileName + " Loaded");
                
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

       
    }
}
