using System;

namespace LoginServerClassLibrary
{
    public static class Utilities
    {
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

        public static  void WriteLineColoredMessage(String msg, ConsoleColor foreGround, ConsoleColor backGround = ConsoleColor.Black)
        {
            Console.ResetColor();
            Console.ForegroundColor = foreGround;
            Console.BackgroundColor = backGround;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
