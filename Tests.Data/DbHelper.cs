using Data;
using Data.DAO;
using Data.Impl;
using Domain.Teams;
using System.Linq;

namespace Tests.Data
{
    public class DbHelper
    {
        public static void DeleteData(JUGContext db)
        {
            db.DeleteData();
        }

        public static void AddSomeTeams(int numberToAdd, JUGContext db)
        {
            var teamDataService = new BaseDataService<TeamDAO>();

            for (int i = 0; i < numberToAdd; i++)
            {
                long id = 1;
                if (teamDataService.GetAll(db).Count > 0)
                {
                    id = teamDataService.GetAll(db).Max(t => t.Id) + 1;
                }

                var name = "Team " + id;
                var skill = 5;
                var type = TeamType.BaseTeam;

                var teamDAO = new TeamDAO() { Name = name, Skill = skill, TeamType = type };
                teamDataService.Save(teamDAO, db);

            }

        }
    }
}
