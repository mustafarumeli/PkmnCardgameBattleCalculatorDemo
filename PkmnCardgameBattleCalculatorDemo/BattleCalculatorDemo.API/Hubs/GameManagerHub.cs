using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.API.Hubs.Clients;
using BattleCalculatorDemo.BoardManager;
using BattleCalculatorDemo.BoardManager.Entities;
using BattleCalculatorDemo.Cards.MonsterCards;
using Microsoft.AspNetCore.SignalR;

namespace BattleCalculatorDemo.API.Hubs
{
    public partial class GameManagerHub : Hub<IGameManagerClient>
    {
        public static readonly RoomManager RoomManagerInstance = new();
        public async Task JoinRoom(string id, string playerName)
        {
            var playerInGame = new PlayerInGame()
            {
                Deck = new List<ICard>(),
                Name = playerName,
                Side = PlayerSide.Blue,
                CardsInHand = new List<ICard>()
            };
            var roomHub = RoomManagerInstance.JoinRoom(Guid.Parse(id), Context.ConnectionId, playerInGame);
            if (roomHub == null)
            {
                playerInGame.Side = PlayerSide.Red;
                roomHub = RoomManagerInstance.CreateRoom(new Player()
                {
                    ConnectionId = Context.ConnectionId,
                    PlayerInGame = playerInGame
                }, null, BoardManagerObject.CreateBoardManager(playerInGame, null));
            }

            var groupName = roomHub.Id.ToString();
            await Clients.Caller.GroupId(groupName);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.GroupExcept(groupName, Context.ConnectionId).JoinedRoom(playerName);
        }
    }
    public partial class GameManagerHub
    {
        public class RoomManager
        {
            private readonly ConcurrentDictionary<Guid, RoomHub> _rooms = new();

            public RoomHub CreateRoom(Player player1, Player player2, IBoardManager boardManager)
            {
                var roomHub = new RoomHub()
                {
                    Id = Guid.NewGuid(),
                    Player1 = player1,
                    Player2 = player2,
                    BoardManager = boardManager
                };
                if (_rooms.TryAdd(roomHub.Id, roomHub))
                {
                    return roomHub;
                }

                return null;
            }

            public RoomHub GetRoom(Guid id)
            {
                return _rooms.GetValueOrDefault(id);
            }

            public RoomHub JoinRoom(Guid id, string connectionId, IPlayerInGame playerInGame)
            {
                if (_rooms.TryGetValue(id, out var roomHub))
                {
                    roomHub.Player2 = new Player()
                    {
                        ConnectionId = connectionId,
                        PlayerInGame = playerInGame
                    };
                    roomHub.BoardManager.SetPlayer2(playerInGame);
                    return roomHub;
                }

                return null;
            }

            public IEnumerable<RoomHub> GetAllRooms() => _rooms.Values.AsEnumerable();
        }

        public class Player
        {
            public IPlayerInGame PlayerInGame { get; set; }
            public string ConnectionId { get; set; }
        }

        public class RoomHub
        {
            public Guid Id { get; set; }
            public IBoardManager BoardManager { get; set; }
            public Player Player1 { get; set; }
            public Player Player2 { get; set; }
        }
    }
}