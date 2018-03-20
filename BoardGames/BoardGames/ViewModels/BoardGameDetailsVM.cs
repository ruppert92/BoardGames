using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.ViewModels
{
    public class BoardGameDetailsVM
    {
        public BoardGameDetailsVM()
        {
            Expansions = new List<BoardGameExpansionVM>();
        }

        public string Owner { get; set; }
        public string Name { get; set; }
        public int? MinPlayers { get; set; }
        public int? MaxPlayers { get; set; }
        public int? IdealMinPlayers { get; set; }
        public int? IdealMaxPlayers { get; set; }
        public int? MinLengthMinutes { get; set; }
        public int? MaxLengthMinutes { get; set; }
        public string ImageFileName { get; set; }
        public int? Intensity { get; set; }
        public bool Played { get; set; }
        public string Comments { get; set; }
        public IEnumerable<BoardGameExpansionVM> Expansions { get; set; }
    }
}
