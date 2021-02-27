using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.CardParamaters;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class BrightCardAttribute :
        CardAttribute,
        ICardAttributeRevertableVariable<DoubleCardParameter>,
        ICardAttributeAffectVariable<DoubleCardParameter>
    {
        public string Name => "Bright";
        public string Description => $"At the Start of Combat enemy attack chance lowered by {_attackChanceRatio}%";
        public BrightCardAttribute(int attackChanceRatio)
        {
            _attackChanceRatio = attackChanceRatio;
        }
        private readonly int _attackChanceRatio;
        private int _attackChanceToRevert = 0;

        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.BeforeDefense;
        public void Revert(DoubleCardParameter parameter)
        {
            parameter.Other.HitChance = _attackChanceToRevert;
        }

        public void Affect(DoubleCardParameter parameter)
        {
            _attackChanceToRevert = parameter.Other.HitChance;
            parameter.Other.HitChance = (int)parameter.Other.HitChance * _attackChanceRatio / 100;
        }

        public override string GetCardSpecificDescription()
        {
            return Name + " " + _attackChanceRatio;
        }
    }
}