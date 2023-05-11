using Microsoft.AspNetCore.Mvc;

namespace CardGame.Api.Controllers;

[Route("[controller]")]
public class CardGameController :ControllerBase
{
     [HttpGet]
     public IActionResult ListDinners()
     {
          return Ok(Array.Empty<string>());
     }
}