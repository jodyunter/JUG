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
using System.Text;

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
            return new List<ITeamViewModel>()
            {
                new TeamViewModel(1, "Team 1", 5, ViewModels.Teams.TeamType.BaseTeam),
                new TeamViewModel(1, "Team 2", 5, ViewModels.Teams.TeamType.BaseTeam),
                new TeamViewModel(1, "Team 3", 5, ViewModels.Teams.TeamType.BaseTeam),
                new TeamViewModel(1, "Team 4", 5, ViewModels.Teams.TeamType.BaseTeam),
                new TeamViewModel(1, "Team 5", 5, ViewModels.Teams.TeamType.BaseTeam),
                new TeamViewModel(1, "Team 6", 5, ViewModels.Teams.TeamType.BaseTeam),
                new TeamViewModel(1, "Team 7", 5, ViewModels.Teams.TeamType.BaseTeam),
            };
        }
    }
}
