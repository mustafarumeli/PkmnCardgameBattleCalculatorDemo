namespace BattleCalculatorDemo.AbstractionLayer
{
    public interface IItemCard : ICard
    {
        void Affect(IVariableParameter variableParameter);
    }
    public interface IItemCard<in T> : IItemCard where T : IVariableParameter
    {
        void Affect(T variableParameter);

        void IItemCard.Affect(IVariableParameter variableParameter)
        {
            Affect((T)variableParameter);
        }
    }
}