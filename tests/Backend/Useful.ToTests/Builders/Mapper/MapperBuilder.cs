using AutoMapper;
using MyBooksRecommendations.Application.Services.AutoMapper;

namespace Useful.ToTests.Builders.Mapper
{
    public class MapperBuilder
    {
        public static IMapper Build()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            return mockMapper.CreateMapper();
        }
    }
}
