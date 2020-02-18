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
        [Fact]
        public void ShouldAddTeam()
        {
            var db = new JUGContext();

            DbHelper.DeleteData(db);

            Assert.Empty(db.Teams);

            var name = "Team 1";
            var skill = 5;
            var type = TeamType.BaseTeam;

            var teamDAO = new TeamDAO() { Name = name, Skill = skill, TeamType = type };

            var teamDataService = new BaseDataService<TeamDAO>(db);

            teamDataService.Create(teamDAO);

            Assert.Single(db.Teams.ToList());

        }

        [Fact]
        public void ShouldUpdateTeam()
        {
            var db = new JUGContext();

            DbHelper.DeleteData(db);

            Assert.Empty(db.Teams);

            var name = "Team 1";
            var skill = 5;
            var type = TeamType.BaseTeam;

            var teamDAO = new TeamDAO() { Name = name, Skill = skill, TeamType = type };

            var teamDataService = new BaseDataService<TeamDAO>(db);

            teamDataService.Create(teamDAO);

            Assert.Single(db.Teams.ToList());

            var currenTeam = teamDataService.GetById(teamDAO.Id);

            Assert.Equal(name, currenTeam.Name);
            Assert.Equal(skill, currenTeam.Skill);
            Assert.Equal(type, currenTeam.TeamType);

            currenTeam.Name = "Team 2";
            currenTeam.Skill = 12;
            currenTeam.TeamType = TeamType.SeasonTeam;

            teamDataService.Save(currenTeam);

            Assert.Single(db.Teams.ToList());

            var updatedTeam = teamDataService.GetById(teamDAO.Id);

            Assert.Equal("Team 2", updatedTeam.Name);
            Assert.Equal(12, updatedTeam.Skill);
            Assert.Equal(TeamType.SeasonTeam, updatedTeam.TeamType);
            Assert.Equal(currenTeam.Id, updatedTeam.Id);

        }
    }
}
