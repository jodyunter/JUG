using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Games
{
    public interface IGameTeamStats
    {
        int Score { get; set; }
        int Shots { get; set; }

    }
}
