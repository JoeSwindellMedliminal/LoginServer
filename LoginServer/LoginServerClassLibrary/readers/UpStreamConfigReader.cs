using System.IO;

namespace LCM.FileIO
{
    public class UpStreamConfigReader
    {
        const string UPSTREAM_CONFIG_FILE = "./config/server.config";

        public bool DoesConfigExist()
        {
            return File.Exists(UPSTREAM_CONFIG_FILE) ? true : false;
        }

        public UpStreamServerClass LoadUpStreamConfigFile(UpStreamServerClass upStreamServerClass)
        {
            using (StreamReader reader = File.OpenText(UPSTREAM_CONFIG_FILE))
            {
                string line;
                string[] rawFile;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line == string.Empty || line.StartsWith("#"))
                        continue;

                    rawFile = line.Split(null);

                    switch (rawFile[0])
                    {
                        case "username":
                            upStreamServerClass.UserName = rawFile[1];
                            break;
                        case "password":
                            upStreamServerClass.Password = rawFile[1];
                            break;
                        case "serveraddress":
                            upStreamServerClass.ServerAddress = rawFile[1];
                            break;
                        case "port":
                            upStreamServerClass.Port = rawFile[1];
                            break;
                    } // End Switch
                } // End While
            } // End using
            return upStreamServerClass;
        }
    }
}
