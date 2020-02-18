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
        public long HomeId { get; set; }
        public string Home { get; set; }
        public long AwayId { get; set; }
        public string Away { get; set; }
        public bool IsCompelte { get; set; }
        public bool IsStarted { get; set; }
        public string PeriodString { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public GameViewModel() { }

        public GameViewModel(int gameNo, int day, int year, long homeId, string home, int homeScore, long awayId, string away, int awayScore, bool isCompelte, bool isStarted, string periodString)
        {
            GameNo = gameNo;
            Day = day;
            Year = year;
            HomeId = homeId;
            Home = home;
            HomeScore = homeScore;
            AwayId = awayId;
            Away = away;
            AwayScore = awayScore;
            IsCompelte = isCompelte;
            IsStarted = isStarted;
            PeriodString = periodString;
        }
    }
}
