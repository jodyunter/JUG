using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels.Teams
{
    public interface ITeamViewModel
    {        
        long Id { get; set; }
        string Name { get; set; }
        int Skill { get; set; }
    }

}
