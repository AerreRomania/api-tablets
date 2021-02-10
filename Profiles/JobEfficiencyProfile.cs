using AutoMapper;

namespace SmartB.API.Profiles
{
    public class JobEfficiencyProfile : Profile
    {
        public JobEfficiencyProfile()
        {
            CreateMap<Entities.JobEfficiency, Models.JobEfficiency>();
            CreateMap<Models.JobEfficiencyForCreation, Entities.JobEfficiency>();
        }
    }
}
