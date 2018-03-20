using BoardGames.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Factories
{
    public static partial class Factory
    {
        public static BoardGameExpansionVM CreateBoardGameExpansionVM(Common.Models.BoardGameExpansion input)
        {
            var result = new BoardGameExpansionVM()
            {
                Name = input.Name,
                MinPlayers = input.MinPlayers,
                MaxPlayers = input.MaxPlayers,
                MinLengthMinutes = input.MinLengthMinutes,
                MaxLengthMinutes = input.MaxLengthMinutes,
                Played = input.Played
            };

            return result;
        }
    }
}
