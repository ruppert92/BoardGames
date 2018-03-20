using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BoardGames.Data.Repositories
{
    public abstract class Repository<TEntity> where TEntity : new()
    {
        private AdoNetContext _context;

        public Repository(AdoNetContext context)
        {
            _context = context;
        }

        protected AdoNetContext Context { get { return _context; } }

        protected IEnumerable<TEntity> ToList(IDbCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                List<TEntity> items = new List<TEntity>();
                while (reader.Read())
                {                    
                    items.Add(MapToDTO(reader));
                }
                return items;
            }
        }

        protected abstract TEntity MapToDTO(IDataRecord record);
    }
}
