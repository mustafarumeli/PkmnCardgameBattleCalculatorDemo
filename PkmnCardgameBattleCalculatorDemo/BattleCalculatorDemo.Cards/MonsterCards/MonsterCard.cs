using System.Collections.Generic;
using System.Linq;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes;
using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class MonsterCard : DbObjectSD, IMonsterCard
    {

        private int _criticalChance = 50;
        private int _hitChance = 75;
        public virtual string Name { get; set; }
        public virtual ICardImages CardImages { get; set; }
        public virtual int Hp { get; set; } = 0;
        public virtual int Atk { get; set; } = 0;
        public virtual int Def { get; set; } = 0;
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
        public virtual IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public virtual IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();
        public string Description { get; set; }
        public string CardDescription => !string.IsNullOrWhiteSpace(Description) ? Description : string.Join(",", CreateCardDescription());

        private IEnumerable<string> CreateCardDescription()
        {
            return Attributes.Select(cardAttribute => cardAttribute.Name);
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