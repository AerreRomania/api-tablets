using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Entities;

namespace SmartB.API.Services
{
    public class DeviceInfoRepository : IDeviceInfoRepository, IDisposable
    {
        private AppDbContext _context;

        public DeviceInfoRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        public async Task<DeviceInfo> GetDeviceInfoAsync(int id)
        {
            return await _context.DeviceInfo.FirstOrDefaultAsync(di => di.DeviceInfoID == id);
        }

        public void AddDeviceInfo(DeviceInfo deviceInfo)
        {
            if (deviceInfo == null)
            {
                throw new ArgumentException(nameof(deviceInfo));
            }

            _context.Add(deviceInfo);
        }

        public void UpdateDeviceInfo(DeviceInfo deviceInfo)
        {

        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
