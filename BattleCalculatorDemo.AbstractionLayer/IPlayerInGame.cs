using System.Collections.Generic;

namespace BattleCalculatorDemo.AbstractionLayer
{
    public interface IPlayerInGame
    {
        string Name { get; set; }
        ICollection<ICard> Deck { get; set; }
        ICollection<ICard> CardsInHand { get; set; }
        PlayerSide Side { get; set; }
    }
    
    public enum PlayerSide
    {
        Red, Blue
    }
}