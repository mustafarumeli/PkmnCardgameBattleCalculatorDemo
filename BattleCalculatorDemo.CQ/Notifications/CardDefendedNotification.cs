using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.CQ.Interfaces;

namespace BattleCalculatorDemo.CQ.Notifications
{
    public class CardDefendedNotification : IGenericEventNotification
    {
        public IBoardManager BoardManager { get; set; }
        public IMonsterCard MonsterCard { get; set; }
    }
}