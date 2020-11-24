using System;
using System.IO;
using Zork.Common;

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

            ConsoleOutputService output = new ConsoleOutputService();
            ConsoleInputService input = new ConsoleInputService();

            Game.StartFromFile(gameFilename, input, output);
            Game.Instance.CommandManager.PerformCommand(Game.Instance, "LOOK");
            Game.Instance.LoadGameString += OnLoadGameString;
            Game.Instance.OnSaveGame += OnSaveGameString;

            while (Game.Instance.IsRunning)
            {
                output.Write("\n> ");
                input.GetInput();
            }

            Console.WriteLine("Thank you for playing!");
        }

        private static string OnLoadGameString()
        {
            if (File.Exists("./ZorkSave.json"))
                return File.ReadAllText("./ZorkSave.json");
            else
                return string.Empty;
        }

        private static void OnSaveGameString(object sender, string data)
        {
            File.WriteAllText("./ZorkSave.Json", data);
        }
    }
}
