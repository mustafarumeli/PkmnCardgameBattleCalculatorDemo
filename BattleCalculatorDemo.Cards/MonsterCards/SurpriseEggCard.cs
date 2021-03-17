using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class SurpriseEggCard : MonsterCard, IEvolve<FeatherBoyCard>
    {
        public override string Name { get; set; } = "Surprise Egg";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 50;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 50;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public SurpriseEggCard()
        {
            Types.HasGlass();
        }

        public FeatherBoyCard Evolve()
        {
            return new();
        }

    }
}