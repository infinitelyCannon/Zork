using System.ComponentModel;

namespace Zork.Builder.WinForms.Data
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string WelcomeMessage { get; set; }

        public World World { get; set; }
    }
}
