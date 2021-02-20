using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public record SelfCardParameter(MonsterCard Self) : IVariableParameter;
}