using Data.DAO;
using Domain.Teams;
using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Config
{
    public class TeamMapper : BaseObjectMapper<TeamViewModel, Team, TeamDAO>
    {
    }
}
