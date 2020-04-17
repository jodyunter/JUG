using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public interface ICompetitionTeamDAO:ITeamDAO
    {
        ITeamDAO Parent { get; set; }
        ICompetitionDAO Competition { get; set; }
    }
}
