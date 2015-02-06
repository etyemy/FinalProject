using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class UcscDAL
    {
        private MySqlConnection conn = null;
        private MySqlConnectionStringBuilder sb = null;
        private MySqlCommand cmd = null;

        public UcscDAL()
        {
            sb = new MySqlConnectionStringBuilder();
            sb.Server = "genome-mysql.cse.ucsc.edu";
            sb.UserID = "genome";
            sb.Database = "hg19";
            try
            {
                conn = new MySqlConnection(sb.ToString());
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
                throw e;
            }
        }

        public List<String> getGene(string geneName, string chrom)
        {
            conn.Open();
            List<String> toReturn = new List<string>();
            string query =
                "SELECT strand, MAX(cdsStart), MAX(cdsEnd), MAX(exonCount), exonStarts, exonEnds " +
                "FROM refGene " +
                "WHERE chrom='" + geneName + "' " +
                "AND name2='" + chrom + "'";
            MySqlDataReader rdr = executeQuery(query);
            if (rdr.Read())
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    toReturn.Add(rdr.GetString(i));
                }
            rdr.Close();
            conn.Close();
            return toReturn;
        }
        public string getCosmicName(string chromNum, int position, string mutationName, string geneName)
        {
            conn.Open();
            string toReturn = null;
            string query =
                "SELECT cosmic_mutation_id " +
                "FROM cosmicRaw " +
                "WHERE chromosome = '" + chromNum + "' " +
                "AND gene_name ='" + geneName + "'" +
                "AND grch37_start ='" + position + "'" +
                "AND cosmicRaw.mut_syntax_aa='" + mutationName + "'";
            MySqlDataReader rdr = executeQuery(query);
            if (rdr.Read())
            {
                toReturn = rdr.GetString(0);
            }
            rdr.Close();
            conn.Close();
            return toReturn;
        }

        private MySqlDataReader executeQuery(string query)
        {
            try
            {
                cmd = new MySqlCommand(query, conn);
                return cmd.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                return null;
            }
        }
    }
}
