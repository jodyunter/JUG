using Data.DAO;
using Domain.Games;
using Domain.Teams;
using Services.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Config
{
    public class GameMapper:BaseObjectMapper<GameViewModel, Game, GameDAO>
    {
        //eventually we want specialty team mappers to figure this out for each type of team
        TeamMapper teamMapper;

        public GameMapper()
        {
            teamMapper = new TeamMapper();
        }
        public override Game DAOToDomain(GameDAO gameDAO)
        {
            var game = new Game(
                gameDAO.Id,
                gameDAO.GameNo,
                gameDAO.Day,
                gameDAO.Year,
                gameDAO.Period,
                teamMapper.DAOToDomain((TeamDAO)gameDAO.Home),
                new GameTeamStats(gameDAO.HomeScore, gameDAO.HomeShots),
                teamMapper.DAOToDomain((TeamDAO)gameDAO.Away),
                new GameTeamStats(gameDAO.AwayScore, gameDAO.AwayShots),
                gameDAO.IsStarted,
                gameDAO.IsComplete,
                gameDAO.CanTie,
                gameDAO.NormalPeriods,
                gameDAO.MaxOverTimePeriods);                

            return game;
        }

        public override GameViewModel DomainToViewModel(Game game)
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

        public override GameDAO DomainToDAO(Game game)
        {
            var gameDAO = new GameDAO(
                game.Id,
                game.GameNo,
                game.Day,
                game.Year,
                game.Period,
                teamMapper.DomainToDAO((Team)game.Home),
                game.HomeStats.Score,
                game.HomeStats.Shots,
                teamMapper.DomainToDAO((Team)game.Away),
                game.AwayStats.Score,
                game.AwayStats.Shots,
                game.IsStarted,
                game.IsComplete,
                game.CanTie,
                game.NormalPeriods,
                game.MaxOverTimePeriods);

            return gameDAO;
        }
    }
}
