using System;

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
        private static readonly string[,] Rooms = {
            {"Rocky Trail", "South of House", "Canyon View"},
            {"Forest", "West of House", "Behind House"},
            {"Dense Woods", "North of House", "Clearing"}
        };
        private static (int Row, int Column) Location = (1,1);
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");
            Console.WriteLine(Rooms[Location.Row, Location.Column]);

            Commands command = Commands.UNKNOWN;
            while(command != Commands.QUIT)
            {
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;
                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door.\n\n" +
                            "A rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        outputString = Move(command) ? $"You moved {command}" : "The way is shut!";
                        break;
                    case Commands.UNKNOWN:
                    default:
                        outputString = "Unknown command";
                        break;
                }
                Console.WriteLine(outputString);
                if (command != Commands.QUIT)
                    Console.WriteLine(Rooms[Location.Row, Location.Column]);
            }
        }

        private static bool Move(Commands command)
        {
            switch (command)
            {
                case Commands.EAST:
                    if (Location.Column + 1 < Rooms.GetLength(0))
                    {
                        ++Location.Column;
                        return true;
                    }
                    return false;
                case Commands.WEST:
                    if (Location.Column - 1 >= 0)
                    {
                        --Location.Column;
                        return true;
                    }
                    return false;
                case Commands.NORTH:
                    if (Location.Row + 1 < Rooms.GetLength(1))
                    {
                        ++Location.Row;
                        return true;
                    }
                    return false;
                case Commands.SOUTH:
                    if(Location.Row - 1 >= 0)
                    {
                        --Location.Row;
                        return true;
                    }
                    return false;
                default:
                    throw new Exception("An illegal command was passed to move");
            }
        }

        private static Commands ToCommand(string commandString)
        {
            return Enum.TryParse(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
        }
    }
}
