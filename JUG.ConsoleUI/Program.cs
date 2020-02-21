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

            for (int i = 1; i <= 20; i++)
            {
                app.TeamService.Create("Team " + i, 5);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
