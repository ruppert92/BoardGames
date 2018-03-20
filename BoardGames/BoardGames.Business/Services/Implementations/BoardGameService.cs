using BoardGames.Business.Services.Interfaces;
using BoardGames.Common.Models;
using BoardGames.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Business.Services.Implementations
{
    public class BoardGameService : IBoardGameService
    {
        private readonly AdoNetContext _context;

        public BoardGameService(AdoNetContext context)
        {
            _context = context;
        }

        public IEnumerable<BoardGame> GetAllBoardGames()
        {
            using (var uow = _context.CreateUnitOfWork())
            {
                return uow.BoardGameRepository.SelectAll();
            }
        }

        public BoardGame GetBoardGameWithExpansionsById(int id)
        {
            using (var uow = _context.CreateUnitOfWork())
            {
                var boardGame = uow.BoardGameRepository.SelectBoardGameById(id);
                boardGame.Owner = uow.OwnerRepository.SelectOwnerById(boardGame.OwnerID);
                boardGame.BoardGameExpansions = uow.BoardGameExpansionRepository.SelectBoardGameExpansionsByBoardGameId(id);
                return boardGame;
            }
        }
    }
}
