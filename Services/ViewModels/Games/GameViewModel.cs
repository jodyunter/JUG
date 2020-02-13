using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels.Games
{
    public class GameViewModel : IViewModel, IGameViewModel
    {
        public int GameNo { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public bool IsCompelte { get; set; }
        public bool IsStarted { get; set; }
        public string PeriodString { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
