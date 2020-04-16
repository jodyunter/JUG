namespace Services.ViewModels.Games
{
    public interface IGameViewModel:IViewModel
    {        
        long AwayId { get; set; }
        string Away { get; set; }
        int AwayScore { get; set; }
        int Day { get; set; }
        int GameNo { get; set; }
        long HomeId { get; set; }
        string Home { get; set; }
        int HomeScore { get; set; }
        bool IsComplete { get; set; }
        bool IsStarted { get; set; }
        string PeriodString { get; set; }
        int Year { get; set; }
    }
}