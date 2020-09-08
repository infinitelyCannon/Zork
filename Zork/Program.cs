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
        private static readonly string[] Rooms = {"Forest", "West of House", "Behind House", "Clearing", "Canyon View"};
        private static int RoomIndex = 1;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");
            Console.WriteLine(Rooms[RoomIndex]);

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
                    Console.WriteLine(Rooms[RoomIndex]);
            }
        }

        private static bool Move(Commands command)
        {
            switch (command)
            {
                case Commands.EAST:
                    if (RoomIndex + 1 < Rooms.Length)
                    {
                        ++RoomIndex;
                        return true;
                    }
                    else
                        return false;
                case Commands.WEST:
                    if (RoomIndex - 1 >= 0)
                    {
                        --RoomIndex;
                        return true;
                    }
                    else
                        return false;
                case Commands.NORTH:
                case Commands.SOUTH:
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
