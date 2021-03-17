using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class FocsCard : MonsterCard, IEvolve<WavCard>
    {
        public override string Name { get; set; } = "Foc's";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 70;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 80;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public FocsCard()
        {
            Attributes.WithHyped().WithFastFeet();
            Types.HasSound().HasScissors();
        }

        public WavCard Evolve()
        {
            return new();
        }
    }
}