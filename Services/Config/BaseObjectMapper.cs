using AutoMapper;
using Data.DAO;
using Domain.Teams;
using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Config
{
    public abstract class BaseObjectMapper<TViewModel, TDomainObject, TDAOObject>:IJUGMapper<TViewModel, TDomainObject, TDAOObject>
    {
        public IMapper Mapper { get; set; }
        public MapperConfiguration Config { get; set; }

        public BaseObjectMapper()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Team, TeamViewModel>()
                .ForMember(dest => dest.Message, act => act.Ignore())
                .ForMember(dest => dest.MessageLevel, act => act.Ignore());
                cfg.CreateMap<TeamViewModel, Team>();
                cfg.CreateMap<Team, TeamDAO>();
                cfg.CreateMap<TeamDAO, Team>();
                cfg.CreateMap<TeamDAO, ITeam>().As<Team>();
                //if you only get the interface, then map it to the base implementation
                cfg.CreateMap<ITeam, TeamDAO>();
                
            });

            Config.AssertConfigurationIsValid();

            Mapper = Config.CreateMapper();
        }

        public virtual TViewModel DomainToViewModel(TDomainObject domain)
        {
            return Mapper.Map<TViewModel>(domain);
        }

        public virtual TDomainObject ViewModelToDomain(TViewModel viewModel)
        {
            return Mapper.Map<TDomainObject>(viewModel);
        }

        public virtual TDomainObject DAOToDomain(TDAOObject dao)
        {
            return Mapper.Map<TDomainObject>(dao);
        }

        public virtual TDAOObject DomainToDAO(TDomainObject domain)
        {
            return Mapper.Map<TDAOObject>(domain);
        }
    }
}
