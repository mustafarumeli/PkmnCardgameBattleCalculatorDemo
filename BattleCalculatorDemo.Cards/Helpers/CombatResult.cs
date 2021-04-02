using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BattleCalculatorDemo.Cards.Helpers
{
    public class CombatResult : ICombatResult
    {
        public int DamageDealt { get; set; }
        public bool WasCritical { get; set; } = false;
        public bool DidDefenderDie { get; set; } = false;
    }

    public class CardHelpers
    {
        public static ICollection<ICard> GetAllTierOneCards()
        {
            var monserCardTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.Namespace == "BattleCalculatorDemo.Cards.MonsterCards");
            return monserCardTypes.Where(x => typeof(IEvolvable).IsAssignableFrom(x) && !typeof(IDevolvable).IsAssignableFrom(x))
                .Select(x => (ICard)Activator.CreateInstance(x)).ToList();
        }
    }
}