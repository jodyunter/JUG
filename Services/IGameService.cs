using Data.DAO;
using Domain.Games;
using Services.ViewModels.Games;
using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IGameService:IBaseService<GameViewModel, Game, GameDAO>
    {
        IGameViewModel Create(ITeamViewModel home, ITeamViewModel away);
        IGameViewModel Play(IGameViewModel game, Random random);                
        void CreateRoundOfGames();

    }
}
