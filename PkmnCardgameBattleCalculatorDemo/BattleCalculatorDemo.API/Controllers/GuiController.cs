using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleCalculatorDemo.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace BattleCalculatorDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuiController : ControllerBase
    {


        [HttpGet("GetCardAttributes")]
        public IEnumerable<CardAttributeModelWithoutType> GetCardAttributes()
        {
            var hs = CardAttributeHelper.GetCardAttributeTypeByName("Sharper", 25);
            var w = CardAttributeHelper.GetCardAttributeTypeByName("Weigthless", 25, 100);

            return CardAttributeHelper.GetCardAttributes().Select(x => new CardAttributeModelWithoutType(x.Name, x.VariableCount));
        }
    }
}
