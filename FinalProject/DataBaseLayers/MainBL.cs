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
        public static Mutation getMutationByDetails(string chrom, int position, char varNuc, char refNuc)
        {
            Mutation toReturn = null;
            List<String> mutationDetails = LocalDbDAL.getMutationByDetails(chrom, position, refNuc, varNuc);
            if(mutationDetails!=null)
            {
                string mutId = mutationDetails.ElementAt(0);
                string tempChrom = mutationDetails.ElementAt(1);
                int tempPosition = Convert.ToInt32(mutationDetails.ElementAt(2));
                string tempGeneName = mutationDetails.ElementAt(3);
                char tempRefNuc = Convert.ToChar( mutationDetails.ElementAt(4));
                char tempVarNuc = Convert.ToChar(mutationDetails.ElementAt(5));
                char tempStrand = Convert.ToChar(mutationDetails.ElementAt(6));
                string tempChromNum = mutationDetails.ElementAt(7);
                string tempRefCodon = mutationDetails.ElementAt(8);
                string tempVarCodon = mutationDetails.ElementAt(9);
                string tempRefAA = mutationDetails.ElementAt(10);
                string tempVarAA = mutationDetails.ElementAt(11);
                string tempPMutationName = mutationDetails.ElementAt(12);
                string tempCMutationName = mutationDetails.ElementAt(13);
                string tempCosmicName = mutationDetails.ElementAt(14);
                toReturn = new Mutation(mutId,tempChrom, tempPosition, tempGeneName, tempRefNuc, tempVarNuc,tempStrand,tempChromNum, tempRefCodon, tempVarCodon, tempRefAA, tempVarAA, tempPMutationName, tempCMutationName, tempCosmicName);
            }
            
            return toReturn;
        }
        public static List<Mutation> getMutationListByTestName(string testName)
        {
            List<string> tempList = LocalDbDAL.getMutationListPerPatient(testName);
            List<Mutation> toReturn =new List<Mutation>();
            foreach (string s in tempList)
                toReturn.Add(getMutationById(s));
            return toReturn;

        }
         public static Mutation getMutationById(string mutId)
        {
            Mutation toReturn = null;
            List<String> mutationDetails = LocalDbDAL.getMutationByID(mutId);
            if (mutationDetails != null)
            {
                string tempMutId = mutationDetails.ElementAt(0);
                string tempChrom = mutationDetails.ElementAt(1);
                int tempPosition = Convert.ToInt32(mutationDetails.ElementAt(2));
                string tempGeneName = mutationDetails.ElementAt(3);
                char tempRefNuc = Convert.ToChar(mutationDetails.ElementAt(4));
                char tempVarNuc = Convert.ToChar(mutationDetails.ElementAt(5));
                char tempStrand = Convert.ToChar(mutationDetails.ElementAt(6));
                string tempChromNum = mutationDetails.ElementAt(7);
                string tempRefCodon = mutationDetails.ElementAt(8);
                string tempVarCodon = mutationDetails.ElementAt(9);
                string tempRefAA = mutationDetails.ElementAt(10);
                string tempVarAA = mutationDetails.ElementAt(11);
                string tempPMutationName = mutationDetails.ElementAt(12);
                string tempCMutationName = mutationDetails.ElementAt(13);
                string tempCosmicName = mutationDetails.ElementAt(14);
                toReturn = new Mutation(tempMutId, tempChrom, tempPosition, tempGeneName, tempRefNuc, tempVarNuc, tempStrand, tempChromNum, tempRefCodon, tempVarCodon, tempRefAA, tempVarAA, tempPMutationName, tempCMutationName, tempCosmicName);
            }

            return toReturn;
        }
        public static void addMutation(Mutation m)
        {
            LocalDbDAL.addMutation(m.MutId,m.Chrom,m.Position,m.GeneName,m.Ref,m.Var,m.Strand,m.ChromNum,m.RefCodon,m.VarCodon,m.RefAA,m.VarAA,m.PMutationName,m.CMutationName,m.CosmicName);
        }
        public static void addGene(string geneName, string chrom)
        {
            List<String> geneStrings;
            geneStrings = UcscDAL.getGene(geneName, chrom);
            if (geneStrings != null)
            {
                char strand = Convert.ToChar(geneStrings[0]);
                int cdsStart = int.Parse(geneStrings[1]);
                int cdsEnd = int.Parse(geneStrings[2]);
                int[] exonStars = exonStringToIntArray(geneStrings[4]);
                int[] exonEnds = exonStringToIntArray(geneStrings[5]);
                Gene g = new Gene(geneName, chrom, strand, cdsStart, cdsEnd, exonStars, exonEnds);
                string tempExonStarts = exonIntArrayToString(g.ExonStarts);
                string tempExonEnds = exonIntArrayToString(g.ExonEnds);

                LocalDbDAL.addGene(geneName, chrom, strand, tempExonStarts, tempExonEnds);
            }
        }
        public static Gene getGene(string geneName, string chrom)
        {
            Gene g=null;
            List<String> geneStrings;
            try
            {
                geneStrings = LocalDbDAL.getGene(geneName, chrom);
                if (geneStrings != null)
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
                throw ;

            }
            
        }
        public static List<String> getCosmicDetails(string chromNum, int position, char refNuc, char varNuc)
        {
            try
            {
                return UcscDAL.getCosmicDetails(chromNum, position, refNuc,varNuc);
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                throw ;
            }
        }

        public static bool mutationExist(Mutation mutation)
        {
            return LocalDbDAL.mutationExist(mutation.Chrom,mutation.Position,mutation.Ref,mutation.Var);
        }

        

        public static bool patientExistByTestName(string testName)
        {
            return LocalDbDAL.patientExist(testName);
        }
        public static int getNumOfPatientWithSameMutation(string mutationId)
        {
            return LocalDbDAL.getNumOfPatientWithSameMutation(mutationId);
        }

        public static void addPatient(string testName,string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string deseaseLevel, string prevTreatment, string currTreatment, string background, string conclusion)
        {
            LocalDbDAL.addPatient(testName,id, fName, lName, pathologicalNum, runNum, tumourSite, deseaseLevel, prevTreatment, currTreatment, background, conclusion);
        }
        public static void updatePatient(string testName,string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string deseaseLevel, string prevTreatment, string currTreatment, string background, string conclusion)
        {
            LocalDbDAL.updatePatient(testName,id, fName, lName, pathologicalNum, runNum, tumourSite, deseaseLevel, prevTreatment, currTreatment, background, conclusion);
        }
        public static void addMatch(string testName, string mutId)
        {
            LocalDbDAL.addMatch(testName, mutId);
        }

        public static string exonIntArrayToString(int[] p)
        {
            string toReturn = "";
            foreach (int n in p)
                toReturn += n + " ";
            return toReturn;
        }
        public static int[] exonStringToIntArray(string exon)
        {
            return Regex.Split(exon, @"\D+").Except(new string[] { "" }).ToArray().Select(x => int.Parse(x)).ToArray();
        }

        public static List<Patient> getPatientListById(string id)
        {
            List<Patient> toReturn = null;
            List<List<string>> patient = LocalDbDAL.getPatientListById(id);
            if(patient!=null)
            {
                toReturn = new List<Patient>();
                foreach (List<string> l in patient)
                {
                    string testName = l.ElementAt(0);
                    string patientId = l.ElementAt(1);
                    string fName = l.ElementAt(2);
                    string lName = l.ElementAt(3);
                    string pathoNum = l.ElementAt(4);
                    string runNum = l.ElementAt(5);
                    string tumourSite = l.ElementAt(6);
                    string diseaseLevel = l.ElementAt(7);
                    string background = l.ElementAt(8);
                    string prevTreatment = l.ElementAt(9);
                    string currTreatment = l.ElementAt(10);
                    string conclusion = l.ElementAt(11);
                    Patient p = new Patient(testName, patientId, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, background, prevTreatment, currTreatment, conclusion);
                    toReturn.Add(p);
                }
            }
            return toReturn;
        }

        public  static List<Patient> getPatientListWithMutation(string mutationId)
        {
            List<Patient> toReturn = null;
            List<List<string>> patient = LocalDbDAL.getPatientListByMutation(mutationId);
            if (patient != null)
            {
                toReturn = new List<Patient>();
                foreach (List<string> l in patient)
                {
                    string testName = l.ElementAt(0);
                    string patientId = l.ElementAt(1);
                    string fName = l.ElementAt(2);
                    string lName = l.ElementAt(3);
                    string pathoNum = l.ElementAt(4);
                    string runNum = l.ElementAt(5);
                    string tumourSite = l.ElementAt(6);
                    string diseaseLevel = l.ElementAt(7);
                    string background = l.ElementAt(8);
                    string prevTreatment = l.ElementAt(9);
                    string currTreatment = l.ElementAt(10);
                    string conclusion = l.ElementAt(11);
                    Patient p = new Patient(testName, patientId, fName, lName, pathoNum, runNum, tumourSite, diseaseLevel, background, prevTreatment, currTreatment, conclusion);
                    toReturn.Add(p);
                }
            }
            return toReturn;
        }
    }
}
