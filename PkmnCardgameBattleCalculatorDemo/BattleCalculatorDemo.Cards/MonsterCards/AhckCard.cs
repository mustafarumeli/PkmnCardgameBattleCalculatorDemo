using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class AhckCard : MonsterCard, IEvolve<JackCard>
    {
        public override string Name { get; set; } = "Ahck";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 50;
        public override int Atk { get; set; } = 100;
        public override int Def { get; set; } = 25;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public AhckCard()
        {
            Types.HasScissors();
        }

        public JackCard Evolve()
        {
            return new();
        }

    }
}