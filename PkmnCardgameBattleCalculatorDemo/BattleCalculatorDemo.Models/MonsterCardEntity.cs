using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.MonsterCards;
using MongoDB.Bson.Serialization.Attributes;
using MongoORM4NetCore;
using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Models
{
    public class MonsterCardEntity : DbObject
    {
        public string Name { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public string Description { get; set; }
        public IMonsterCard CardReference { get; set; }
        public string MainCardType { get; set; }
        public string SecondaryCardType { get; set; }

        public MonsterCardEntity(IMonsterCard card)
        {
            Name = card.Name;
            Atk = card.Atk;
            Def = card.Def;
            Hp = card.Hp;
            Description = card.Description;
            CardReference = card;
            MainCardType = card.Types.FirstOrDefault().Icon;
            SecondaryCardType = card.Types.Skip(1).FirstOrDefault()?.Icon;
        }

        public static IEnumerable<MonsterCardEntity> GetAllRegisteredCards()
        {
            var cards = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => !t.IsAbstract && t.IsAssignableTo(typeof(MonsterCard)))
                  .Select(x => (IMonsterCard)Activator.CreateInstance(x));

            foreach (var card in cards)
            {
                yield return new MonsterCardEntity((IMonsterCard)card);
            }

        }
    }
}