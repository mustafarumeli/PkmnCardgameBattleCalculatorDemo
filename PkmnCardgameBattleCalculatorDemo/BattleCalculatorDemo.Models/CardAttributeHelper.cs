using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BattleCalculatorDemo.Models.CardAttributes;

namespace BattleCalculatorDemo.Models
{

    public static class CardAttributeHelper
    {
        public static IEnumerable<CardAttributeModel> GetCardAttributes()
        {
            var cachedValue = RedisFacade.GetFromJson<IEnumerable<CardAttributeModel>>("cardAttributes");
            if (cachedValue != null)
            {
                return cachedValue;
            }


            var types = GetTypesInNamespace(Assembly.GetExecutingAssembly(),
                "BattleCalculatorDemo.Models.CardAttributes");
            List<CardAttributeModel> retList = new List<CardAttributeModel>();
            foreach (var type in types)
            {
                var releasedAttribute =
                    type.CustomAttributes.FirstOrDefault(x => x.ConstructorArguments.Any(y => y.ArgumentType == typeof(bool) && !(bool)y.Value));

                var variableCount = (int)releasedAttribute.ConstructorArguments.FirstOrDefault(x => x.ArgumentType == typeof(int))
                    .Value;
                var name = (string)releasedAttribute.ConstructorArguments.FirstOrDefault(x => x.ArgumentType == typeof(string))
                    .Value;
                retList.Add(new CardAttributeModel(name, variableCount, type));
            }


            RedisFacade.SetAsJson("cardAttributes", retList);
            return retList;
        }
        private static IEnumerable<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes()
                .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)
                            &&
                            Attribute.IsDefined(t, typeof(CardAttributeStatusAttribute)
                            ));
        }

        public static ICardAttributeAffectVariable GetCardAttributeTypeByName(string name, params object[] constructorValues)
        {
            var cardAttribute = GetCardAttributes().FirstOrDefault(x => x.Name == name);
            if (cardAttribute.VariableCount > 0)
            {
                return (ICardAttributeAffectVariable)Activator.CreateInstance(cardAttribute.type, args: constructorValues);
            }

            return (ICardAttributeAffectVariable)Activator.CreateInstance(cardAttribute.type);
        }

    }

}