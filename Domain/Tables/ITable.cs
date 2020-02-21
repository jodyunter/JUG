using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tables
{
    public interface ITable
    {       
        string Heading { get; set; }        
        IList<IRanking> Rankings { get; set; }
        void SortStandings(string byGroup);
        void SortStandings();
        int CompareTeams(ITableTeam a, ITableTeam b);
        
    }
}
