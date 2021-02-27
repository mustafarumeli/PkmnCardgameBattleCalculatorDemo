using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.CardParamaters;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class BlindEyeAttribute : ICardAttribute, ICardAttributeAffectVariable<SelfCardParameter>, ICardAttributeRevertableVariable<SelfCardParameter>
    {
        public BlindEyeAttribute(int ratio)
        {
            Ratio = ratio;
        }

        public string Name => "Blind Eye";
        public string Description => $"Doubles its Attack while Attacking but has {Ratio}% chance to miss";
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.BeforeAttack;

        public int Ratio { get; }
        private int _oldRatio = 50;

        public void Affect(SelfCardParameter parameter)
        {
            _oldRatio = parameter.Self.HitChance;
            parameter.Self.HitChance = 100 - Ratio;
        }

        public void Revert(SelfCardParameter parameter)
        {
            parameter.Self.HitChance = _oldRatio;
        }
        public string GetCardSpecificDescription()
        {
            return Name + " " + Ratio;
        }
    }
}