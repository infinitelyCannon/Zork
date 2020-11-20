using System;
using System.IO;

namespace Zork.Common.Commands
{
    [CommandClass]
    public static class LoadCommand
    {
        [Command("LOAD", "LOAD")]
        public static void Load(Game game, CommandContext context)
        {
            if (File.Exists("./ZorkSave.json"))
                game.LoadGame();
            else
                Console.WriteLine("Restore failed. No save file exists yet.");
        }
    }
}
