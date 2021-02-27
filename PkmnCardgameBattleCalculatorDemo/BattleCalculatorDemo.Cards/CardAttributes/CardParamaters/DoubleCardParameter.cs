using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.CardAttributes.CardParamaters
{
    public record DoubleCardParameter(MonsterCard Self, MonsterCard Other) : IVariableParameter;
}