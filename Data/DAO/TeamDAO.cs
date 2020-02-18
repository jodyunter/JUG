using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public class TeamDAO:IDAOObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
        public TeamType TeamType { get; set; }
        
    }
}
