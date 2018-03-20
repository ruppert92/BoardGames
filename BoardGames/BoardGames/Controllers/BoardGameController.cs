using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGames.Business.Services.Interfaces;
using BoardGames.Common.Models;
using BoardGames.Factories;
using BoardGames.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGames.Controllers
{
    [Route("api/[controller]")]
    public class BoardGamesController : Controller
    {
        private readonly IBoardGameService _boardGameService;

        public BoardGamesController(IBoardGameService boardGameService)
        {
            _boardGameService = boardGameService;
        }

        [HttpGet("[action]")]
        public IEnumerable<BoardGameVM> AllGames()
        {
            var games = _boardGameService.GetAllBoardGames().Select(Factory.CreateBoardGameVM);
            return games;
        }

        // GET: BoardGame/Details/5
        [HttpGet("[action]/[id]")]
        public BoardGameDetailsVM Details(int id)
        {
            var viewModel = Factory.CreateBoardGameDetailsVM(_boardGameService.GetBoardGameWithExpansionsById(id));
            
            return viewModel;
        }        
    }
}