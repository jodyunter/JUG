using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JUG.ConsoleUI.App
{
    public class AppCode
    {
        public IGameService GameService { get; set; }
        public ITeamService TeamService { get; set; }

        public AppCode()
        {
            SetupServices();
        }

        public void SetupServices()
        {

        }
    }
}
