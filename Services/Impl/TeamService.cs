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
    public class TeamService : BaseService, ITeamService
    {
        IDataService<TeamDAO> teamDS;        

        public TeamService(IMapperConfig config, IDataService<TeamDAO> data):base(config)
        {
            teamDS = data;
        }

        public ITeamViewModel Create(string name, int skill)
        {
            var teamDAO = new TeamDAO() { Name = name, Skill = skill, TeamType = Domain.Teams.TeamType.BaseTeam };

            teamDS.Create(teamDAO);

            var team = Mapper.TeamDAOToTeam(teamDAO);

            return Mapper.TeamToTeamViewModel(team);
        }

        public void Update(ITeamViewModel model)
        {
            var team = Mapper.TeamViewModelToTeam((TeamViewModel)model);

            var teamDAO = Mapper.TeamToTeamDAO(team);

            teamDS.Save(teamDAO);
        }


        public ITeamViewModel GetById(long id)
        {
            var teamObject = GetDomainObjectById(id);

            var teamView = Mapper.TeamToTeamViewModel((Team)teamObject);
            
            return teamView;
        }

        public ITeam GetDomainObjectById(long id)
        {
            var teamDAO = teamDS.GetById(id);

            return Mapper.TeamDAOToTeam(teamDAO);
        }

        public IList<ITeamViewModel> GetAll()
        {

            var teamDAOs = teamDS.GetAll();

            var teams = Mapper.TeamDAOToTeam(teamDAOs);

            var models = Mapper.TeamToTeamViewModel(teams);

            return models.ToList<ITeamViewModel>();

        }
    }
}
