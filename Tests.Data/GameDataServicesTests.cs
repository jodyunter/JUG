using Data;
using Data.DAO;
using Data.Impl;
using System;
using System.Linq;
using Xunit;

namespace Tests.Data
{
    public class GameDataServicesTests
    {
        [Fact]
        public void ShouldAddGames()
        {
            using (var db = new JUGContext())
            {

                var teamDataService = new BaseDataService<TeamDAO>();
                var gameDataService = new GameDataService();

                Assert.Empty(teamDataService.GetAll(db));
                Assert.Empty(gameDataService.GetAll(db));

                DbHelper.AddSomeTeams(10, db);

                var game = new GameDAO();
                game.Home = teamDataService.GetAll(db).Where(t => t.Name == "Team 1").FirstOrDefault();
                game.Away = teamDataService.GetAll(db).Where(t => t.Name == "Team 6").FirstOrDefault();
                game.AwayScore = 5;
                game.HomeScore = 6;
                game.IsComplete = true;
                game.IsStarted = true;
                game.CanTie = true;

                gameDataService.Create(game, db);


                Assert.Single(db.Games.Local);

            }
        }


    }
}
