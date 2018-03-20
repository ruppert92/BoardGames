using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGames.Data
{
    public static class InjectModules
    {
        public static void LoadTypes(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<AdoNetContext>(_ => new AdoNetContext(new MySqlConnectionFactory(configuration["ConnectionStrings:DefaultConnection"])));
        }
    }
}
