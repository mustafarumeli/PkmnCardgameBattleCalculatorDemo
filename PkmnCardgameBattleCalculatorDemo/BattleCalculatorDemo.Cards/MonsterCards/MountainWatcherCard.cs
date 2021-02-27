using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class MountainWatcherCard : MonsterCard, IEvolve<TheMountainCard>, IDevolve<MountainRangerCard>
    {
        public override string Name { get; set; } = "Mountain Watcher";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 250;
        public override int Atk { get; set; } = 10;
        public override int Def { get; set; } = 100;
        public sealed override IList<ICardAttribute> Attributes { get; set; }
        public sealed override IList<IMonsterType> Types { get; set; }

        public MountainWatcherCard()
        {
            Attributes.WithHardShell(5).WithFastFeet();
            Types.HasRock();
        }
        public TheMountainCard Evolve()
        {
            return new();
        }

        public MountainRangerCard Devolve()
        {
            return new();
        }
    }
}