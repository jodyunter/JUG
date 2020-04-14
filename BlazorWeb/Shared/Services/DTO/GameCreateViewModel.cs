using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Services.ViewModels
{
    public class GameCreateViewModel:ViewModel
    {
        public IList<TeamViewModel> TeamList { get; set; }

        public TeamViewModel HomeTeam { get; set; } = new TeamViewModel();
        public TeamViewModel AwayTeam { get; set; } = new TeamViewModel();

        public GameViewModel SelectedGame { get; set; }

        public IList<TeamViewModel> GetHomeList()
        {
            return TeamList.Where(x => x.Name != AwayTeam.Name).ToList();
        }

        public IList<TeamViewModel> GetAwayList()
        {
            return TeamList.Where(x => x.Name != HomeTeam.Name).ToList();
        }
    }
}
