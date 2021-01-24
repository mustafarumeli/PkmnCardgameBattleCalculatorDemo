using System.Collections.Generic;
using BattleCalculatorDemo.Models.CardAttributes;

namespace BattleCalculatorDemo.Models
{
    public interface ICard
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public short Hp { get; set; }
        public short Atk { get; set; }
        public short Def { get; set; }
        public short CriticalChance { get; set; }
        public short HitChance { get; set; }
        public IList<ICardAttributeAffectVariable> Attributes { get; set; }
        public string Description { get; }
    }
}