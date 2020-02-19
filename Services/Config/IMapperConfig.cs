using Data.DAO;
using Domain.Games;
using Domain.Teams;
using Services.ViewModels.Games;
using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Config
{
    public interface IMapperConfig
    {
        public Team TeamToTeamViewModel(TeamViewModel teamViewModel);
        public TeamViewModel TeamViewModelToTeam(Team team);

        public Game GameDAOToGame(GameDAO gameDAO);

        //this one should probably be part of the create method
        public GameDAO GameToGameDAO(Game game, TeamDAO home, TeamDAO away);
        public GameViewModel GameToGameViewModel(Game game);
        public void MapGameResults(GameDAO gameDAO, Game game);

    }
}
