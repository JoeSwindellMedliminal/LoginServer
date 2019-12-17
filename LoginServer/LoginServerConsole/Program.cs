using System;
using LCM;
using LCM.FileIO;
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
            //Our config readers
            DatabaseServerClass dbServerClass = LoadDatabaseConfig();

            UpStreamServerClass upStreamServerClass = LoadUpStreamServerConfig();

            MySQLDAL mySQL = new MySQLDAL(dbServerClass.GetConnectionString());
            // TODO: Test Connection         

            if (!mySQL.TestConnection())
                ChuckError("MySQL Connection test failed!");
            

            // TODO: Bind to Listen Port

            // TODO: Start Up Stream Connection Thread

            // TODO: Wait for connections

            Console.ReadKey();
        }

   
        public static void SampleQuery(MySQLDAL mySQL)
        {
            try
            {
                List<List<string>> results = new List<List<string>>();
                results = mySQL.MakeAQuery("Select * from `accounts` where is_active = 1");

                foreach (List<string> r in results)
                {
                    foreach (string row in r)
                    {
                        Utilities.WriteLineColoredMessage(row, ConsoleColor.Blue, ConsoleColor.White);
                    }
                }

            }
            catch (Exception ex)
            {
                ChuckError(ex.ToString());
            }
        }


        public static UpStreamServerClass LoadUpStreamServerConfig()
        {
            UpStreamConfigReader upConfigReader = new UpStreamConfigReader();
            if (upConfigReader.DoesConfigExist())
            {
                Utilities.WriteGoodBlueMessage("UpStreamServer config found");
            }
            else
            {
                ChuckError("UpStreamServer config does not exist");
            }

            UpStreamServerClass upStreamServer = new UpStreamServerClass();
            try
            {
                upStreamServer =  upConfigReader.LoadUpStreamConfigFile(upStreamServer);
                Utilities.WriteGoodMessage("Up Stream Server Config Loaded");
            } catch (Exception ex)
            {
                Utilities.DumpClassProperties(upStreamServer);
                ChuckError(ex.ToString());
            }

            return upStreamServer;
        }

        public static DatabaseServerClass LoadDatabaseConfig()
        {
            DBConfigReader dBConfigReader = new DBConfigReader();
            if (dBConfigReader.DoesConfigExist())
            {
                Utilities.WriteGoodBlueMessage("Database Config found");
            }
            else
            {
                ChuckError("DB Config does not exist");
            }

            DatabaseServerClass dbServer = new DatabaseServerClass();
            try
            {
                dBConfigReader.LoadConfigFile(dbServer);
                Utilities.WriteGoodMessage("Database Config Loaded");
                return dbServer;
            } catch (Exception ex)
            {
                Utilities.DumpClassProperties(dbServer);
                ChuckError(ex.ToString());               
            }

            return null;            
        }

        public static void ChuckError(string msg)
        {
            Utilities.WriteStarError(msg);
            TerminateApplication();
        }

        public static void TerminateApplication()
        {
            Utilities.WriteApplicationTerminating();
            Console.ReadKey();
            Environment.Exit(0);
        }

    } // End class
}
