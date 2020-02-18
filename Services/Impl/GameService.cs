using System;
using System.Collections.Generic;
using System.Text;
using Services.ViewModels.Games;
using Services.ViewModels.Teams;

namespace Services.Impl
{
    public class GameService : IGameService
    {
        public IGameViewModel Create(ITeamViewModel home, ITeamViewModel away)
        {
            var game = new GameViewModel(1, 1, 1, home.Id, home.Name, 0, away.Id, away.Name, 0, false, false, "1st");

            return game;
        }

        public IGameViewModel Play(IGameViewModel game, Random random)
        {
            game.HomeScore = 3;
            game.AwayScore = 2;
            game.IsStarted = true;
            game.IsCompelte = true;
            game.PeriodString = "F";

            return game;
        }
    }
}
