using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Games
{
    
    public interface IGame:IDomainObject
    {
        int GameNo { get; set; }
        int Day { get; set; }
        int Year { get; set; }
        int Period { get; set; }                
        public ITeam Home { get; set; }        
        public IGameTeamStats HomeStats { get; set; }
        public ITeam Away { get; set; }
        public IGameTeamStats AwayStats { get; set; }
        bool IsStarted { get; set; }
        bool IsComplete { get; set; }        


    }

    public enum GameType
    {
        Exhibition = 0,
        Season = 1,
        Playoff = 2
    }
}
