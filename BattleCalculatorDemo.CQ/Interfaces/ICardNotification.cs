using BattleCalculatorDemo.AbstractionLayer;
using MediatR;

namespace BattleCalculatorDemo.CQ.Interfaces
{
    public interface ICardNotification : INotification
    {
        public IMonsterCard MonsterCard { get; set; }
    }
}