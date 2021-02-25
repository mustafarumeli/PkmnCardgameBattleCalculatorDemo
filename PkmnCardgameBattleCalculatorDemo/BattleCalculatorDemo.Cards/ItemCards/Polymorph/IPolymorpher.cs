using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.ItemCards.Polymorph
{
    public interface IPolymorpher
    {
        PolymorphedMonsterCard Polymorph<TLeft, TRight>(TLeft leftCard, TRight rightCard)
            where TLeft : IMonsterCard
            where TRight : IMonsterCard;
    }
}