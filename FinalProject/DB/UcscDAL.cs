using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;

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
                Console.WriteLine("Error on creation: {0}", e.ToString());
                throw e;
            }
            
        }
        
        public List<String> getGene(string geneName, string chrom)
        {
            conn.Open();
            List<String> toReturn =null;
            string query =
                "SELECT strand, MIN(cdsStart), MAX(cdsEnd), MAX(exonCount), exonStarts, exonEnds " +
                "FROM refGene " +
                "WHERE chrom='" + chrom + "' " +
                "AND name2='" + geneName + "'";
            MySqlDataReader rdr = executeQuery(query);
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
        
        public List<String> getCosmicDetails(string chromNum, int position,char refNuc,char varNuc)
        {
            conn.Open();
            List<String> toReturn = null;
            string query =
                "SELECT cosmic_mutation_id, mut_syntax_aa, mut_syntax_cds, tumour_site " +
                "FROM cosmicRaw " +
                "WHERE chromosome = '" + chromNum + "' " +
                "AND grch37_start ='" + position + "' " +
                "AND mut_syntax_cds REGEXP '" +refNuc+">"+varNuc + "$'";
            MySqlDataReader rdr = executeQuery(query);
            if (rdr.Read())
            {
                toReturn = new List<string>();
                toReturn.Add(rdr.GetString(0));
                toReturn.Add(rdr.GetString(1));
                toReturn.Add(rdr.GetString(2));
                toReturn.Add(rdr.GetString(3));
            }
            conn.Close();
            rdr.Close();
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
                Console.WriteLine("Error on executing: {0}", ex.ToString());
                return null;
            }
        }
    }
}
