using System;
using Zork.Common;
using Zork.Common.Commands;

string[] responses = new string[]
{
    "Good day.",
    "Nice weather we've been having lately.",
    "Nice to see you"
};

var command = new Command("HELLO", new string[] { "HELLO", "HI", "HOWDY" },
    (game, context) =>
    {
        string response = responses[Game.Random.Next(responses.Length)];
        Console.WriteLine(response);
    });

Game.Instance.CommandManager.AddCommand(command);