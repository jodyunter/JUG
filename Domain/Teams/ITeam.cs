using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Teams
{
    public interface ITeam:IDomainObject
    {        
        string Name { get; set; }
        int Skill { get; set; }
    }
    
}
