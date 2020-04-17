using Data.DAO;
using Domain.Teams;
using Services.ViewModels.Teams;

namespace Services
{
    public interface ITeamService:IBaseService<TeamViewModel, Team, TeamDAO>
    {        
    }
    
}
