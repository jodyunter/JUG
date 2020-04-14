using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.ViewModels.Games
{
    public class GameCreateViewModel : BaseViewModel
    {
        public IList<TeamViewModel> TeamList { get; set; }

        public TeamViewModel HomeTeam { get; set; } = new TeamViewModel();
        public TeamViewModel AwayTeam { get; set; } = new TeamViewModel();

        public GameViewModel SelectedGame { get; set; }

    }
}
