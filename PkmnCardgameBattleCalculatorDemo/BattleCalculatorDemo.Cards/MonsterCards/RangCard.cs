using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class RangCard : MonsterCard, IDevolve<WavCard>
    {
        public override string Name { get; set; } = "Rang";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 120;
        public override int Atk { get; set; } = 100;
        public override int Def { get; set; } = 90;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public RangCard()
        {
            Attributes.WithBlindEye(30).WithCoward().WithDetermined();
            Types.HasSound().HasGlass();
        }
        public WavCard Devolve()
        {
            return new();
        }
    }
}