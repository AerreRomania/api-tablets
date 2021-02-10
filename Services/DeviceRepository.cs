using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Entities;

namespace SmartB.API.Services
{
    public class DeviceRepository : IDeviceRepository, IDisposable
    {
        private AppDbContext _context;

        public DeviceRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<Devices> GetDeviceAsync(int id)
        {
            return await _context.Devices.FirstOrDefaultAsync(d => d.DeviceID == id);
        }

        public async Task<Devices> GetDeviceBySNAsync(string SN)
        {
            return await _context.Devices.FirstOrDefaultAsync(d => d.SN == SN);
        }

        public void AddDevice(Devices device)
        {
            if (device==null)
            {
                throw new ArgumentException(nameof(device));
            }

            if (!_context.Devices.Any(d=>d.SN == device.SN))
            {
                _context.Add(device);
            }
        }

        public void UpdateDevice(Devices device)
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
