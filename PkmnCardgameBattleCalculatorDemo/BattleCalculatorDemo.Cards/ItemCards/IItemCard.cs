using BattleCalculatorDemo.Cards.CardAttributes;

namespace BattleCalculatorDemo.Cards.ItemCards
{
    public interface IItemCard : ICard
    {
        void Affect(IVariableParameter variableParameter);
    }
    public interface IItemCard<T> : IItemCard where T : IVariableParameter
    {
        void Affect(T variableParameter);

        void IItemCard.Affect(IVariableParameter variableParameter)
        {
            Affect((T)variableParameter);
        }
    }
}