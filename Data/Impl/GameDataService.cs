using Data.DAO;
using System.Linq;

namespace Data.Impl
{
    public class GameDataService : BaseDataService<GameDAO>, IGameDataService
    {
        public GameDataService() : base() { }        
        public int MostRecentGameNumber()
        {
            using (var db = new JUGContext())
            {
                return db.Games.Max(g => g.GameNo);
            }
        }
    }
}
