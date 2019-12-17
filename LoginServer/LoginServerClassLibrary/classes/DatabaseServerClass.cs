using System;

namespace LCM
{
    public class DatabaseServerClass
    {        
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string ServerAddress { get; set; }
        public string Port { get; set; }
        public string ConnectionString { get; private set; }

        public DatabaseServerClass()
        {
        }

        public DatabaseServerClass(string username, string password, string database, string serverAddress, string port)
        {
            UserName = username;
            Password = password;
            Database = database;
            ServerAddress = serverAddress;
            Port = port;

            CreateMySQLConnectionString();
        }


        public void CreateMySQLConnectionString()
        {
            ConnectionString = String.Format("server={0};user={1};database={2};port={3};password={4}", ServerAddress, UserName, Database, Port, Password);
        }

        public string GetConnectionString()
        {
            CreateMySQLConnectionString();
            return ConnectionString;
        }

      
    }
}
