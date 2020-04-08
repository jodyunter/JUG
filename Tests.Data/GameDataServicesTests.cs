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
            var db = new JUGContext();

            DbHelper.DeleteData(db);

            Assert.Empty(db.Teams);

            DbHelper.AddSomeTeams(10);

            var game = new GameDAO();
            game.Home = db.Teams.Where(t => t.Name == "Team 1").FirstOrDefault();
            game.Away = db.Teams.Where(t => t.Name == "Team 6").FirstOrDefault();
            game.AwayScore = 5;
            game.HomeScore = 6;
            game.IsComplete = true;
            game.IsStarted = true;
            game.CanTie = true;

            var service = new GameDataService();

            service.Save(game);

            Assert.Single(db.Games);

        }
    }
}
