using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Models;

namespace SmartB.API.Services
{
    public class OperatiArticolRepository : IOperatiArticolRepository, IDisposable
    {
        private AppDbContext _context;

        public OperatiArticolRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Phases>> GetPhasesForArticleAsync(int articleId, string machineName)
        {

                return await (from articlePhase in _context.OperatiiArticols
                              join phase in _context.Operatiis on articlePhase.IdOperatie equals phase.Id
                              join machine in _context.MachinePhases on phase.MachineID equals machine.MashinePhaseID
                              where articlePhase.IdArticol == articleId && machine.MashineName == machineName
                              select new Phases
                              {
                                  Id = phase.Id,
                                  IdOperatie = articlePhase.IdOperatie,
                                  MachineID = phase.MachineID,
                                  BucatiOra = articlePhase.BucatiOra,
                                  Centes = articlePhase.Centes,
                                  Operatie = phase.Operatie,
                                  BucatiButon = articlePhase.BucatiButon,
                                  MachineName = machine.MashineName

                              }).ToListAsync();
            
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
