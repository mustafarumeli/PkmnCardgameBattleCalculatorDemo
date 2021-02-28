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
    public class EnebergCard : MonsterCard, IDevolve<MarlCard>, INotificationHandler<CardEvolvedNotification>
    {
        public override string Name { get; set; } = "Eneberg";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 150;
        public override int Atk { get; set; } = 150;
        public override int Def { get; set; } = 25;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();
        public EnebergCard()
        {
            Attributes.WithShower("Attack a random enemy twice");
            Types.HasScissors().HasGlass();
        }
        public MarlCard Devolve()
        {
            return new();
        }

        public Task Handle(CardEvolvedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}