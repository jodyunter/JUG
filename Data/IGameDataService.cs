using Data.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IGameDataService:IDataService<GameDAO>
    {
        int MostRecentGameNumber();
    }
}
