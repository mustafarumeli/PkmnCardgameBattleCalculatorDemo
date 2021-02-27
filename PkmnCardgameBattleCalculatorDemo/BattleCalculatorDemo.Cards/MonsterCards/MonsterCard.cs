using System.Collections.Generic;
using System.Linq;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes;
using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public abstract class MonsterCard : IMonsterCard
    {

        private int _criticalChance = 50;
        private int _hitChance = 75;
        public abstract string Name { get; set; }
        public abstract ICardImages CardImages { get; set; }
        public abstract int Hp { get; set; }
        public abstract int Atk { get; set; }
        public abstract int Def { get; set; }
        public int CriticalChance
        {
            get => _criticalChance;
            set => _criticalChance = value > 100 ? (int)100 : value;
        }
        public int HitChance
        {
            get => _hitChance;
            set => _hitChance = value > 100 ? (int)100 : value;
        }
        public abstract IList<ICardAttribute> Attributes { get; set; }
        public abstract IList<IMonsterType> Types { get; set; }
        public string Description => string.Join(",", CreateCardDescription());

        private IEnumerable<string> CreateCardDescription()
        {
            return Attributes.Select(cardAttribute => cardAttribute.GetCardSpecificDescription());
        }
        public void AddTypes(params IMonsterType[] monsterTypes)
        {
            Types = monsterTypes;
        }

        public string GetTypeNames()
        {
            return string.Join(",", Types.Select(x => x.Name));
        }

    }
}