using AutoMapper;

namespace SmartB.API.Profiles
{
    public class DeviceInfoProfile : Profile
    {
        public DeviceInfoProfile()
        {
            CreateMap<Entities.DeviceInfo, Models.DeviceInfo>();
            CreateMap<Models.DeviceInfoForCreation, Entities.DeviceInfo>();
            CreateMap<Models.DeviceInfoForUpdate, Entities.DeviceInfo>();
        }
    }
}
