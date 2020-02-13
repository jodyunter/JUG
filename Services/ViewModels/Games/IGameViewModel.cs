namespace Services.ViewModels.Games
{
    public interface IGameViewModel
    {
        string Away { get; set; }
        int AwayScore { get; set; }
        int Day { get; set; }
        int GameNo { get; set; }
        string Home { get; set; }
        int HomeScore { get; set; }
        bool IsCompelte { get; set; }
        bool IsStarted { get; set; }
        string PeriodString { get; set; }
        int Year { get; set; }
    }
}