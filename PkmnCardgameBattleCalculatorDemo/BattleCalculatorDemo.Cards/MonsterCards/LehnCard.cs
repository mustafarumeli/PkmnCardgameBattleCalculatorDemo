using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class LehnCard : MonsterCard, IEvolve<MarlCard>
    {
        public override string Name { get; set; } = "Lehn";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 70;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 25;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();

        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public LehnCard()
        {
            Attributes.WithFastFeet();
            Types.HasScissors();
        }

        public MarlCard Evolve()
        {
            return new();
        }
    }
}