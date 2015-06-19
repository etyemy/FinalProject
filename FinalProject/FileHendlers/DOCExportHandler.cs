using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;


namespace FinalProject.FileHendlers
{
    public class DOCExportHandler
    {

        public static void saveDOC(Patient patient, List<Mutation> mutationList, bool includePersonalDetails)
        {
            WordprocessingDocument myDoc = null;
            string fullPath = Properties.Settings.Default.DocSavePath + @"\" + patient.TestName;
            if (includePersonalDetails)
                fullPath += "_withDetails";
            fullPath += ".docx";
            try
            {
                myDoc = WordprocessingDocument.Create(fullPath, WordprocessingDocumentType.Document);
            }
            catch(IOException e)
            {
                throw e;
            }
            MainDocumentPart mainPart = myDoc.AddMainDocumentPart();
            mainPart.Document = new Document();
            Body body = new Body();
            Paragraph paragraph = new Paragraph();
            Run run_paragraph = new Run();
            paragraph.Append(run_paragraph);

            body.Append(addPara("Test Name",true));
            body.Append(addPara(patient.TestName,false));
            if (includePersonalDetails)
            {
                body.Append(addPara("ID", true));
                body.Append(addPara(patient.PatientID, false));
                body.Append(addPara("First Name", true));
                body.Append(addPara(patient.FName, false));
                body.Append(addPara("Last Name", true));
                body.Append(addPara(patient.LName, false));
            }
            
            body.Append(addPara("Pathological Number", true));
            body.Append(addPara(patient.PathoNum, false));
            body.Append(addPara("Run Number", true));
            body.Append(addPara(patient.RunNum, false));
            body.Append(addPara("Tumour Site", true));
            body.Append(addPara(patient.TumourSite, false));
            body.Append(addPara("Disease Level", true));
            body.Append(addPara(patient.DiseaseLevel, false));
            body.Append(addPara("Backgroud", true));
            body.Append(addPara(patient.Background, false));
            body.Append(addPara("Previous Treatment", true));
            body.Append(addPara(patient.PrevTreatment, false));
            body.Append(addPara("Current Treatment", true));
            body.Append(addPara(patient.CurrTreatment, false));
            body.Append(addPara("Conclusion", true));
            body.Append(addPara(patient.Conclusion, false));

            CreateTable(body, mutationList);

            mainPart.Document.Append(body);
            mainPart.Document.Save();
            myDoc.Close();
        }
        private static Paragraph addPara(string text,bool isHeader)
        {
            Paragraph paragraph = new Paragraph();
            Run run_paragraph = new Run();
            paragraph.Append(run_paragraph);
            if(isHeader)
            {
                RunProperties runProperties = run_paragraph.AppendChild(new RunProperties());
                Bold bold = new Bold();
                bold.Val = OnOffValue.FromBoolean(true);
                runProperties.AppendChild(bold);
                FontSize fontSize = new FontSize();
                fontSize.Val = "26";
                runProperties.Color = new Color() { Val = "0E6EB8" };
                runProperties.AppendChild(fontSize);
            }
            run_paragraph.AppendChild(new Text(text));
            if (!isHeader)
                run_paragraph.AppendChild(new Break());
            return paragraph;
        }

        

        private static void CreateTable(Body body, List<Mutation> mutationList)
        {
            Table mutationTable = new Table();
            mutationTable.AppendChild<TableProperties>(getTableProperties());
            TableRow headerRow = new TableRow();
            headerRow.Append(makeCell("Chromosome", 1));
            headerRow.Append(makeCell("Position", 1));
            headerRow.Append(makeCell("Gene Name", 1));
            headerRow.Append(makeCell("Ref", 1));
            headerRow.Append(makeCell("Var", 1));
            headerRow.Append(makeCell("Ref Codon", 1));
            headerRow.Append(makeCell("Var Codon", 1));
            headerRow.Append(makeCell("Mutation", 1));
            mutationTable.Append(headerRow);
            foreach (Mutation m in mutationList)
            {
                int toColor = 0;
                if (!m.CosmicName.Equals("-----"))
                    toColor = 2;
                TableRow row = new TableRow();
                row.Append(makeCell(m.Chrom, toColor));
                row.Append(makeCell(m.Position + "", toColor));
                row.Append(makeCell(m.GeneName, toColor));
                row.Append(makeCell(m.Ref + "", toColor));
                row.Append(makeCell(m.Var + "", toColor));
                row.Append(makeCell(m.RefCodon, toColor));
                row.Append(makeCell(m.VarCodon, toColor));
                row.Append(makeCell(m.PMutationName, toColor));
                mutationTable.Append(row);
            }
            body.Append(mutationTable);
        }

         private static TableCell makeCell(string p,int colorType)
        {
            TableCell cell = new TableCell();
            if(colorType!=0)
            {
                string color = "";
                if(colorType==1)
                    color="a9a9a9";
                else if(colorType==2)
                    color="ABCDEF";
                TableCellProperties tcp = new TableCellProperties(
                    new TableCellWidth { Type = TableWidthUnitValues.Auto, }
                );
                Shading shading = new Shading()
                    {
                        Color = "auto",
                        Fill = color,
                        Val = ShadingPatternValues.Clear
                    };
                // Add the Shading object to the TableCellProperties object
                tcp.Append(shading);
                cell.Append(tcp);
            }
            cell.Append(new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            cell.Append(new Paragraph(new Run(new Text(p))));
            return cell;
        }

        private static TableProperties getTableProperties()
        {
            return new TableProperties(
                    new TableBorders(
                        new TopBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        },
                        new BottomBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        },
                        new LeftBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        },
                        new RightBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        },
                        new InsideHorizontalBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        },
                        new InsideVerticalBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Single),
                            Size = 8
                        }
                    )
                );
        }
    }
}
