using System;
using System.Linq;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.AbstractionLayer.Utils;
using BattleCalculatorDemo.Cards.CardAttributes.CardParamaters;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class ChamaCardAttribute : CardAttribute, ICardAttributeAffectVariable<DoubleCardParameter>,
        IAttributeComparer<ChamaCardAttribute>
    {
        public override string Name { get; set; } = "Chama";
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.BeforeDefense;

        public void Affect(DoubleCardParameter parameter)
        {
            var (defender, attacker) = parameter;
            var attackerTypes = attacker.Types;
            defender.Types = attackerTypes.Select(x => x.DeepClone()).ToList();
        }

        public int CompareTo(ChamaCardAttribute? other)
        {
            return 0;
        }
    }
}