using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Threading;


namespace ECommerce_Application
{
    class Design
    {
        public void Loader(string beofre, string after)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(beofre + "....");
            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }
            Console.WriteLine("\n");
            Console.Write(after + "\n");
            Console.ResetColor();

        }

        public void consoleColorFail()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public void consoleColorSuccess()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void consoleColorInput()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public void consoleColorResetter()
        {
            Console.ResetColor();
        }
    }
}
