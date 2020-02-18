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
        public int HomeScore { get; set; }
        public ITeam Away { get; set; }
        public int AwayScore { get; set; }
        bool IsStarted { get; set; }
        bool IsComplete { get; set; }


    }
}
