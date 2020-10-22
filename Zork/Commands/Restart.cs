using System;

namespace Zork
{
    [CommandClass]
    public static class RestartCommand
    {
        [Command("RESTART", "RESTART")]
        public static void Restart(Game game, CommandContext context)
        {
            if (game.ConfirmAction("Are you sure you want to restart?"))
                game.Restart();
        }
    }
}
