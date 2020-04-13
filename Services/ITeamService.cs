using Data.DAO;
using Domain.Teams;
using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ITeamService:IBaseService<TeamViewModel, TTeam, TTeamDAO>
    {        
    }
    
}
