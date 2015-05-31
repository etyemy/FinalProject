using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace FinalProject
{

    class LocalDbDAL
    {
        //Connection string for debbuging mode
        string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Dev\Visual_Projects\FinalProject\FinalProject\Database.mdf;Integrated Security=True";

        //Connection string for publish
        //string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

        private SqlConnection conn = null;

        public LocalDbDAL()
        {
            try
            {
                conn = new SqlConnection(connString);
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error on creation: {0}", e.ToString());
                throw e;
            }
        }
        public List<String> getGene(string geneName, string chrom)
        {

            List<String> toReturn = null;
            SqlDataReader rdr = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                cmd.Parameters.Add("@geneName", SqlDbType.NChar).Value = geneName;
                cmd.CommandText = "SELECT * FROM Gene WHERE chrom=@chrom AND name=@geneName";
                conn.Open();
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    toReturn = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        toReturn.Add(rdr.GetString(i));
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }



            return toReturn;
        }
        public void addGene(string name, string chrom, char strand, string exonStarts, string exonEnds)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@name", SqlDbType.NChar).Value = name;
                cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                cmd.Parameters.Add("@strand", SqlDbType.NChar).Value = strand;
                cmd.Parameters.Add("@exonStarts", SqlDbType.NChar).Value = exonStarts;
                cmd.Parameters.Add("@exonEnds", SqlDbType.NChar).Value = exonEnds;
                cmd.CommandText = "INSERT INTO Gene VALUES (@name,@chrom,@strand,@exonStarts,@exonEnds)";

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }


        }

        public List<String> getMutationByDetails(string chrom, int position, char varNuc, char refNuc)
        {

            List<String> toReturn = null;
            SqlDataReader rdr = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                cmd.Parameters.Add("@position", SqlDbType.NChar).Value = position;
                cmd.Parameters.Add("@ref", SqlDbType.NChar).Value = refNuc;
                cmd.Parameters.Add("@var", SqlDbType.NChar).Value = varNuc;
                cmd.CommandText = "SELECT * FROM Mutation WHERE chrom=@chrom AND position=@position AND ref=@ref AND var=@var";
                conn.Open();
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    toReturn = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        string toAdd = rdr.GetString(i).Trim();
                        if (toAdd.Equals(""))
                            toReturn.Add(null);
                        else
                            toReturn.Add(toAdd);
                    }
                }
            }
            catch (Exception e)
            {
               
            }
            finally
            {
                conn.Close();
                rdr.Close();
                
            }
            return toReturn;
            
        }
        public List<string> getMutationListPerPatient(string testName)
        {

            List<string> toReturn = null;
            SqlDataReader rdr = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                cmd.CommandText = "SELECT mutation_id FROM Matches WHERE test_name=@testName";
                conn.Open();
                rdr = cmd.ExecuteReader();
                toReturn = new List<string>();
                while (rdr.Read())
                {
                    toReturn.Add(rdr.GetString(0).Trim());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }
            return toReturn;
        }
        public List<String> getMutationByID(string mutId)
        {

            List<String> toReturn = null;
            SqlDataReader rdr = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@mutId", SqlDbType.NChar).Value = mutId;
                cmd.CommandText = "SELECT * FROM Mutation WHERE mut_id=@mutId";
                conn.Open();
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    toReturn = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        string toAdd = rdr.GetString(i).Trim();
                        if (toAdd.Equals(""))
                            toReturn.Add(null);
                        else
                            toReturn.Add(toAdd);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }
            return toReturn;
        }
        public void addMutation(string mutId, string chrom, int position, string geneName, char refNuc, char varNuc, char strand, string chromNum, string refCodon, string varCodon, string refAA, string varAA, string pMutationName, string cMutationName, string cosmicName, string tumourSite)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@mutId", SqlDbType.NChar).Value = mutId;
                cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                cmd.Parameters.Add("@position", SqlDbType.NChar).Value = position;
                cmd.Parameters.Add("@geneName", SqlDbType.NChar).Value = geneName;
                cmd.Parameters.Add("@refNuc", SqlDbType.NChar).Value = refNuc;
                cmd.Parameters.Add("@varNuc", SqlDbType.NChar).Value = varNuc;
                cmd.Parameters.Add("@strand", SqlDbType.NChar).Value = strand;
                cmd.Parameters.Add("@chromNum", SqlDbType.NChar).Value = chromNum;
                cmd.Parameters.Add("@refCodon", SqlDbType.NChar).Value = refCodon;
                cmd.Parameters.Add("@varCodon", SqlDbType.NChar).Value = varCodon;
                cmd.Parameters.Add("@refAA", SqlDbType.NChar).Value = refAA;
                cmd.Parameters.Add("@varAA", SqlDbType.NChar).Value = varAA;
                cmd.Parameters.Add("@pMutationName", SqlDbType.NChar).Value = pMutationName;
                cmd.Parameters.Add("@cMutationName", SqlDbType.NChar).Value = cMutationName;
                cmd.Parameters.Add("@cosmicName", SqlDbType.NChar).Value = cosmicName;
                cmd.Parameters.Add("@tumourSite", SqlDbType.NChar).Value = tumourSite;
                cmd.CommandText = "INSERT INTO Mutation VALUES(@mutId,@chrom,@position,@geneName,@refNuc,@varNuc,@strand,@chromNum,@refCodon,@varCodon,@refAA,@varAA,@pMutationName,@cMutationName,@cosmicName,@tumourSite)";

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
            
        }
        internal bool mutationExist(string chrom, int position, char refNuc, char varNuc)
        {

            bool toReturn = false;
            SqlDataReader rdr = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                cmd.Parameters.Add("@position", SqlDbType.NChar).Value = position;
                cmd.Parameters.Add("@refNuc", SqlDbType.NChar).Value = refNuc;
                cmd.Parameters.Add("@varNuc", SqlDbType.NChar).Value = varNuc;
                cmd.CommandText = "SELECT * FROM Mutation WHERE chrom=@chrom AND position=@position AND ref=@refNuc AND var=@varNuc";
                conn.Open();
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    toReturn = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }
            return toReturn;
        }

        public List<String> getPatientById(string id)
        {

            List<String> toReturn = null;
            SqlDataReader rdr = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@id", SqlDbType.NChar).Value = id;
                cmd.CommandText = "SELECT * FROM Patients WHERE id=@id";
                conn.Open();
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    toReturn = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        toReturn.Add(rdr.GetString(i).Trim());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }
            return toReturn;
        }
        internal bool patientExist(string testName)
        {

            bool toReturn = false;
            SqlDataReader rdr = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                cmd.CommandText = "SELECT * FROM Patients WHERE test_name=@testName";
                conn.Open();
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    toReturn = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }
            return toReturn;
        }
        public void addPatient(string testName, string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string diseaseLevel, string background, string prevTreatment, string currTreatment, string conclusion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                cmd.Parameters.Add("@id", SqlDbType.NChar).Value = id;
                cmd.Parameters.Add("@fName", SqlDbType.NChar).Value = fName;
                cmd.Parameters.Add("@lName", SqlDbType.NChar).Value = lName;
                cmd.Parameters.Add("@pathologicalNum", SqlDbType.NChar).Value = pathologicalNum;
                cmd.Parameters.Add("@runNum", SqlDbType.NChar).Value = runNum;
                cmd.Parameters.Add("@tumourSite", SqlDbType.NChar).Value = tumourSite;
                cmd.Parameters.Add("@diseaseLevel", SqlDbType.NChar).Value = diseaseLevel;
                cmd.Parameters.Add("@prevTreatment", SqlDbType.NChar).Value = prevTreatment;
                cmd.Parameters.Add("@currTreatment", SqlDbType.NChar).Value = currTreatment;
                cmd.Parameters.Add("@background", SqlDbType.NChar).Value = background;
                cmd.Parameters.Add("@conclusion", SqlDbType.NChar).Value = conclusion;
                cmd.CommandText = "INSERT INTO Patients VALUES (@testName,@id,@fName,@lName,@pathologicalNum,@runNum,@tumourSite,@diseaseLevel,@background,@prevTreatment,@currTreatment,@conclusion)";
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
        public void updatePatient(string testName,string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string diseaseLevel, string prevTreatment, string currTreatment, string background, string conclusion)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@id", SqlDbType.NChar).Value = id;
                cmd.Parameters.Add("@fName", SqlDbType.NChar).Value = fName;
                cmd.Parameters.Add("@lName", SqlDbType.NChar).Value = lName;
                cmd.Parameters.Add("@pathologicalNum", SqlDbType.NChar).Value = pathologicalNum;
                cmd.Parameters.Add("@runNum", SqlDbType.NChar).Value = runNum;
                cmd.Parameters.Add("@tumourSite", SqlDbType.NChar).Value = tumourSite;
                cmd.Parameters.Add("@diseaseLevel", SqlDbType.NChar).Value = diseaseLevel;
                cmd.Parameters.Add("@prevTreatment", SqlDbType.NChar).Value = prevTreatment;
                cmd.Parameters.Add("@currTreatment", SqlDbType.NChar).Value = currTreatment;
                cmd.Parameters.Add("@background", SqlDbType.NChar).Value = background;
                cmd.Parameters.Add("@conclusion", SqlDbType.NChar).Value = conclusion;
                cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                cmd.CommandText = "UPDATE Patients SET id=@id,first_name=@fName,last_name=@lName,pathological_number=@pathologicalNum"
                    + ",run_number=@runNum,tumour_site=@tumourSite,disease_level=@diseaseLevel,previous_treatment=@prevTreatment"
                    + ",current_treatment=@currTreatment,background=@background,conclusion=@conclusion,test_name=@testName "
                    + "WHERE test_name=@testName";
                conn.Open();
                cmd.ExecuteNonQuery();
            }
           catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
        public void addMatch(string testName, string mutId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                cmd.Parameters.Add("@mutId", SqlDbType.NChar).Value = mutId;
                cmd.CommandText = "INSERT into Matches VALUES (@testName,@mutId)";
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        public int getNumOfTestsWithSameMut(string mutId)
        {
            int toReturn = 0;
            SqlDataReader rdr = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@mutId", SqlDbType.NChar).Value = mutId;
                cmd.CommandText = "SELECT COUNT(DISTINCT test_name) FROM Matches WHERE mutation_id=@mutId";
                conn.Open();
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    toReturn = rdr.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }
            return toReturn;
        }

        internal List<List<string>> getPatientListById(string id)
        {
            List<List<String>> toReturn = null;
            SqlDataReader rdr = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@id", SqlDbType.NChar).Value = id;
                cmd.CommandText = "SELECT * FROM Patients WHERE id=@id";
                conn.Open();
                rdr = cmd.ExecuteReader();
                bool first = true;
                while (rdr.Read())
                {
                    if (first)
                    {
                        toReturn = new List<List<string>>();
                        first = false;
                    }
                    
                    List<string> l = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        l.Add(rdr.GetString(i).Trim());
                    }
                    toReturn.Add(l);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }
            return toReturn;
        }

        internal List<List<string>> getPatientListByMutation(string mutationId)
        {
            List<List<String>> toReturn = null;
            SqlDataReader rdr = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Parameters.Add("@mutationId", SqlDbType.NChar).Value = mutationId;
                cmd.CommandText = "SELECT * FROM Patients,Matches WHERE Matches.test_name=Patients.test_name AND Matches.mutation_id=@mutationId";
                conn.Open();
                rdr = cmd.ExecuteReader();
                bool first = true;
                while (rdr.Read())
                {
                    Console.WriteLine("xxx");
                    if (first)
                    {
                        toReturn = new List<List<string>>();
                        first = false;
                    }

                    List<string> l = new List<string>();
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        l.Add(rdr.GetString(i).Trim());
                    }
                    toReturn.Add(l);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }
            return toReturn;
        }
    }
}
