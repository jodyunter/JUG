using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public interface ITeamDAO
    {
        TeamType Type { get; }
        long Id { get; set; }
        string Name { get; set; }
        int Skill { get; set; }
    }

    public enum TeamType
    {
        BaseTeam,
        SeasonTeam
    }

}
