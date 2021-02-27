using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class JackCard : MonsterCard, IDevolve<AhckCard>, IEvolve<BhansCard>
    {
        public override string Name { get; set; } = "Jack";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 100;
        public override int Atk { get; set; } = 200;
        public override int Def { get; set; } = 25;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public JackCard()
        {
            Attributes.WithEarlyBird();
            Types.HasScissors();
        }

        public BhansCard Evolve()
        {
            return new();
        }
        public AhckCard Devolve()
        {
            return new();
        }
    }
}