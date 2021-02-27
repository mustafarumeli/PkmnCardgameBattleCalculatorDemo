using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class PapyrCard : MonsterCard, IEvolve<ShazhCard>
    {
        public override string Name { get; set; } = "Papyr";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 50;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 50;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();

        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public PapyrCard()
        {
            Attributes.WithEarlyBird();
            Types.HasPaper();
        }

        public ShazhCard Evolve()
        {
            return new();
        }
    }
}