using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class SquamationCard : MonsterCard, IEvolve<AnnulatedCard>
    {
        public override string Name { get; set; } = "Squamation";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 100;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 75;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public SquamationCard()
        {
            Attributes.WithChama();
            Types.HasPaper();
        }

        public AnnulatedCard Evolve()
        {
            return new();
        }
    }
}