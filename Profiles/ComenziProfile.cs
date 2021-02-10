using AutoMapper;

namespace SmartB.API.Profiles
{
    public class ComenziProfile : Profile
    {
        public ComenziProfile()
        {
            CreateMap<Entities.Comenzi, Models.Comenzi>();
        }
    }
}
