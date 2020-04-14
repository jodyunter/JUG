using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.ViewModels.Games;
using Services.ViewModels.Teams;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/team")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;

        private ITeamService teamService { get; set; }
        private IGameService gameService { get; set; }

        public GameController(ILogger<TeamController> logger, IGameService gameService, ITeamService teamService)
        {
            this.teamService = teamService;
            this.gameService = gameService;
            _logger = logger;
        }

        [HttpGet]
        [HttpGet("list")]
        public IActionResult List()
        {
            IList<GameViewModel> teams = gameService.GetAll();

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

            return Ok(gameService.GetById(id.Value));
        }

        [HttpPost]
        public ActionResult<IGameViewModel> Post(GameViewModel model)
        {
            IGameViewModel newTeam = model;

            if (model.Id == 0)
            {
                newTeam = gameService.Create(model.HomeId, model.AwayId);
            }
            else
            {
                teamService.Update(model);
            }

            return Ok(newTeam);
        }

        [HttpPost("delete")]
        public IActionResult Delete(GameViewModel model)
        {
            teamService.Delete(model.Id);

            return Ok();
        }

        [HttpPost("dataforcreate/")]
        public ActionResult<ITeamViewModel> GetDataForCreate()
        {
            return Ok(new TeamViewModel() { Message = "Not implemented yet", MessageLevel = 1 });


        }
    }
}