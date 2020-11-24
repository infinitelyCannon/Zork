using System.Collections.Generic;

namespace Zork.Common
{
    public class PlayerState
    {
        public int Moves { get; set; }

        public int Score { get; set; }

        public List<string> Inventory { get; set; }

        public string Location { get; set; }

        public PlayerState()
        {
            Inventory = new List<string>();
            Moves = 0;
            Score = 0;
        }
    }
}
