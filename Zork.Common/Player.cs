using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zork.Common
{
    public enum Directions
    {
        North,
        South,
        East,
        West
    }

    /*
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
    */

    public class Player
    {
        public World World { get; }

        public int Moves { get; set; }

        [JsonIgnore]
        public Room Location { get; private set; }

        [JsonIgnore]
        public int Score { get; set; }

        [JsonIgnore]
        public List<string> Inventory { get; set; }

        [JsonIgnore]
        public string LocationName
        {
            get
            {
                return Location?.Name;
            }
            set
            {
                Location = World?.RoomsByName.GetValueOrDefault(value);
            }
        }

        public Player(World world, PlayerState data)
        {
            World = world;
            LocationName = data.Location;
            Score = data.Score;
            Moves = data.Moves;
            Inventory = data.Inventory;
        }

        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue(direction, out Room destination);
            if (isValidMove)
                Location = destination;

            return isValidMove;
        }

        public PlayerState GetSaveData()
        {
            PlayerState state = new PlayerState();
            state.Inventory = Inventory;
            state.Location = LocationName;
            state.Moves = Moves;
            state.Score = Score;

            return state;
        }
    }
}