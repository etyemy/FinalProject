using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    public class UcscBL
    {
        UcscDAL _ucscDAL;
        public UcscBL()
        {
            _ucscDAL = new UcscDAL();
        }
        
        public Gene getGene(string geneName, string chrom)
        {
            try
            {
                List<String> geneStrings = _ucscDAL.getGene(geneName, chrom);
                if (geneStrings != null)
                {
                    char strand = Convert.ToChar(geneStrings[0]);
                    int cdsStart = int.Parse(geneStrings[1]);
                    int cdsEnd = int.Parse(geneStrings[2]);
                    int exonCount = int.Parse(geneStrings[3]);
                    int[] exonStars = exonStringToStringArray(geneStrings[4]);
                    int[] exonEnds = exonStringToStringArray(geneStrings[5]);
                    return new Gene(geneName, chrom, strand, cdsStart, cdsEnd, exonCount, exonStars, exonEnds);
                }
                else
                    return null;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                throw e;

            }
        }
        private int[] exonStringToStringArray(string exon)
        {
            return Regex.Split(exon, @"\D+").Except(new string[] { "" }).ToArray().Select(x => int.Parse(x)).ToArray();
        }

        public List<String> getCosmicDetails(string chromNum, int position, string cMutationName)
        {
            try
            {
                return _ucscDAL.getCosmicDetails(chromNum, position, cMutationName);
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                throw e;
            }
        }
    }
}
