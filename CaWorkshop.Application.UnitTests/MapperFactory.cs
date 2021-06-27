using AutoMapper;
using CaWorkshop.Application.Common.Mapping;

namespace CaWorkshop.Application.UnitTests
{
    public class MapperFactory
    {
        public static IMapper Create()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(MappingProfile));
            });
            return configurationProvider.CreateMapper();
        }
    }
}
