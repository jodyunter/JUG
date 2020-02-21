using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tables
{
    public interface IRanking
    {
        ITableTeam Team { get; set; }
        string Group { get; set; }
        int Rank { get; set; }
    }
}
