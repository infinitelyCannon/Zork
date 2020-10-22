using System;

namespace Zork
{
    class Program
    {
        private enum CommandLineArguments
        {
            GameFilename = 0
        }

        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultGameFilename);

            Game.Start(gameFilename);
            Console.WriteLine("Thank you for playing!");
        }
    }
}
