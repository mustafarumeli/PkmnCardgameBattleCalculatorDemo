using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BattleCalculatorDemo.Models.CardAttributes;

namespace BattleCalculatorDemo.Models
{
    public record CardAttributeModel(string Name, Type type);


    public static class GuiHelpers
    {
        public static IEnumerable<CardAttributeModel> GetCardAttributes()
        {
            return GetTypesInNamespace(Assembly.GetExecutingAssembly(), "BattleCalculatorDemo.Models.CardAttributes")
                .Select(x => new CardAttributeModel(x.Name, x));

        }
        private static IEnumerable<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            var types =
                assembly.GetTypes()
                    .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)
                                &&
                                Attribute.IsDefined(t, typeof(CardAttributeStatusAttribute)
                                ));
            return types.Where(x => x.GetCustomAttributesData().Any(x =>
                 x.ConstructorArguments.Any(y => y.Value != null && (bool)y.Value == false)));
        }
    }
}