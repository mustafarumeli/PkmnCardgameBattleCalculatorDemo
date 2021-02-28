using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.BoardManager.Entities
{
    public class PlayerInGame : IPlayerInGame
    {
        public string Name { get; set; }
        public ICollection<ICard> Deck { get; set; }
        public ICollection<ICard> CardsInHand { get; set; }
        public PlayerSide Side { get; set; }
    }

}