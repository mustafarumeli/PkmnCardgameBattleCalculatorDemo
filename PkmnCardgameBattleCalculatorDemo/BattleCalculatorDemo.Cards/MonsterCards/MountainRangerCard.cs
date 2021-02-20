using BattleCalculatorDemo.Cards.ItemCards.Evolve;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class MountainRangerCard : MonsterCard, IEvolve<TheMountainCard>
    {
        public override string Name { get; set; } = "Mountain Ranger";

        public TheMountainCard Evolve()
        {
            return new();
        }
    }
}