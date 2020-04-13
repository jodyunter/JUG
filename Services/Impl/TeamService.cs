using AutoMapper;
using Data;
using Data.DAO;
using Domain;
using Domain.Teams;
using Services.Config;
using Services.ViewModels;
using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Impl
{
    public class TeamService : BaseService<TeamViewModel, Team, TeamDAO>, ITeamService
    {          

        public TeamService(IDataService<TeamDAO> data):base()
        {            
            DataService = data;            
        }

        public override void CreateMapper()
        {
            Mapper = new TeamMapper();
        }
    }
}
