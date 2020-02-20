using AutoMapper;
using AutoMapper.Configuration;
using Data.DAO;
using Domain.Games;
using Domain.Teams;
using Services.ViewModels.Games;
using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Config
{
    //modify this so that we explicity have a mapper method.  Sometimes we'll need to have a data service to do the mapping properly or intermediate steps
    //maybe change this to mapper service?
    public class MapperConfig:IMapperConfig
    {
        public IMapper Mapper { get; set; }
        public MapperConfiguration Config { get; set; }
        
        public MapperConfig()
        {            
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Team, TeamViewModel>();
                cfg.CreateMap<TeamViewModel, Team>();
                cfg.CreateMap<Team, TeamDAO>();
                cfg.CreateMap<TeamDAO, Team>();
                cfg.CreateMap<TeamDAO, ITeam>().As<Team>();
                cfg.CreateMap<GameDAO, Game>();

                cfg.CreateMap<Game, GameDAO>()
                .ForMember(d => d.Home, s => s.MapFrom(p => p.Home))
                .ForMember(d => d.Away, s => s.MapFrom(p => p.Away));

                cfg.CreateMap<Game, GameViewModel>()
                .ForMember(d => d.Home, s => s.MapFrom(p => p.Home.Name))
                .ForMember(d => d.HomeId, s => s.MapFrom(p => p.Home.Id))
                .ForMember(d => d.Away, s => s.MapFrom(p => p.Away.Name))
                .ForMember(d => d.AwayId, s => s.MapFrom(p => p.Away.Id))
                .ForMember(d => d.PeriodString, s => s.MapFrom(p => p.Period.ToString()));

                cfg.CreateMap<ITeam, TeamDAO>();
            });
            
            Config.AssertConfigurationIsValid();

            Mapper = Config.CreateMapper();

        }

        public Team TeamViewModelToTeam(TeamViewModel teamViewModel)
        {
            return Mapper.Map<Team>(teamViewModel);
        }

        public TeamViewModel TeamToTeamViewModel(Team team)
        {
            return Mapper.Map<TeamViewModel>(team);
        }

        public Game GameDAOToGame(GameDAO gameDAO)
        {
            return Mapper.Map<Game>(gameDAO);
        }

        public GameViewModel GameToGameViewModel(Game game)
        {
            return Mapper.Map<GameViewModel>(game);
        }


        public GameDAO GameToGameDAO(Game game)
        {
            var gameDAO = Mapper.Map<GameDAO>(game);            

            return gameDAO;
        }

        public TeamDAO TeamToTeamDAO(Team team)
        {
            throw new NotImplementedException();
        }

        public Team TeamDAOToTeam(TeamDAO teamDAO)
        {
            return Mapper.Map<Team>(teamDAO);
        }
    }    
}

