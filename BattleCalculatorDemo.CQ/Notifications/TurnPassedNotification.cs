using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.CQ.Interfaces;

namespace BattleCalculatorDemo.CQ.Notifications
{
    public class TurnPassedNotification : IBoardNotification
    {
        public IBoardManager BoardManager { get; set; }
    }
}