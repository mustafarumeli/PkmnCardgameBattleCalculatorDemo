using System.Collections.Generic;

namespace BattleCalculatorDemo.Models
{
    public record Card : ICard
    {

        private short _criticalChance = 50;
        private short _hitChance = 75;
        public string Name { get; set; }
        public string Image { get; set; }
        public short Hp { get; set; } = 0;
        public short Atk { get; set; } = 0;
        public short Def { get; set; } = 0;
        public short CriticalChance
        {
            get => _criticalChance;
            set => _criticalChance = value > 100 ? (short)100 : value;
        }
        public short HitChance
        {
            get => _hitChance;
            set => _hitChance = value > 100 ? (short)100 : value;
        }

        public IList<IValueVariable> Attributes { get; set; } = new List<IValueVariable>();

        public string Description => this.CreateCardDescription();
    }
}