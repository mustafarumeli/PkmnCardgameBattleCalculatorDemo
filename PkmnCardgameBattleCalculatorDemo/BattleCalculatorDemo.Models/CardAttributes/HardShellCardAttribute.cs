using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Models.CardAttributes
{
    [CardAttributeStatus(isBeta: false, variableCount: 1, name: "Hard Shell")]
    public class HardShellCardAttribute : ICardAttributeAffectVariable<SelfCardParameter>
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
    }
}