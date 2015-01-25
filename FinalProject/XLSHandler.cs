using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemBox.Spreadsheet;

namespace FinalProject
{
    class XLSHandler
    {
        enum XLSCol { Chrom = 0, Position, Ref, Variant, AlleleCall, Filter1, Frequency, Quality, Filter2, Type, AlleleSource, AlleleName, GeneID };

        private List<Mutation> _nonCosmicMutation;
        private List<Mutation> _cosmicMutation;
        string _xlsPath;
        public XLSHandler(string xlsPath)
        {
            _nonCosmicMutation = new List<Mutation>();
            _cosmicMutation = new List<Mutation>();
            _xlsPath = xlsPath;
        }

        public void handle()
        {
            // If using Professional version, put your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile ef = new ExcelFile();
            try
            {
                ef = ExcelFile.Load(_xlsPath);
            }
            catch
            {
                Console.WriteLine("CATCH EX");
                TextReader tr = (TextReader)new StreamReader(_xlsPath);
                ef = ExcelFile.Load(tr, new CsvLoadOptions('2'));
            }
            finally
            {
                StringBuilder sb = new StringBuilder();

                foreach (ExcelWorksheet sheet in ef.Worksheets)
                {
                    sb.AppendLine();
                    sb.AppendFormat("--------- {0} ---------", sheet.Name);

                    foreach (ExcelRow row in sheet.Rows)
                    {
                        sb.AppendLine();
                        foreach (ExcelCell cell in row.AllocatedCells)
                        {
                            if (cell.Value != null)
                                sb.AppendFormat("{0}({1})", cell.Value, cell.Value.GetType().Name);

                            sb.Append("\t");
                        }
                    }
                }

                Console.WriteLine(sb.ToString());
            }



            StreamReader xlsStream = new StreamReader(_xlsPath);
            xlsStream.ReadLine();
            string outputPath = _xlsPath.Split('.')[0];
            outputPath += "_detailed.xls";
            Console.WriteLine(outputPath);
            if (File.Exists(outputPath))
                File.Delete(outputPath);
            StreamWriter outputStream = new StreamWriter(outputPath);
            string header = "Chrom\tPosition\tGene Name\tRef\tVar\tRef Codon\tVar Codon\tRef AA\tVar AA\tMutation Symbol\tCosmic Name";
            outputStream.WriteLine(header);
            while (xlsStream.Peek() >= 0)
            {

                string[] lineParts = xlsStream.ReadLine().Split('\t');
                if (lineParts[(int)XLSCol.Type].Equals("SNP"))
                {
                    string chrom = lineParts[(int)XLSCol.Chrom];
                    int position = Convert.ToInt32(lineParts[(int)XLSCol.Position]);
                    string geneSym = lineParts[(int)XLSCol.GeneID];
                    char refNuc = Convert.ToChar(lineParts[(int)XLSCol.Ref]);
                    char varNuc = Convert.ToChar(lineParts[(int)XLSCol.Variant]);
                    try
                    {

                        Mutation m = new Mutation(chrom, position, geneSym, refNuc, varNuc);
                        outputStream.WriteLine(m.PrintXLSLine());
                        if (m.isImportant())
                            _cosmicMutation.Add(m);
                        else
                            _nonCosmicMutation.Add(m);


                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        Console.WriteLine("Error: {0}", e.ToString());
                        throw e;
                    }
                }
            }
            outputStream.Close();
            xlsStream.Close();

        }
        public override string ToString()
        {
            string toReturn = "";
            foreach (Mutation m in _nonCosmicMutation)
                toReturn += m.PrintToLog() + "\n";
            return toReturn;

        }
        public List<Mutation> NonCosmicMutation
        {
            get
            {
                return _nonCosmicMutation;
            }
        }
        public List<Mutation> CosmicMutation
        {
            get
            {
                return _cosmicMutation;
            }
        }

    }
}
