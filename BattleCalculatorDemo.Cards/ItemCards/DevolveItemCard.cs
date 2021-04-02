﻿using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using System;

namespace BattleCalculatorDemo.Cards.ItemCards
{
    public class DevolveItemCard : IItemCard<EvolutionCardParameter>
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
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