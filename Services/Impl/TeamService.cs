using AutoMapper;
using Data;
using Data.DAO;
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
        IDataService<TeamDAO> teamDS;        

        public TeamService(MapperConfiguration config, IDataService<TeamDAO> data):base(config)
        {
            teamDS = data;
        }

        public ITeamViewModel Create(string name, int skill)
        {
            var teamDAO = new TeamDAO() { Name = name, Skill = skill, TeamType = Domain.Teams.TeamType.BaseTeam };

            teamDS.Create(teamDAO);

            var team = Mapper.Map<Team>(teamDAO);

            return Mapper.Map<TeamViewModel>(team);
        }

        public void Update(ITeamViewModel model)
        {
            var team = Mapper.Map<Team>(model);

            var teamDAO = Mapper.Map<TeamDAO>(team);

            teamDS.Save(teamDAO);
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
