using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
