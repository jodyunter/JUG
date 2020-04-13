using Data.DAO;
using Domain.Games;
using Domain.Teams;
using Services.ViewModels.Games;
using Services.ViewModels.Teams;
using System.Collections.Generic;

namespace Services.Config
{
    public interface IMapperConfig<TViewModel, TDomain, TDAOObject>
    {
        //remove the multiple ones, it is now taken care of in the service
        public Team TeamViewModelToTeam(TeamViewModel teamViewModel);
        public TeamDAO TeamToTeamDAO(Team team);
        public Team TeamDAOToTeam(TeamDAO team);
        public TeamViewModel TeamToTeamViewModel(Team team);
        public IList<Team> TeamDAOToTeam(IList<TeamDAO> teamDAO);
        public IList<TeamViewModel> TeamToTeamViewModel(IList<Team> teams);
        public Game GameDAOToGame(GameDAO gameDAO);
        public IList<Game> GameDAOToGame(IList<GameDAO> gameDAO);
        public GameDAO GameToGameDAO(Game game);
        public GameViewModel GameToGameViewModel(Game game);
        public IList<GameViewModel> GameToGameViewModel(IList<Game> games);

        public 
    }
}
