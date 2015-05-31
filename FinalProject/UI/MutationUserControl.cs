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
    public partial class MutationUserControl : UserControl
    {
        private List<Mutation> _mutationList;
        private MainForm _mainForm;
        public MutationUserControl(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _mutationList = null;
            mutationDataGridView.MouseEnter += (s, e) => this.Focus();
            mutationDataGridView.CellContentClick += dataGridView1_CellClick;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                string mutationId = _mutationList.ElementAt(e.RowIndex).MutId;
                List<Patient> patientList = _mainForm.MainBL.getPatientListWithMutation(mutationId);
                HistoryForm hf = new HistoryForm(patientList,_mainForm);
                _mainForm.Enabled = false;
                hf.Show();
            }
        }

        public void initTable(List<Mutation> mutationList)
        {
            _mutationList = mutationList;
            fillTable();

        }

        private void fillTable()
        {
            if(_mutationList!=null)
            {
                foreach(Mutation m in _mutationList)
                {
                    DataGridViewRow tempRow = new DataGridViewRow();
                    tempRow.CreateCells(mutationDataGridView);
                    tempRow.Cells[0].Value = m.Chrom;
                    tempRow.Cells[1].Value = m.Position;
                    tempRow.Cells[2].Value = m.GeneName;
                    tempRow.Cells[3].Value = m.Ref;
                    tempRow.Cells[4].Value = m.Var;
                    tempRow.Cells[5].Value = m.Strand;
                    tempRow.Cells[6].Value = m.RefCodon;
                    tempRow.Cells[7].Value = m.VarCodon;
                    tempRow.Cells[8].Value = m.RefAA;
                    tempRow.Cells[9].Value = m.VarAA;
                    tempRow.Cells[10].Value = m.PMutationName;
                    tempRow.Cells[11].Value = m.CMutationName;
                    tempRow.Cells[12].Value = m.CosmicName;
                    tempRow.Cells[13].Value = m.NumOfShows;
                    int historyNum=_mainForm.MainBL.getNumOfPatientWithSameMut(m.MutId);
                    if (historyNum == 0)
                        tempRow.Cells[14] = new DataGridViewTextBoxCell();
                    tempRow.Cells[14].Value = historyNum;
                    if (!m.CosmicName.Equals("-----"))
                        tempRow.DefaultCellStyle.BackColor = Color.LightCyan;
                    mutationDataGridView.Rows.Add(tempRow);
                }
            }
        }
        public void clearAll()
        {
            _mutationList = null;
            mutationDataGridView.Rows.Clear();
        }
    }
}
