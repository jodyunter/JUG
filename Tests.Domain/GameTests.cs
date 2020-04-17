using Domain.Games;
using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace Tests.Domain
{
    public class GameTests
    {
        [Fact]
        public void ShouldPlayGameNormalTeam()
        {
            var home = new Team(TeamType.BaseTeam, 1, "Team 1", 5);
            var away = new Team(TeamType.BaseTeam, 2, "Team 2", 5);

            var game = new Game(0, 1, 1, 1, 1, home, new GameTeamStats(0, 0), away, new GameTeamStats(0, 0), false, false, true, 3, 0);

            game.Play(new Random());

            Assert.True(game.IsComplete);
            Assert.True(game.IsStarted);
            
        }
    }
}
