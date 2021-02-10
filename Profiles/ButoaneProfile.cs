using AutoMapper;

namespace SmartB.API.Profiles
{
    public class ButoaneProfile : Profile
    {
        public ButoaneProfile()
        {
            CreateMap<Entities.Butoane, Models.Butoane>();
            CreateMap<Models.ButoaneForCreation, Entities.Butoane>();
        }
    }
}
