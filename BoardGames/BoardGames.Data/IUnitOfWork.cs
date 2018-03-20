using BoardGames.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        IBoardGameRepository BoardGameRepository { get; }
        IBoardGameExpansionRepository BoardGameExpansionRepository { get; }
        IOwnerRepository OwnerRepository { get; }
    }
}
