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
    public class MatteCard : MonsterCard, IDevolve<AbsorberCard>, INotificationHandler<CardDiedNotification>
    {
        public override string Name { get; set; } = "Matte";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 100;
        public override int Atk { get; set; } = 0;
        public override int Def { get; set; } = 120;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public MatteCard()
        {
            Attributes.WithTarget().WithWill("Give a random ally Target");
            Types.HasRock().HasGlass();
        }

        public AbsorberCard Devolve()
        {
            return new();
        }

        public Task Handle(CardDiedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}