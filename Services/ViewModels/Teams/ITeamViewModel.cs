using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Services.ViewModels.Teams
{
    public interface ITeamViewModel
    {                
        public TeamType TeamType { get; set; }
        long Id { get; set; }
        string Name { get; set; }
        int Skill { get; set; }
    }

    public enum TeamType
    {        
        BaseTeam = 0,        
        SeasonTeam = 1
    }

}
