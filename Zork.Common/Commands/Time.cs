using System;

namespace Zork.Common.Commands
{
    [CommandClass]
    public static class TimeCommand
    {
        [Command("TIME", "TIME")]
        public static void Time(Game game, CommandContext context)
        {
            game.Output.WriteLine("You have been playing ZORK for longer than you think.");
        }
    }
}
