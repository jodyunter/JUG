using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public interface ICompetitionDAO:IDAOObject
    {
        int Year { get; set; }
        int Number { get; set; }
    }
}
