using Data.DAO;
using System.Linq;

namespace Data.Impl
{
    public class GameDataService : BaseDataService<GameDAO>, IGameDataService
    {
        public GameDataService() : base() { }
        public GameDataService(JUGContext db) : base(db) { }
        public int MostRecentGameNumber()
        {
            return db.Games.Max(g => g.GameNo);
        }
    }
}
