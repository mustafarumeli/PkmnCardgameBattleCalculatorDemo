using System.Collections.Generic;
using System.Linq;
using BattleCalculatorDemo.Models.CardAttributes;

namespace BattleCalculatorDemo.Models
{
    public class Card : ICard
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

        public IList<ICardAttributeAffectVariable> Attributes { get; set; } = new List<ICardAttributeAffectVariable>();

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
    }
}