using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class DeagleCard : MonsterCard, IEvolve<CharshCard>
    {
        public override string Name { get; set; } = "Deagle";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 90;
        public override int Atk { get; set; } = 30;
        public override int Def { get; set; } = 25;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public DeagleCard()
        {
            Attributes.WithBold();
            Types.HasSound();
        }
        public CharshCard Evolve()
        {
            return new();
        }
    }
}