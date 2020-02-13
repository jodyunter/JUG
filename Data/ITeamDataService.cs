using Data.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface ITeamDataService
    {
        ITeamDAO GetById(long Id);
    }
}
