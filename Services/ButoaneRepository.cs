using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Entities;

namespace SmartB.API.Services
{
    public class ButoaneRepository : IButoaneRepository, IDisposable
    {
        private AppDbContext _context;

        public ButoaneRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Butoane> GetClickAsync(long id)
        {
            return await _context.Butoane.FirstOrDefaultAsync(b => b.Id == id);
        }

        public void AddClick(Butoane butoaneToAdd)
        {
            if (butoaneToAdd == null)
            {
                throw new ArgumentNullException(nameof(butoaneToAdd));
            }

            _context.Add(butoaneToAdd);
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
