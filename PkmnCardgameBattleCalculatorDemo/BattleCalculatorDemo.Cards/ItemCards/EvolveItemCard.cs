﻿using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;

namespace BattleCalculatorDemo.Cards.ItemCards
{
    public class EvolveItemCard : IItemCard<EvolutionCardParameter>
    {
        public string Name { get; set; } = "Evolve";
        public CardImages CardImages { get; set; }
        public string Description { get; } = "Very nice evolve";

        public void Affect(EvolutionCardParameter variableParameter)
        {
            if (variableParameter.Self is IEvolvable evolvable)
            {
                var evolved = evolvable.Evolve();
                variableParameter.ResultingMonsterCard = evolved;
            }
        }
    }
}