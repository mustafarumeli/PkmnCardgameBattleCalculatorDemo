using System.Collections.Generic;
using System.Linq;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.MonsterCards;
using BattleCalculatorDemo.Cards.MonsterType;

namespace BattleCalculatorDemo.Cards.ItemCards.Polymorph
{
    public sealed class PolymorphedMonsterCard : IPolymorphedMonsterCard, IMonsterCard
    {

        private int _criticalChance = 50;
        private int _hitChance = 75;

        public string Name { get; set; }
        public CardImages CardImages { get; set; }
        public int Hp { get; set; } = 0;
        public int Atk { get; set; } = 0;
        public int Def { get; set; } = 0;
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
        public IList<CardAttribute> Attributes { get; set; } = new List<CardAttribute>();
        public IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();
        public string Description { get; set; }
        public string CardDescription => !string.IsNullOrWhiteSpace(Description) ? Description : string.Join(",", CreateCardDescription());

        private IEnumerable<string> CreateCardDescription()
        {
            return new List<string>();
        }
        public void AddTypes(params IMonsterType[] monsterTypes)
        {
            Types = monsterTypes;
        }

        public string GetTypeNames()
        {
            return string.Join(",", Types.Select(x => x.Name));
        }

        public IPolymorphSides PolymorphSides { get; set; } = new PolymorphSides();
    }
}