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
        public static ConcurrentDictionary<string, Player> _players = new ConcurrentDictionary<string, Player>();

        public static readonly RoomManager RoomManagerInstance = new();
        public async Task JoinRoom(string id, string playerName)
        {
            Player player = new Player();
            _players.TryGetValue(Context.ConnectionId, out player);
            if (player == null)
            {
                player = new Player
                {
                    ConnectionId = Context.ConnectionId,
                    PlayerInGame = new PlayerInGame()
                    {
                        Name = Context.ConnectionId,
                        Side = PlayerSide.Blue,
                        CardsInHand = new List<ICard>()
                    }
                };
                _players.TryAdd(Context.ConnectionId, player);
            }
            PlayerInGame playerInGame = (PlayerInGame)player.PlayerInGame;

            var roomHub = RoomManagerInstance.JoinRoom(Guid.Parse(id), Context.ConnectionId, playerInGame);
            if (roomHub == null)
            {
                playerInGame.Side = PlayerSide.Red;
                roomHub = RoomManagerInstance.CreateRoom(player, null, BoardManagerObject.CreateBoardManager(playerInGame, null), Guid.Parse(id));
            }
            else
            {
                roomHub.Player2 = player;
                roomHub.BoardManager.SetPlayer2(playerInGame);
            }
            var groupName = roomHub.Id.ToString();
            await Clients.Caller.GroupId(groupName);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.GroupExcept(groupName, Context.ConnectionId).JoinedRoom(playerName);
                await Clients.Client(Context.ConnectionId).SendOutHand(roomHub.Player1.GetHand(5));

            if (roomHub.Player1 != null && roomHub.Player2 != null)
            {
                await Clients.Client(roomHub.Player1.ConnectionId).SendOutHand(roomHub.Player1.GetHand(5));
                await Clients.Client(roomHub.Player2.ConnectionId).SendOutHand(roomHub.Player2.GetHand(6));

            }
        }
    }
    public partial class GameManagerHub
    {
        public class RoomManager
        {
            private readonly ConcurrentDictionary<Guid, RoomHub> _rooms = new();

            public RoomHub CreateRoom(Player player1, Player player2, IBoardManager boardManager, Guid? id = null)
            {
                var roomHub = new RoomHub()
                {
                    Id = id == null ? Guid.NewGuid() : id.Value,
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

            public IEnumerable<IMonsterCard> GetHand(int cardCount)
            {
                var cards = PlayerInGame.Deck.ToList();
                var random = new Random();
                for (int i = 0; i < cardCount; i++)
                {
                    var picked = (IMonsterCard)cards[random.Next(cards.Count)];
                    yield return picked;
                    cards.Remove(picked);
                }
            }
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