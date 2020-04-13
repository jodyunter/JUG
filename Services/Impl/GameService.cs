using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.DAO;
using Domain.Games;
using Services.ViewModels.Games;
using Services.ViewModels.Teams;
using Services.Config;

namespace Services.Impl
{
    public class GameService : BaseService<GameDAO>, IGameService
    {        
        public ITeamService TeamService { get; set; }
        public IGameDataService GameDataService { get; set; }
        public IDataService<TeamDAO> TeamDataService { get; set; }

        public GameService(IMapperConfig config, ITeamService teamService, IGameDataService data, IDataService<TeamDAO> teamData) : base(config)
        {
            TeamService = teamService;
            GameDataService = data;
            TeamDataService = teamData;
        }
        public IGameViewModel Create(ITeamViewModel home, ITeamViewModel away)
        {
            var gameModel = new GameViewModel(1, 1, 1, home.Id, home.Name, 0, away.Id, away.Name, 0, false, false, "1st");

            var homeTeam = TeamService.GetDomainObjectById(home.Id);
            var awayTeam = TeamService.GetDomainObjectById(away.Id);

            var mostRecentGameNumber = GameDataService.MostRecentGameNumber();

            var gameNo = mostRecentGameNumber+1; //need a way to get this
            var day = 1; //need a way to get this
            var year = 1; //need a way to get this
            var canTie = true; //need a way to get this
            var maxOverTimePeriods = 1; //need a way to get this
            var minPeriods = 3; //need a way to get this

            var game = new Game(null, gameNo, day, year, 1, homeTeam, new GameTeamStats(0,0), awayTeam, new GameTeamStats(0,0), false, false, canTie, minPeriods, maxOverTimePeriods, GameType.Exhibition);

            //map the model
            var gameDAO = Mapper.GameToGameDAO(game);

            //when creating we need to make sure we populate the child objects with registered data objects
            gameDAO.Home = TeamDataService.GetById(home.Id);
            gameDAO.Away = TeamDataService.GetById(away.Id);

            GameDataService.Create(gameDAO);
            gameModel.Id = gameDAO.Id;

            return gameModel;
        }

        public IGameViewModel Play(IGameViewModel gameModel, Random random)
        {

            var gameDAO = GameDataService.GetById(gameModel.Id);

            var game = Mapper.GameDAOToGame(gameDAO);

            game.Play(new Random());

            MapGameResults(gameDAO, game);

            GameDataService.Save(gameDAO);

            var resultModel = Mapper.GameToGameViewModel(game);

            return resultModel;
        }

        public IGameViewModel Update(IGameViewModel gameModel)
        {
            var gameDAO = GameDataService.GetById(gameModel.Id);

            if (gameDAO.Home.Id != gameModel.HomeId)
            {
                var newHomeTeam = TeamDataService.GetById(gameModel.HomeId);
                //check if null
                gameDAO.Home = newHomeTeam;
            }

            if (gameDAO.Away.Id != gameModel.AwayId)
            {
                var newAwayTeam = TeamDataService.GetById(gameModel.AwayId);
                //check if null
                gameDAO.Away = newAwayTeam;
            }          

            return null;
            
        }

        private void MapGameResults(GameDAO gameDAO, Game game)
        {
            gameDAO.HomeScore = game.HomeScore;
            gameDAO.AwayScore = game.AwayScore;
            gameDAO.IsComplete = game.IsComplete;
            gameDAO.IsStarted = game.IsStarted;
            gameDAO.Period = game.Period;
            gameDAO.HomeShots = game.HomeStats.Shots;
            gameDAO.AwayShots = game.AwayStats.Shots;
        }

        public IList<IGameViewModel> GetAll()
        {
            var gameDAOs = GameDataService.GetAll();

            var games = Mapper.GameDAOToGame(gameDAOs);

            var models = Mapper.GameToGameViewModel(games);

            return models.ToList<IGameViewModel>();
        }

        public void CreateRoundOfGames()
        {
            throw new NotImplementedException();
        }

        public IGameViewModel GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
