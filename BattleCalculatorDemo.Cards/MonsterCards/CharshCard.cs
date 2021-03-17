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
    public class CharshCard : MonsterCard, IDevolve<DeagleCard>, IEvolve<OwarCard>, INotificationHandler<CardDiedNotification>
    {
        public override string Name { get; set; } = "Charsh";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 120;
        public override int Atk { get; set; } = 40;
        public override int Def { get; set; } = 30;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public CharshCard()
        {
            Attributes.WithBold().WithWill("Damage every monster on field by 20");
            Types.HasSound();
        }

        public OwarCard Evolve()
        {
            return new();
        }
        public DeagleCard Devolve()
        {
            return new();
        }

        public Task Handle(CardDiedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}