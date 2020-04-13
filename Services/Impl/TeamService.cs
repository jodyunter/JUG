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

        public TeamService(IMapperConfig config, IDataService<TeamDAO> data):base(config)
        {
            DataService = data;
        }

        public override TeamDAO CreateDAO(TeamViewModel newModel)
        {
            var model = newModel;

            var dao = Mapper.TeamToTeamDAO(Mapper.TeamViewModelToTeam(model));

            return dao;
        }

        public override Team MapDAOToDomain(TeamDAO dao)
        {
            return Mapper.TeamDAOToTeam(dao);
        }

        public override TeamDAO MapDomainToDAO(Team domain)
        {
            return Mapper.TeamToTeamDAO(domain);
        }

        public override TeamViewModel MapDomainToViewModel(Team domain)
        {
            return Mapper.TeamToTeamViewModel(domain);
        }

        public override Team MapViewModelToDomain(TeamViewModel model)
        {
            return Mapper.TeamViewModelToTeam(model);
        }
    }
}
