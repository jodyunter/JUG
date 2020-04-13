using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class BaseViewModel : IViewModel
    {
        public long Id { get; set; }
        public int MessageLevel { get; set; }
        public string Message { get; set; }
    }
}
