namespace Zork.Common.Commands
{
    [CommandClass]
    public static class SaveCommand
    {
        [Command("SAVE", "SAVE")]
        public static void Save(Game game, CommandContext context)
        {
            game.SaveGame();
        }
    }
}
