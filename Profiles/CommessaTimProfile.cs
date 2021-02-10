using AutoMapper;

namespace SmartB.API.Profiles
{
    public class CommessaTimProfile : Profile
    {
        public CommessaTimProfile()
        {
            CreateMap<Entities.CommessaTIM, Models.CommessaTim>();
        }
    }
}
