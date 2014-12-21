using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FinalProject
{
    public class UcscXML
    {
        public static string getCodonAt(string chrom, int index)
        {
            switch (getOffsetInCodon(index))
            {
                case 0:
                    return getSeq(chrom, index, index + 2);
                case 1:
                    return getSeq(chrom, index - 1, index + 1);
                case 2:
                    return getSeq(chrom, index - 2, index);
                default:
                    return null;
            }
        }
        public static int getOffsetInCodon(int index)
        {
            return (index - 1) % 3;
        }
        private static string getSeq(string chrom, int start, int end)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(connectionString(chrom, start, end));
            XmlNode node = xmlDoc.SelectSingleNode("/DASDNA/SEQUENCE/DNA/text()");
            return node.Value.Trim();
        }
        private static string connectionString(string chrom, int start, int end)
        {
            return @"http://genome.ucsc.edu/cgi-bin/das/hg19/dna?segment=" + chrom + ":" + start + "," + end;
        }
    }
}
