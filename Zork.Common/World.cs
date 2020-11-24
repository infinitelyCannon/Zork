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

        public Player SpawnPlayer(string newGameString)
        {
            PlayerState playerState;

            if (string.IsNullOrEmpty(newGameString))
            {
                playerState = new PlayerState();
                playerState.Location = StartingLocation;
            }
            else
                playerState = JsonConvert.DeserializeObject<PlayerState>(newGameString);

            return new Player(this, playerState);
        }

        public string GetStartingLocation()
        {
            return StartingLocation;
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