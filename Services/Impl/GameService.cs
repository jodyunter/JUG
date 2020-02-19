using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Data;
using Data.DAO;
using Domain.Games;
using Services.ViewModels.Games;
using Services.ViewModels.Teams;

namespace Services.Impl
{
    public class GameService : BaseService, IGameService
    {        
        public ITeamService TeamService { get; set; }
        public IDataService<GameDAO> gameDS { get; set; }
        public IDataService<TeamDAO> teamDS { get; set; }

        public GameService(MapperConfiguration config, ITeamService teamService, IDataService<GameDAO> data, IDataService<TeamDAO> teamData) : base(config)
        {
            TeamService = teamService;
            gameDS = data;
            teamDS = teamData;
        }
        public IGameViewModel Create(ITeamViewModel home, ITeamViewModel away)
        {
            var gameModel = new GameViewModel(1, 1, 1, home.Id, home.Name, 0, away.Id, away.Name, 0, false, false, "1st");

            var homeTeam = TeamService.GetDomainObjectById(home.Id);
            var awayTeam = TeamService.GetDomainObjectById(away.Id);

            var gameNo = 1; //need a way to get this
            var day = 1; //need a way to get this
            var year = 1; //need a way to get this
            var canTie = true; //need a way to get this
            var maxOverTimePeriods = 1; //need a way to get this
            var minPeriods = 3; //need a way to get this

            var game = new Game(gameNo, day, year, 1, homeTeam, 0, awayTeam, 0, false, false, canTie, minPeriods, maxOverTimePeriods);

            //map the model
            var gameDAO = Map(game);
            gameDS.Create(gameDAO);
            gameModel.Id = gameDAO.Id;

            return gameModel;
        }

        public IGameViewModel Play(IGameViewModel gameModel, Random random)
        {

            var gameDAO = gameDS.GetById(gameModel.Id);

            var game = Mapper.Map<Game>(gameDAO);

            game.Play(new Random());

            MapGameResult(gameDAO, game);

            gameDS.Save(gameDAO);
                       
            var resultModel = Mapper.Map<GameViewModel>(game);

            return resultModel;
        }

        public GameDAO Map(Game game)
        {
            var gameDAO = Mapper.Map<GameDAO>(game);
            gameDAO.Home = teamDS.GetById(game.Home.Id);
            gameDAO.Away = teamDS.GetById(game.Away.Id);

            return gameDAO;
        }

        public void MapGameResult(GameDAO gameDAO, Game game)
        {
            gameDAO.HomeScore = game.HomeScore;
            gameDAO.AwayScore = game.AwayScore;
            gameDAO.IsComplete = game.IsComplete;
            gameDAO.IsStarted = game.IsStarted;
            gameDAO.Period = game.Period;            
        }

    }
}
