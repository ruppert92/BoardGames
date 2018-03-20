using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BoardGames.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}
