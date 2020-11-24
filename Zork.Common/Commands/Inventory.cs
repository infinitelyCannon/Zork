using System;

namespace Zork.Common.Commands
{
    [CommandClass]
    public static class InventoryCommand
    {
        [Command("INVENTORY", new string[] { "INVENTORY", "I" })]
        public static void Inventory(Game game, CommandContext context)
        {
            if (game.Player.Inventory.Count > 0)
            {
                game.Output.WriteLine("You are carrying:");
                foreach(string item in game.Player.Inventory)
                {
                    game.Output.WriteLine(item);
                }
            }
            else
                game.Output.WriteLine("You are empty handed");
        }
    }
}
