using System;

namespace Zork.Common.Commands
{
    [CommandClass]
    public static class RestartCommand
    {
        [Command("RESTART", "RESTART")]
        public static void Restart(Game game, CommandContext context)
        {
            game.ConfirmAction("Are you sure you want to restart?", () => game.Restart(), null);
        }
    }
}
