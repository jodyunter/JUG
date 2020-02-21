using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Games
{
    public class GameTeamStats : IGameTeamStats
    {
        public int Score { get; set; }
        public int Shots { get; set; }

        public GameTeamStats(int score, int shots)
        {
            Score = score;
            Shots = shots;
        }
    }
}
