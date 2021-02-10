using AutoMapper;

namespace SmartB.API.Profiles
{
    public class AngajatiProfile : Profile
    {
        public AngajatiProfile()
        {
            CreateMap<Entities.Angajati, Models.Angajati>();
            CreateMap<Models.AngajatiForCreation, Entities.Angajati>();
            CreateMap<Models.AngajatiForUpdate, Entities.Angajati>();
        }  
    }
}
