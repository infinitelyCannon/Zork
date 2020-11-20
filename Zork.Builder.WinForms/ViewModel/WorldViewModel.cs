using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;
using Zork.Builder.WinForms.Data;
using Newtonsoft.Json;

namespace Zork.Builder.WinForms.ViewModel
{
    public class WorldViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BindingList<Room> Rooms { get; set; }

        public string WelcomeMessage { get; set; }

        public string Filename { get; set; }

        public Room StartingLocation 
        {
            get => mStartingLocation;
            set
            {
                mStartingLocation = value;
                mGame.World.StartingLocation = StartingLocation;
            }
        }

        public Game Game
        {
            set
            {
                if(mGame != value)
                {
                    mGame = value;
                    if(mGame != null)
                    {
                        Rooms = mGame.World.Rooms;
                        SetRoomNeighbors(mGame.World.Rooms);
                        WelcomeMessage = mGame.WelcomeMessage;
                        StartingLocation = mGame.World.StartingLocation;
                    }
                    else
                    {
                        Rooms = new BindingList<Room>(Array.Empty<Room>());
                        RoomNeighbors = new List<string>();
                        WelcomeMessage = "";
                        StartingLocation = null;
                    }
                }
            }
        }

        public WorldViewModel(Game game = null)
        {
            Game = game;
        }

        public void SaveWorld()
        {
            if (string.IsNullOrEmpty(Filename))
                throw new InvalidProgramException("Filename expected");

            SetGameProperties();

            JsonSerializer serializer = new JsonSerializer { Formatting = Formatting.Indented };

            using (StreamWriter streamWriter = new StreamWriter(Filename))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, mGame);
            }
        }

        private void SetRoomNeighbors(BindingList<Room> rooms)
        {
            RoomNeighbors = new List<string>();
            RoomNeighbors.Add("");
            foreach(Room r in rooms)
            {
                RoomNeighbors.Add(r.Name);
            }
        }

        private void SetGameProperties()
        {
            mGame.WelcomeMessage = WelcomeMessage;
        }

        private Game mGame;
        private Room mStartingLocation;
        public List<string> RoomNeighbors { get; set; }

        public static string NewFile = "{\"Welcome Message\": \"\",\"World\": {\"Rooms\": [{\"Name\": \"First Room\",\"Description\": \"\",\"Neighbors\":{\"North\": \"\",\"South\": \"\",\"East\": \"\",\"West\": \"\"}}],\"StartingLocation\": \"\"}}";
    }
}
