using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.ViewModels.Teams;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/team")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;

        private ITeamService teamService { get; set; }

        public TeamController(ILogger<TeamController> logger,ITeamService teamService)
        {
            this.teamService = teamService;
            _logger = logger;
        }
        
        [HttpGet]
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            IList<ITeamViewModel> teams = teamService.GetAll();

            return Ok(teams);
        }

        [HttpGet("{id}")]
        [HttpGet("find/{id}")]
        public async Task<IActionResult> Find(long? id)
        {
            if (id == null)
            {
                return NoContent();
            }

            return Ok(teamService.GetById(id.Value));
        }
        
        [HttpPost]
        public async Task<ActionResult<ITeamViewModel>> PostTeam(TeamViewModel teamModel)
        {
            ITeamViewModel newTeam;

            if (teamModel.Id == -1)
            {
                newTeam = teamService.Create(teamModel.Name, teamModel.Skill);
            }
            else
            {
                teamService.Update(teamModel);
            }
            


            return CreatedAtAction(nameof(newTeam), new { id = newTeam.Id }, newTeam);
        }
    }
}