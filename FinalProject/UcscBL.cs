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
                int[] exonStars = exonStringToStringArray(geneStrings[7]);
                int[] exonEnds = exonStringToStringArray(geneStrings[8]);
                return new Gene(geneStrings[0], geneStrings[1], geneStrings[2], geneStrings[3][0], int.Parse(geneStrings[4]), int.Parse(geneStrings[5]), int.Parse(geneStrings[6]), exonStars, exonEnds);
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
            string toReturn = _ucscDAL.getCosmicName(chrom, position, mutationName, geneName); ;
            if(toReturn==null)
                return "No Cosmic Name";
            return toReturn;
        }
    }
}
