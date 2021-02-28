using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.MonsterCards;
using BattleCalculatorDemo.Models;
using MongoORM4NetCore;

namespace BattleCalculatorDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuiController : ControllerBase
    {
        private readonly Crud<MonsterCardEntity> _monsterCardEntityCrud;
        private readonly Crud<CardImageEntity> _cardImageEntityCrud;
        private readonly IMapper _mapper;

        public GuiController(Crud<MonsterCardEntity> monsterCardEntityCrud, IMapper mapper, Crud<CardImageEntity> cardImageEntityCrud)
        {
            _monsterCardEntityCrud = monsterCardEntityCrud;
            _mapper = mapper;
            _cardImageEntityCrud = cardImageEntityCrud;

            if (monsterCardEntityCrud.CountAll == 0)
            {
                monsterCardEntityCrud.InsertMany(MonsterCardEntity.GetAllRegisteredCards().ToArray());
            }
        }
        [HttpGet("GetAllCards")]
        public IEnumerable<MonsterCardModel> GetAllCards()
        {
            var all = _cardImageEntityCrud.GetAll();
            foreach (var monsterCardModel in _monsterCardEntityCrud.GetAll().Select(x => _mapper.Map<MonsterCardModel>(x)))
            {
                monsterCardModel.MapImages(all);
                yield return monsterCardModel;
            }
        }

        [HttpPut("ResetAllCards")]
        public bool ResetAllCards()
        {
            _monsterCardEntityCrud.DropCollection();
            if (_monsterCardEntityCrud.CountAll == 0)
            {
                _monsterCardEntityCrud.InsertMany(MonsterCardEntity.GetAllRegisteredCards().ToArray());
            }
            return true;
        }

        [HttpPost("SaveImage")]
        public bool SaveImage([FromBody] ImageModel imageModel)
        {
            try
            {
                var t = _cardImageEntityCrud.Insert(_mapper.Map<CardImageEntity>(imageModel));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return true;
        }
    }
}
