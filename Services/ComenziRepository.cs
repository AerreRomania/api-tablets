using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLog;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Entities;
namespace SmartB.API.Services
{
    public class ComenziRepository : IComenziRepository, IDisposable
    {
        private AppDbContext _context;
      
        public ComenziRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Comenzi>> GetOrdersAsync(int idSector)
        {
            return await _context.Comenzis.Where(c => c.IdSector == idSector).ToListAsync();
        }

        public async Task<Comenzi> GetOrderAsync(int id)
        {
            return await _context.Comenzis.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comenzi> GetOrderWithName(string commessa)
        {
            return await _context.Comenzis.FirstOrDefaultAsync(c => c.NrComanda == commessa);
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
