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
using BattleCalculatorDemo.Crud;
using BattleCalculatorDemo.Models;
using BattleCalculatorDemo.Models.CardAttributes;
using BattleCalculatorDemo.Models.MonsterTypes;
using MongoDB.Bson.Serialization;
using MongoORM4NetCore;
using StackExchange.Redis;

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
            BsonClassMap.RegisterClassMap<HardShellCardAttribute>();
            BsonClassMap.RegisterClassMap<IronWillCardAttribute>();
            BsonClassMap.RegisterClassMap<SharperCardAttribute>();
            BsonClassMap.RegisterClassMap<WeightlessCardAttribute>();

            BsonClassMap.RegisterClassMap<GlassMonsterType>();
            BsonClassMap.RegisterClassMap<RockMonsterType>();
            BsonClassMap.RegisterClassMap<PaperMonsterType>();
            BsonClassMap.RegisterClassMap<SoundMonsterType>();
            BsonClassMap.RegisterClassMap<ScissorsMonsterType>();

            services.AddSingleton<MonsterCrud>();
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
