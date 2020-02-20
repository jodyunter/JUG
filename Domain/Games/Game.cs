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
        public GameType GameType { get; set; }
        
        public Game() { }

        public Game(int gameNo, int day, int year, int period, ITeam home, int homeScore, ITeam away, int awayScore, bool isStarted, bool isComplete, bool canTie, int normalPeriods, int maxOverTimePeriods, GameType gameType)
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
            GameType = gameType;
        }

        public void Play(Random random)
        {
            IsStarted = true;
            IsComplete = true;
            
            HomeScore = 0;
            AwayScore = 0;

            //calculate odds
            int difference = Home.Skill - Away.Skill;

            //we want an average of 4 goals per game per team per 3 periods.
            int[,] odds = new int[,]
            {
               { 0,100 },
                {101, 1100 },
                {1101,  1200},
                {1201, 1300 }
            };

            for (int i = Period; i <= NormalPeriods; i++)
            {
                int homeScore = random.Next(0, 1301);
                int awayScore = random.Next(0, 1301);
                
                for (int j = 0; j < 3; j++)
                {
                    if (homeScore > odds[j,0] && homeScore < odds[j,1])
                    {
                        homeScore = j;
                    }

                    if (awayScore > odds[j, 0] && awayScore < odds[j, 1])
                    {
                        awayScore = j;
                    }
                }

                HomeScore += homeScore;
                AwayScore += awayScore;
            }
           
        }
    }
}
