using System.Collections.Generic;

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
        public IList<IValueVariable> Attributes { get; set; }
        public string Description { get; }
    }
}