using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
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
            string fullPath = Properties.Settings.Default.DocSavePath + @"\" + testName;
            fullPath += ".xlsx";

            using (var workbook = SpreadsheetDocument.Create(fullPath, SpreadsheetDocumentType.Workbook))
            {

                WorkbookPart mainPart = workbook.AddWorkbookPart();
                mainPart.Workbook = new Workbook();
                WorkbookStylesPart stylePart = mainPart.AddNewPart
                          <WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStyleSheet();
                stylePart.Stylesheet.Save();

                workbook.WorkbookPart.Workbook.Sheets = new Sheets();
                var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                sheetPart.Worksheet = new Worksheet(sheetData);
                Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);
                uint sheetId = 1;
                if (sheets.Elements<Sheet>().Count() > 0)
                {
                    sheetId =
                        sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                }
                Sheet sheet = new Sheet() { Id = relationshipId, SheetId = sheetId, Name = testName };
                sheets.Append(sheet);




                Row headerRow = new Row();
                foreach (string s in Mutation.getHeaderForExport())
                {
                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(s);
                    cell.StyleIndex = 1;
                    headerRow.AppendChild(cell);
                }
                sheetData.AppendChild(headerRow);

                foreach (Mutation m in mutationList)
                {
                    Row newRow = new Row();
                    string[] infoString = m.getInfoForExport();
                    for (int i = 0; i < infoString.Length; i++)
                    {
                        Cell cell1 = new Cell();
                        if (i == 1)
                            cell1.DataType = CellValues.Number;
                        else
                            cell1.DataType = CellValues.String;
                        cell1.CellValue = new CellValue(infoString[i]);
                        if (!m.CosmicName.Equals("-----"))
                            cell1.StyleIndex = 2;
                        else
                            cell1.StyleIndex = 3;
                        newRow.AppendChild(cell1);
                    }

                    sheetData.AppendChild(newRow);
                }
            }
        }
        private static Stylesheet GenerateStyleSheet()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(                                                               // Index 0 - The default font.
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                   new Font(
                        new Bold(),                                                         // Index 1 - Header.
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" })
                ),
                new Fills(
                    new Fill(                                                           // Index 0 - Regular row.
                        new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(                                                           // Index 1 - Header row
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "A9A9A9" } }
                        ) { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 2 - Important Mutation row .
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "ABCDEF" } }
                        ) { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 2 - Important Mutation row .
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFFFFF" } }
                        ) { PatternType = PatternValues.Solid })
                ),
                new Borders(
                    new Border(                                                         // Index 0 - The default border.
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder()),
            new Border(                                                         // Index 1 - Applies a Left, Right, Top, Bottom border to a cell
                new LeftBorder(
                    new Color() { Auto = true }
                ) { Style = BorderStyleValues.Thin },
                new RightBorder(
                    new Color() { Auto = true }
                ) { Style = BorderStyleValues.Thin },
                new TopBorder(
                    new Color() { Auto = true }
                ) { Style = BorderStyleValues.Thin },
                new BottomBorder(
                    new Color() { Auto = true }
                ) { Style = BorderStyleValues.Thin },
                new DiagonalBorder())

                ),
                new CellFormats(
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 0, FillId = 0, BorderId = 1, ApplyAlignment = true, ApplyBorder = true, ApplyFill = true },
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 1, FillId = 1, BorderId = 1, ApplyAlignment = true, ApplyBorder = true, ApplyFill = true },
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 0, FillId = 2, BorderId = 1, ApplyAlignment = true, ApplyBorder = true, ApplyFill = true },
                    new CellFormat(new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }) { FontId = 0, FillId = 3, BorderId = 1, ApplyAlignment = true, ApplyBorder = true, ApplyFill = true }

                )
            ); // return
        }
    }
}
