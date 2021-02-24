using MongoORM4NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.MonsterCards;
using BattleCalculatorDemo.Cards.MonsterType;
using MongoORM4NetCore.Interfaces;

namespace BattleCalculatorDemo.Crud
{
    public class MonsterCrud : Crud<MonsterCard>
    {
    }
}
