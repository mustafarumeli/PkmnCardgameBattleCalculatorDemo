using System.Collections.Generic;
using System.Linq;
using BattleCalculatorDemo.Models.CardAttributes;
using BattleCalculatorDemo.Models.MonsterTypes;

namespace BattleCalculatorDemo.Models
{
    public class MonsterCard : IMonsterCard
    {

        private int _criticalChance = 50;
        private int _hitChance = 75;
        public string Name { get; set; }
        public string Image { get; set; }
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
        public IList<ICardAttributeAffectVariable> Attributes { get; set; } = new List<ICardAttributeAffectVariable>();
        public IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();
        public string Description
        {
            get
            {
                var attributeDesc = CreateCardDescription();
                return string.Join(",", attributeDesc);
            }
        }
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