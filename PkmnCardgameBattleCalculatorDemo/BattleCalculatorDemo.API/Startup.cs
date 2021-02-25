using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.MonsterType;
using BattleCalculatorDemo.Crud;
using MongoDB.Bson.Serialization;
using MongoORM4NetCore;

namespace BattleCalculatorDemo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            BsonRegister();
            MongoDbConnection.InitializeAndStartConnection(
                "mongodb+srv://dbusr:TgFbMteUpmbWuQKv@cluster0.zvps8.mongodb.net/pkmndb?retryWrites=true&w=majority",
                "pkmndb");
            services.AddSingleton<MonsterCrud>();
            services.AddSingleton<Crud<CardAttribute>>();
            services.AddSwaggerGen();
        }

        private static void BsonRegister()
        {
            BsonClassMap.RegisterClassMap<HardShellCardAttribute>();
            BsonClassMap.RegisterClassMap<IronWillCardAttribute>();
            BsonClassMap.RegisterClassMap<SharperCardAttribute>();
            BsonClassMap.RegisterClassMap<WeightlessCardAttribute>();
            BsonClassMap.RegisterClassMap<GlassMonsterType>();
            BsonClassMap.RegisterClassMap<RockMonsterType>();
            BsonClassMap.RegisterClassMap<PaperMonsterType>();
            BsonClassMap.RegisterClassMap<SoundMonsterType>();
            BsonClassMap.RegisterClassMap<ScissorsMonsterType>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}