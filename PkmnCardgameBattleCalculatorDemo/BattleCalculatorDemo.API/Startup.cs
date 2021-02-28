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
using System.Reflection;
using System.Threading.Tasks;
using BattleCalculatorDemo.AbstractionLayer;
using BattleCalculatorDemo.API.Hubs;
using BattleCalculatorDemo.Cards.CardAttributes;
using BattleCalculatorDemo.Cards.MonsterCards;
using BattleCalculatorDemo.Cards.MonsterType;
using BattleCalculatorDemo.Models;
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

            MongoDbConnection.InitializeAndStartConnection(
                "mongodb+srv://dbusr:TgFbMteUpmbWuQKv@cluster0.zvps8.mongodb.net/pkmndb?retryWrites=true&w=majority",
                "pkmndb");
            // MongoDbConnection.InitializeAndStartConnection(databaseName: "pkmndb");
            BsonRegister();
            services.AddSingleton<Crud<MonsterCardEntity>>();
            services.AddSingleton<Crud<CardImageEntity>>();
            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSignalR();
        }

        private static void BsonRegister()
        {
            var assemblyTypes = Assembly.LoadFrom("bin/Debug/net5.0/BattleCalculatorDemo.Cards.dll").GetTypes();
            var cards = assemblyTypes.Where(t => !t.IsAbstract && t.IsAssignableTo(typeof(MonsterCard)));
            var attributes = assemblyTypes.Where(t => t.IsAssignableTo(typeof(ICardAttribute)));
            var monsterTypes = assemblyTypes.Where(t => t.IsAssignableTo(typeof(IMonsterType)));
            foreach (var type in cards.Union(attributes).Union(monsterTypes))
            {
                var classMapDefinition = typeof(BsonClassMap<>);
                var classMapType = classMapDefinition.MakeGenericType(type);
                var classMap = (BsonClassMap)Activator.CreateInstance(classMapType);
                BsonClassMap.RegisterClassMap(classMap);
            }
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
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3230").AllowCredentials());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<GameManagerHub>("/hub/gameManagerHub");
            });
        }
    }
}