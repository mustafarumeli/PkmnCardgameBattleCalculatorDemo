using System;
using System.Collections.Generic;
using System.Linq;
using BattleCalculatorDemo.Models.CardAttributes;

namespace BattleCalculatorDemo.Models.Polymorph
{
    public class Polymorpher : IPolymorpher
    {
        public PolymorphedMonsterCard Polymorph<TLeft, TRight>(TLeft leftCard, TRight rightCard)
            where TLeft : IMonsterCard where TRight : IMonsterCard
        {
            if (CanCardsPolymorph(leftCard, rightCard))
            {
                return new()
                {
                    Atk = leftCard.Atk + rightCard.Atk,
                    Attributes = CombineAttributes(leftCard.Attributes, rightCard.Attributes),
                    CriticalChance = Math.Max(leftCard.CriticalChance, rightCard.CriticalChance),
                    Def = leftCard.Def + rightCard.Def,
                    HitChance = Math.Max(leftCard.HitChance, rightCard.HitChance),
                    Types = leftCard.Types.Union(rightCard.Types).ToList(),
                    Name = string.Join("", leftCard.Name.Take(rightCard.Name.Length / 2)) +
                           string.Join("", rightCard.Name.TakeLast(rightCard.Name.Length / 2)),
                    Hp = leftCard.Hp + rightCard.Hp,
                    PolymorphSides = new PolymorphSides(leftCard, rightCard)
                };
            }

            return null;
        }

        private bool CanCardsPolymorph<TLeft, TRight>(TLeft leftCard, TRight rightCard)
            where TLeft : IMonsterCard where TRight : IMonsterCard
        {
            return leftCard.Types.Any(x => rightCard.Types.Select(y => y.Name).Contains(x.Name));
        }

        List<ICardAttributeAffectVariable> CombineAttributes(
            IList<ICardAttributeAffectVariable> leftCardAttribute,
            IList<ICardAttributeAffectVariable> rightCardAttribute)
        {
            CardAttributeAffectVariableList list = new CardAttributeAffectVariableList();
            list.AddRange(leftCardAttribute);
            list.AddRange(rightCardAttribute);
            return list;
        }
    }
}