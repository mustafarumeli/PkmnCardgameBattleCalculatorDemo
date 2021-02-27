using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class EndemicCard : MonsterCard, IDevolve<AnnulatedCard>
    {
        public override string Name { get; set; } = "Endemic";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 100;
        public override int Atk { get; set; } = 100;
        public override int Def { get; set; } = 75;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public EndemicCard()
        {
            Attributes.WithThinker(2, "Devolve");
            Types.HasSound().HasGlass();
        }
        
        public AnnulatedCard Devolve()
        {
            return new();
        }
    }
}