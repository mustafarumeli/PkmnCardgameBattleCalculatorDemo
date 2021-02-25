using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.CardParamaters;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    [CardAttributeStatus(isBeta: false, variableCount: 1, name: "Hard Shell")]
    public class HardShellCardAttribute :
        CardAttribute,
        ICardAttributeAffectVariable<SelfCardParameter>,
        IAttributeComparer<HardShellCardAttribute>
    {
        public int _value;

        public override string Name { get; set; } = "Hard Shell ";
        //protected override Type Type { get; set; } = typeof(HardShellCardAttribute);

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