using AutoMapper;

namespace SmartB.API.Profiles
{
    public class MasiniProfile : Profile
    {
        public MasiniProfile()
        {
            CreateMap<Entities.Masini, Models.Masini>();

            CreateMap<Entities.Masini, Models.Masini>()
                .ForMember(dest => dest.CodeAndName, opt => opt
                    .MapFrom(src => $"{src.CodMasina} - {src.Descriere}"));

            CreateMap<Models.MasiniForUpdate, Entities.Masini>();

        }
    }
}
