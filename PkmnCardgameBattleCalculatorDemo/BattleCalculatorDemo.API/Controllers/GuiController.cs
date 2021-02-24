﻿using BattleCalculatorDemo.Crud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.MonsterCards;
using MongoORM4NetCore;

namespace BattleCalculatorDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuiController : ControllerBase
    {
        private MonsterCrud _crud;
        private Crud<CardAttribute> _cardAttributeCrud;

        public GuiController(MonsterCrud crud, Crud<CardAttribute> cardAttributeCrud)
        {
            _crud = crud;
            _cardAttributeCrud = cardAttributeCrud;

            if (_cardAttributeCrud.Count == 0)
            {
                _cardAttributeCrud.Insert(new IronWillCardAttribute());
                _cardAttributeCrud.Insert(new SharperCardAttribute());
                _cardAttributeCrud.Insert(new WeightlessCardAttribute());
                _cardAttributeCrud.Insert(new HardShellCardAttribute());
            }
            _crud.Insert(new MountainRangerCard());
        }

        [HttpGet("GetCardAttributes")]
        public IEnumerable<CardAttribute> GetCardAttributes()
        {
            return _cardAttributeCrud.GetAll();
        }

        [HttpGet("GetCards")]
        public IEnumerable<MonsterCard> GetCards()
        {
            var t = _crud.GetAll();
            return t;
        }


        [HttpPost("SaveCard")]
        public bool SaveCard(MonsterCard card)
        {
            _crud.Insert(card);
            return true;
        }
    }
}
