using Data.DAO;
using System.Linq;

namespace Data.Impl
{
    public class GameDataService : BaseDataService<GameDAO>, IGameDataService
    {
        public int MostRecentGameNumber()
        {
            return db.Games.Max(g => g.GameNo);
        }
    }
}
