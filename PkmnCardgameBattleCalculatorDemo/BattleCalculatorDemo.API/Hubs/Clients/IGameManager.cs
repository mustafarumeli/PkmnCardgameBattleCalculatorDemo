using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BattleCalculatorDemo.Models;

namespace BattleCalculatorDemo.API.Hubs.Clients
{
    public interface IGameManagerClient
    {
        Task SendOutHand(IEnumerable<MonsterCardModel> monsterCardModels);
        Task JoinedRoom(string playerName);
        Task GroupId(string id);
    }
}