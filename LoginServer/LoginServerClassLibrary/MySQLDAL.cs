using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LoginServerClassLibrary
{
    public class MySQLDAL
    {
        MySqlConnection conn;

        public MySQLDAL(DatabaseServerClass server)
        {
            server.CreateMySQLConnectionString();
            Console.WriteLine(server.ConnectionString);
            conn = new MySqlConnection(server.ConnectionString); 
        }

        public bool TryLogin(string userEmail, string userPassword)
        {
            try
            {
                Console.WriteLine("Connecting to MySQL");
                conn.Open();
                CharacterToken ct = new CharacterToken();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                return false;
            } finally
            {
                conn.Close();
            }
            
        }


    }
}
