using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public record DoubleCardParameter(MonsterCard Attacker, MonsterCard Defender) : IVariableParameter;
}