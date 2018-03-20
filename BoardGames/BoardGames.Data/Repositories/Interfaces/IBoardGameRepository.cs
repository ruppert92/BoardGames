using BoardGames.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Data.Repositories.Interfaces
{
    public interface IBoardGameRepository
    {
        void Insert(BoardGame boardGame);

        void Update(BoardGame boardGame);

        void Delete(int id);

        IEnumerable<BoardGame> SelectAll();

        BoardGame SelectBoardGameById(int id);
    }
}
