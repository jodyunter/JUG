using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class AppState
    {
        public Object EditModel { get; set; } = new TeamViewModel() { Id = 0, Name = "Edit Me", Skill = 15, TeamType = TeamType.BaseTeam };
    }
}
