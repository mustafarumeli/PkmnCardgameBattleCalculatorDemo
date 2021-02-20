using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.CardAttributes
{
    public class EvolutionCardParameter : IVariableParameter
    {
        public IMonsterCard Self;
        public IMonsterCard ResultingMonsterCard;
    }
}