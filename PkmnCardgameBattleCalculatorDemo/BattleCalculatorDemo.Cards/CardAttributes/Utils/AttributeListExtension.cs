﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;

namespace BattleCalculatorDemo.Cards.CardAttributes.Utils
{
    public static class AttributeListExtension
    {
        public static IList<ICardAttribute> WithBold(this IList<ICardAttribute> list)
        {
            list.Add(new BoldCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithBright(this IList<ICardAttribute> list, int attackChanceRatio)
        {
            list.Add(new BrightCardAttribute(attackChanceRatio));
            return list;
        }
        public static IList<ICardAttribute> WithChama(this IList<ICardAttribute> list)
        {
            list.Add(new ChamaCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithCradle(this IList<ICardAttribute> list)
        {
            list.Add(new CradleCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithDeathDenier(this IList<ICardAttribute> list)
        {
            list.Add(new DeathDenierCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithDetermined(this IList<ICardAttribute> list)
        {
            list.Add(new DeterminedCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithFastFeet(this IList<ICardAttribute> list)
        {
            list.Add(new FastFeetCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithGermaphobe(this IList<ICardAttribute> list, int turnCount)
        {
            list.Add(new GermaphobeCardAttribute(turnCount));
            return list;
        }
        public static IList<ICardAttribute> WithHardShell(this IList<ICardAttribute> list, int val)
        {
            list.Add(new HardShellCardAttribute(val));
            return list;
        }
        public static IList<ICardAttribute> WithIronWill(this IList<ICardAttribute> list)
        {
            list.Add(new IronWillCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithLazy(this IList<ICardAttribute> list)
        {
            list.Add(new LazyCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithLoneWolf(this IList<ICardAttribute> list)
        {
            list.Add(new LoneWolfCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithSecondWind(this IList<ICardAttribute> list)
        {
            list.Add(new LoneWolfCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithSharper(this IList<ICardAttribute> list)
        {
            list.Add(new SharperCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithShower(this IList<ICardAttribute> list)
        {
            list.Add(new ShowerCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithSociopath(this IList<ICardAttribute> list, int monsterCount)
        {
            list.Add(new SociopathCardAttribute(monsterCount));
            return list;
        }
        public static IList<ICardAttribute> WithTarget(this IList<ICardAttribute> list)
        {
            list.Add(new TargetCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithThinker(this IList<ICardAttribute> list, int thinkerCount)
        {
            list.Add(new ThinkerCardAttribute(thinkerCount));
            return list;
        }
        public static IList<ICardAttribute> WithWeightless(this IList<ICardAttribute> list)
        {
            list.Add(new WeightlessCardAttribute());
            return list;
        }
        public static IList<ICardAttribute> WithWill(this IList<ICardAttribute> list)
        {
            list.Add(new WillCardAttribute());
            return list;
        }
    }
}
