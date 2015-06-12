using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.FileHendlers
{
    class XLSExportHandler
    {
        public static void saveXLS(String testName, List<Mutation> mutationList)
        {
            Application xlApp = new Application();
            var workbooks = xlApp.Workbooks;
            Workbook workbook = xlApp.Workbooks.Add(1);
            Worksheet worksheet = (Worksheet)workbook.Sheets[1];

            worksheet.Cells[1,1] = "Chromosome";
            worksheet.Cells[1,2] = "Position";
            worksheet.Cells[1,3] = "Gene Name";
            worksheet.Cells[1, 4] = "Ref";
            worksheet.Cells[1, 5] = "Var";
            worksheet.Cells[1, 6] = "Strand";
            worksheet.Cells[1, 7] = "Ref Codon";
            worksheet.Cells[1, 8] = "Var Codon";
            worksheet.Cells[1, 9] = "Ref AA";
            worksheet.Cells[1, 10] = "Var AA";
            worksheet.Cells[1, 11] = "AA Mutation";
            worksheet.Cells[1, 12] = "CDS Mutation";
            worksheet.Cells[1,13] = "COSMIC Name";

            Range r = worksheet.get_Range("A1", "M1");
            r.Font.Bold=true;
            r.Font.Size = 13;
            r.Interior.Color = System.Drawing.Color.LightGray.ToArgb();

            for (int i = 0; i < mutationList.Count;i++ )
            {
                int row = i + 2;
                Mutation m = mutationList.ElementAt(i);
                worksheet.Cells[row, 1] = m.Chrom;
                worksheet.Cells[row, 2] = m.Position;
                worksheet.Cells[row, 3] = m.GeneName;
                worksheet.Cells[row, 4] = m.Ref;
                worksheet.Cells[row, 5] = m.Var;
                worksheet.Cells[row, 6] = m.Strand;
                worksheet.Cells[row, 7] = m.RefCodon;
                worksheet.Cells[row, 8] = m.VarCodon;
                worksheet.Cells[row, 9] = m.RefAA;
                worksheet.Cells[row, 10] = m.VarAA;
                worksheet.Cells[row, 11] = m.PMutationName;
                worksheet.Cells[row, 12] = m.CMutationName;
                worksheet.Cells[row, 13] = m.CosmicName;

                if (!m.CosmicName.Equals("-----"))
                    worksheet.get_Range("A" + row, "M" + row).Interior.Color = System.Drawing.Color.LightGreen.ToArgb();
            }

            worksheet.Columns.AutoFit();



            workbook.SaveAs(Properties.Settings.Default.DocSavePath + @"\" + testName + ".xlsx");
            workbook.Close();
            xlApp.Quit();



           
        }
    }
}
