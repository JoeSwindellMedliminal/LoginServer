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

            // TODO: Test Connection
            MySQLDAL mySQL = ConnectToDB(dbServerClass.GetConnectionString());
           

            // TODO: Bind to Listen Port

            // TODO: Start Up Stream Connection Thread

            // TODO: Wait for connections

            Console.ReadKey();
        }

        public static MySQLDAL ConnectToDB(string connString)
        {
            try
            {
                MySQLDAL mySQL = new MySQLDAL(connString);
                return mySQL;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
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
