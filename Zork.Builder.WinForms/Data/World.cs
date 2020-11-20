using System.Linq;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Zork.Builder.WinForms.Data
{
    public class World : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BindingList<Room> Rooms { get; set; }

        [JsonIgnore]
        public Room StartingLocation { get; set; }

        [JsonProperty(PropertyName = "StartingLocation")]
        private string StartingLocationName { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            StartingLocation = Rooms.FirstOrDefault(r => r.Name == StartingLocationName);
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            StartingLocationName = StartingLocation.Name;
        }
    }
}
