﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalProject.UI
{
    /*
    * Patient UserControl.
    * Main purpose - show mutations details in MainForm.
    * Part of MainForm. 
    */
    public partial class MutationUserControl : UserControl
    {
        private List<Mutation> _mutationList;
        private MainForm _mainForm;
        //initialize the MutationUserControl
        public MutationUserControl(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _mutationList = null;
            mutationDataGridView.MouseEnter += (s, e) => this.Focus();
            mutationDataGridView.CellContentClick += dataGridView1_CellClick;
        }

        //occurs when cell clicked in dataGridView, use only in history field,Open the history form for current mutation.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                string mutationId = _mutationList.ElementAt(e.RowIndex).MutId;
                try
                {
                    List<Patient> patientList = MainBL.getPatientListWithMutation(mutationId);
                    HistoryForm hf = new HistoryForm(patientList, _mainForm);
                    _mainForm.Enabled = false;
                    hf.Show();
                }
                catch (Exception)
                {
                    GeneralMethods.showErrorMessageBox("Something Went Wrong, Please try Again");

                }
                
            }
        }
        //Initialize the table with the details from the mutation list.
        public void initTable(List<Mutation> mutationList)
        {
            _mutationList = mutationList;
            if (_mutationList != null)
            {
                foreach (Mutation m in _mutationList)
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
                    try
                    {
                        int historyNum = MainBL.getNumOfPatientWithSameMutation(m.MutId);
                        if (historyNum == 0)
                            tempRow.Cells[14] = new DataGridViewTextBoxCell();
                        tempRow.Cells[14].Value = historyNum;
                        if (!m.CosmicName.Equals("-----"))
                            tempRow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#ABCDEF");
                        mutationDataGridView.Rows.Add(tempRow);
                        mutationDataGridView.PerformLayout();
                    }
                    catch (Exception)
                    {
                        GeneralMethods.showErrorMessageBox("Something Went Wrong, Please try Again");
                    }
                }
            }
        }

        //Clear all the data from the table
        public void clearAll()
        {
            _mutationList = null;
            mutationDataGridView.Rows.Clear();
        }
    }
}
