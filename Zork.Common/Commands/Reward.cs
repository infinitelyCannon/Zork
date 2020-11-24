using System;

namespace Zork.Common.Commands
{
    [CommandClass]
    public static class RewardCommand
    {
        [Command("REWARD", new string[] { "REWARD", "R" })]
        public static void Reward(Game game, CommandContext context)
        {
            game.ParseNumber("How many points?", (value) => game.Player.Score += value);
        }
    }
}
