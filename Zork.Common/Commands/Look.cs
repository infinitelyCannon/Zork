﻿using System;

namespace Zork.Common.Commands
{
    [CommandClass]
    public static class LookCommand
    {
        [Command("LOOK", new string[] { "LOOK", "L" })]
        public static void Look(Game game, CommandContext context) => game.Output.WriteLine($"{game.Player.Location}\n{game.Player.Location.Description}");
    }
}
