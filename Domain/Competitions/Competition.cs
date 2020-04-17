using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Competitions
{
    public class Competition : ICompetition
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Number { get; set; }
        public long Id { get; set; }
    }
}
