﻿using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;

namespace BattleCalculatorDemo.Cards.ItemCards
{
    public class DevolveItemCard : IItemCard<EvolutionCardParameter>
    {
        public string Name { get; set; } = "Evolve";
        public ICardImages CardImages { get; set; }
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