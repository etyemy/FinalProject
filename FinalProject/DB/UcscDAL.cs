﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;

namespace FinalProject
{
    class UcscDAL
    {
        static string connectionString = @"server=genome-mysql.cse.ucsc.edu;user id=genome;database=hg19";

        public static List<String> getGene(string geneName, string chrom)
        {
            List<String> toReturn = null;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@chrom", chrom);
                cmd.Parameters.AddWithValue("@geneName", geneName);
                cmd.CommandText = "SELECT strand, MIN(cdsStart), MAX(cdsEnd), MAX(exonCount), exonStarts, exonEnds " +
                    "FROM refGene " +
                "WHERE chrom=@chrom " +
                "AND name2=@geneName";
                using (MySqlDataReader rdr = cmd.ExecuteReader())
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

        public static List<String> getCosmicDetails(string chromNum, int position, char refNuc, char varNuc)
        {
            List<String> toReturn = null;
            string mutSyntaxRegex = refNuc + ">" + varNuc + "$";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@chromNum", chromNum);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@mutSyntaxRegex", mutSyntaxRegex);
                cmd.CommandText = "SELECT cosmic_mutation_id, mut_syntax_aa, mut_syntax_cds, tumour_site " +
                "FROM cosmicRaw " +
                "WHERE chromosome = @chromNum " +
                "AND grch37_start =@position " +
                "AND mut_syntax_cds REGEXP @mutSyntaxRegex";
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    List<string> cosmicIdList = new List<string>();
                    string cosmicIDs = "";
                    bool firstTime = true;
                    while (rdr.Read())
                    {
                        if (firstTime)
                        {
                            toReturn = new List<string>();
                            toReturn.Add(rdr.GetString(0));
                            toReturn.Add(rdr.GetString(1));
                            toReturn.Add(rdr.GetString(2));
                            toReturn.Add(rdr.GetString(3));
                            cosmicIdList.Add(rdr.GetString(0));
                            firstTime = false;
                        }
                        else
                        {
                            bool found = false;
                            foreach (string s in cosmicIdList)
                                if (s.Trim().Equals(rdr.GetString(0).Trim()))
                                    found = true;
                            if (!found)
                            {
                                toReturn[0] += " " + rdr.GetString(0);
                                cosmicIdList.Add(rdr.GetString(0));
                            }
                        }
                    }
                    if (toReturn != null)
                        toReturn.Add(cosmicIDs);
                }
            }
            return toReturn;
        }
    }
}
