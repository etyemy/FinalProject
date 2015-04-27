using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FinalProject
{
    class LocalDbDAL
    {
        string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Dev\Visual_Projects\FinalProject\FinalProject\Database.mdf;Integrated Security=True";
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
            conn.Open();
            List<String> toReturn = null;
            string query =
                "SELECT * " +
                "FROM Gene " +
                "WHERE chrom='" + chrom + "' " +
                "AND name='" + geneName + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                toReturn = new List<string>();
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    toReturn.Add(rdr.GetString(i));
                }

            }
            conn.Close();
            rdr.Close();

            return toReturn;
        }
        public void addGene(string name, string chrom, char strand, string exonStarts, string exonEnds)
        {
            conn.Open();
            string query =
                "INSERT INTO Gene " +
                "VALUES ('" + name + "','" + chrom + "','" + strand + "','" + exonStarts + "','" + exonEnds + "')";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<String> getMutationByDetails(string chrom, int position, char varNuc, char refNuc)
        {
            conn.Open();
            List<String> toReturn = null;
            string query =
                "SELECT * " +
                "FROM Mutation " +
                "WHERE chrom='" + chrom + "' " +
                "AND position='" + position + "' " +
                "AND ref='" + refNuc + "' " +
                "AND var='" + varNuc + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

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
            conn.Close();

            rdr.Close();

            return toReturn;
        }
        public List<string> getMutationListPerPatient(string patientId)
        {
            conn.Open();
            List<string> toReturn = null;
            string query =
                "SELECT mutation_id " +
                "FROM Matches " +
                "WHERE patient_id='" + patientId + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            toReturn = new List<string>();
            while (rdr.Read())
            {
                toReturn.Add(rdr.GetString(0).Trim());
            }
            conn.Close();
            rdr.Close();
            return toReturn;
        }
        public List<String> getMutationByID(string mutId)
        {
            conn.Open();
            List<String> toReturn = null;
            string query =
                "SELECT * " +
                "FROM Mutation " +
                "WHERE mut_id='" + mutId + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

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
            conn.Close();
            rdr.Close();
            return toReturn;
        }
        public void addMutation(string mutId,string chrom, int position, string geneName, char refNuc, char varNuc, char strand, string chromNum, string refCodon, string varCodon, string refAA, string varAA, string pMutationName, string cMutationName, string cosmicName, string tumourSite)
        {
            
            conn.Open();
            string query =
                "INSERT INTO Mutation " +
                "VALUES ('" + mutId + "','" + chrom + "','" + position + "','" + geneName + "','" + refNuc + "','" + varNuc + "','" + strand + "','" + chromNum + "','" + refCodon + "','" + varCodon + "','" + refAA + "','" + varAA + "','" + pMutationName + "','" + cMutationName + "','" + cosmicName + "','"+tumourSite+"')";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
        internal bool mutationExist(string chrom, int position, char refNuc, char varNuc)
        {
            conn.Open();
            bool toReturn = false;
            string query =
                "SELECT * " +
                "FROM Mutation " +
                "WHERE chrom='" + chrom + "' " +
                "AND position='" + position + "' " +
                "AND ref='" + refNuc + "' " +
                "AND var='" + varNuc + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                toReturn = true;
            }
            conn.Close();
            rdr.Close();

            return toReturn;
        }

        public List<String> getPatientById(string id)
        {
            conn.Open();
            List<String> toReturn = null;
            string query =
                "SELECT * " +
                "FROM Patients " +
                "WHERE id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                toReturn = new List<string>();
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    toReturn.Add(rdr.GetString(i));
                }
            }
            conn.Close();
            rdr.Close();

            return toReturn;
        }
        internal bool patientExist(string id)
        {
            conn.Open();
            bool toReturn = false;
            string query =
                "SELECT * " +
                "FROM Patients " +
                "WHERE id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                toReturn = true;
            }
            conn.Close();
            rdr.Close();

            return toReturn;
        }
        public void addPatient(string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string deseaseLevel, string prevTreatment, string currTreatment, string background, string conclusion)
        {
            conn.Open();
            string query =
                "INSERT INTO Patients " +
                "VALUES ('" + id + "','" + fName + "','" + lName + "','" + pathologicalNum + "','" + runNum + "','" + tumourSite + "','" + deseaseLevel + "','" + prevTreatment + "','" + currTreatment + "','" + background + "','" + conclusion + "')";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
        public void updatePatient(string id, string fName, string lName, string pathologicalNum, string runNum, string tumourSite, string deseaseLevel, string prevTreatment, string currTreatment, string background, string conclusion)
        {
            conn.Open();
            string query =
                "UPDATE Patients " +
                "SET id='" + id + "', first_name='" + fName + "', last_name='" + lName + "', pathological_number='" + pathologicalNum + "', run_number='" + runNum + "', tumour_site='" + tumourSite + "', disease_level='" + deseaseLevel + "', previous_treatment='" + prevTreatment + "', current_treatment='" + currTreatment + "', background='" + background + "', conclusion='" + conclusion + "' " +
                "WHERE id='" + id + "'";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
        public void addMatch(string patientId,string mutId)
        {
            conn.Open();
            string query =
                "INSERT INTO Matches " +
                "VALUES ('" + patientId + "','" + mutId + "')";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
