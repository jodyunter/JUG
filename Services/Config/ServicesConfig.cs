using Data;
using Data.DAO;
using Data.Impl;
using Microsoft.Extensions.DependencyInjection;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Config
{
    public static class ServicesConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            services.AddDbContext<JUGContext>(ServiceLifetime.Singleton);
            
            services.AddSingleton<IGameDataService, GameDataService> ();          
            services.AddSingleton<IDataService<TeamDAO>, BaseDataService<TeamDAO>>();

            services.AddSingleton<ITeamService, TeamService>();
            services.AddSingleton<IGameService, GameService>();

            return services;
        }
    }
}
