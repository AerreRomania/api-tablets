using AutoMapper;

namespace SmartB.API.Profiles
{
    public class ArticoleProfile : Profile
    {
        public ArticoleProfile()
        {
            CreateMap<Entities.Articole, Models.Articole>();
        }
    }
}
