using System;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.CardParamaters;
using MongoDB.Bson.Serialization.Attributes;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    [CardAttributeStatus(isBeta: false, variableCount: 0, name: "Iron Will")]
    public class IronWillCardAttribute :
        CardAttribute,
        ICardAttributeAffectVariable<DuringCardParameter>,
        IAttributeComparer<IronWillCardAttribute>
    {
        public override string Name { get; set; } = "Iron Will";
        //protected override Type Type { get; set; } = typeof(IronWillCardAttribute);
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.DuringAttack;

        public void Affect(DuringCardParameter parameter)
        {
            parameter.Self.HitChance = 100;
            if (parameter.CombatResult.WasCritical)
                parameter.Self.Hp += (int)(parameter.CombatResult.DamageDealt / 2);
        }

        public int CompareTo(IronWillCardAttribute other)
        {
            return 0;
        }
    }
}