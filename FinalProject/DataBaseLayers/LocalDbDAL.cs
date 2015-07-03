﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace FinalProject
{

     public class LocalDbDAL
    {
        //Connection string for debbuging mode
        static string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Dev\Visual_Projects\FinalProject\FinalProject\Database.mdf;Integrated Security=True";

        //Connection string for publish
        //static string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

        public static List<String> getGene(string geneName, string chrom)
        {
            List<String> toReturn = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                cmd.Parameters.Add("@geneName", SqlDbType.NChar).Value = geneName;
                cmd.CommandText = "SELECT * FROM Gene WHERE chrom=@chrom AND name=@geneName";
                using(SqlDataReader rdr =cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        toReturn = new List<string>();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            toReturn.Add(rdr.GetString(i));
                        }
                    }
                }
            }
            return toReturn;
        }
        public static void addGene(string name, string chrom, char strand, string exonStarts, string exonEnds)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@name", SqlDbType.NChar).Value = name;
                cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                cmd.Parameters.Add("@strand", SqlDbType.NChar).Value = strand;
                cmd.Parameters.Add("@exonStarts", SqlDbType.NChar).Value = exonStarts;
                cmd.Parameters.Add("@exonEnds", SqlDbType.NChar).Value = exonEnds;
                cmd.CommandText = "INSERT INTO Gene VALUES (@name,@chrom,@strand,@exonStarts,@exonEnds)";
                cmd.ExecuteNonQuery();
            }
        }

        public static List<String> getMutationByDetails(string chrom, int position, char varNuc, char refNuc)
        {
            List<String> toReturn = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                cmd.Parameters.Add("@position", SqlDbType.NChar).Value = position;
                cmd.Parameters.Add("@ref", SqlDbType.NChar).Value = refNuc;
                cmd.Parameters.Add("@var", SqlDbType.NChar).Value = varNuc;
                cmd.CommandText = "SELECT * FROM Mutation WHERE chrom=@chrom AND position=@position AND ref=@ref AND var=@var";
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
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
            }
            return toReturn;
        }
        public static List<string> getMutationListPerPatient(string testName)
        {
            List<String> toReturn = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                cmd.CommandText = "SELECT mutation_id FROM Matches WHERE test_name=@testName";
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    toReturn = new List<string>();
                    while (rdr.Read())
                    {
                        toReturn.Add(rdr.GetString(0).Trim());
                    }
                }
            }
            return toReturn;
        }
        public static List<String> getMutationByID(string mutId)
        {
            List<String> toReturn = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@mutId", SqlDbType.NChar).Value = mutId;
                cmd.CommandText = "SELECT * FROM Mutation WHERE mut_id=@mutId";
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
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
            }
            return toReturn;
        }
        public static void addMutation(string mutId, string chrom, int position, string geneName, char refNuc, char varNuc, char strand, string chromNum, string refCodon, string varCodon, string refAA, string varAA, string pMutationName, string cMutationName, string cosmicName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
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
                cmd.CommandText = "INSERT INTO Mutation VALUES(@mutId,@chrom,@position,@geneName,@refNuc,@varNuc,@strand,@chromNum,@refCodon,@varCodon,@refAA,@varAA,@pMutationName,@cMutationName,@cosmicName)";
                cmd.ExecuteNonQuery();
            }
        }
        public static bool mutationExist(string chrom, int position, char refNuc, char varNuc)
        {
            bool toReturn = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@chrom", SqlDbType.NChar).Value = chrom;
                cmd.Parameters.Add("@position", SqlDbType.NChar).Value = position;
                cmd.Parameters.Add("@refNuc", SqlDbType.NChar).Value = refNuc;
                cmd.Parameters.Add("@varNuc", SqlDbType.NChar).Value = varNuc;
                cmd.CommandText = "SELECT * FROM Mutation WHERE chrom=@chrom AND position=@position AND ref=@refNuc AND var=@varNuc";
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        toReturn = true;
                    }
                }
            }
            return toReturn;
        }

        public static List<String> getPatientById(string id)
        {
            List<String> toReturn = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@id", SqlDbType.NChar).Value = id;
                cmd.CommandText = "SELECT * FROM Patients WHERE id=@id";
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        toReturn = new List<string>();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            toReturn.Add(rdr.GetString(i).Trim());
                        }
                    }
                }
            }
            return toReturn;
        }
        public static bool patientExist(string testName)
        {
            bool toReturn = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                cmd.CommandText = "SELECT * FROM Patients WHERE test_name=@testName";
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        toReturn = true;
                    }
                }
            }
            return toReturn;
        }
        public static void addPatient(string testName, string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string diseaseLevel, string background, string prevTreatment, string currTreatment, string conclusion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
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
                cmd.ExecuteNonQuery();
            }
        }
        public static void updatePatient(string testName, string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string diseaseLevel, string prevTreatment, string currTreatment, string background, string conclusion)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
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
                cmd.ExecuteNonQuery();
            }
        }
        public static void addMatch(string testName, string mutId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@testName", SqlDbType.NChar).Value = testName;
                cmd.Parameters.Add("@mutId", SqlDbType.NChar).Value = mutId;
                cmd.CommandText = "INSERT into Matches VALUES (@testName,@mutId)";
                cmd.ExecuteNonQuery();
            }
        }

        public static int getNumOfPatientWithSameMutation(string mutId)
        {
            int toReturn = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@mutId", SqlDbType.NChar).Value = mutId;
                cmd.CommandText = "SELECT COUNT(DISTINCT test_name) FROM Matches WHERE mutation_id=@mutId";
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        toReturn = rdr.GetInt32(0);
                    }
                }
            }
            return toReturn;
        }

        public static List<List<string>> getPatientListById(string id)
        {
            List<List<String>> toReturn = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@id", SqlDbType.NChar).Value = id;
                cmd.CommandText = "SELECT * FROM Patients WHERE id=@id";
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
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
            }
            return toReturn;
        }

        public static List<List<string>> getPatientListByMutation(string mutationId)
        {
            List<List<String>> toReturn = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.Add("@mutationId", SqlDbType.NChar).Value = mutationId;
                cmd.CommandText = "SELECT * FROM Patients,Matches WHERE Matches.test_name=Patients.test_name AND Matches.mutation_id=@mutationId";
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
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
            }
            return toReturn;
        }
    }
}
