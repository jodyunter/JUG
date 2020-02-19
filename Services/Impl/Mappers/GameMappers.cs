using Data.DAO;
using Domain.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Impl.Mappers
{
    public static class GameMappers
    {
        public static GameDAO MapGameToDAOWithTeam(this GameService gameService, Game game)
        {
            var gameDAO = gameService.Mapper.Map<GameDAO>(game);
            gameDAO.Home = gameService.TeamDataService.GetById(game.Home.Id);
            gameDAO.Away = gameService.TeamDataService.GetById(game.Away.Id);

            return gameDAO;
        }

        public static void MapGameResult(this GameService gameService, GameDAO gameDAO, Game game)
        {
            gameDAO.HomeScore = game.HomeScore;
            gameDAO.AwayScore = game.AwayScore;
            gameDAO.IsComplete = game.IsComplete;
            gameDAO.IsStarted = game.IsStarted;
            gameDAO.Period = game.Period;
        }
    }
}
