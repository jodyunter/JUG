using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAO
{
    public class CompetitionTeamDAO:TeamDAO
    {
        public TeamDAO Parent { get; set; }
        public CompetitionDAO Competition { get; set; }
    }
}
