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
    public class PauseRepository : IPauseRepository, IDisposable
    {
        private AppDbContext _context;

        public PauseRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Pause> GetPauseAsync(int id)
        {
            return await _context.Pause.FirstOrDefaultAsync(p => p.PauseID == id);
        }

        public async Task<IEnumerable<Pause>> GetPausesAsync(int jobId)
        {
            return await _context.Pause.Where(p => p.RealizareID == jobId).ToListAsync();
        }

        public void AddPause(Pause pauseToAdd)
        {
            if (pauseToAdd == null)
            {
                throw new ArgumentNullException(nameof(pauseToAdd));
            }

            _context.Add(pauseToAdd);
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
