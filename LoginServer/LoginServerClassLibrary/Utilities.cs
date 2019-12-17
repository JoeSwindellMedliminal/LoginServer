using System;
using System.Reflection;

namespace LCM
{
    public static class Utilities
    {
        public static void WriteStarError(string msgToWrite)
        {
            Console.ResetColor();
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
        public static void WriteApplicationTerminating()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("********************************************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Application is terminating");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("********************************************************************************");
            Console.ResetColor();
        }
        public static void WriteGoodMessage(string msgToWrite)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(msgToWrite);
            Console.ResetColor();
        }
        public static void WriteGoodBlueMessage(string msgToWrite)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(msgToWrite);
            Console.ResetColor();
        }

        public static void DumpClassProperties(object obj)
        {            
            PropertyInfo[] classProp = obj.GetType().GetProperties();
            foreach (PropertyInfo pi in classProp)
            {
                Console.WriteLine();
                Console.ResetColor();
                Console.Write(pi.Name);
                Console.Write(' ');
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(pi.GetValue(obj, null));
            }
        }
    }
}
