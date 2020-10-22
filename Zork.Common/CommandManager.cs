using System;
using System.Collections.Generic;
using System.Linq;

namespace Zork
{
    public class CommandManager
    {
        private HashSet<Command> mCommands;

        public CommandManager() => mCommands = new HashSet<Command>();

        public CommandManager(IEnumerable<Command> commands) => mCommands = new HashSet<Command>(commands);

        public CommandContext Parse(string str)
        {
            var commandQuery = from command in mCommands
                               where command.Verbs.Contains(str, StringComparer.OrdinalIgnoreCase)
                               select new CommandContext(str, command);

            return commandQuery.FirstOrDefault();
        }

        public bool PerformCommand(Game game, string commandString)
        {
            bool result;
            CommandContext context = Parse(commandString);
            if(context.Command != null)
            {
                context.Command.Action(game, context);
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public void AddCommand(Command command) => mCommands.Add(command);

        public void RemoveCommand(Command command) => mCommands.Remove(command);

        public void AddCommands(IEnumerable<Command> commands) => mCommands.UnionWith(commands);

        public void ClearCommands() => mCommands.Clear();
    }
}
