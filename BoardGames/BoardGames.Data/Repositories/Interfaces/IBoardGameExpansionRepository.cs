using BoardGames.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Data.Repositories.Interfaces
{
    public interface IBoardGameExpansionRepository
    {
        void Insert(BoardGameExpansion boardGameExpansion);

        void Update(BoardGameExpansion boardGameExpansion);

        void Delete(int id);

        BoardGameExpansion SelectBoardGameExpansionById(int id);

        IEnumerable<BoardGameExpansion> SelectBoardGameExpansionsByBoardGameId(int boardGameId);
    }
}
