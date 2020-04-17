using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Competitions
{
    public interface ICompetition:IDomainObject
    {
        string Name { get; set; }
        int Year { get; set; }
        int Number { get; set; }
    }
}
