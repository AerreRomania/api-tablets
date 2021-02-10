
using AutoMapper;

namespace SmartB.API.Profiles
{
    public class PauseProfile : Profile
    {
        public PauseProfile()
        {
            CreateMap<Entities.Pause, Models.Pause>();
            CreateMap<Models.PauseForCreation, Entities.Pause>();
        }
    }
}
