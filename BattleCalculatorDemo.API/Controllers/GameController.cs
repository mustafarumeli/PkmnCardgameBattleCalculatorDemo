using BattleCalculatorDemo.API.Hubs;
using Microsoft.AspNetCore.Mvc;

namespace BattleCalculatorDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        [HttpGet("group")]
        public IActionResult GetGroups()
        {
            return Ok(GameManagerHub.RoomManagerInstance.GetAllRooms());
        }



    }
}