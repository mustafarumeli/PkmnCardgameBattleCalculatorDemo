using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class TheMountainCard : MonsterCard, IDevolve<MountainWatcherCard>
    {
        public override string Name { get; set; } = "The Mountain";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 500;
        public override int Atk { get; set; } = 10;
        public override int Def { get; set; } = 150;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; }

        public TheMountainCard()
        {
            Attributes.WithHardShell(25).WithIronWill();
            Types.HasGlass().HasRock();
        }

        public MountainWatcherCard Devolve()
        {
            return new();
        }

    }
}