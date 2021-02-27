using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class ShazhCard : MonsterCard, IEvolve<KhorCard>, IDevolve<PapyrCard>
    {
        public override string Name { get; set; } = "Shazh";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 70;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 25;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();

        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public ShazhCard()
        {
            Attributes.WithEarlyBird().WithWeightless(20, 5);
            Types.HasPaper().HasGlass();
        }

        public KhorCard Evolve()
        {
            return new();
        }


        public PapyrCard Devolve()
        {
            return new();
        }
    }
}