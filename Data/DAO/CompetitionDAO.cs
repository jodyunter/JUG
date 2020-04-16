using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public class CompetitionDAO : ICompetitionDAO
    {
        public long Id { get; set; }
        public int Year { get; set; }
        public int Number { get; set; }
    }
}
