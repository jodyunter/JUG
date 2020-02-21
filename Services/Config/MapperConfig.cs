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

        public TeamDAO TeamToTeamDAO(Team team)
        {
            return Mapper.Map<TeamDAO>(team);
        }

        public Team TeamDAOToTeam(TeamDAO teamDAO)
        {
            return Mapper.Map<Team>(teamDAO);
        }

        public Game GameDAOToGame(GameDAO gameDAO)
        {
            var game = new Game(
                gameDAO.Id,
                gameDAO.GameNo,
                gameDAO.Day,
                gameDAO.Year,
                gameDAO.Period,
                TeamDAOToTeam(gameDAO.Home),
                new GameTeamStats(gameDAO.HomeScore, gameDAO.HomeShots),
                TeamDAOToTeam(gameDAO.Away),
                new GameTeamStats(gameDAO.AwayScore, gameDAO.AwayShots),
                gameDAO.IsStarted,
                gameDAO.IsComplete,
                gameDAO.CanTie,
                gameDAO.NormalPeriods,
                gameDAO.MaxOverTimePeriods,
                gameDAO.GameType);

            return game;
        }

        public GameViewModel GameToGameViewModel(Game game)
        {
            var gameViewModel = new GameViewModel(
                game.GameNo,
                game.Day,
                game.Year,
                game.Home.Id,
                game.Home.Name,
                game.HomeStats.Score,
                game.Away.Id,
                game.Away.Name,
                game.AwayStats.Score,
                game.IsComplete,
                game.IsStarted,
                game.Period.ToString());

            return gameViewModel;
                
        }


        public GameDAO GameToGameDAO(Game game)
        {
            var gameDAO = new GameDAO(
                game.Id,
                game.GameNo,
                game.Day,
                game.Year,
                game.Period,
                TeamToTeamDAO((Team)game.Home),
                game.HomeStats.Score,
                game.HomeStats.Shots,
                TeamToTeamDAO((Team)game.Away),
                game.AwayStats.Score,
                game.AwayStats.Shots,
                game.IsStarted,
                game.IsComplete,
                game.CanTie,
                game.NormalPeriods,
                game.MaxOverTimePeriods,
                game.GameType);                                             

            return gameDAO;
        }

    }    
}

