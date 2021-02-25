using BattleCalculatorDemo.AbstractionLayer;
using MediatR;

namespace BattleCalculatorDemo.CQ.Interfaces
{
    public interface IBoardNotification : INotification
    {
        public IBoardManager BoardManager { get; set; }
    }
}