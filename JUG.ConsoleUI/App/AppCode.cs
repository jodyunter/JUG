using Data;
using Data.DAO;
using Data.Impl;
using Services;
using Services.Config;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace JUG.ConsoleUI.App
{
    public class AppCode
    {
        public IGameService GameService { get; set; }
        public ITeamService TeamService { get; set; }
        
        public IDataService<TeamDAO> TeamDataService { get; set; }
        public GameDataService GameDataService { get; set; }
        public MapperConfig AutoMapperConfig { get; set; }
        public JUGContext db { get; set; }

        public AppCode()
        {
            SetupAutoMapper();
            SetupDataBase(true);
            SetupDataServices();
            SetupServices();
        }

        public void SetupAutoMapper()
        {
            AutoMapperConfig = new MapperConfig();
        }

        public void SetupDataBase(bool deleteAll)
        {
            db = new JUGContext();
            if (deleteAll)
            {
                db.DeleteData();
            }
        }

        public void SetupDataServices()
        {
            TeamDataService = new BaseDataService<TeamDAO>();
            GameDataService = new GameDataService();
        }

        public void SetupServices()
        {
            var config = new MapperConfig();
            TeamService = new TeamService(config, TeamDataService);
            GameService = new GameService(config, TeamService, GameDataService, TeamDataService);
        }
    }
}
