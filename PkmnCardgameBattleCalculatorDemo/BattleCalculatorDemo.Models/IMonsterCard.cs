using System.Collections.Generic;
using BattleCalculatorDemo.Models.CardAttributes;
using BattleCalculatorDemo.Models.MonsterTypes;

namespace BattleCalculatorDemo.Models
{
    public interface ICard
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; }

    }

    public interface IMonsterCard : ICard
    {
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int CriticalChance { get; set; }
        public int HitChance { get; set; }
        public IList<ICardAttributeAffectVariable> Attributes { get; set; }
        public IList<IMonsterType> Types { get; set; }
    }
}