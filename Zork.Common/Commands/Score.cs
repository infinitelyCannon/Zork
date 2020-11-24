using System;

namespace Zork.Common.Commands
{
    [CommandClass]
    public static class ScoreCommand
    {
        [Command("SCORE", "SCORE")]
        public static void Score(Game game, CommandContext context)
        {
            game.Output.WriteLine($"Your score would be {game.Player.Score}, in {game.Player.Moves} moves.");
        }
    }
}
