using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Teams
{
    public interface ITeam:IDomainObject
    {
        TeamType TeamType { get; set; }
        string Name { get; set; }
        int Skill { get; set; }
    }

    public enum TeamType
    {
        BaseTeam = 0,
        SeasonTeam = 1
    } 
    
}
