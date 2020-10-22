using System;
using System.Collections.Generic;
using System.Linq;

namespace Zork
{
    public class Command : IEquatable<Command>
    {
        public string Name { get; set; }

        public string[] Verbs { get; }

        public Action<Game, CommandContext> Action { get; }

        public Command(string name, string verb, Action<Game, CommandContext> action) :
            this(name, new string[] { verb }, action)
        {

        }

        public Command(string name, IEnumerable<string> verbs, Action<Game, CommandContext> action)
        {
            Name = name;
            Verbs = verbs.ToArray();
            Action = action;
        }

        public static bool operator ==(Command left, Command right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (left is null || right is null)
                return false;

            return left.Name == right.Name;
        }

        public static bool operator !=(Command left, Command right) => !(left == right);

        public override bool Equals(object obj) => obj is Command ? this == (Command)obj : false;

        public bool Equals(Command other) => this == other;

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => Name;
    }
}
