using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public interface ITeamDAO:IDAOObject
    {
        long Id { get; set; }
        string Name { get; set; }
        int Skill { get; set; }
        TeamType TeamType { get; set; }
    }
}
