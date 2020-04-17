using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tables
{
    public interface ITableTeam:ITeam
    {        
        ITeam Parent { get; set; }
        int Wins { get; set; }
        int RegulationWins { get; set; }
        int OverTimeWins { get; set; }        
        int Loses { get; set; }
        int RegulationLoses { get; set; }
        int OverTimeLoses { get; set; }
        int Ties { get; set; }
        int Points { get; set; }
        int GamesPlayed { get; set; }
        int GoalsFor { get; set; }
        int GoalsAgainst { get; set; }
        int GoalDifference { get; set; }
        int ShotsFor { get; set; }
        int ShotsAgainst { get; set; }
    }
}
