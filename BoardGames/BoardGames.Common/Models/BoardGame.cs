using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Common.Models
{
    public class BoardGame
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
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

        public Owner Owner { get; set; }
        
        public IEnumerable<BoardGameExpansion> BoardGameExpansions { get; set; }
    }
}
