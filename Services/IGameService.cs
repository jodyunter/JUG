using Services.ViewModels.Games;
using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IGameService:IBaseService
    {
        IGameViewModel Create(ITeamViewModel home, ITeamViewModel away);
        IGameViewModel Play(IGameViewModel game, Random random);
        IGameViewModel Update(IGameViewModel game);
        IList<IGameViewModel> GetAll();
        IGameViewModel GetById(long id);
        void Delete(long id);
        void CreateRoundOfGames();

    }
}
