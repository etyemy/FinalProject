using System;
using System.Collections.Generic;
using System.IO;

namespace FinalProject
{
    class XLSHandler
    {
        enum XLSCol { Chrom = 0, Position, Ref, Variant, AlleleCall, Filter1, Frequency, Quality, Filter2, Type, AlleleSource, AlleleName, GeneID };

        private List<string[]> _xlsMin;
        string _xlsPath;
        public XLSHandler(string xlsPath)
        {
            _xlsMin = new List<string[]>();
            _xlsPath = xlsPath;
            StreamReader reader = new StreamReader(_xlsPath);
            string header = reader.ReadLine();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts[(int)XLSCol.Type].Equals("SNP"))
                {
                    string chrom = parts[(int)XLSCol.Chrom];
                    string position = parts[(int)XLSCol.Position];
                    string geneName = parts[(int)XLSCol.GeneID];
                    string refNuc = parts[(int)XLSCol.Ref];
                    string varNuc = parts[(int)XLSCol.Variant];
                    string[] a = new string[6] { chrom, position, geneName, refNuc, varNuc,"1" };
                    _xlsMin.Add(a);
                }
            }
        }
        public List<string[]> XlsMin
        {
            get
            {
                return _xlsMin;
            }
        }

    }
}
