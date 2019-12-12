using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServerClassLibrary
{
    public class ServerConfig
    {
        private string username;
        private string password;
        private string database;
        private string serverAddress;
        private string port;

        public string ConnectionString;

        public ServerConfig(string UserName, string Password, string Databse, string ServerAddress, string Port)
        {
            username = UserName;
            password = Password;
            database = Databse;
            serverAddress = ServerAddress;
            port = Port;

            CreateMySQLConnectionString();

        }

        
        public void CreateMySQLConnectionString()
        {
            ConnectionString = String.Format("server={0};user={1};database={2};port={3};password={4}", serverAddress, username, database, port, password);
        }
    }
}
