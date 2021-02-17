namespace BattleCalculatorDemo.Models.Polymorph
{
    public interface IPolymorpher
    {
        PolymorphedMonsterCard Polymorph<TLeft, TRight>(TLeft leftCard, TRight rightCard)
            where TLeft : IMonsterCard
            where TRight : IMonsterCard;
    }
}