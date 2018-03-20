using BoardGames.Business.Services.Implementations;
using BoardGames.Business.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Business
{
    public static class InjectModules
    {
        public static void LoadTypes(IServiceCollection services, IConfiguration configuration)
        {
            Data.InjectModules.LoadTypes(services, configuration);

            services.AddTransient<IBoardGameService, BoardGameService>();
        }
    }
}
