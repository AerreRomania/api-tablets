using System.Threading.Tasks;
using SmartB.API.Entities;

namespace SmartB.API.Contracts.Services
{
    public interface IDeviceRepository
    {
        Task<Devices> GetDeviceAsync(int id);
        Task<Devices> GetDeviceBySNAsync(string SN);

        void AddDevice(Devices device);
        void UpdateDevice(Devices device);
        Task<bool> SaveChangesAsync();
    }
}
