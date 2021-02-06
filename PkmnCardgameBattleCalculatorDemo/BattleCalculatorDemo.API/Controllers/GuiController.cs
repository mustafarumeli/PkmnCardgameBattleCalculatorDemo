﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleCalculatorDemo.API.Controllers;
using BattleCalculatorDemo.Crud;
using BattleCalculatorDemo.Models;
using BattleCalculatorDemo.Models.Models;
using Microsoft.Extensions.Caching.Distributed;
using MongoORM4NetCore;
using MongoORM4NetCore.Interfaces;

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
            return CardAttributeHelper.GetCardAttributes().Select(x => new CardAttributeModelWithoutType(x.Name, x.VariableCount));
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


    }

}
