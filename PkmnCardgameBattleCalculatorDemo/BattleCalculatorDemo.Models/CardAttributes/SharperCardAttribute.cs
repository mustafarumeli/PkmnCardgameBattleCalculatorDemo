namespace BattleCalculatorDemo.Models.CardAttributes
{
    [CardAttributeStatus(isBeta: false, variableCount: 0, name: "Sharper")]
    public class SharperCardAttribute : ICardAttributeAffectVariable<SelfCardParameter>, ICardAttributeRevertableVariable<SelfCardParameter>
    {
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.BeforeAttack;
        int PreviousValue { get; set; }
        private string _name = "Sharper ";
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public void Affect(SelfCardParameter parameter)
        {
            PreviousValue = parameter.Self.HitChance;
            parameter.Self.HitChance = 100;
        }

        public void Revert(SelfCardParameter parameter)
        {
            parameter.Self.HitChance = PreviousValue;
        }
    }
}