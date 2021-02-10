using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Entities;

namespace SmartB.API.Services
{
    public class JobEfficiencyRepository: IJobEfficiencyRepository, IDisposable
    {
        private AppDbContext _context;

        public JobEfficiencyRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<JobEfficiency> GetJobEfficiencyAsync(int id)
        {
            return await _context.JobEfficiency.FirstOrDefaultAsync(je => je.EfficiencyID == id);
        }

        public void AddJobEfficiency(JobEfficiency jobEfficiency)
        {
            if (jobEfficiency == null)
            {
                throw new ArgumentNullException(nameof(jobEfficiency));
            }

            _context.Add(jobEfficiency);
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
