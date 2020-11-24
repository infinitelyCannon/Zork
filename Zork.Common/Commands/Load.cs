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
            game.LoadGame();
        }
    }
}
