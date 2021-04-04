using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.MonsterCards;
using BattleCalculatorDemo.Models;

namespace BattleCalculatorDemo.API.Hubs.Clients
{
    public interface IGameManagerClient
    {
        Task SendOutHand(string monsterCardModels);
        Task SendOutHand(IEnumerable<IMonsterCard> monsterCardModels);
        Task JoinedRoom(string playerName);
        Task GroupId(string id);
        Task OpenBoard();
    }
}