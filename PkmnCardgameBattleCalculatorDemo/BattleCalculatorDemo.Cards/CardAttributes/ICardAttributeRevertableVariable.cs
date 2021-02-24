namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public interface ICardAttributeRevertableVariable<in T> : ICardAttributeRevertableVariable where T : IVariableParameter
    {
        void Revert(T parameter);
        void ICardAttributeRevertableVariable.Revert(IVariableParameter parameter)
        {
            Revert((T)parameter);
        }
    }

    public interface ICardAttributeRevertableVariable 
    {
        void Revert(IVariableParameter parameter);

    }
}