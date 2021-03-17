using BattleCalculatorDemo.AbstractionLayer;
using MediatR;

namespace BattleCalculatorDemo.CQ.Interfaces
{
    public interface IGenericEventNotification : INotification, IBoardNotification, ICardNotification
    {
        
    }

    public interface IAttributeEventNotification : INotification,ICardNotification
    {
        IAttribute Attribute { get; set; }
        IMonsterCard MonsterCard { get; set; }
    }
    
}