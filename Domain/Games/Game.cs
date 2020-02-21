using Domain.Teams;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int HomeScore { get { return HomeStats.Score; } }
        public ITeam Away { get; set; }
        public int AwayScore { get { return AwayStats.Score; } }
        public bool IsStarted { get; set; }
        public bool IsComplete { get; set; }
        public bool CanTie { get; set; }
        public int NormalPeriods { get; set; }
        public int MaxOverTimePeriods { get; set; }
        public GameType GameType { get; set; }        
        [NotMapped] public IGameTeamStats HomeStats { get; set; }
        [NotMapped] public IGameTeamStats AwayStats { get; set; }
        
        public Game() { }

        public Game(long? id, int gameNo, int day, int year, int period, ITeam home, IGameTeamStats homeStats, ITeam away, IGameTeamStats awayStats, bool isStarted, bool isComplete, bool canTie, int normalPeriods, int maxOverTimePeriods, GameType gameType)
        {
            if (id != null) Id = id.Value;

            GameNo = gameNo;
            Day = day;
            Year = year;
            Period = period;
            Home = home;            
            Away = away;            
            IsStarted = isStarted;
            IsComplete = isComplete;
            CanTie = canTie;
            NormalPeriods = normalPeriods;
            MaxOverTimePeriods = maxOverTimePeriods;
            GameType = gameType;
            HomeStats = homeStats;
            AwayStats = awayStats;
        }

        public void Play(Random random)
        {
            IsStarted = true;
            IsComplete = true;

            HomeStats.Score = 0;
            AwayStats.Score = 0;

            for (int i = 0; i < NormalPeriods; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    ProcessTickForTeam(Home, Away, HomeStats, AwayStats, random);
                    ProcessTickForTeam(Away, Home, AwayStats, HomeStats, random);                                       
                }
            }           
        }

        public void ProcessTickForTeam(ITeam attacker, ITeam defender, IGameTeamStats attackerStats, IGameTeamStats defenderStats, Random random)
        {
            if (ShotOnNet(attacker, defender, random))
            {
                attackerStats.Shots++;
                if (GoalScored(attacker, defender, random))
                {
                    attackerStats.Score++;
                }
            }
        }
        public bool GoalScored(ITeam attacker, ITeam defender, Random random)
        {
            return random.Next(0, 10) == 0;
        }
        public bool ShotOnNet(ITeam attacker, ITeam defender, Random random)
        {
            return random.Next(0, 6) == 0;
        }
    }
}
