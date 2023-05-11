using CardGame.API.Controllers.Responses;
using CardGame.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameManager _gameManager;

        public GameController(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        [HttpPost("reset-shuffle")]
        public IActionResult ResetAndShuffleDeck()
        {
            _gameManager.ResetGame();
            _gameManager.ShuffleDeck();
            return Ok(new SuccessMessage("Deck reset and shuffled successfully."));
        }
        
        [HttpPost("play-round")]
        public IActionResult PlayOneRound()
        {
            return Ok();
        }

        [HttpGet("all-scores")]
        public IActionResult GetCurrentScores()
        {
            return Ok();
        }

        [HttpGet("all-rounds-winner")]
        public IActionResult GetAllRoundsWinner()
        {
            return Ok();
        }
    }
}