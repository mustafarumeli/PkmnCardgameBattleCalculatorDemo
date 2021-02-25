using System.Collections.Generic;

namespace BattleCalculatorDemo.AbstractionLayer
{
    public interface IMonsterCard : ICard
    {
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int CriticalChance { get; set; }
        public int HitChance { get; set; }
        public IList<ICardAttribute> Attributes { get; set; }
        public IList<IMonsterType> Types { get; set; }
    }
}