using System;
using LoginServerClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;


namespace LoginServerConsole
{
    public class Program
    {
       
        public static void Main()
        {      
            ServerConfig serverConfig = new ServerConfig();   
            
            // Check to see if the server.config is in the directory
            bool proc = (ServerConfig.DoesFileExist())
                ? true 
                : false;

            if (!proc)
            {
                // LogWriter.WriteErrorMessage();
                TerminateApplication();                
            }


            // Attempt to load ServerConfig
            bool configLoaded = (serverConfig.LoadServerConfig())
                ? true
                : false;

            if (!configLoaded)
            {
                // LogWriter.WriteErrorMessage();
                TerminateApplication();
            }

            // Maker sure server config is valid
            bool validServerConfig = (serverConfig.IsServerConfigValid())
                ? true
                : false;

            if (!validServerConfig)
            {
                // LogWriter.WriteErrorMessage();
                TerminateApplication();
            }

            // Connect to char server
            // ConnectoCharServer()

            // Create a DAL for mysql
            serverConfig.db.CreateMySQLConnectionString();
            Console.WriteLine(serverConfig.db.ConnectionString);
            MySQLDAL mySqlDAL = new MySQLDAL(serverConfig.db);

            // Get the input login email and password
            mySqlDAL.TryLogin("joe@joe.com","GOD");
            // Start a waiting loop for connections here







            Console.ReadKey();
        }



        public static void TerminateApplication()
        {
            Utilities.WriteLineColoredMessage("Check log for details", ConsoleColor.Yellow, ConsoleColor.Red);
            Utilities.WriteLineColoredMessage("Application Terminating", ConsoleColor.Yellow, ConsoleColor.Red);
            Console.ReadKey();
            Environment.Exit(0);
        }




    }
}
