using System;
using System.Collections.Generic;

namespace Zork.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandClassAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {
        public string CommandName { get; }

        public IEnumerable<string> Verbs { get; }

        public CommandAttribute(string name, string verb) :
            this(name, new string[] { verb })
        {

        }

        public CommandAttribute(string name, string[] verbs)
        {
            CommandName = name;
            Verbs = verbs;
        }
    }
}
