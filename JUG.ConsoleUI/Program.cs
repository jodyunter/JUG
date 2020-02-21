using JUG.ConsoleUI.App;
using JUG.ConsoleUI.Views;
using System;

namespace JUG.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new AppCode();

            var gameService = app.GameService;
            var teamService = app.TeamService;

            var homeTeam = teamService.Create("Team 1", 5);
            var awayTeam = teamService.Create("Team 2", 5);

            for (int i = 0; i < 100; i++)
            {
                var game = gameService.Create(homeTeam, awayTeam);

                game = gameService.Play(game, new Random());

                var view = new SimpleGameView() { Model = game };
                Console.WriteLine(view.GetDisplayString());
            }

            Console.WriteLine("Hello World!");
        }
    }
}
