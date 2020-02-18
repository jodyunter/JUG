using Data.DAO;
using Domain.Teams;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Impl
{
    public class TeamDataService : ITeamDataService
    {
        private JUGContext db;
        private DbSet<TeamDAO> teamData;

        public TeamDataService(JUGContext context)
        {
            teamData = context.Teams;
            db = context;
        }
        public ITeamDAO GetById(long Id, TeamType teamType)
        {
            //will use different DbSets based on type in the future
            return teamData.Find(Id);
        }

        public void Save(ITeamDAO o)
        {
            //determine the object and save it
            var team = (TeamDAO)o;

            db.Update(team);

            db.SaveChanges();

        }
    }
}
