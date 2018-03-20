using BoardGames.Data.Repositories.Implementations;
using BoardGames.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BoardGames.Data
{
    public class AdoNetUnitOfWork : IUnitOfWork
    {
        private IDbTransaction _transaction;
        private AdoNetContext _context;
        private readonly Action<AdoNetUnitOfWork> _rolledBack;
        private readonly Action<AdoNetUnitOfWork> _committed;

        public AdoNetUnitOfWork(AdoNetContext context, IDbTransaction transaction, Action<AdoNetUnitOfWork> rolledBack, Action<AdoNetUnitOfWork> committed)
        {
            _context = context;
            _transaction = transaction;
            _rolledBack = rolledBack;
            _committed = committed;
        }

        public IDbTransaction Transaction {
            get
            {
                return _transaction;
            }
            private set
            {
                _transaction = value;
            }
        }

        public void Dispose()
        {
            if (_transaction == null)
                return;

            _transaction.Rollback();
            _transaction.Dispose();
            _rolledBack(this);
            _transaction = null;
        }

        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException("May not call save changes twice.");

            _transaction.Commit();
            _committed(this);
            _transaction = null;
        }

        private IBoardGameRepository _boardGameRepository = null;

        public IBoardGameRepository BoardGameRepository
        {
            get
            {
                if (_boardGameRepository == null)
                    _boardGameRepository = new BoardGameRepository(_context);

                return _boardGameRepository;
            }
        }

        private IBoardGameExpansionRepository _boardGameExpansionRepository = null;

        public IBoardGameExpansionRepository BoardGameExpansionRepository
        {
            get
            {
                if (_boardGameExpansionRepository == null)
                    _boardGameExpansionRepository = new BoardGameExpansionRepository(_context);

                return _boardGameExpansionRepository;
            }
        }

        private IOwnerRepository _ownerRepository = null;

        public IOwnerRepository OwnerRepository
        {
            get
            {
                if (_ownerRepository == null)
                    _ownerRepository = new OwnerRepository(_context);

                return _ownerRepository;
            }
        }
    }
}
