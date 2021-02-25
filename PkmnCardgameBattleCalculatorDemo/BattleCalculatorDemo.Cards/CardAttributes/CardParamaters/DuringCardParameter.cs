using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.Helpers;
using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.CardAttributes.CardParamaters
{
    public record DuringCardParameter(MonsterCard Self, CombatResult CombatResult) : IVariableParameter;
}