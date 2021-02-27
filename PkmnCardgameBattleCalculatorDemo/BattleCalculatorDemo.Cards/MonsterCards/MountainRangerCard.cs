using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class MountainRangerCard : MonsterCard, IEvolve<MountainWatcherCard>
    {
        public override string Name { get; set; } = "Mountain Ranger";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 120;
        public override int Atk { get; set; } = 25;
        public override int Def { get; set; } = 50;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();

        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public MountainRangerCard()
        {
            Attributes.WithHardShell(5);
            Types.HasRock();
        }

        public MountainWatcherCard Evolve()
        {
            return new();
        }
    }
}