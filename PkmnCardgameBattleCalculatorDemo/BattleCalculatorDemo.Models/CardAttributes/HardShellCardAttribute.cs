namespace BattleCalculatorDemo.Models.CardAttributes
{
    public class HardShellCardAttribute : ICardAttributeAffectVariable<SelfCardParameter>
    {
        private readonly short _value;
        public string Name => "HardShell " + _value;
        public HardShellCardAttribute(short value)
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