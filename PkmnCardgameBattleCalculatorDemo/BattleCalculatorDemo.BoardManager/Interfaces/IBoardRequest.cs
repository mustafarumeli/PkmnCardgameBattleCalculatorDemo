using MediatR;

namespace BattleCalculatorDemo.BoardManager.Interfaces
{
    public interface IBoardRequest : IRequest
    {
        public IBoardManager BoardManager { get; set; }
    }
}