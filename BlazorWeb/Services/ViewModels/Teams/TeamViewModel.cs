using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.ViewModels.Teams
{
    public class TeamViewModel
    {                
        public TeamType TeamType { get; set; }
        public long Id { get; set; }
        [StringLength(12,ErrorMessage = "Cannot be longer than 12 characters")]
        public string Name { get; set; }
        public int Skill { get; set; }
    }

    public enum TeamType
    {        
        BaseTeam = 0,        
        SeasonTeam = 1
    }

}
