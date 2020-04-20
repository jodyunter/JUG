using Domain.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Competitions.Seasons
{
    public class SeasonRanking : IRanking
    {
        public ITableTeam Team { get; set; }
        public string Group { get; set; }
        public int Rank { get; set; }
    }
}
