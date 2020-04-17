using Domain.Tables;
using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Competitions.Seasons
{
    public class SeasonTeam : ICompetitionTeam, ITableTeam
    {
        public ITeam Parent { get; set; }
        public ICompetition Competition { get; set; }
        public TeamType TeamType { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
        public long Id { get; set; }
        public int RegulationWins { get; set; }
        public int OverTimeWins { get; set; }
        public int RegulationLoses { get; set; }
        public int OverTimeLoses { get; set; }
        public int Ties { get; set; }
        public int Points { get; set; }
        public int GamesPlayed { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int ShotsFor { get; set; }
        public int ShotsAgainst { get; set; }
        public int Wins { get { return RegulationWins + OverTimeWins; } set => throw new NotImplementedException(); }
        public int Loses { get { return RegulationLoses + OverTimeLoses; set => throw new NotImplementedException(); }
    }
}
