using System.Collections.Generic;

namespace BattleCalculatorDemo.Models
{
    public class Card : ICard
    {
        private ushort _criticalChance = 50;
        private ushort _hitChance = 100;
        public string Name { get; set; }
        public string Image { get; set; }

        [AffectableCardProperty]
        public ushort Hp { get; set; } = ushort.MinValue;
        [AffectableCardProperty]
        public ushort Atk { get; set; } = ushort.MinValue;
        [AffectableCardProperty]
        public ushort Def { get; set; } = ushort.MinValue;

        [AffectableCardProperty]
        public ushort CriticalChance
        {
            get => _criticalChance;
            set => _criticalChance = value > 100 ? (ushort)100 : value;
        }
        [AffectableCardProperty]
        public ushort HitChance
        {
            get => _hitChance;
            set => _hitChance = value > 100 ? (ushort)100 : value;
        }

        public IList<IValueVariable> Attributes { get; set; } = new List<IValueVariable>();


        public string Description => this.CreateCardDescription();
    }
}