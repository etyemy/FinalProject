using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject
{
    public class MainBL
    {
        UcscDAL _ucscDAL;
        LocalDbDAL _localDbDAL;
        public MainBL()
        {
            _ucscDAL = new UcscDAL();
            _localDbDAL = new LocalDbDAL();
        }
        public Mutation getMutation(string chrom, int position, char varNuc, char refNuc)
        {
            Mutation toReturn = null;
            List<String> mutationDetails = _localDbDAL.getMutation(chrom, position, refNuc, varNuc);
            if(mutationDetails!=null)
            {
                string tempChrom = mutationDetails.ElementAt(0);
                int tempPosition = Convert.ToInt32(mutationDetails.ElementAt(1));
                string tempGeneName = mutationDetails.ElementAt(2);
                char tempRefNuc = Convert.ToChar( mutationDetails.ElementAt(3));
                char tempVarNuc = Convert.ToChar(mutationDetails.ElementAt(4));
                char tempStrand = Convert.ToChar(mutationDetails.ElementAt(5));
                string tempChromNum = mutationDetails.ElementAt(6);
                string tempRefCodon = mutationDetails.ElementAt(7);
                string tempVarCodon = mutationDetails.ElementAt(8);
                string tempRefAA = mutationDetails.ElementAt(9);
                string tempVarAA = mutationDetails.ElementAt(10);
                string tempPMutationName = mutationDetails.ElementAt(11);
                string tempCMutationName = mutationDetails.ElementAt(12);
                string tempCosmicName = mutationDetails.ElementAt(13);
                toReturn = new Mutation(tempChrom, tempPosition, tempGeneName, tempRefNuc, tempVarNuc,tempStrand,tempChromNum, tempRefCodon, tempVarCodon, tempRefAA, tempVarAA, tempPMutationName, tempCMutationName, tempCosmicName);
            }
            
            return toReturn;
        }
        public void addMutation(Mutation m)
        {
            _localDbDAL.addMutation(m.Chrom,m.Position,m.GeneName,m.Ref,m.Var,m.Strand,m.ChromNum,m.RefCodon,m.VarCodon,m.RefAA,m.VarAA,m.PMutationName,m.CMutationName,m.CosmicName);
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

        internal bool mutationExist(Mutation mutation)
        {
            return _localDbDAL.mutationExist(mutation.Chrom,mutation.Position,mutation.Ref,mutation.Var);
        }
    }
}
