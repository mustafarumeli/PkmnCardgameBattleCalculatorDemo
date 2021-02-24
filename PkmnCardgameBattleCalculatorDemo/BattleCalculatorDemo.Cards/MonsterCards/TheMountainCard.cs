using System;
using System.Text;
using System.Threading.Tasks;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;

namespace BattleCalculatorDemo.Cards.MonsterCards
{

    
    public class TheMountainCard : MonsterCard, IDevolve<MountainRangerCard> 
    {
        public override string Name { get; set; } = "The Mountain";
        public MountainRangerCard Devolve()
        {
            return new();
        }
       
    }
}
