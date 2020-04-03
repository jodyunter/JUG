using Domain.Teams;
using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ITeamService:IBaseService
    {
        ITeamViewModel GetById(long id);
        ITeamViewModel Create(string name, int skill);
        IList<ITeamViewModel> GetAll();
        ITeam GetDomainObjectById(long id);        
        void Update(ITeamViewModel model);
        void Delete(long? id);
    }
    
}
