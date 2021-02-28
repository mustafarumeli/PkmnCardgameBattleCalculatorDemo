using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class JohnsCard : MonsterCard, IDevolve<DwayCard>
    {
        public override string Name { get; set; } = "Johns";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 200;
        public override int Atk { get; set; } = 30;
        public override int Def { get; set; } = 450;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public JohnsCard()
        {
            Attributes.WithLoneWolf("Lose 50% of its defense power").WithShattered(25);
            Types.HasRock();
        }
        public DwayCard Devolve()
        {
            return new();
        }
    }
}