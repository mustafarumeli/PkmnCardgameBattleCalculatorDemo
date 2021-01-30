namespace BattleCalculatorDemo.Models.CardAttributes
{
    [CardAttributeStatus(isBeta: false, variableCount: 1, name: "Hard Shell")]
    public class HardShellCardAttribute : ICardAttributeAffectVariable<SelfCardParameter>
    {
        private readonly int _value;
        public string Name => "HardShell " + _value;
        public HardShellCardAttribute(int value)
        {
            _value = value;
        }

        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.AfterDefense;

        public void Affect(SelfCardParameter parameter)
        {
            parameter.Self.Hp += _value;
        }
    }
}