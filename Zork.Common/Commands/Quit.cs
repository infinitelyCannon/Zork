using System;

namespace Zork.Common.Commands
{
    [CommandClass]
    public static class QuitCommand
    {
        [Command("QUIT", new string[] { "QUIT", "Q" })]
        public static void Quit(Game game, CommandContext context)
        {
            if (game.ConfirmAction("Are you sure you want to quit?"))
                game.Quit();
        }
    }
}
