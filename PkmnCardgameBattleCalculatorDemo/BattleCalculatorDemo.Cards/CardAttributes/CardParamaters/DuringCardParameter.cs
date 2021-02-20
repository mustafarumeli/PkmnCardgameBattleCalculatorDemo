using BattleCalculatorDemo.Cards.Helpers;
using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public record DuringCardParameter(MonsterCard Self, CombatResult CombatResult) : IVariableParameter;
}