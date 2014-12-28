using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    class RefGeneBL
    {
        RefGeneDAL rgd;
        public RefGeneBL()
        {
            rgd = new RefGeneDAL();
        }

        public Gene getGene(string geneName, string chrom)
        {
            List<String> geneStrings = rgd.getGene(geneName,chrom);
            if (geneStrings != null)
            {
                int[] exonStars = Regex.Split(geneStrings[7], @"\D+").Except(new string[] { "" }).ToArray().Select(x => int.Parse(x)).ToArray();
                int[] exonEnds = Regex.Split(geneStrings[8], @"\D+").Except(new string[] { "" }).ToArray().Select(x => int.Parse(x)).ToArray();
                return new Gene(geneStrings[0], geneStrings[1], geneStrings[2], geneStrings[3][0], int.Parse(geneStrings[4]), int.Parse(geneStrings[5]), int.Parse(geneStrings[6]), exonStars, exonEnds);
            }
            else
                return null;
        }
    }
}
