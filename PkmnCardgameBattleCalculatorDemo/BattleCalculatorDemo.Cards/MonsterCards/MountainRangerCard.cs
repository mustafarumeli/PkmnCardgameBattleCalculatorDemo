﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.CardAttributes.Utils;
using BattleCalculatorDemo.Cards.ItemCards.Evolve;
using BattleCalculatorDemo.Cards.MonsterType;
using BattleCalculatorDemo.Cards.MonsterType.Utils;
using BattleCalculatorDemo.CQ.Notifications;
using MediatR;

namespace BattleCalculatorDemo.Cards.MonsterCards
{
    public class MountainRangerCard : MonsterCard, IEvolve<MountainWatcherCard>
    {
        public override string Name { get; set; } = "Mountain Ranger";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 120;
        public override int Atk { get; set; } = 25;
        public override int Def { get; set; } = 50;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();

        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public MountainRangerCard()
        {
            Attributes.WithHardShell(5);
            Types.HasRock();
        }

        public MountainWatcherCard Evolve()
        {
            return new();
        }
    }
    public class MountainWatcherCard : MonsterCard, IEvolve<TheMountainCard>, IDevolve<MountainRangerCard>
    {
        public override string Name { get; set; } = "Mountain Watcher";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 250;
        public override int Atk { get; set; } = 10;
        public override int Def { get; set; } = 100;
        public sealed override IList<ICardAttribute> Attributes { get; set; }
        public sealed override IList<IMonsterType> Types { get; set; }

        public MountainWatcherCard()
        {
            Attributes.WithHardShell(5).WithFastFeet();
            Types.HasRock();
        }
        public TheMountainCard Evolve()
        {
            return new();
        }

        public MountainRangerCard Devolve()
        {
            return new();
        }
    }
    public class TheMountainCard : MonsterCard, IDevolve<MountainWatcherCard>
    {
        public override string Name { get; set; } = "The Mountain";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 500;
        public override int Atk { get; set; } = 10;
        public override int Def { get; set; } = 150;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; }

        public TheMountainCard()
        {
            Attributes.WithHardShell(25).WithIronWill();
            Types.HasGlass().HasRock();
        }

        public MountainWatcherCard Devolve()
        {
            return new();
        }

    }

    public class LehnCard : MonsterCard, IEvolve<MarlCard>
    {
        public override string Name { get; set; } = "Lehn";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 70;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 25;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();

        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public LehnCard()
        {
            Attributes.WithFastFeet();
            Types.HasScissors();
        }

        public MarlCard Evolve()
        {
            return new();
        }
    }
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
            Attributes.WithShower();
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
    public class EnebergCard : MonsterCard, IDevolve<MarlCard>, INotificationHandler<CardEvolvedNotification>
    {
        public override string Name { get; set; } = "Eneberg";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 150;
        public override int Atk { get; set; } = 150;
        public override int Def { get; set; } = 25;
        public sealed override IList<ICardAttribute> Attributes { get; set; }
        public sealed override IList<IMonsterType> Types { get; set; }
        public EnebergCard()
        {
            Attributes.WithShower();
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

    public class PapyrCard : MonsterCard, IEvolve<ShazhCard>
    {
        public override string Name { get; set; } = "Papyr";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 50;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 50;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();

        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public PapyrCard()
        {
            Attributes.WithEarlyBird();
            Types.HasPaper();
        }

        public ShazhCard Evolve()
        {
            return new();
        }
    }
    public class ShazhCard : MonsterCard, IEvolve<KhorCard>, IDevolve<PapyrCard>
    {
        public override string Name { get; set; } = "Shazh";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 70;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 25;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();

        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public ShazhCard()
        {
            Attributes.WithEarlyBird().WithWeightless(20, 5);
            Types.HasPaper().HasGlass();
        }

        public KhorCard Evolve()
        {
            return new();
        }


        public PapyrCard Devolve()
        {
            return new();
        }
    }
    public class KhorCard : MonsterCard, IDevolve<ShazhCard>
    {
        public override string Name { get; set; } = "Khor";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 100;
        public override int Atk { get; set; } = 100;
        public override int Def { get; set; } = 100;

        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();

        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public KhorCard()
        {
            Attributes.WithHyped().WithShattered(70).WithSharper();
            Types.HasScissors().HasPaper();
        }

        public ShazhCard Devolve()
        {
            return new();
        }
    }

    public class DeagleCard : MonsterCard, IEvolve<CharshCard>
    {
        public override string Name { get; set; } = "Deagle";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 90;
        public override int Atk { get; set; } = 30;
        public override int Def { get; set; } = 25;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public DeagleCard()
        {
            Attributes.WithBold();
            Types.HasSound();
        }
        public CharshCard Evolve()
        {
            return new();
        }
    }
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
            Attributes.WithBold().WithWill();
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

    public class SurpriseEggCard : MonsterCard, IEvolve<FeatherBoyCard>
    {
        public override string Name { get; set; } = "Surprise Egg";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 50;
        public override int Atk { get; set; } = 50;
        public override int Def { get; set; } = 50;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public SurpriseEggCard()
        {
            Types.HasGlass();
        }

        public FeatherBoyCard Evolve()
        {
            return new();
        }

    }
    public class FeatherBoyCard : MonsterCard, IEvolve<AngryEagleCard>, IDevolve<SurpriseEggCard>,INotificationHandler<CardPlayedNotification>
    {
        public override string Name { get; set; } = "Feather Boy";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 100;
        public override int Atk { get; set; } = 100;
        public override int Def { get; set; } = 100;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public FeatherBoyCard()
        {
            Attributes.WithShower();
            Types.HasGlass();
        }

        public AngryEagleCard Evolve()
        {
            return new();
        }
        public SurpriseEggCard Devolve()
        {
            return new();
        }

        public Task Handle(CardPlayedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class AngryEagleCard : MonsterCard,IDevolve<FeatherBoyCard>,INotificationHandler<CardEvolvedNotification>
    {
        public override string Name { get; set; } = "Angry Eagle";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 150;
        public override int Atk { get; set; } = 150;
        public override int Def { get; set; } = 150;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public AngryEagleCard()
        {
            Attributes.WithShower();
            Types.HasGlass().HasRock();
        }
     
        public FeatherBoyCard Devolve()
        {
            return new();
        }

        public Task Handle(CardEvolvedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class ReflektorCard : MonsterCard, IEvolve<AbsorberCard> , INotificationHandler<CardPlayedNotification>
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
            Attributes.WithEarlyBird().WithShower();
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
    public class AbsorberCard : MonsterCard, IEvolve<MatteCard>,IDevolve<ReflektorCard> , INotificationHandler<CardEvolvedNotification>
    {
        public override string Name { get; set; } = "Absorber";
        public override ICardImages CardImages { get; set; }
        public override int Hp { get; set; } = 75;
        public override int Atk { get; set; } = 0;
        public override int Def { get; set; } = 120;
        public sealed override IList<ICardAttribute> Attributes { get; set; } = new List<ICardAttribute>();
        public sealed override IList<IMonsterType> Types { get; set; } = new List<IMonsterType>();

        public AbsorberCard()
        {
            Attributes.WithEarlyBird().WithShower();
            Types.HasRock().HasGlass();
        }

        public MatteCard Evolve()
        {
            return new();
        }
        public ReflektorCard Devolve()
        {
            return new();
        }

        public Task Handle(CardEvolvedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class MatteCard : MonsterCard,IDevolve<AbsorberCard>, INotificationHandler<CardDiedNotification>
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
            Attributes.WithTarget().WithWill();
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