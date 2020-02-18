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
        public TeamDAO Home { get; set; }
        public int HomeScore { get; set; }
        public TeamDAO Away { get; set; }
        public int AwayScore { get; set; }
        public bool IsStarted { get; set; }
        public bool IsComplete { get; set; }
        public bool CanTie { get; set; }
        public int NormalPeriods { get; set; }
        public int MaxOverTimePeriods { get; set; }
    }
}
