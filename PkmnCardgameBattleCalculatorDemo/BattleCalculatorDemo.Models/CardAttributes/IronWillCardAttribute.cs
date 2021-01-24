namespace BattleCalculatorDemo.Models.CardAttributes
{
    public class IronWillCardAttribute : ICardAttributeAffectVariable<DuringCardParameter>
    {
        public string Name => "Iron Will";

        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.DuringAttack;

        public void Affect(DuringCardParameter parameter)
        {
            parameter.Self.HitChance = 100;
            if (parameter.BattleResult.WasCritical)
                parameter.Self.Hp += (short)(parameter.BattleResult.DamageDealt / 2);
        }

    }
}