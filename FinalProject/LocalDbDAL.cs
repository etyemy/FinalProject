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
        private SqlCommand cmd = null;

        public LocalDbDAL()
        {
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();
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
            string query =
                "SELECT * " +
                "FROM Gene " +
                "WHERE chrom='" + chrom + "' " +
                "AND name='" + geneName + "'";
            cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            
            if (rdr.Read())
            {
                toReturn=new List<string>();
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    toReturn.Add(rdr.GetString(i));
                }

            }
            rdr.Close();
           
            return toReturn;
        }
        public void addGene(string name, string chrom, char strand, string exonStarts, string exonEnds)
        {
            
            string query =
                "INSERT INTO Gene " +
                "VALUES ('"+name+"','"+chrom+"','"+strand+"','"+exonStarts+"','"+exonEnds+"')";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.ExecuteNonQuery();
            
        }
        
    }
}
