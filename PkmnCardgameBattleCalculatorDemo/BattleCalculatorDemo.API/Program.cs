using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleCalculatorDemo.Models;
using BattleCalculatorDemo.Models.CardAttributes;
using BattleCalculatorDemo.Models.Evolve;
using BattleCalculatorDemo.Models.MonsterTypes;
using MongoORM4NetCore;

namespace BattleCalculatorDemo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var result = MongoDbConnection.InitializeAndStartConnection(
                "mongodb+srv://dbusr:TgFbMteUpmbWuQKv@cluster0.zvps8.mongodb.net/pkmndb?retryWrites=true&w=majority",
                "pkmndb");
            var crud = new Crud<MonsterCard>();
            crud.Insert(new MountainRangerCard());
            var monsterCards = crud.GetAll();
            var evolvable = monsterCards.First() as IEvolvable;
            var monsterCard = evolvable.Evolve();
            //var card = new MonsterCard()
            //{
            //    Name = "Mountain Ranger",
            //    Atk = 25,
            //    Hp = 50,
            //    Def = 125
            //};
            //var hardShell = new HardShellCardAttribute(25);
            //var weightless = new WeightlessCardAttribute(0, 100);
            //card.Attributes.Add(hardShell);
            //card.Attributes.Add(weightless);
            //card.AddTypes(new PaperMonsterType(), new RockMonsterType());
            //crud.Insert(card);
            //var all = crud.GetAll();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
