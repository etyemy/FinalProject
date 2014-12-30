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
        public static string getCodonAt(string chrom, int index,int codonOffset)
        {
          
            string toReturn = null;
            switch (codonOffset)
            {
                case 0:
                    toReturn= getSeq(chrom, index, index + 2);
                    break;
                case 1:
                    toReturn = getSeq(chrom, index - 1, index + 1);
                    break;
                case 2:
                    toReturn = getSeq(chrom, index - 2, index);
                    break;
                default:
                    break;
            }
            return toReturn.ToUpper();   
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
