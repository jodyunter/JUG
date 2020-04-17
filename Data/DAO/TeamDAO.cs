using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public class TeamDAO:DAOObject
    {        
        public string Name { get; set; }
        public int Skill { get; set; }
        public TeamType TeamType { get; set; }
    }

    public enum TeamType
    {
        BaseTeam = 0,
        SeasonTeam = 1
    }
}
