using Data.DAO;
using Domain.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface ITeamDataService
    {
        ITeamDAO GetById(long Id, TeamType teamType);
        void Save(ITeamDAO team);        
    }
}
