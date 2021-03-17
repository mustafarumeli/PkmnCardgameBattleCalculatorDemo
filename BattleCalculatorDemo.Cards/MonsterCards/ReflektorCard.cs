using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType.Utils;
using BattleCalculatorDemo.CQ.Notifications;
using MediatR;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class ReflektorCard : MonsterCard, IEvolve<AbsorberCard>, INotificationHandler<CardPlayedNotification>
    {
        public override string Name { get; set; } = "Reflektor";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 50;
        public override int Atk { get; set; } = 0;
        public override int Def { get; set; } = 120;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public ReflektorCard()
        {
            Attributes.WithEarlyBird().WithShower("Can't Be targeted by monsters");
            Types.HasGlass().HasRock();
        }

        public AbsorberCard Evolve()
        {
            return new();
        }

        public Task Handle(CardPlayedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}