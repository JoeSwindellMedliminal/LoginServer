using System;
using System.IO;

namespace LCM.FileIO
{
    public class DBConfigReader
    {
        const string DB_CONFIG_FILE = "./config/db.config";

        // Simple file path and file check
        public bool DoesConfigExist()
        {
            return File.Exists(DB_CONFIG_FILE) ? true : false;
        }

        // TODO : remove File IO from here and generalize this and Upstream reader
        public DatabaseServerClass LoadConfigFile(DatabaseServerClass dbServerClass)
        {            
            using (StreamReader reader = File.OpenText(DB_CONFIG_FILE))
            {
                string line;
                string[] rawFile;

                while ((line = reader.ReadLine()) != null)
                {
                    // Is line empty or comment
                    if (line == string.Empty || line.StartsWith("#"))
                        continue;

                    // Split on whitespace
                    rawFile = line.Split(null);

                    switch (rawFile[0])
                    {
                        case "username":
                            dbServerClass.UserName = rawFile[1];
                            break;
                        case "password":
                            dbServerClass.Password = rawFile[1];
                            break;
                        case "database":
                            dbServerClass.Database = rawFile[1];
                            break;
                        case "serveraddress":
                            dbServerClass.ServerAddress = rawFile[1];
                            break;
                        case "port":
                            dbServerClass.Port = rawFile[1];
                            break;
                    } // End Switch
                } // End while

            } // End using        
            return dbServerClass;
        }
    }
}
