namespace BattleCalculatorDemo.AbstractionLayer
{
    public abstract class OutsideCombatCardAttribute : ICardAttribute
    {
        public virtual string Name { get;  }
        public virtual string Description { get;  }
        public AttributeTriggers TriggerAttributeOn { get; } = AttributeTriggers.OutsideCombat;
    }
}