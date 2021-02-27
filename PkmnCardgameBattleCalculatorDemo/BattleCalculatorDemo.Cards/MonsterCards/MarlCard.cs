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
    public class MarlCard : MonsterCard, IDevolve<LehnCard>, IEvolve<EnebergCard>, INotificationHandler<CardEvolvedNotification>
    {
        public override string Name { get; set; } = "Marl";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 100;
        public override int Atk { get; set; } = 100;
        public override int Def { get; set; } = 25;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();

        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public MarlCard()
        {
            Attributes.WithShower("Attack a random enemy");
            Types.HasScissors().HasGlass();
        }

        public EnebergCard Evolve()
        {
            return new();
        }

        public LehnCard Devolve()
        {
            return new LehnCard();
        }

        public Task Handle(CardEvolvedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}