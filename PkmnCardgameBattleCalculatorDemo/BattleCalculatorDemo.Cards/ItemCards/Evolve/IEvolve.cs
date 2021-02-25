using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.ItemCards.Evolve
{
    public interface IEvolve<out TNext> : IEvolvable where TNext : IMonsterCard
    {
        TNext Evolve();
        IMonsterCard IEvolvable.Evolve()
        {
            return Evolve();
        }
    }
}