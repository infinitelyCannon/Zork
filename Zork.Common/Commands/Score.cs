using System;

namespace Zork.Common.Commands
{
    [CommandClass]
    public static class ScoreCommand
    {
        [Command("SCORE", "SCORE")]
        public static void Score(Game game, CommandContext context)
        {
            Console.WriteLine("Your score would be {0}, in {1} moves.", game.Player.Score, game.Player.Moves);
        }
    }
}
