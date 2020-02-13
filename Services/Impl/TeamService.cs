using AutoMapper;
using Data;
using Domain;
using Domain.Teams;
using Services.ViewModels;
using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Impl
{
    public class TeamService : BaseService, ITeamService
    {
        ITeamDataService teamDS;        

        public TeamService(MapperConfiguration config, ITeamDataService data):base(config)
        {
            teamDS = data;
        }

        public ITeamViewModel Create(string name, int skill)
        {
            throw new NotImplementedException();
        }


        public ITeamViewModel GetById(long id)
        {
            var teamObject = GetDomainObjectById(id);

            var teamView = Mapper.Map<TeamViewModel>(teamObject);
            
            return teamView;
        }

        public ITeam GetDomainObjectById(long id)
        {
            var teamDAO = teamDS.GetById(id);

            return Mapper.Map<Team>(teamDAO);
        }

    }
}
