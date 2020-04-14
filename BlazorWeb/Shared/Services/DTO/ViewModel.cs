using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ViewModels
{
    public class ViewModel
    {
        public long Id { get; set; }       
        public string Message { get; set; }
        public int MessageLevel { get; set; }
    }
}
