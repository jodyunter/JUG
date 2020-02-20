using Data.DAO;
using Domain.Games;
using Domain.Teams;
using Services.ViewModels.Games;
using Services.ViewModels.Teams;

namespace Services.Config
{
    public interface IMapperConfig
    {
        public Team TeamViewModelToTeam(TeamViewModel teamViewModel);
        public TeamDAO TeamToTeamDAO(Team team);
        public Team TeamDAOToTeam(TeamDAO team);
        public TeamViewModel TeamToTeamViewModel(Team team);
        public Game GameDAOToGame(GameDAO gameDAO);
        public GameDAO GameToGameDAO(Game game);
        public GameViewModel GameToGameViewModel(Game game);      
    }
}
