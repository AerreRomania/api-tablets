using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Entities;

namespace SmartB.API.Services
{
    public class MasiniRepository : IMasiniRepository, IDisposable
    {
        private AppDbContext _context;

        public MasiniRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Masini>> GetMachinesAsync(int idSector, string line)
        {
            return await _context.Masinis.Where(m => m.IdSector == idSector && m.Linie == line).ToListAsync();
        }

        public async Task<Masini> GetMachineAsync(int id)
        {
            return await _context.Masinis.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool?> IsMachineActiveAsync(int id)
        {
            var machineState = await _context.Masinis.FirstOrDefaultAsync(m => m.Id == id);
            return machineState?.Active;
        }

        public void UpdateMachine(Masini machineForUpdate)
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
