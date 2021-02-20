using MongoORM4NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.MonsterCards;
using BattleCalculatorDemo.Cards.MonsterType;
using MongoORM4NetCore.Interfaces;
using BattleCalculatorDemo.Models;

namespace BattleCalculatorDemo.Crud
{
    public class MonsterCrud : Crud<MonsterCard>
    {
        public bool Insert(CardModel card)
        {
            MonsterCard mc = new MonsterCard()
            {
                Atk = card.Atk,
                Attributes = card.Attributes.Select(x => x.GetAsAttribute()).ToList(),
                Def = card.Def,
                Hp = card.Hp,
                Image = card.Image,
                Name = card.Name,
                Description = card.Description,
                Types = card.Types.Select(x => x.GetAsMonsterType()).ToList()
            };
            return base.Insert(mc);
        }

        public new IEnumerable<CardReadModel> GetAll()
        {
            return base.GetAll().Select(x => new CardReadModel()
            {
                Atk = x.Atk,
                Def = x.Def,
                Description = x.Description,
                Image = x.Image,
                Name = x.Name,
                Types = string.Join(",", x.Types.Select(x => x.Name)),
                Hp = x.Hp
            });
        }
    }
   
  
}
