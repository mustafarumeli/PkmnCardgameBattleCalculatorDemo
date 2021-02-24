using System.Collections.Generic;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.MonsterType;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public interface IMonsterCard : ICard
    {
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int CriticalChance { get; set; }
        public int HitChance { get; set; }
        public IList<CardAttribute> Attributes { get; set; }
        public IList<IMonsterType> Types { get; set; }
    }
}