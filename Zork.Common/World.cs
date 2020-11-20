using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System;
using System.Runtime.Serialization;

namespace Zork.Common
{
    public class World
    {
        public HashSet<Room> Rooms { get; set; }

        [JsonIgnore]
        public ReadOnlyDictionary<string, Room> RoomsByName => new ReadOnlyDictionary<string, Room>(mRoomsByName);

        public Player SpawnPlayer(bool newGame)
        {
            PlayerState playerState;

            if (newGame)
            {
                playerState = new PlayerState();
                playerState.Location = StartingLocation;
            }
            else
            {
                if(File.Exists("./ZorkSave.json"))
                    playerState = JsonConvert.DeserializeObject<PlayerState>(File.ReadAllText("./ZorkSave.json"));
                else
                {
                    // Should not ever reach this state, but just in case, we'll start a new game.
                    playerState = new PlayerState();
                    playerState.Location = StartingLocation;
                }
            }

            return new Player(this, playerState);
        }

        public void SetStartingLocation(string location)
        {
            StartingLocation = location;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            mRoomsByName = Rooms.ToDictionary(room => room.Name, room => room);

            foreach(Room room in Rooms)
            {
                room.UpdateNeighbors(this);
            }
        }

        [JsonProperty]
        private string StartingLocation { get; set; }

        private Dictionary<string, Room> mRoomsByName;
    }
}