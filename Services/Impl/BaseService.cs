using AutoMapper;
using Data;
using Domain;
using Services.Config;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Impl
{
    public class BaseService : IBaseService
    {
        public IMapperConfig Mapper { get; set; }
        public IDataService<IDAOObject> DataService { get; set; }

        public BaseService(IMapperConfig config)
        {
            Mapper = config;
        }
        
        public IViewModel Create(string name, int skill)
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


        public IVewModel GetById(long id)
        {
            var teamObject = GetDomainObjectById(id);

            var teamView = Mapper.TeamToTeamViewModel((Team)teamObject);

            return teamView;
        }

        public IDomainObject GetDomainObjectById(long id)
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

        public void Delete(long? id)
        {
            if (id != null)
            {
                var teamId = (long)id;

                var daoObject = teamDS.GetById(teamId);
                teamDS.Delete(daoObject);
            }
        }

    }
}
