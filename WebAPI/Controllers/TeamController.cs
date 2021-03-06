﻿using System;
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

        public TeamController(ILogger<TeamController> logger, ITeamService teamService)
        {
            this.teamService = teamService;
            _logger = logger;
        }

        [HttpGet]
        [HttpGet("list")]
        public IActionResult List()
        {
            IList<TeamViewModel> teams = teamService.GetAll();

            return Ok(teams);
        }

        [HttpGet("{id}")]
        [HttpGet("find/{id}")]
        public IActionResult Find(long? id)
        {
            if (id == null)
            {
                return NoContent();
            }

            return Ok(teamService.GetById(id.Value));
        }

        [HttpPost]
        public ActionResult<ITeamViewModel> Post(TeamViewModel teamModel)
        {
            ITeamViewModel newTeam = teamModel;

            if (teamModel.Id == 0)
            {
                newTeam = teamService.Create(teamModel);
            }
            else
            {
                teamService.Update(teamModel);
            }

            return Ok(newTeam);
        }

        [HttpPost("delete")]
        public IActionResult Delete(TeamViewModel teamModel)
        {
            teamService.Delete(teamModel.Id);

            return Ok();
        }

        [HttpPost("dataforcreate/")]
        public ActionResult<ITeamViewModel> GetDataForCreate()
        {
            return Ok(new TeamViewModel() { Message = "Not implemented yet", MessageLevel = 1 });


        }
    }
}