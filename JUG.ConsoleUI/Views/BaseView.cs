using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JUG.ConsoleUI.Views
{
    public interface BaseView
    {
        IViewModel Model {get; set;}
        string GetDisplayString();
    }
}
