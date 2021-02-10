using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Entities;

namespace SmartB.API.Services
{
    public class ArticolRepository : IArticolRepository, IDisposable
    {
        private AppDbContext _context;

        public ArticolRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Articole> GetArticleAsync(int id)
        {
            return await _context.Articoles.FirstOrDefaultAsync(a => a.Id == id);
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
