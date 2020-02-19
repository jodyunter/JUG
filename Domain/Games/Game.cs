using Domain.Teams;
using System;

namespace Domain.Games
{
    public class Game : IGame
    {
        public long Id { get; set; }
        public int GameNo { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public int Period { get; set; }
        public ITeam Home { get; set; }
        public int HomeScore { get; set; }
        public ITeam Away { get; set; }
        public int AwayScore { get; set; }
        public bool IsStarted { get; set; }
        public bool IsComplete { get; set; }
        public bool CanTie { get; set; }
        public int NormalPeriods { get; set; }
        public int MaxOverTimePeriods { get; set; }
        
        public Game() { }

        public Game(int gameNo, int day, int year, int period, ITeam home, int homeScore, ITeam away, int awayScore, bool isStarted, bool isComplete, bool canTie, int normalPeriods, int maxOverTimePeriods)
        {            
            GameNo = gameNo;
            Day = day;
            Year = year;
            Period = period;
            Home = home;
            HomeScore = homeScore;
            Away = away;
            AwayScore = awayScore;
            IsStarted = isStarted;
            IsComplete = isComplete;
            CanTie = canTie;
            NormalPeriods = normalPeriods;
            MaxOverTimePeriods = maxOverTimePeriods;
        }

        public void Play(Random random)
        {
            IsStarted = true;
            IsComplete = true;
            HomeScore = random.Next(0, 7);
            AwayScore = random.Next(0, 6);
        }
    }
}
