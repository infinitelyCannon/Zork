using System;
using System.Collections.Generic;

namespace Zork
{
    enum Commands
    {
        QUIT,
        LOOK,
        NORTH,
        SOUTH,
        EAST,
        WEST,
        UNKNOWN
    }

    class Program
    {
        private static string CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        private static readonly List<Commands> Directions = new List<Commands>
        {
            Commands.NORTH,
            Commands.SOUTH,
            Commands.EAST,
            Commands.WEST
        };

        private static readonly string[,] Rooms = {
            {"Rocky Trail", "South of House", "Canyon View"},
            {"Forest", "West of House", "Behind House"},
            {"Dense Woods", "North of House", "Clearing"}
        };
        private static (int Row, int Column) Location = (1,1);
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while(command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;
                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded front door.\n\n" +
                            "A rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (!Move(command))
                            Console.WriteLine("The way is shut!");
                        break;
                    case Commands.UNKNOWN:
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }

        private static bool Move(Commands command)
        {
            Assert.IsTrue(IsDirection(command), "Invalid direction");

            bool isValidMove = true;
            switch (command)
            {
                case Commands.EAST when Location.Column < Rooms.GetLength(0) - 1:
                    ++Location.Column;
                    break;
                case Commands.WEST when Location.Column > 0:
                    --Location.Column;
                    break;
                case Commands.NORTH when Location.Row < Rooms.GetLength(1) - 1:
                    ++Location.Row;
                    break;
                case Commands.SOUTH when Location.Row > 0:
                    --Location.Row;
                    break;
                default:
                    isValidMove = false;
                    break;
            }

            return isValidMove;
        }

        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static Commands ToCommand(string commandString) =>
            Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
    }
}
