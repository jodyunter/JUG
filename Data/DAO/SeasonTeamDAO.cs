
namespace Data.DAO
{
    public class SeasonTeamDAO : CompetitionTeamDAO
    {
        //we use both because we want a link AND a record of what it was for the season
        public int RegulationWins { get; set; }
        public int OverTimeWins { get; set; }
        public int RegulationLoses { get; set; }
        public int OverTimeLoses { get; set; }
        public int Ties { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int ShotsFor { get; set; }
        public int ShotsAgainst { get; set; }        
    }
}
