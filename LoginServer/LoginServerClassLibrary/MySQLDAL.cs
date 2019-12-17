using System;
using MySql.Data.MySqlClient;

namespace LCM
{
    public class MySQLDAL
    {
        MySqlConnection conn;

        public MySQLDAL(string connectionString)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
       
            conn.Open();
            Console.WriteLine("Connected to MySql");
       

            conn.Close();
            Console.WriteLine("Closed connection to MySql");


        }


    }
}
