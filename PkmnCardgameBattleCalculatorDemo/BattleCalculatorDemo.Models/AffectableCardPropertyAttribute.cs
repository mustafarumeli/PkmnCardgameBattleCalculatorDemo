using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace BattleCalculatorDemo.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AffectableCardPropertyAttribute : Attribute
    {

    }
}
