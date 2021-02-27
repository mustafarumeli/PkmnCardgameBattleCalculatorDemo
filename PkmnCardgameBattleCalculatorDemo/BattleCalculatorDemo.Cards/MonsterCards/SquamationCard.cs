using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.MonsterType;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class SquamationCard : MonsterCard
    {
        public override string Name { get; set; } = "Squamation";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 100;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 75;

        public override IList<ICardAttribute> Attributes { get; set; } =
            new List<ICardAttribute>() {new ChamaCardAttribute()};
        public override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>() { new PaperMonsterType()};
    }
}