using Domain.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public class GameDAO:IDAOObject
    {
        public long Id { get; set; }
        public int GameNo { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public int Period { get; set; }        
        public ITeamDAO Home { get; set; }
        public int HomeScore { get; set; }
        public int HomeShots { get; set; }        
        public ITeamDAO Away { get; set; }
        public int AwayScore { get; set; }
        public int AwayShots { get; set; }
        public bool IsStarted { get; set; }
        public bool IsComplete { get; set; }
        public bool CanTie { get; set; }
        public int NormalPeriods { get; set; }
        public int MaxOverTimePeriods { get; set; }
        public GameType GameType { get; set; }
        public ICompetitionDAO Competition { get; set; }

        public GameDAO() { }
        public GameDAO(long id, int gameNo, int day, int year, int period, TeamDAO home, int homeScore, int homeShots, TeamDAO away, int awayScore, int awayShots, bool isStarted, bool isComplete, bool canTie, int normalPeriods, int maxOverTimePeriods, GameType gameType)
        {
            Id = id;
            GameNo = gameNo;
            Day = day;
            Year = year;
            Period = period;
            Home = home;
            HomeScore = homeScore;
            HomeShots = homeShots;
            Away = away;
            AwayScore = awayScore;
            AwayShots = awayShots;
            IsStarted = isStarted;
            IsComplete = isComplete;
            CanTie = canTie;
            NormalPeriods = normalPeriods;
            MaxOverTimePeriods = maxOverTimePeriods;
            GameType = gameType;
        }
    }
}
