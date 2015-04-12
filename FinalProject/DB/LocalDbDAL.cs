using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FinalProject
{
    class LocalDbDAL
    {
        string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Dev\Visual_Projects\FinalProject\FinalProject\DB\Database.mdf;Integrated Security=True";
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

        public List<String> getMutation(string chrom, int position, char varNuc, char refNuc)
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
                for (int i = 1; i < rdr.FieldCount; i++)
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
        public void addMutation(string chrom, int position, string geneName, char refNuc, char varNuc, char strand, string chromNum, string refCodon, string varCodon, string refAA, string varAA, string pMutationName, string cMutationName, string cosmicName, string tumourSite)
        {
            
            conn.Open();
            string query =
                "INSERT INTO Mutation " +
                "VALUES ('" + generateMutId() + "','" + chrom + "','" + position + "','" + geneName + "','" + refNuc + "','" + varNuc + "','" + strand + "','" + chromNum + "','" + refCodon + "','" + varCodon + "','" + refAA + "','" + varAA + "','" + pMutationName + "','" + cMutationName + "','" + cosmicName + "','"+tumourSite+"')";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        private string generateMutId()
        {
            DateTime t = DateTime.Now;
            string temp = "";
            temp += t.Year;
            temp += t.Month;
            temp += t.Day;
            temp += t.Hour;
            temp += t.Minute;
            temp += t.Second;
            temp += t.Millisecond;
            Console.WriteLine(temp);
            return temp;
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
    }
}
