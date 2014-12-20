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
        public UcscDAL()
        {
            sb = new MySqlConnectionStringBuilder();
            sb.Server = "genome-mysql.cse.ucsc.edu";
            sb.UserID = "genome";
            sb.Database = "hg19";
            conn = new MySqlConnection(sb.ToString());

        }

        public List<string> getTableColName(string tableName)
        {

            conn.Open();
            List<String> Tablenames = new List<String>();
            string query = "SHOW columns FROM " + tableName + ";";
            MySqlCommand command = new MySqlCommand(query, conn);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Tablenames.Add(reader.GetString(0));
                }
            }
            Console.WriteLine("TABLE: " + tableName);
            foreach (string s in Tablenames)
            {
                Console.WriteLine(s);
            }
            conn.Close();
            return Tablenames;
        }

        public void allTableToFile(string path)
        {
            conn.Open();
            StreamWriter w = new StreamWriter(path);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SHOW TABLES;";
            MySqlDataReader Reader;
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                    row += Reader.GetValue(i).ToString() + "\n";
                w.Write(row);
            }
            w.Close();
            conn.Close();
        }
        public void getFirst20Lines(string tableName)
        {
            conn.Open();
            string stm = "SELECT * FROM " + tableName;
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            int i = 0;
            while (rdr.Read() && i < 20)
            {
                for (int j = 0; j < rdr.FieldCount; j++)
                {
                    Console.Write(rdr[j].ToString() + " ");
                }
                Console.WriteLine("");
                i++;
            }
            rdr.Close();
            conn.Close();
        }

    }
}
