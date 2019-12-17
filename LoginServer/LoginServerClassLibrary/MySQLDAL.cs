using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace LCM
{
    // Exceptions are intentionally not handled here.
    // This is so you can handle them in your application
    public class MySQLDAL
    {
        public string ConnString = "";

        public MySQLDAL(string connectionString)
        {
            ConnString = connectionString;         
        }

        public bool TestConnection()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnString))
            {
                try {
                    conn.Open();
                    conn.Close();
                    Utilities.WriteGoodBlueMessage("MySQL Connection Test GOOD");
                    return true;
                } catch (Exception ex)
                {
                    Utilities.WriteStarError(ex.ToString());
                    return false;
                }
            }  
        }

        // A query which returns a single result
        public string MakeAScalarQuery(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnString))
            {
                string sql = query;
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        conn.Close();
                        return result.ToString();
                    }

                }
                conn.Close();
            }
            return "";
        }

        // A query that returns a list of results
        public List<List<string>> MakeAQuery(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnString))               
            {
                conn.Open();
                string sql = query;
                List<List<string>> results = new List<List<string>>();

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int cols = reader.FieldCount;
                        int x = 0;
                        List<string> row = new List<string>();
                        while (x < cols)
                        {                            
                            row.Add(reader[x].ToString());
                            x++;
                        }
                        results.Add(row);
                    }
                    reader.Close();
                    conn.Close();
                    return results;
                }               
            }            
        }

        // A query that doesn't return results (insert, update delete)
        public bool MakeANonQuery(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnString))
            {
                string sql = query;

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }                
            }            
        }



    }
}
