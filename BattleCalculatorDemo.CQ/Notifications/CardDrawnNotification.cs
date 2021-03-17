using System;
using System.Threading;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.CQ.Interfaces;
using MediatR;

namespace BattleCalculatorDemo.CQ.Notifications
{
   
    public class CardDrawnNotification : IGenericEventNotification 
    {
        public IBoardManager BoardManager { get; set; }
        public IMonsterCard MonsterCard { get; set; }
    }
}