using System.Threading;
using System.Threading.Tasks;
using BattleCalculatorDemo.BoardManager.Interfaces;
using BattleCalculatorDemo.Cards.MonsterCards;
using MediatR;

namespace BattleCalculatorDemo.BoardManager.Notifications
{
   
    public class CardDrawnNotification : IBoardRequest 
    {
        public IBoardManager BoardManager { get; set; }
        public IMonsterCard MonsterCard { get; set; }
    }
    public class CardDrawnNotificationHandler : IRequestHandler<CardDrawnNotification>
    {
        public Task<Unit> Handle(CardDrawnNotification request, CancellationToken cancellationToken)
        {
            request.MonsterCard.Attributes.
        }
    }
}