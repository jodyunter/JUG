﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels.Teams
{
    public class TeamViewModel : BaseViewModel, ITeamViewModel
    {
        public long Id { get; set; } = -1;
        public string Name { get; set; }
        public int Skill { get; set; }
        public TeamType TeamType { get; set; }

        public TeamViewModel() { }

        public TeamViewModel(long id, string name, int skill, TeamType teamType)
        {
            Id = id;
            Name = name;
            Skill = skill;
            TeamType = teamType;
        }
    }
}
