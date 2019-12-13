using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LoginServerClassLibrary
{
    public class ServerConfig
    {
        public DatabaseServerClass db = new DatabaseServerClass();
        public CharServerClass cs = new CharServerClass();
        const string SERVER_CONFIG = "server.config";

        public ServerConfig()
        {          
        }

        public static bool DoesFileExist()
        {
            // server.config is missing
            if (!File.Exists(SERVER_CONFIG))
            {
                Utilities.WriteLineColoredMessage("server.config not found", ConsoleColor.Yellow, ConsoleColor.Red);
                return false;
            }
            Utilities.WriteLineColoredMessage("server.config found", ConsoleColor.White, ConsoleColor.Blue);
            return true;
        }

        public bool LoadServerConfig()
        {
            try
            {   
                // This is kind of ugly maybe refactor this
                using (StreamReader reader = File.OpenText(SERVER_CONFIG))
                {
                    string line;
                    string[] rawFile;
                    string whichFile = "";
              
                    while ((line = reader.ReadLine()) != null)
                    {                        
                        // Is line empty or a comment
                        if (line == string.Empty || line.StartsWith("#"))
                            continue;

                        rawFile = line.Split('=');

                        if (rawFile[0] == "configtype")
                        {
                            whichFile = rawFile[1];
                            Console.WriteLine("Reading " + whichFile +" config.");
                        }

                        switch (whichFile)
                        {
                            case "database":
                                switch (rawFile[0])
                                {
                                    case "username":                                       
                                        db.UserName = rawFile[1];
                                        break;
                                    case "password":                                        
                                        db.Password = rawFile[1];
                                        break;
                                    case "database":                                        
                                        db.Database = rawFile[1];
                                        Console.WriteLine(db.Database);
                                        break;
                                    case "serveraddress":                                        
                                        db.ServerAddress = rawFile[1];
                                        break;
                                    case "port":                                        
                                        db.Port = rawFile[1];
                                        break;
                                }
                                break;
                            case "char":
                                switch (rawFile[0])
                                {
                                    case "username":                                       
                                        cs.UserName = rawFile[1];
                                        break;
                                    case "password":                                        
                                        cs.Password = rawFile[1];
                                        break;
                                    case "serveraddress":                                        
                                        cs.ServerAddress = rawFile[1];
                                        break;
                                    case "port":                                        
                                        cs.Port = rawFile[1];
                                        break;
                                }
                                break;
                        } // End Switch     
                    }

                    
                    Console.WriteLine("^^^^^^^^^^" + db.Database);
                    return true;
                }
            }
            catch(Exception e)
            {
                //LogWrite.WriteLog();
                Console.WriteLine("Server.Config could not be read");
                Console.WriteLine(e.Message);
                return false;
            }     
        }

        public bool IsServerConfigValid()
        {
            // Right now we are just looping through each property and making sure its not empty/null/whitespace. 
           
            //PropertyInfo[] dbProperties = db.GetType().GetProperties();
            //PropertyInfo[] csProperties = cs.GetType().GetProperties();

            //foreach(PropertyInfo pi in dbProperties)
            //{
            //    if (IsPropertyValid(pi.GetValue(db, null).ToString()))
            //    {                   
            //        Utilities.WriteLineColoredMessage("##" + pi.GetValue(db, null), ConsoleColor.Yellow, ConsoleColor.Red);
            //        return false;
            //    }                
            //}

            //foreach (PropertyInfo pi in csProperties)
            //{
            //    if (IsPropertyValid(pi.GetValue(cs, null).ToString()))
            //    {
            //        Utilities.WriteLineColoredMessage("##" + pi.GetValue(cs, null), ConsoleColor.Yellow, ConsoleColor.Red);
            //        return false;
            //    }
                
            //}
            return true;            
        }

        public bool IsPropertyValid(string prop)
        {            
            return String.IsNullOrWhiteSpace(prop);
        }
    }
}
