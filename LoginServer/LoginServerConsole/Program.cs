using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.IO;

namespace LoginServerConsole
{
    public class Program
    {
        const string STAR_WARNING = "";
        public static void Main()
        {
            bool serverConfigLoad = LoadServerConfig();
          
            if (serverConfigLoad)
            {
                WriteLineColoredMessage("server.config loaded", ConsoleColor.White, ConsoleColor.Blue);
            } else
            {
                WriteLineColoredMessage("server.config not loaded", ConsoleColor.Yellow, ConsoleColor.Red);
            }
            Console.ReadKey();
        }


        public static bool LoadServerConfig()
        {

            // server.config is missing
            if (!File.Exists("server.configa"))
            {
                WriteStarError("server.config is missing");                
                return false;
            }


            StreamReader reader = File.OpenText("server.config");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }

       

            return true;
        }


        public static void WriteStarError(string msgToWrite)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("********************************************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msgToWrite);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("********************************************************************************");
            Console.ResetColor();
        }

        public static void WriteLineColoredMessage(String msg, ConsoleColor foreGround, ConsoleColor backGround = ConsoleColor.Black)
        {
            Console.ResetColor();
            Console.ForegroundColor = foreGround;
            Console.BackgroundColor = backGround;
            Console.WriteLine(msg);
            Console.ResetColor();
        }


    }
}
