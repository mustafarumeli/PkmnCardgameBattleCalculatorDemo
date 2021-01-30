namespace BattleCalculatorDemo.Models.CardAttributes
{
    [CardAttributeStatus(isBeta: false)]
    public class IronWillCardAttribute : ICardAttributeAffectVariable<DuringCardParameter>
    {
        public string Name => "Iron Will";

        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.DuringAttack;

        public void Affect(DuringCardParameter parameter)
        {
            parameter.Self.HitChance = 100;
            if (parameter.CombatResult.WasCritical)
                parameter.Self.Hp += (short)(parameter.CombatResult.DamageDealt / 2);
        }

    }
}