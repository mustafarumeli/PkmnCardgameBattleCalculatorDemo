using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;

namespace BattleCalculatorDemo.Cards.MonsterCards
{

    
    public class TheMountainCard : MonsterCard, IDevolve<MountainRangerCard>
    {
        public override string Name { get; set; } = "The Mountain";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; }
        public override int Atk { get; set; }
        public override int Def { get; set; }
        public override IList<ICardAttribute> Attributes { get; set; }
        public override IList<IMonsterType> Types { get; set; }

        public MountainRangerCard Devolve()
        {
            return new();
        }
       
    }
}
