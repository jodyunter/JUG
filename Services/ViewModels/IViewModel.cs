using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public interface IViewModel
    {
        int MessageLevel { get; set; }
        string Message { get; set; }
    }

}
