using AutoMapper;
using BattleCalculatorDemo.Models;
using MongoORM4NetCore;

namespace BattleCalculatorDemo.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MonsterCardEntity, MonsterCardModel>();
            CreateMap<ImageModel, CardImageEntity>();
        }
    }
}