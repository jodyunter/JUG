using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels.Teams
{
    public class TeamViewModel : ITeamViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
        public TeamType TeamType { get; set; }
    }
}
