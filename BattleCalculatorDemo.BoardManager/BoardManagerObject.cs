using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.BoardManager.Entities;
using BattleCalculatorDemo.Cards.Helpers;
using BattleCalculatorDemo.Cards.MonsterCards;

namespace BattleCalculatorDemo.BoardManager
{

    public class CardOnBoardList : IEnumerable<IMonsterCard>
    {
        List<IMonsterCard> _list = new List<IMonsterCard>();

        public IMonsterCard GetMonsterCard(string id) => _list.FirstOrDefault(x => x.Id == id);

        public void PlayCardOnBoard(IMonsterCard card)
        {
            _list.Add(card);
        }
        public IEnumerator<IMonsterCard> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<IMonsterCard>).GetEnumerator();
        }
    }
    public class BoardManagerObject : IBoardManager
    {
        public IPlayerInGame Player1 { get; private set; }
        public IPlayerInGame Player2 { get; private set; }
        public CardOnBoardList Player1CardsOnBoard { get; set; }
        public CardOnBoardList Player2CardsOnBoard { get; set; }

        private int _turnTimer = 0;

        private BoardManagerObject(IPlayerInGame player1, IPlayerInGame player2)
        {
            Player1 = player1;
            Player2 = player2;
            Player1CardsOnBoard = new CardOnBoardList();
            Player2CardsOnBoard = new CardOnBoardList();
        }

        public void SetPlayer2(IPlayerInGame playerInGame)
        {
            Player2 = playerInGame;
        }

        private ICard GetCardFromDeck(string cardId, int playerNum)
        {
            if (playerNum == 1)
            {
                return Player1.CardsInHand.FirstOrDefault(x => x.Id == cardId);

            }
            return Player2.CardsInHand.FirstOrDefault(x => x.Id == cardId);
        }

        public void Player1PlayCard(string cardId)
        {
            IMonsterCard card = GetCardFromDeck(cardId, playerNum: 1) as IMonsterCard;
            Player1CardsOnBoard.PlayCardOnBoard(card);
        }


        public void Player2PlayCard(string cardId)
        {
            IMonsterCard card = GetCardFromDeck(cardId, playerNum: 2) as IMonsterCard;
            Player2CardsOnBoard.PlayCardOnBoard(card);
        }


        public static IBoardManager CreateBoardManager(IPlayerInGame player1, IPlayerInGame player2)
        {
            return new BoardManagerObject(player1, player2);
        }

        public ICombatResult Battle(string attackerId, string defenderId, int attackingSide = 1)
        {

            IMonsterCard attacker = GetAttacker(attackerId, attackingSide);
            IMonsterCard defender = GetDefender(defenderId, attackingSide);

            return BattleCalculator.Attacks((MonsterCard)attacker, (MonsterCard)defender);
        }

        private IMonsterCard GetDefender(string defenderId, int attackingSide)
        {
            if (attackingSide == 1)
            {
                return Player2CardsOnBoard.GetMonsterCard(defenderId);
            }
            else
            {
                return Player1CardsOnBoard.GetMonsterCard(defenderId);
            }
        }
        private IMonsterCard GetAttacker(string attackerId, int attackingSide)
        {
            if (attackingSide == 1)
            {
                return Player1CardsOnBoard.GetMonsterCard(attackerId);
            }
            else
            {
                return Player2CardsOnBoard.GetMonsterCard(attackerId);
            }
        }
    }
}