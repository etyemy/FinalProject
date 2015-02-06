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
            ExcelFile ef=new ExcelFile();
            try
            {
                ef = ExcelFile.Load(_xlsPath);
            }
            catch(Exception e)
            {
                Console.WriteLine("CATCH EXCEL OPEN");
                Console.WriteLine("Error: {0}", e.ToString());
                TextReader tr = (TextReader)new StreamReader(_xlsPath);
                ef = ExcelFile.Load(tr, new CsvLoadOptions('1'));
            }
            finally
            {
                string outputPath = _xlsPath.Split('.')[0];
                outputPath += "_detailed.xls";
                if (File.Exists(outputPath))
                    File.Delete(outputPath);
                StreamWriter outputStream = new StreamWriter(outputPath);
                string header = "Chrom\tPosition\tGene Name\tRef\tVar\tRef Codon\tVar Codon\tRef AA\tVar AA\tMutation Symbol\tCosmic Name";
                outputStream.WriteLine(header);



                CellRange range = ef.Worksheets[0].GetUsedCellRange(true);
                for (int i = 1; i < range.LastRowIndex; i++)
                {
                    if (range[i, 9].Value.ToString().Equals("SNP"))
                    {
                        string chrom = range[i, 0].Value.ToString();
                        int position = Convert.ToInt32(range[i, 1].Value.ToString());
                        string geneName = range[i, 12].Value.ToString();
                        char refNuc = range[i, 2].Value.ToString()[0];
                        char varNuc = range[i, 3].Value.ToString()[0];
                        try
                        {
                            Mutation m = new Mutation(chrom, position, geneName, refNuc, varNuc);
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
            }
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
