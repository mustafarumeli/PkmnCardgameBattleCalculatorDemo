using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.ItemCards.Evolve
{
    public interface IEvolvable
    {
        IMonsterCard Evolve();
    }
}