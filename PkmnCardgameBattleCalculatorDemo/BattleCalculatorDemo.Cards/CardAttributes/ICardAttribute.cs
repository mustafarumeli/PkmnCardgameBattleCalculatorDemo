using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class CardAttribute : DbObject
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }

    public class EarlyBirdCardAttribute : CardAttribute
    {
        public override string Name { get; set; } = "Early Bird";
        public override string Description { get; set; } = "Evolves 1 turn faster";
    }

}