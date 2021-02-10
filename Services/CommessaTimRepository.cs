using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Entities;

namespace SmartB.API.Services
{
    public class CommessaTimRepository : ICommessaTimRepository, IDisposable
    {
        private AppDbContext _context;

        public CommessaTimRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CommessaTIM> GetCommessaTimAsync(string barcode)
        {
            return await _context.CommessaTim.FirstOrDefaultAsync(ct => ct.Barcode == barcode);
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
