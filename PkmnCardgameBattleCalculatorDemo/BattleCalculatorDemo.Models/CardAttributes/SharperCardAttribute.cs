namespace BattleCalculatorDemo.Models.CardAttributes
{
    [CardAttributeStatus(isBeta: false)]
    public class SharperCardAttribute : ICardAttributeAffectVariable<SelfCardParameter>, ICardAttributeRevertableVariable<SelfCardParameter>
    {
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.BeforeAttack;
        short _previousValue { get; set; }
        public string Name => "Sharper ";

        public void Affect(SelfCardParameter parameter)
        {
            _previousValue = parameter.Self.HitChance;
            parameter.Self.HitChance = 100;
        }

        public void Revert(SelfCardParameter parameter)
        {
            parameter.Self.HitChance = _previousValue;
        }
    }
}