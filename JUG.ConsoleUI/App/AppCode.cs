using Data;
using Data.DAO;
using Data.Impl;
using Domain.Teams;
using Services;
using Services.Config;
using Services.Impl;
using Services.ViewModels.Teams;
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
        public JUGContext db { get; set; }

        public AppCode()
        {            
            SetupDataBase(true);
            SetupDataServices();
            SetupServices();
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
            TeamService = new TeamService(TeamDataService);
            GameService = new GameService(TeamService, GameDataService, TeamDataService);
        }
    }
}
