using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class WavCard : MonsterCard, IDevolve<FocsCard>, IEvolve<RangCard>
    {
        public override string Name { get; set; } = "Wav";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 90;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 70;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public WavCard()
        {
            Attributes.WithBold().WithSharper();
            Types.HasSound();
        }

        public RangCard Evolve()
        {
            return new();
        }
        public FocsCard Devolve()
        {
            return new();
        }
    }
}