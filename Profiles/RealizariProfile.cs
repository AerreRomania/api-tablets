using AutoMapper;

namespace SmartB.API.Profiles
{
    public class RealizariProfile : Profile
    {
        public RealizariProfile()
        {
            CreateMap<Entities.Realizari, Models.Realizari>();
            CreateMap<Models.RealizariForCreation, Entities.Realizari>();
            CreateMap<Models.RealizariForUpdate, Entities.Realizari>();
        }
    }
}
