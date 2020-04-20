using Domain.Games;
using Domain.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Competitions
{
    public abstract class Competition : ICompetition
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Number { get; set; }
        public long Id { get; set; }
        public IList<ICompetitionTeam> Teams { get; set; }
        public IList<IRanking> Rankings { get; set; }

        public void PlayGame(IGame game, Random rand)
        {
            //is this a game for this competition
            game.Play(rand);
        }

        public abstract void ProcessGame(IGame game);

        public abstract void SetRankings();
    }
}
