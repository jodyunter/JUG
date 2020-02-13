using Services.ViewModels;
using Services.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace JUG.ConsoleUI.Views
{
    public class SimpleGameView : BaseView
    {
        public IViewModel Model { get; set; }

        public string GetDisplayString()
        {
            var m = (GameViewModel)Model;

            return m.Home + "\t" + m.HomeScore + " : " + m.AwayScore + "\t" + m.Away;
        }
    }
}
