using BattleCalculatorDemo.Crud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleCalculatorDemo.Models;
using BattleCalculatorDemo.Models.Helpers;

namespace BattleCalculatorDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuiController : ControllerBase
    {
        private MonsterCrud _crud;

        public GuiController(MonsterCrud crud)
        {
            _crud = crud;
        }


        [HttpGet("GetCardAttributes")]
        public IEnumerable<CardAttributeModelWithoutType> GetCardAttributes()
        {
            return CardAttributeHelper.GetCardAttributes()
                .Select(x => new CardAttributeModelWithoutType(x.Name, x.VariableCount));
        }

        [HttpGet("GetCardTypes")]
        public IEnumerable<CardTypeModelWithoutType> GetCardTypes()
        {
            return CardTypeHelper.GetCardTypes().Select(x => new CardTypeModelWithoutType(x.Name));
        }

        [HttpGet("GetCards")]
        public IEnumerable<CardReadModel> GetCards()
        {
            return _crud.GetAll();
        }

        [HttpPost("SaveCard")]
        public bool SaveCard(CardModel card)
        {
            _crud.Insert(card);
            return true;
        }

        [HttpGet("test")]
        public bool Test()
        {
            return false;
        }

    }
}
