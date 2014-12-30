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
        private MySqlDataReader rdr = null;
        private MySqlCommand cmd = null;

        public UcscDAL()
        {
            sb = new MySqlConnectionStringBuilder();
            sb.Server = "genome-mysql.cse.ucsc.edu";
            sb.UserID = "genome";
            sb.Database = "hg19";
            conn = new MySqlConnection(sb.ToString());
        }

        public List<String> getGene(string geneName, string chrom)
        {
            List<String> toReturn = new List<string>();
            string query = 
                "SELECT name, name2, chrom, strand, MAX(cdsStart), MAX(cdsEnd), MAX(exonCount), exonStarts, exonEnds "+
                "FROM refGene "+
                "WHERE chrom='" + geneName + "' "+
                "AND name2='" + chrom + "'";
            try
            {
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    toReturn.Add(rdr.GetString(i));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                rdr.Close();
                conn.Close();
            }
            return toReturn;
        }
        public string getCosmicName(string chromNum, int position, string mutationName,string geneName)
        {
            string toReturn = null;
            string query =
                "SELECT cosmic_mutation_id " +
                "FROM cosmicRaw "+ 
                "WHERE chromosome = '" + chromNum + "' "+
                "AND gene_name ='" + geneName + "'" +
                "AND grch37_start ='" + position + "'" +
                "AND cosmicRaw.mut_syntax_aa='" + mutationName + "'";
            try
            {
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    toReturn = rdr.GetString(0);
                }
                  

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            finally
            {
                rdr.Close();
                conn.Close();
            }
            return toReturn;
        }
    }
}
