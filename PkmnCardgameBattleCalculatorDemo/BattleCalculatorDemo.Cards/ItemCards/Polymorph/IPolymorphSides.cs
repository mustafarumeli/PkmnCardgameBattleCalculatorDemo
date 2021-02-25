using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.Cards.ItemCards.Polymorph
{
    public interface IPolymorphSides
    {
        public IMonsterCard LeftCard { get; set; }
        public IMonsterCard RightCard { get; set; }
    }
}