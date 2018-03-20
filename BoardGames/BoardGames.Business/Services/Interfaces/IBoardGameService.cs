using BoardGames.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Business.Services.Interfaces
{
    public interface IBoardGameService
    {
        IEnumerable<BoardGame> GetAllBoardGames();

        BoardGame GetBoardGameWithExpansionsById(int id);
    }
}
