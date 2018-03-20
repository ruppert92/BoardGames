using BoardGames.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Data.Repositories.Interfaces
{
    public interface IOwnerRepository
    {
        void Insert(Owner owner);

        void Update(Owner owner);

        void Delete(int id);

        Owner SelectOwnerById(int id);
    }
}
