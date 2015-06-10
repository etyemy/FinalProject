using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FinalProject.FileHendlers
{
    public class DOCHandler
    {

        public static void saveDOC(Patient patient, List<Mutation> mutationList, bool includePersonalDetails, string path)
        {
            _Application oWord = new Application();
            Document oDoc = oWord.Documents.Add();

            oDoc.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            oDoc.Paragraphs.ReadingOrder= WdReadingOrder.wdReadingOrderLtr;

            addParagraph(oDoc, "Test Name", true);
            addParagraph(oDoc, patient.TestName, false);

            

            if (includePersonalDetails)
            {
                addParagraph(oDoc, "ID", true);
                addParagraph(oDoc, patient.PatientID, false);

                addParagraph(oDoc, "First Name", true);
                addParagraph(oDoc, patient.FName, false);

                addParagraph(oDoc, "Last Name", true);
                addParagraph(oDoc, patient.LName, false);
            }


            addParagraph(oDoc, "Pathological Number", true);
            addParagraph(oDoc, patient.PathoNum, false);

            addParagraph(oDoc, "Run Number", true);
            addParagraph(oDoc, patient.RunNum, false);

            addParagraph(oDoc, "Tumour Site", true);
            addParagraph(oDoc, patient.TumourSite, false);

            addParagraph(oDoc, "Disease Level", true);
            addParagraph(oDoc, patient.DiseaseLevel, false);

            addParagraph(oDoc, "Backgroud", true);
            addParagraph(oDoc, patient.Background, false);

            addParagraph(oDoc, "Previous Treatment", true);
            addParagraph(oDoc, patient.PrevTreatment, false);

            addParagraph(oDoc, "Current Treatment", true);
            addParagraph(oDoc, patient.CurrTreatment, false);

            addParagraph(oDoc, "Conclusion", true);
            addParagraph(oDoc, patient.Conclusion, false);

            addParagraph(oDoc, "\n\n", false);
            addMutationTable(oDoc, mutationList);



            foreach (Paragraph p in oWord.ActiveDocument.Paragraphs)
            {
                p.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            }
            oDoc.Paragraphs[1].Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            oDoc.Paragraphs[2].Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            String fullPath = Properties.Settings.Default.DocSavePath + @"\" + patient.TestName;
            if (includePersonalDetails)
                fullPath += "_withDetails";
            fullPath += ".docx";
            oDoc.SaveAs2(fullPath);

            oWord.Quit();

        }

        private static void addMutationTable(Document oDoc, List<Mutation> mutationList)
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";
            Table newTable;
            Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            newTable = oDoc.Tables.Add(wrdRng, mutationList.Count+1,8, ref oMissing, ref oMissing);
            newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            newTable.AllowAutoFit = true;
            newTable.Range.Font.Name = "David";
            newTable.Range.Font.Size = 10;
            newTable.Rows.HeightRule = WdRowHeightRule.wdRowHeightAtLeast;
            newTable.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
           
            newTable.Cell(1, 1).Range.Text = "Chromosome";
            newTable.Cell(1, 1).Range.Font.Bold = -1;
            newTable.Cell(1, 2).Range.Text = "Position";
            newTable.Cell(1, 2).Range.Font.Bold = -1;
            newTable.Cell(1, 3).Range.Text = "Gene Name";
            newTable.Cell(1, 3).Range.Font.Bold = -1;
            newTable.Cell(1, 4).Range.Text = "Ref";
            newTable.Cell(1, 4).Range.Font.Bold = -1;
            newTable.Cell(1, 5).Range.Text = "Var";
            newTable.Cell(1, 5).Range.Font.Bold = -1;
            newTable.Cell(1, 6).Range.Text = "Ref Codon";
            newTable.Cell(1, 6).Range.Font.Bold = -1;
            newTable.Cell(1, 7).Range.Text = "Var Codon";
            newTable.Cell(1, 7).Range.Font.Bold = -1;
            newTable.Cell(1, 8).Range.Text = "Protein Mutation";
            newTable.Cell(1, 8).Range.Font.Bold = -1;

            for (int i = 0; i < mutationList.Count;i++ )
            {
                newTable.Cell(i + 2, 1).Range.Text = mutationList.ElementAt(i).Chrom;
                newTable.Cell(i + 2, 2).Range.Text = mutationList.ElementAt(i).Position.ToString();
                newTable.Cell(i + 2, 3).Range.Text = mutationList.ElementAt(i).GeneName;
                newTable.Cell(i + 2, 4).Range.Text = mutationList.ElementAt(i).Ref.ToString();
                newTable.Cell(i + 2, 5).Range.Text = mutationList.ElementAt(i).Var.ToString();
                newTable.Cell(i + 2, 6).Range.Text = mutationList.ElementAt(i).RefCodon;
                newTable.Cell(i + 2, 7).Range.Text = mutationList.ElementAt(i).VarCodon;
                newTable.Cell(i + 2, 8).Range.Text = mutationList.ElementAt(i).PMutationName;
                if(!mutationList.ElementAt(i).CosmicName.Equals("-----"))
                {
                    for (int j = 1; j <= 8; j++)
                        newTable.Cell(i + 2, j).Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                }
            }  
        }


        private static void addParagraph(Document oDoc, string text, bool isHeader)
        {
            Paragraph paragraph;
            paragraph = oDoc.Content.Paragraphs.Add();
            paragraph.Range.Text = text;
            if (isHeader)
                paragraph.Range.set_Style(oDoc.Styles[WdBuiltinStyle.wdStyleHeading2]);
            else
            {
                paragraph.Range.Font.Name = "David";
                paragraph.Range.Font.Size = 11;
            }

            paragraph.Range.InsertParagraphAfter();
        }
    }
}
