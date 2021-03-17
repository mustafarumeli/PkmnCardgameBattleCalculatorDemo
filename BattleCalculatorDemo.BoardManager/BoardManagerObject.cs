using System;
using System.Collections.Generic;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.BoardManager.Entities;

namespace BattleCalculatorDemo.BoardManager
{
    public class BoardManagerObject : IBoardManager
    {
        public IPlayerInGame Player1 { get; private set;}
        public IPlayerInGame Player2 { get; private set;}
        public ICollection<ICard> CardsOnBoard { get; private set; }
        private int _turnTimer = 0;

        private BoardManagerObject(IPlayerInGame player1, IPlayerInGame player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public void SetPlayer2(IPlayerInGame playerInGame)
        {
            Player2 = playerInGame;
        }

        public static IBoardManager CreateBoardManager(IPlayerInGame player1, IPlayerInGame player2)
        {
            return new BoardManagerObject(player1, player2);
        }
    }
}