using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.ItemCards.Polymorph
{
    public class PolymorphSides : IPolymorphSides
    {
        public PolymorphSides(IMonsterCard leftCard, IMonsterCard rightCard)
        {
            LeftCard = leftCard;
            RightCard = rightCard;
        }

        public PolymorphSides()
        {
            /// <summary>
            /// DO NOT DELETE !!
            /// </summary> 
        }
        public IMonsterCard LeftCard { get; set; }
        public IMonsterCard RightCard { get; set; }
    }
}