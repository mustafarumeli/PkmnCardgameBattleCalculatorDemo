using System.Collections.Generic;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class MountainRangerCard : MonsterCard, IEvolve<TheMountainCard>
    {
        public override string Name { get; set; } = "Mountain Ranger";

        public override IList<CardAttribute> Attributes { get; set; } = new List<CardAttribute>()
        {
            new IronWillCardAttribute(),
            new HardShellCardAttribute(25)
        };

        public override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>()
        {
            new RockMonsterType(), new GlassMonsterType()
        };

        public TheMountainCard Evolve()
        {
            return new();
        }
    }
}