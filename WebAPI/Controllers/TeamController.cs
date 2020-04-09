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
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;

        private IGameService gameService { get; set; }

        public GameController(ILogger<GameController> logger,IGameService gameService)
        {
            this.gameService = gameService;
            _logger = logger;
        }
        
        [HttpGet]
        [HttpGet("list")]
        public IActionResult List()
        {
            IList<IGameViewModel> teams = gameService.GetAll();

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
        public ActionResult<IGameViewModel> PostTeam(GameViewModel gameModel)
        {
            IGameViewModel newGameModel = gameModel;

            if (gameModel.Id == 0)
            {
               // newTeam = .Create(teamModel.Name, teamModel.Skill);
            }
            else
            {
                gameService.Update(gameModel);
            }

            return Ok(newGameModel);            
        }

        [HttpPost("delete/")]
        public IActionResult DeleteTeam(GameViewModel gameModel)
        {
            gameService.Delete(gameModel.Id);

            return Ok();
        }
    }
}