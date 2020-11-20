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
                Console.WriteLine("You are carrying:");
                foreach(string item in game.Player.Inventory)
                {
                    Console.WriteLine(item);
                }
            }
            else
                Console.WriteLine("You are empty handed");
        }
    }
}
