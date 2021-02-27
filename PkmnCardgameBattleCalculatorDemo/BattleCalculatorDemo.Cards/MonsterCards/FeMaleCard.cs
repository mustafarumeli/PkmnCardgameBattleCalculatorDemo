using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class FeMaleCard : MonsterCard, IEvolve<DwayCard>
    {
        public override string Name { get; set; } = "Fe Male";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 80;
        public override int Atk { get; set; } = 25;
        public override int Def { get; set; } = 110;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public FeMaleCard()
        {
            Attributes.WithIronWill();
            Types.HasRock();
        }

        public DwayCard Evolve()
        {
            return new();
        }

    }
}