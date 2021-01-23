using System.Collections.Generic;

namespace BattleCalculatorDemo.Models
{
    public interface ICard
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public ushort Hp { get; set; }
        public ushort Atk { get; set; }
        public ushort Def { get; set; }
        public ushort CriticalChance { get; set; }
        public ushort HitChance { get; set; }
        public IList<IValueVariable> Attributes { get; set; }
        public string Description { get; }
    }
}