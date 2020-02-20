using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tables
{
    public interface ITableTeam
    {
        List<TeamStat> Stats { get; set; }
    }
}
