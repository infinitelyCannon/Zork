using System;

namespace Zork.Common.Commands
{
    [CommandClass]
    public static class RewardCommand
    {
        [Command("REWARD", new string[] { "REWARD", "R" })]
        public static void Reward(Game game, CommandContext context)
        {
            int amount;
            if(game.ParseNumber("How many points? ", out amount))
            {
                game.Player.Score += amount;
            }
        }
    }
}
