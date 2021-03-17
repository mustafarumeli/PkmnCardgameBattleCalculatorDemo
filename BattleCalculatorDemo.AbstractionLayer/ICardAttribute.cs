namespace BattleCalculatorDemo.AbstractionLayer
{
    public interface ICardAttribute
    {
        string Name { get;  }
        string Description { get;  }
        AttributeTriggers TriggerAttributeOn { get; }
        string GetCardSpecificDescription();

    }
}