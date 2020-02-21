using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Teams
{
    public class Team : ITeam
    {
        public TeamType TeamType { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }

        public Team() { }

        public Team(TeamType teamType, long id, string name, int skill)
        {
            TeamType = teamType;
            Id = id;
            Name = name;
            Skill = skill;
        }
    }
}
