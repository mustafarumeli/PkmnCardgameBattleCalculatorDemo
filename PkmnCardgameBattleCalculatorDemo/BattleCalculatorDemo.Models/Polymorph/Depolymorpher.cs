﻿namespace BattleCalculatorDemo.Models.Polymorph
{
    public class Depolymorpher : IDepolymorpher
    {
        public IPolymorphSides Depolymorph(ref PolymorphedMonsterCard polymorphedMonsterCard)
        {
            var sides = polymorphedMonsterCard.PolymorphSides;
            polymorphedMonsterCard = null;
            return sides;
        }
    }
}