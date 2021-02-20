using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.ItemCards.Evolve
{
    public interface IDevolve<out TPrevious> : IDevolvable where TPrevious : IMonsterCard
    {
        TPrevious Devolve();
        IMonsterCard IDevolvable.Devolve()
        {
            return Devolve();
        }
    }
}