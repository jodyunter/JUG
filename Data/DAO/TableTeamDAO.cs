using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public class TableTeamDAO : ITeamDAO
    {
        public long Id { get; set; }
        public ICompetitionDAO Competition { get; set; }
        public ITeamDAO ParentTeam { get; set; }
        //we use both because we want a link AND a record of what it was for the season
        public string Name { get; set; }
        public int Skill { get; set; }
        public int RegulationWins { get; set; }
        public int OverTimeWins { get; set; }
        public int RegulationLoses { get; set; }
        public int OverTimeLoses { get; set; }
        public int Ties { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int ShotsFor { get; set; }
        public int ShotsAgainst { get; set; }
        public TeamType TeamType { get; set; }
    }
}
