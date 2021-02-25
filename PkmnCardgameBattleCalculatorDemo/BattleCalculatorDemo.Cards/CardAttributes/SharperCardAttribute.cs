using System;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.CardParamaters;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    [CardAttributeStatus(isBeta: false, variableCount: 0, name: "Sharper")]
    public class SharperCardAttribute :
        CardAttribute,
        ICardAttributeAffectVariable<SelfCardParameter>,
        ICardAttributeRevertableVariable<SelfCardParameter>,
        IAttributeComparer<SharperCardAttribute>
    {
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.BeforeAttack;
        int PreviousValue { get; set; }
        public override string Name { get; set; } = "Sharper ";
        //protected override Type Type { get; set; } = typeof(SharperCardAttribute);

        public void Affect(SelfCardParameter parameter)
        {
            PreviousValue = parameter.Self.HitChance;
            parameter.Self.HitChance = 100;
        }

        public void Revert(SelfCardParameter parameter)
        {
            parameter.Self.HitChance = PreviousValue;
        }

        public int CompareTo(SharperCardAttribute other)
        {
            return 0;
        }
    }
}