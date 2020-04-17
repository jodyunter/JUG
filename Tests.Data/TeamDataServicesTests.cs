using Data;
using Xunit;
using Data.DAO;
using Data.Impl;

namespace Tests.Data
{
    public class TeamDataServicesTests
    {        

        [Fact]
        public void ShouldAddTeam()
        {
            using (var db = new JUGContext())
            {
                var teamDataService = new BaseDataService<TeamDAO>();

                Assert.Empty(teamDataService.GetAll(db));

                var name = "Team 1";
                var skill = 5;
                var type = TeamType.BaseTeam;

                var teamDAO = new TeamDAO() { Name = name, Skill = skill, TeamType = type };


                teamDataService.Create(teamDAO, db);

                Assert.Single(db.Teams.Local);
                
            }
        }

        [Fact]
        public void ShouldUpdateTeam()
        {
            using (var db = new JUGContext())
            {
                var teamDataService = new BaseDataService<TeamDAO>();

                var name = "Team 1";
                var skill = 5;
                var type = TeamType.BaseTeam;

                var teamDAO = new TeamDAO() { Name = name, Skill = skill, TeamType = type };

                teamDataService.Create(teamDAO, db);
                teamDataService.SaveChanges(db);

                Assert.Single(db.Teams);

                var currenTeam = teamDataService.GetById(teamDAO.Id, db);

                Assert.Equal(name, currenTeam.Name);
                Assert.Equal(skill, currenTeam.Skill);
                Assert.Equal(type, currenTeam.TeamType);

                currenTeam.Name = "Team 2";
                currenTeam.Skill = 12;
                currenTeam.TeamType = TeamType.SeasonTeam;

                teamDataService.Save(currenTeam, db);

                Assert.Single(db.Teams.Local);

                var updatedTeam = teamDataService.GetById(teamDAO.Id, db);

                Assert.Equal("Team 2", updatedTeam.Name);
                Assert.Equal(12, updatedTeam.Skill);
                Assert.Equal(TeamType.SeasonTeam, updatedTeam.TeamType);
                Assert.Equal(currenTeam.Id, updatedTeam.Id);

                teamDataService.SaveChanges(db);
                teamDataService.Delete(updatedTeam, db);
                teamDataService.SaveChanges(db);
            }
            
        }
    }
}
