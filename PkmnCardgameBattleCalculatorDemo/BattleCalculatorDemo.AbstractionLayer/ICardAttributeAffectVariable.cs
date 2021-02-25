namespace BattleCalculatorDemo.AbstractionLayer
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
        AttributeTriggers TriggerAttributeOn { get; }
        void Affect(IVariableParameter parameter);
    }
}