using System.Threading.Tasks;
using SmartB.API.Entities;

namespace SmartB.API.Contracts.Services
{
    public interface IDeviceInfoRepository
    {
        Task<DeviceInfo> GetDeviceInfoAsync(int id);
        void AddDeviceInfo(DeviceInfo deviceInfo);
        void UpdateDeviceInfo(DeviceInfo deviceInfo);
        Task<bool> SaveChangesAsync();
    }
}
