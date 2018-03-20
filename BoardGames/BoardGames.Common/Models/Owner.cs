using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Common.Models
{
    public class Owner
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<BoardGame> BoardGames { get; set; }
        public IEnumerable<BoardGameExpansion> BoardGameExpansions { get; set; }
    }
}
