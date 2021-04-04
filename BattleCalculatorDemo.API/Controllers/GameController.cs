using System.Collections.Generic;
using System.Linq;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.API.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Connections;

namespace BattleCalculatorDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {

        private Microsoft.AspNetCore.SignalR.IHubContext<GameManagerHub> _hub;



        [HttpGet("group")]
        public IActionResult GetGroups()
        {
            return Ok(GameManagerHub.RoomManagerInstance.GetAllRooms());
        }
        [HttpGet("RequestHand")]
        public IEnumerable<IMonsterCard> RequestHand(string connectionId)
        {
            var roomHub = GameManagerHub.RoomManagerInstance.GetAllRooms().First();
            if (roomHub.Player1.ConnectionId == connectionId)
            {
                return roomHub.Player1.GetHand(6);
            }
            return roomHub.Player2.GetHand(5);
        }

    }
}