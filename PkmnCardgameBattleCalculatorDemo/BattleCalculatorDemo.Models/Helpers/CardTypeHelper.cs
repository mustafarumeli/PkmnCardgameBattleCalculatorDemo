using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BattleCalculatorDemo.Cards.MonsterType;

namespace BattleCalculatorDemo.Models.Helpers
{
    public static class CardTypeHelper
    {
        public static IEnumerable<CardTypeModel> GetCardTypes()
        {
            var types = GetTypesInNamespace(Assembly.GetExecutingAssembly(),
                "BattleCalculatorDemo.Models.MonsterTypes");

            return types.Select(x => new CardTypeModel(x.Name, x));
        }
        private static IEnumerable<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes()
                .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)
                            && t.IsAssignableTo(typeof(IMonsterType))
                            && t.IsClass
                );
        }
        public static IMonsterType GetByName(string name)
        {
            var cardType = GetCardTypes().FirstOrDefault(x => x.Name == name);
            return (IMonsterType)Activator.CreateInstance(cardType.Type);
        }

    }
}
