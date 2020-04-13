using Data;
using System;
using Xunit;
using System.Linq;
using Data.DAO;
using Domain.Teams;
using Data.Impl;

namespace Tests.Data
{
    public class TeamDataServicesTests
    {
        private JUGContext db = new JUGContext();
        [Fact]
        public void ShouldAddGames()
        {
            var teamDataService = new BaseDataService<TeamDAO>(db);
            var gameDataService = new GameDataService(db);                  
            
            Assert.Empty(teamDataService.GetAll());
            Assert.Empty(gameDataService.GetAll());

            DbHelper.AddSomeTeams(10);            

            var game = new GameDAO();
            game.Home = teamDataService.GetAll().Where(t => t.Name == "Team 1").FirstOrDefault();
            game.Away = teamDataService.GetAll().Where(t => t.Name == "Team 6").FirstOrDefault();
            game.AwayScore = 5;
            game.HomeScore = 6;
            game.IsComplete = true;
            game.IsStarted = true;
            game.CanTie = true;            

            gameDataService.Save(game);

            Assert.Single(gameDataService.GetAll());

            gameDataService.DeleteAll();
        }

        [Fact]
        public void ShouldAddTeam()
        {
            var teamDataService = new BaseDataService<TeamDAO>();            

            Assert.Empty(teamDataService.GetAll());

            var name = "Team 1";
            var skill = 5;
            var type = TeamType.BaseTeam;

            var teamDAO = new TeamDAO() { Name = name, Skill = skill, TeamType = type };
            

            teamDataService.Create(teamDAO);

            Assert.Single(teamDataService.GetAll());

            teamDataService.DeleteAll();
        }

        [Fact]
        public void ShouldUpdateTeam()
        {
            var teamDataService = new BaseDataService<TeamDAO>();
            teamDataService.DeleteAll();

            var name = "Team 1";
            var skill = 5;
            var type = TeamType.BaseTeam;

            var teamDAO = new TeamDAO() { Name = name, Skill = skill, TeamType = type };            

            teamDataService.Create(teamDAO);

            Assert.Single(teamDataService.GetAll());

            var currenTeam = teamDataService.GetById(teamDAO.Id);

            Assert.Equal(name, currenTeam.Name);
            Assert.Equal(skill, currenTeam.Skill);
            Assert.Equal(type, currenTeam.TeamType);

            currenTeam.Name = "Team 2";
            currenTeam.Skill = 12;
            currenTeam.TeamType = TeamType.SeasonTeam;

            teamDataService.Save(currenTeam);

            Assert.Single(teamDataService.GetAll());

            var updatedTeam = teamDataService.GetById(teamDAO.Id);

            Assert.Equal("Team 2", updatedTeam.Name);
            Assert.Equal(12, updatedTeam.Skill);
            Assert.Equal(TeamType.SeasonTeam, updatedTeam.TeamType);
            Assert.Equal(currenTeam.Id, updatedTeam.Id);
            
        }
    }
}
