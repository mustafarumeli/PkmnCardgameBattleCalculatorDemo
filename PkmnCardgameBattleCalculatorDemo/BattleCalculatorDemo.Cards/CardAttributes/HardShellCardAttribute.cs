namespace BattleCalculatorDemo.Cards.CardAttributes
{
    [CardAttributeStatus(isBeta: false, variableCount: 1, name: "Hard Shell")]
    public class HardShellCardAttribute : ICardAttributeAffectVariable<SelfCardParameter>, IAttributeComparer<HardShellCardAttribute>
    {
        public int _value;
        private string _name = "Hard Shell ";

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public HardShellCardAttribute(int value)
        {
            _value = value;
        }

        public HardShellCardAttribute()
        {

        }
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.AfterDefense;

        public void Affect(SelfCardParameter parameter)
        {
            parameter.Self.Hp += _value;
        }

        public int CompareTo(HardShellCardAttribute other)
        {
            return _value.CompareTo(other._value);
        }
    }
}