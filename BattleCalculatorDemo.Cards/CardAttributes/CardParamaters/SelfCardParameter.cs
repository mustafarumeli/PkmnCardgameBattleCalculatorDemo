using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.CardAttributes.CardParamaters
{
    public record SelfCardParameter(MonsterCard Self) : IVariableParameter;
}