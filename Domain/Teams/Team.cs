﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Teams
{
    public class Team : ITeam
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
    }
}
