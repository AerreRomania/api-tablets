using AutoMapper;

namespace SmartB.API.Profiles
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Entities.Devices, Models.Device>();
            CreateMap<Models.DeviceForCreation, Entities.Devices>();
            CreateMap<Models.DeviceForUpdate, Entities.Devices>();
        }
    }
}
