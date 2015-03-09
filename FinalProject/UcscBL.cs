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
        LocalDbDAL _localDbDAL;
        public UcscBL()
        {
            _ucscDAL = new UcscDAL();
            _localDbDAL = new LocalDbDAL();
        }
        
        public Gene getGene(string geneName, string chrom)
        {
            Gene g=null;
            List<String> geneStrings;
            try
            {
                geneStrings = _localDbDAL.getGene(geneName, chrom);
                if (geneStrings == null)
                {
                    geneStrings = _ucscDAL.getGene(geneName, chrom);
                    if (geneStrings != null)
                    {
                        char strand = Convert.ToChar(geneStrings[0]);
                        int cdsStart = int.Parse(geneStrings[1]);
                        int cdsEnd = int.Parse(geneStrings[2]);
                        int[] exonStars = exonStringToIntArray(geneStrings[4]);
                        int[] exonEnds = exonStringToIntArray(geneStrings[5]);
                        g = new Gene(geneName, chrom, strand, cdsStart, cdsEnd, exonStars, exonEnds);
                        string tempExonStarts = intArrayToString(g.ExonStarts);
                        string tempExonEnds = intArrayToString(g.ExonEnds);

                        _localDbDAL.addGene(geneName, chrom, strand, tempExonStarts, tempExonEnds);
                    }
                }
                else
                {
                    char strand = Convert.ToChar(geneStrings[2]);
                    int[] exonStarts = exonStringToIntArray(geneStrings[3]);
                    int[] exonEnds = exonStringToIntArray(geneStrings[4]);
                    g = new Gene(geneName, chrom, strand, exonStarts, exonEnds);
                }
                return g;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                throw e;

            }
            
        }

        private string intArrayToString(int[] p)
        {
            string toReturn = "";
            foreach (int n in p)
                toReturn += n + " ";
            return toReturn;
        }
        private int[] exonStringToIntArray(string exon)
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
