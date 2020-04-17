using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Competitions
{
    public interface ICompetitionTeam:ITeam
    {
        ITeam Parent { get; set; }
        ICompetition Competition { get; set; }
    }
}
