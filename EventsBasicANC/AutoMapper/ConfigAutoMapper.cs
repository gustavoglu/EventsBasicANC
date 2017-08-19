using AutoMapper;

namespace EventsBasicANC.AutoMapper
{
    public class ConfigAutoMapper
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelProfile>();
                cfg.AddProfile<ViewModelToDomainProfile>();
            });
        }
    }
}
