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
    public class OwarCard : MonsterCard, IDevolve<CharshCard>, INotificationHandler<CardAttackedNotification>
    {
        public override string Name { get; set; } = "Owar";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 150;
        public override int Atk { get; set; } = 60;
        public override int Def { get; set; } = 50;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public OwarCard()
        {
            Attributes.WithBold().WithHyped();
            Types.HasSound().HasGlass();
        }
        public CharshCard Devolve()
        {
            return new();
        }

        public Task Handle(CardAttackedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}