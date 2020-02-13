using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public interface ITeamDAO
    {
        TeamType TeamType { get; set; }
        long Id { get; set; }
        string Name { get; set; }
        int Skill { get; set; }
    }


}
