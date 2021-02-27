using System;
using System.Threading.Tasks;
using Autofac;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.BoardManager;
using BattleCalculatorDemo.Cards.Helpers;
using BattleCalculatorDemo.Cards.MonsterCards;
using BattleCalculatorDemo.CQ.Notifications;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace BattleCalculatorDemo.Game
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterMediatR(typeof(MonsterCard).Assembly);
            builder.RegisterType<BoardManagerObject>().As<IBoardManager>();
            var container = builder.Build();
            var mountainRangerCard = new MountainRangerCard();
            var squamation = new SquamationCard();

            var combatResult = mountainRangerCard.Attacks(squamation);

            var notification = new CardDrawnNotification()
            {
                BoardManager = container.Resolve<IBoardManager>(),
                MonsterCard = mountainRangerCard
            };
            var mediator = container.Resolve<IMediator>();
            await mediator.Publish(notification);
        }
    }
}