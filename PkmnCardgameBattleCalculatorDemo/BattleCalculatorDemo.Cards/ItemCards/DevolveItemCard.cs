using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.ItemCards;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;

namespace BattleCalculatorDemo.Cards
{
    public class DevolveItemCard : IItemCard<EvolutionCardParameter>
    {
        public string Name { get; set; } = "Evolve";
        public string Image { get; set; } = "evolve.png";
        public string Description { get; } = "Very nice evolve";

        public void Affect(EvolutionCardParameter variableParameter)
        {
            if (variableParameter.Self is IDevolvable devolvable)
            {
                var devolved = devolvable.Devolve();
                variableParameter.ResultingMonsterCard = devolved;
            }
        }
    }
}