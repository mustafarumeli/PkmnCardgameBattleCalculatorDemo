namespace BattleCalculatorDemo.AbstractionLayer
{
    public interface ICardAttributeRevertableVariable<in T> : ICardAttributeRevertableVariable where T : IVariableParameter
    {
        void Revert(T parameter);
        void ICardAttributeRevertableVariable.Revert(IVariableParameter parameter)
        {
            Revert((T)parameter);
        }
    }

    public interface ICardAttributeRevertableVariable : ICardAttribute
    {
        void Revert(IVariableParameter parameter);

    }
}