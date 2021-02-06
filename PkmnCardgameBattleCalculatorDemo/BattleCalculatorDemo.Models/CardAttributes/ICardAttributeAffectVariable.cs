namespace BattleCalculatorDemo.Models.CardAttributes
{
    public interface ICardAttributeAffectVariable<in T> : ICardAttributeAffectVariable where T : IVariableParameter
    {
        void Affect(T parameter);

        void ICardAttributeAffectVariable.Affect(IVariableParameter parameter)
        {
            Affect((T)parameter);
        }

    }

    public interface ICardAttributeAffectVariable
    {
        string Name { get; set; }
        AttributeTriggers TriggerAttributeOn { get; }
        void Affect(IVariableParameter parameter);
    }
}