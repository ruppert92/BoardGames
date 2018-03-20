using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.ViewModels
{
    public class BoardGameVM
    {
        public string Name { get; set; }
        public int? MinPlayers { get; set; }
        public int? MaxPlayers { get; set; }
        public int? MinLengthMinutes { get; set; }
        public int? MaxLengthMinutes { get; set; }
        public bool Played { get; set; }
    }
}
