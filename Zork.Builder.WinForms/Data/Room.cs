using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zork.Builder.WinForms.Data
{
    public class Room : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public string North { get; set; }

        [JsonIgnore]
        public string South { get; set; }

        [JsonIgnore]
        public string East { get; set; }

        [JsonIgnore]
        public string West { get; set; }

        public Room(string name)
        {
            Name = name;
            Description = "";
            Neighbors = new Dictionary<Common.Directions, string>();

            string[] directions = Enum.GetNames(typeof(Common.Directions));
            for (int i = 0; i < directions.Length; ++i)
            {
                Neighbors.Add((Common.Directions)i, "");
            }
            North = South = East = West = "";
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // Fill in any gaps for neighbor values
            Common.Directions[] directions = (Common.Directions[]) Enum.GetValues(typeof(Common.Directions));
            foreach(Common.Directions dir in directions)
            {
                if (Neighbors.ContainsKey(dir))
                {
                    switch (dir)
                    {
                        case Common.Directions.North:
                            North = Neighbors[dir];
                            break;
                        case Common.Directions.South:
                            South = Neighbors[dir];
                            break;
                        case Common.Directions.East:
                            East = Neighbors[dir];
                            break;
                        case Common.Directions.West:
                            West = Neighbors[dir];
                            break;
                    }
                }
                else
                {
                    switch (dir)
                    {
                        case Common.Directions.North:
                            North = "";
                            Neighbors.Add(dir, "");
                            break;
                        case Common.Directions.South:
                            South = "";
                            Neighbors.Add(dir, "");
                            break;
                        case Common.Directions.East:
                            East = "";
                            Neighbors.Add(dir, "");
                            break;
                        case Common.Directions.West:
                            West = "";
                            Neighbors.Add(dir, "");
                            break;
                    }
                }
            }
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            Neighbors[Common.Directions.North] = North;
            Neighbors[Common.Directions.South] = South;
            Neighbors[Common.Directions.East] = East;
            Neighbors[Common.Directions.West] = West;
        }

        [JsonProperty]
        private Dictionary<Zork.Common.Directions, string> Neighbors { get; set; }
    }
}
