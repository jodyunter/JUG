using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tables
{
    public class Ranking : IRanking
    {
        public ITableTeam Team { get; set;}
        public string Group { get; set;}
        public int Rank { get; set;}
    }
}
