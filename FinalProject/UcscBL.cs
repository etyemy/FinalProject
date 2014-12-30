using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    class UcscBL
    {
        UcscDAL _ucscDAL;
        public UcscBL()
        {
            _ucscDAL = new UcscDAL();
        }

        public Gene getGene(string geneName, string chrom)
        {
            List<String> geneStrings = _ucscDAL.getGene(geneName,chrom);
            if (geneStrings != null)
            {
                char strand=Convert.ToChar(geneStrings[0]);
                int cdsStart=int.Parse(geneStrings[1]);
                int cdsEnd=int.Parse(geneStrings[2]);
                int exonCount=int.Parse(geneStrings[3]);
                int[] exonStars = exonStringToStringArray(geneStrings[4]);
                int[] exonEnds = exonStringToStringArray(geneStrings[5]);
                return new Gene(geneName, chrom, strand, cdsStart, cdsEnd, exonCount, exonStars, exonEnds);
            }
            else
                return null;
        }
        private int[] exonStringToStringArray(string exon)
        {
            return Regex.Split(exon, @"\D+").Except(new string[] { "" }).ToArray().Select(x => int.Parse(x)).ToArray();
        }

        public string getCosmicName(string chrom, int position, string mutationName,string geneName)
        {
            return _ucscDAL.getCosmicName(chrom, position, mutationName, geneName); 
        }
    }
}
